using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class Heart : IWorldItem
    {
        public float xPos, yPos;

        public Heart(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source = ItemTextureStorage.HEART;
            spriteBatch.Draw(texture, GetRectangle(), source, Color.White);
        }

        public List<ICollider> GetColliders()
        {
            return new List<ICollider> { this };
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)xPos, (int)yPos,
                ItemTextureStorage.HEART.Width * 3,
                ItemTextureStorage.HEART.Height * 3);
        }
    }
}