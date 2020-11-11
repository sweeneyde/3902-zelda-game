using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class GelDeath : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private Gel gel;

        private static int delay_frames = 6;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.GEL_1,
            NpcTextureStorage.GEL_2
        };

        public GelDeath(Gel gel)
        {
            this.gel = gel;
            my_frame_index = 0;
            delay_frame_index = 0;
            gel.hitbox = new Rectangle((int)gel.xPos, (int)gel.yPos, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
        }

        public void Update()
        {
        }

        public void TakeDamage()
        {
        }
    }
}