﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonWalkEast : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Skeleton skeleton;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.SKELETON_1,
            NpcTextureStorage.SKELETON_2
        };

        public SkeletonWalkEast(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getSkeletonSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
            skeleton.hitbox = destination;
        }

        public void Update()
        {
            if (counter == 10)
            {
                skeleton.currentState = new SkeletonWalkSouth(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                skeleton.initialX = skeleton.xPos;
                skeleton.initialY = skeleton.yPos;

                delay_frame_index = 0;
                skeleton.xPos += 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage()
        {
            skeleton.health--;

            if (skeleton.health == 0)
            {
                skeleton.currentState = new SkeletonDeath(skeleton);
            } else
            {
                skeleton.currentState = new SkeletonKnockedWest(skeleton);
            }
        }

        public void ChangeDirection()
        {
            skeleton.xPos = skeleton.initialX;
            skeleton.currentState = new SkeletonWalkWest(skeleton);
        }
    }
}