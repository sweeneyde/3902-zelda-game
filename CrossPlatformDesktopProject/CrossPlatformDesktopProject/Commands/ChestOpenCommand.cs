using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Sound;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.WorldItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class ChestOpenCommand : ICommand
    {
        private Sword mySword;
        private IWorldItem myItem;
        private Room myRoom;
        public ChestOpenCommand(Sword playerSword, IWorldItem item, Room room)
        {
            mySword = playerSword;
            myItem = item;
            myRoom = room;
        }

        public void Execute()
        {
            Chest cItem = (Chest)myItem;
            if (!cItem.IsOpen)
            {
                cItem.IsOpen = true;
            }
            // Animation here?

        }
    }
}
