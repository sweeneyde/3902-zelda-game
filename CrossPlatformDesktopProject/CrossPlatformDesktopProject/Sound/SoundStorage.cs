using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Sound
{
    class SoundStorage : ISpriteFactory
    {
        private static SoundStorage instance = null;


        public static SoundStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundStorage();
                }
                return instance;
            }
        }


        private static SoundEffect swordSound = null;

        private SoundStorage()
        {

        }



        public void LoadAllResources(ContentManager content)
        {
            swordSound = content.Load<SoundEffect>("LOZ_Sword_Slash");
        }

        public SoundEffect getSwordSound()
        {
            return swordSound;
        }

        public static Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>
        {
            ["sword"] = swordSound
        };

    }
}