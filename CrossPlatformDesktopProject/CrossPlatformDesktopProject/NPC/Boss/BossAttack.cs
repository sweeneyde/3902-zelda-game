using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class BossAttack : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
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

        public BossAttack(Boss boss, Fireball fireball1, Fireball fireball2, Fireball fireball3)
        {
            this.boss = boss;
            this.fireball1 = fireball1;
            this.fireball2 = fireball2;
            this.fireball3 = fireball3;
            my_frame_index = 0;
            delay_frame_index = 0;

            fireball1.currentState = new TopFireball(fireball1, boss.xPos - 10, boss.yPos + 10, true);
            fireball2.currentState = new MiddleFireball(fireball2, boss.xPos - 10, boss.yPos + 30, true);
            fireball3.currentState = new BottomFireball(fireball3, boss.xPos - 10, boss.yPos + 50, true);
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getBossSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);

            spriteBatch.Draw(texture, destination, source, Color.White);
            boss.hitbox = destination;
        }

        public void Update()
        {
            if (fireball2.xPos < 3)
            {
                boss.currentState = new BossWalkWest(boss, fireball1, fireball2, fireball3);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }

        public void TakeDamage(CollisionSides side)
        {
        }
    }
}