﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingEastState : ILinkState
    {
        private Player player;
        private int frames_left;
        private static List<Rectangle> my_sources = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_EAST,
            LinkTextureStorage.LINK_STEP_EAST,
        };
        private int my_source_index;
        private int my_texture_index;

        public LinkFacingEastState(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
            my_source_index = 0;
            my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getTextures()[my_texture_index];
            Rectangle source = my_sources[my_source_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update()
        {
        }
        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
        }

        public void MoveDown()
        {
            player.currentState = new LinkFacingSouthState(player);
        }

        public void MoveLeft()
        {
            player.currentState = new LinkFacingWestState(player);
        }

        public void MoveRight()
        {
            player.xPos += Player.walking_speed;
            if (--frames_left <= 0)
            {
                frames_left = Player.frames_per_step;
                my_source_index++;
                my_source_index %= my_sources.Count;
            }
        }

        public void MoveUp()
        {
            player.currentState = new LinkFacingNorthState(player);
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
