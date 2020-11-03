using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject
{
    class RoomTransitionState : IGameState
    {
        Game1 game;
        Room room1, room2;
        int delayLeft;
        public RoomTransitionState(Game1 game, Room room1, Room room2)
        {
            this.game = game;
            this.room1 = room1;
            this.room2 = room2;
            delayLeft = 20;
        }

        public void Draw(SpriteBatch sb)
        {
            // TODO
        }

        public void Update()
        {
            if (--delayLeft == 0)
            {
                game.currentState = game.currentGamePlayState;
            }
        }
    }
}
