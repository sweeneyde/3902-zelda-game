﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Boss : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        private Rectangle hitbox;

        public Boss(float xPos, float yPos, Fireball fireball1, Fireball fireball2, Fireball fireball3)
        {
            currentState = new BossWalkEast(this, fireball1, fireball2, fireball3);
            this.xPos = xPos;
            this.yPos = yPos;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Update()
        {
            currentState.Update();
            hitbox = new Rectangle((int)xPos, (int)yPos, 100, 100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }

}