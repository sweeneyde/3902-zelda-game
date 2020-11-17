using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStates
{
    class WindowManager
    {
        private int screenWidth;
        private int screenHeight;

        private int gameOffSetY;

        private int hudOffSetY;
        
        private float windowScalar;
        private int windowOffSetX;

        private int gameWindowHeight;
        private int gameWindowWidth;

        private int hudWindowWidth;
        private int hudWindowHeight;
        public WindowManager(Game1 game)
        {
            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;

            Rectangle roomSize = RoomTextureStorage.BORDER;
            gameWindowWidth = roomSize.Width;
            gameWindowHeight = roomSize.Height;

            Rectangle hudSize = HUDTextureStorage.HUD_WINDOW;
            hudWindowWidth = hudSize.Width;
            hudWindowHeight = hudSize.Height;

            FitGameWindow();
        }

        private void FitGameWindow()
        {
            //Find best window fit, adjusting for window width, height, offsets, and scalars

            //Limiting dimensions
            float xScalar = (float) screenWidth / gameWindowWidth;
            float yScalar = (float) screenHeight / (gameWindowHeight + hudWindowHeight);

            if(xScalar > yScalar)
            {
                //Window X size too large
                windowScalar = yScalar;
                windowOffSetX = (int)((float)(screenWidth - (int)((float)gameWindowWidth * windowScalar)) / (2*windowScalar));
                hudOffSetY = hudWindowHeight;
            }
            else
            {
                //Window Y size too large
                windowScalar = xScalar;
                hudOffSetY = (int)((float)(screenHeight - (int)((float)(gameWindowHeight + hudWindowHeight) * windowScalar)) / (2*windowScalar));
            }
            gameOffSetY = (hudOffSetY + (int)(hudWindowHeight));
        }
        public void HUDStart(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateTranslation(new Vector3(windowOffSetX, 0, 0)) * Matrix.CreateScale(windowScalar));
        }
        public void GameStart(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateTranslation(new Vector3(windowOffSetX, hudOffSetY, 0)) * Matrix.CreateScale(windowScalar));
        }
    }
}
