using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsEngine
{
  public class DXEngine : Engine
  {
    private Device m_Display;
    private Surface m_Front;
    private Surface m_Back;
    private Clipper m_Clip;

    private int m_Width;
    private int m_Height;
    private Color m_BackColor;

    private Form m_GraphicTarget;

    public DXEngine()
    {
      m_Width = 200;
      m_Height = 200;
      m_BackColor = Color.White;
      m_GraphicTarget = new Form();
      m_GraphicTarget.Width = m_Width;
      m_GraphicTarget.Height = m_Height;

      m_GraphicTarget.Show();

      InitDirectDraw();
    }

    #region D3DStuff

    public void InitDirectDraw()
    {
      // Used to describe a Surface
      SurfaceDescription description = new SurfaceDescription();
      // Init the Device
      m_Display = new Device();
#if DEBUG
      m_Display.SetCooperativeLevel(m_GraphicTarget, CooperativeLevelFlags.Normal);
#else
    m_Display.SetCooperativeLevel(m_GraphicTarget, CooperativeLevelFlags.FullscreenExclusive);
    m_Display.SetDisplayMode(1280, 1024, 16, 0, false);
#endif

      description.SurfaceCaps.PrimarySurface = true;

#if DEBUG
      m_Front = new Surface(description, m_Display);
#else
    description.SurfaceCaps.Flip = true;
    description.SurfaceCaps.Complex = true;

    // Set the Back Buffer count
    description.BackBufferCount = 1;

    // Create the Surface with specifed description and device)
    front = new Surface(description, display);
#endif

      description.Clear();

#if DEBUG
      description.Width = m_Front.SurfaceDescription.Width;
      description.Height = m_Front.SurfaceDescription.Height;
      description.SurfaceCaps.OffScreenPlain = true;
      m_Back = new Surface(description, m_Display);
      m_Back.ColorFill(Color.White);
#else
    // A Caps is a set of attributes used by most of DirectX components
    SurfaceCaps caps = new SurfaceCaps();
    // Yes, we are using a back buffer
    caps.BackBuffer = true;

    // Associate the front buffer to back buffer with specified caps
    m_Back = front.GetAttachedSurface(caps);
#endif

      // Create the Clipper
      m_Clip = new Clipper(m_Display);
      /// Set the region to this form
      m_Clip.Window = m_GraphicTarget;
      // Set the clipper for the front Surface
      m_Front.Clipper = m_Clip;

      description.Clear();
      description.SurfaceCaps.OffScreenPlain = true;
      description.Width = m_Width;
      description.Height = m_Height;
    }
    private void RestoreSurfaces()
    {
      // Used to describe a Surface
      SurfaceDescription description = new SurfaceDescription();

      // Restore al the surface associed with the device
      m_Display.RestoreAllSurfaces();

      //Redraw
      description.SurfaceCaps.OffScreenPlain = true;
      description.Width = m_Width;
      description.Height = m_Height;

      return;
    }

    #endregion

    #region Engine Members

    public void DrawLine(Color pen, Point pt1, Point pt2)
    {
      m_Back.ForeColor = pen;
      m_Back.DrawLine(pt1.X, pt1.Y, pt2.X, pt2.Y);
    }

    public void Render()
    {
      try
      {
#if DEBUG
        // Draw all this to the front
        m_Front.Draw(new Rectangle(m_GraphicTarget.Location, new Size(m_Back.SurfaceDescription.Width, m_Back.SurfaceDescription.Height)), m_Back, DrawFlags.Wait);
        //front.Draw(back, DrawFlags.Wait);
#else
        // Doing a flip to transfer back buffer to the front, faster
        m_Front.Flip(m_Back, FlipFlags.Wait);
#endif
      }
      catch (Microsoft.DirectX.DirectDraw.WasStillDrawingException)
      {
        // no problem just draw next time
      }
      catch (Microsoft.DirectX.DirectDraw.SurfaceLostException)
      {
        // If we lost the surfaces, restore the surfaces
        RestoreSurfaces();
      }
    }

    public bool Created()
    {
      return m_GraphicTarget.Created;
    }

    #endregion
  }
}
