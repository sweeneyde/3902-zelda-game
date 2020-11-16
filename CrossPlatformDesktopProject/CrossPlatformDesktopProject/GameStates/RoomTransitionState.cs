using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject
{
    class RoomTransitionState : IGameState
    {
        int borderWidth = RoomTextureStorage.BORDER_WIDTH;
        int borderHeight = RoomTextureStorage.BORDER_HEIGHT;
        int roomWidth = RoomTextureStorage.ROOM_WIDTH;
        int roomHeight = RoomTextureStorage.ROOM_HEIGHT;
        int doorSize = RoomTextureStorage.DOOR_SIDE;
        
        Game1 game;
        Room room1, room2;

        int delayLeft;
        int scrolling;
        int scrollSpeed;

        Texture2D texture;
        Rectangle sourceRoom1;
        Rectangle sourceRoom2;
        Rectangle destinationRoom1;
        Rectangle destinationRoom2;
        Rectangle borderDestination1;
        Rectangle borderDestination2;
        Rectangle borderSource;
        Rectangle topDoor1;
        Rectangle rightDoor1;
        Rectangle leftDoor1;
        Rectangle bottomDoor1;
        Rectangle topDoor2;
        Rectangle rightDoor2;
        Rectangle leftDoor2;
        Rectangle bottomDoor2;
        Rectangle topDoorDest1;
        Rectangle leftDoorDest1;
        Rectangle bottomDoorDest1;
        Rectangle rightDoorDest1;
        Rectangle topDoorDest2;
        Rectangle leftDoorDest2;
        Rectangle bottomDoorDest2;
        Rectangle rightDoorDest2;
        
        CollisionSides mySide;

        string[] adjacentRooms1;
        string[] adjacentRooms2;

        public RoomTransitionState(Game1 game, Room room1, Room room2, CollisionSides side)
        {
            this.game = game;
            this.room1 = room1;
            this.room2 = room2;
            mySide = side;

            scrolling = 0;
            scrollSpeed = 2;

            if (side == CollisionSides.Right || side == CollisionSides.Left)
            {
                delayLeft = 130;
            } else 
            {
                delayLeft = 90;
            }

            texture = RoomTextureStorage.Instance.getRoomSpriteSheet();
            sourceRoom1 = RoomTextureStorage.ROOM_RECTS[room1.roomID];
            sourceRoom2 = RoomTextureStorage.ROOM_RECTS[room2.roomID];
            borderSource = RoomTextureStorage.BORDER;

            adjacentRooms1 = Map.adjacencies[room1.roomID];
            adjacentRooms2 = Map.adjacencies[room2.roomID];
            if (adjacentRooms1[0].Equals("-1")) 
            {
                topDoor1 = RoomTextureStorage.TOP_NO_DOOR;
            } else 
            {
                topDoor1 = RoomTextureStorage.TOP_OPEN_DOOR;
            }
            if (adjacentRooms1[1].Equals("-1")) 
            {
                bottomDoor1 = RoomTextureStorage.BOTTOM_NO_DOOR;
            } else 
            {
                bottomDoor1 = RoomTextureStorage.BOTTOM_OPEN_DOOR;
            }
            if (adjacentRooms1[2].Equals("-1")) 
            {
                leftDoor1 = RoomTextureStorage.LEFT_NO_DOOR;
            } else 
            {
                leftDoor1 = RoomTextureStorage.LEFT_OPEN_DOOR;
            }
            if (adjacentRooms1[3].Equals("-1")) 
            {
                rightDoor1 = RoomTextureStorage.RIGHT_NO_DOOR;
            } else 
            {
                rightDoor1 = RoomTextureStorage.RIGHT_OPEN_DOOR;
            }
            
            if (adjacentRooms2[0].Equals("-1")) 
            {
                topDoor2 = RoomTextureStorage.TOP_NO_DOOR;
            } else 
            {
                topDoor2 = RoomTextureStorage.TOP_OPEN_DOOR;
            }
            if (adjacentRooms2[1].Equals("-1")) 
            {
                bottomDoor2 = RoomTextureStorage.BOTTOM_NO_DOOR;
            } else 
            {
                bottomDoor2 = RoomTextureStorage.BOTTOM_OPEN_DOOR;
            }
            if (adjacentRooms2[2].Equals("-1")) 
            {
                leftDoor2 = RoomTextureStorage.LEFT_NO_DOOR;
            } else 
            {
                leftDoor2 = RoomTextureStorage.LEFT_OPEN_DOOR;
            }
            if (adjacentRooms2[3].Equals("-1")) 
            {
                rightDoor2 = RoomTextureStorage.RIGHT_NO_DOOR;
            } else 
            {
                rightDoor2 = RoomTextureStorage.RIGHT_OPEN_DOOR;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, borderDestination1, borderSource, Color.White);
            sb.Draw(texture, borderDestination2, borderSource, Color.White);
            sb.Draw(texture, destinationRoom1, sourceRoom1, Color.White);
            sb.Draw(texture, destinationRoom2, sourceRoom2, Color.White);
            sb.Draw(texture, topDoorDest1, topDoor1, Color.White);
            sb.Draw(texture, bottomDoorDest1, bottomDoor1, Color.White);
            sb.Draw(texture, leftDoorDest1, leftDoor1, Color.White);
            sb.Draw(texture, rightDoorDest1, rightDoor1, Color.White);
            sb.Draw(texture, topDoorDest2, topDoor2, Color.White);
            sb.Draw(texture, bottomDoorDest2, bottomDoor2, Color.White);
            sb.Draw(texture, leftDoorDest2, leftDoor2, Color.White);
            sb.Draw(texture, rightDoorDest2, rightDoor2, Color.White);
            
        }

        public void Update()
        {
            switch (mySide)
            {
                case CollisionSides.Right:
                    borderDestination1 = new Rectangle(scrolling, 0, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(scrolling + borderWidth, 0, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling + borderWidth, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);    
                    topDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2 + scrolling, 0, doorSize, doorSize);
                    leftDoorDest1 = new Rectangle(scrolling, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    bottomDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2 + scrolling, borderHeight - doorSize, doorSize, doorSize);
                    rightDoorDest1 = new Rectangle(borderWidth - doorSize + scrolling, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    topDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2 + borderWidth + scrolling, 0, doorSize, doorSize);
                    leftDoorDest2 = new Rectangle(scrolling + borderWidth, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    bottomDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2 + borderWidth + scrolling, borderHeight - doorSize, doorSize, doorSize);
                    rightDoorDest2 = new Rectangle(borderWidth - doorSize + borderWidth + scrolling, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    scrolling -= scrollSpeed;
                    break;
                case CollisionSides.Left:
                    borderDestination1 = new Rectangle(scrolling, 0, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(scrolling - borderWidth, 0, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling - borderWidth, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    topDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2 + scrolling, 0, doorSize, doorSize);
                    leftDoorDest1 = new Rectangle(scrolling, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    bottomDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2 + scrolling, borderHeight - doorSize, doorSize, doorSize);
                    rightDoorDest1 = new Rectangle(borderWidth - doorSize + scrolling, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    topDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2 - borderWidth + scrolling, 0, doorSize, doorSize);
                    leftDoorDest2 = new Rectangle(scrolling - borderWidth, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    bottomDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2 - borderWidth + scrolling, borderHeight - doorSize, doorSize, doorSize);
                    rightDoorDest2 = new Rectangle(borderWidth - doorSize - borderWidth + scrolling, borderHeight / 2 - doorSize / 2, doorSize, doorSize);
                    scrolling += scrollSpeed;
                    break;
                case CollisionSides.Up:
                    borderDestination1 = new Rectangle(0, scrolling, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(0, scrolling - borderHeight, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling - borderHeight, roomWidth, roomHeight);
                    topDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2, scrolling, doorSize, doorSize);
                    leftDoorDest1 = new Rectangle(0, borderHeight / 2 - doorSize / 2 + scrolling, doorSize, doorSize);
                    bottomDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2, borderHeight - doorSize + scrolling, doorSize, doorSize);
                    rightDoorDest1 = new Rectangle(borderWidth - doorSize, borderHeight / 2 - doorSize / 2 + scrolling, doorSize, doorSize);
                    topDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2, scrolling - borderHeight, doorSize, doorSize);
                    leftDoorDest2 = new Rectangle(0, borderHeight / 2 - doorSize / 2 + scrolling - borderHeight, doorSize, doorSize);
                    bottomDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2, scrolling - doorSize, doorSize, doorSize);
                    rightDoorDest2 = new Rectangle(borderWidth - doorSize, borderHeight / 2 - doorSize / 2 + scrolling - borderHeight, doorSize, doorSize);
                    scrolling += scrollSpeed;
                    break;
                case CollisionSides.Down:
                    borderDestination1 = new Rectangle(0, scrolling, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(0, scrolling + borderHeight, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling + borderHeight, roomWidth, roomHeight);
                    topDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2, scrolling, doorSize, doorSize);
                    leftDoorDest1 = new Rectangle(0, borderHeight / 2 - doorSize / 2 + scrolling, doorSize, doorSize);
                    bottomDoorDest1 = new Rectangle(borderWidth / 2 - doorSize / 2, borderHeight - doorSize + scrolling, doorSize, doorSize);
                    rightDoorDest1 = new Rectangle(borderWidth - doorSize, borderHeight / 2 - doorSize / 2 + scrolling, doorSize, doorSize);
                    topDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2, scrolling + borderHeight, doorSize, doorSize);
                    leftDoorDest2 = new Rectangle(0, borderHeight / 2 - doorSize / 2 + scrolling + borderHeight, doorSize, doorSize);
                    bottomDoorDest2 = new Rectangle(borderWidth / 2 - doorSize / 2, scrolling - doorSize + borderHeight + borderHeight, doorSize, doorSize);
                    rightDoorDest2 = new Rectangle(borderWidth - doorSize, borderHeight / 2 - doorSize / 2 + scrolling + borderHeight, doorSize, doorSize);
                    scrolling -= scrollSpeed;
                    break;
                default:
                    break;
            }



            if (--delayLeft == 0)
            {
                game.currentState = game.currentGamePlayState;
            }
        }
    }
}
