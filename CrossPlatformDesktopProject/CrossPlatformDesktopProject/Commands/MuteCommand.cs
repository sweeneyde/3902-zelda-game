using CrossPlatformDesktopProject.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class MuteCommand : ICommand
    {
        private Game1 myGame;

        public MuteCommand(Game1 g)
        {
            myGame = g;
        }
        public void Execute() => myGame.mute();
    }
}
