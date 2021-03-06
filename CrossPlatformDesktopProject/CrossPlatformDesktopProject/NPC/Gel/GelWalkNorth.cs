﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class GelWalkNorth : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Gel gel;
        private System.Random random;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GEL_1,
            NpcTextureStorage.GEL_2
        };

        public GelWalkNorth(Gel gel)
        {
            this.random = new System.Random();
            this.gel = gel;
            gel.initialY = gel.yPos;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
            gel.hitbox = destination;
        }

        public void Update()
        {
            if (counter == 4)
            {
                gel.movementRNG = gel.random.Next(1, 4);

                switch (gel.movementRNG)
                {
                    case 1:
                        gel.currentState = new GelWalkSouth(gel);
                        break;
                    case 2:
                        gel.currentState = new GelWalkNorth(gel);
                        break;
                    case 3:
                        gel.currentState = new GelWalkWest(gel);
                        break;
                    case 4:
                        gel.currentState = new GelWalkEast(gel);
                        break;
                }
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                gel.yPos -= 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage()
        {
            gel.currentState = new GelDeath(gel);
        }

        public void ChangeDirection()
        {
            if (System.Math.Abs(gel.yPos - gel.initialY) > 2)
            {
                gel.yPos += 5;
                gel.currentState = new GelWalkEast(gel);
            }
        }
    }
}