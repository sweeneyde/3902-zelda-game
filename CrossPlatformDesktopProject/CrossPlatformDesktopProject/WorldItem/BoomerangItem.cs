using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class BoomerangItem : IWorldItem
    {
        public float xPos, yPos;

        public BoomerangItem(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = HUDTextureStorage.Instance.texture;
            Rectangle source = HUDTextureStorage.BOOMERANG;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, GetRectangle(), source, Color.White);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)xPos, (int)yPos,
                HUDTextureStorage.BOOMERANG.Width,
                HUDTextureStorage.BOOMERANG.Height);
        }
    }
}