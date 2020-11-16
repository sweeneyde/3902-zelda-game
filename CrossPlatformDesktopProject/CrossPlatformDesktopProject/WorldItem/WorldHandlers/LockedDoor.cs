using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using System;
using CrossPlatformDesktopProject.Levels;

namespace CrossPlatformDesktopProject.WorldItem.WorldHandlers
{
    public class LockedDoor : ICollider
    {
        private Rectangle hitbox;

        public LockedDoor(string direction, int screenWidth, int screenHeight)
        {
            int doorWidth = RoomTextureStorage.DOOR_SIDE;
            int doorHeight = RoomTextureStorage.DOOR_SIDE;
            int ymid = (screenHeight / 2) - (doorHeight / 2) + 1;
            int xmid = (screenWidth / 2) - (doorWidth / 2);

            int THICKNESS = 30;

            switch (direction)
            {
                case "top":
                    hitbox = new Rectangle(xmid, 0, doorWidth, THICKNESS);
                    break;
                case "bottom":
                    hitbox = new Rectangle(xmid, screenHeight - THICKNESS, doorWidth, THICKNESS);
                    break;
                case "left":
                    hitbox = new Rectangle(0, ymid, THICKNESS, doorHeight);
                    break;
                case "right":
                    hitbox = new Rectangle(screenWidth - THICKNESS, ymid, THICKNESS, doorHeight);
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
