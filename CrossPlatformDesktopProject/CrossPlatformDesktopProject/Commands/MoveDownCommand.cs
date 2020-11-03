using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class MoveDownCommand : ICommand
    {
        private Player myPlayer;
        public MoveDownCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute(Game1 game) => myPlayer.MoveDown();
    }
}
