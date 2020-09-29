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

        public Player()
        {
            currentState = new LinkFacingSouthState1(this);
            xPos = 100;
            yPos = 100;
        }

        public void Update()
        {
            IButtonChecker instance = KeyButtonChecker.Instance;
            ISet<ButtonKind> buttons = instance.GetPressedButtons();
            currentState.Update(buttons);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}
