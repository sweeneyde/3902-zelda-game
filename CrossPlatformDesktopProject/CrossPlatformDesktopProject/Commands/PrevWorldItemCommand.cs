using CrossPlatformDesktopProject.WorldItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class PrevWorldItemCommand : ICommand
    {
        private Game1 myGame;
        public PrevWorldItemCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute() => myGame.entityStorage.prevWorldItem();
    }
}
