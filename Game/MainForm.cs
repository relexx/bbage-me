using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpriteCraft;
using Pathfinder;

namespace Game
{
  public class MainForm
  {
    private Engine m_Engine;
    private Character m_Character;
    private Mouse m_Mouse;
    private Pathfinder.Pathfinder m_Pathfinder;
    private PolygonManager m_PolygonManager;

    public int MouseX { get { return m_Engine.mouseX; } }
    public int MouseY { get { return m_Engine.mouseY; } }
    public bool MouseIn { get { return m_Engine.mouseIn; } }

    public MainForm()
    {
      m_Engine = new EngineClass();
      m_PolygonManager = new PolygonManager();
      m_Pathfinder = new Pathfinder.Pathfinder(m_PolygonManager);
      m_PolygonManager.AddRectangle(new Rectangle(Point.Empty, new Size()), PolygonType.normal, 2);
    }

    public void Init()
    {
      m_Engine.logging = true;
      m_Engine.Init(tagScDevice.DevAuto);
      m_Engine.background.color = Color.White.ToArgb();
      m_Engine.SST = "common.sst";
      m_Engine.PlaceWindowAt(tagPosition.PositionCenter);
      m_Engine.showFps = true;

      ISprite characterSprite = m_Engine.NewSprite_("player_character01", 0);
      m_Character = new Character(characterSprite, m_Engine.scrWidth, m_Engine.scrHeight);

      ISprite mouseSprite = m_Engine.NewSprite_("mouse_cursor", 0);
      m_Mouse = new Mouse(mouseSprite, m_Engine.scrWidth, m_Engine.scrHeight, this);
    }

    public void Run()
    {
      while (true)
      {
        if (m_Engine.NextEvent())
        {
          if (m_Engine.EvtIsESC() || m_Engine.EvtIsQuit()) { break; }

          if (m_Engine.EvtIsKeyDown() && m_Engine.EvtKey() == tagKeyVal.Key_F4)
          { m_Engine.fullscreen = !m_Engine.fullscreen; }

          if (m_Engine.mouseLDown)
          {
            m_Character.Walkto_X = m_Engine.mouseX;
            m_Character.Walkto_Y = m_Engine.mouseY;
            m_Character.UpdateWalkingDirection();
          }
        }

        m_Engine.DisplayEx(30);
      }
      m_Engine.Purge();

      m_Engine = null;
    }
  }
}