using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;

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
            myGame.GoToRoom(Room.FromId(myGame, myDoor.TargetRoomKey), mySide);
            myPlayer.previousXPos = myDoor.PlayerXPosAfterTravel;
            myPlayer.previousYPos = myDoor.PlayerYPosAfterTravel;
            myPlayer.xPos = myDoor.PlayerXPosAfterTravel;
            myPlayer.yPos = myDoor.PlayerYPosAfterTravel;
        }
    }
}
