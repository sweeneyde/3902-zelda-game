using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject
{
    class MouseController : IController
    {
        Game1 myGame;
        MouseState oldState;
        MouseState currentState;
        int currentID;
        string newID;
        CollisionSides test;

        public MouseController(Game1 game)
        {
            myGame = game;
            oldState = Mouse.GetState();
            currentState = Mouse.GetState();
            test = CollisionSides.Right;
        }

        public void Update()
        {
            oldState = currentState;
            currentState = Mouse.GetState();

            if (oldState.RightButton != ButtonState.Pressed && currentState.RightButton == ButtonState.Pressed)
            {
                currentID = Int32.Parse(myGame.currentGamePlayState.CurrentRoom.roomID);
                if (currentID < 17)
                {
                    currentID++;
                }
                if (currentID < 10)
                {
                    newID = "00";
                } else 
                {
                    newID = "0";
                }
                newID += currentID;
                myGame.GoToRoom(Room.FromId(myGame, newID), test);
            }

            else if (oldState.LeftButton != ButtonState.Pressed && currentState.LeftButton == ButtonState.Pressed)
            {
                currentID = Int32.Parse(myGame.currentGamePlayState.CurrentRoom.roomID);
                if (currentID > 1)
                {
                    currentID--;
                }
                if (currentID < 10)
                {
                    newID = "00";
                } else 
                {
                    newID = "0";
                }
                newID += currentID;
                myGame.GoToRoom(Room.FromId(myGame, newID), test);
            }
        }

    }
}
