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
        public int hitboxX, hitboxY;

        public Bat(float xPos, float yPos)
        {
            currentState = new BatWalkEast(this);
            this.xPos = xPos;
            this.yPos = yPos;

            hitboxX = 16;
            hitboxY = 16;
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