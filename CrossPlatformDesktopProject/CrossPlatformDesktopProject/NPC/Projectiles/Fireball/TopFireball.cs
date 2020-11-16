using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class TopFireball : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Fireball fireball;

        private static int delay_frames = 2;

        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BOSS_ATTACK_1,
            NpcTextureStorage.BOSS_ATTACK_2,
            NpcTextureStorage.BOSS_ATTACK_3,
            NpcTextureStorage.BOSS_ATTACK_4
        };

        public TopFireball(Fireball fireball, float xPos, float yPos, bool start)
        {
            this.fireball = fireball;
            my_frame_index = 0;
            delay_frame_index = 0;

            fireball.xPos = xPos;
            fireball.yPos = yPos;
            fireball.start = start;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            if (fireball.start == true)
            {
                Texture2D texture = NpcTextureStorage.Instance.getBossSpriteSheet();

                Rectangle source = my_source_frames[my_frame_index];
                Rectangle destination_fireball = new Rectangle(
                    (int)fireball.xPos, (int)fireball.yPos,
                    NpcTextureStorage.BOSS_1.Width, NpcTextureStorage.BOSS_1.Height);

                spriteBatch.Draw(texture, destination_fireball, source, Color.White);
            }
        }

        public void Update()
        {
            if (fireball.start == true)
            {
                if (++delay_frame_index >= delay_frames)
                {
                    delay_frame_index = 0;
                    my_frame_index++;

                    fireball.xPos -= 5;
                    fireball.yPos -= 3;

                    my_frame_index %= my_source_frames.Count;
                }
            }
        }

        public void TakeDamage(CollisionSides side)
        {
        }
    }
}