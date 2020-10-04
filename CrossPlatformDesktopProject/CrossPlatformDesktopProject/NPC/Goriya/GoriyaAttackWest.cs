using CrossPlatformDesktopProject.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaAttackWest : IGoriyaState
    {
        private int my_frame_index, my_frame_index_2;
        private int delay_frame_index, delay_frame_index_2;
        private int travelMarker;
        private Goriya goriya;
        private float boomerang_x, boomerang_y;

        private static int delay_frames = 6;
        private static int delay_frames_2 = 2;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GORIYA_LEFT_1,
            NpcTextureStorage.GORIYA_LEFT_2
        };

        private static List<Rectangle> my_source_frames_boomerang = new List<Rectangle>{
            NpcTextureStorage.BOSS_ATTACK_1,
            NpcTextureStorage.BOSS_ATTACK_2,
            NpcTextureStorage.BOSS_ATTACK_3,
        };

        public GoriyaAttackWest(Goriya goriya)
        {
            this.goriya = goriya;
            my_frame_index = 0;
            delay_frame_index = 0;

            my_frame_index_2 = 0;
            delay_frame_index_2 = 0;

            travelMarker = 0;

            boomerang_x = 410;
            boomerang_y = 120;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getEnemySpriteSheetMirrored();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);

            Rectangle source_fireball = my_source_frames_boomerang[my_frame_index_2];
            Rectangle destination_boomerang = new Rectangle(
                (int)boomerang_x, (int)boomerang_y,
                source.Width, source.Height);

            spriteBatch.Draw(texture, destination_boomerang, source_fireball, Color.White);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (boomerang_x == 400 && travelMarker == 1)
            {
                goriya.currentState = new GoriyaWalkNorth(goriya);
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
                    boomerang_x -= 5;
                }
                else if (travelMarker == 1)
                {
                    boomerang_x += 5;
                }

                if (boomerang_x == 0)
                {
                    travelMarker = 1;
                }
                else if (boomerang_x == 410)
                {
                    travelMarker = 0;
                }

                my_frame_index_2 %= my_source_frames_boomerang.Count;
            }
        }
    }
}