using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class BossWalkEast : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Boss boss;
        private Fireball fireball1;
        private Fireball fireball2;
        private Fireball fireball3;

        private static int delay_frames = 15;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BOSS_1,
            NpcTextureStorage.BOSS_2,
            NpcTextureStorage.BOSS_3,
            NpcTextureStorage.BOSS_4
        };

        public BossWalkEast(Boss boss, Fireball fireball1, Fireball fireball2, Fireball fireball3)
        {
            this.boss = boss;
            this.fireball1 = fireball1;
            this.fireball2 = fireball2;
            this.fireball3 = fireball3;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getBossSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (counter == 10)
            {
                boss.currentState = new BossWalkWest(boss, fireball1, fireball2, fireball3);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                boss.xPos += 3;
                counter++;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}