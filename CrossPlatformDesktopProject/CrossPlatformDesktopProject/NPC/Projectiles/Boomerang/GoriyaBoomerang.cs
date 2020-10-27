using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class GoriyaBoomerang : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public int travelmarker;
        public bool start;

        public GoriyaBoomerang()
        {
            currentState = new BoomerangDown(this, xPos, yPos, start);
            xPos = 0;
            yPos = 0;
            travelmarker = 0;
            start = false;
        }

        public void Update()
        {
            currentState.Update();
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
    }

}