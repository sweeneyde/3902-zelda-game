using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class Fireball : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public bool start;
        private Rectangle hitbox;
        public int hitboxX, hitboxY;

        public Fireball()
        {
            currentState = new MiddleFireball(this, xPos, yPos, start);
            xPos = 0;
            yPos = 0;
            start = false;

            hitboxX = NpcTextureStorage.BOSS_1.Height / 3;
            hitboxY = NpcTextureStorage.BOSS_1.Width / 3;
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

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
        }
    }

}