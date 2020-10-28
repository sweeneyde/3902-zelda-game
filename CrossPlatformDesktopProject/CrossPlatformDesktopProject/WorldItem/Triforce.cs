using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class Triforce : IWorldItem
    {
        public float xPos, yPos;

        public Triforce(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source = ItemTextureStorage.TRIFORCE;
            spriteBatch.Draw(texture, GetRectangle(), source, Color.White);
        }

        public List<ICollider> GetColliders()
        {
            return new List<ICollider> { this };
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)xPos, (int)yPos,
                ItemTextureStorage.TRIFORCE.Width * 3,
                ItemTextureStorage.TRIFORCE.Height * 3);
        }

    }
}