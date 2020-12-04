using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.WorldItem
{
    class ItemTextureStorage : ISpriteFactory
    {
        private static ItemTextureStorage instance = null;

        public static ItemTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemTextureStorage();
                }
                return instance;
            }
        }


        private static Texture2D itemTexture = null;
        private static Texture2D HUDTexture = null;

        private ItemTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            itemTexture = content.Load<Texture2D>("item_sheet");
            HUDTexture = content.Load<Texture2D>("heart_sheet");
        }


        public Texture2D getItemSpriteSheet()
        {
            return itemTexture;
        }

        public Texture2D getHeartSpriteSheet()
        {
            return HUDTexture;
        }

        public static Rectangle HEART = new Rectangle(645, 117, 8, 8);
        public static Rectangle TRIFORCE = new Rectangle(5 + 27 * 10, 1, 10, 16);
        public static Rectangle KEY = new Rectangle(24 * 10, 0 , 8 , 16);
        public static Rectangle RUPEE = new Rectangle(2 + 7 * 10, 0, 8, 16);
        public static Rectangle MAP = new Rectangle(8 + 8 * 10, 0, 8, 16);
    }
}