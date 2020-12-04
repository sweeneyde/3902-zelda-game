using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Gel : INpc
    {
        public INpcState currentState;
        public float xPos, yPos, initialX, initialY;
        public Rectangle hitbox;
        public int hitboxX, hitboxY, movementRNG;
        public Game1 myGame;
        public System.Random random;

        public Gel(float xPos, float yPos, Game1 game)
        {
            this.random = new System.Random();
            this.myGame = game;

            this.xPos = xPos;
            this.initialX = xPos;
            this.yPos = yPos;
            this.initialY = yPos;

            hitboxX = NpcTextureStorage.GEL_1.Width;
            hitboxY = NpcTextureStorage.GEL_1.Height;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);

            movementRNG = random.Next(1, 4);

            switch(movementRNG)
            {
                case 1:
                    currentState = new GelWalkSouth(this);
                    break;
                case 2:
                    currentState = new GelWalkNorth(this);
                    break;
                case 3:
                    currentState = new GelWalkWest(this);
                    break;
                case 4:
                    currentState = new GelWalkEast(this);
                    break;
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