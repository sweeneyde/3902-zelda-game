using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class DungeonKey : IWorldItem
    {
        public float xPos, yPos;
        private Rectangle hitbox;
        public DungeonKey()
        {
            xPos = 300;
            yPos = 300;
            hitbox = new Rectangle((int)xPos,(int)yPos, 20, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source = ItemTextureStorage.KEY;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }
}