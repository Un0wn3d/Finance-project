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
  public partial class BudgetItemForm : Form {
    private int _selectedRowIndex = 0;
    private ValidationMy _validation = new ValidationMy();
    private BudgetItemProvider _BudgetItemPrivider = new BudgetItemProvider();
    private List<BudgetItem> _BudgetItemList = new List<BudgetItem>();
    private BudgetCategoriesProvider _BudgetCategoriesProvider = new BudgetCategoriesProvider();
    private List<BudgetCategory> _BudgetCategoryList = new List<BudgetCategory>();
    private ValidationMy _Validation = new ValidationMy();
    private LogsProvider _LogProvider = new LogsProvider();
    public BudgetItemForm() {
      InitializeComponent();
      LoadAllDate();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        double value = double.Parse(DefaultAmountTBox.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
        _BudgetItemPrivider.InsertBudgetItem(Convert.ToInt32(BudgetCategoryCBox.SelectedValue.ToString()), ItemNameTBox.Text,
          value, DescriptionTBox.Text);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач додав новий елемент витрат: '{ItemNameTBox.Text}' " +
            $"(категорія: '{BudgetCategoryCBox.Text}', сума: {value.ToString("F2", CultureInfo.InvariantCulture)})",
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

    private void BudgetItemGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && BudgetItemGridView[0, e.RowIndex].Value.ToString() != _BudgetItemList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateBudgetItemForm updateBudgetItemForm = new UpdateBudgetItemForm(Convert.ToInt32(BudgetItemGridView[0, e.RowIndex].Value.ToString()));
        updateBudgetItemForm.ShowDialog();
        DataLoad();
      }
    }

    private void LoadAllDate() {
      _BudgetCategoryList = _BudgetCategoriesProvider.GetAllBudgetCategory();
      BudgetCategoryCBox.DataSource = _BudgetCategoryList;
      BudgetCategoryCBox.ValueMember = "CategoryId";
      BudgetCategoryCBox.DisplayMember = "CategoryName";
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (BudgetItemGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = BudgetItemGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _BudgetItemList = _BudgetItemPrivider.GetAllBudgetItem();
        LoadDataInBudgetItemGridView(_BudgetItemList);
        if (_selectedRowIndex == BudgetItemGridView.Rows.Count) {
          _selectedRowIndex = BudgetItemGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          BudgetItemGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          BudgetItemGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInBudgetItemGridView(List<BudgetItem> BudgetItemList) {
      BudgetItemGridView.DataSource = null;
      BudgetItemGridView.Columns.Clear();
      BudgetItemGridView.AutoGenerateColumns = false;
      BudgetItemGridView.RowHeadersVisible = false;

      BudgetItemGridView.DataSource = BudgetItemList;

      if (BudgetItemList.Count > 0) {
        if (BudgetItemList[0].Message == NamesMy.NoDataNames.NoDataInBudgetItem) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = BudgetItemGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          BudgetItemGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn ItemIdColumn = new DataGridViewTextBoxColumn();
          ItemIdColumn.DataPropertyName = "ItemId";
          BudgetItemGridView.Columns.Add(ItemIdColumn);
          BudgetItemGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          BudgetItemGridView.Columns.Add(numberColumn);

          DataGridViewColumn ItemNameColumn = new DataGridViewTextBoxColumn();
          ItemNameColumn.HeaderText = "Витрата";
          ItemNameColumn.DataPropertyName = "ItemName";
          ItemNameColumn.Width = NamesMy.SizeOptins.NameSize;
          BudgetItemGridView.Columns.Add(ItemNameColumn);

          DataGridViewColumn DefaultAmountColumn = new DataGridViewTextBoxColumn();
          DefaultAmountColumn.HeaderText = "Сума";
          DefaultAmountColumn.DataPropertyName = "DefaultAmount";
          DefaultAmountColumn.Width = 120;
          DefaultAmountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          BudgetItemGridView.Columns.Add(DefaultAmountColumn);

       }
        for (int i = 0; i < BudgetItemGridView.Columns.Count; i++) {
          BudgetItemGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      ItemNameTBox.Text = "";
      DefaultAmountTBox.Text = "0.00";
      BudgetCategoryCBox.SelectedIndex = 0;
      DescriptionTBox.Text = "";
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
