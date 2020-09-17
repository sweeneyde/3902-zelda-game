using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class MovingSprite : ISprite
    {
        int spriteX = 106;
        int spriteY = 46;

        int spriteWidth = 32;
        int spriteHeight = 42;

        int frame;

        public MovingSprite()
        {
            frame = 0;
        }
        
        private int[] move(int frame)
        {

            int[] movement = new int[] {frame, frame * 3};
            return movement;
        }

        public void Draw(Texture2D img, SpriteBatch spriteBatch, Vector2 vector)
        {
            int startX = (int) vector.X;
            int startY = (int) vector.Y;

            int[] movePixels = move(frame);

            Rectangle destinationRectangle = new Rectangle(startX/2 + movePixels[0], 0 + movePixels[1], spriteWidth, spriteHeight);
            Rectangle sourceRectangle = new Rectangle(spriteX, spriteY, spriteWidth, spriteHeight);

            spriteBatch.Draw(img, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            frame++;
            if(frame > 200)
            {
                frame = 0;
            }
        }
    }
}
