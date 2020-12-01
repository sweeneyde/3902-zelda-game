using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class BatWalkSouth : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Bat bat;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BAT_1,
            NpcTextureStorage.BAT_2
        };

        public BatWalkSouth(Bat bat)
        {
            this.bat = bat;
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
            bat.hitbox = destination;
        }

        public void Update()
        {
            if (counter == 4)
            {
                bat.movementRNG = bat.random.Next(1, 8);

                switch (bat.movementRNG)
                {
                    case 1:
                        bat.currentState = new BatWalkSouth(bat);
                        break;
                    case 2:
                        bat.currentState = new BatWalkNorth(bat);
                        break;
                    case 3:
                        bat.currentState = new BatWalkEast(bat);
                        break;
                    case 4:
                        bat.currentState = new BatWalkWest(bat);
                        break;
                    case 5:
                        bat.currentState = new BatWalkSE(bat);
                        break;
                    case 6:
                        bat.currentState = new BatWalkSW(bat);
                        break;
                    case 7:
                        bat.currentState = new BatWalkNE(bat);
                        break;
                    case 8:
                        bat.currentState = new BatWalkNW(bat);
                        break;
                }
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bat.yPos += 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage()
        {
            bat.currentState = new BatDeath(bat);
        }

        public void ChangeDirection()
        {
            bat.yPos -= 5;
            bat.currentState = new BatWalkNorth(bat);
        }
    }
}