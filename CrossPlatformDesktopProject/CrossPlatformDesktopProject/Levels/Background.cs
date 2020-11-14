using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        private int doorSize;

        private string roomTextureID;
        private Rectangle topDoorDest;
        private Rectangle leftDoorDest;
        private Rectangle rightDoorDest;
        private Rectangle bottomDoorDest;

        public Background(Game1 game, string texture) 
        {

            screenWidth = RoomTextureStorage.BORDER_WIDTH;
            screenHeight = RoomTextureStorage.BORDER_HEIGHT;
            innerWidth = RoomTextureStorage.ROOM_WIDTH;
            innerHeight = RoomTextureStorage.ROOM_HEIGHT;
            destinationHeight = (screenHeight - innerHeight) / 2;
            destinationWidth = (screenWidth - innerWidth) / 2;
            roomTextureID = texture;

            doorSize = RoomTextureStorage.DOOR_SIDE;

            //screenWidth - (doorWidth / 2)= 7
            topDoorDest = new Rectangle((screenWidth / 2) - (doorSize / 2), 0, doorSize, doorSize);
            leftDoorDest = new Rectangle(0, (screenHeight / 2) - (doorSize / 2), doorSize, doorSize);
            rightDoorDest = new Rectangle(screenWidth - doorSize, (screenHeight / 2) - (doorSize / 2), doorSize, doorSize);
            bottomDoorDest = new Rectangle((screenWidth / 2) - (doorSize / 2), screenHeight - doorSize, doorSize, doorSize);
        }

        public void Draw(SpriteBatch sb)
        {
            Texture2D texture = RoomTextureStorage.Instance.getRoomSpriteSheet();

            Rectangle borderSource = RoomTextureStorage.BORDER;
            Rectangle borderDestination = new Rectangle(0, 0, screenWidth, screenHeight);
            sb.Draw(texture, borderDestination, borderSource, Color.White);

            DoorCheck(sb, Map.adjacencies[roomTextureID], texture);

            //Recover source image from CSV string
            Rectangle source = RoomTextureStorage.ROOM_RECTS[roomTextureID];
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
