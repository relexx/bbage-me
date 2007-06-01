using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      MainForm form = new MainForm();
      form.Init();
      form.Run();
    }
  }
}