using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class MoveUpCommand : ICommand
    {
        private Player myPlayer;
        public MoveUpCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.MoveUp();
    }
}
