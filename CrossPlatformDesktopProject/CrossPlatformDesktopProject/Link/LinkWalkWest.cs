﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkWalkWest : ILinkState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Player player;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            LinkTextureStorage.MIRRORED_LINK_IDLE_WEST,
            LinkTextureStorage.MIRRORED_LINK_STEP_WEST
        };
        
        public LinkWalkWest(Player player)
        {
            this.player = player;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheetMirrored();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update()
        {
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                player.xPos -= 8;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}