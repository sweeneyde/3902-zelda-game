using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Goriya : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;

        public Goriya()
        {
            currentState = new GoriyaWalkEast(this);
            xPos = 400;
            yPos = 100;
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