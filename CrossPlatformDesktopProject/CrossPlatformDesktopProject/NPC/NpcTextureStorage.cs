using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        private static Texture2D goriyaTextureUpDown = null;
        private static Texture2D skeletonTexture = null;
        private static Texture2D skeletonGoriyaHurtTexture = null;
        private static Texture2D bossTexture = null;
        private static Texture2D npcTexture = null;

        private NpcTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            enemyTexture = content.Load<Texture2D>("enemies");
            enemyTextureMirrored = content.Load<Texture2D>("enemiesflipped");
            goriyaTextureUpDown = content.Load<Texture2D>("goriya_sheet");
            skeletonTexture = content.Load<Texture2D>("skeleton_sheet");
            skeletonGoriyaHurtTexture = content.Load<Texture2D>("skeleton_hurt_sheet");
            bossTexture = content.Load<Texture2D>("boss_sheet");
            npcTexture = content.Load<Texture2D>("npc_sheet");
        }


        public Texture2D getEnemySpriteSheet()
        {
            return enemyTexture;
        }

        public Texture2D getEnemySpriteSheetMirrored()
        {
            return enemyTextureMirrored;
        }

        public Texture2D getGoriyaUpDownSpriteSheet()
        {
            return goriyaTextureUpDown;
        }

        public Texture2D getSkeletonSpriteSheet()
        {
            return skeletonTexture;
        }

        public Texture2D getSkeletonGoriyaHurtSpriteSheet()
        {
            return skeletonGoriyaHurtTexture;
        }

        public Texture2D getBossSpriteSheet()
        {
            return bossTexture;
        }

        public Texture2D getNpcSpriteSheet()
        {
            return npcTexture;
        }

        public static Rectangle BAT_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        public static Rectangle BAT_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);

        public static Rectangle GEL_1 = new Rectangle(1 + 0 * 10, 11, 8, 16);
        public static Rectangle GEL_2 = new Rectangle(10 + 0 * 10, 11, 8, 16);

        public static Rectangle GORIYA_RIGHT_1 = new Rectangle(6 + 25 * 10, 11, 16, 16);
        public static Rectangle GORIYA_RIGHT_2 = new Rectangle(3 + 27 * 10, 11, 16, 16);
        public static Rectangle GORIYA_LEFT_1 = new Rectangle(5 + 18 * 10, 11, 16, 16);
        public static Rectangle GORIYA_LEFT_2 = new Rectangle(8 + 16 * 10, 11, 16, 16);
        public static Rectangle GORIYA_UP_1 = new Rectangle(6 + 25 * 10, 11, 16, 16);
        public static Rectangle GORIYA_UP_2 = new Rectangle(3 + 27 * 10, 11, 16, 16);
        public static Rectangle GORIYA_DOWN_1 = new Rectangle(12 + 21 * 10, 11, 16, 16);
        public static Rectangle GORIYA_DOWN_2 = new Rectangle(9 + 23 * 10, 11, 16, 16);

        public static Rectangle BOOMERANG_1 = new Rectangle(10 + 28 * 10, 11, 8, 16);
        public static Rectangle BOOMERANG_2 = new Rectangle(9 + 29 * 10, 11, 8, 16);
        public static Rectangle BOOMERANG_3 = new Rectangle(8 + 30 * 10, 11, 8, 16);

        public static Rectangle SKELETON_1 = new Rectangle(1 + 0 * 10, 59, 16, 16);
        public static Rectangle SKELETON_2 = new Rectangle(8 + 1 * 10, 59, 16, 16);
        public static Rectangle SKELETON_HURT_1 = new Rectangle(544, 8, 16, 16);
        public static Rectangle SKELETON_HURT_2 = new Rectangle(568, 8, 16, 16);
        public static Rectangle SKELETON_HURT_3 = new Rectangle(592, 8, 16, 16);
        public static Rectangle SKELETON_HURT_4 = new Rectangle(616, 8, 16, 16);

        public static Rectangle BOSS_1 = new Rectangle(1 + 0 * 10, 11, 24, 32);
        public static Rectangle BOSS_2 = new Rectangle(6 + 2 * 10, 11, 24, 32);
        public static Rectangle BOSS_3 = new Rectangle(1 + 5 * 10, 11, 24, 32);
        public static Rectangle BOSS_4 = new Rectangle(6 + 7 * 10, 11, 24, 32);

        public static Rectangle BOSS_ATTACK_1 = new Rectangle(1 + 10 * 10, 11, 8, 15);
        public static Rectangle BOSS_ATTACK_2 = new Rectangle(0 + 11 * 10, 11, 8, 15);
        public static Rectangle BOSS_ATTACK_3 = new Rectangle(9 + 11 * 10, 11, 8, 15);
        public static Rectangle BOSS_ATTACK_4 = new Rectangle(8 + 12 * 10, 11, 8, 15);

        public static Rectangle OLD_MAN_IDLE = new Rectangle(1 + 0 * 10, 11, 16, 16);
    }
}