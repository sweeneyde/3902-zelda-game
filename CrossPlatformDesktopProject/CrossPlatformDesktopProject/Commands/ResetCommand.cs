using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class ResetCommand: ICommand
    {
        private Player myPlayer;
        private CollisionSides mySide;
        public ResetCommand(Player player, CollisionSides side)
        {
            myPlayer = player;
            mySide = side;
        }
        public void Execute()
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
