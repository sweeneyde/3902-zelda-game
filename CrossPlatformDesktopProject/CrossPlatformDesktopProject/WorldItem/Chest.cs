using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class Chest : IWorldItem
    {
        public float xPos, yPos;
        public bool IsOpen { get; set; }
        public IWorldItem content;

        private int hitBoxOffset = 1;

        public Chest(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            IsOpen = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source;
            if (IsOpen)
            {
                source = ItemTextureStorage.CHEST_OPEN;
            }
            else
            {
                source = ItemTextureStorage.CHEST_CLOSED;
            }
            spriteBatch.Draw(texture, getRectangle(), source, Color.LightSteelBlue);
        }

        private Rectangle getRectangle()
        {
            
            return new Rectangle((int)xPos, (int)yPos,
                ItemTextureStorage.CHEST_CLOSED.Width,
                ItemTextureStorage.CHEST_CLOSED.Height);
        }

        Rectangle ICollider.GetRectangle()
        {          
            return getRectangle();
        }
    }
}