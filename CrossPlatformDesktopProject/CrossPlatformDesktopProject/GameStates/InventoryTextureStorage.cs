using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.GameStates
{
    class InventoryTextureStorage : ISpriteFactory
    {
        private static InventoryTextureStorage instance = null;
        public static InventoryTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InventoryTextureStorage();
                }
                return instance;
            }
        }
        private InventoryTextureStorage()
        {
        }

        public Texture2D texture = null;
        public void LoadAllResources(ContentManager content)
        {
            texture = content.Load<Texture2D>("HUD_spritesheet");
        }

        private static int WIDTH = 255;
        private static int HEIGHT = 87;
        private static int GAP = 12;
        public static Rectangle TOP_THIRD = new Rectangle(1, GAP, WIDTH, HEIGHT);
        public static Rectangle MIDDLE_THIRD = new Rectangle(WIDTH + 3, HEIGHT + 2*GAP + 1, WIDTH, HEIGHT);
        public static Rectangle BOTTOM_THIRD = new Rectangle(WIDTH + 3, GAP, WIDTH, 55);
        public static Rectangle YOU_ARE_HERE = new Rectangle(519, 126, 3, 3);
        public static Rectangle BOOMERANG = new Rectangle(584, 137, 8, 16);
        public static Rectangle BOMB = new Rectangle(602, 137, 10, 16);
        public static Rectangle MAP = new Rectangle(601, 156, 10, 16);
        public static Rectangle COMPASS = new Rectangle(612, 156, 16, 16);

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
        public static Rectangle getDoorSetRectangle(int doorbits)
        {
            int ROOM_RECT_START_X = 519;
            int ROOM_RECT_START_Y = 108;
            int SIZE = 8;

            if (doorbits == 0)
            {
                return new Rectangle(590, 95, SIZE, SIZE);
            }
            else
            {
                doorbits &= 0b1111;
                return new Rectangle (
                    ROOM_RECT_START_X + (SIZE + 1) * doorbits,
                    ROOM_RECT_START_Y,
                    SIZE, SIZE
                );
            }
        }

    }
}
