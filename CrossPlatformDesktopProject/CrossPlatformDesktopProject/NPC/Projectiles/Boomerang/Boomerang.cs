using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Boomerang : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        private Rectangle hitbox;

        public Boomerang()
        {
            currentState = new BoomerangIdle(this);
            xPos = 0;
            yPos = 0;
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