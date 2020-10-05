using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class BossAttack : INpcState
    {
        private int my_frame_index, my_frame_index_2;
        private int delay_frame_index, delay_frame_index_2;
        private Boss boss;
        private float fireball1_x, fireball2_x, fireball3_x, fireball1_y, fireball2_y, fireball3_y;

        private static int delay_frames = 15;
        private static int delay_frames_2 = 2;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BOSS_1,
            NpcTextureStorage.BOSS_2,
            NpcTextureStorage.BOSS_3,
            NpcTextureStorage.BOSS_4
        };

        private static List<Rectangle> my_source_frames_fireball = new List<Rectangle>{
            NpcTextureStorage.BOSS_ATTACK_1,
            NpcTextureStorage.BOSS_ATTACK_2,
            NpcTextureStorage.BOSS_ATTACK_3,
            NpcTextureStorage.BOSS_ATTACK_4
        };

        public BossAttack(Boss boss)
        {
            this.boss = boss;
            my_frame_index = 0;
            delay_frame_index = 0;

            my_frame_index_2 = 0;
            delay_frame_index_2 = 0;

            fireball1_x = 370;
            fireball1_y = 100;

            fireball2_x = 370;
            fireball2_y = 120;

            fireball3_x = 370;
            fireball3_y = 140;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getBossSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);

            Rectangle source_fireball = my_source_frames_fireball[my_frame_index_2];
            Rectangle destination_fireball_1 = new Rectangle(
                (int)fireball1_x, (int)fireball1_y,
                source.Width, source.Height);
            Rectangle destination_fireball_2 = new Rectangle(
                (int)fireball2_x, (int)fireball2_y,
                source.Width, source.Height);
            Rectangle destination_fireball_3 = new Rectangle(
                (int)fireball3_x, (int)fireball3_y,
                source.Width, source.Height);

            spriteBatch.Draw(texture, destination, source, Color.White);
            spriteBatch.Draw(texture, destination_fireball_1, source_fireball, Color.White);
            spriteBatch.Draw(texture, destination_fireball_2, source_fireball, Color.White);
            spriteBatch.Draw(texture, destination_fireball_3, source_fireball, Color.White);
        }

        public void Update()
        {
            if (fireball2_x == 0)
            {
                boss.currentState = new BossWalkWest(boss);
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

                fireball1_x -= 5;
                fireball1_y -= 3;

                fireball2_x -= 5;

                fireball3_x -= 5;
                fireball3_y += 3;

                my_frame_index_2 %= my_source_frames_fireball.Count;
            }
        }
    }
}