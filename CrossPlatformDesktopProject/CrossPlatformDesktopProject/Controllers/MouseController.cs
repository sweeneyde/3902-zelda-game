using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class MouseController : IController
    {
        Game1 myGame;
        MouseState oldState;
        MouseState currentState;
        private Dictionary<Rectangle, ICommand> mappingsLeft;
        private Dictionary<Rectangle, ICommand> mappingsRight;

        public MouseController(Game1 game)
        {
            myGame = game;
            mappingsLeft = new Dictionary<Rectangle, ICommand>();
            mappingsRight = new Dictionary<Rectangle, ICommand>();
            oldState = Mouse.GetState();
            currentState = Mouse.GetState();
        }

        public void addLeftCommand(Rectangle rect, ICommand command)
        {
            mappingsLeft.Add(rect, command);
        }

        public void addRightCommand(Rectangle rect, ICommand command)
        {
            mappingsRight.Add(rect, command);
        }


        public void Update()
        {
            oldState = currentState;
            currentState = Mouse.GetState();

            if (oldState.RightButton != ButtonState.Pressed && currentState.RightButton == ButtonState.Pressed)
            {
                List<Rectangle> list = new List<Rectangle>(mappingsRight.Keys);

                foreach (Rectangle rect in list)
                {
                    mappingsRight[rect].Execute();
                    
                }
            }

            else if (oldState.LeftButton != ButtonState.Pressed && currentState.LeftButton == ButtonState.Pressed)
            {
                List<Rectangle> list = new List<Rectangle>(mappingsLeft.Keys);

                foreach (Rectangle rect in list)
                {
                    if (rect.Contains(currentState.X, currentState.Y))
                    {
                        mappingsLeft[rect].Execute();
                    }
                }
            }
        }

    }
}
