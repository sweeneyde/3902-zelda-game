using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Fireball : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public bool start;
        private Rectangle hitbox;

        public Fireball()
        {
            currentState = new MiddleFireball(this, xPos, yPos, start);
            xPos = 0;
            yPos = 0;
            start = false;
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