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
        private Player myPlayer;
        private CollisionSides mySide;
        public TransportRoomCommand(Player player, Door door, CollisionSides side)
        {
            myDoor = door;
            myPlayer = player;
            mySide = side;
        }
        public void Execute(Game1 game)
        {
            myPlayer.xPos = myDoor.PlayerXPosAfterTravel;
            myPlayer.yPos = myDoor.PlayerYPosAfterTravel;
            game.GoToRoom(Room.FromId(game, myDoor.TargetRoomKey));
        }
    }
}
