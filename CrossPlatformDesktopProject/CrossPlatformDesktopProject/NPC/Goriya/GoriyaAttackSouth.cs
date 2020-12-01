using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaAttackSouth : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Goriya goriya;
        private GoriyaBoomerang boomerang;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_DOWN_1,
            NpcTextureStorage.GORIYA_DOWN_2
        };

        public GoriyaAttackSouth(Goriya goriya, GoriyaBoomerang boomerang)
        {
            this.goriya = goriya;
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;

            boomerang.travelmarker = 0;
            boomerang.currentState = new BoomerangDown(boomerang, goriya.xPos, goriya.yPos, true);
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getGoriyaUpDownSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);

            spriteBatch.Draw(texture, destination, source, Color.White);
            goriya.hitbox = destination;
        }

        public void Update()
        {
            if (boomerang.yPos == goriya.yPos && boomerang.travelmarker == 1)
            {
                goriya.movementRNG = goriya.random.Next(1, 4);

                switch (goriya.movementRNG)
                {
                    case 1:
                        goriya.currentState = new GoriyaWalkSouth(goriya, boomerang);
                        break;
                    case 2:
                        goriya.currentState = new GoriyaWalkNorth(goriya, boomerang);
                        break;
                    case 3:
                        goriya.currentState = new GoriyaWalkWest(goriya, boomerang);
                        break;
                    case 4:
                        goriya.currentState = new GoriyaWalkEast(goriya, boomerang);
                        break;
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
            goriya.health--;

            if (goriya.health == 0)
            {
                goriya.currentState = new GoriyaDeath(goriya, boomerang);
            }
            else
            {
                goriya.currentState = new GoriyaKnockedNorth(goriya, boomerang);
            }
        }

        public void ChangeDirection()
        {
        }
    }
}