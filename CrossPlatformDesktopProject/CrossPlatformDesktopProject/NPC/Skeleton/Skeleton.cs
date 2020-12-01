using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Skeleton : INpc
    {
        public INpcState currentState;
        public float xPos, yPos, initialX, initialY;
        public Rectangle hitbox;
        public int health, hitboxX, hitboxY, movementRNG;
        public Game1 myGame;

        public Skeleton(float xPos, float yPos, Game1 game)
        {
            System.Random random = new System.Random();

            this.myGame = game;

            health = 2;
            this.xPos = xPos;
            this.initialX = xPos;
            this.yPos = yPos;
            this.initialY = yPos;

            hitboxX = 25;
            hitboxY = 25;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);

            movementRNG = random.Next(1, 4);

            if (movementRNG == 1)
            {
                currentState = new SkeletonWalkSouth(this);
            }
            else if (movementRNG == 2)
            {
                currentState = new SkeletonWalkNorth(this);
            }
            else if (movementRNG == 3)
            {
                currentState = new SkeletonWalkWest(this);
            }
            else
            {
                currentState = new SkeletonWalkEast(this);
            }
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