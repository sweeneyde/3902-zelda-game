using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaAttackEast : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Goriya goriya;
        private Boomerang boomerang;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_RIGHT_1,
            NpcTextureStorage.GORIYA_RIGHT_2
        };

        public GoriyaAttackEast(Goriya goriya, Boomerang boomerang)
        {
            this.goriya = goriya;
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;

            boomerang.travelmarker = 0;
            boomerang.currentState = new BoomerangRight(boomerang, goriya.xPos + 10, goriya.yPos + 10);
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);

            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (boomerang.xPos == 470 && boomerang.travelmarker == 1)
            {
                goriya.currentState = new GoriyaWalkSouth(goriya, boomerang);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}