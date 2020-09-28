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
    class Block : IObstacle
    {
        public float xPos, yPos;
        public Block()
        {
            xPos = 200;
            yPos = 200;
        }
        public void Update()
        {
            // Not needed for blocks
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = ObstacleTextureStorage.Instance.getObstacleSpriteSheet();
            Rectangle source = ObstacleTextureStorage.OBSTACLE_BLOCK;
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
    }
}
