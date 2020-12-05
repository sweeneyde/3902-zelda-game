using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class DeathStateCommand : ICommand
    {
        private Game1 myGame;
        public DeathStateCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            if (myGame.currentState.GetType() == typeof(ThunderDomeState))
            {
                myGame.currentState = new ThunderDomeDefeatState(myGame, myGame.font);
            }
            else
            {
                myGame.currentState = new DeathMenuState(myGame, myGame.font);
            }
        }
    }
}
