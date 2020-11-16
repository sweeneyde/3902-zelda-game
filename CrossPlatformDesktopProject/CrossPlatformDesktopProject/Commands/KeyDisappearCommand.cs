using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Sound;
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
        private DungeonKey myKey;
        private Room myRoom;
        public KeyDisappearCommand(DungeonKey key, Room room)
        {
            myKey = key;
            myRoom = room;
        }

        public void Execute()
        {
            myRoom.Remove(myKey);
            SoundStorage.Instance.getPickUpItemSound().Play();
        }
    }
}
