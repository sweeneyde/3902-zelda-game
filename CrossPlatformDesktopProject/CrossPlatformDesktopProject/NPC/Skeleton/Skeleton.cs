using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Skeleton : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        private Rectangle hitbox;

        public Skeleton()
        {
            currentState = new SkeletonWalkEast(this);
            xPos = 400;
            yPos = 100;
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
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }

}