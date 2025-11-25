using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanningApp.AppCode {
  internal class AccountsApp {
    private string _ConnStr = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    /// <summary>
    /// Повертає агреговані по днях витрати/доходи користувача за вказаним ItemId у періоді [from; to].
    /// Інтервал робимо напіввідкритим: [From; ToNextDay), щоб включити весь день "To".
    /// </summary>
    public List<Storys> GetAllStorysForUserByBudgetItemIdAndDate(int userId, int itemId,
      DateTime from, DateTime to) {
      var list = new List<Storys>();
      // Робимо межі як [from; toNextDay) — включає повністю день "to"
      DateTime fromDate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
      DateTime toNextDay = new DateTime(to.Year, to.Month, to.Day, 0, 0, 0).AddDays(1);
      string sql = @"
            SELECT 
                DATE(t.TransactionDate)    AS DayVal,
                SUM(CASE WHEN t.TransactionType = 'Витрати' THEN t.Amount ELSE 0 END) AS SpendingSumma,
                SUM(CASE WHEN t.TransactionType = 'Доходи'  THEN t.Amount ELSE 0 END) AS ProfitSumma
            FROM transactions t
            WHERE t.UserId = @UserId
              AND t.ItemId = @ItemId
              AND t.TransactionDate >= @FromDate
              AND t.TransactionDate <  @ToNextDay
            GROUP BY DATE(t.TransactionDate)
            ORDER BY DayVal ASC;";

      using (var cn = new MySqlConnection(_ConnStr))
      using (var cmd = new MySqlCommand(sql, cn)) {
        cmd.Parameters.AddWithValue("@UserId", userId);
        cmd.Parameters.AddWithValue("@ItemId", itemId);
        cmd.Parameters.AddWithValue("@FromDate", fromDate);
        cmd.Parameters.AddWithValue("@ToNextDay", toNextDay);

        cn.Open();
        using (var r = cmd.ExecuteReader()) {
          while (r.Read()) {
            var d = Convert.ToDateTime(r["DayVal"]);
            double exp = r["SpendingSumma"] == DBNull.Value ? 0.0 : Convert.ToDouble(r["SpendingSumma"]);
            double inc = r["ProfitSumma"] == DBNull.Value ? 0.0 : Convert.ToDouble(r["ProfitSumma"]);

            list.Add(new Storys {
              StoryDateTime = d,
              SpendingSumma = exp,
              ProfitSumma = inc
            });
          }
        }
      }

      return list;
    }

    /// <summary>
    /// Повертає агреговані витрати користувача по місяцях у проміжку [fromMonth; toMonth] включно.
    /// Межі часу реалізовані як [MonthStart; NextMonthStart) для коректного охоплення всіх дат.
    /// </summary>
    public List<MonthlyExpense> GetUserMonthlyExpenses(int userId, DateTime fromMonth, DateTime toMonth) {
      var list = new List<MonthlyExpense>();

      // Нормалізація до першого числа місяця 00:00:00
      DateTime fromStart = new DateTime(fromMonth.Year, fromMonth.Month, 1);
      DateTime toNext = new DateTime(toMonth.Year, toMonth.Month, 1).AddMonths(1);

      string sql = @"
            SELECT
                YEAR(t.TransactionDate)  AS Y,
                MONTH(t.TransactionDate) AS M,
                SUM(CASE WHEN t.TransactionType = 'Витрати' THEN t.Amount ELSE 0 END) AS ExpenseSum
            FROM transactions t
            WHERE t.UserId = @UserId
              AND t.TransactionDate >= @FromStart
              AND t.TransactionDate <  @ToNext
            GROUP BY YEAR(t.TransactionDate), MONTH(t.TransactionDate)
            ORDER BY Y, M;";

      using (var cn = new MySqlConnection(_ConnStr))
      using (var cmd = new MySqlCommand(sql, cn)) {
        cmd.Parameters.AddWithValue("@UserId", userId);
        cmd.Parameters.AddWithValue("@FromStart", fromStart);
        cmd.Parameters.AddWithValue("@ToNext", toNext);

        cn.Open();
        using (var r = cmd.ExecuteReader()) {
          while (r.Read()) {
            list.Add(new MonthlyExpense {
              Year = Convert.ToInt32(r["Y"]),
              Month = Convert.ToInt32(r["M"]),
              ExpenseSum = r["ExpenseSum"] == DBNull.Value ? 0.0 : Convert.ToDouble(r["ExpenseSum"])
            });
          }
        }
      }

      return list;
    }


    /// <summary>
    /// Повертає список рядків План/Факт по всіх активних позиціях користувача за вказаний місяць.
    /// План = DefaultAmount з budget_items (1 раз/місяць), Факт = сума expense за місяць.
    /// Межі часу: [MonthStart; NextMonthStart) – без «пастки опівночі».
    /// </summary>
    public List<PlanFactRow> GetUserPlanFactByMonth(int userId, DateTime month) {
      var list = new List<PlanFactRow>();

      DateTime monthStart = new DateTime(month.Year, month.Month, 1);
      DateTime nextMonthStart = monthStart.AddMonths(1);

      string sql = @"
            SELECT
                bc.CategoryName,
                bi.ItemName,
                COALESCE(bi.DefaultAmount, 0)                                  AS Planned,
                COALESCE(SUM(CASE WHEN t.TransactionType = 'Витрати'
                                   THEN t.Amount END), 0)                        AS Actual
            FROM budget_items bi
            JOIN budget_categories bc ON bc.CategoryId = bi.CategoryId
            LEFT JOIN transactions t
                ON t.ItemId = bi.ItemId
               AND t.UserId = @UserId
               AND t.TransactionType = 'Витрати'
               AND t.TransactionDate >= @MonthStart
               AND t.TransactionDate <  @NextMonthStart
            WHERE bc.IsActive = 1
            GROUP BY bc.CategoryName, bi.ItemName, bi.DefaultAmount
            ORDER BY bc.CategoryName ASC, bi.ItemName ASC;";

      using (var cn = new MySqlConnection(_ConnStr))
      using (var cmd = new MySqlCommand(sql, cn)) {
        cmd.Parameters.AddWithValue("@UserId", userId);
        cmd.Parameters.AddWithValue("@MonthStart", monthStart);
        cmd.Parameters.AddWithValue("@NextMonthStart", nextMonthStart);

        cn.Open();
        using (var r = cmd.ExecuteReader()) {
          while (r.Read()) {
            var row = new PlanFactRow {
              CategoryName = r["CategoryName"].ToString(),
              ItemName = r["ItemName"].ToString(),
              Planned = Convert.ToDouble(r["Planned"]),
              Actual = Convert.ToDouble(r["Actual"])
            };
            list.Add(row);
          }
        }
      }

      return list;
    }


  }
}

// DTO для ряду графіка
public class Storys {
  public DateTime StoryDateTime { get; set; }   // день
  public double SpendingSumma { get; set; }   // сума витрат за день
  public double ProfitSumma { get; set; }   // сума доходів за день (якщо потрібно)
}

public class MonthlyExpense {
  // Рік та місяць звітного періоду
  public int Year { get; set; }
  public int Month { get; set; }

  // Загальна сума витрат (TransactionType = 'expense') за місяць
  public double ExpenseSum { get; set; }
}

public class PlanFactRow {
  public string CategoryName { get; set; } = string.Empty; // Категорія
  public string ItemName { get; set; } = string.Empty;     // Позиція
  public double Planned { get; set; }                      // План (DefaultAmount або 0)
  public double Actual { get; set; }                       // Факт (сума витрат)
  public double Deviation => Actual - Planned;             // Відхилення (факт - план)
  public double UtilizationPercent                       // Виконання плану у %
      => Planned <= 0.0 ? 0.0 : (Actual / Planned) * 100.0;
}
