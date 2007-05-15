using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  public class Vertice
  {
    private Point m_Position;
    private List<Polygon> m_PolygonList;

    public Point Position
    {
      get { return m_Position; }
      set { m_Position = value; }
    }

    public List<Polygon> PolygonList
    {
      get { return m_PolygonList; }
      set { m_PolygonList = value; }
    }

    public Vertice()
    {
      m_Position = Point.Empty;
      m_PolygonList = new List<Polygon>();
    }
    public Vertice(Point p)
      :this()
    {
      m_Position = p;
    }
  }
}
