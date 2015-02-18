using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace monopong
{
    class Player : GameObject
    {
        private int Score;

        public override void Move(Vector2 amount)
        {
            int screenheight = Game1.GetScreenHeight();
            base.Move(amount);
            if (Position.Y < 0) Position.Y = 0;
            if (Position.Y + Texture.Height >= screenheight) Position.Y = screenheight - Texture.Height;
        }

        public void AddScore()
        {
            Score++;
        }

        public int GetScore()
        {
            return Score;
        }
    }
}
