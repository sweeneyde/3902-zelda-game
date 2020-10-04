using CrossPlatformDesktopProject.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GelWalkSouth : IGelState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Gel gel;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GEL_1,
            NpcTextureStorage.GEL_2
        };

        public GelWalkSouth(Gel gel)
        {
            this.gel = gel;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (gel.xPos == 450 && gel.yPos == 150)
            {
                gel.currentState = new GelWalkWest(gel);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                gel.yPos += 5;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}