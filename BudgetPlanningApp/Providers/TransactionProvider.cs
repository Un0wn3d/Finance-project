using BudgetPlanningApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace BudgetPlanningApp.Providers {
  internal class TransactionProvider {
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    /// <summary>
    /// Додає новий запис транзакції (витрата/дохід).
    /// </summary>
    public void InsertTransaction(int userId, int itemId, string transactionType,
                                  double amount, DateTime transactionDate, string description) {
      using (var connection = new MySqlConnection(_ConnStr)) {
        string query =
            "INSERT INTO transactions " +
            "(UserId, ItemId, TransactionType, Amount, TransactionDate, Description) " +
            "VALUES (@UserId, @ItemId, @TransactionType, @Amount, @TransactionDate, @Description)";

        using (var cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@UserId", userId);
          cmd.Parameters.AddWithValue("@ItemId", itemId);
          cmd.Parameters.AddWithValue("@TransactionType", transactionType);
          cmd.Parameters.AddWithValue("@Amount", amount);
          cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
          cmd.Parameters.AddWithValue("@Description", description);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    /// <summary>
    /// Повертає повний список транзакцій, відсортований за датою (новіші зверху).
    /// Якщо записів немає — повертає службовий елемент із повідомленням.
    /// </summary>
    public List<Transaction> GetAllTransaction() {
      int i = 0;
      var list = new List<Transaction>();

      using (var connection = new MySqlConnection(_ConnStr)) {
        // Вибірка транзакцій із приєднанням довідників: назви позиції та категорії
        string query = @"
            SELECT 
                t.TransactionId,
                t.UserId,
                t.ItemId,
                t.TransactionType,
                t.Amount,
                t.TransactionDate,
                t.Description,
                bi.ItemName,
                bc.CategoryName
            FROM transactions t
            JOIN budget_items bi       ON bi.ItemId = t.ItemId
            JOIN budget_categories bc  ON bc.CategoryId = bi.CategoryId
            ORDER BY t.TransactionDate DESC, t.TransactionId DESC";

        using (var command = new MySqlCommand(query, connection)) {
          connection.Open();
          using (var reader = command.ExecuteReader()) {
            while (reader.Read()) {
              var t = new Transaction {
                Number = ++i, // Порядковий номер для відображення
                TransactionId = Convert.ToInt32(reader["TransactionId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                ItemId = Convert.ToInt32(reader["ItemId"]),
                TransactionType = reader["TransactionType"].ToString(),
                Amount = Convert.ToDouble(reader["Amount"]),
                TransactionDate = Convert.ToDateTime(reader["TransactionDate"]),
                Description = reader["Description"] == DBNull.Value ? string.Empty : reader["Description"].ToString(),
                // Нові поля з JOIN
                ItemName = reader["ItemName"] == DBNull.Value ? string.Empty : reader["ItemName"].ToString(),
                CategoryName = reader["CategoryName"] == DBNull.Value ? string.Empty : reader["CategoryName"].ToString()
              };

              list.Add(t);
            }
          }
        }
      }

      if (list.Count == 0) {
        list.Add(new Transaction {
          TransactionId = 0,
          Message = NamesMy.NoDataNames.NoDataInTransaction
        });
      }

      return list;
    }


    /// <summary>
    /// Отримує всі витрати певного користувача, включно з назвами позицій і категорій.
    /// </summary>
    public List<Transaction> GetAllUserExpenses(int userId) {
      int i = 0;
      List<Transaction> transactionList = new List<Transaction>();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        // Запит: отримати всі транзакції користувача типу "expense"
        // та приєднати назви категорії й елемента бюджету
        string query = @"
            SELECT 
                t.TransactionId,
                t.UserId,
                t.ItemId,
                t.TransactionType,
                t.Amount,
                t.TransactionDate,
                t.Description,
                bi.ItemName,
                bc.CategoryName
            FROM transactions t
            JOIN budget_items bi ON bi.ItemId = t.ItemId
            JOIN budget_categories bc ON bc.CategoryId = bi.CategoryId
            WHERE t.UserId = @UserId
            ORDER BY t.TransactionDate DESC, t.TransactionId DESC";

        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@UserId", userId);

        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
          Transaction tr = new Transaction {
            Number = ++i, // Порядковий номер для відображення у таблиці
            TransactionId = Convert.ToInt32(reader["TransactionId"]),
            UserId = Convert.ToInt32(reader["UserId"]),
            ItemId = Convert.ToInt32(reader["ItemId"]),
            TransactionType = reader["TransactionType"].ToString(),
            Amount = Convert.ToDouble(reader["Amount"]),
            TransactionDate = Convert.ToDateTime(reader["TransactionDate"]),
            Description = reader["Description"] == DBNull.Value ? string.Empty : reader["Description"].ToString(),
            ItemName = reader["ItemName"] == DBNull.Value ? string.Empty : reader["ItemName"].ToString(),
            CategoryName = reader["CategoryName"] == DBNull.Value ? string.Empty : reader["CategoryName"].ToString()
          };

          transactionList.Add(tr);
        }

        if (transactionList.Count == 0) {
          transactionList.Add(new Transaction {
            TransactionId = 0,
            Message = NamesMy.NoDataNames.NoDataInTransaction
          });
        }
        reader.Close();
      }

      // Якщо даних немає — додаємо службовий запис із повідомленням
      if (transactionList.Count == 0) {
        Transaction noData = new Transaction {
          TransactionId = 0,
          UserId = userId,
          Message = $"Для користувача з ID = {userId} відсутні витрати у базі даних."
        };
        transactionList.Add(noData);
      }

      return transactionList;
    }


    /// <summary>
    /// Повертає одну транзакцію за її ідентифікатором.
    /// Якщо не знайдено — повертає об’єкт із повідомленням.
    /// </summary>
    public Transaction SelectedTransactionById(int transactionId) {
      var t = new Transaction();

      using (var connection = new MySqlConnection(_ConnStr)) {
        string query = "SELECT * FROM transactions WHERE TransactionId = @TransactionId";

        using (var command = new MySqlCommand(query, connection)) {
          command.Parameters.AddWithValue("@TransactionId", transactionId);

          connection.Open();
          using (var reader = command.ExecuteReader()) {
            if (reader.Read()) {
              t.TransactionId = Convert.ToInt32(reader["TransactionId"]);
              t.UserId = Convert.ToInt32(reader["UserId"]);
              t.ItemId = Convert.ToInt32(reader["ItemId"]);
              t.TransactionType = reader["TransactionType"].ToString();
              t.Amount = Convert.ToDouble(reader["Amount"]);
              t.TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);
              t.Description = reader["Description"] == DBNull.Value ? string.Empty : reader["Description"].ToString();
              return t;
            }
          }
        }
      }

      // Якщо не знайдено
      t.TransactionId = 0;
      t.Message = NamesMy.NoDataNames.NoDataInTransaction;
      return t;
    }

    /// <summary>
    /// Оновлює дані транзакції за її ідентифікатором.
    /// </summary>
    public void UpdateTransaction(int userId, int itemId, string transactionType,
                                  double amount, DateTime transactionDate, string description, int transactionId) {
      using (var connection = new MySqlConnection(_ConnStr)) {
        string query =
            "UPDATE transactions " +
            "SET UserId = @UserId, ItemId = @ItemId, TransactionType = @TransactionType, " +
            "    Amount = @Amount, TransactionDate = @TransactionDate, Description = @Description " +
            "WHERE TransactionId = @TransactionId";

        using (var cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@TransactionId", transactionId);
          cmd.Parameters.AddWithValue("@UserId", userId);
          cmd.Parameters.AddWithValue("@ItemId", itemId);
          cmd.Parameters.AddWithValue("@TransactionType", transactionType);
          cmd.Parameters.AddWithValue("@Amount", amount);
          cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
          cmd.Parameters.AddWithValue("@Description", description);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    /// <summary>
    /// Перевіряє, чи користувач уже має запис про цю витрату (ItemId) у вибраному місяці.
    /// Повертає true, якщо така транзакція вже існує.
    /// </summary>
    public bool IsTransactionExistsForMonth(int userId, int itemId, DateTime selectedDate) {
      using (var connection = new MySqlConnection(_ConnStr)) {
        DateTime monthStart = new DateTime(selectedDate.Year, selectedDate.Month, 1);
        DateTime nextMonthStart = monthStart.AddMonths(1);
        const string sql = @"
            SELECT COUNT(*)
            FROM transactions
            WHERE UserId = @UserId
              AND ItemId = @ItemId
              AND TransactionType = 'expense'
              AND TransactionDate >= @MonthStart
              AND TransactionDate <  @NextMonthStart";
        using (var cmd = new MySqlCommand(sql, connection)) {
          cmd.Parameters.AddWithValue("@UserId", userId);
          cmd.Parameters.AddWithValue("@ItemId", itemId);
          cmd.Parameters.AddWithValue("@MonthStart", monthStart);
          cmd.Parameters.AddWithValue("@NextMonthStart", nextMonthStart);
          connection.Open();
          int count = Convert.ToInt32(cmd.ExecuteScalar());
          return count > 0;
        }
      }
    }




    /// <summary>
    /// Видаляє транзакцію за її ідентифікатором.
    /// </summary>
    public void DeleteTransaction(int transactionId) {
      using (var connection = new MySqlConnection(_ConnStr)) {
        string query = "DELETE FROM transactions WHERE TransactionId = @TransactionId";

        using (var cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@TransactionId", transactionId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

  }
}

/// <summary>
/// Клас-модель для представлення фінансових транзакцій користувачів.
/// Кожна транзакція відображає факт витрати або доходу,
/// пов'язаний з конкретною позицією бюджету та користувачем.
/// </summary>
public class Transaction {
  // Порядковий номер запису (для відображення у таблиці або звіті)
  public int Number { get; set; }

  // Унікальний ідентифікатор транзакції (ключ у таблиці transactions)
  public int TransactionId { get; set; }

  // Ідентифікатор користувача, який виконав операцію
  public int UserId { get; set; }

  // Ідентифікатор позиції бюджету (зв’язок із таблицею budget_items)
  public int ItemId { get; set; }

  // Тип транзакції (наприклад: "expense" – витрата, "income" – дохід)
  public string TransactionType { get; set; } = string.Empty;

  // Сума операції (позитивне число, що відображає розмір доходу або витрати)
  public double Amount { get; set; }

  // Дата та час виконання транзакції
  public DateTime TransactionDate { get; set; } = DateTime.Now;

  // Текстовий опис або коментар до транзакції
  public string Description { get; set; } = string.Empty;

  // Повідомлення про стан або результат операції (службове поле)
  public string Message { get; set; } = string.Empty;
  
  // Додаткові поля з суміжних таблиць
  public string ItemName { get; set; } = string.Empty;      // Назва позиції з budget_items
  public string CategoryName { get; set; } = string.Empty;  // Назва категорії з budget_categories

  /// <summary>
  /// Конструктор без параметрів із ініціалізацією стандартних значень.
  /// </summary>
  public Transaction() { }
}
