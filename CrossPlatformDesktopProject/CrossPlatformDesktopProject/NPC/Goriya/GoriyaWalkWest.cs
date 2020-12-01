using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaWalkWest : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Goriya goriya;
        private GoriyaBoomerang boomerang;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_LEFT_1,
            NpcTextureStorage.GORIYA_LEFT_2
        };

        public GoriyaWalkWest(Goriya goriya, GoriyaBoomerang boomerang)
        {
            this.goriya = goriya;
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheetMirrored();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
            goriya.hitbox = destination;
        }

        public void Update()
        {
            if (counter == 6)
            {
                goriya.currentState = new GoriyaAttackWest(goriya, boomerang);
            }

            if (++delay_frame_index >= delay_frames)
            {
                goriya.initialX = goriya.xPos;
                goriya.initialY = goriya.yPos;

                delay_frame_index = 0;
                goriya.xPos -= 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage()
        {
            goriya.health--;

            if (goriya.health == 0)
            {
                goriya.currentState = new GoriyaDeath(goriya, boomerang);
            }
            else
            {
                goriya.currentState = new GoriyaKnockedEast(goriya, boomerang);
            }
        }

        public void ChangeDirection()
        {
            goriya.xPos = goriya.initialX;
            goriya.currentState = new GoriyaWalkEast(goriya, boomerang);
        }
    }
}