using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class UseSecondaryCommand3 : ICommand
    {
        private Player myPlayer;
        public UseSecondaryCommand3(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UseSecondary3();
    }
}
