using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaWalkNorth : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Goriya goriya;
        private GoriyaBoomerang boomerang;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_UP_1,
            NpcTextureStorage.GORIYA_UP_2
        };

        public GoriyaWalkNorth(Goriya goriya, GoriyaBoomerang boomerang)
        {
            this.goriya = goriya;
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;
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
            if (counter == 10)
            {
                goriya.currentState = new GoriyaAttackNorth(goriya, boomerang);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriya.yPos -= 5;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}