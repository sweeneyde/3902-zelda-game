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
        private int frames_left;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_HURT_EAST_1,
            NpcTextureStorage.GORIYA_HURT_EAST_2,
        };

        public GoriyaKnockedEast(Goriya goriya, GoriyaBoomerang boomerang)
        {
            this.goriya = goriya;
            this.boomerang = boomerang;
            this.frames_left = Goriya.knockback_frames;

            goriya.knockback = true;
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
            if (goriya.knockback)
            {
                goriya.xPos += Goriya.knockback_speed;
                if (--frames_left <= 0)
                {
                    goriya.currentState = new GoriyaWalkWest(goriya, boomerang);
                }
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
            goriya.knockback = false;
            goriya.xPos -= 5;
            goriya.currentState = new GoriyaWalkWest(goriya, boomerang);
        }
    }
}
