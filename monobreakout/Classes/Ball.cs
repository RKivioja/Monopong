using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monobreakout
{
    class Ball : GameObject
    {
        public Vector2 Velocity;
        private Random random;
        private bool collided;

        public Ball()
        {
            random = new Random();
        }

        public void Launch(float speed, Vector2 playerposition, int playerTextureHeight, int playerTextureWidth)
        {
            int screenwidth = Game1.GetScreenWidth();
            int screenheight = Game1.GetScreenHeight();

            int direction = 0;
            Velocity = new Vector2(direction, 4);
            Position.Y = playerposition.Y - playerTextureHeight;
            Position.X = playerposition.X + playerTextureWidth/2;
             
        }

        public void CheckWallCollision()
        {
            int screenwidth = Game1.GetScreenWidth();
            int screenheight = Game1.GetScreenHeight();

            if (Position.X < 0)
            {
                Position.X = 0;
                Velocity.X *= -1;
                /*
                SoundEffect soundeffect = SoundManager.GetSoundEffectBW();
                SoundManager.PlaySoundEffect(soundeffect);
                 */
            }
            if (Position.X + Texture.Width > screenwidth)
            {
                Position.X = screenwidth - Texture.Width;
                Velocity.X *= -1;

                /*
                SoundEffect soundeffect = SoundManager.GetSoundEffectBW();
                SoundManager.PlaySoundEffect(soundeffect);
                 */
            }

            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;

                /*
                SoundEffect soundeffect = SoundManager.GetSoundEffectBW();
                SoundManager.PlaySoundEffect(soundeffect);
                 */
            }
        }

        public override void Move(Vector2 amount)
        {
            base.Move(amount);
            CheckWallCollision();
        }

        public void Deflection(Brick brick)
        {
            if (!collided)
            {
                collided = true;
                Velocity.Y *= -1;
            }
        }

        public void SetTexture(Texture2D balltexture)
        {
            Texture = balltexture;
        }

        public Vector2 GetVelocity()
        {
            return Velocity;
        }

        public void SetVelocity(float ballvelocityX, float ballvelocityY)
        {
            Velocity.X = ballvelocityX;
            Velocity.Y = ballvelocityY;
            
        }

        public void SetVelocityY(float ballvelocityY)
        {
            Velocity.Y = ballvelocityY;
        }

        public void SetPosition(Vector2 ballPosition)
        {
            Position = ballPosition;
        }

        internal void SetCollided(bool collision)
        {
            collided = collision;
        }
    }
}
