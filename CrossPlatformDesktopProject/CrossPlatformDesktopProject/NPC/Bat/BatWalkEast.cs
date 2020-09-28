﻿using CrossPlatformDesktopProject.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC.Gel
{
    class BatWalkEast : INpc
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Npc npc;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BAT_1,
            NpcTextureStorage.BAT_2
        };

        public BatWalkEast(Npc npc)
        {
            this.npc = npc;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        void INpc.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void INpc.Update()
        {
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                npc.xPos += 5;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }

        }
    }
}
