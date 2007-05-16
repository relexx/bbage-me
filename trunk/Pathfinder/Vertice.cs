using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  /// <summary>
  /// A Point-like Stucture. 3 can build 1 Polygon
  /// </summary>
  public class Vertex
  {
    private Point m_Position;
    private List<Polygon> m_PolygonList;

    /// <summary>
    /// The Position of the Vertice
    /// </summary>
    public Point Position
    {
      get { return m_Position; }
      set { m_Position = value; }
    }

    /// <summary>
    /// The List of Polygon which contain this Vertice
    /// </summary>
    public List<Polygon> CurrentPolygonList
    {
      get { return m_PolygonList; }
      set { m_PolygonList = value; }
    }

    public Vertex()
    {
      m_Position = Point.Empty;
      m_PolygonList = new List<Polygon>();
    }

    public Vertex(Point p)
      :this()
    {
      m_Position = p;
    }

    /// <summary>
    /// compares 2 Vertices (same position)
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      bool result = false;
      Vertex v1 = this;
      Vertex v2 = obj as Vertex;

      if (v1 == null && v1 != null
        || v1 != null && v1 == null)
      { return false; }
      else if (v1 == null && v1 == null)
      { return true; }

      if (v1.m_Position == v2.m_Position)
      {
        result = true;
      }

      return result;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }
}
