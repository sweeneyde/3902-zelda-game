using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class BoomerangLeft : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Boomerang boomerang;
        private float fireball_x, fireball_y;

        private static int delay_frames = 2;

        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.BOOMERANG_1,
            NpcTextureStorage.BOOMERANG_2,
            NpcTextureStorage.BOOMERANG_3,
        };

        public BoomerangLeft(Boomerang boomerang, float xPos, float yPos)
        {
            this.boomerang = boomerang;
            my_frame_index = 0;
            delay_frame_index = 0;

            boomerang_x = xPos;
            boomerang_y = yPos;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getBossSpriteSheet();

            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination_fireball = new Rectangle(
                (int)fireball_x, (int)fireball_y,
                NpcTextureStorage.BOSS_1.Width, NpcTextureStorage.BOSS_1.Height);

            spriteBatch.Draw(texture, destination_fireball, source, Color.White);
        }

        public void Update()
        {
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                my_frame_index++;

                fireball_x -= 5;
                fireball_y -= 3;

                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}