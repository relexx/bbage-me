using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pathfinder
{
  public class Polygon
  {
    private static int s_IdCounter = 0;
    private int id;

    private Vertice m_Vertice0;
    private Vertice m_Vertice1;
    private Vertice m_Vertice2;
    private PolygonType m_Type;
    private PolygonCenterType m_CenterType;
    private List<Polygon> m_Neighbors;

    public int ID
    {
      get { return id; }
    }

    public List<Polygon> Neighbors
    {
      get { return m_Neighbors; }
      set { m_Neighbors = value; }
    }

    public PolygonCenterType CenterType
    {
      get { return m_CenterType; }
      set { m_CenterType = value; }
    }

    public PolygonType Type
    {
      get { return m_Type; }
      set { m_Type = value; }
    }

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
      set
      { m_Vertice2 = value; }
    }

    public Polygon()
    {
      id = s_IdCounter++;

      m_Neighbors = new List<Polygon>();

      m_Vertice0 = new Vertice();
      m_Vertice1 = new Vertice();
      m_Vertice2 = new Vertice();

      m_CenterType = PolygonCenterType.centroid;
      m_Type = PolygonType.normal;
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

    public Point GetCenter()
    {
      Point result;

      Point v0 = m_Vertice0.Position;
      Point v1 = m_Vertice1.Position;
      Point v2 = m_Vertice2.Position;

      if (m_CenterType == PolygonCenterType.centroid)
      {
        int cx = (int)Math.Floor((double)(v0.X + v1.X + v2.X) / (double)3);
        int cy = (int)Math.Floor((double)(v0.Y + v1.Y + v2.Y) / (double)3);

        result = new Point(cx, cy);
      }
      else
      {
        throw new Exception("tsnh: You should implement this!");
      }

      return result;
    }

    public void RefreshNeigbors()
    {
      List<Polygon> tempList = new List<Polygon>();
      if (m_Vertice0 != null)
      {
        foreach (Polygon p in m_Vertice0.CurrentPolygonList)
        {
          if (!tempList.Contains(p))
          {
            tempList.Add(p);
          }
        }
      }

      if (m_Vertice1 != null)
      {
        foreach (Polygon p in m_Vertice1.CurrentPolygonList)
        {
          if (p != this)
          {
            if (tempList.Contains(p))
            {
              m_Neighbors.Add(p);
              tempList.Remove(p);
            }
            else
            {
              tempList.Add(p);
            }
          }
        }
      }

      if (m_Vertice2 != null)
      {
        foreach (Polygon p in m_Vertice2.CurrentPolygonList)
        {
          if (p != this)
          {
            if (tempList.Contains(p))
            {
              m_Neighbors.Add(p);
              tempList.Remove(p);
            }
            else
            {
              tempList.Add(p);
            }
          }
        }
      }
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public int Distance(Polygon that)
    {
      int result = 0;

      if (that != null)
      {
        Point thisP = this.GetCenter();
        Point thatP = that.GetCenter();

        double dx = Math.Abs(thisP.X - thatP.X);
        double dy = Math.Abs(thisP.Y - thatP.Y);

        double distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

        result = (int)Math.Floor(distance);
      }

      return result;
    }
  }
}
