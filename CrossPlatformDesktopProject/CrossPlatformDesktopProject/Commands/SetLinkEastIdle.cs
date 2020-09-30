using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Link


namespace CrossPlatformDesktopProject.Commands
{
    class SetLinkEastIdle : ICommand
    {
        private Player player1;
        public SetLinkEastIdle(Player player) => player1 = player;
        public void Execute() => player1.currentState = new LinkFacingEastState1(player1);
    }
}
