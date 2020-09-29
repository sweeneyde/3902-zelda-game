using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.WorldItem
{
    class Item
    {
        private IWorldItem currentState;
        public float xPos, yPos;

        public Item()
        {
            currentState = new TriforceIdle(this);
            xPos = 300;
            yPos = 300;
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
