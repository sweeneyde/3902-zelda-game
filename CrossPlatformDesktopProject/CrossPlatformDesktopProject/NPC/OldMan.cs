using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class OldMan : INpc
    {
        public float xPos, yPos;
        public OldMan()
        {
            xPos = 400;
            yPos = 100;
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

        public void Update()
        {
        }
    }
}