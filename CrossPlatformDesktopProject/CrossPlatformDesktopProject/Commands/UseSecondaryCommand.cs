using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class UseSecondaryCommand : ICommand
    {
        private Player myPlayer;
        public UseSecondaryCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UseSecondary();
    }
}
