using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Levels
{
    class Background
    {
        private int screenWidth;
        private int screenHeight;
        private int innerWidth;
        private int innerHeight;
        private int destinationWidth;
        private int destinationHeight;
        private int doorWidth;
        private int doorHeight;
        private string roomTextureID;
        private Rectangle topDoorDest;
        private Rectangle leftDoorDest;
        private Rectangle rightDoorDest;
        private Rectangle bottomDoorDest;

        public Background(Game1 game, string texture) 
        {
            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
            innerWidth = (screenWidth * 191) / 255 + 6;
            innerHeight = (screenHeight * 111) / 175 + 6;
            destinationHeight = (screenHeight - innerHeight) / 2 + 1;
            destinationWidth = (screenWidth - innerWidth) / 2 + 1;
            roomTextureID = texture;

            doorWidth = (screenWidth * 31) / 255;
            doorHeight = (screenHeight * 31) / 175;
            //screenWidth - (doorWidth / 2)= 7
            topDoorDest = new Rectangle((screenWidth/2) - (doorWidth / 2), 0, doorWidth, doorHeight);
            leftDoorDest = new Rectangle(0, (screenHeight / 2) - (doorHeight / 2) + 1, doorWidth, doorHeight);
            rightDoorDest = new Rectangle(screenWidth - doorWidth, (screenHeight / 2) - (doorHeight / 2), doorWidth, doorHeight);
            bottomDoorDest = new Rectangle((screenWidth / 2) - (doorWidth / 2), screenHeight - doorHeight, doorWidth, doorHeight);
        }

        public void Draw(SpriteBatch sb, string[] adjacents)
        {
            RoomTextureStorage textureInstance = RoomTextureStorage.Instance;
            Texture2D texture = textureInstance.getRoomSpriteSheet();

            Rectangle borderSource = RoomTextureStorage.BORDER;
            Rectangle borderDestination = new Rectangle(0, 0, screenWidth, screenHeight);
            sb.Draw(texture, borderDestination, borderSource, Color.White);
            //Recover source image from CSV string

            DoorCheck(sb, adjacents, texture);

            FieldInfo propInfo = typeof(RoomTextureStorage).GetField(roomTextureID);
            object rectType = propInfo.GetValue(typeof(RoomTextureStorage));
            Rectangle source = (Rectangle)rectType;

            Rectangle destination = new Rectangle(destinationWidth, destinationHeight, innerWidth, innerHeight);
            sb.Draw(texture, destination, source, Color.White);
        }

        public void DoorCheck(SpriteBatch sb, string[] adjacentRooms, Texture2D texture)
        {
            if (adjacentRooms[0].Equals("-1"))
            {
                sb.Draw(texture, topDoorDest, RoomTextureStorage.TOP_NO_DOOR, Color.White);
            }
            else
            {
                sb.Draw(texture, topDoorDest, RoomTextureStorage.TOP_OPEN_DOOR, Color.White);
            }

            if (adjacentRooms[1].Equals("-1"))
            {
                sb.Draw(texture, bottomDoorDest, RoomTextureStorage.BOTTOM_NO_DOOR, Color.White);
            }
            else
            {
                sb.Draw(texture, bottomDoorDest, RoomTextureStorage.BOTTOM_OPEN_DOOR, Color.White);
            }

            if (adjacentRooms[2].Equals("-1"))
            {
                sb.Draw(texture, leftDoorDest, RoomTextureStorage.LEFT_NO_DOOR, Color.White);
            }
            else
            {
                sb.Draw(texture, leftDoorDest, RoomTextureStorage.LEFT_OPEN_DOOR, Color.White);
            }

            if (adjacentRooms[3].Equals("-1"))
            {
                sb.Draw(texture, rightDoorDest, RoomTextureStorage.RIGHT_NO_DOOR, Color.White);
            }
            else
            {
                sb.Draw(texture, rightDoorDest, RoomTextureStorage.RIGHT_OPEN_DOOR, Color.White);
            }
        }
    }
}
