using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class SelectCommand : ICommand
    {
        private Player myPlayer;
        public SelectCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute(Game1 game)
        {

        }
            
    }
}
