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
  public partial class BudgetCategoriesForm : Form {
    private int _selectedRowIndex = 0;
    private ValidationMy _validation = new ValidationMy();
    private BudgetCategoriesProvider _BudgetCategoriesProvider = new BudgetCategoriesProvider();
    private List<BudgetCategory> _CategoryList = new List<BudgetCategory>();
    private LogsProvider _LogProvider = new LogsProvider();
    public BudgetCategoriesForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _BudgetCategoriesProvider.InsertBudgetCategory(CategoryNameTBox.Text, DescriptionTBox.Text, IsActiveChBox.Checked);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач додав нову категорію: '{CategoryNameTBox.Text}'",
            DateTime.Now);

        DataLoad();
        ClearAllControls();
      }
    }

    private void ClearBtn_Click(object sender, EventArgs e) {
      ClearAllControls();
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void CategoryGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && CategoryGridView[0, e.RowIndex].Value.ToString() != _CategoryList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateCategoryForm updateCategoryForm = new UpdateCategoryForm(Convert.ToInt32(CategoryGridView[0, e.RowIndex].Value.ToString()));
        updateCategoryForm.ShowDialog();
        DataLoad();
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (CategoryGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = CategoryGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _CategoryList = _BudgetCategoriesProvider.GetAllBudgetCategory();
        LoadDataInCategoryGridView(_CategoryList);
        if (_selectedRowIndex == CategoryGridView.Rows.Count) {
          _selectedRowIndex = CategoryGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          CategoryGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          CategoryGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInCategoryGridView(List<BudgetCategory> BudgetCategoryList) {
      CategoryGridView.DataSource = null;
      CategoryGridView.Columns.Clear();
      CategoryGridView.AutoGenerateColumns = false;
      CategoryGridView.RowHeadersVisible = false;

      CategoryGridView.DataSource = BudgetCategoryList;

      if (BudgetCategoryList.Count > 0) {
        if (BudgetCategoryList[0].Message == NamesMy.NoDataNames.NoDataInBudgetCategory) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = CategoryGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          CategoryGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
          DetailIdColumn.DataPropertyName = "CategoryId";
          CategoryGridView.Columns.Add(DetailIdColumn);
          CategoryGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          CategoryGridView.Columns.Add(numberColumn);

          DataGridViewColumn CategoryNameColumn = new DataGridViewTextBoxColumn();
          CategoryNameColumn.HeaderText = "Категорія";
          CategoryNameColumn.DataPropertyName = "CategoryName";
          CategoryNameColumn.Width = NamesMy.SizeOptins.NameSize;
          CategoryGridView.Columns.Add(CategoryNameColumn);

          // поле IsActive
          DataGridViewCheckBoxColumn isActiveColumn = new DataGridViewCheckBoxColumn();
          isActiveColumn.HeaderText = "Активна";
          isActiveColumn.DataPropertyName = "IsActive";
          isActiveColumn.Width = 80;
          isActiveColumn.ThreeState = false; // true = можна мати Null
          CategoryGridView.Columns.Add(isActiveColumn);
        }
        for (int i = 0; i < CategoryGridView.Columns.Count; i++) {
          CategoryGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      CategoryNameTBox.Text = String.Empty;
      DescriptionTBox.Text = String.Empty;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(CategoryNameTBox.Text)) {
        CategoryNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CategoryNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }



  }
}
