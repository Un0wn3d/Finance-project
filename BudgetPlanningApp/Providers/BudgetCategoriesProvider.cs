using BudgetPlanningApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanningApp.Providers {
  internal class BudgetCategoriesProvider {
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];


    /// <summary>
    /// Додавання нової категорії бюджету у таблицю budget_categories.
    /// </summary>
    public void InsertBudgetCategory(string categoryName, string description, bool isActive) {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "INSERT INTO budget_categories (CategoryName, Description, IsActive) " +
                       "VALUES (@CategoryName, @Description, @IsActive)";

        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
        cmd.Parameters.AddWithValue("@Description", description);
        cmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);

        connection.Open();
        cmd.ExecuteNonQuery();
      }
    }

    /// <summary>
    /// Отримання повного списку категорій бюджету.
    /// </summary>
    public List<BudgetCategory> GetAllBudgetCategory() {
      int i = 0;
      List<BudgetCategory> categoryList = new List<BudgetCategory>();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "SELECT * FROM budget_categories ORDER BY CategoryName ASC";
        MySqlCommand command = new MySqlCommand(query, connection);
        connection.Open();

        using (MySqlDataReader reader = command.ExecuteReader()) {
          while (reader.Read()) {
            BudgetCategory category = new BudgetCategory {
              Number = ++i,
              CategoryId = Convert.ToInt32(reader["CategoryId"]),
              CategoryName = reader["CategoryName"].ToString(),
              Description = reader["Description"].ToString(),
              IsActive = Convert.ToBoolean(reader["IsActive"])
            };
            categoryList.Add(category);
          }
        }
      }

      // Якщо даних немає — повертаємо службовий запис з повідомленням
      if (categoryList.Count == 0) {
        BudgetCategory noData = new BudgetCategory {
          CategoryId = 0,
          Message = NamesMy.NoDataNames.NoDataInBudgetCategory
        };
        categoryList.Add(noData);
      }

      return categoryList;
    }


    /// <summary>
    /// Отримує всі активні категорії бюджету (IsActive = 1),
    /// відсортовані за назвою.
    /// </summary>
    public List<BudgetCategory> GetAllActiveBudgetCategory() {
      int i = 0;
      List<BudgetCategory> categoryList = new List<BudgetCategory>();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        // Вибираємо лише активні категорії
        string query = "SELECT * FROM budget_categories WHERE IsActive = 1 ORDER BY CategoryName ASC";
        MySqlCommand command = new MySqlCommand(query, connection);

        connection.Open();

        using (MySqlDataReader reader = command.ExecuteReader()) {
          while (reader.Read()) {
            BudgetCategory category = new BudgetCategory {
              Number = ++i, // порядковий номер
              CategoryId = Convert.ToInt32(reader["CategoryId"]),
              CategoryName = reader["CategoryName"].ToString(),
              Description = reader["Description"] == DBNull.Value
                    ? string.Empty
                    : reader["Description"].ToString(),
              IsActive = Convert.ToBoolean(reader["IsActive"])
            };
            categoryList.Add(category);
          }
        }
      }

      // Якщо даних немає — додаємо службовий запис
      if (categoryList.Count == 0) {
        BudgetCategory noData = new BudgetCategory {
          CategoryId = 0,
          Message = NamesMy.NoDataNames.NoDataInBudgetCategory
        };
        categoryList.Add(noData);
      }

      return categoryList;
    }


    /// <summary>
    /// Повертає одну категорію бюджету за її ідентифікатором.
    /// </summary>
    public BudgetCategory SelectedBudgetCategoryById(int categoryId) {
      BudgetCategory selectedCategory = new BudgetCategory();

      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "SELECT * FROM budget_categories WHERE CategoryId = @CategoryId";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@CategoryId", categoryId);

        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read()) {
          selectedCategory.CategoryId = Convert.ToInt32(reader["CategoryId"]);
          selectedCategory.CategoryName = reader["CategoryName"].ToString();
          selectedCategory.Description = reader["Description"].ToString();
          selectedCategory.IsActive = Convert.ToBoolean(reader["IsActive"]);
        }

        reader.Close();
      }

      return selectedCategory;
    }

    /// <summary>
    /// Оновлює дані категорії бюджету за заданим ідентифікатором.
    /// </summary>
    public void UpdateBudgetCategory(string categoryName, string description, bool isActive, int categoryId) {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "UPDATE budget_categories " +
                       "SET CategoryName = @CategoryName, Description = @Description, IsActive = @IsActive " +
                       "WHERE CategoryId = @CategoryId";

        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
        cmd.Parameters.AddWithValue("@Description", description);
        cmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);
        cmd.Parameters.AddWithValue("@CategoryId", categoryId);

        connection.Open();
        cmd.ExecuteNonQuery();
      }
    }

    /// <summary>
    /// Видаляє категорію бюджету за її ідентифікатором.
    /// </summary>
    public void DeleteBudgetCategory(int categoryId) {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        string query = "DELETE FROM budget_categories WHERE CategoryId = @CategoryId";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@CategoryId", categoryId);

        connection.Open();
        cmd.ExecuteNonQuery();
      }
    }

    // === Безпечне видалення категорії бюджету ===
    public bool TryDeleteBudgetCategory(int categoryId, out string userMessage) {
      userMessage = string.Empty;

      try {
        using (MySqlConnection cn = new MySqlConnection(_ConnStr)) {
          using (MySqlCommand cmd = new MySqlCommand("DELETE FROM budget_categories WHERE CategoryId = @CategoryId", cn)) {
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cn.Open();

            int affected = cmd.ExecuteNonQuery();
            return affected > 0;
          }
        }
      } catch (MySqlException ex) {
        if (ex.Number == 1451) {
          // Помилка зовнішнього ключа — категорія використовується в budget_items
          userMessage = "Неможливо видалити категорію, оскільки до неї прив’язані позиції у таблиці 'budget_items'.\n" +
                        "Спочатку видаліть або змініть пов’язані елементи, або зробіть категорію неактивною.";
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
/// Клас-модель для зберігання інформації про категорії бюджету.
/// Категорія визначає узагальнений тип витрат або доходів у системі.
/// </summary>
public class BudgetCategory {
  // Порядковий номер запису (для відображення у таблиці або звіті)
  public int Number { get; set; }

  // Унікальний ідентифікатор категорії (ключ у таблиці budget_categories)
  public int CategoryId { get; set; }

  // Назва категорії (наприклад: "Їжа", "Житло", "Транспорт", "Зарплата")
  public string CategoryName { get; set; } = string.Empty;

  // Опис категорії або додаткова інформація
  public string Description { get; set; } = string.Empty;

  // Ознака активності категорії (1 – активна, 0 – неактивна)
  public bool IsActive { get; set; } = true;

  // Повідомлення про стан або результат операції з категорією
  public string Message { get; set; } = string.Empty;

  /// <summary>
  /// Конструктор без параметрів із ініціалізацією значень за замовчуванням.
  /// </summary>
  public BudgetCategory() { }
}
