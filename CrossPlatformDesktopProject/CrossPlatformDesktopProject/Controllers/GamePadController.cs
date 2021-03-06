﻿using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Controllers
{
    class GamePadController : IController
    {
        private Game1 myGame;
        private Player myPlayer;
        
        public GamePadController(Game1 game, Player player)
        {
            myGame = game;
            myPlayer = player;
        }

        public void Update()
        {

            // Get the current state of Controller1
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if (state.ThumbSticks.Left.X < -0.5f || state.IsButtonDown(Buttons.DPadLeft))
                new MoveLeftCommand(myPlayer).Execute();
            if (state.ThumbSticks.Left.X > 0.5f || state.IsButtonDown(Buttons.DPadRight))
                new MoveRightCommand(myPlayer).Execute();
            if (state.ThumbSticks.Left.Y < -0.5f || state.IsButtonDown(Buttons.DPadDown))
                new MoveDownCommand(myPlayer).Execute();
            if (state.ThumbSticks.Left.Y > 0.5f || state.IsButtonDown(Buttons.DPadUp))
                new MoveUpCommand(myPlayer).Execute();
            if (state.IsButtonDown(Buttons.A))
                new UsePrimaryCommand(myPlayer).Execute();
            if (state.IsButtonDown(Buttons.B))
                new UseSecondaryCommand(myPlayer).Execute();
            if (state.IsButtonDown(Buttons.Y))
                new MuteCommand(myGame).Execute();
            if (state.IsButtonDown(Buttons.RightTrigger))
                new ResetGame(myGame).Execute();
            if (state.IsButtonDown(Buttons.Start))
                new SelectCommand(myGame).Execute();
            if (state.IsButtonDown(Buttons.Back))
                new Quit(myGame).Execute();
            if (state.IsButtonDown(Buttons.X))
                new StartCommand(myGame).Execute();



        }
    }
}
