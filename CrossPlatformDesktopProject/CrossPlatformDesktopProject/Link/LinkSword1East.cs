using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace CrossPlatformDesktopProject.Link
{
    class LinkSword1East : ILinkState
    {
        private Player player;
        private int frames_left;
        public LinkSword1East(Player player)
        {
            this.player = player;
            this.frames_left = Player.frames_for_sword;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = LinkTextureStorage.LINK_SWORD_EAST;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update(ISet<ButtonKind> pressedButtons)
        {
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingEastState1(player);
            }
        }
    }
}
