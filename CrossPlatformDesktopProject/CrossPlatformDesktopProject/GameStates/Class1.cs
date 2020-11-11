using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStates
{
    class GameScreenTextureStorage
    {
        private static GameScreenTextureStorage instance = null;

        public static GameScreenTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameScreenTextureStorage();
                }
                return instance;
            }
        }

        public static Texture2D renderTargetTexture;
        public RenderTarget2D screenshot;
        private Game1 myGame;
        public void LoadAllResources(Game1 game)
        {
            myGame = game;
            screenshot = new RenderTarget2D(game.GraphicsDevice, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height, false, SurfaceFormat.Color, DepthFormat.Depth24);
            renderTargetTexture = (Texture2D) screenshot;
        }

        public void SaveScreen(SpriteBatch sb)
        {
            myGame.GraphicsDevice.SetRenderTarget(screenshot);
            sb.Begin();
            myGame.currentGamePlayState.Draw(sb);
            sb.End();
            myGame.GraphicsDevice.SetRenderTarget(null);
            renderTargetTexture = (Texture2D)screenshot;
        }
    }
}
