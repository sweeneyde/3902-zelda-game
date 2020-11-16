using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
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
    public class Bomb : IEquipable, ICollider
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

        public Bomb(Player player)
        {
            this.player = player;
            usedX = player.xPos;
            usedY = player.yPos;
            currentPos = new Vector2(usedX, usedY);
            my_frame_index = 0;
            delay_frame_index = 0;
            explode_time = 100;
            current_frame = 1;
            swap_frame = 6;
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
                destination = new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width, source.Height);
                spriteBatch.Draw(texture, destination, source, Color.White);
            }
            else
            {
                foreach (var smoke in GetColliders())
                {
                    destination = smoke.GetRectangle();
                    spriteBatch.Draw(texture, destination, source, Color.White);
                }
            }
        }

        public void Update()
        {
            delay_frame_index++;
            switch (my_frame_index)
            {
                case 0:
                    if (delay_frame_index >= explode_time)
                    {
                        my_frame_index++;
                        delay_frame_index = 0;
                    }
                    break;

                case 1: 
                    if (current_frame == 1 && delay_frame_index >= delay_frames)
                    {
                        current_frame++;
                        delay_frame_index = 0;
                        swap_frame_index++;
                    } else if (current_frame == 2 && delay_frame_index >= delay_frames)
                    {
                        current_frame--;
                        delay_frame_index = 0;
                        swap_frame_index++;
                    } else if (swap_frame_index >= swap_frame)
                    {
                        my_frame_index++;
                        delay_frame_index = 0;
                    }
                    break;

                case 2:
                    if (delay_frame_index >= delay_frames)
                    {
                        my_frame_index++;
                        delay_frame_index = 0;
                    }
                    break;

                case 3:
                    if (delay_frame_index >= delay_frames)
                    {
                        player.linkInventory.TerminateBomb();
                    }
                    break;

                default:
                    player.linkInventory.TerminateBomb();
                    break;
            }
        }

    
        public List<ICollider> GetColliders()
        {
            Rectangle source = my_source_frames[my_frame_index];
            if (current_frame == 1 || my_frame_index >= 2)
            {
                return new List<ICollider>()
                {
                    new Smoke(new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width, source.Height)),
                    new Smoke(new Rectangle((int)currentPos.X + 16, (int)currentPos.Y, source.Width, source.Height)),
                    new Smoke(new Rectangle((int)currentPos.X + 8, (int)currentPos.Y + 12, source.Width, source.Height)),
                    new Smoke(new Rectangle((int)currentPos.X - 8, (int)currentPos.Y - 12, source.Width, source.Height)),
                };
            }
            else if (current_frame == 2) {
                return new List<ICollider>()
                {
                    new Smoke(new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width, source.Height)),
                    new Smoke(new Rectangle((int)currentPos.X - 16, (int)currentPos.Y, source.Width, source.Height)),
                    new Smoke(new Rectangle((int)currentPos.X + 8, (int)currentPos.Y - 12, source.Width, source.Height)),
                    new Smoke(new Rectangle((int)currentPos.X - 8, (int)currentPos.Y + 12, source.Width, source.Height)),
                };
            }
            else {
                return new List<ICollider>();
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)usedX, (int)usedY, my_source_frames[my_frame_index].Width, my_source_frames[my_frame_index].Height);
        }
    }
}
