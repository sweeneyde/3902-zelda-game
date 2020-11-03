using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class UsePrimaryCommand : ICommand
    {
        private Player myPlayer;
        public UsePrimaryCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UsePrimary();
    }
}
