using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaAttackNorth : INpcState
    {
        private int my_frame_index, my_frame_index_2;
        private int delay_frame_index, delay_frame_index_2;
        private int travelMarker;
        private Goriya goriya;
        private float boomerang_x, boomerang_y;

        private static int delay_frames = 6;
        private static int delay_frames_2 = 4;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_UP_1,
            NpcTextureStorage.GORIYA_UP_2
        };

        private static List<Rectangle> my_source_frames_boomerang = new List<Rectangle>{
            NpcTextureStorage.BOOMERANG_1,
            NpcTextureStorage.BOOMERANG_2,
            NpcTextureStorage.BOOMERANG_3,
        };

        public GoriyaAttackNorth(Goriya goriya)
        {
            this.goriya = goriya;
            my_frame_index = 0;
            delay_frame_index = 0;

            my_frame_index_2 = 0;
            delay_frame_index_2 = 0;

            travelMarker = 0;

            boomerang_x = 410;
            boomerang_y = 110;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getGoriyaUpDownSpriteSheet();
            Texture2D texture2 = NpcTextureStorage.Instance.getEnemySpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);

            Rectangle source_fireball = my_source_frames_boomerang[my_frame_index_2];
            Rectangle destination_boomerang = new Rectangle(
                (int)boomerang_x, (int)boomerang_y,
                source.Width * 2, source.Height * 3);

            spriteBatch.Draw(texture2, destination_boomerang, source_fireball, Color.White);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (boomerang_y == 100 && travelMarker == 1)
            {
                goriya.currentState = new GoriyaWalkEast(goriya);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }

            if (++delay_frame_index_2 >= delay_frames_2)
            {
                delay_frame_index_2 = 0;
                my_frame_index_2++;

                if (travelMarker == 0)
                {
                    boomerang_y -= 10;
                }
                else if (travelMarker == 1)
                {
                    boomerang_y += 10;
                }

                if (boomerang_y == 0)
                {
                    travelMarker = 1;
                }
                else if (boomerang_y == 110)
                {
                    travelMarker = 0;
                }

                my_frame_index_2 %= my_source_frames_boomerang.Count;
            }
        }
    }
}