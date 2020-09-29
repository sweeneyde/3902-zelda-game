using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class HeartIdle : IWorldItem
    {
        private Item item;

        public HeartIdle(Item item)
        {
            this.item = item;
        }

        void IWorldItem.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source = ItemTextureStorage.HEART;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void IWorldItem.Update()
        {
        }
    }
}