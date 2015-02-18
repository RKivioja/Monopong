using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace monopacman
{
    /// <summary>
    /// This is the Player class for the game. Inherits GameObject and adds few new features to it.
    /// </summary>
    class Player : GameObject
    {
        /// <summary>
        /// Moves the player according to the Vector2 given.
        /// </summary>
        /// <param name="amount">Vector2 for the amount of distance that should be moven</param>
        public override void Move(Vector2 amount)
        {
            int screenwidth = Game1.GetScreenWidth();
            int screenheight = Game1.GetScreenHeight();

            float targettile;
            
            if(amount.X != 0) targettile = Position.X / 32;
            else targettile = Position.Y / 32;

            //int nextTile = inttofloat(targettile);
            //Rectangle collisiontile = Tile.GetSourceRectangle(nextTile);

            base.Move(amount);

            if (Position.X < 0) Position.X = 0;
            if (Position.X + Texture.Width >= screenwidth) Position.X = screenwidth - Texture.Width;

            if (Position.Y < 0) Position.Y = 0;
            if (Position.Y + Texture.Height >= screenheight) Position.Y = screenheight - Texture.Height;
            
        }

        /// <summary>
        /// Sets a texture for the Player object.
        /// </summary>
        /// <param name="playertexture"></param>
        public void SetTexture(Texture2D playertexture)
        {
            Texture = playertexture;
        }

        /// <summary>
        /// Sets a position for the Player object.
        /// </summary>
        /// <param name="playerposition"></param>
        public void SetPosition(Vector2 playerposition)
        {
            Position = playerposition;
        }
    }
}
