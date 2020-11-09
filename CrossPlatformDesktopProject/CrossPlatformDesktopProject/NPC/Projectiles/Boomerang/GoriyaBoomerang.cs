using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaBoomerang : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public int travelmarker;
        public bool start;
        private Rectangle hitbox;

        public GoriyaBoomerang()
        {
            currentState = new BoomerangDown(this, xPos, yPos, start);
            xPos = 0;
            yPos = 0;
            travelmarker = 0;
            start = false;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Update()
        {
            currentState.Update();
            hitbox = new Rectangle((int)xPos, (int)yPos, 25, 30);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(
                (int)xPos, (int)yPos, 
                NpcTextureStorage.BOOMERANG_1.Width, 
                NpcTextureStorage.BOOMERANG_1.Height
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void TakeDamage()
        {
        }
    }

}