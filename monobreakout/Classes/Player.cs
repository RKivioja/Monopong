using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monobreakout
{
    class Player : GameObject
    {

        public override void Move(Vector2 amount)
        {
            int screenwidth = Game1.GetScreenWidth();
            base.Move(amount);
            
            if (Position.X < 0) Position.X = 0;
            if (Position.X + Texture.Width >= screenwidth) Position.X = screenwidth - Texture.Width;
        }

        public void SetTexture(Texture2D playertexture)
        {
            Texture = playertexture;
        }

        public void SetPosition(Vector2 playerposition)
        {
            Position = playerposition;
        }
    }
}
