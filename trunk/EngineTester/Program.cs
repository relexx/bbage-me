using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GraphicsEngine;
using System.Drawing;

namespace EngineTester
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Engine engine = new DXEngine();

        // ExampleData
        engine.DrawLine(Color.Black, new Point(10, 10), new Point(100, 100));
        engine.DrawLine(Color.Red, new Point(100, 100), new Point(0, 100));

        while (engine.Created())
        {
          //do stuff
          engine.Render();
          Application.DoEvents();
          System.Threading.Thread.Sleep(20);
        }

        Application.Exit();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }
  }
}