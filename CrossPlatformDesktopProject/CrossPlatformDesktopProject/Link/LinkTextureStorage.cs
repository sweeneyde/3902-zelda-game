using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class LinkTextureStorage : ISpriteFactory
    {
        private static LinkTextureStorage instance = null;
        
        public static LinkTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LinkTextureStorage();
                }
                return instance;
            }
        }


        private static Texture2D linkTexture = null;
        private static Texture2D linkTextureMirrored = null;
        private static Texture2D arrowTexture = null;

        private LinkTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            linkTexture = content.Load<Texture2D>("Link_Spritesheet");
            linkTextureMirrored = content.Load<Texture2D>("Link_Spritesheet_Mirrored");
            arrowTexture = content.Load<Texture2D>("ArrowSpriteSheet");

        }


        public Texture2D getLinkSpriteSheet()
        {
            return linkTexture;
        }

        public Texture2D getLinkSpriteSheetMirrored()
        {
            return linkTextureMirrored;
        }

        public Texture2D getArrowSpriteSheet()
        {
            return arrowTexture;
        }

        public static Rectangle LINK_IDLE_SOUTH = new Rectangle(1 + 0 * 17, 11, 16, 16);
        public static Rectangle LINK_STEP_SOUTH = new Rectangle(1 + 1 * 17, 11, 16, 16);
        public static Rectangle LINK_IDLE_EAST = new Rectangle(1 + 2 * 17, 11, 16, 16);
        public static Rectangle LINK_STEP_EAST = new Rectangle(1 + 3 * 17, 11, 16, 16);
        public static Rectangle LINK_IDLE_NORTH = new Rectangle(1 + 4 * 17, 11, 16, 16);
        public static Rectangle LINK_STEP_NORTH = new Rectangle(1 + 5 * 17, 11, 16, 16);
        public static Rectangle MIRRORED_LINK_IDLE_WEST = new Rectangle(320, 11, 16, 16);
        public static Rectangle MIRRORED_LINK_STEP_WEST = new Rectangle(303, 11, 16, 16);

        public static Rectangle LINK_SWORD_NORTH = new Rectangle(1 + 1*17, 97, 16, 28);
        public static Rectangle LINK_SWORD_SOUTH = new Rectangle(1 + 1*17, 47, 16, 27);
        public static Rectangle LINK_SWORD_EAST = new Rectangle(1 + 1*17, 78, 27, 16);
        public static Rectangle MIRRORED_LINK_SWORD_WEST = new Rectangle(371 - 45, 78, 27, 16);

        public static Rectangle LINK_USE_ITEM_NORTH = new Rectangle(141, 11, 16, 16);
        public static Rectangle LINK_USE_ITEM_SOUTH = new Rectangle(107, 11, 16, 16);
        public static Rectangle LINK_USE_ITEM_EAST = new Rectangle(124, 11, 16, 16);
        public static Rectangle MIRRORED_LINK_USE_ITEM_WEST = new Rectangle(232, 11, 16, 16);

        public static Rectangle BOOMERANG_1 = new Rectangle(65, 189, 5, 8);
        public static Rectangle BOOMERANG_2 = new Rectangle(73, 189, 7, 7);
        public static Rectangle BOOMERANG_3 = new Rectangle(82, 189, 7, 7);
        public static Rectangle BOOMERANG_4 = new Rectangle(290, 189, 7, 7);
        public static Rectangle BOOMERANG_5 = new Rectangle(301, 189, 5, 8);

        public static Rectangle ARROW_EAST = new Rectangle(47, 8, 19, 5);
        public static Rectangle ARROW_WEST = new Rectangle(3, 7, 19, 5);
        public static Rectangle ARROW_SOUTH = new Rectangle(38, 2, 5, 19);
        public static Rectangle ARROW_NORTH = new Rectangle(26, 0, 5, 19);

        public static Rectangle BOMB = new Rectangle(129, 185, 8, 14);
        public static Rectangle BOMB_EXPLOSION_1 = new Rectangle(138, 185, 16, 16);
        public static Rectangle BOMB_EXPLOSION_2 = new Rectangle(155, 185, 16, 16);
        public static Rectangle BOMB_EXPLOSION_3 = new Rectangle(172, 185, 16, 16);
    }
}