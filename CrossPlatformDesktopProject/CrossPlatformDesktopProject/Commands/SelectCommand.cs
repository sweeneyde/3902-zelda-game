using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class SelectCommand : ICommand
    {
        private Game1 myGame;
        public SelectCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute() => myGame.Pause();
    }
}
