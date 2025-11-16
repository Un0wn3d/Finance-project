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
  public partial class MonthlyExpensesForm : Form {
    AccountsApp _AccountsApp = new AccountsApp();
    public MonthlyExpensesForm() {
      InitializeComponent();
      InitMonthPickers();
    }


    private void FormReportBtn_Click(object sender, EventArgs e) {
      if (!IsDataEnteringCorrect()) return;

      int userId = LoginForm.CurrentUser.UserId;

      // Зчитуємо місячні межі з DTP (див. налаштування нижче)
      DateTime fromMonth = new DateTime(FromDTP.Value.Year, FromDTP.Value.Month, 1);
      DateTime toMonth = new DateTime(ToDTP.Value.Year, ToDTP.Value.Month, 1);

      var data = _AccountsApp.GetUserMonthlyExpenses(userId, fromMonth, toMonth);
      RenderMonthlyExpensesToAccTextBox(data, AccTBox);
    }

    private void RenderMonthlyExpensesToAccTextBox(List<MonthlyExpense> data, TextBox accTBox) {
      var sb = new StringBuilder();

      if (data == null || data.Count == 0) {
        accTBox.Text = "За вказаний період витрат не знайдено.";
        return;
      }

      // Заголовок
      sb.AppendLine("Звіт по витратам користувача (по місячно)");
      sb.AppendLine("=======================================");

      double grandTotal = 0.0;

      foreach (var row in data) {
        var monthName = new DateTime(row.Year, row.Month, 1)
                            .ToString("MMMM yyyy", CultureInfo.GetCultureInfo("uk-UA"));

        sb.AppendLine($"{monthName,-20} — {row.ExpenseSum.ToString("N2", CultureInfo.GetCultureInfo("uk-UA"))}");
        grandTotal += row.ExpenseSum;
      }

      sb.AppendLine("---------------------------------------");
      sb.AppendLine($"Разом: {grandTotal.ToString("N2", CultureInfo.GetCultureInfo("uk-UA"))}");

      accTBox.Text = sb.ToString();
    }

    private void InitMonthPickers() {
      var ua = System.Globalization.CultureInfo.GetCultureInfo("uk-UA");

      FromDTP.Format = DateTimePickerFormat.Custom;
      FromDTP.CustomFormat = "MMMM yyyy";

      ToDTP.Format = DateTimePickerFormat.Custom;
      ToDTP.CustomFormat = "MMMM yyyy";
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
      return isCorrect;
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
          var font = new XFont("Courier New", 12, XFontStyle.Regular);


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
