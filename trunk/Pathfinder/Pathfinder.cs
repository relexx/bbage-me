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
    public Pathfinder(PolygonManager manager)
    {
      m_PolygonManager = manager;
    }

    public Polygon[] FindPath(Polygon src, Polygon dst)
    {
      List<Polygon> result = new List<Polygon>();
      List<PathEntry> openlist = new List<PathEntry>();
      List<PathEntry> closedlist = new List<PathEntry>();

      //result = new List<Polygon>( new Polygon[] { m_PolygonManager.PolygonList[0], m_PolygonManager.PolygonList[1], m_PolygonManager.PolygonList[2], m_PolygonManager.PolygonList[3], m_PolygonManager.PolygonList[4] });
      closedlist.Add(new PathEntry(src, src));

      foreach (Polygon neighbor in src.Neighbors)
      {
        openlist.Add(new PathEntry(src, neighbor));
      }

      return result.ToArray();
    }

    private int CalculateHeuristic(Polygon src, Polygon dst)
    {
      int result = 0;
      return result;
    }

    private int CalculateCost(Polygon src, Polygon dst)
    {
      int result = 0;
      return result;
    }

    private class PathEntry
    {
      private int m_CostFromLastEntry;
      private Polygon m_EntryPolygon;
      private Polygon m_Predecessor;

      public int CostFromLastEntry
      {
        get { return m_CostFromLastEntry; }
        set { m_CostFromLastEntry = value; }
      }

      public Polygon EntryPolygon
      {
        get { return m_EntryPolygon; }
        set { m_EntryPolygon = value; }
      }

      public Polygon Predecessor
      {
        get { return m_Predecessor; }
        set { m_Predecessor = value; }
      }

      public PathEntry(Polygon entrypolygon, Polygon predecessor)
      {
        m_EntryPolygon = entrypolygon;
        m_CostFromLastEntry = entrypolygon.Distance(predecessor);
        m_Predecessor = predecessor;
      }
    }
  }
}
