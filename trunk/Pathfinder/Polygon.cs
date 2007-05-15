using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pathfinder
{
  public class Polygon
  {
    private Vertice m_Vertice0;
    private Vertice m_Vertice1;
    private Vertice m_Vertice2;

    public Vertice Vertice0
    {
      get { return m_Vertice0; }
      set { m_Vertice0 = value; }
    }

    public Vertice Vertice1
    {
      get { return m_Vertice1; }
      set { m_Vertice1 = value; }
    }

    public Vertice Vertice2
    {
      get { return m_Vertice2; }
      set { m_Vertice2 = value; }
    }

    public Polygon()
    {
      m_Vertice0 = new Vertice();
      m_Vertice1 = new Vertice();
      m_Vertice2 = new Vertice();
    }

    public Polygon(Vertice v1, Vertice v2, Vertice v3)
      :this()
    {
      m_Vertice0 = v1;
      m_Vertice1 = v2;
      m_Vertice2 = v3;
    }
  }
}
