using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Controllers
{
    class GamePadController : IController
    {
        private Game1 myGame;
        private Player myPlayer;
        //private GamePadState oldState;
        //private GamePadState currentState;
        

        public GamePadController(Game1 game, Player player)
        {
            myGame = game;
            myPlayer = player;
            //oldState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            //currentState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
        }


        public void Update()
        {
            // Check the device for Player One
            GamePadCapabilities capabilities = GamePad.GetCapabilities(
                                               PlayerIndex.One);


            // Get the current state of Controller1
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if (state.ThumbSticks.Left.X < -0.5f)
                new MoveLeftCommand(myPlayer).Execute();
            if (state.ThumbSticks.Left.X > 0.5f)
                new MoveRightCommand(myPlayer).Execute();
            if (state.ThumbSticks.Left.Y < -0.5f)
                new MoveDownCommand(myPlayer).Execute();
            if (state.ThumbSticks.Left.Y > 0.5f)
                new MoveUpCommand(myPlayer).Execute();
            if (state.IsButtonDown(Buttons.A))
                new UsePrimaryCommand(myPlayer).Execute();
            if (state.IsButtonDown(Buttons.X))
                new UseSecondaryCommand(myPlayer).Execute();
            if (state.IsButtonDown(Buttons.B))
                new MuteCommand(myGame).Execute();
            if (state.IsButtonDown(Buttons.Back))
                new ResetGame(myGame).Execute();
            if (state.IsButtonDown(Buttons.Start))
                new SelectCommand(myGame).Execute();
            


        }
    }
}
