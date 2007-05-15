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
    private Polygon m_SelectedSourcePolygon;
    private Polygon m_SelectedDestinationPolygon;
    private List<Polygon> m_SelectedBlockedPolygons;

    public MainForm()
    {
      InitializeComponent();

      m_SelectedBlockedPolygons = new List<Polygon>();
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
      if (m_SelectedSourcePolygon != null)
      {
        FillPolygon(g, m_SelectedSourcePolygon, Color.Red);
      }
      if (m_SelectedDestinationPolygon != null)
      {
        FillPolygon(g, m_SelectedDestinationPolygon, Color.Blue);
      }

      foreach (Polygon blockedpoly in m_SelectedBlockedPolygons)
      {
        FillPolygon(g, blockedpoly, Color.Gray);
      }
    }

    private void DrawPolygon(Graphics g, Polygon p)
    {
      g.DrawLine(Pens.Black, p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10, p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10);
      g.DrawLine(Pens.Black, p.Vertice1.Position.X * 10, p.Vertice1.Position.Y * 10, p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10);
      g.DrawLine(Pens.Black, p.Vertice2.Position.X * 10, p.Vertice2.Position.Y * 10, p.Vertice0.Position.X * 10, p.Vertice0.Position.Y * 10);
    }

    private void FillPolygon(Graphics g, Polygon p, Color c)
    {
      g.FillPolygon(new SolidBrush(c), new Point[] {
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
      Polygon poly = m_Manager.FindPolygon(p);

      if (e.Button == MouseButtons.Left)
      {
        if (m_SelectedSourcePolygon != null)
        {
          m_SelectedDestinationPolygon = m_SelectedSourcePolygon;
        }
        m_SelectedSourcePolygon = poly;
      }
      else if (poly != null)
      {
        bool exists = false;
        foreach (Polygon existingpoly in m_SelectedBlockedPolygons)
        {
          if (existingpoly == poly)
          {
            exists = true;
            m_SelectedBlockedPolygons.Remove(existingpoly);
            break;
          }
        }
        if (!exists)
        {
          m_SelectedBlockedPolygons.Add(poly);
        }
      }
      Refresh();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      m_SelectedBlockedPolygons.Clear();
      m_SelectedDestinationPolygon = null;
      m_SelectedSourcePolygon = null;
    }
  }
}