using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class Player
    {
        public ILinkState currentState;
        public IEquipable currentItem = null;
        public float xPos, yPos;
        public static float walking_speed = 3.0f;
        public static int frames_per_step = 6;
        public static int frames_for_sword = 18;
        public bool itemInUse = false;

        public Player()
        {
            currentState = new LinkFacingSouthState1(this);
            xPos = 100;
            yPos = 100;
        }

        public void Update()
        {
            IButtonChecker instance = KeyButtonChecker.Instance;
            if(currentItem != null)
            {
                Debug.Print("current item isn't null");
                currentItem.Update();
                Debug.Print(xPos.ToString());
                Debug.Print(yPos.ToString());
            }
            else if (itemInUse)
            {
                itemInUse = false;
            }
           
            ISet<ButtonKind> buttons = instance.GetPressedButtons();
            currentState.Update(buttons);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
            if(currentItem != null)
            {
                Debug.Print("current item isn't null");
                currentItem.Draw(spriteBatch);
                Debug.Print(xPos.ToString());
                Debug.Print(yPos.ToString());
            }
            else if (itemInUse)
            {
                itemInUse = false;
            }

        }
    }
}
