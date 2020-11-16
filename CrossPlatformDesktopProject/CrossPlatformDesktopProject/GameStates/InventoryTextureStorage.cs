using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Rectangle TOP_THIRD = new Rectangle(0, 0, 100, 100);
        public static Rectangle MIDDLE_THIRD = new Rectangle(100, 100, 100, 100);
        public static Rectangle BOTTOM_THIRD = new Rectangle(100, 0, 100, 100);
    }
}
