using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class NextWorldItemCommand : ICommand
    {
        private Game1 myGame;
        public NextWorldItemCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute() => myGame.entityStorage.nextWorldItem();
    }
}
