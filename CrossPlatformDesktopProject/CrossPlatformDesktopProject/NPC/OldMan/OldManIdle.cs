using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class OldManIdle : INpc
    {
        private Npc npc;

        public OldManIdle(Npc npc)
        {
            this.npc = npc;
        }

        void INpc.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getNpcSpriteSheet();
            Rectangle source = NpcTextureStorage.OLD_MAN_IDLE;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void INpc.Update()
        {
        }
    }
}