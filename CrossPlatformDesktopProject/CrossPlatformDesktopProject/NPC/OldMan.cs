using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class OldMan : INpc
    {
        public float xPos, yPos;
        public OldMan(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = NpcTextureStorage.Instance.getNpcSpriteSheet();
            Rectangle source = NpcTextureStorage.OLD_MAN_IDLE;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public Rectangle GetRectangle()
        {
            Rectangle source = NpcTextureStorage.OLD_MAN_IDLE;
            return new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
        }

        public void Update()
        {
        }

        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
        }
    }
}