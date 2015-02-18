using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace monopong
{
    public static class SoundManager
    {
        private static SoundEffect BallWallCollisionSoundEffect;
        private static SoundEffect PaddleBallCollisionSoundEffect;

        public static void LoadSounds(ContentManager Content)
        {
            BallWallCollisionSoundEffect = Content.Load<SoundEffect>("BallWallCollision");
            PaddleBallCollisionSoundEffect = Content.Load<SoundEffect>("PaddleBallCollision");
        }

        public static void PlaySoundEffect(SoundEffect soundeffect)
        {
            soundeffect.Play();
        }
        
        public static SoundEffect GetSoundEffectBW()
        {
            return BallWallCollisionSoundEffect;
        }

        public static SoundEffect GetSoundEffectPB()
        {
            return BallWallCollisionSoundEffect;
        }
    }
}
