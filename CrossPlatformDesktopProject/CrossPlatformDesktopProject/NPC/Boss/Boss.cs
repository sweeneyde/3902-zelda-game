﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class Boss : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public Rectangle hitbox;
        public int health, hitboxX, hitboxY;
        public Game1 myGame;
        public System.Random random;
        public bool movement;

        public Boss(float xPos, float yPos, Fireball fireball1, Fireball fireball2, Fireball fireball3, Game1 game)
        {
            this.random = new System.Random();
            this.myGame = game;
            this.movement = false;

            health = 8;

            this.xPos = xPos;
            this.yPos = yPos;

            hitboxX = NpcTextureStorage.BOSS_1.Width;
            hitboxY = NpcTextureStorage.BOSS_1.Height;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);

            currentState = new BossWalkWest(this, fireball1, fireball2, fireball3);
        }

        public void Update()
        {
            currentState.Update();
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void TakeDamage()
        {
            currentState.TakeDamage();
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

        public void ChangeDirection()
        {
            currentState.ChangeDirection();
        }
    }

}