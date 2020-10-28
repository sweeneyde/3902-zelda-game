using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class OldMan : INpc
    {
        public float xPos, yPos;
        private Rectangle hitbox;
        public OldMan(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = NpcTextureStorage.Instance.getNpcSpriteSheet();
            Rectangle source = NpcTextureStorage.OLD_MAN_IDLE;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public List<ICollider> GetColliders()
        {
            return new List<ICollider> { this };
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

        public void Update()
        {
        }
    }
}