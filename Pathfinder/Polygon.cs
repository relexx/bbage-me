using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pathfinder
{
  public class Polygon
  {
    private Vertice m_Vertice0;
    private Vertice m_Vertice1;
    private Vertice m_Vertice2;

    public Vertice Vertice0
    {
      get { return m_Vertice0; }
      set { m_Vertice0 = value; }
    }

    public Vertice Vertice1
    {
      get { return m_Vertice1; }
      set { m_Vertice1 = value; }
    }

    public Vertice Vertice2
    {
      get { return m_Vertice2; }
      set { m_Vertice2 = value; }
    }

    public Polygon()
    {
      m_Vertice0 = new Vertice();
      m_Vertice1 = new Vertice();
      m_Vertice2 = new Vertice();
    }

    public Polygon(Vertice v1, Vertice v2, Vertice v3)
      :this()
    {
      m_Vertice0 = v1;
      m_Vertice1 = v2;
      m_Vertice2 = v3;
    }

    public bool Contains(Point p)
    {
      bool result = false;

      Point p0 = Vertice0.Position;
      Point p1 = Vertice1.Position;
      Point p2 = Vertice2.Position;

      GraphicsPath data = new GraphicsPath(FillMode.Winding);
      data.AddPolygon(new Point[] {p0, p1, p2});
      Region r = new Region(data);

      result = r.IsVisible(p);

      return result;
    }

    public override bool Equals(object obj)
    {
      bool result = false;
      Polygon p1 = this;
      Polygon p2 = obj as Polygon;

      if (  p1 == null && p1 != null
        ||  p1 != null && p1 == null)
      { return false; }
      else if ( p1 == null && p1 == null)
      { return true; }
      
      if (p1.m_Vertice0 == p2.m_Vertice0
        && p1.m_Vertice1 == p2.m_Vertice1
        && p1.m_Vertice2 == p2.m_Vertice2)
      {
        result = true;
      }

      return result;
    }
  }
}
