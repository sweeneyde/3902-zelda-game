using CrossPlatformDesktopProject.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class EnterThunderDome : ICommand
    {
        private Game1 myGame;
        public EnterThunderDome(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.currentGamePlayState = new GamePlayState(myGame, Room.FromId(myGame, "018"));
            myGame.currentState = new ThunderDomeState(myGame, Room.FromId(myGame, "018"));
        }
    }
}
