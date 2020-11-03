using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class UseSecondaryCommand2 : ICommand
    {
        private Player myPlayer;
        public UseSecondaryCommand2(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UseSecondary2();
    }
}
