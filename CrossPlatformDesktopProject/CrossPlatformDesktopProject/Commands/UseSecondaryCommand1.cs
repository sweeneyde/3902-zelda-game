using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class UseSecondaryCommand1 : ICommand
    {
        private Player myPlayer;
        public UseSecondaryCommand1(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UseSecondary1();
    }
}
