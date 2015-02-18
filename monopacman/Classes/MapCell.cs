using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace monopacman
{
    /// <summary>
    /// This is the MapCell class which functions as a part of the map.
    /// </summary>
    class MapCell
    {
        public int TileID { get; set; }

        public MapCell(int tileID)
        {
            TileID = tileID;
        }
    }
}
