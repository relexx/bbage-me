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
    /// Searches for the Vertex at the given point
    /// </summary>
    /// <param name="pos">the Point at which position the Vertex should be</param>
    /// <returns>null if not found</returns>
    public Vertex FindVertex(Point pos)
    {
      Vertex result = null;

      foreach (Vertex vert in m_VertexList)
      {
        if (vert.Position.Equals(pos))
        {
          result = vert;
          break;
        }
      }

      return result;
    }

    /// <summary>
    /// Builds Polygons from a Rectangle
    /// </summary>
    /// <param name="rect">the Rectangle</param>
    /// <param name="type">the Type of the Polygons</param>
    /// <param name="polygons">the number of Polygons min 2</param>
    public void AddRectangle(Rectangle rect, PolygonType type, int polygons)
    {
      //the 4 corners
      Vertex va = new Vertex(new Point(rect.X, rect.Y));
      Vertex vb = new Vertex(new Point(rect.X + rect.Width, rect.Y));
      Vertex vc = new Vertex(new Point(rect.X, rect.Y + rect.Height));
      Vertex vd = new Vertex(new Point(rect.X + rect.Width, rect.Y + rect.Height));
      Polygon p1 = new Polygon(va, vc, vd);
      Polygon p2 = new Polygon(va, vb, vd);
      p1.Type = type;
      p2.Type = type;
      va.CurrentPolygonList.Add(p1);
      vc.CurrentPolygonList.Add(p1);
      vd.CurrentPolygonList.Add(p1);
      va.CurrentPolygonList.Add(p2);
      vb.CurrentPolygonList.Add(p2);
      vd.CurrentPolygonList.Add(p2);
      m_PolygonList.Add(p1);
      m_PolygonList.Add(p2);
      m_VertexList.Add(va);
      m_VertexList.Add(vb);
      m_VertexList.Add(vc);
      m_VertexList.Add(vd);

      polygons -= 2;

      // 2
      Queue<Polygon> templist = new Queue<Polygon>();
      templist.Enqueue(p1);
      templist.Enqueue(p2);
      while (polygons > 0)
      {
        Polygon p = templist.Dequeue();

        Polygon p_new;
        Vertex v_new;
        SplitPolygon(p, out p_new, out v_new);
        p_new.Type = type;
        m_PolygonList.Add(p_new);
        m_VertexList.Add(v_new);

        templist.Enqueue(p_new);
        templist.Enqueue(p);
        polygons -=1;
      }
    }

    public void SplitPolygon(Polygon polygon, out Polygon p_new, out Vertex v_new)
    {
      p_new = null;
      v_new = null;

      if (polygon != null)
      {
        //find longest edge (put them between v1 and v2)
        Vertex v1;
        Vertex v2;
        Vertex v3;

        int d_0_1 = polygon.Vertex0.Distance(polygon.Vertex1);
        int d_1_2 = polygon.Vertex1.Distance(polygon.Vertex2);
        int d_2_0 = polygon.Vertex2.Distance(polygon.Vertex0);

        if (d_0_1 >= d_1_2 && d_0_1 >= d_2_0)
        {
          v1 = polygon.Vertex0;
          v2 = polygon.Vertex1;
          v3 = polygon.Vertex2;
        }
        else if (d_1_2 >= d_0_1 && d_1_2 >= d_2_0)
        {
          v1 = polygon.Vertex1;
          v2 = polygon.Vertex2;
          v3 = polygon.Vertex0;
        }
        else
        {
          v1 = polygon.Vertex2;
          v2 = polygon.Vertex0;
          v3 = polygon.Vertex1;
        }

        //get Point in Middle
        int dx = (v2.Position.X - v1.Position.X) / 2;
        int dy = (v2.Position.Y - v1.Position.Y) / 2;
        Point v_new_pos = new Point(v1.Position.X + dx, v1.Position.Y + dy);
        Vertex v_alreadyExists = FindVertex(v_new_pos);
        if (v_alreadyExists == null)
        {
          v_new = new Vertex(v_new_pos);
        }
        else
        {
          v_new = v_alreadyExists;
        }

        polygon.Vertex0 = v1;
        polygon.Vertex1 = v_new;
        polygon.Vertex2 = v3;
        v_new.CurrentPolygonList.Add(polygon);

        v2.CurrentPolygonList.Remove(polygon);

        p_new = new Polygon(v_new, v2, v3);
        v_new.CurrentPolygonList.Add(p_new);
        v3.CurrentPolygonList.Add(p_new);
        v2.CurrentPolygonList.Add(p_new);
      }
    }
  }
}
