using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Goriya : INpc
    {
        public INpcState currentState;
        public float xPos, yPos, initialX, initialY;
        public Rectangle hitbox;
        public int health, hitboxX, hitboxY, movementRNG;
        public Game1 myGame;
        public System.Random random;

        private static int frames_per_damage_color_change = 4;
        public static float knockback_speed = 3.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        public Goriya(float xPos, float yPos, GoriyaBoomerang boomerang, Game1 game)
        {
            this.random = new System.Random();
            this.myGame = game;
            health = 3;

            this.xPos = xPos;
            this.initialX = xPos;
            this.yPos = yPos;
            this.initialY = yPos;

            hitboxX = 20;
            hitboxY = 20;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);

            movementRNG = random.Next(1, 4);

            switch(movementRNG)
            {
                case 1:
                    currentState = new GoriyaWalkSouth(this, boomerang);
                    break;
                case 2:
                    currentState = new GoriyaWalkNorth(this, boomerang);
                    break;
                case 3:
                    currentState = new GoriyaWalkWest(this, boomerang);
                    break;
                case 4:
                    currentState = new GoriyaWalkEast(this, boomerang);
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