﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class BoomerangRight : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int starting;
        private GoriyaBoomerang boomerang;

        private static int delay_frames = 4;

        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BOOMERANG_1,
            NpcTextureStorage.BOOMERANG_2,
            NpcTextureStorage.BOOMERANG_3,
        };

        public BoomerangRight(GoriyaBoomerang boomerang, float xPos, float yPos, bool start)
        {
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;

            starting = (int)xPos;

            boomerang.xPos = xPos;
            boomerang.yPos = yPos;
            boomerang.start = start;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            if (boomerang.start == true)
            {
                Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheet();

                Rectangle source = my_source_frames[my_frame_index];
                Rectangle destination_fireball = new Rectangle(
                    (int)boomerang.xPos, (int)boomerang.yPos,
                    NpcTextureStorage.GORIYA_LEFT_1.Width * 2, NpcTextureStorage.GORIYA_LEFT_1.Height * 3);

                spriteBatch.Draw(texture, destination_fireball, source, Color.White);
            }
        }

        public void Update()
        {
            if (boomerang.start == true)
            {
                if (++delay_frame_index >= delay_frames)
                {
                    delay_frame_index = 0;
                    my_frame_index++;

                    if (boomerang.travelmarker == 1 && boomerang.xPos == starting)
                    {
                        boomerang.start = false;
                    }

                    if (boomerang.travelmarker == 0)
                    {
                        boomerang.xPos += 10;
                    }
                    else if (boomerang.travelmarker == 1)
                    {
                        boomerang.xPos -= 10;
                    }

                    if (boomerang.xPos == 800)
                    {
                        boomerang.travelmarker = 1;
                    }

                    my_frame_index %= my_source_frames.Count;
                }
            }
        }
    }
}