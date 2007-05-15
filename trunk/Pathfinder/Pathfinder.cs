using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  public class Pathfinder
  {
    private PolygonManager m_PolygonManager;
    
    public Pathfinder()
    {
      m_PolygonManager = new PolygonManager();
    }

    public Point[] FindPath(Point source, Point destination)
    {
      List<Point> result = new List<Point>();

      //doit

      return result.ToArray();
    }
  }
}
