using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class TransportRoomCommand: ICommand
    {
        private Door myDoor;
        private Map myMap;
        private Player myPlayer;
        private CollisionSides mySide;
        public TransportRoomCommand(Player player, Door door, CollisionSides side)
        {
            myDoor = door;
            myMap = myDoor.myMap;
            myPlayer = player;
            mySide = side;
        }
        public void Execute()
        {
            Door targetDoor = myMap.FindDoor(myDoor.myRoomKey);
            Rectangle targetRect = targetDoor.GetRectangle();
            Console.WriteLine("Change room");
            switch (mySide)
            {
                case CollisionSides.Left:
                    myPlayer.xPos = targetRect.Center.X - myPlayer.GetRectangle().Width - 25;
                    break;
                case CollisionSides.Right:
                    myPlayer.xPos = targetRect.Center.X + myPlayer.GetRectangle().Width + 15;
                    break;
                case CollisionSides.Up:
                    myPlayer.yPos = targetRect.Center.Y - myPlayer.GetRectangle().Height - 30;
                    break;
                case CollisionSides.Down:
                    myPlayer.yPos = targetRect.Center.Y + myPlayer.GetRectangle().Height;
                    break;
                default:
                    break;
            }

        }
    }
}
