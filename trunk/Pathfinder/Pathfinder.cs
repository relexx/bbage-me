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
      PathEntry SrcEntry = new PathEntry(src, null, CalculateHeuristic(src, dst));
      closedlist.Add(SrcEntry);

      foreach (Polygon neighbor in src.Neighbors)
      {
        if (neighbor.Type == PolygonType.normal)
        {
          openlist.Add(new PathEntry(neighbor, SrcEntry, CalculateHeuristic(neighbor, dst)));
        }
      }

      // get lowest OverallCost Value
      PathEntry lowestEntry = null;
      foreach (PathEntry entry in openlist)
      {
        if (lowestEntry == null)
        {
          lowestEntry = entry;
        }
        else if (entry.OverallCost < lowestEntry.OverallCost)
        {
          lowestEntry = entry;
        }
      }

      if (lowestEntry != null)
      {
        foreach (Polygon neighbor in lowestEntry.EntryPolygon.Neighbors)
        {
          if (neighbor.Type == PolygonType.normal)
          {
            bool containsNeighbor = false;
            foreach (PathEntry pe in openlist)
            {
              if (pe.EntryPolygon == neighbor)
              {
                containsNeighbor = true;
                break;
              }
            }
            if (!containsNeighbor)
            {
              openlist.Add(new PathEntry(neighbor, lowestEntry, CalculateHeuristic(neighbor, dst)));
            }
            else
            {
              //int costToNeighbor = neighbor.Distance(
              /* check to see if this path to that square is a better one. In other words, check to see if the G score for that square is lower if we use the current square to get there. If not, don’t do anything. 
    On the other hand, if the G cost of the new path is lower, change the parent of the adjacent square to the selected square (in the diagram above, change the direction of the pointer to point at the selected square). Finally, recalculate both the F and G scores of that square. If this seems confusing, you will see it illustrated below.*/
            }
          }
        }
      }

      return result.ToArray();
    }

    private int CalculateHeuristic(Polygon src, Polygon dst)
    {
      int result = 0;

      result = src.Distance(dst); //TODO: use a better algorithm for heuristic. see http://www.policyalmanac.org/games/heuristics.htm

      return result;
    }

    private class PathEntry
    {
      private int m_CostFromLastEntry;
      private int m_HeuristicCost;
      private Polygon m_EntryPolygon;
      private PathEntry m_Predecessor;

      public int CostFromLastEntry
      {
        get { return m_CostFromLastEntry; }
        set { m_CostFromLastEntry = value; }
      }

      public int HeuristicCost
      {
        get { return m_HeuristicCost; }
        set { m_HeuristicCost = value; }
      }

      public Polygon EntryPolygon
      {
        get { return m_EntryPolygon; }
        set { m_EntryPolygon = value; }
      }

      public PathEntry Predecessor
      {
        get { return m_Predecessor; }
        set { m_Predecessor = value; }
      }

      public int OverallCost
      {
        get
        {
          return m_CostFromLastEntry + m_HeuristicCost;
        }
      }

      public PathEntry(Polygon entrypolygon, PathEntry predecessor, int heuristiccost)
      {
        m_EntryPolygon = entrypolygon;
        m_HeuristicCost = heuristiccost;
        m_Predecessor = predecessor;
        CalculateCost();
      }

      private void CalculateCost()
      {
        if (m_Predecessor != null)
        {
          m_CostFromLastEntry = m_EntryPolygon.Distance(m_Predecessor.EntryPolygon);

          PathEntry prePredecessor = m_Predecessor.Predecessor;
          while (prePredecessor != null)
          {
            m_CostFromLastEntry += prePredecessor.m_CostFromLastEntry;
            prePredecessor = prePredecessor.m_Predecessor;
          }
        }
        else
	      {
          m_CostFromLastEntry = 0;
        }
      }
    }
  }
}
