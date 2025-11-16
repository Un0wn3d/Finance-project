using BudgetPlanningApp.AppCode;
using BudgetPlanningApp.Forms.Systems;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetPlanningApp.Forms.Acco {
  public partial class RenderPlanFactForm : Form {
    AccountsApp _AccountsApp = new AccountsApp();
    public RenderPlanFactForm() {
      InitializeComponent();
      InitMonthPickers();
    }

    private void FormReportBtn_Click(object sender, EventArgs e) {
      int userId = LoginForm.CurrentUser.UserId;

      // Режим вибору місяців для DTP (як ми робили раніше: CustomFormat = "MMMM yyyy"; ShowUpDown = true)
      DateTime month = new DateTime(ReportMonthDTP.Value.Year, ReportMonthDTP.Value.Month, 1);

      List<PlanFactRow> rows = _AccountsApp.GetUserPlanFactByMonth(userId, month);
      RenderPlanFactToAccTextBox(rows, AccTBox, month);
    }



    private void RenderPlanFactToAccTextBox(List<PlanFactRow> data, TextBox accTBox, DateTime month) {
      accTBox.Clear();

      if (data == null || data.Count == 0) {
        accTBox.Text = "За вибраний місяць даних не знайдено.";
        return;
      }

      var ua = CultureInfo.GetCultureInfo("uk-UA");
      var sb = new StringBuilder();

      string monthTitle = month.ToString("MMMM yyyy", ua);
      sb.AppendLine($"Звіт «План / Факт / Відхилення» — {monthTitle}");
      sb.AppendLine(new string('=', 105));

      double grandPlanned = 0.0;
      double grandActual = 0.0;

      // Групування по категоріях
      foreach (var grp in data.GroupBy(x => x.CategoryName)) {
        sb.AppendLine();
        sb.AppendLine($"Категорія: {grp.Key}");
        sb.AppendLine(new string('-', 105));

        double catPlanned = 0.0;
        double catActual = 0.0;

        foreach (var row in grp) {
          catPlanned += row.Planned;
          catActual += row.Actual;

          string planned = row.Planned.ToString("N2", ua);
          string actual = row.Actual.ToString("N2", ua);
          string dev = row.Deviation.ToString("N2", ua);
          string util = row.UtilizationPercent.ToString("N1", ua) + "%";

          sb.AppendLine($"{row.ItemName,-30} План: {planned,10}  Факт: {actual,10}  Відхил: {dev,10}  Виконання: {util,7}");
        }

        grandPlanned += catPlanned;
        grandActual += catActual;

        string catDev = (catActual - catPlanned).ToString("N2", ua);
        string catPlan = catPlanned.ToString("N2", ua);
        string catAct = catActual.ToString("N2", ua);
        string catUtil = (catPlanned <= 0.0 ? 0.0 : (catActual / catPlanned * 100.0)).ToString("N1", ua) + "%";

        sb.AppendLine(new string('-', 105));
        sb.AppendLine($"Підсумок категорії → План: {catPlan}  Факт: {catAct}  Відхил: {catDev}  Виконання: {catUtil}");
      }

      sb.AppendLine();
      sb.AppendLine(new string('=', 105));
      string gPlan = grandPlanned.ToString("N2", ua);
      string gAct = grandActual.ToString("N2", ua);
      string gDev = (grandActual - grandPlanned).ToString("N2", ua);
      string gUtil = (grandPlanned <= 0.0 ? 0.0 : (grandActual / grandPlanned * 100.0)).ToString("N1", ua) + "%";

      sb.AppendLine($"ЗАГАЛОМ → План: {gPlan}  Факт: {gAct}  Відхил: {gDev}  Виконання: {gUtil}");

      accTBox.Text = sb.ToString();
    }

    private void InitMonthPickers() {
      var ua = System.Globalization.CultureInfo.GetCultureInfo("uk-UA");

      ReportMonthDTP.Format = DateTimePickerFormat.Custom;
      ReportMonthDTP.CustomFormat = "MMMM yyyy";
    }

    private void ExportBtn_Click(object sender, EventArgs e) {
      if (AccTBox.Text != "") {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK) {
          PdfDocument document = new PdfDocument();
          document.Info.Title = "Generated PDF";

          PdfPage page = document.AddPage();
          XGraphics gfx = XGraphics.FromPdfPage(page);
          var font = new XFont("Courier New", 9, XFontStyle.Regular);


          XTextFormatter tf = new XTextFormatter(gfx);
          XRect rect = new XRect(0, 0, page.Width, page.Height);
          gfx.DrawRectangle(XBrushes.White, rect);

          tf.DrawString(AccTBox.Text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

          document.Save(saveFileDialog.FileName);
          document.Close();
          MessageBox.Show("PDF файл успішно створений.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } else {
        MessageBox.Show("Спочатку створіть звіт", "Увага!");
      }
    }

  }
}
