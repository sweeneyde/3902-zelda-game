using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
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
        private Map myMap;
        public KeyDisappearCommand(DungeonKey key, Map map)
        {
            myKey = key;
            myMap = map;
        }

        public void Execute()
        {
            myMap.RemoveEntity(myKey);
        }
    }
}
