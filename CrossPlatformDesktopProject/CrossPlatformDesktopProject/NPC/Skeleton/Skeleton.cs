using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Skeleton : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public Rectangle hitbox;

        public static float knockback_speed = 2.0f;

        public Skeleton(float xPos, float yPos)
        {
            currentState = new SkeletonWalkEast(this);
            this.xPos = xPos;
            this.yPos = yPos;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Update()
        {
            currentState.Update();
            hitbox = new Rectangle((int)xPos, (int)yPos, 150, 150);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void TakeDamage(CollisionSides side)
        {
            currentState.TakeDamage(side);
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

    }

}