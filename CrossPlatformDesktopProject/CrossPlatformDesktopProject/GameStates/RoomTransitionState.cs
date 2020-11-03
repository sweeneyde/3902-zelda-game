using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    class RoomTransitionState : IGameState
    {
        Game1 game;
        Room room1, room2;
        int delayLeft;
        RenderTarget2D screenshot;
        public RoomTransitionState(Game1 game, Room room1, Room room2)
        {
            this.game = game;
            this.room1 = room1;
            this.room2 = room2;
            delayLeft = 20;
            screenshot = GameScreenTextureStorage.Instance.screenshot;
        }

        public void Draw(SpriteBatch sb)
        {

            Rectangle window = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            sb.Draw(screenshot, window, window, Color.White);
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
