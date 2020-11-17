using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.WorldItem.WorldHandlers
{
    public class Wall : ICollider
    {
        private Rectangle hitbox;
        private int WIDTH_THICKNESS = (RoomTextureStorage.BORDER_WIDTH - RoomTextureStorage.ROOM_WIDTH) / 2;
        private int HEIGHT_THICKNESS = (RoomTextureStorage.BORDER_HEIGHT - RoomTextureStorage.ROOM_HEIGHT) / 2;

        public Wall(string direction, int screenWidth, int screenHeight, Boolean side)
        {
            Rectangle roomSize = RoomTextureStorage.BORDER;

            int doorWidth = RoomTextureStorage.DOOR_SIDE;
            int doorHeight = RoomTextureStorage.DOOR_SIDE;
            

            switch (direction)
            {
                case "top":
                    if (side)
                    {
                        hitbox = new Rectangle(0, 0, screenWidth / 2 - doorWidth / 2, HEIGHT_THICKNESS);
                    }
                    else
                    {
                        hitbox = new Rectangle(screenWidth / 2 + doorWidth / 2, 0, screenWidth, HEIGHT_THICKNESS);
                    } 
                    break;
                case "bottom":
                    if (side)
                    {
                        hitbox = new Rectangle(0, screenHeight - HEIGHT_THICKNESS, screenWidth /2 - doorWidth / 2, screenHeight);
                    }
                    else
                    {
                        hitbox = new Rectangle(screenWidth / 2 + doorWidth / 2, screenHeight - HEIGHT_THICKNESS, screenWidth, screenHeight);
                    }
                    break;
                case "left":
                    if (side)
                    {
                        hitbox = new Rectangle(0, 0, WIDTH_THICKNESS, screenHeight/2 - doorHeight/2);
                    }
                    else
                    {
                        hitbox = new Rectangle(0, screenHeight/2 + doorHeight / 2, WIDTH_THICKNESS, screenHeight);
                    }
                    break;
                case "right":
                    if (side)
                    {
                        hitbox = new Rectangle(screenWidth - WIDTH_THICKNESS, 0, screenWidth, screenHeight/2 - doorHeight / 2);
                    }
                    else
                    {
                        hitbox = new Rectangle(screenWidth - WIDTH_THICKNESS, screenHeight/2 + doorHeight / 2, screenWidth, screenHeight);
                    }
                    break;
                default:
                    throw new Exception();
            }
        }
        public Wall(string direction, int screenWidth, int screenHeight)
        {
            switch (direction)
            {
                case "top":
                    hitbox = new Rectangle(0, 0, screenWidth, HEIGHT_THICKNESS);
                    break;

                case "bottom":
                    hitbox = new Rectangle(0, screenHeight - HEIGHT_THICKNESS, screenWidth, screenHeight);
                    break;
                case "left":
                    hitbox = new Rectangle(0, 0, WIDTH_THICKNESS, screenHeight);
                    break;
                case "right":
                    hitbox = new Rectangle(screenWidth - WIDTH_THICKNESS, 0, screenWidth, screenHeight);
                    break;
                default:
                    throw new Exception();
            }
        }
        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }
}
