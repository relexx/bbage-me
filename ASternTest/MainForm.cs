using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pathfinder;

namespace ASternTest
{
  public partial class MainForm : Form
  {
    private PolygonManager m_Manager;

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      m_Manager = new PolygonManager();
      m_Manager.DoTestData();
      btnDoPaint_Click(null, null);
    }

    private void MainForm_Paint(object sender, PaintEventArgs e)
    {
      
    }

    private void DoPaint(Graphics g)
    {
      int pointwidth = 6;
      foreach (Vertice v in m_Manager.VerticeList)
      {
        g.FillPie(Brushes.Red, v.Position.X * 10 - pointwidth / 2, v.Position.Y * 10 - pointwidth / 2, pointwidth, pointwidth, 0, 360);
      }

      foreach (Polygon p in m_Manager.PolygonList)
      {
        g.DrawLine(Pens.Black, p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10, p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10);
        g.DrawLine(Pens.Black, p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10, p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10);
        g.DrawLine(Pens.Black, p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10, p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10);
      }
    }

    private void btnDoPaint_Click(object sender, EventArgs e)
    {
      Image img = new Bitmap(plTarget.Width, plTarget.Height);
      Graphics g = Graphics.FromImage(img);

      DoPaint(g);
      if (plTarget.BackgroundImage != null)
      {
        plTarget.BackgroundImage.Dispose();
      }
      plTarget.BackgroundImage = img;
    }
  }
}