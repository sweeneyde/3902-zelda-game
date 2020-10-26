using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Gel : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        private Rectangle hitbox;

        public Gel(float xPos, float yPos)
        {
            currentState = new GelWalkEast(this);
            this.xPos = xPos;
            this.yPos = yPos;
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