using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonWalkNorth : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Skeleton skeleton;
        private string linkState;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.SKELETON_1,
            NpcTextureStorage.SKELETON_2
        };

        public SkeletonWalkNorth(Skeleton skeleton)
        {
            this.skeleton = skeleton;

            skeleton.initialY = skeleton.yPos;
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
            if (counter == 2)
            {
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

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.yPos -= 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage()
        {
            linkState = skeleton.myGame.player.currentState.GetType().Name;
            skeleton.health--;

            if (skeleton.health == 0)
            {
                skeleton.currentState = new SkeletonDeath(skeleton);
            }
            else
            {
                if (linkState.Contains("East"))
                {
                    skeleton.currentState = new SkeletonKnockedEast(skeleton);
                }
                else if (linkState.Contains("West"))
                {
                    skeleton.currentState = new SkeletonKnockedWest(skeleton);
                }
                else if (linkState.Contains("North"))
                {
                    skeleton.currentState = new SkeletonKnockedNorth(skeleton);
                }
                else
                {
                    skeleton.currentState = new SkeletonKnockedSouth(skeleton);
                }
            }
        }

        public void ChangeDirection()
        {
            if (System.Math.Abs(skeleton.yPos - skeleton.initialY) > 2)
            {
                skeleton.yPos += 5;
                skeleton.currentState = new SkeletonWalkEast(skeleton);
            }
        }
    }
}