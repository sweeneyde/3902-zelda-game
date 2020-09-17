using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class AnimatedSprite : ISprite
    {
        int spriteX = 0;
        int spriteY = 0;

        int spriteWidth = 32;
        int spriteHeight = 42;

        int counter;
        int frame;

        public AnimatedSprite()
        {
            counter = 0;
            frame = 0;
        }

        private int move(int counter)
        {
            return spriteWidth * counter;
        }

        public void Draw(Texture2D img, SpriteBatch spriteBatch, Vector2 vector)
        {
            int startX = (int)vector.X;
            int startY = (int)vector.Y;

            int movePixels = move(counter);

            Rectangle destinationRectangle = new Rectangle(startX, startY, spriteWidth, spriteHeight);
            Rectangle sourceRectangle = new Rectangle(spriteX + movePixels, spriteY, spriteWidth, spriteHeight);

            spriteBatch.Draw(img, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            frame++;
            if (frame > 5)
            {
                frame = 0;
                counter++;
                if(counter > 4)
                {
                    counter = 0;
                }
            }
        }
    }
}
