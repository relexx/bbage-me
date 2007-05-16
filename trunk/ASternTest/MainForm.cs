using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pathfinder;
using System.Drawing.Drawing2D;

namespace ASternTest
{
  public partial class MainForm : Form
  {
    private PolygonManager m_Manager;
    private Pathfinder.Pathfinder m_Pathfinder;
    private Polygon m_SelectedSourcePolygon;
    private Polygon m_SelectedDestinationPolygon;
    private List<PathEntry> m_PathEntries;
    private int m_Factor;

    public MainForm()
    {
      InitializeComponent();

      m_Factor = 10;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      m_Manager = new PolygonManager();
      m_Pathfinder = new Pathfinder.Pathfinder(m_Manager);

      m_Manager.DoTestData();
      btnDoPaint_Click(null, null);
    }

    private void MainForm_Paint(object sender, PaintEventArgs e)
    {
      
    }

    private void DoPaint(Graphics g)
    {
      foreach (Polygon p in m_Manager.PolygonList)
      {
        DrawPolygon(g, p);

        if (p.Type == PolygonType.obstacle)
        {
          FillPolygon(g, p, Color.Gray);
        }
      }

      if (m_SelectedSourcePolygon != null)
      {
        FillPolygon(g, m_SelectedSourcePolygon, Color.DarkRed);
      }
      if (m_SelectedDestinationPolygon != null)
      {
        FillPolygon(g, m_SelectedDestinationPolygon, Color.DarkBlue);
      }
      if (m_SelectedDestinationPolygon != null && m_SelectedSourcePolygon != null)
      {
        Point c1 = m_SelectedSourcePolygon.GetCenter();
        Point c2 = m_SelectedDestinationPolygon.GetCenter();
        Pen p = (Pen)Pens.White.Clone();
        p.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
        g.DrawLine(p, c1.X * m_Factor, c1.Y * m_Factor, c2.X * m_Factor, c2.Y * m_Factor);
      }

      int pointwidth = 2 * m_Factor / 5;
      pointwidth = pointwidth < 2 ? 2 : pointwidth;
      foreach (Vertice v in m_Manager.VerticeList)
      {
        g.FillPie(Brushes.Red, v.Position.X * m_Factor - pointwidth / 2, v.Position.Y * m_Factor - pointwidth / 2, pointwidth, pointwidth, 0, 360);
      }

      if (m_PathEntries != null)
      {
        for (int i = 0; i < m_PathEntries.Count; i++)
			  {
          Polygon pathpolygon = m_PathEntries[i].EntryPolygon;
          Point pathpoint = pathpolygon.GetCenter();
          Point p = new Point( pathpoint.X * m_Factor - pointwidth / 2, pathpoint.Y * m_Factor - pointwidth / 2);
          g.FillPie(Brushes.Black, new Rectangle(p.X, p.Y, pointwidth, pointwidth), 0, 360);
          string data = "Cost: "+m_PathEntries[i].Cost;
          Font f = new Font(FontFamily.GenericSerif, 12f);
          SizeF s = g.MeasureString(data, f);
          g.FillRectangle(Brushes.White, new Rectangle((int)p.X, (int)p.Y, (int)s.Width+2, (int)s.Height+2));
          g.DrawString(data, f, Brushes.Black, p.X + 1, p.Y + 1);

          if (i + 1 < m_PathEntries.Count)
          {
            Point pathpoint2 = m_PathEntries[i + 1].EntryPolygon.GetCenter();
            g.DrawLine(Pens.Black, pathpoint.X * m_Factor, pathpoint.Y * m_Factor, pathpoint2.X * m_Factor, pathpoint2.Y * m_Factor);
          }
        }
      }
    }

    private void DrawPolygon(Graphics g, Polygon p)
    {
      g.DrawLine(Pens.Black, p.Vertice0.Position.X * m_Factor, p.Vertice0.Position.Y * m_Factor, p.Vertice1.Position.X * m_Factor, p.Vertice1.Position.Y * m_Factor);
      g.DrawLine(Pens.Black, p.Vertice1.Position.X * m_Factor, p.Vertice1.Position.Y * m_Factor, p.Vertice2.Position.X * m_Factor, p.Vertice2.Position.Y * m_Factor);
      g.DrawLine(Pens.Black, p.Vertice2.Position.X * m_Factor, p.Vertice2.Position.Y * m_Factor, p.Vertice0.Position.X * m_Factor, p.Vertice0.Position.Y * m_Factor);
    }

    private void FillPolygon(Graphics g, Polygon p, Color c)
    {
      g.FillPolygon(new SolidBrush(c), new Point[] {
        new Point(p.Vertice0.Position.X * m_Factor, p.Vertice0.Position.Y * m_Factor), 
        new Point(p.Vertice1.Position.X * m_Factor, p.Vertice1.Position.Y * m_Factor),
        new Point(p.Vertice2.Position.X * m_Factor, p.Vertice2.Position.Y * m_Factor)});
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
      Point p = new Point((int)Math.Floor((double)e.X / m_Factor), (int)Math.Floor((double)e.Y / m_Factor));
      Polygon poly = m_Manager.FindPolygon(p);

      if (e.Button == MouseButtons.Left)
      {
        if (poly != null)
        {
          if (m_SelectedSourcePolygon == null)
          {
            m_SelectedSourcePolygon = poly;
          }
          else if (m_SelectedDestinationPolygon == null)
          {
            m_SelectedDestinationPolygon = poly;
          }
          else
          {
            m_SelectedSourcePolygon = m_SelectedDestinationPolygon;
            m_SelectedDestinationPolygon = poly;
          }
        }
        else
        {
          m_SelectedSourcePolygon = null;
          m_SelectedDestinationPolygon = null;
        }
      }
      else if (poly != null)
      {
        if (poly.Type == PolygonType.normal)
        {
          poly.Type = PolygonType.obstacle;
        }
        else
        {
          poly.Type = PolygonType.normal;
        }
      }
      plTarget.Refresh();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      foreach (Polygon poly in m_Manager.PolygonList)
      {
        poly.Type = PolygonType.normal;
      }
      m_PathEntries.Clear();
      m_SelectedDestinationPolygon = null;
      m_SelectedSourcePolygon = null;
      plTarget.Refresh();
    }

    private void tbFactor_Scroll(object sender, EventArgs e)
    {
      ttInfo.SetToolTip((Control)sender, "Factor: "+tbFactor.Value);
      m_Factor = tbFactor.Value;
      plTarget.Refresh();
    }

    private void btnFindPath_Click(object sender, EventArgs e)
    {
      if (m_SelectedDestinationPolygon != null && m_SelectedSourcePolygon != null)
      {
        m_PathEntries = m_Pathfinder.FindPath(m_SelectedSourcePolygon, m_SelectedDestinationPolygon);
        plTarget.Refresh();
      }
    }
  }
}