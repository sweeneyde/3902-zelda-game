using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class StandingSprite : ISprite
    {
        int spriteX = 0;
        int spriteY = 0;

        int spriteWidth = 32;
        int spriteHeight = 42;

        int frame;

        public StandingSprite()
        {
        }

        public void Draw(Texture2D img, SpriteBatch spriteBatch, Vector2 vector)
        {
            int startX = (int)vector.X;
            int startY = (int)vector.Y;

            Rectangle destinationRectangle = new Rectangle(startX, startY, spriteWidth, spriteHeight);
            Rectangle sourceRectangle = new Rectangle(spriteX, spriteY, spriteWidth, spriteHeight);

            spriteBatch.Draw(img, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
