using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.NPC
{
    class NpcTextureStorage : ISpriteFactory
    {
        private static NpcTextureStorage instance = null;

        public static NpcTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NpcTextureStorage();
                }
                return instance;
            }
        }


        private static Texture2D enemyTexture = null;
        private static Texture2D enemyTextureMirrored = null;

        private NpcTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            enemyTexture = content.Load<Texture2D>("enemies");
            enemyTextureMirrored = content.Load<Texture2D>("enemiesflipped");
        }


        public Texture2D getEnemySpriteSheet()
        {
            return enemyTexture;
        }

        public Texture2D getEnemySpriteSheetMirrored()
        {
            return enemyTextureMirrored;
        }

        public static Rectangle BAT_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        public static Rectangle BAT_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);

        public static Rectangle GEL_1 = new Rectangle(1 + 0 * 10, 11, 8, 16);
        public static Rectangle GEL_2 = new Rectangle(10 + 0 * 10, 11, 8, 16);

        public static Rectangle GORIYA_RIGHT_1 = new Rectangle(6 + 25 * 10, 11, 16, 16);
        public static Rectangle GORIYA_RIGHT_2 = new Rectangle(3 + 27 * 10, 11, 16, 16);
        public static Rectangle GORIYA_LEFT_1 = new Rectangle(5 + 18 * 10, 11, 16, 16);
        public static Rectangle GORIYA_LEFT_2 = new Rectangle(8 + 16 * 10, 11, 16, 16);
        public static Rectangle GORIYA_UP_1 = new Rectangle(1 + 4 * 17, 11, 16, 16);
        public static Rectangle GORIYA_UP_2 = new Rectangle(1 + 5 * 17, 11, 16, 16);
        public static Rectangle GORIYA_DOWN_1 = new Rectangle(1 + 4 * 17, 11, 16, 16);
        public static Rectangle GORIYA_DOWN_2 = new Rectangle(1 + 5 * 17, 11, 16, 16);

        public static Rectangle SKELETON_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        public static Rectangle SKELETON_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);
    }
}
