using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class NextNpcCommand : ICommand
    {
        private Game1 myGame;
        public NextNpcCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute() => myGame.entityStorage.nextNpc();
    }
}
