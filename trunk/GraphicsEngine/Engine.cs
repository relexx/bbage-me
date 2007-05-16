using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphicsEngine
{
  public interface Engine
  {
    /// <summary>
    /// Function used to Draw a Line
    /// </summary>
    /// <param name="pen">the Color to draw with</param>
    /// <param name="pt1">Startpoint </param>
    /// <param name="pt2">Endpoint</param>
    void DrawLine(Color pen, Point pt1, Point pt2);
    void Render();
    bool Created();
  }
}
