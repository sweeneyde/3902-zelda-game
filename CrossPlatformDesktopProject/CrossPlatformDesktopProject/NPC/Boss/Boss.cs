using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class Boss : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public Rectangle hitbox;

        public Boss(float xPos, float yPos, Fireball fireball1, Fireball fireball2, Fireball fireball3)
        {
            currentState = new BossWalkEast(this, fireball1, fireball2, fireball3);
            this.xPos = xPos;
            this.yPos = yPos;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Update()
        {
            currentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void TakeDamage(CollisionSides side)
        {
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }

}