using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class BatDeath : INpcState
    {
        private Bat bat;

        public BatDeath(Bat bat)
        {
            this.bat = bat;
            bat.hitboxX = 0;
            bat.hitboxY = 0;
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