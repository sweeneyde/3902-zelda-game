using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class StartCommand : ICommand
    {
        private Player myPlayer;
        public StartCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {

        }
            
    }
}
