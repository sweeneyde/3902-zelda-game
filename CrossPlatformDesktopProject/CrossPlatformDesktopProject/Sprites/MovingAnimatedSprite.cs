using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class MovingAnimatedSprite : ISprite
    {
        int spriteX = 0;
        int spriteY = 0;

        int spriteWidth = 32;
        int spriteHeight = 42;

        int counter;
        int frame;

        public MovingAnimatedSprite()
        {
            counter = 0;
            frame = 0;
        }

        private int findFrame()
        {
            return spriteWidth * counter;
        }
        
        private Vector2 move()
        {
            double degrees = (double)frame;
            double frequency = Math.PI / 180;
            int moveY = (int) (20.0 * Math.Sin(frequency * degrees));

            if(frame > 400)
            {
                frame = -frame;
            }

            return new Vector2(frame, moveY);
        }

        public void Draw(Texture2D img, SpriteBatch spriteBatch, Vector2 vector)
        {
            int startX = (int)vector.X;
            int startY = (int)vector.Y;

            int framePixels = findFrame();
            Vector2 movePixels = move();

            Rectangle destinationRectangle = new Rectangle(startX + (int) movePixels.X, startY + (int) movePixels.Y, spriteWidth, spriteHeight);
            Rectangle sourceRectangle = new Rectangle(spriteX + framePixels, spriteY, spriteWidth, spriteHeight);

            spriteBatch.Draw(img, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            frame++;
            if (frame % 5 == 0)
            {
                counter++;
                if (counter > 4)
                {
                    counter = 0;
                }
            }
        }
    }
}
