using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class SetMoving : ICommand
    {
        private Game1 myGame;
        public SetMoving(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.sprite = new MovingSprite();
        }
    }
}
