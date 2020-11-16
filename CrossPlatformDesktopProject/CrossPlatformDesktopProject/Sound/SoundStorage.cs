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
        private static SoundEffect music = null;


        private SoundStorage()
        {

        }



        public void LoadAllResources(ContentManager content)
        {
            swordSound = content.Load<SoundEffect>("LOZ_Sword_Slash");
            music = content.Load<SoundEffect>("04 - Dungeon");
            
            // song loops
            var music_instance = music.CreateInstance();
            music_instance.IsLooped = true;
            music_instance.Play();
        }

        public SoundEffect getSwordSound()
        {
            return swordSound;
        }

        public SoundEffect getMusic()
        {
            return music;
        }

        public static Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>
        {
            ["sword"] = swordSound
        };

    }
}