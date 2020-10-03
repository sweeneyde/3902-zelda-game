using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Equipables
{
    class Bomb : IEquipable
    {
        private Player player;
        private Vector2 currentPos;
        private float usedX;
        private float usedY;
        private int my_frame_index;
        private int delay_frame_index;
        private int delay_frames;
        private int explode_time;
        private int current_frame;
        private int swap_frame;
        private int swap_frame_index;

        private static List<Rectangle> my_source_frames = new List<Rectangle>
        {
            LinkTextureStorage.BOMB,
            LinkTextureStorage.BOMB_EXPLOSION_1,
            LinkTextureStorage.BOMB_EXPLOSION_2,
            LinkTextureStorage.BOMB_EXPLOSION_3
        };

        public Bomb(Player player, ButtonKind envokedWith)
        {
            this.player = player;
            usedX = player.xPos;
            usedY = player.yPos;
            currentPos = new Vector2(usedX, usedY);
            my_frame_index = 0;
            delay_frame_index = 0;
            explode_time = 100;
            current_frame = 1;
            swap_frame = 8;
            swap_frame_index = 0;
            delay_frames = 5;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination;
            if (my_frame_index == 0)
            {
                destination = new Rectangle((int)currentPos.X + 40, (int)currentPos.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
            } else if (current_frame == 1 || my_frame_index >= 2)
            {
                destination = new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
                destination = new Rectangle((int)currentPos.X + 48, (int)currentPos.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
                destination = new Rectangle((int)currentPos.X + 24, (int)currentPos.Y + 38, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
                destination = new Rectangle((int)currentPos.X - 24, (int)currentPos.Y - 38, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
            } else if (current_frame == 2)
            {
                destination = new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
                destination = new Rectangle((int)currentPos.X - 48, (int)currentPos.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
                destination = new Rectangle((int)currentPos.X + 24, (int)currentPos.Y - 38, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
                destination = new Rectangle((int)currentPos.X - 24, (int)currentPos.Y + 38, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destination, source, Color.White);
            } 
            

        }

        public void Update()
        {
            if (my_frame_index == 0)
            {
                if (++delay_frame_index >= explode_time)
                {
                    my_frame_index++;
                    delay_frame_index = 0;
                }
                
            } else
            {
                if (my_frame_index == 1)
                {
                    if (current_frame == 1 && ++delay_frame_index >= delay_frames)
                    {
                        current_frame++;
                        delay_frame_index = 0;
                        swap_frame_index++;
                    } else if (current_frame == 2 && ++delay_frame_index >= delay_frames)
                    {
                        current_frame--;
                        delay_frame_index = 0;
                        swap_frame_index++;
                    } else if (swap_frame_index >= swap_frame)
                    {
                        my_frame_index++;
                        delay_frame_index = 0;
                    }
                } else if (my_frame_index == 2 && ++delay_frame_index >= delay_frames)
                {
                    my_frame_index++;
                    delay_frame_index = 0;
                } else if (my_frame_index == 3 && ++delay_frame_index >= delay_frames)
                {
                    my_frame_index++;
                }
            }
            if (my_frame_index > 3)
            {
                Player.linkInventory.TerminateBomb();
            }

        }
    }
}