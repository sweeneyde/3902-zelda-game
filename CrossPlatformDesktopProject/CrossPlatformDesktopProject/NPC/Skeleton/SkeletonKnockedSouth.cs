using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonKnockedSouth : INpcState
    {
        private int my_frame_index = 0;
        private int delay_frame_index = 0;
        private Skeleton skeleton;
        private int counter;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.SKELETON_HURT_1,
            NpcTextureStorage.SKELETON_HURT_2,
            NpcTextureStorage.SKELETON_HURT_3,
            NpcTextureStorage.SKELETON_HURT_4
        };

        public SkeletonKnockedSouth(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            counter = 0;

            skeleton.initialX = skeleton.xPos;
            skeleton.initialY = skeleton.yPos;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getSkeletonGoriyaHurtSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (counter == 6)
            {
                skeleton.currentState = new SkeletonWalkNorth(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.yPos += 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
            skeleton.xPos = skeleton.initialX;
            skeleton.yPos = skeleton.initialY;

            skeleton.movementRNG = skeleton.random.Next(1, 4);

            switch (skeleton.movementRNG)
            {
                case 1:
                    skeleton.currentState = new SkeletonWalkSouth(skeleton);
                    break;
                case 2:
                    skeleton.currentState = new SkeletonWalkNorth(skeleton);
                    break;
                case 3:
                    skeleton.currentState = new SkeletonWalkWest(skeleton);
                    break;
                case 4:
                    skeleton.currentState = new SkeletonWalkEast(skeleton);
                    break;
            }
        }
    }
}
