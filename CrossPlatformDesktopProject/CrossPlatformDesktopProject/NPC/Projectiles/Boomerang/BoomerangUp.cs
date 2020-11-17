using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class BoomerangUp : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int starting;
        private int counter;
        private GoriyaBoomerang boomerang;

        private static int delay_frames = 4;

        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BOOMERANG_1,
            NpcTextureStorage.BOOMERANG_2,
            NpcTextureStorage.BOOMERANG_3,
        };

        public BoomerangUp(GoriyaBoomerang boomerang, float xPos, float yPos, bool start)
        {
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;

            starting = (int)yPos;

            boomerang.xPos = xPos;
            boomerang.yPos = yPos;
            boomerang.start = start;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            if (boomerang.start == true)
            {
                Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheet();

                Rectangle source = my_source_frames[my_frame_index];
                Rectangle destination = new Rectangle(
                    (int)boomerang.xPos, (int)boomerang.yPos,
                    NpcTextureStorage.BOOMERANG_1.Width, NpcTextureStorage.BOOMERANG_1.Height);

                spriteBatch.Draw(texture, destination, source, Color.White);
            }
        }

        public void Update()
        {
            if (boomerang.start == true)
            {
                if (++delay_frame_index >= delay_frames)
                {
                    delay_frame_index = 0;
                    my_frame_index++;

                    if (boomerang.travelmarker == 1 && boomerang.yPos == starting)
                    {
                        boomerang.start = false;
                    }

                    if (boomerang.travelmarker == 0)
                    {
                        boomerang.yPos -= 10;
                        counter++;
                    }
                    else if (boomerang.travelmarker == 1)
                    {
                        boomerang.yPos += 10;
                    }

                    if (counter == 15)
                    {
                        boomerang.travelmarker = 1;
                    }

                    my_frame_index %= my_source_frames.Count;
                }
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