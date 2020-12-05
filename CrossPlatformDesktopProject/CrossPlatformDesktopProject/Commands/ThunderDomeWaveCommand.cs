using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class ThunderDomeWaveCommand : ICommand
    {
        private Game1 myGame;
        private ICollider myCollider;
        public ThunderDomeWaveCommand(Game1 game, Player player, ICollider collider, CollisionSides side)
        {
            myGame = game;
            myCollider = collider;
        }
        public void Execute()
        {
            if (myGame.currentState.GetType() == typeof(ThunderDomeState))
            {
                ((ThunderDomeState)myGame.currentState).StartCountdown();
            }
        }
    }
}
