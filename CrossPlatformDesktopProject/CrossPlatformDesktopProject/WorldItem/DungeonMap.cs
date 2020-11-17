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

        public DungeonMap(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
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
                ItemTextureStorage.MAP.Width,
                ItemTextureStorage.MAP.Height);
        }
        Rectangle ICollider.GetRectangle()
        {
            return getRectangle();
        }
    }
}