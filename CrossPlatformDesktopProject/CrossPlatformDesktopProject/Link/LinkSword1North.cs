﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace CrossPlatformDesktopProject.Link
{
    class LinkSword1North : ILinkState
    {
        private Player player;
        private int frames_left;
        public LinkSword1North(Player player)
        {
            this.player = player;
            this.frames_left = Player.frames_for_sword;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = LinkTextureStorage.LINK_SWORD_NORTH;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos - 33,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update()
        {
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingNorthState(player);
            }
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void UsePrimary()
        {
        }

        public void UseSecondary()
        {
        }
    }
}
