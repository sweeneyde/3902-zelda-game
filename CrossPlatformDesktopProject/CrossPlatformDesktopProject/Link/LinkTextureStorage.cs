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

        private LinkTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            linkTexture = content.Load<Texture2D>("Link_Spritesheet");
            linkTextureMirrored = content.Load<Texture2D>("Link_Spritesheet_Mirrored");
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
    }
}
