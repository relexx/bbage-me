using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pathfinder
{
  /// <summary>
  /// a triangle-shaped structure. Consists of 3 Vertices
  /// </summary>
  public class Polygon
  {
    private static int s_IdCounter = 0;
    private int id;

    private Vertex m_Vertex0;
    private Vertex m_Vertex1;
    private Vertex m_Vertex2;
    private PolygonType m_Type;
    private PolygonCenterType m_CenterType;
    private List<Polygon> m_Neighbors;

    /// <summary>
    /// Polygon Identity
    /// </summary>
    public int ID
    {
      get { return id; }
    }

    /// <summary>
    /// List of Neighbors surrounding the current Polygon.
    /// Be careful. Use RefreshNeigbors() Method for refreshing this data.
    /// </summary>
    public List<Polygon> Neighbors
    {
      get { return m_Neighbors; }
    }

    /// <summary>
    /// The type of the Centerpoint calculation. Default: centroid
    /// </summary>
    public PolygonCenterType CenterType
    {
      get { return m_CenterType; }
      set { m_CenterType = value; }
    }

    /// <summary>
    /// The Type of the Polygon. Defines whether a Polygon is an obstacle.
    /// </summary>
    public PolygonType Type
    {
      get { return m_Type; }
      set { m_Type = value; }
    }

    /// <summary>
    /// First Point of the Polygon
    /// </summary>
    public Vertex Vertex0
    {
      get { return m_Vertex0; }
      set { m_Vertex0 = value; }
    }

    /// <summary>
    /// Second Point of the Polygon
    /// </summary>
    public Vertex Vertex1
    {
      get { return m_Vertex1; }
      set { m_Vertex1 = value; }
    }

    /// <summary>
    /// Third Point of the Polygon
    /// </summary>
    public Vertex Vertex2
    {
      get { return m_Vertex2; }
      set { m_Vertex2 = value; }
    }

    public Polygon()
    {
      id = s_IdCounter++;

      m_Neighbors = new List<Polygon>();

      m_Vertex0 = new Vertex();
      m_Vertex1 = new Vertex();
      m_Vertex2 = new Vertex();

      m_CenterType = PolygonCenterType.centroid;
      m_Type = PolygonType.normal;
    }

    public Polygon(Vertex v1, Vertex v2, Vertex v3)
      :this()
    {
      m_Vertex0 = v1;
      m_Vertex1 = v2;
      m_Vertex2 = v3;
    }

    /// <summary>
    /// determines whether the given Point is inside of the Polygon-Region
    /// </summary>
    /// <param name="p">the Point which is to be searched</param>
    /// <returns>Returns true if the Point is inside</returns>
    public bool Contains(Point p)
    {
      bool result = false;

      Point p0 = Vertex0.Position;
      Point p1 = Vertex1.Position;
      Point p2 = Vertex2.Position;

      GraphicsPath data = new GraphicsPath(FillMode.Winding);
      data.AddPolygon(new Point[] {p0, p1, p2});
      Region r = new Region(data);

      result = r.IsVisible(p);

      return result;
    }

    /// <summary>
    /// compares 2 Polygons (same Vertices). 
    /// Alternative: just compare the IDs.
    /// </summary>
    /// <param name="obj">the other Polygon</param>
    /// <returns>Returns true when the object are the same</returns>
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
      
      if (p1.m_Vertex0 == p2.m_Vertex0
        && p1.m_Vertex1 == p2.m_Vertex1
        && p1.m_Vertex2 == p2.m_Vertex2)
      {
        result = true;
      }

      return result;
    }

    /// <summary>
    /// Calculates a centerpoint from current Algorithm
    /// </summary>
    /// <returns>The CenterPoint</returns>
    public Point GetCenter()
    {
      Point result;

      Point v0 = m_Vertex0.Position;
      Point v1 = m_Vertex1.Position;
      Point v2 = m_Vertex2.Position;

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

    /// <summary>
    /// updates List of surrounding Neighbors
    /// </summary>
    public void RefreshNeigbors()
    {
      List<Polygon> tempList = new List<Polygon>();
      if (m_Vertex0 != null)
      {
        foreach (Polygon p in m_Vertex0.CurrentPolygonList)
        {
          if (!tempList.Contains(p))
          {
            tempList.Add(p);
          }
        }
      }

      if (m_Vertex1 != null)
      {
        foreach (Polygon p in m_Vertex1.CurrentPolygonList)
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

      if (m_Vertex2 != null)
      {
        foreach (Polygon p in m_Vertex2.CurrentPolygonList)
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

    /// <summary>
    /// Calculatses Distance between Polygons. (using current center calculation algorithm)
    /// </summary>
    /// <param name="that">The other Polygon</param>
    /// <returns>the Distance between the Polygons</returns>
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
