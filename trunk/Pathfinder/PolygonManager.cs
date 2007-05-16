using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  /// <summary>
  /// Holds and Manages Vertices and Polygon Data
  /// </summary>
  public class PolygonManager
  {
    private List<Vertex> m_VertexList;
    private List<Polygon> m_PolygonList;

    public List<Polygon> PolygonList
    {
      get { return m_PolygonList; }
      set { m_PolygonList = value; }
    }

    public List<Vertex> VertexList
    {
      get { return m_VertexList; }
      set { m_VertexList = value; }
    }

    public PolygonManager()
    {
      m_VertexList = new List<Vertex>();
      m_PolygonList = new List<Polygon>();

      DoTestData();
    }

    /// <summary>
    /// only for testing. Makes default Data.
    /// </summary>
    public void DoTestData()
    {
/* Daten:
00
01  1
02          2
03
04
05  3                4
06
07          5
08
09
10                6
11   7
12
13      8
14                  9
15
16            a
17                     b
18  c
*/

      Polygon p01 = new Polygon();
      Polygon p02 = new Polygon();
      Polygon p03 = new Polygon();
      Polygon p04 = new Polygon();
      Polygon p05 = new Polygon();
      Polygon p06 = new Polygon();
      Polygon p07 = new Polygon();
      Polygon p08 = new Polygon();
      Polygon p09 = new Polygon();
      Polygon p10 = new Polygon();
      Polygon p11 = new Polygon();
      Polygon p12 = new Polygon();
      Polygon p13 = new Polygon();

      Vertex v01 = new Vertex(new Point( 2, 1 ));
      Vertex v02 = new Vertex(new Point(11, 2 ));
      Vertex v03 = new Vertex(new Point( 2, 5 ));

      Vertex v04 = new Vertex(new Point(20, 5 ));
      Vertex v05 = new Vertex(new Point(11, 7 ));
      Vertex v06 = new Vertex(new Point(17, 10));

      Vertex v07 = new Vertex(new Point( 4, 11));
      Vertex v08 = new Vertex(new Point( 7, 13));
      Vertex v09 = new Vertex(new Point(19, 14));

      Vertex v10 = new Vertex(new Point(13, 16));
      Vertex v11 = new Vertex(new Point(22, 17));
      Vertex v12 = new Vertex(new Point( 3, 18));
      
      p01.Vertex0 = v01;
      p01.Vertex1 = v02;
      p01.Vertex2 = v03;
      v01.CurrentPolygonList.Add(p01);
      v02.CurrentPolygonList.Add(p01);
      v03.CurrentPolygonList.Add(p01);

      p02.Vertex0 = v02;
      p02.Vertex1 = v03;
      p02.Vertex2 = v04;
      v02.CurrentPolygonList.Add(p02);
      v03.CurrentPolygonList.Add(p02);
      v04.CurrentPolygonList.Add(p02);

      p03.Vertex0 = v03;
      p03.Vertex1 = v04;
      p03.Vertex2 = v05;
      v03.CurrentPolygonList.Add(p03);
      v04.CurrentPolygonList.Add(p03);
      v05.CurrentPolygonList.Add(p03);

      p04.Vertex0 = v04;
      p04.Vertex1 = v05;
      p04.Vertex2 = v06;
      v04.CurrentPolygonList.Add(p04);
      v05.CurrentPolygonList.Add(p04);
      v06.CurrentPolygonList.Add(p04);

      p05.Vertex0 = v03;
      p05.Vertex1 = v05;
      p05.Vertex2 = v07;
      v03.CurrentPolygonList.Add(p05);
      v05.CurrentPolygonList.Add(p05);
      v07.CurrentPolygonList.Add(p05);

      p06.Vertex0 = v05;
      p06.Vertex1 = v06;
      p06.Vertex2 = v07;
      v05.CurrentPolygonList.Add(p06);
      v06.CurrentPolygonList.Add(p06);
      v07.CurrentPolygonList.Add(p06);

      p07.Vertex0 = v06;
      p07.Vertex1 = v07;
      p07.Vertex2 = v08;
      v06.CurrentPolygonList.Add(p07);
      v07.CurrentPolygonList.Add(p07);
      v08.CurrentPolygonList.Add(p07);

      p08.Vertex0 = v06;
      p08.Vertex1 = v08;
      p08.Vertex2 = v09;
      v06.CurrentPolygonList.Add(p08);
      v08.CurrentPolygonList.Add(p08);
      v09.CurrentPolygonList.Add(p08);

      p09.Vertex0 = v07;
      p09.Vertex1 = v08;
      p09.Vertex2 = v12;
      v07.CurrentPolygonList.Add(p09);
      v08.CurrentPolygonList.Add(p09);
      v12.CurrentPolygonList.Add(p09);

      p10.Vertex0 = v08;
      p10.Vertex1 = v09;
      p10.Vertex2 = v10;
      v08.CurrentPolygonList.Add(p10);
      v09.CurrentPolygonList.Add(p10);
      v10.CurrentPolygonList.Add(p10);

      p11.Vertex0 = v08;
      p11.Vertex1 = v10;
      p11.Vertex2 = v12;
      v08.CurrentPolygonList.Add(p11);
      v10.CurrentPolygonList.Add(p11);
      v12.CurrentPolygonList.Add(p11);

      p12.Vertex0 = v09;
      p12.Vertex1 = v10;
      p12.Vertex2 = v11;
      v09.CurrentPolygonList.Add(p12);
      v10.CurrentPolygonList.Add(p12);
      v11.CurrentPolygonList.Add(p12);

      p13.Vertex0 = v10;
      p13.Vertex1 = v11;
      p13.Vertex2 = v12;
      v10.CurrentPolygonList.Add(p13);
      v11.CurrentPolygonList.Add(p13);
      v12.CurrentPolygonList.Add(p13);

      m_PolygonList.Add(p01);
      m_PolygonList.Add(p02);
      m_PolygonList.Add(p03);
      m_PolygonList.Add(p04);
      m_PolygonList.Add(p05);
      m_PolygonList.Add(p06);
      m_PolygonList.Add(p07);
      m_PolygonList.Add(p08);
      m_PolygonList.Add(p09);
      m_PolygonList.Add(p10);
      m_PolygonList.Add(p11);
      m_PolygonList.Add(p12);
      m_PolygonList.Add(p13);

      m_VertexList.Add(v01);
      m_VertexList.Add(v02);
      m_VertexList.Add(v03);
      m_VertexList.Add(v04);
      m_VertexList.Add(v05);
      m_VertexList.Add(v06);
      m_VertexList.Add(v07);
      m_VertexList.Add(v08);
      m_VertexList.Add(v09);
      m_VertexList.Add(v10);
      m_VertexList.Add(v11);
      m_VertexList.Add(v12);
    }

    /// <summary>
    /// Searches for the Polygon which contains the given point
    /// </summary>
    /// <param name="pos">the Point at which position the polygon should be</param>
    /// <returns>null if not found</returns>
    public Polygon FindPolygon(Point pos)
    {
      Polygon result = null;

      foreach (Polygon poly in m_PolygonList)
      {
        if (poly.Contains(pos))
        {
          result = poly;
          break;
        }
      }

      return result;
    }

    /// <summary>
    /// builds Net from Pointlist
    /// </summary>
    /// <param name="points">the Pointlist</param>
    public void AutoAddPointList(Point[] points)
    {
      AutoAddPointList(new List<Point>(points));
    }
    /// <summary>
    /// builds Net from Pointlist
    /// </summary>
    /// <param name="points">the pointlist</param>
    public void AutoAddPointList(List<Point> points)
    {
      // sort for distance

      // connect each point with each other
      List<Connection> connections = new List<Connection>();
      for (int i = 0; i < points.Count; i++)
      {
        for (int j = 0; j < points.Count; j++)
        {
          Connection con = new Connection(points[i], points[j]);
          if (ConnectionCrosses(connections, con))
          {
            connections.Add(con);
          }
        }
      }
      /*

      // do polygons
      List<Point> tripple = new List<Point>();
      for (int i = 0; i < points.Count; i++)
			{
        tripple.Add(points[i]);
        
        if (tripple.Count >= 3)
        {
          Polygon polygon = new Polygon();
          polygon.Vertice0 = new Vertice(tripple[0], polygon);
          polygon.Vertice1 = new Vertice(tripple[0], polygon);
          polygon.Vertice2 = new Vertice(tripple[0], polygon);

          m_VerticeList.Add(Vertice0);
          m_VerticeList.Add(Vertice1);
          m_VerticeList.Add(Vertice2);
          m_PolygonList.Add(polygon);
        }
      }*/
    }

    private bool ConnectionCrosses(List<Connection> connections, Connection connection)
    {
      bool result = false;

      for (int i = 0; i < connections.Count; i++)
      {
        if (connections[i].Crosses(connection))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    private class Connection
	  {
      private Point m_P1;
      private Point m_P2;

      public Connection(Point p1, Point p2)
      {
        m_P1 = p1;
        m_P2 = p2;
      }

      public bool Crosses(Connection that)
      {
        bool result = false;

        double dx = Math.Abs( this.m_P1.X - that.m_P1.X );
        // 

        return result;
      }
	  }
  }
}
