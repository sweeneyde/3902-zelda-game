using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;

namespace CrossPlatformDesktopProject.Commands
{
    class UnlockDoorCommand: ICommand
    {
        private Game1 myGame;
        private Player myPlayer;
        private CollisionSides mySide;
        private string roomID;
        public UnlockDoorCommand(Game1 game, Player player, CollisionSides side)
        {
            this.myGame = game;
            this.myPlayer = player;
            this.mySide = side;
            roomID = myGame.currentGamePlayState.CurrentRoom.roomID;
        }
        public void Execute()
        {
            //Ex: roomID = 0011 --> this is a locked connection to room 001
            // When changed to 0010, the door is no longer locked.
            if (myPlayer.linkInventory.keyCount > 0)
            {
                string unlocked;
                string[] adjacents = Map.adjacencies[roomID];
                switch (mySide)
                {
                    case CollisionSides.Up:
                        unlocked = adjacents[0].Substring(0, 3) + "0";
                        adjacents[1] = unlocked;
                        break;
                    case CollisionSides.Down:
                        unlocked = adjacents[1].Substring(0, 3) + "0";
                        adjacents[2] = unlocked;
                        break;
                    case CollisionSides.Left:
                        unlocked = adjacents[2].Substring(0, 3) + "0";
                        adjacents[3] = unlocked;
                        break;
                    case CollisionSides.Right:
                        unlocked = adjacents[2].Substring(0, 3) + "0";
                        adjacents[3] = unlocked;
                        break;
                    default:
                        break;
                }
                myPlayer.linkInventory.keyCount--;
            }
            else 
            {
                switch(mySide)
                {
                    case CollisionSides.Left:
                        myPlayer.xPos = myPlayer.previousXPos - 1;
                        myPlayer.yPos = myPlayer.previousYPos;
                        break;
                    case CollisionSides.Right:
                        myPlayer.xPos = myPlayer.previousXPos + 1;
                        myPlayer.yPos = myPlayer.previousYPos;
                        break;
                    case CollisionSides.Up:
                        myPlayer.xPos = myPlayer.previousXPos;
                        myPlayer.yPos = myPlayer.previousYPos - 1;
                        break;
                    case CollisionSides.Down:
                        myPlayer.xPos = myPlayer.previousXPos;
                        myPlayer.yPos = myPlayer.previousYPos + 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
