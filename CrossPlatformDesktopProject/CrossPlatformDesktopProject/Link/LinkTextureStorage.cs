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

        private static Texture2D linkBlackDamageTexture = null;
        private static Texture2D linkRedDamageTexture = null;
        private static Texture2D linkBlueDamageTexture = null;

        private static Texture2D linkBlackDamageTextureMirrored = null;
        private static Texture2D linkRedDamageTextureMirrored = null;
        private static Texture2D linkBlueDamageTextureMirrored = null;


        private LinkTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            linkTexture = content.Load<Texture2D>("Link_Spritesheet");
            linkTextureMirrored = content.Load<Texture2D>("Link_Spritesheet_Mirrored");

            linkBlackDamageTexture = content.Load<Texture2D>("link_damaged_black");
            linkBlueDamageTexture = content.Load<Texture2D>("link_damaged_blue");
            linkRedDamageTexture = content.Load<Texture2D>("link_damaged_red");

            linkBlackDamageTextureMirrored = content.Load<Texture2D>("link_damaged_black_mirrored");
            linkBlueDamageTextureMirrored = content.Load<Texture2D>("link_damaged_blue_mirrored");
            linkRedDamageTextureMirrored = content.Load<Texture2D>("link_damaged_red_mirrored");
        }

        public Texture2D getLinkSpriteSheet()
        {
            return linkTexture;
        }

        public Texture2D getLinkSpriteSheetMirrored()
        {
            return linkTextureMirrored;
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
    }
}
