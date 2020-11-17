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
        public Rectangle hitbox;
        public int hitboxX, hitboxY;

        public GoriyaBoomerang()
        {
            currentState = new BoomerangDown(this, xPos, yPos, start);
            xPos = 0;
            yPos = 0;
            travelmarker = 0;
            start = false;

            hitboxX = NpcTextureStorage.BOOMERANG_1.Width;
            hitboxY = NpcTextureStorage.BOOMERANG_1.Height;
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);
        }

        public void Update()
        {
            currentState.Update();
            hitbox = new Rectangle((int)xPos, (int)yPos, hitboxX, hitboxY);
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
        }
    }

}