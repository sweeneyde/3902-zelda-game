using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class BossDeath : INpcState
    {
        private Boss boss;
        private Fireball fireball1, fireball2, fireball3;

        public BossDeath(Boss boss, Fireball fireball1, Fireball fireball2, Fireball fireball3)
        {
            this.boss = boss;
            this.fireball1 = fireball1;
            this.fireball2 = fireball2;
            this.fireball3 = fireball3;

            boss.hitboxX = 0;
            boss.hitboxY = 0;

            fireball1.hitboxX = 0;
            fireball1.hitboxY = 0;
            fireball2.hitboxX = 0;
            fireball2.hitboxY = 0;
            fireball3.hitboxX = 0;
            fireball3.hitboxY = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos) // make sure to set source = transparent frame if counter has been reached
        {
        }

        public void Update()
        {
        }

        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
        }
    }
}