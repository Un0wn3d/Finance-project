using BudgetPlanningApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetPlanningApp.Providers {
  internal class GenerateData {
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];
    private EncryptData _encryptData = new EncryptData();

    /// <summary>
    /// Додає 5 типових активних категорій витрат до таблиці budget_categories.
    /// Використовується для первинного заповнення бази.
    /// </summary>
    public void InsertDefaultBudgetCategories() {
      try {
        // Створюємо список базових категорій
        var defaultCategories = new List<(string Name, string Description)>
        {
            ("Продукти харчування", "Витрати на продукти, напої, побутові товари."),
            ("Комунальні послуги", "Оплата електроенергії, газу, води, опалення."),
            ("Транспорт", "Пальне, проїзд у громадському транспорті, обслуговування авто."),
            ("Оренда житла", "Щомісячна плата за оренду квартири або будинку."),
            ("Розваги та відпочинок", "Кіно, кафе, подорожі, дозвілля, підписки тощо.")
        };

        using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
          connection.Open();

          foreach (var category in defaultCategories) {
            string query = "INSERT INTO budget_categories (CategoryName, Description, IsActive) " +
                           "VALUES (@CategoryName, @Description, @IsActive)";

            using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
              cmd.Parameters.AddWithValue("@CategoryName", category.Name);
              cmd.Parameters.AddWithValue("@Description", category.Description);
              cmd.Parameters.AddWithValue("@IsActive", 1); // усі активні

              cmd.ExecuteNonQuery();
            }
          }
        }
      } catch (Exception ex) {
        MessageBox.Show("Помилка під час вставлення категорій: " + ex.Message,
                        "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Додає по 5 типових позицій витрат (budget_items) для кожної категорії з таблиці budget_categories.
    /// Усі створені елементи є активними і мають типовий розмір витрат.
    /// </summary>
    public void InsertDefaultBudgetItems() {
      using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
        connection.Open();

        // 1. Отримуємо всі категорії, що є активними
        string selectQuery = "SELECT CategoryId, CategoryName FROM budget_categories WHERE IsActive = 1";
        MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection);

        using (MySqlDataReader reader = selectCmd.ExecuteReader()) {
          // Зберігаємо всі активні категорії у список для подальшої обробки
          List<(int CategoryId, string CategoryName)> activeCategories = new List<(int, string)>();

          while (reader.Read()) {
            int id = Convert.ToInt32(reader["CategoryId"]);
            string name = reader["CategoryName"].ToString();
            activeCategories.Add((id, name));
          }

          reader.Close();

          // 2. Для кожної категорії додаємо по 5 типових позицій витрат
          foreach (var cat in activeCategories) {
            var items = GetDefaultItemsForCategory(cat.CategoryName);

            foreach (var item in items) {
              string insertQuery = "INSERT INTO budget_items (CategoryId, ItemName, DefaultAmount, Description) " +
                                   "VALUES (@CategoryId, @ItemName, @DefaultAmount, @Description)";

              using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection)) {
                insertCmd.Parameters.AddWithValue("@CategoryId", cat.CategoryId);
                insertCmd.Parameters.AddWithValue("@ItemName", item.Item1);
                insertCmd.Parameters.AddWithValue("@DefaultAmount", item.Item2);
                insertCmd.Parameters.AddWithValue("@Description", item.Item3);

                insertCmd.ExecuteNonQuery();
              }
            }
          }
        }
      }
    }


    /// <summary>
    /// Формує набір із 5 типових позицій витрат для конкретної категорії.
    /// </summary>
    private List<(string, double, string)> GetDefaultItemsForCategory(string categoryName) {
      List<(string, double, string)> items = new List<(string, double, string)>();

      switch (categoryName) {
        case "Продукти харчування":
          items.Add(("Хліб", 30.0, "Повсякденні продукти"));
          items.Add(("Молоко", 40.0, "Молочні вироби"));
          items.Add(("М'ясо", 200.0, "Основні білкові продукти"));
          items.Add(("Овочі та фрукти", 150.0, "Щоденне харчування"));
          items.Add(("Солодощі", 100.0, "Десерти та перекуси"));
          break;

        case "Комунальні послуги":
          items.Add(("Електроенергія", 500.0, "Оплата рахунків за електрику"));
          items.Add(("Вода", 200.0, "Холодна і гаряча вода"));
          items.Add(("Газ", 400.0, "Плата за газ"));
          items.Add(("Опалення", 800.0, "Сезонні витрати"));
          items.Add(("Інтернет", 250.0, "Щомісячна підписка на інтернет"));
          break;

        case "Транспорт":
          items.Add(("Пальне", 1000.0, "Заправка автомобіля"));
          items.Add(("Громадський транспорт", 300.0, "Метро, автобуси, трамваї"));
          items.Add(("Стоянка", 150.0, "Паркування автомобіля"));
          items.Add(("Обслуговування авто", 700.0, "Масло, фільтри, шиномонтаж"));
          items.Add(("Таксі", 250.0, "Поїздки на короткі дистанції"));
          break;

        case "Оренда житла":
          items.Add(("Квартира", 8000.0, "Щомісячна плата за житло"));
          items.Add(("Комісія агенту", 1000.0, "Одноразові платежі"));
          items.Add(("Ремонтні витрати", 500.0, "Дрібні ремонти у помешканні"));
          items.Add(("Оренда паркомісця", 600.0, "Для автомобіля"));
          items.Add(("Прибирання", 300.0, "Послуги з клінінгу"));
          break;

        case "Розваги та відпочинок":
          items.Add(("Кінотеатр", 150.0, "Похід у кіно"));
          items.Add(("Кафе та ресторани", 500.0, "Харчування поза домом"));
          items.Add(("Подорожі", 3000.0, "Відпустка або короткі поїздки"));
          items.Add(("Підписки", 200.0, "Netflix, Spotify, YouTube Premium"));
          items.Add(("Спорт", 400.0, "Тренажерний зал, абонемент"));
          break;

        default:
          // Якщо категорія не визначена — створюємо 5 універсальних витрат
          items.Add(("Загальна витрата 1", 100.0, "Універсальна категорія"));
          items.Add(("Загальна витрата 2", 200.0, "Універсальна категорія"));
          items.Add(("Загальна витрата 3", 300.0, "Універсальна категорія"));
          items.Add(("Загальна витрата 4", 400.0, "Універсальна категорія"));
          items.Add(("Загальна витрата 5", 500.0, "Універсальна категорія"));
          break;
      }

      return items;
    }


    /// <summary>
    /// Додає трьох стандартних користувачів системи з роллю 2 і паролем "123".
    /// Використовується для первинного заповнення таблиці Users.
    /// </summary>
    public void InsertDefaultUsers() {
      try {
        using (MySqlConnection connection = new MySqlConnection(_ConnStr)) {
          connection.Open();

          // Створюємо список користувачів
          var defaultUsers = new List<(string FirstName, string LastName, string UserName, string Description)>
          {
                ("Іван", "Петренко", "ivan.petrenko", "Бухгалтер підприємства"),
                ("Марія", "Коваль", "maria.koval", "Менеджер з фінансів"),
                ("Олег", "Шевченко", "oleg.shevchenko", "Користувач системи бюджетного планування")
            };

          foreach (var user in defaultUsers) {
            string query = "INSERT INTO Users (FirstName, LastName, UserName, UserPassword, RoleId, Description) " +
                           "VALUES(@FirstName, @LastName, @UserName, @UserPassword, @RoleId, @Description)";

            using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
              cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
              cmd.Parameters.AddWithValue("@LastName", user.LastName);
              cmd.Parameters.AddWithValue("@UserName", user.UserName);
              cmd.Parameters.AddWithValue("@UserPassword", _encryptData.Encrypt("123")); // пароль для всіх
              cmd.Parameters.AddWithValue("@RoleId", 2); // роль користувача
              cmd.Parameters.AddWithValue("@Description", user.Description);

              cmd.ExecuteNonQuery();
            }
          }
        }

      } catch (Exception ex) {
        MessageBox.Show("Помилка під час вставлення користувачів: " + ex.Message,
                        "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }



    /// <summary>
    /// Створює витрати (transactions) для кожного користувача на поточний та наступні 3 місяці.
    /// Для кожного місяця генерується 10–15 різних позицій з budget_items.
    /// Сума = max(DefaultAmount, DefaultAmount * (1 + невелике збільшення)).
    /// TransactionType = 'expense'.
    /// </summary>
    /// <param name="users">Список користувачів (клас Users із властивістю UserId).</param>
    /// <param name="minPerMonth">Мінімум позицій на місяць (за замовчуванням 10).</param>
    /// <param name="maxPerMonth">Максимум позицій на місяць (за замовчуванням 15).</param>
    public void SeedExpensesForUsers(IEnumerable<User> users, int minPerMonth = 10, int maxPerMonth = 15) {
      if (minPerMonth < 1 || maxPerMonth < minPerMonth)
        throw new ArgumentException("Невірні межі кількості позицій на місяць.");

      // 1) Підтягуємо всі активні категорії та їхні айтеми з DefaultAmount
      var items = GetAllActiveItems(); // (ItemId, ItemName, CategoryId, DefaultAmount)
      if (items.Count == 0)
        throw new InvalidOperationException("Немає активних позицій у budget_items (або активних категорій).");

      var rng = new Random();

      using (var connection = new MySqlConnection(_ConnStr)) {
        connection.Open();
        using (var tx = connection.BeginTransaction()) {
          // Підготовлений INSERT
          string insertSql =
              "INSERT INTO transactions (UserId, ItemId, TransactionType, Amount, TransactionDate, Description) " +
              "VALUES (@UserId, @ItemId, @TransactionType, @Amount, @TransactionDate, @Description)";

          using (var cmd = new MySqlCommand(insertSql, connection, tx)) {
            cmd.Parameters.Add("@UserId", MySqlDbType.Int32);
            cmd.Parameters.Add("@ItemId", MySqlDbType.Int32);
            cmd.Parameters.Add("@TransactionType", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Amount", MySqlDbType.Decimal);
            cmd.Parameters.Add("@TransactionDate", MySqlDbType.DateTime);
            cmd.Parameters.Add("@Description", MySqlDbType.VarChar);

            foreach (var u in users) {
              // 2) Для кожного користувача генеруємо 4 місяці: поточний + 3 наступні
              DateTime monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

              for (int m = 0; m < 4; m++) {
                DateTime firstDay = monthStart.AddMonths(m);
                DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);
                int daysInMonth = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);

                // Кількість позицій на цей місяць
                int count = rng.Next(minPerMonth, maxPerMonth + 1);

                // Щоб позиції були різними в межах одного місяця, виберемо випадкову підмножину
                // Якщо айтемів мало, допускаємо повтор (але намагаємось уникати).
                var shuffledIndices = ShuffleIndices(items.Count, rng);
                int take = Math.Min(count, items.Count);

                for (int i = 0; i < take; i++) {
                  var it = items[shuffledIndices[i]];

                  // Якщо DefaultAmount немає — візьмемо резервне значення (наприклад, 100.00)
                  decimal baseAmount = it.DefaultAmount.HasValue ? it.DefaultAmount.Value : 100.00m;

                  // Невелике збільшення: 0%..15%
                  // Гарантуємо не менше baseAmount
                  decimal factor = 1m + (decimal)rng.NextDouble() * 0.15m;
                  decimal amount = Math.Max(baseAmount, Math.Round(baseAmount * factor, 2, MidpointRounding.AwayFromZero));

                  // Випадковий день цього місяця
                  int day = rng.Next(1, daysInMonth + 1);
                  var txDate = new DateTime(firstDay.Year, firstDay.Month, day,
                                            rng.Next(8, 21), // година 8..20 для реалістичності
                                            rng.Next(0, 60), // хвилини
                                            0);

                  // Параметри
                  cmd.Parameters["@UserId"].Value = u.UserId;
                  cmd.Parameters["@ItemId"].Value = it.ItemId;
                  cmd.Parameters["@TransactionType"].Value = "expense";
                  cmd.Parameters["@Amount"].Value = amount;
                  cmd.Parameters["@TransactionDate"].Value = txDate;
                  cmd.Parameters["@Description"].Value = $"Автогенерована витрата за '{it.ItemName}'";

                  cmd.ExecuteNonQuery();
                }

                // Якщо потрібно рівно count (а айтемів менше), дозаповнимо повтореннями
                for (int i = take; i < count; i++) {
                  var it = items[rng.Next(items.Count)];
                  decimal baseAmount = it.DefaultAmount.HasValue ? it.DefaultAmount.Value : 100.00m;
                  decimal factor = 1m + (decimal)rng.NextDouble() * 0.15m;
                  decimal amount = Math.Max(baseAmount, Math.Round(baseAmount * factor, 2, MidpointRounding.AwayFromZero));

                  int day = rng.Next(1, daysInMonth + 1);
                  var txDate = new DateTime(firstDay.Year, firstDay.Month, day,
                                            rng.Next(8, 21), rng.Next(0, 60), 0);

                  cmd.Parameters["@UserId"].Value = u.UserId;
                  cmd.Parameters["@ItemId"].Value = it.ItemId;
                  cmd.Parameters["@TransactionType"].Value = "expense";
                  cmd.Parameters["@Amount"].Value = amount;
                  cmd.Parameters["@TransactionDate"].Value = txDate;
                  cmd.Parameters["@Description"].Value = $"Автогенерована витрата за '{it.ItemName}'";

                  cmd.ExecuteNonQuery();
                }
              }
            }
          }

          tx.Commit();
        }
      }
    }

    /// <summary>
    /// Повертає всі активні айтеми (із активних категорій) з дефолтними сумами.
    /// </summary>
    private List<BudgetItemRow> GetAllActiveItems() {
      var list = new List<BudgetItemRow>();
      using (var connection = new MySqlConnection(_ConnStr)) {
        string sql = @"
                SELECT bi.ItemId, bi.ItemName, bi.CategoryId, bi.DefaultAmount
                FROM budget_items bi
                JOIN budget_categories bc ON bc.CategoryId = bi.CategoryId
                WHERE bc.IsActive = 1
                ORDER BY bi.ItemName ASC";

        using (var cmd = new MySqlCommand(sql, connection)) {
          connection.Open();
          using (var r = cmd.ExecuteReader()) {
            while (r.Read()) {
              var row = new BudgetItemRow {
                ItemId = Convert.ToInt32(r["ItemId"]),
                ItemName = r["ItemName"].ToString(),
                CategoryId = Convert.ToInt32(r["CategoryId"]),
                DefaultAmount = r["DefaultAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(r["DefaultAmount"])
              };
              list.Add(row);
            }
          }
        }
      }
      return list;
    }

    /// <summary>
    /// Повертає масив індексів 0..n-1 у випадковому порядку.
    /// </summary>
    private static int[] ShuffleIndices(int n, Random rng) {
      var arr = new int[n];
      for (int i = 0; i < n; i++) arr[i] = i;

      for (int i = n - 1; i > 0; i--) {
        int j = rng.Next(i + 1);
        (arr[i], arr[j]) = (arr[j], arr[i]);
      }
      return arr;
    }


  }
}

// Локальний DTO для айтемів
public class BudgetItemRow {
  public int ItemId { get; set; }
  public string ItemName { get; set; } = string.Empty;
  public int CategoryId { get; set; }
  public decimal? DefaultAmount { get; set; }
}
