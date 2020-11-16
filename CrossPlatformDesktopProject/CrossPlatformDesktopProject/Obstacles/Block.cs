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
        public Block(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }
        public void Update()
        {
            // Not needed for blocks
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ObstacleTextureStorage.Instance.getObstacleSpriteSheet();
            Rectangle source = ObstacleTextureStorage.OBSTACLE_BLOCK;
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public Rectangle GetRectangle()
        {
            Rectangle source = ObstacleTextureStorage.OBSTACLE_BLOCK;
            return new Rectangle((int)xPos, (int)yPos, source.Width, source.Height);
        }
    }
}
