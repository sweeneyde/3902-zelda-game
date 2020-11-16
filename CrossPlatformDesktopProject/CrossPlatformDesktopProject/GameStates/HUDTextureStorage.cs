using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.GameStates
{
    class HUDTextureStorage : ISpriteFactory
    {
        private static HUDTextureStorage instance = null;
        public static HUDTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HUDTextureStorage();
                }
                return instance;
            }
        }
        private HUDTextureStorage()
        {
        }

        public Texture2D texture = null;
        public void LoadAllResources(ContentManager content)
        {
            texture = content.Load<Texture2D>("HUD_spritesheet");
        }

        public static int WIDTH = 256;
        public static int HEIGHT = 56;
        public static Rectangle HUD_WINDOW = new Rectangle(258, 11, WIDTH, HEIGHT);

        public static int TOKEN_WIDTH = 8;
        public static int TOKEN_HEIGHT = 8;
        public static int TOKEN_GAP = 1;
        public static Rectangle X_TOKEN = new Rectangle(519, 117, TOKEN_WIDTH, TOKEN_HEIGHT);

        public static int ITEM_WINDOW_OFFSET_X = 96;
        public static int RUPEE_WINDOW_OFFSET_Y = 16;
        public static int KEY_WINDOW_OFFSET_Y = 32;
        public static int BOMB_WINDOW_OFFSET_Y = 40;

        public static Rectangle ITEM_SLOT_B = new Rectangle(385 - HUD_WINDOW.X, 34 - HUD_WINDOW.Y, 10, 18);
        public static Rectangle ITEM_SLOT_A = new Rectangle(409 - HUD_WINDOW.X, 34 - HUD_WINDOW.Y, 10, 18);

        public static Rectangle SWORD = new Rectangle(555, 137, 8, 16);
        public static Rectangle BOOMERANG = new Rectangle(584, 137, 8, 16);
        public static Rectangle BOMB = new Rectangle(604, 137, 8, 16);
        public static Rectangle BOW = new Rectangle(633, 156, 16, 16);
        public static Rectangle EMPTY_ITEM = new Rectangle(725, 156, 16, 16);

        public static int HEALTH_OFFSET_X = 434 - HUD_WINDOW.X;
        public static int HEALTH_OFFSET_Y = 51 - HUD_WINDOW.Y;

        public static Rectangle FULL_HEART = new Rectangle(645, 117, TOKEN_WIDTH, TOKEN_HEIGHT);
        public static Rectangle HALF_HEART = new Rectangle(636, 117, TOKEN_WIDTH, TOKEN_HEIGHT);
        public static Rectangle EMPTY_HEART = new Rectangle(627, 117, TOKEN_WIDTH, TOKEN_HEIGHT);
        public static Rectangle HEALTH_BAR = new Rectangle(433 - HUD_WINDOW.X, 42 - HUD_WINDOW.Y, 66, 18);
        /// <summary>
        /// Return a source texture rectangle on the texture for
        /// a map square corresponding to a given set of doors.
        /// </summary>
        /// <param name="doorbits">
        /// If 0b1000 & doorbits, there will be a top door.
        /// If 0b0100 & doorbits, there will be a bottom door.
        /// If 0b0010 & doorbits, there will be a left door.
        /// If 0b0001 & doorbits, there will be a right door.
        /// </param>
        /// <returns></returns>
        public static Rectangle getOnesToken(int num)
        {
            //Base 10
            num %= 10;
            if (num < 0 || num > 9)
            {
                return X_TOKEN;
            }
            else
            {
                return new Rectangle(X_TOKEN.X + (TOKEN_GAP + TOKEN_WIDTH) * (num + 1), X_TOKEN.Y, TOKEN_WIDTH, TOKEN_HEIGHT);
            }
        }
        public static Rectangle getTensToken(int num)
        {
            //Base 10
            num /= 10;
            if (num < 0 || num > 9)
            {
                return X_TOKEN;
            }
            else
            {
                return new Rectangle(X_TOKEN.X + (TOKEN_GAP + TOKEN_WIDTH) * (num + 1), X_TOKEN.Y, TOKEN_WIDTH, TOKEN_HEIGHT);
            }
        }
    }
}
