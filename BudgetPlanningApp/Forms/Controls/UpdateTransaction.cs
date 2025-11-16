using BudgetPlanningApp.AppCode;
using BudgetPlanningApp.Forms.Systems;
using BudgetPlanningApp.Providers;
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

namespace BudgetPlanningApp.Forms.Controls {
  public partial class UpdateTransaction : Form {
    private int _TransactionId = 0;
    private Transaction _selectedTransaction = new Transaction();
    private TransactionProvider _TransactionProvider = new TransactionProvider();
    private ValidationMy _Validation = new ValidationMy();
    private BudgetItemProvider _BudgetItemPrivider = new BudgetItemProvider();
    private List<BudgetItem> _BudgetItemList = new List<BudgetItem>();
    private LogsProvider _LogProvider = new LogsProvider();
    public UpdateTransaction(int TransactionId) {
      InitializeComponent();
      _TransactionId = TransactionId;
      LoadAllDate();

    }


    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        double value = double.Parse(AmountTBox.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
        _TransactionProvider.UpdateTransaction(LoginForm.CurrentUser.UserId, Convert.ToInt32(BudgetItemCBox.SelectedValue), TransactionTypeCBox.Text,
          Convert.ToDouble(AmountTBox.Text), TransactionDateDTP.Value, DescriptionTBox.Text, _TransactionId);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач оновив транзакцію ID: {_TransactionId} " +
            $"(елемент: '{BudgetItemCBox.Text}', тип: '{TransactionTypeCBox.Text}', " +
            $"нова сума: {value.ToString("F2", CultureInfo.InvariantCulture)}, дата: {TransactionDateDTP.Value:dd.MM.yyyy})",
            DateTime.Now);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _TransactionProvider.DeleteTransaction(_TransactionId);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач видалив транзакцію ID: {_TransactionId} " +
            $"(елемент: '{BudgetItemCBox.Text}', тип: '{TransactionTypeCBox.Text}', дата: {TransactionDateDTP.Value:dd.MM.yyyy})",
            DateTime.Now);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _BudgetItemList = _BudgetItemPrivider.GetAllBudgetItem();
      BudgetItemCBox.DataSource = _BudgetItemList;
      BudgetItemCBox.ValueMember = "ItemId";
      BudgetItemCBox.DisplayMember = "ItemName";

      _selectedTransaction = _TransactionProvider.SelectedTransactionById(_TransactionId);
      BudgetItemCBox.SelectedValue = _selectedTransaction.ItemId;
      AmountTBox.Text = _selectedTransaction.Amount.ToString();
      TransactionTypeCBox.Text = _selectedTransaction.TransactionType;
      TransactionDateDTP.Value = _selectedTransaction.TransactionDate;
      DescriptionTBox.Text = _selectedTransaction.Description;
    }


    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      double min = 10.0;
      double max = 1_000_000.0;

      if (_Validation.TryParseDouble(AmountTBox.Text, out double amount)) {
        if (_Validation.IsDataInThisScope(min, max, amount)) {
          AmountValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
        } else {
          AmountValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
          isCorrect = false;
        }
      } else {
        AmountValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (Convert.ToInt32(BudgetItemCBox.SelectedValue) > 0) {
        BudgetItemValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        BudgetItemValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      return isCorrect;
    }

  }
}
