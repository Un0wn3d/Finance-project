using BudgetPlanningApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanningApp.Providers {
  internal class BudgetItemProvider {
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    /// <summary>
    /// Додає нову позицію бюджету до таблиці budget_items.
    /// </summary>
    public void InsertBudgetItem(int categoryId, string itemName, double defaultAmount, string description) {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "INSERT INTO budget_items (CategoryId, ItemName, DefaultAmount, Description) " +
                       "VALUES (@CategoryId, @ItemName, @DefaultAmount, @Description)";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
        cmd.Parameters.AddWithValue("@ItemName", itemName);
        cmd.Parameters.AddWithValue("@DefaultAmount", defaultAmount);
        cmd.Parameters.AddWithValue("@Description", description);

        connection.Open();
        cmd.ExecuteNonQuery();
      }
    }

    /// <summary>
    /// Отримує повний список позицій бюджету з таблиці budget_items.
    /// </summary>
    public List<BudgetItem> GetAllBudgetItem() {
      int i = 0;
      List<BudgetItem> itemList = new List<BudgetItem>();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "SELECT * FROM budget_items ORDER BY ItemName ASC";
        MySqlCommand command = new MySqlCommand(query, connection);

        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
          BudgetItem item = new BudgetItem {
            Number = ++i,
            ItemId = Convert.ToInt32(reader["ItemId"]),
            CategoryId = Convert.ToInt32(reader["CategoryId"]),
            ItemName = reader["ItemName"].ToString(),
            Description = reader["Description"].ToString(),
            DefaultAmount = Convert.ToDouble(reader["DefaultAmount"])
          };

          itemList.Add(item);
        }

        reader.Close();
      }

      // Якщо даних немає — додаємо службове повідомлення
      if (itemList.Count == 0) {
        BudgetItem noData = new BudgetItem {
          ItemId = 0,
          Message = NamesMy.NoDataNames.NoDataInBudgetItem
        };
        itemList.Add(noData);
      }

      return itemList;
    }

    /// <summary>
    /// Отримує список позицій бюджету (витрат) за вказаним CategoryId.
    /// </summary>
    public List<BudgetItem> GetAllBudgetItemByCategoryId(int categoryId) {
      int i = 0;
      List<BudgetItem> itemList = new List<BudgetItem>();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        // Запит вибирає тільки ті записи, які належать заданій категорії
        string query = "SELECT * FROM budget_items WHERE CategoryId = @CategoryId ORDER BY ItemName ASC";

        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@CategoryId", categoryId);

        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
          BudgetItem item = new BudgetItem {
            Number = ++i,  // Порядковий номер для виведення у таблиці
            ItemId = Convert.ToInt32(reader["ItemId"]),
            CategoryId = Convert.ToInt32(reader["CategoryId"]),
            ItemName = reader["ItemName"].ToString(),
            Description = reader["Description"].ToString(),
            DefaultAmount = Convert.ToDouble(reader["DefaultAmount"])
          };
          itemList.Add(item);
        }

        reader.Close();
      }

      // Якщо список порожній — додаємо службове повідомлення
      if (itemList.Count == 0) {
        BudgetItem noData = new BudgetItem {
          ItemId = 0,
          CategoryId = categoryId,
          Message = $"У категорії з ID = {categoryId} відсутні записи витрат."
        };
        itemList.Add(noData);
      }

      return itemList;
    }

    /// <summary>
    /// Повертає одну позицію бюджету за її ідентифікатором (ItemId).
    /// </summary>
    public BudgetItem SelectedBudgetItemById(int itemId) {
      BudgetItem selectedItem = new BudgetItem();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "SELECT * FROM budget_items WHERE ItemId = @ItemId";

        using (MySqlCommand command = new MySqlCommand(query, connection)) {
          command.Parameters.AddWithValue("@ItemId", itemId);

          connection.Open();
          using (MySqlDataReader reader = command.ExecuteReader()) {
            if (reader.Read()) {
              selectedItem.ItemId = Convert.ToInt32(reader["ItemId"]);
              selectedItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
              selectedItem.ItemName = reader["ItemName"].ToString();
              selectedItem.Description = reader["Description"].ToString();
              selectedItem.DefaultAmount = Convert.ToDouble(reader["DefaultAmount"]);
            }
          }
        }
      }

      return selectedItem;
    }

    /// <summary>
    /// Оновлює дані позиції бюджету за заданим ідентифікатором.
    /// </summary>
    public void UpdateBudgetItem(int categoryId, string itemName, double? defaultAmount, 
      string description, int itemId) {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query =
            "UPDATE budget_items " +
            "SET CategoryId = @CategoryId, ItemName = @ItemName, " +
            "DefaultAmount = @DefaultAmount, Description = @Description " +
            "WHERE ItemId = @ItemId";
        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@ItemId", itemId);
          cmd.Parameters.AddWithValue("@CategoryId", categoryId);
          cmd.Parameters.AddWithValue("@ItemName", itemName);
          cmd.Parameters.AddWithValue("@DefaultAmount", defaultAmount.HasValue ? 
            defaultAmount.Value : (object)DBNull.Value);
          cmd.Parameters.AddWithValue("@Description", description);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    /// <summary>
    /// Видаляє позицію бюджету за її ідентифікатором.
    /// </summary>
    public void DeleteBudgetItem(int itemId) {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "DELETE FROM budget_items WHERE ItemId = @ItemId";

        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@ItemId", itemId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }


    public bool TryDeleteBudgetItem(int itemId, out string userMessage) {
      userMessage = string.Empty;

      try {
        using (MySqlConnection cn = new MySqlConnection(_ConnStr)) {
          using (MySqlCommand cmd = new MySqlCommand("DELETE FROM budget_items WHERE ItemId = @ItemId", cn)) {
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            cn.Open();
            int affected = cmd.ExecuteNonQuery();
            return affected > 0;
          }
        }
      } catch (MySqlException ex) {
        if (ex.Number == 1451) {
          userMessage = "Цю позицію не можна видалити: на неї посилаються записи в таблиці transactions.";
          return false;
        } else {
          userMessage = "Помилка бази даних: " + ex.Message;
          return false;
        }
      } catch (Exception ex) {
        userMessage = "Непередбачена помилка: " + ex.Message;
        return false;
      }
    }


  }
}


/// <summary>
/// Клас-модель для представлення окремої позиції бюджету.
/// Використовується для зберігання конкретних елементів витрат або доходів,
/// що належать до певної категорії.
/// </summary>
public class BudgetItem {
  // Порядковий номер запису (для відображення у таблиці чи звіті)
  public int Number { get; set; }

  // Унікальний ідентифікатор позиції (ключ таблиці budget_items)
  public int ItemId { get; set; }

  // Ідентифікатор категорії, до якої належить дана позиція
  public int CategoryId { get; set; }

  // Назва позиції (наприклад: "Пальне", "Оренда житла", "Комунальні послуги")
  public string ItemName { get; set; } = string.Empty;

  // Типова (рекомендована) сума за замовчуванням
  public double DefaultAmount { get; set; }

  // Опис або додаткова інформація про позицію
  public string Description { get; set; } = string.Empty;

  // Повідомлення про стан або результат операції (службове поле)
  public string Message { get; set; } = string.Empty;

  /// <summary>
  /// Конструктор без параметрів із ініціалізацією значень за замовчуванням.
  /// </summary>
  public BudgetItem() { }
}
