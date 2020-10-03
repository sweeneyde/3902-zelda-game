using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class Player
    {
        public ILinkState currentState;
        public float xPos, yPos;
        public static float walking_speed = 3.0f;
        public static int frames_per_step = 6;
        public static int frames_for_sword = 18;

        public Player()
        {
            currentState = new LinkFacingSouthState(this);
            xPos = 100;
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
