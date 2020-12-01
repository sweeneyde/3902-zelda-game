using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Bat : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public Rectangle hitbox;
        public int hitboxX, hitboxY, movementRNG;
        public Game1 myGame;
        public System.Random random;

        public Bat(float xPos, float yPos, Game1 game)
        {
            this.random = new System.Random();
            this.myGame = game;
            this.xPos = xPos;
            this.yPos = yPos;
            hitboxX = 16;
            hitboxY = 16;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);

            movementRNG = random.Next(1, 8);

            switch(movementRNG)
            {
                case 1:
                    currentState = new BatWalkSouth(this);
                    break;
                case 2:
                    currentState = new BatWalkNorth(this);
                    break;
                case 3:
                    currentState = new BatWalkEast(this);
                    break;
                case 4:
                    currentState = new BatWalkWest(this);
                    break;
                case 5:
                    currentState = new BatWalkSE(this);
                    break;
                case 6:
                    currentState = new BatWalkSW(this);
                    break;
                case 7:
                    currentState = new BatWalkNE(this);
                    break;
                case 8:
                    currentState = new BatWalkNW(this);
                    break;
            }
        }

        public void Update()
        {
            currentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);
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