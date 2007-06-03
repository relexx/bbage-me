using System;
using System.Collections.Generic;
using System.Text;
using SpriteCraft;

namespace Game
{
  public class Character : IOnUpdate
  {
    private const double WALKING_SPEED = 250;
    private const double WALKING_TOLERANCE = 8;
    private const int DEFAULT_FRAME_NUMBER = 36;
    private double m_Walkto_X;
    private double m_Walkto_Y;
    private int m_Frame_Skipping;
    private int m_LeftRight;
    private int m_UpDown;
    private ISprite m_Character;

    public int Frame_Skipping
    {
      get { return m_Frame_Skipping; }
      set { m_Frame_Skipping = value; }
    }

    public double Walkto_X
    {
      get { return m_Walkto_X; }
      set { m_Walkto_X = value; }
    }

    public double Walkto_Y
    {
      get { return m_Walkto_Y; }
      set { m_Walkto_Y = value; }
    }

    public Character(ISprite charactersprite, int srcwidth, int srcheight)
    {
      m_Frame_Skipping = 0;
      m_LeftRight = 0;
      m_UpDown = 0;

      m_Character = charactersprite;
      m_Character.frno = DEFAULT_FRAME_NUMBER;
      m_Character.subimpl = this;
      m_Character.x = srcwidth / 2 + 200;
      m_Character.y = srcheight - m_Character.height;

      m_Walkto_X = m_Character.x;
      m_Walkto_Y = m_Character.y;
    }

    public void UpdateWalkingDirection()
    {
      string output = "";
      double adjacent = m_Character.y - m_Walkto_Y;
      double oposite = m_Character.x - m_Walkto_X;
      adjacent = adjacent == 0 ? 0.1 : adjacent;
      double angle = Math.Abs(Math.Atan(adjacent / oposite) * 180 / Math.PI);

      output += "adjacent: " + (m_Walkto_Y - m_Character.y);
      output += "oposite: " + (m_Walkto_X - m_Character.x);
      output += " angle: " + angle;

      if (false) {}
      else if (oposite < 0 && adjacent < 0)
      {
        output += " -- 180 -- ";
        angle += 180;
      }
      else if (oposite > 0 && adjacent < 0)
      {
        output += " -- 270 -- ";
        angle += 270;
      }
      else if (oposite < 0 && adjacent > 0)
      {
        output += " -- 90 -- ";
        angle += 90;
      }
      else if (oposite > 0 && adjacent > 0)
      {
        output += " -- 0 -- ";
        angle += 0;
      }

      output += " offset+angle: " + angle;

      m_Character.frno = DEFAULT_FRAME_NUMBER;


      if (false) { }
      else if (angle >= 337.5 && angle < 360 || angle >= 0 && angle < 22.5) // W
      {output += " --> W <-- ";
        m_Character.frno += 0;
      }
      else if (angle >= 152.5 && angle < 202.5) // O
      {output += " --> O <-- ";
        m_Character.frno += 1;
      }
      //else if (angle >= 247.5 && angle < 292.5) // N
      else if (angle >= 67.5 && angle < 112.5) // N
      {output += " --> N <-- ";
        m_Character.frno += 2;
      }
      //else if (angle >= 292.5 && angle < 337.5) // NO
      else if (angle >= 112.5 && angle < 157.5) // NO
      {output += " --> NO <-- ";
        m_Character.frno += 3;
      }
      //else if (angle >= 202.5 && angle < 247.5) // NW
      else if (angle >= 22.5 && angle < 67.5) // NW
      {output += " --> NW <-- ";
        m_Character.frno += 4;
      }
      //else if (angle >= 67.5 && angle < 112.5) // S
      else if (angle >= 247.5 && angle < 292.5) // S
      {output += " --> S <-- ";
        m_Character.frno += 5;
      }
      //else if (angle >= 112.5 && angle < 157.5) // SW
      else if (angle >= 292.5 && angle < 337.5) // SW
      {output += " --> SW <-- ";
        m_Character.frno += 7;
      }
      //else if (angle >= 22.5 && angle < 67.5) // SO
      else if (angle >= 202.5 && angle < 247.5) // SO
      {output += " --> SO <-- ";
        m_Character.frno += 6;
      }
      else
      { output += " --> ??? <-- "; }

      /*
      if (false) { }
      else if (m_LeftRight < 0 && m_UpDown == 0) // W
      {
        m_Character.frno += 0;
      }
      else if (m_LeftRight > 0 && m_UpDown == 0) // O
      {
        m_Character.frno += 1;
      }
      else if (m_LeftRight == 0 && m_UpDown < 0) // N
      {
        m_Character.frno += 2;
      }
      else if (m_LeftRight > 0 && m_UpDown < 0) // NO
      {
        m_Character.frno += 3;
      }
      else if (m_LeftRight < 0 && m_UpDown < 0) // NW
      {
        m_Character.frno += 4;
      }
      else if (m_LeftRight == 0 && m_UpDown > 0) // S
      {
        m_Character.frno += 5;
      }
      else if (m_LeftRight < 0 && m_UpDown > 0) // SW
      {
        m_Character.frno += 6;
      }
      else if (m_LeftRight > 0 && m_UpDown > 0) // SO
      {
        m_Character.frno += 7;
      }
      */

      System.Diagnostics.Debug.WriteLine(output);
    }

    private void ComputeLeftRight()
    {
    }

    #region IOnUpdate Members

    public void OnUpdate(ISprite sprite, int tickdelta)
    {
      m_Character.visible = true;

      // Differenzen berechnen
      double xDiff = Math.Abs(m_Walkto_X - m_Character.x);
      double yDiff = Math.Abs(m_Walkto_Y - m_Character.y);

      // Restliche Strecke berechnen (Pythagoras)
      double dblRemain = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
      double dblStep = 0;
      // Falls noch Weg zurückgelegt werden muss
      if (dblRemain > (WALKING_TOLERANCE))
      {
        dblStep = ((WALKING_SPEED * tickdelta) / 1000.0);
        m_Character.x = (float)(m_Character.x + ((dblStep * xDiff) / dblRemain) * m_LeftRight);
        m_Character.y = (float)(m_Character.y + ((dblStep * yDiff) / dblRemain) * m_UpDown);
      }

      // Defining current speed directions.
      m_LeftRight = 0;
      m_UpDown = 0;

      // We're using default key mapping rules (see the key definitions above).
      if (m_Walkto_X < m_Character.x) { m_LeftRight = -1; }
      if (m_Walkto_X > m_Character.x) { m_LeftRight = 1; }
      if (m_Walkto_Y < m_Character.y) { m_UpDown = -1; }
      if (m_Walkto_Y > m_Character.y) { m_UpDown = 1; }
      if (Math.Abs(m_Walkto_X - m_Character.x) < (tickdelta / 10)) { m_LeftRight = 0; }
      if (Math.Abs(m_Walkto_Y - m_Character.y) < (tickdelta / 10)) { m_UpDown = 0; }
      if (dblRemain < WALKING_TOLERANCE) { m_UpDown = 0; m_LeftRight = 0; }
    }

    #endregion
  }
}
