using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace CrossPlatformDesktopProject.GameStates
{
    class ThunderDomeDefeatState : IGameState
    {
        private Game1 game;
        private int cursorpos;
        private SpriteFont font;
        private bool previously_start;
        private bool previously_select;

        public ThunderDomeDefeatState(Game1 game, SpriteFont font)
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
                    (new EnterThunderDome(game)).Execute();
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
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if ((start_pressed && !previously_start) || state.IsButtonDown(Buttons.A))
            {
                ConfirmOption();
                return;
            }
            
            if ((select_pressed && !previously_select) || state.ThumbSticks.Left.Y < -0.5f || state.ThumbSticks.Left.Y > 0.5f || state.IsButtonDown(Buttons.DPadDown) || state.IsButtonDown(Buttons.DPadUp))
            {
                MoveCursor();
            }

            previously_start = start_pressed;
            previously_select = select_pressed;
        }

        void IGameState.Draw(SpriteBatch sb)
        {
            sb.DrawString(font, "You failed the Thunderdome.", new Vector2(20, 30), Color.Red);
            sb.DrawString(font, "Restart", new Vector2(50, 80), Color.Red);
            sb.DrawString(font, "Exit", new Vector2(50, 130), Color.Red);
            sb.DrawString(font, ">", new Vector2(20, 80 + 50 * cursorpos), Color.Blue);
        }
    }
}
