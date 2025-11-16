using BudgetPlanningApp.AppCode;
using BudgetPlanningApp.Forms.Systems;
using BudgetPlanningApp.Providers;
using LiveCharts;
using LiveCharts.Wpf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetPlanningApp.Forms.Acco {
  public partial class StorysForUserByBudgetItemForm : Form {
    private AccountsApp _AccountsApp = new AccountsApp();
    private BudgetItemProvider _BudgetItemPrivider = new BudgetItemProvider();
    private List<BudgetItem> _BudgetItemList = new List<BudgetItem>();


    public StorysForUserByBudgetItemForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void FormingBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        int userId = LoginForm.CurrentUser.UserId; // джерело поточного користувача
        int itemId = Convert.ToInt32(BudgetItemCBox.SelectedValue);

        // Отримати агреговані дані по днях
        List<Storys> stories = _AccountsApp
            .GetAllStorysForUserByBudgetItemIdAndDate(userId, itemId, FromDTP.Value, ToDTP.Value);

        // Побудувати графік
        BuildUserSpendingChartFromStories(stories);
      }
    }


    private void BuildUserSpendingChartFromStories(List<Storys> stories) {
      // Без даних — очистити й повідомити
      if (stories == null || stories.Count == 0) {
        GraphicsCC.Series.Clear();
        GraphicsCC.AxisX.Clear();
        GraphicsCC.AxisY.Clear();
        MessageBox.Show("За вказаним періодом даних не знайдено.", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      // Осі
      GraphicsCC.AxisX.Clear();
      GraphicsCC.AxisX.Add(new Axis {
        Title = "Дата",
        Labels = stories.Select(s => s.StoryDateTime.ToString("dd.MM.yyyy")).ToArray()
      });

      GraphicsCC.AxisY.Clear();
      GraphicsCC.AxisY.Add(new Axis {
        Title = "Сума"
      });

      // Серії
      var spendingSeries = new LineSeries {
        Title = "SpendingSumma",
        Values = new ChartValues<double>(stories.Select(s => s.SpendingSumma)),
        DataLabels = false,
        PointGeometrySize = 8
      };

      var profitSeries = new LineSeries {
        Title = "ProfitSumma",
        Values = new ChartValues<double>(stories.Select(s => s.ProfitSumma)),
        DataLabels = false,
        PointGeometrySize = 8
      };

      GraphicsCC.Series.Clear();
      // Якщо треба лише витрати — додайте тільки spendingSeries
      GraphicsCC.Series.Add(profitSeries);
      GraphicsCC.Series.Add(spendingSeries);
    }

    private void LoadAllDate() {
      _BudgetItemList = _BudgetItemPrivider.GetAllBudgetItem();
      BudgetItemCBox.DataSource = _BudgetItemList;
      BudgetItemCBox.ValueMember = "ItemId";
      BudgetItemCBox.DisplayMember = "ItemName";

    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (FromDTP.Value <= ToDTP.Value) {
        FromValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
        ToValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        FromValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        ToValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (Convert.ToInt32(BudgetItemCBox.SelectedValue) > 0) {
        BudgetItemValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        BudgetItemValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }


    private bool HasLiveChartData() {
      return GraphicsCC != null
          && GraphicsCC.Series != null
          && GraphicsCC.Series.Count > 0
          && GraphicsCC.Series.Any(s => s?.Values != null && s.Values.Count > 0);
    }

    private Bitmap RenderControlToBitmap(Control ctrl) {
      // гарантуємо актуальний рендер
      ctrl.Refresh();
      Application.DoEvents();

      var bmp = new Bitmap(ctrl.Width, ctrl.Height);
      ctrl.DrawToBitmap(bmp, new Rectangle(Point.Empty, ctrl.Size));
      return bmp; // викликаючий код зобов’язаний Dispose()
    }


    private void ExportBtn_Click(object sender, EventArgs e) {
      if (!HasLiveChartData()) {
        MessageBox.Show("Немає даних для побудови або експорту графіка.",
                        "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      using (var sfd = new SaveFileDialog()) {
        sfd.Filter = "PDF files (*.pdf)|*.pdf";
        sfd.FileName = "chart.pdf";
        if (sfd.ShowDialog(this) != DialogResult.OK) return;

        using (var bmp = RenderControlToBitmap(GraphicsCC))
        using (var ms = new System.IO.MemoryStream()) {
          bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
          ms.Position = 0;

          var document = new PdfDocument();
          document.Info.Title = "Chart Export";
          var page = document.AddPage();

          using (var gfx = XGraphics.FromPdfPage(page)) {
            var pageRect = new XRect(0, 0, page.Width, page.Height);
            gfx.DrawRectangle(XBrushes.White, pageRect);

            // === Ваш динамічний текст-заголовок ===
            string accountName = BudgetItemCBox.Text; // або будь-який інший ідентифікатор рахунку
            string periodInfo =
                $"Витрати за обраним рахунком \"{accountName}\", за період від {FromDTP.Value:dd.MM.yyyy} до {ToDTP.Value:dd.MM.yyyy}.";

            var titleFont = new XFont("Arial", 14, XFontStyle.Bold);
            var tf = new XTextFormatter(gfx);
            var titleRect = new XRect(40, 30, page.Width - 80, 60);
            tf.DrawString(periodInfo, titleFont, XBrushes.Black, titleRect, XStringFormats.TopLeft);
            // ========================================

            using (var ximg = XImage.FromStream(ms)) {
              double margin = 40;
              double maxW = page.Width - 2 * margin;
              double maxH = page.Height - 2 * margin - 60;

              double wPt = ximg.PixelWidth * 72.0 / ximg.HorizontalResolution;
              double hPt = ximg.PixelHeight * 72.0 / ximg.VerticalResolution;

              double scale = Math.Min(maxW / wPt, maxH / hPt);
              double drawW = wPt * scale;
              double drawH = hPt * scale;

              double x = (page.Width - drawW) / 2.0;
              double y = titleRect.Bottom + 10;

              gfx.DrawImage(ximg, x, y, drawW, drawH);
            }
          }

          document.Save(sfd.FileName);
          document.Close();

          MessageBox.Show("PDF файл успішно створений.",
                          "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }


  }
}