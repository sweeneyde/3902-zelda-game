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
        private static SoundEffect dropBombSound = null;
        private static SoundEffect blowUpBombSound = null;
        private static SoundEffect ArrowBoomerangSound = null;
        private static SoundEffect getItemSound = null;
        private static SoundEffect EnemyHitSound = null;
        private static SoundEffect EnemyDieSound = null;
        private static SoundEffect LinkHitSound = null;
        private static SoundEffect LinkDieSound = null;
        private static SoundEffectInstance music_instance = null;


        private SoundStorage()
        {

        }



        public void LoadAllResources(ContentManager content)
        {
            swordSound = content.Load<SoundEffect>("LOZ_Sword_Slash");
            music = content.Load<SoundEffect>("04 - Dungeon");
            dropBombSound = content.Load<SoundEffect>("LOZ_Bomb_Drop");
            blowUpBombSound = content.Load<SoundEffect>("LOZ_Bomb_Blow");
            ArrowBoomerangSound = content.Load<SoundEffect>("LOZ_Arrow_Boomerang");
            getItemSound = content.Load<SoundEffect>("LOZ_Get_Item");
            EnemyHitSound = content.Load<SoundEffect>("LOZ_Enemy_Hit");
            EnemyDieSound = content.Load<SoundEffect>("LOZ_Enemy_Die");
            LinkDieSound = content.Load<SoundEffect>("LOZ_Link_Die");
            LinkHitSound = content.Load<SoundEffect>("LOZ_Link_Hurt");

            if(music_instance != null)
            {
                music_instance.Stop();
            }
            
            music_instance = music.CreateInstance();
            music_instance.IsLooped = true;
            music_instance.Play();
           
        }


        public SoundEffect getSwordSound()
        {
            return swordSound;
        }

        public SoundEffect getdropBombSound()
        {
            return dropBombSound;
        }
        public SoundEffect getblowUpBombSound()
        {
            return blowUpBombSound;
        }
        public SoundEffect getArrowBoomerangSound()
        {
            return ArrowBoomerangSound;
        }
        public SoundEffect getPickUpItemSound()
        {
            return getItemSound;
        }
        public SoundEffect getEnemyHitSound()
        {
            return EnemyHitSound;
        }
        public SoundEffect getEnemyDieSound()
        {
            return EnemyDieSound;
        }
        public SoundEffect getLinkHitSound()
        {
            return LinkHitSound;
        }
        public SoundEffect getLinkDieSound()
        {
            return LinkDieSound;
        }
        public static Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>
        {
            ["sword"] = swordSound
        };

    }
}