using BudgetPlanningApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanningApp.Providers {
  internal class UsersProvider {
    private EncryptData _encryptData = new EncryptData();
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    public void InsertUsers(string FirstName, string LastName, string UserName, string UserPassword,
   int RoleId, string Description) {
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "INSERT INTO Users (FirstName, LastName, UserName, UserPassword, RoleId, Description) " +
        "VALUES(@FirstName, @LastName," +
        " @UserName, @UserPassword, @RoleId, @Description)";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("FirstName", FirstName);
      cmd.Parameters.AddWithValue("LastName", LastName);
      cmd.Parameters.AddWithValue("UserName", UserName);
      cmd.Parameters.AddWithValue("UserPassword", _encryptData.Encrypt(UserPassword));
      cmd.Parameters.AddWithValue("RoleId", RoleId);
      cmd.Parameters.AddWithValue("Description", Description);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
      connection.Dispose();
      connection = null;
    }

    public User SelectedUsersByUserId(int UserId) {
      User selectedUsers = new User();
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "SELECT * FROM Users WHERE UserId=" + UserId.ToString();
      MySqlCommand command = new MySqlCommand(query, connection);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        selectedUsers.UserId = Convert.ToInt32(reader["UserId"]);
        selectedUsers.FirstName = reader["FirstName"].ToString();
        selectedUsers.LastName = reader["LastName"].ToString();
        selectedUsers.UserName = reader["UserName"].ToString();
        selectedUsers.FIO = selectedUsers.LastName + " " + selectedUsers.FirstName;
        selectedUsers.UserPassword = _encryptData.Decrypt(reader["UserPassword"].ToString());
        selectedUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
        selectedUsers.Description = reader["Description"].ToString();
      }
      reader.Close();
      connection.Close();
      return selectedUsers;
    }


    public List<User> SelectedUsersByUserNameAndUserPassword(string UserName, string UserPassword) {
      int i = 0;
      List<User> UsersList = new List<User>();
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "SELECT * FROM Users WHERE UserName='" + UserName + "' AND UserPassword='" + _encryptData.Encrypt(UserPassword) + "'";
      MySqlCommand command = new MySqlCommand(query, connection);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        User selectedUsers = new User();
        selectedUsers.Number = ++i;
        selectedUsers.UserId = Convert.ToInt32(reader["UserId"]);
        selectedUsers.FirstName = reader["FirstName"].ToString();
        selectedUsers.LastName = reader["LastName"].ToString();
        selectedUsers.FIO = selectedUsers.LastName + " " + selectedUsers.FirstName;
        selectedUsers.UserName = reader["UserName"].ToString();
        selectedUsers.UserPassword = _encryptData.Decrypt(reader["UserPassword"].ToString());
        selectedUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
        selectedUsers.RoleName = GetRoleName(selectedUsers.RoleId);
        selectedUsers.Description = reader["Description"].ToString();
        UsersList.Add(selectedUsers);
      }
      reader.Close();
      connection.Close();
      return UsersList;
    }


    public List<User> GetAllUsers() {
      int i = 0;
      List<User> UsersList = new List<User>();
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "SELECT * FROM Users ORDER BY UserName";
      MySqlCommand command = new MySqlCommand(query, connection);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        User selectedUsers = new User();
        selectedUsers.Number = ++i;
        selectedUsers.UserId = Convert.ToInt32(reader["UserId"]);
        selectedUsers.FirstName = reader["FirstName"].ToString();
        selectedUsers.LastName = reader["LastName"].ToString();
        selectedUsers.FIO = selectedUsers.LastName + " " + selectedUsers.FirstName;
        selectedUsers.UserName = reader["UserName"].ToString();
        selectedUsers.UserPassword = _encryptData.Decrypt(reader["UserPassword"].ToString());
        selectedUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
        selectedUsers.RoleName = GetRoleName(selectedUsers.RoleId);
        selectedUsers.Description = reader["Description"].ToString();
        UsersList.Add(selectedUsers);
      }
      reader.Close();
      connection.Close();

      if (UsersList.Count == 0) {
        User noUsers = new User();
        noUsers.UserId = 0;
        noUsers.Message = NamesMy.NoDataNames.NoDataInUsers;
        UsersList.Add(noUsers);
      }
      return UsersList;
    }

    private string GetRoleName(int RoleId) {
      RoleApp roleApp = new RoleApp();
      for (int i = 0; i < roleApp.GetRoleList().Count(); i++) {
        if (RoleId == roleApp.GetRoleList()[i].RoleId) {
          return roleApp.GetRoleList()[i].RoleName;
        }
      }
      return "";
    }

    public void UpdateUsers(string FirstName, string LastName, string UserName, string UserPassword,
   int RoleId, string Description, int UserId) {
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName," +
        " UserName=@UserName, UserPassword=@UserPassword," +
        " RoleId=@RoleId,  Description=@Description" +
          " WHERE UserId = @UserId";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("FirstName", FirstName);
      cmd.Parameters.AddWithValue("LastName", LastName);
      cmd.Parameters.AddWithValue("UserName", UserName);
      cmd.Parameters.AddWithValue("UserPassword", _encryptData.Encrypt(UserPassword));
      cmd.Parameters.AddWithValue("RoleId", RoleId);
      cmd.Parameters.AddWithValue("Description", Description);
      cmd.Parameters.AddWithValue("UserId", UserId);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
      connection.Dispose();
      connection = null;
    }

    public void DeleteUsers(int UserId) {
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "DELETE FROM Users WHERE UserId = @UserId";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@UserId", UserId);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
      connection.Dispose();
      connection = null;
    }


    public int GetUsersCount() {
      int usersCount = 0; // Ініціалізація лічильника користувачів
      MySqlConnection connection = new MySqlConnection(_ConnStr); // Встановлення з'єднання з базою даних
      string query = "SELECT COUNT(*) FROM Users"; // Запит для підрахунку кількості користувачів
      MySqlCommand command = new MySqlCommand(query, connection); // Створення команди
      try {
        connection.Open(); // Відкриття з'єднання
        usersCount = Convert.ToInt32(command.ExecuteScalar()); // Виконання запиту і конвертація результату в int
      } catch (Exception ex) {
        // Обробка можливих винятків, наприклад, виведення інформації про помилку
        Console.WriteLine("Помилка при отриманні кількості користувачів: " + ex.Message);
      } finally {
        connection.Close(); // Закриття з'єднання
      }
      return usersCount; // Повернення кількості користувачів
    }


  }
}


