using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace monobreakout
{
    class Brick
    {
        public Texture2D texture;
        private Rectangle location;
        private Color tint;
        private bool alive;

        public Rectangle Location
        {
            get { return location; }
        }

        public Brick(Texture2D texture, Rectangle location, Color tint, bool alive)
        {
            this.texture = texture;
            this.location = location;
            this.tint = tint;
            this.alive = true;
        }

        public void CheckCollision(Ball ball)
        {
            if (alive && ball.Bounds.Intersects(location))
            {
                alive = false;
                Game1.DeductBricksLeft();
                ball.Deflection(this);
                SoundEffect soundeffect = SoundManager.GetSoundEffectBB();
                SoundManager.PlaySoundEffect(soundeffect);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (alive) _spriteBatch.Draw(texture, location, tint);
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public void SetTexture(Texture2D bricktexture)
        {
            texture = bricktexture;
        }
    }
}
