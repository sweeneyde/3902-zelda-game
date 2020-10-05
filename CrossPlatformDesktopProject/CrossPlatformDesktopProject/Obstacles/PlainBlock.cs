using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Obstacles
{
    class PlainBlock : IObstacle
    {
        public float xPos, yPos;
        public PlainBlock()
        {
            xPos = 200;
            yPos = 200;
        }
        public void Update()
        {
            // Not needed for blocks
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ObstacleTextureStorage.Instance.getObstacleSpriteSheet();
            Rectangle source = ObstacleTextureStorage.OBSTACLE_BASIC;
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
    }
}
