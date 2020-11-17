using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using System;
using CrossPlatformDesktopProject.Levels;

namespace CrossPlatformDesktopProject.WorldItem.WorldHandlers
{
    public class Door : ICollider
    {
        private Rectangle hitbox;
        public String TargetRoomKey { get; private set; }
        public float PlayerXPosAfterTravel { get; }
        public float PlayerYPosAfterTravel { get; }

        public Door(string direction, String NextRoomCode, int screenWidth, int screenHeight)
        {
            int doorWidth = RoomTextureStorage.DOOR_SIDE;
            int doorHeight = RoomTextureStorage.DOOR_SIDE;
            int ymid = (screenHeight / 2) - (doorHeight / 2) + 1;
            int xmid = (screenWidth / 2) - (doorWidth / 2);

            TargetRoomKey = NextRoomCode;
            int STEP = 20;
            int LINKSIZE = LinkTextureStorage.LINK_IDLE_EAST.Width;
            int THICKNESS = 5;
            int XMID_LINK = (screenWidth / 2) - (LINKSIZE / 2);
            int YMID_LINK = (screenHeight / 2) - (LINKSIZE / 2);

            switch (direction)
            {
                case "top":
                    hitbox = new Rectangle(xmid, 0, doorWidth, THICKNESS);
                    PlayerXPosAfterTravel = XMID_LINK;
                    PlayerYPosAfterTravel = screenHeight - STEP - LINKSIZE;
                    break;
                case "bottom":
                    hitbox = new Rectangle(xmid, screenHeight - THICKNESS, doorWidth, THICKNESS);
                    PlayerXPosAfterTravel = XMID_LINK;
                    PlayerYPosAfterTravel = STEP;
                    break;
                case "left":
                    hitbox = new Rectangle(0, ymid, THICKNESS, doorHeight);
                    PlayerXPosAfterTravel = screenWidth - STEP - LINKSIZE;
                    PlayerYPosAfterTravel = YMID_LINK;
                    break;
                case "right":
                    hitbox = new Rectangle(screenWidth - THICKNESS, ymid, THICKNESS, doorHeight);
                    PlayerXPosAfterTravel = STEP;
                    PlayerYPosAfterTravel = YMID_LINK;
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
