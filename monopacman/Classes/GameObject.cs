using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monopacman
{
    /// <summary>
    /// This is the GameObject class which acts as a parent to all the objects in the game.
    /// Makes applying changes to all the objects easier.
    /// </summary>
    class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;

        /**
         * Draws the GameObject to the given spriteBatch
         */
        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(Texture, Position, Color.White);
        }

        /**
         * Moves the GameObject by the amount given in the vector 
         */
        public virtual void Move(Vector2 amount)
        {
            Position += amount;
        }

        /**
         * Gives the bounds of the GameObject. Used to detect collision.
         */
        public Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }

        /**
         * Returns the texture of the GameObject. Used to avoid declaring global variables.
         */
        public Texture2D GetTexture()
        {
            return Texture;
        }

        /**
         * Returns the position of the GameObject. Used to avoid declaring global variables.
         */
        public Vector2 GetPosition()
        {
            return Position;
        }
    }

}