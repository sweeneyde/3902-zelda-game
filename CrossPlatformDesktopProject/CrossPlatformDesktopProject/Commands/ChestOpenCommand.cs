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
        private IWorldItem myItem;
        private CollisionSides mySide;
        private Player myPlayer;

        public ChestOpenCommand(Player player, IWorldItem item, CollisionSides side)
        {
            myPlayer = player;
            //mySword = playerSword;
            myItem = item;
            mySide = side;
        }

        public void Execute()
        {
            switch (mySide)
            {
                case CollisionSides.Up:
                    Chest cItem = (Chest)myItem;
                    if (!cItem.IsOpen)
                    {
                        cItem.IsOpen = true;
                        myPlayer.PickupItem(cItem.getItemInChest());
                    }

                    myPlayer.xPos = myPlayer.previousXPos;
                    myPlayer.yPos = myPlayer.previousYPos + 1;
                    break;
                case CollisionSides.Down:
                    myPlayer.xPos = myPlayer.previousXPos;
                    myPlayer.yPos = myPlayer.previousYPos - 1;
                    break;
                case CollisionSides.Right:
                    myPlayer.xPos = myPlayer.previousXPos - 1;
                    myPlayer.yPos = myPlayer.previousYPos; 
                    break;
                case CollisionSides.Left:
                    myPlayer.xPos = myPlayer.previousXPos + 1;
                    myPlayer.yPos = myPlayer.previousYPos;
                    break;
                default: break;
            }
        }
    }
}
