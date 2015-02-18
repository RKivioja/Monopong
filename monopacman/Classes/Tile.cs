using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monopacman
{
    /// <summary>
    /// A small class which holds the properties for each tile in the game.
    /// </summary>
    static class Tile
    {
        static public Texture2D TileSetTexture;

        /// <summary>
        /// Returns the borders of the Tile in the spesific index.
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <returns></returns>
        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            return new Rectangle(tileIndex * 32, 0, 32, 32);
        }
    }
}
