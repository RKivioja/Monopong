using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace monopacman
{
    /// <summary>
    /// Class for the whole TileMap.
    /// </summary>
    class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        private int MapWidth  = 21;
        private int MapHeight = 21;
        
        /// <summary>
        /// Class declaration.
        /// </summary>
        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }

            // Create Sample Map Data
            //yläreuna
            for (int i = 1; i < 20; i++)
            {
                Rows[0].Columns[i].TileID = 1;
            }
            //vasen reuna
            for (int i = 1; i < 7; i++)
            {
                Rows[i].Columns[1].TileID = 1;
            }
            for (int i = 12; i < 20; i++)
            {
                Rows[i].Columns[1].TileID = 1;
            }
            //oikea reuna
            for (int i = 1; i < 7; i++)
            {
                Rows[i].Columns[19].TileID = 1;
            }
            for (int i = 12; i < 20; i++)
            {
                Rows[i].Columns[19].TileID = 1;
            }
            //alareuna
            for (int i = 1; i < 20; i++)
            {
                Rows[20].Columns[i].TileID = 1;
            }

            //RIVI: 1

            for (int i = 2; i < 10; i++)
            {
                Rows[1].Columns[i].TileID = 2;
            }
            
            Rows[1].Columns[10].TileID = 1;

            for (int i = 11; i < 19; i++)
            {
                Rows[1].Columns[i].TileID = 2;
            }

            //RIVI: 2

            Rows[2].Columns[2].TileID = 3;
            Rows[2].Columns[3].TileID = 1;
            Rows[2].Columns[4].TileID = 1;
            Rows[2].Columns[5].TileID = 2;
            Rows[2].Columns[6].TileID = 1;
            Rows[2].Columns[7].TileID = 1;
            Rows[2].Columns[8].TileID = 1;
            Rows[2].Columns[9].TileID = 2;
            Rows[2].Columns[10].TileID = 1;
            Rows[2].Columns[11].TileID = 2;
            Rows[2].Columns[12].TileID = 1;
            Rows[2].Columns[13].TileID = 1;
            Rows[2].Columns[14].TileID = 1;
            Rows[2].Columns[15].TileID = 2;
            Rows[2].Columns[16].TileID = 1;
            Rows[2].Columns[17].TileID = 1;
            Rows[2].Columns[18].TileID = 3;
            Rows[2].Columns[19].TileID = 1;

            //RIVI: 3

            for (int i = 2; i < 19; i++)
            {
                Rows[3].Columns[i].TileID = 2;
            }

            //RIVI: 4

            Rows[4].Columns[2].TileID = 2;
            Rows[4].Columns[3].TileID = 1;
            Rows[4].Columns[4].TileID = 1;
            Rows[4].Columns[5].TileID = 2;
            Rows[4].Columns[6].TileID = 1;
            Rows[4].Columns[7].TileID = 2;
            Rows[4].Columns[8].TileID = 1;
            Rows[4].Columns[9].TileID = 1;
            Rows[4].Columns[10].TileID = 1;
            Rows[4].Columns[11].TileID = 1;
            Rows[4].Columns[12].TileID = 1;
            Rows[4].Columns[13].TileID = 2;
            Rows[4].Columns[14].TileID = 1;
            Rows[4].Columns[15].TileID = 2;
            Rows[4].Columns[16].TileID = 1;
            Rows[4].Columns[17].TileID = 1;
            Rows[4].Columns[18].TileID = 2;
            Rows[4].Columns[19].TileID = 1;

            //RIVI: 5

            Rows[5].Columns[2].TileID = 2;
            Rows[5].Columns[3].TileID = 2;
            Rows[5].Columns[4].TileID = 2;
            Rows[5].Columns[5].TileID = 2;
            Rows[5].Columns[6].TileID = 1;
            Rows[5].Columns[7].TileID = 2;
            Rows[5].Columns[8].TileID = 2;
            Rows[5].Columns[9].TileID = 2;
            Rows[5].Columns[10].TileID = 1;
            Rows[5].Columns[11].TileID = 2;
            Rows[5].Columns[12].TileID = 2;
            Rows[5].Columns[13].TileID = 2;
            Rows[5].Columns[14].TileID = 1;
            Rows[5].Columns[15].TileID = 2;
            Rows[5].Columns[16].TileID = 2;
            Rows[5].Columns[17].TileID = 2;
            Rows[5].Columns[18].TileID = 2;
            Rows[5].Columns[19].TileID = 1;

            //RIVI: 6
            
            Rows[6].Columns[2].TileID = 1;
            Rows[6].Columns[3].TileID = 1;
            Rows[6].Columns[4].TileID = 1;
            Rows[6].Columns[5].TileID = 2;
            Rows[6].Columns[6].TileID = 1;
            Rows[6].Columns[7].TileID = 1;
            Rows[6].Columns[8].TileID = 1;
            Rows[6].Columns[9].TileID = 2;
            Rows[6].Columns[10].TileID = 1;
            Rows[6].Columns[11].TileID = 2;
            Rows[6].Columns[12].TileID = 1;
            Rows[6].Columns[13].TileID = 1;
            Rows[6].Columns[14].TileID = 1;
            Rows[6].Columns[15].TileID = 2;
            Rows[6].Columns[16].TileID = 1;
            Rows[6].Columns[17].TileID = 1;
            Rows[6].Columns[18].TileID = 1;
            Rows[6].Columns[19].TileID = 1;

            //RIVI: 7

            Rows[7].Columns[4].TileID = 1;
            Rows[7].Columns[5].TileID = 2;
            Rows[7].Columns[6].TileID = 1;
            Rows[7].Columns[14].TileID = 1;
            Rows[7].Columns[15].TileID = 2;
            Rows[7].Columns[16].TileID = 1;

            //RIVI: 8

            Rows[8].Columns[0].TileID = 1;
            Rows[8].Columns[1].TileID = 1;
            Rows[8].Columns[2].TileID = 1;
            Rows[8].Columns[3].TileID = 1;
            Rows[8].Columns[4].TileID = 1;
            Rows[8].Columns[5].TileID = 2;
            Rows[8].Columns[6].TileID = 1;

            Rows[8].Columns[8].TileID = 1;
            Rows[8].Columns[9].TileID = 1;
            Rows[8].Columns[11].TileID = 1;
            Rows[8].Columns[12].TileID = 1;

            Rows[8].Columns[14].TileID = 1;
            Rows[8].Columns[15].TileID = 2;
            Rows[8].Columns[16].TileID = 1;
            Rows[8].Columns[17].TileID = 1;
            Rows[8].Columns[18].TileID = 1;
            Rows[8].Columns[19].TileID = 1;
            Rows[8].Columns[20].TileID = 1;
            //------------------------------------------------------------------

            //RIVI: 9

            Rows[9].Columns[5].TileID = 2;
            Rows[9].Columns[8].TileID = 1;
            Rows[9].Columns[12].TileID = 1;
            Rows[9].Columns[15].TileID = 2;

            //------------------------------------------------------------------

            //RIVI: 10

            Rows[10].Columns[0].TileID = 1;
            Rows[10].Columns[1].TileID = 1;
            Rows[10].Columns[2].TileID = 1;
            Rows[10].Columns[3].TileID = 1;
            Rows[10].Columns[4].TileID = 1;
            Rows[10].Columns[5].TileID = 2;
            Rows[10].Columns[6].TileID = 1;

            Rows[10].Columns[8].TileID = 1;
            Rows[10].Columns[9].TileID = 1;
            Rows[10].Columns[10].TileID = 1;
            Rows[10].Columns[11].TileID = 1;
            Rows[10].Columns[12].TileID = 1;

            Rows[10].Columns[14].TileID = 1;
            Rows[10].Columns[15].TileID = 2;
            Rows[10].Columns[16].TileID = 1;
            Rows[10].Columns[17].TileID = 1;
            Rows[10].Columns[18].TileID = 1;
            Rows[10].Columns[19].TileID = 1;
            Rows[10].Columns[20].TileID = 1;

            //RIVI: 11

            Rows[11].Columns[4].TileID = 1;
            Rows[11].Columns[5].TileID = 2;
            Rows[11].Columns[6].TileID = 1;
            Rows[11].Columns[14].TileID = 1;
            Rows[11].Columns[15].TileID = 2;
            Rows[11].Columns[16].TileID = 1;

            //RIVI: 12

            Rows[12].Columns[2].TileID = 1;
            Rows[12].Columns[3].TileID = 1;
            Rows[12].Columns[4].TileID = 1;
            Rows[12].Columns[5].TileID = 2;
            Rows[12].Columns[6].TileID = 1;
            Rows[12].Columns[8].TileID = 1;
            Rows[12].Columns[9].TileID = 1;
            Rows[12].Columns[10].TileID = 1;
            Rows[12].Columns[11].TileID = 1;
            Rows[12].Columns[12].TileID = 1;
            Rows[12].Columns[14].TileID = 1;
            Rows[12].Columns[15].TileID = 2;
            Rows[12].Columns[16].TileID = 1;
            Rows[12].Columns[17].TileID = 1;
            Rows[12].Columns[18].TileID = 1;
            Rows[12].Columns[19].TileID = 1;

            //RIVI: 13

            for (int i = 2; i < 10; i++)
            {
                Rows[13].Columns[i].TileID = 2;
            }

            Rows[13].Columns[10].TileID = 1;

            for (int i = 11; i < 19; i++)
            {
                Rows[13].Columns[i].TileID = 2;
            }

            //RIVI: 14

            Rows[14].Columns[2].TileID = 2;
            Rows[14].Columns[3].TileID = 1;
            Rows[14].Columns[4].TileID = 1;
            Rows[14].Columns[5].TileID = 2;
            Rows[14].Columns[6].TileID = 1;
            Rows[14].Columns[7].TileID = 1;
            Rows[14].Columns[8].TileID = 1;
            Rows[14].Columns[9].TileID = 2;
            Rows[14].Columns[10].TileID = 1;
            Rows[14].Columns[11].TileID = 2;
            Rows[14].Columns[12].TileID = 1;
            Rows[14].Columns[13].TileID = 1;
            Rows[14].Columns[14].TileID = 1;
            Rows[14].Columns[15].TileID = 2;
            Rows[14].Columns[16].TileID = 1;
            Rows[14].Columns[17].TileID = 1;
            Rows[14].Columns[18].TileID = 2;
            Rows[14].Columns[19].TileID = 1;

            // RIVI: 15

            Rows[15].Columns[2].TileID = 3;
            Rows[15].Columns[3].TileID = 2;
            Rows[15].Columns[4].TileID = 1;

            for (int i = 5; i < 16; i++)
            {
                Rows[15].Columns[i].TileID = 2;
            }

            Rows[15].Columns[16].TileID = 1;
            Rows[15].Columns[17].TileID = 2;
            Rows[15].Columns[18].TileID = 3;

            //RIVI: 16

            Rows[16].Columns[2].TileID = 1;
            Rows[16].Columns[3].TileID = 2;
            Rows[16].Columns[4].TileID = 1;
            Rows[16].Columns[5].TileID = 2;
            Rows[16].Columns[6].TileID = 1;
            Rows[16].Columns[7].TileID = 2;
            Rows[16].Columns[8].TileID = 1;
            Rows[16].Columns[9].TileID = 1;
            Rows[16].Columns[10].TileID = 1;
            Rows[16].Columns[11].TileID = 1;
            Rows[16].Columns[12].TileID = 1;
            Rows[16].Columns[13].TileID = 2;
            Rows[16].Columns[14].TileID = 1;
            Rows[16].Columns[15].TileID = 2;
            Rows[16].Columns[16].TileID = 1;
            Rows[16].Columns[17].TileID = 2;
            Rows[16].Columns[18].TileID = 1;
            Rows[16].Columns[19].TileID = 1;

            //RIVI: 17

            Rows[17].Columns[2].TileID = 2;
            Rows[17].Columns[3].TileID = 2;
            Rows[17].Columns[4].TileID = 2;
            Rows[17].Columns[5].TileID = 2;
            Rows[17].Columns[6].TileID = 1;
            Rows[17].Columns[7].TileID = 2;
            Rows[17].Columns[8].TileID = 2;
            Rows[17].Columns[9].TileID = 2;
            Rows[17].Columns[10].TileID = 1;
            Rows[17].Columns[11].TileID = 2;
            Rows[17].Columns[12].TileID = 2;
            Rows[17].Columns[13].TileID = 2;
            Rows[17].Columns[14].TileID = 1;
            Rows[17].Columns[15].TileID = 2;
            Rows[17].Columns[16].TileID = 2;
            Rows[17].Columns[17].TileID = 2;
            Rows[17].Columns[18].TileID = 2;
            Rows[17].Columns[19].TileID = 1;

            //RIVIT: 18

            Rows[18].Columns[2].TileID = 2;
            Rows[18].Columns[3].TileID = 1;
            Rows[18].Columns[4].TileID = 1;
            Rows[18].Columns[5].TileID = 1;
            Rows[18].Columns[6].TileID = 1;
            Rows[18].Columns[7].TileID = 1;
            Rows[18].Columns[8].TileID = 1;
            Rows[18].Columns[9].TileID = 2;
            Rows[18].Columns[10].TileID = 1;
            Rows[18].Columns[11].TileID = 2;
            Rows[18].Columns[12].TileID = 1;
            Rows[18].Columns[13].TileID = 1;
            Rows[18].Columns[14].TileID = 1;
            Rows[18].Columns[15].TileID = 1;
            Rows[18].Columns[16].TileID = 1;
            Rows[18].Columns[17].TileID = 1;
            Rows[18].Columns[18].TileID = 2;
            Rows[18].Columns[19].TileID = 1;
            // End Create Sample Map Data

            //RIVI: 19

            for (int i = 2; i < 19; i++)
            {
                Rows[19].Columns[i].TileID = 2;
            }
        }
    }
    /// <summary>
    /// Small class which helps the organizing of cells.
    /// </summary>
    class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
    }
}
