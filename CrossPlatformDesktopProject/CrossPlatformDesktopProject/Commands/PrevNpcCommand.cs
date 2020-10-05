using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class PrevNpcCommand : ICommand
    {
        private Game1 myGame;
        public PrevNpcCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute() => myGame.entityStorage.prevNpc();
    }
}
