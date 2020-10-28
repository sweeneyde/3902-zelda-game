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
        private IWorldItem myItem;
        private Map myMap;
        public KeyDisappearCommand(IWorldItem item, Map map)
        {
            myItem = item; ;
            myMap = map;
        }

        public void Execute()
        {
            myMap.RemoveEntity(myItem);
        }
    }
}
