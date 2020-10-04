﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingSouthState2 : ILinkState
    {
        private Player player;
        private int frames_left;

        public LinkFacingSouthState2(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = LinkTextureStorage.LINK_STEP_SOUTH;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update(ISet<ButtonKind> buttons)
        {
            if (buttons.Contains(ButtonKind.PRIMARY))
            {
                player.currentState = new LinkSword1South(player);
            }
            else if (buttons.Contains(ButtonKind.DOWN))
            {
                player.yPos += Player.walking_speed;
                if (--frames_left <= 0)
                {
                    player.currentState = new LinkFacingSouthState1(player);
                }
            }
            else if (buttons.Contains(ButtonKind.RIGHT))
            {
                player.currentState = new LinkFacingEastState1(player);
            }
            else if (buttons.Contains(ButtonKind.UP))
            {
                player.currentState = new LinkFacingNorthState1(player);
            }
            else if (buttons.Contains(ButtonKind.LEFT))
            {
                player.currentState = new LinkFacingWestState1(player);
            }
        }
    }
}