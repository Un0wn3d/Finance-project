using BudgetPlanningApp.AppCode;
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

namespace BudgetPlanningApp.Forms.Systems {
  public partial class LoginForm : Form {
    public static User CurrentUser = new User();

    private UsersProvider _UserProvider = new UsersProvider();
    private ValidationMy _validation = new ValidationMy();
    private LogsProvider _LogProvider = new LogsProvider();
    private List<User> _UserList = new List<User>();

    public LoginForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void SubmitBtn_Click(object sender, EventArgs e) {
      GetSubmitData();
    }

    private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      MyOfficeForm myOfficeForm = new MyOfficeForm(0);
      myOfficeForm.Show();
    }

    private void DataLoad() {
      _LogProvider.InsertLogs(CurrentUser.UserId, "Користувач ввійшов в систему", DateTime.Now);
      this.Visible = false;
      (new BudgetMDI()).ShowDialog();
      _LogProvider.InsertLogs(CurrentUser.UserId, "Користувач вийшов із системи", DateTime.Now);
      this.Close();
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(UserNameCBox.Text)) {
        UserNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        UserNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(UserPasswordTBox.Text)) {
        UserPasswordValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        UserPasswordValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private void LoadAllDate() {
      _UserList = _UserProvider.GetAllUsers();
      UserNameCBox.DataSource = _UserList;
      UserNameCBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      UserNameCBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      UserNameCBox.ValueMember = "UserId";
      UserNameCBox.DisplayMember = "UserName";
    }

    private void GetSubmitData() {
      try {
        if (IsDataEnteringCorrect()) {
          List<User> listUsers = new List<User>();
          listUsers = _UserProvider.SelectedUsersByUserNameAndUserPassword(UserNameCBox.Text, UserPasswordTBox.Text);
          if (listUsers.Count > 0) {
            CurrentUser = listUsers[0];
            DataLoad();
          } else {
            MessageBox.Show(NamesMy.MessageBoxExaption.ThisUserLoginAndUserPasswordNotExistInSystem, NamesMy.MessageBoxExaption.CaptionMessage);
          }
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }


  }
}
