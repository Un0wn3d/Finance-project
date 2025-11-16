using BudgetPlanningApp.AppCode;
using BudgetPlanningApp.Forms.Acco;
using BudgetPlanningApp.Forms.Controls;
using BudgetPlanningApp.Forms.Dict;
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

namespace BudgetPlanningApp {
    public partial class BudgetMDI : Form {
        GenerateData _GenerateData = new GenerateData();
        UsersProvider _UsersProvider = new UsersProvider();
        List<User> _UsersList = new List<User>();

        public BudgetMDI() {
            InitializeComponent();
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.MdiParent = this;
            transactionForm.WindowState = FormWindowState.Maximized;
            transactionForm.Show();
            //_UsersList = _UsersProvider.GetAllUsers();
            //_GenerateData.InsertDefaultUsers();
            //_GenerateData.InsertDefaultBudgetCategories();
            //_GenerateData.InsertDefaultBudgetItems();
            //_GenerateData.SeedExpensesForUsers(_UsersList);
        }

        public void CloseAllForms() {
            Form[] childArray = this.MdiChildren;
            foreach (Form childForm in childArray) {
                childForm.Close();
            }
        }

        private void трензакціїToolStripMenuItem_Click(object sender, EventArgs e) {
          CloseAllForms();
          TransactionForm transactionForm = new TransactionForm();
          transactionForm.MdiParent = this;
          transactionForm.WindowState = FormWindowState.Maximized;
          transactionForm.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e) {
          this.Close();
        }

        private void категоріїВитратToolStripMenuItem_Click(object sender, EventArgs e) {
          if (LoginForm.CurrentUser.RoleId == 1) {
            CloseAllForms();
            BudgetCategoriesForm budgetCategoriesForm = new BudgetCategoriesForm();
            budgetCategoriesForm.MdiParent = this;
            budgetCategoriesForm.WindowState = FormWindowState.Maximized;
            budgetCategoriesForm.Show();
          } else {
            MessageBox.Show(NamesMy.MessageBoxExaption.YouDontHavePermission);
          }
        }

        private void витратиToolStripMenuItem_Click(object sender, EventArgs e) {
          if (LoginForm.CurrentUser.RoleId == 1) {
            CloseAllForms();
            BudgetItemForm budgetItemForm = new BudgetItemForm();
            budgetItemForm.MdiParent = this;
            budgetItemForm.WindowState = FormWindowState.Maximized;
            budgetItemForm.Show();
          } else {
            MessageBox.Show(NamesMy.MessageBoxExaption.YouDontHavePermission);
          }
        }

        private void обліковіЗаписиToolStripMenuItem_Click(object sender, EventArgs e) {
          if (LoginForm.CurrentUser.RoleId == 1) {
            CloseAllForms();
            UsersForm usersForm = new UsersForm();
            usersForm.MdiParent = this;
            usersForm.WindowState = FormWindowState.Maximized;
            usersForm.Show();
          } else {
            MessageBox.Show(NamesMy.MessageBoxExaption.YouDontHavePermission);
          }
        }

        private void діїКористувачівToolStripMenuItem_Click(object sender, EventArgs e) {
          if (LoginForm.CurrentUser.RoleId == 1) {
            CloseAllForms();
            LogsForm logsForm = new LogsForm();
            logsForm.MdiParent = this;
            logsForm.WindowState = FormWindowState.Maximized;
            logsForm.Show();
          } else {
            MessageBox.Show(NamesMy.MessageBoxExaption.YouDontHavePermission);
          }
        }

        private void мійКабінетToolStripMenuItem_Click(object sender, EventArgs e) {
          CloseAllForms();
          MyOfficeForm myOfficeForm = new MyOfficeForm(LoginForm.CurrentUser.UserId);
          myOfficeForm.MdiParent = this;
          myOfficeForm.WindowState = FormWindowState.Maximized;
          myOfficeForm.Show();
        }

        private void змінитиОбліковіДаніToolStripMenuItem_Click(object sender, EventArgs e) {
          // Закриття всіх дочірніх вікон
          CloseAllForms();
          // Перезапуск програми
          Program.RestartApp();
        }

        private void витратиЗаОбранимРахункомToolStripMenuItem_Click(object sender, EventArgs e) {
          CloseAllForms();
          StorysForUserByBudgetItemForm storysForUserByBudgetItemForm = new StorysForUserByBudgetItemForm();
          storysForUserByBudgetItemForm.MdiParent = this;
          storysForUserByBudgetItemForm.WindowState = FormWindowState.Maximized;
          storysForUserByBudgetItemForm.Show();
        }

        private void витратиКористувачаЗаВказанийПеріодToolStripMenuItem_Click(object sender, EventArgs e) {
          CloseAllForms();
          MonthlyExpensesForm monthlyExpensesForm = new MonthlyExpensesForm();
          monthlyExpensesForm.MdiParent = this;
          monthlyExpensesForm.WindowState = FormWindowState.Maximized;
          monthlyExpensesForm.Show();
        }

        private void витратиЗаВибранийМісяцьToolStripMenuItem_Click(object sender, EventArgs e) {
          CloseAllForms();
          RenderPlanFactForm renderPlanFactForm = new RenderPlanFactForm();
          renderPlanFactForm.MdiParent = this;
          renderPlanFactForm.WindowState = FormWindowState.Maximized;
          renderPlanFactForm.Show();
        }
    }
}
