using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingSouthState1 : ILinkState
    {
        private Player player;
        private int frames_left;

        public LinkFacingSouthState1(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = LinkTextureStorage.LINK_IDLE_SOUTH;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update()
        {
        }
        public void MoveDown()
        {
            player.yPos += Player.walking_speed;
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingSouthState2(player);
            }
        }

        public void MoveLeft()
        {
            player.currentState = new LinkFacingWestState1(player);
        }

        public void MoveRight()
        {
            player.currentState = new LinkFacingEastState1(player);
        }

        public void MoveUp()
        {
            player.currentState = new LinkFacingNorthState1(player);
        }

        public void UsePrimary()
        {
            player.currentState = new LinkSword1South(player);
        }

        public void UseSecondary()
        {
        }

    }
}
