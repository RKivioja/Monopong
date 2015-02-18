using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace monopacman
{
    /// <summary>
    /// This is the camera class for the game. 
    /// In pacman, there is no need to adjust camera at any point, so this is almost obsolete.
    /// </summary>
    static class Camera
    {
        static public Vector2 Location = Vector2.Zero;
    }
}
