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
    private Polygon m_SelectedPolygon;

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
        DrawPolygon(g, p);
      }
      if (m_SelectedPolygon != null)
      {
        DrawPolygon(g, m_SelectedPolygon);
        FillPolygon(g, m_SelectedPolygon);
      }
    }

    private void DrawPolygon(Graphics g, Polygon p)
    {
      g.DrawLine(Pens.Black, p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10, p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10);
      g.DrawLine(Pens.Black, p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10, p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10);
      g.DrawLine(Pens.Black, p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10, p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10);
    }

    private void FillPolygon(Graphics g, Polygon p)
    {
      g.FillPolygon(Brushes.Red, new Point[] {
        new Point(p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10), 
        new Point(p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10),
        new Point(p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10)});
    }

    private void btnDoPaint_Click(object sender, EventArgs e)
    {
      plTarget.Refresh();
    }

    private void plTarget_Paint(object sender, PaintEventArgs e)
    {
      DoPaint(e.Graphics);
    }

    private void plTarget_MouseDown(object sender, MouseEventArgs e)
    {
      Point p = new Point((int)Math.Floor((double)e.X / 10), (int)Math.Floor((double)e.Y / 10));
      m_SelectedPolygon = m_Manager.FindPolygon(p);
      Refresh();
    }
  }
}