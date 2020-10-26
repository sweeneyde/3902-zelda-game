using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class TakeDamageCommand : ICommand
    {
        private Player myPlayer;
        private CollisionSides mySide;
        public TakeDamageCommand(Player player, CollisionSides side)
        {
            myPlayer = player;
            mySide = side;

        }
        public void Execute() => myPlayer.TakeDamage(mySide);
    }
}
