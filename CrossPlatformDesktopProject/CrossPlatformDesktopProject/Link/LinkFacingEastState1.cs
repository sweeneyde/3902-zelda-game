using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingEastState1 : ILinkState
    {
        private Player player;
        private int frames_left;

        public LinkFacingEastState1(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = LinkTextureStorage.LINK_IDLE_EAST;
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
            player.currentState = new LinkFacingSouthState1(player);
        }

        public void MoveLeft()
        {
            player.currentState = new LinkFacingWestState1(player);
        }

        public void MoveRight()
        {
            player.xPos += Player.walking_speed;
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingEastState2(player);
            }
        }

        public void MoveUp()
        {
            player.currentState = new LinkFacingNorthState1(player);
        }

        public void UsePrimary()
        {
            player.currentState = new LinkSword1East(player);
        }

        public void UseSecondary()
        {
        }
    }
}
