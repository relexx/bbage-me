using System;
using System.Collections.Generic;
using System.Text;
using SpriteCraft;

namespace Game
{
  public class Mouse : IOnUpdate
  {
    private ISprite m_Cursor;
    private MainForm m_Parent;

    public Mouse(ISprite mousesprite, int srcwidth, int srcheight, MainForm parent)
    {
      m_Cursor = mousesprite;
      m_Parent = parent;

      m_Cursor.frno = 1;
      m_Cursor.hotspot = tagHotspot.HotspotLeftTop;
      m_Cursor.subimpl = this;
      m_Cursor.x = srcwidth / 2 + 200;
      m_Cursor.y = srcheight - m_Cursor.height;
    }

    #region IOnUpdate Members

    public void OnUpdate(ISprite sprite, int tickdelta)
    {
      if (m_Parent.MouseIn)
      {
        m_Cursor.visible = true;
        m_Cursor.x = m_Parent.MouseX;
        m_Cursor.y = m_Parent.MouseY;
      }
      else
      {
        m_Cursor.visible = false;
      }
    }

    #endregion
  }
}
