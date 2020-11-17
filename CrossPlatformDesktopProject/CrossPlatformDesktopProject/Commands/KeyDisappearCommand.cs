using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
<<<<<<< HEAD
using CrossPlatformDesktopProject.Sound;
=======
using CrossPlatformDesktopProject.Link;
>>>>>>> master
using CrossPlatformDesktopProject.WorldItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class KeyDisappearCommand : ICommand
    {
        private Player myPlayer;
        private IWorldItem myItem;
        private Room myRoom;
        public KeyDisappearCommand(Player player, IWorldItem item, Room room)
        {
            myPlayer = player;
            myItem = item;
            myRoom = room;
        }

        public void Execute()
        {

            myRoom.Remove(myItem);
            myPlayer.linkInventory.ItemPickedUp(myItem);

        }
    }
}
