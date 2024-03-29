using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  /// <summary>
  /// An implementation of the A* Algorithm
  /// </summary>
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

    /// <summary>
    /// Finds a short Path between 2 given Polygons
    /// </summary>
    /// <param name="src">the Source Polygon</param>
    /// <param name="dst">the Destination Polygon</param>
    /// <returns>A List of PathEntries which, if possible, contain a short Path</returns>
    public List<PathEntry> FindPath(Polygon src, Polygon dst)
    {
      List<PathEntry> result = new List<PathEntry>();
      List<PathEntry> openlist = new List<PathEntry>();
      List<PathEntry> closedlist = new List<PathEntry>();

      //result = new List<Polygon>( new Polygon[] { m_PolygonManager.PolygonList[0], m_PolygonManager.PolygonList[1], m_PolygonManager.PolygonList[2], m_PolygonManager.PolygonList[3], m_PolygonManager.PolygonList[4] });
      PathEntry SrcEntry = new PathEntry(src, null, CalculateHeuristic(src, dst));
      closedlist.Add(SrcEntry);
      src.RefreshNeigbors();

      foreach (Polygon neighbor in src.Neighbors)
      {
        if (neighbor.Type == PolygonType.normal)
        {
          if (!PolygonIsInList(closedlist, neighbor))
          {
            openlist.Add(new PathEntry(neighbor, SrcEntry, CalculateHeuristic(neighbor, dst)));
          }
        }
      }

      // get lowest OverallCost Value
      PathEntry lowestEntry = null;
      do
      {
        lowestEntry = null;
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
          openlist.Remove(lowestEntry);
          closedlist.Add(lowestEntry);

          lowestEntry.EntryPolygon.RefreshNeigbors();
          foreach (Polygon neighbor in lowestEntry.EntryPolygon.Neighbors)
          {
            if (neighbor.Type == PolygonType.normal)
            {
              bool isInOpenList = true;
              bool isInClosedList = true;
              PathEntry alreadyExistingEntryInOpenList;
              isInOpenList = PolygonIsInList(openlist, neighbor, out alreadyExistingEntryInOpenList);
              isInClosedList = PolygonIsInList(closedlist, neighbor);

              if (!isInOpenList && !isInClosedList)
              {
                openlist.Add(new PathEntry(neighbor, lowestEntry, CalculateHeuristic(neighbor, dst)));
              }
              else if (isInOpenList)
              {
                int costToNeighbor = neighbor.Distance(lowestEntry.EntryPolygon) + lowestEntry.Cost;
                if (costToNeighbor < alreadyExistingEntryInOpenList.Cost
                  && !IsPredecessorOf(alreadyExistingEntryInOpenList, lowestEntry))
                {
                  alreadyExistingEntryInOpenList.Predecessor = lowestEntry;
                }
              }
            }
          }
        }
      }
      while (lowestEntry != null && lowestEntry.EntryPolygon != dst);

      PathEntry lastEntry = closedlist[closedlist.Count - 1];
      if (lastEntry.EntryPolygon == dst)
      {
        result.Add(lastEntry);
        PathEntry predecessor = lastEntry.Predecessor;
        while (predecessor != null)
        {
          if (result.Contains(predecessor)) { break; }
          result.Add(predecessor);
          predecessor = predecessor.Predecessor;
        }
        result.Reverse();
      }
      else
      {
        //Path not Found
      }

      return result;
    }

    private bool IsPredecessorOf(PathEntry p1, PathEntry p2)
    {
      bool result = false;

      if (p1 == null) { return false; }
      if (p2 == null) { return false; }
      if (p1 == p2) { return false; }

      PathEntry predecessor = p2.Predecessor;
      while (predecessor != null)
      {
        if (p1 == predecessor)
        {
          result = true;
          break;
        }
        predecessor = predecessor.Predecessor;
      }

      return result;
    }
    private bool PolygonIsInList(List<PathEntry> list, Polygon entry)
    {
      PathEntry foundentry;
      return PolygonIsInList(list, entry, out foundentry);
    }
    private bool PolygonIsInList(List<PathEntry> list, Polygon entry, out PathEntry foundentry)
    {
      bool result = false;
      foundentry = null;

      if (entry != null)
      {
        foreach (PathEntry pe in list)
        {
          if (pe.EntryPolygon == entry)
          {
            foundentry = pe;
            result = true;
            break;
          }
        }
      }

      return result;
    }

    private int CalculateHeuristic(Polygon src, Polygon dst)
    {
      int result = 0;

      result = src.Distance(dst); //TODO: use a better algorithm for heuristic. see http://www.policyalmanac.org/games/heuristics.htm

      return result;
    }
  }

  /// <summary>
  /// A single Point on the found Path
  /// </summary>
  public class PathEntry
  {
    private int m_HeuristicCost;
    private Polygon m_EntryPolygon;
    private PathEntry m_Predecessor;

    public int ID
    {
      get
      {
        int id = -1;
        if (m_EntryPolygon != null)
        {
          id = m_EntryPolygon.ID;
        }
        return id;
      }
    }

    /// <summary>
    /// The Cost to get to this Point from the Source
    /// </summary>
    public int Cost
    {
      get
      {
        int result = -1;
        if (m_Predecessor != null)
        {
          result = m_EntryPolygon.Distance(m_Predecessor.EntryPolygon) + m_Predecessor.Cost;
        }
        return result;
      }
    }

    /// <summary>
    /// The approximated distance to the destination.
    /// </summary>
    public int HeuristicCost
    {
      get { return m_HeuristicCost; }
      set { m_HeuristicCost = value; }
    }

    /// <summary>
    /// the actual Polygon
    /// </summary>
    public Polygon EntryPolygon
    {
      get { return m_EntryPolygon; }
      set { m_EntryPolygon = value; }
    }

    /// <summary>
    /// the Polygon lying on the Path before this one
    /// </summary>
    public PathEntry Predecessor
    {
      get { return m_Predecessor; }
      set { m_Predecessor = value; }
    }

    /// <summary>
    /// Cost + Heuristic Cost
    /// </summary>
    public int OverallCost
    {
      get
      {
        return Cost + m_HeuristicCost;
      }
    }

    public PathEntry(Polygon entrypolygon, PathEntry predecessor, int heuristiccost)
    {
      m_EntryPolygon = entrypolygon;
      m_HeuristicCost = heuristiccost;
      m_Predecessor = predecessor;
    }
  }
}
