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

        private ItemTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            itemTexture = content.Load<Texture2D>("item_sheet");
        }


        public Texture2D getItemSpriteSheet()
        {
            return itemTexture;
        }

        public static Rectangle HEART = new Rectangle(5 + 2 * 10, 1, 13, 16);
        public static Rectangle TRIFORCE = new Rectangle(5 + 27 * 10, 1, 10, 16);
        public static Rectangle KEY = new Rectangle(24 * 10, 0 , 8 , 16);
        public static Rectangle RUPEE = new Rectangle(2 + 7 * 10, 0, 8, 16);
        public static Rectangle MAP = new Rectangle(8 + 8 * 10, 0, 8, 16);
        public static Rectangle CHEST_CLOSED = new Rectangle(23, 84, 16, 16);
        public static Rectangle CHEST_OPEN = new Rectangle(44, 82, 16, 18);
    }
}