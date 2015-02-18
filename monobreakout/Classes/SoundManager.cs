using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace monobreakout
{
    public static class SoundManager
    {
        private static SoundEffect BallBrickCollisionSoundEffect;
        private static SoundEffect PaddleBallCollisionSoundEffect;

        public static void LoadSounds(ContentManager Content)
        {
            BallBrickCollisionSoundEffect = Content.Load<SoundEffect>("BallWallCollision");
            PaddleBallCollisionSoundEffect = Content.Load<SoundEffect>("PaddleBallCollision");
        }

        public static void PlaySoundEffect(SoundEffect soundeffect)
        {
            soundeffect.Play();
        }
        
        public static SoundEffect GetSoundEffectBB()
        {
            return BallBrickCollisionSoundEffect;
        }
        
        public static SoundEffect GetSoundEffectPB()
        {
            return PaddleBallCollisionSoundEffect;
        }
        
    }
}
