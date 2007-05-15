using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  public class PolygonManager
  {
    private List<Vertice> m_VerticeList;
    private List<Polygon> m_PolygonList;

    public List<Polygon> PolygonList
    {
      get { return m_PolygonList; }
      set { m_PolygonList = value; }
    }

    public List<Vertice> VerticeList
    {
      get { return m_VerticeList; }
      set { m_VerticeList = value; }
    }

    public PolygonManager()
    {
      m_VerticeList = new List<Vertice>();
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

      Vertice v01 = new Vertice(new Point( 2, 1 ));
      Vertice v02 = new Vertice(new Point(11, 2 ));
      Vertice v03 = new Vertice(new Point( 2, 5 ));

      Vertice v04 = new Vertice(new Point(20, 5 ));
      Vertice v05 = new Vertice(new Point(11, 7 ));
      Vertice v06 = new Vertice(new Point(17, 10));

      Vertice v07 = new Vertice(new Point( 4, 11));
      Vertice v08 = new Vertice(new Point( 7, 13));
      Vertice v09 = new Vertice(new Point(19, 14));

      Vertice v10 = new Vertice(new Point(13, 16));
      Vertice v11 = new Vertice(new Point(22, 17));
      Vertice v12 = new Vertice(new Point( 3, 18));
      
      p01.Vertice0 = v01;
      p01.Vertice1 = v02;
      p01.Vertice2 = v03;
      v01.PolygonList.Add(p01);
      v02.PolygonList.Add(p01);
      v03.PolygonList.Add(p01);

      p02.Vertice0 = v02;
      p02.Vertice1 = v03;
      p02.Vertice2 = v04;
      v02.PolygonList.Add(p02);
      v03.PolygonList.Add(p02);
      v04.PolygonList.Add(p02);

      p03.Vertice0 = v03;
      p03.Vertice1 = v04;
      p03.Vertice2 = v05;
      v03.PolygonList.Add(p03);
      v04.PolygonList.Add(p03);
      v05.PolygonList.Add(p03);

      p04.Vertice0 = v04;
      p04.Vertice1 = v05;
      p04.Vertice2 = v06;
      v04.PolygonList.Add(p04);
      v05.PolygonList.Add(p04);
      v06.PolygonList.Add(p04);

      p05.Vertice0 = v03;
      p05.Vertice1 = v05;
      p05.Vertice2 = v07;
      v03.PolygonList.Add(p05);
      v05.PolygonList.Add(p05);
      v07.PolygonList.Add(p05);

      p06.Vertice0 = v05;
      p06.Vertice1 = v06;
      p06.Vertice2 = v07;
      v05.PolygonList.Add(p06);
      v06.PolygonList.Add(p06);
      v07.PolygonList.Add(p06);

      p07.Vertice0 = v06;
      p07.Vertice1 = v07;
      p07.Vertice2 = v08;
      v06.PolygonList.Add(p07);
      v07.PolygonList.Add(p07);
      v08.PolygonList.Add(p07);

      p08.Vertice0 = v06;
      p08.Vertice1 = v08;
      p08.Vertice2 = v09;
      v06.PolygonList.Add(p08);
      v08.PolygonList.Add(p08);
      v09.PolygonList.Add(p08);

      p09.Vertice0 = v07;
      p09.Vertice1 = v08;
      p09.Vertice2 = v12;
      v07.PolygonList.Add(p09);
      v08.PolygonList.Add(p09);
      v12.PolygonList.Add(p09);

      p10.Vertice0 = v08;
      p10.Vertice1 = v09;
      p10.Vertice2 = v10;
      v08.PolygonList.Add(p10);
      v09.PolygonList.Add(p10);
      v10.PolygonList.Add(p10);

      p11.Vertice0 = v08;
      p11.Vertice1 = v10;
      p11.Vertice2 = v12;
      v08.PolygonList.Add(p11);
      v10.PolygonList.Add(p11);
      v12.PolygonList.Add(p11);

      p12.Vertice0 = v09;
      p12.Vertice1 = v10;
      p12.Vertice2 = v11;
      v09.PolygonList.Add(p12);
      v10.PolygonList.Add(p12);
      v11.PolygonList.Add(p12);

      p13.Vertice0 = v10;
      p13.Vertice1 = v11;
      p13.Vertice2 = v12;
      v10.PolygonList.Add(p13);
      v11.PolygonList.Add(p13);
      v12.PolygonList.Add(p13);

      m_PolygonList.Add(p01);
      m_PolygonList.Add(p02);
      m_PolygonList.Add(p03);
      m_PolygonList.Add(p04);
      m_PolygonList.Add(p05);
      m_PolygonList.Add(p06);
      m_PolygonList.Add(p07);
      m_PolygonList.Add(p08);
      m_PolygonList.Add(p08);
      m_PolygonList.Add(p10);
      m_PolygonList.Add(p11);
      m_PolygonList.Add(p12);
      m_PolygonList.Add(p13);

      m_VerticeList.Add(v01);
      m_VerticeList.Add(v02);
      m_VerticeList.Add(v03);
      m_VerticeList.Add(v04);
      m_VerticeList.Add(v05);
      m_VerticeList.Add(v06);
      m_VerticeList.Add(v07);
      m_VerticeList.Add(v08);
      m_VerticeList.Add(v08);
      m_VerticeList.Add(v10);
      m_VerticeList.Add(v11);
      m_VerticeList.Add(v12);
    }

    public void AutoAddPointList(Point[] points)
    {
      AutoAddPointList(new List<Point>(points));
    }
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
