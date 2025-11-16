using BudgetPlanningApp.Forms.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetPlanningApp {
  internal static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new LoginForm());
    }

    public static void RestartApp() {
      Application.Exit();
      System.Diagnostics.Process.Start(Application.ExecutablePath);
    }
  }
}
