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

        public Bat(float xPos, float yPos)
        {
            currentState = new BatWalkEast(this);
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

        public void ChangeDirection(CollisionSides side)
        {
            switch (side)
            {
                case CollisionSides.Left:
                    currentState = new BatWalkEast(this);
                    break;
                case CollisionSides.Right:
                    currentState = new BatWalkWest(this);
                    break;
                case CollisionSides.Up:
                    currentState = new BatWalkSouth(this);
                    break;
                case CollisionSides.Down:
                    currentState = new BatWalkNorth(this);
                    break;
                default:
                    break;
            }
        }
    }

}