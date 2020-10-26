using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class DungeonMap : IWorldItem
    {
        public float xPos, yPos;
        public DungeonMap()
        {
            xPos = 300;
            yPos = 300;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source = ItemTextureStorage.MAP;
            spriteBatch.Draw(texture, getRectangle(), source, Color.White);
        }
        private Rectangle getRectangle()
        {
            return new Rectangle((int)xPos, (int)yPos,
                ItemTextureStorage.RUPEE.Width * 3,
                ItemTextureStorage.RUPEE.Height * 3);
        }
        Rectangle ICollider.GetRectangle()
        {
            return getRectangle();
        }
    }
}