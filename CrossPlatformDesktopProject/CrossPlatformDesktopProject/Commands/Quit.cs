﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class Quit : ICommand
    {
        private Game1 myGame;
        public Quit(Game1 game)
        {
            myGame = game;
        }
        public void Execute(Game1 game) => myGame.quit();
    }
}
