using BudgetPlanningApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanningApp.Providers {
  internal class LogsProvider {
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    public void InsertLogs(int UserId, string EventNameShow, DateTime EventDate) {
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "INSERT INTO Logs (UserId, EventNameShow, EventDate) VALUES(@UserId, @EventNameShow, @EventDate)";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("UserId", UserId);
      cmd.Parameters.AddWithValue("EventNameShow", EventNameShow);
      cmd.Parameters.AddWithValue("EventDate", EventDate.ToString("yyyy-MM-dd HH:mm:ss"));
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    public List<Log> GetAllLogs() {
      int i = 0;
      List<Log> LogsList = new List<Log>();
      MySqlConnection connection = new MySqlConnection(_ConnStr);
      string query = "SELECT Logs.LogId, Logs.UserId, Logs.EventNameShow, Logs.EventDate, Users.UserName " +
      "FROM Logs INNER JOIN Users ON Users.UserId = Logs.UserId  ORDER BY Logs.EventDate DESC";
      MySqlCommand command = new MySqlCommand(query, connection);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        Log selectedLogs = new Log();
        selectedLogs.Number = ++i;
        selectedLogs.LogId = Convert.ToInt32(reader["LogId"]);
        selectedLogs.UserId = Convert.ToInt32(reader["UserId"]);
        selectedLogs.EventNameShow = reader["EventNameShow"].ToString();
        selectedLogs.EventDate = Convert.ToDateTime(reader["EventDate"]);
        selectedLogs.UserName = reader["UserName"].ToString();
        LogsList.Add(selectedLogs);
      }
      reader.Close();
      connection.Close();

      if (LogsList.Count == 0) {
        Log noLogs = new Log();
        noLogs.LogId = 0;
        noLogs.Message = NamesMy.NoDataNames.NoDataInLogs;
        LogsList.Add(noLogs);
      }
      return LogsList;
    }

  }
}

/// <summary>
/// Клас для зберігання інформації про події (журнал логів системи).
/// Використовується для фіксації дій користувачів у системі.
/// </summary>
public class Log {
  // Порядковий номер запису (для відображення у таблиці або звіті)
  public int Number { get; set; }

  // Унікальний ідентифікатор запису журналу
  public int LogId { get; set; }

  // Ідентифікатор користувача, який здійснив дію
  public int UserId { get; set; }

  // Ім’я користувача (логін або відображуване ім’я)
  public string UserName { get; set; } = string.Empty;

  // Опис події (що саме відбулося)
  public string EventNameShow { get; set; } = string.Empty;

  // Дата та час події
  public DateTime EventDate { get; set; } = DateTime.Now;

  // Додаткове повідомлення (наприклад, результат операції або деталі події)
  public string Message { get; set; } = string.Empty;

  /// <summary>
  /// Конструктор без параметрів із ініціалізацією значень за замовчуванням.
  /// </summary>
  public Log() { }
}
