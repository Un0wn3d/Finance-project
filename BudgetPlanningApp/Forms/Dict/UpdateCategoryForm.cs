using BudgetPlanningApp.AppCode;
using BudgetPlanningApp.Forms.Systems;
using BudgetPlanningApp.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetPlanningApp.Forms.Dict {
  public partial class UpdateCategoryForm : Form {
    private int _CategoryId = 0;
    private BudgetCategory _selectedBudgetCategory = new BudgetCategory();
    private BudgetCategoriesProvider _BudgetCategoriesProvider = new BudgetCategoriesProvider();
    private ValidationMy _Validation = new ValidationMy();
    private LogsProvider _LogProvider = new LogsProvider();
    public UpdateCategoryForm(int CategoryId) {
      InitializeComponent();
      _CategoryId = CategoryId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _BudgetCategoriesProvider.UpdateBudgetCategory(CategoryNameTBox.Text, DescriptionTBox.Text, IsActiveChBox.Checked, _CategoryId);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач оновив категорію: '{CategoryNameTBox.Text}' (ID: {_CategoryId})",
            DateTime.Now);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цю категорію?",
                          "Підтвердження видалення",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      try {
        string msg;
        bool success = _BudgetCategoriesProvider.TryDeleteBudgetCategory(_CategoryId, out msg);

        if (success) {
          MessageBox.Show("Категорію успішно видалено.", "Успіх",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
          this.Close();
        } else {
          MessageBox.Show(msg, "Видалення неможливе",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      } catch (Exception ex) {
        MessageBox.Show("Непередбачена помилка: " + ex.Message,
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }


    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedBudgetCategory = _BudgetCategoriesProvider.SelectedBudgetCategoryById(_CategoryId);
      CategoryNameTBox.Text = _selectedBudgetCategory.CategoryName;
      DescriptionTBox.Text = _selectedBudgetCategory.Description;
      IsActiveChBox.Checked = _selectedBudgetCategory.IsActive;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_Validation.IsDataEntering(CategoryNameTBox.Text)) {
        CategoryNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CategoryNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }



  }
}
