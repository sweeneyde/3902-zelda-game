using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Boomerang : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public int travelmarker;
        private Rectangle hitbox;

        public Boomerang()
        {
            currentState = new BoomerangIdle(this);
            xPos = 0;
            yPos = 0;
            travelmarker = 0;
        }

        public void Update()
        {
            currentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}