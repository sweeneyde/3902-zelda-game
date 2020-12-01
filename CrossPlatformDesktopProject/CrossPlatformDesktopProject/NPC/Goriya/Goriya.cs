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
        public int health, hitboxX, hitboxY;
        public Game1 myGame;

        private static int frames_per_damage_color_change = 4;
        public static float knockback_speed = 3.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        public Goriya(float xPos, float yPos, GoriyaBoomerang boomerang, Game1 game)
        {
            this.myGame = game;
            currentState = new GoriyaWalkEast(this, boomerang);
            health = 3;

            this.xPos = xPos;
            this.initialX = xPos;
            this.yPos = yPos;
            this.initialY = yPos;

            hitboxX = 25;
            hitboxY = 25;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);
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