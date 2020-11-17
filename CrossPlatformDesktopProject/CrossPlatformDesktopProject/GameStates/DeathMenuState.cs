using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace CrossPlatformDesktopProject.GameStates
{
    class DeathMenuState : IGameState
    {
        private Game1 game;
        private int cursorpos;
        private SpriteFont font;
        private bool previously_start;
        private bool previously_select;

        public DeathMenuState(Game1 game, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            cursorpos = 0;
            previously_select = previously_start = false;
        }

        private void MoveCursor()
        {
            cursorpos += 1;
            cursorpos %= 2;
        }
        private void ConfirmOption()
        {
            switch (cursorpos)
            {
                case 0:
                    Thread.Sleep(500);
                    game.reset();
                    break;
                case 1:
                    game.quit();
                    break;
            }
        }

        void IGameState.Update()
        {
            bool select_pressed = Keyboard.GetState().IsKeyDown(Keys.RightShift);
            bool start_pressed = Keyboard.GetState().IsKeyDown(Keys.Enter);

            if (start_pressed && !previously_start)
            {
                ConfirmOption();
                return;
            }

            if (select_pressed && !previously_select)
            {
                MoveCursor();
            }

            previously_start = start_pressed;
            previously_select = select_pressed;
        }

        void IGameState.Draw(SpriteBatch sb)
        {
            sb.DrawString(font, "Restart Game", new Vector2(50, 30), Color.Red);
            sb.DrawString(font, "Exit", new Vector2(50, 80), Color.Red);
            sb.DrawString(font, ">", new Vector2(20, 30 + 50 * cursorpos), Color.Blue);
        }
    }
}
