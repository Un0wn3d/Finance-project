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

namespace BudgetPlanningApp.Forms.Dict {
  public partial class UpdateBudgetItemForm : Form {
    private int _BudgetItemId = 0;
    private BudgetItem _selectedBudgetItem = new BudgetItem();
    private BudgetItemProvider _BudgetItemProvider = new BudgetItemProvider();
    private ValidationMy _Validation = new ValidationMy();
    private BudgetCategoriesProvider _BudgetCategoriesProvider = new BudgetCategoriesProvider();
    private List<BudgetCategory> _BudgetCategoryList = new List<BudgetCategory>();
    private LogsProvider _LogProvider = new LogsProvider();
    public UpdateBudgetItemForm(int BudgetItemId) {
      InitializeComponent();
      _BudgetItemId = BudgetItemId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        double value = double.Parse(DefaultAmountTBox.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
        _BudgetItemProvider.UpdateBudgetItem(Convert.ToInt32(BudgetCategoryCBox.SelectedValue), ItemNameTBox.Text,
          value, DescriptionTBox.Text, _BudgetItemId);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач оновив елемент витрат: '{ItemNameTBox.Text}' " +
            $"(категорія: '{BudgetCategoryCBox.Text}', нова сума: {value.ToString("F2", CultureInfo.InvariantCulture)}, ID: {_BudgetItemId})",
            DateTime.Now);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?",
                          "Видалити", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
        string msg;
        bool success = _BudgetItemProvider.TryDeleteBudgetItem(_BudgetItemId, out msg);

        if (success) {
          MessageBox.Show("Позицію успішно видалено.", "Успіх",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
          this.Close();
        } else {
          MessageBox.Show(msg, "Видалення неможливе",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
    }


    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _BudgetCategoryList = _BudgetCategoriesProvider.GetAllBudgetCategory();
      BudgetCategoryCBox.DataSource = _BudgetCategoryList;
      BudgetCategoryCBox.ValueMember = "CategoryId";
      BudgetCategoryCBox.DisplayMember = "CategoryName";

      _selectedBudgetItem = _BudgetItemProvider.SelectedBudgetItemById(_BudgetItemId);

      ItemNameTBox.Text = _selectedBudgetItem.ItemName;
      BudgetCategoryCBox.SelectedValue = _selectedBudgetItem.CategoryId;
      DefaultAmountTBox.Text = _selectedBudgetItem.DefaultAmount.ToString();
      DescriptionTBox.Text = _selectedBudgetItem.Description;
    }


    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      double min = 10.0;
      double max = 1_000_000.0;

      if (_Validation.TryParseDouble(DefaultAmountTBox.Text, out double amount)) {
        if (_Validation.IsDataInThisScope(min, max, amount)) {
          DefaultAmountValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
        } else {
          DefaultAmountValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
          isCorrect = false;
        }
      } else {
        DefaultAmountValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_Validation.IsDataEntering(ItemNameTBox.Text)) {
        ItemNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ItemNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (Convert.ToInt32(BudgetCategoryCBox.SelectedValue) > 0) {
        BudgetCategoryValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        BudgetCategoryValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }


  }
}
