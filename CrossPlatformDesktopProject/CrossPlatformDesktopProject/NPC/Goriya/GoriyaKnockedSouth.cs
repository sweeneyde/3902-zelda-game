using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaKnockedSouth : INpcState
    {
        private int my_frame_index = 0;
        private int delay_frame_index = 0;
        private Goriya goriya;
        private GoriyaBoomerang boomerang;
        private int counter;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_HURT_NORTH_1,
            NpcTextureStorage.GORIYA_HURT_NORTH_2,
        };

        public GoriyaKnockedSouth(Goriya goriya, GoriyaBoomerang boomerang)
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
                goriya.currentState = new GoriyaWalkNorth(goriya, boomerang);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriya.yPos += 15;
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
        }
    }
}
