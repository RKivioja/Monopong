using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace monopong
{
    class Ball : GameObject
    {
        public Vector2 Velocity;
        public Random random;

        public Ball()
        {
            random = new Random();
        }

        public void Launch(float speed)
        {
            int screenwidth = Game1.GetScreenWidth();
            int screenheight = Game1.GetScreenHeight();

            Position = new Vector2(screenwidth / 2 - Texture.Width / 2, screenheight / 2 - Texture.Height / 2);

            float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            Velocity.X = (float)Math.Sin(rotation);
            Velocity.Y = (float)Math.Cos(rotation);

            if (random.Next(2) == 1)
            {
                Velocity.X *= -1;
            }

            Velocity *= speed;
        }

        public void CheckWallCollision()
        {
            int screenheight = Game1.GetScreenHeight();
            if (Position.Y < 0)
            {
                Position.Y  =  0;
                Velocity.Y *= -1;

                SoundEffect soundeffect = SoundManager.GetSoundEffectBW();
                SoundManager.PlaySoundEffect(soundeffect);
            }
            if (Position.Y + Texture.Height > screenheight)
            {
                Position.Y  = screenheight - Texture.Height;
                Velocity.Y *= -1;

                SoundEffect soundeffect = SoundManager.GetSoundEffectBW();
                SoundManager.PlaySoundEffect(soundeffect);
            }
        }

        public override void Move(Vector2 amount)
        {
            base.Move(amount);
            CheckWallCollision();
        }
    }
}
