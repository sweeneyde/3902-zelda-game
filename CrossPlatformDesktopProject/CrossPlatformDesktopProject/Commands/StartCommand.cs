﻿using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class StartCommand : ICommand
    {
        private Game1 myGame;
        public StartCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.currentState = new InventoryState(myGame.player);
        }
    }
}