/// <summary>
/// Модель користувача системи для зберігання основних даних авторизації,
/// ролі та опису.
/// </summary>
public class User {
  // Номер запису у списку (порядковий, не обов’язково з БД)
  public int Number { get; set; }

  // Унікальний ідентифікатор користувача (з БД)
  public int UserId { get; set; }

  // Ім’я користувача
  public string FirstName { get; set; } = string.Empty;

  // Прізвище користувача
  public string LastName { get; set; } = string.Empty;

  // Повне ім’я (ПІБ)
  public string FIO { get; set; } = string.Empty;

  // Логін користувача для входу в систему
  public string UserName { get; set; } = string.Empty;

  // Пароль користувача
  public string UserPassword { get; set; } = string.Empty;

  // Ідентифікатор ролі користувача
  public int RoleId { get; set; }

  // Назва ролі (наприклад, “Адміністратор”, “Користувач”)
  public string RoleName { get; set; } = string.Empty;

  // Опис або додаткова інформація про користувача
  public string Description { get; set; } = string.Empty;

  // Повідомлення (наприклад, результат операції або статус)
  public string Message { get; set; } = string.Empty;

  /// <summary>
  /// Конструктор без параметрів із ініціалізацією стандартних значень.
  /// </summary>
  public User() { }
}
