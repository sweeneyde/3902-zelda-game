using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class SetMovingAnimated : ICommand
    {
        private Game1 myGame;
        public SetMovingAnimated(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.sprite = new MovingAnimatedSprite();
        }
    }
}
