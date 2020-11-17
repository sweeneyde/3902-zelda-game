using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStates
{
    public class PauseState : IGameState
    {
        Game1 game;
        SpriteFont font;
        int cooldown;
        public PauseState(Game1 game, SpriteFont font)
        {
            Debug.WriteLine("Pausing.");
            this.game = game;
            this.font = font;
            cooldown = 10;
        }
        public void Draw(SpriteBatch sb)
        {
            game.currentGamePlayState.Draw(sb);

            var location = new Vector2(95, 80);
            sb.DrawString(font, "PAUSED", location, Color.Red);
        }

        private void unpause()
        {
            Debug.WriteLine("Unpausing.");
            game.currentState = game.currentGamePlayState;
        }

        public void Update()
        {
            if (cooldown > 0)
            {
                cooldown--;
                return;
            }

            if (Keyboard.GetState().GetPressedKeys().Contains(Keys.RightShift))
            {
                game.pauseCooldown = 10;
                unpause();
            }
        }
    }
}
