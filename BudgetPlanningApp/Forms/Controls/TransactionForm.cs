using BudgetPlanningApp.AppCode;
using BudgetPlanningApp.Forms.Dict;
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
  public partial class TransactionForm : Form {
    private int _selectedRowIndex = 0;
    private ValidationMy _Validation = new ValidationMy();
    private BudgetItemProvider _BudgetItemPrivider = new BudgetItemProvider();
    private List<BudgetItem> _BudgetItemList = new List<BudgetItem>();
    private BudgetItem _selBudgetItem = new BudgetItem();
    private BudgetCategoriesProvider _BudgetCategoriesProvider = new BudgetCategoriesProvider();
    private List<BudgetCategory> _BudgetCategoryList = new List<BudgetCategory>();
    private TransactionProvider _TransactionProvider = new TransactionProvider();
    private List<Transaction> _TransactionList = new List<Transaction>();
    private LogsProvider _LogProvider = new LogsProvider();
    private bool _isBudgetCategoryLoad = false;
    private bool _isBudgetItemLoad = false;

    public TransactionForm() {
      InitializeComponent();
      LoadAllDate();
      DataLoad();
    }

    private void BudgetCategoryCBox_SelectedValueChanged(object sender, EventArgs e) {
      if (_isBudgetCategoryLoad) {
        _BudgetItemList =
        _BudgetItemPrivider.GetAllBudgetItemByCategoryId(Convert.ToInt32(BudgetCategoryCBox.SelectedValue));
        BudgetItemCBox.DataSource = _BudgetItemList;
        BudgetItemCBox.ValueMember = "ItemId";
        BudgetItemCBox.DisplayMember = "ItemName";
        _isBudgetItemLoad = true;
        BudgetItemCBox_SelectedValueChanged(sender, e);
      }
    }

    private void BudgetItemCBox_SelectedValueChanged(object sender, EventArgs e) {
      if (_isBudgetItemLoad) {
        _selBudgetItem = _BudgetItemPrivider.SelectedBudgetItemById(Convert.ToInt32(BudgetItemCBox.SelectedValue));
        AmountTBox.Text = _selBudgetItem.DefaultAmount.ToString();
      }
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        double value = double.Parse(AmountTBox.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
        _TransactionProvider.InsertTransaction(LoginForm.CurrentUser.UserId, 
          Convert.ToInt32(BudgetItemCBox.SelectedValue), TransactionTypeCBox.Text,
          value, TransactionDateDTP.Value, DescriptionTBox.Text);
        // === Додавання запису у журнал подій ===
        _LogProvider.InsertLogs(
            LoginForm.CurrentUser.UserId,
            $"Користувач додав транзакцію: '{TransactionTypeCBox.Text}' " +
            $"(елемент: '{BudgetItemCBox.Text}', сума: {value.ToString("F2", CultureInfo.InvariantCulture)}, " +
            $"дата: {TransactionDateDTP.Value:dd.MM.yyyy})",
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

    private void TransactionGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && TransactionGridView[0, e.RowIndex].Value.ToString() != _BudgetItemList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateTransaction updateUpdateTransaction = new UpdateTransaction(Convert.ToInt32(TransactionGridView[0, e.RowIndex].Value.ToString()));
        updateUpdateTransaction.ShowDialog();
        DataLoad();
      }
    }

    private void LoadAllDate() {
      _BudgetCategoryList = _BudgetCategoriesProvider.GetAllActiveBudgetCategory();
      BudgetCategoryCBox.DataSource = _BudgetCategoryList;
      BudgetCategoryCBox.ValueMember = "CategoryId";
      BudgetCategoryCBox.DisplayMember = "CategoryName";
      _isBudgetCategoryLoad = true;
      BudgetCategoryCBox_SelectedValueChanged(BudgetCategoryCBox, EventArgs.Empty);

    }

    private void DataLoad() {
      int firstRowIndex = 0;
      TransactionTypeCBox.SelectedIndex = 0;
      if (TransactionGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = TransactionGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _TransactionList = _TransactionProvider.GetAllUserExpenses(LoginForm.CurrentUser.UserId);
        LoadDataInTransactionGridView(_TransactionList);
        if (_selectedRowIndex == TransactionGridView.Rows.Count) {
          _selectedRowIndex = TransactionGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          TransactionGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          TransactionGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInTransactionGridView(List<Transaction> TransactionList) {
      TransactionGridView.DataSource = null;
      TransactionGridView.Columns.Clear();
      TransactionGridView.AutoGenerateColumns = false;
      TransactionGridView.RowHeadersVisible = false;

      // Сортування за датою (новіші зверху), потім за категорією
      var sortedList = TransactionList
        .OrderByDescending(t => t.TransactionDate)
        .ThenBy(t => t.CategoryName)
        .ToList();

      TransactionGridView.DataSource = sortedList;
      //TransactionGridView.DataSource = TransactionList;

      if (TransactionList.Count > 0) {
        if (TransactionList[0].Message == NamesMy.NoDataNames.NoDataInTransaction) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = TransactionGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          TransactionGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn TransactionIdColumn = new DataGridViewTextBoxColumn();
          TransactionIdColumn.DataPropertyName = "TransactionId";
          TransactionGridView.Columns.Add(TransactionIdColumn);
          TransactionGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          TransactionGridView.Columns.Add(numberColumn);

          DataGridViewColumn TransactionDateColumn = new DataGridViewTextBoxColumn();
          TransactionDateColumn.HeaderText = "Дата";
          TransactionDateColumn.DataPropertyName = "TransactionDate";
          TransactionDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          TransactionDateColumn.Width = 130;
          TransactionGridView.Columns.Add(TransactionDateColumn);
          
          DataGridViewColumn DefaultAmountColumn = new DataGridViewTextBoxColumn();
          DefaultAmountColumn.HeaderText = "Категорія";
          DefaultAmountColumn.DataPropertyName = "CategoryName";
          DefaultAmountColumn.Width = 250;
          TransactionGridView.Columns.Add(DefaultAmountColumn);

          DataGridViewColumn ItemNameColumn = new DataGridViewTextBoxColumn();
          ItemNameColumn.HeaderText = "Тип витрати";
          ItemNameColumn.DataPropertyName = "ItemName";
          ItemNameColumn.Width = 250;
          TransactionGridView.Columns.Add(ItemNameColumn);

          DataGridViewColumn AmountColumn = new DataGridViewTextBoxColumn();
          AmountColumn.HeaderText = "Сума";
          AmountColumn.DataPropertyName = "Amount";
          AmountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          AmountColumn.Width = 100;
          TransactionGridView.Columns.Add(AmountColumn);

          // Додаємо обробник для сортування при кліку на заголовок
          TransactionGridView.ColumnHeaderMouseClick += TransactionGridView_ColumnHeaderMouseClick;

          // Візуальне групування за категоріями (різні кольори фону)
          ApplyCategoryGrouping(sortedList);
        }

        for (int i = 0; i < TransactionGridView.Columns.Count; i++) {
          TransactionGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    // Додайте цей метод для обробки сортування
    private void TransactionGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex < 0) return;
    
      var columnName = TransactionGridView.Columns[e.ColumnIndex].DataPropertyName;
      if (string.IsNullOrEmpty(columnName)) return;
    
      var currentList = TransactionGridView.DataSource as List<Transaction>;
      if (currentList == null || currentList.Count == 0) return;
    
      // Визначаємо напрямок сортування
      var currentSortOrder = TransactionGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
      bool ascending = currentSortOrder != SortOrder.Ascending;
    
      List<Transaction> sortedList = null;
    
      switch (columnName)
      {
        case "TransactionDate":
          sortedList = ascending
            ? currentList.OrderBy(t => t.TransactionDate).ToList()
            : currentList.OrderByDescending(t => t.TransactionDate).ToList();
          break;
        case "CategoryName":
          sortedList = ascending
            ? currentList.OrderBy(t => t.CategoryName).ToList()
            : currentList.OrderByDescending(t => t.CategoryName).ToList();
          break;
        case "ItemName":
          sortedList = ascending
            ? currentList.OrderBy(t => t.ItemName).ToList()
            : currentList.OrderByDescending(t => t.ItemName).ToList();
          break;
        case "Amount":
          sortedList = ascending
            ? currentList.OrderBy(t => t.Amount).ToList()
            : currentList.OrderByDescending(t => t.Amount).ToList();
          break;
        default:
          return;
      }
    
      // Оновлюємо DataSource
      TransactionGridView.DataSource = null;
      TransactionGridView.DataSource = sortedList;
    
      // Встановлюємо індикатор сортування
      TransactionGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
        ascending ? SortOrder.Ascending : SortOrder.Descending;
    
      ApplyCategoryGrouping(sortedList);
    }
    
    // Додайте цей метод для візуального групування
    private void ApplyCategoryGrouping(List<Transaction> transactions)
    {
      string previousCategory = string.Empty;
      Color[] groupColors = { Color.White, Color.FromArgb(240, 248, 255) }; // Альтернативні кольори
      int colorIndex = 0;
    
      for (int i = 0; i < TransactionGridView.Rows.Count; i++)
      {
        if (i >= transactions.Count) break;
    
        string currentCategory = transactions[i].CategoryName ?? string.Empty;
    
        if (currentCategory != previousCategory)
        {
          colorIndex = (colorIndex + 1) % groupColors.Length;
          previousCategory = currentCategory;
        }
    
        TransactionGridView.Rows[i].DefaultCellStyle.BackColor = groupColors[colorIndex];
      }
    }

    private void ClearAllControls() {
      TransactionTypeCBox.SelectedIndex = 0;
      BudgetItemCBox.SelectedIndex = 0;
      BudgetCategoryCBox.SelectedIndex = 0;
      TransactionDateDTP.Value = DateTime.Now;
      DescriptionTBox.Text = "";
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      double min = 10.0;
      double max = 1_000_000.0;

      // --- Перевірка суми ---
      if (_Validation.TryParseDouble(AmountTBox.Text, out double amount)) {
        if (_Validation.IsDataInThisScope(min, max, amount))
          AmountValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
        else {
          AmountValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
          isCorrect = false;
        }
      } else {
        AmountValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      // --- Перевірка категорії ---
      if (Convert.ToInt32(BudgetCategoryCBox.SelectedValue) > 0)
        BudgetCategoryValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      else {
        BudgetCategoryValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      // --- Перевірка елемента ---
      if (Convert.ToInt32(BudgetItemCBox.SelectedValue) > 0)
        BudgetItemValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      else {
        BudgetItemValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      // --- Перевірка дублю витрати за місяць ---
      if (isCorrect) {
        int userId = LoginForm.CurrentUser.UserId; // поточний користувач
        int itemId = Convert.ToInt32(BudgetItemCBox.SelectedValue);
        DateTime transactionDate = TransactionDateDTP.Value;

        bool isExists = _TransactionProvider.IsTransactionExistsForMonth(userId, itemId, transactionDate);

        if (isExists) {
          DialogResult result = MessageBox.Show(
            "Витрата для цієї категорії вже додана у вибраному місяці.\n\nВи впевнені, що хочете додати ще одну транзакцію?",
            "Попередження",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

          if (result == DialogResult.No) {
            isCorrect = false;
          }
        }
      }

      return isCorrect;
    }
  }
}
