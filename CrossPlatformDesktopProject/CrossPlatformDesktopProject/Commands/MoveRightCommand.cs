using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class MoveRightCommand : ICommand
    {
        private Player myPlayer;
        public MoveRightCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.MoveRight();
    }
}
