using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrossPlatformDesktopProject.Commands
{
    class SetLinkWestIdle : ICommand
    {
        private Game1 myGame;
        public SetLinkWestIdle(Game1 game)
        {
            myGame = game;
        }
        public void Execute() => myGame.quit();
    }
