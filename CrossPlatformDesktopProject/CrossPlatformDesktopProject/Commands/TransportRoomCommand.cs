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
        private Game1 myGame;
        private Player myPlayer;
        private CollisionSides mySide;
        public TransportRoomCommand(Game1 game, Player player, Door door, CollisionSides side)
        {
            myGame = game;
            myPlayer = player;
            myDoor = door;
            mySide = side;
        }
        public void Execute()
        {
            myPlayer.xPos = myDoor.PlayerXPosAfterTravel;
            myPlayer.yPos = myDoor.PlayerYPosAfterTravel;
            myGame.GoToRoom(Room.FromId(myGame, myDoor.TargetRoomKey));
        }
    }
}
