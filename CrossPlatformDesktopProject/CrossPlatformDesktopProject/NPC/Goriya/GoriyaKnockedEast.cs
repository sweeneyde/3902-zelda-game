using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaKnockedEast : INpcState
    {
        private int my_frame_index = 0;
        private int delay_frame_index = 0;
        private Goriya goriya;
        private GoriyaBoomerang boomerang;
        private int counter;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_HURT_EAST_1,
            NpcTextureStorage.GORIYA_HURT_EAST_2,
        };

        public GoriyaKnockedEast(Goriya goriya, GoriyaBoomerang boomerang)
        {
            this.goriya = goriya;
            this.boomerang = boomerang;
            counter = 0;

            goriya.initialX = goriya.xPos;
            goriya.initialY = goriya.yPos;
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
            if (counter == 5)
            {
                goriya.currentState = new GoriyaWalkWest(goriya, boomerang);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriya.xPos += 5;
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
            goriya.xPos = goriya.initialX;
            goriya.yPos = goriya.initialY;

            goriya.movementRNG = goriya.random.Next(1, 4);

            switch (goriya.movementRNG)
            {
                case 1:
                    goriya.currentState = new GoriyaWalkSouth(goriya, boomerang);
                    break;
                case 2:
                    goriya.currentState = new GoriyaWalkNorth(goriya,boomerang);
                    break;
                case 3:
                    goriya.currentState = new GoriyaWalkWest(goriya, boomerang);
                    break;
                case 4:
                    goriya.currentState = new GoriyaWalkEast(goriya, boomerang);
                    break;
            }
        }
    }
}
