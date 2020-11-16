using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject
{
    class RoomTransitionState : IGameState
    {
        Game1 game;
        Room room1, room2;
        int delayLeft;
        RenderTarget2D screenshot;
        int scrolling;
        Texture2D texture;
        Rectangle sourceRoom1;
        Rectangle sourceRoom2;
        Rectangle destinationRoom1;
        Rectangle destinationRoom2;
        Rectangle borderDestination1;
        Rectangle borderDestination2;
        Rectangle borderSource;
        int scrollSpeed;
        CollisionSides mySide;
        int borderWidth = RoomTextureStorage.BORDER_WIDTH;
        int borderHeight = RoomTextureStorage.BORDER_HEIGHT;
        int roomWidth = RoomTextureStorage.ROOM_WIDTH;
        int roomHeight = RoomTextureStorage.ROOM_HEIGHT;

        public RoomTransitionState(Game1 game, Room room1, Room room2, CollisionSides side)
        {
            this.game = game;
            this.room1 = room1;
            this.room2 = room2;
            scrolling = 0;
            if (side == CollisionSides.Right || side == CollisionSides.Left)
            {
                delayLeft = 112;
            } else 
            {
                delayLeft = 90;
            }
            screenshot = GameScreenTextureStorage.Instance.screenshot;
            texture = RoomTextureStorage.Instance.getRoomSpriteSheet();
            sourceRoom1 = RoomTextureStorage.ROOM_RECTS[room1.roomID];
            sourceRoom2 = RoomTextureStorage.ROOM_RECTS[room2.roomID];
            scrollSpeed = 2;
            mySide = side;
            borderSource = RoomTextureStorage.BORDER;
        }

        public void Draw(SpriteBatch sb)
        {
            switch(mySide) 
            {
                case CollisionSides.Right:
                    borderDestination1 = new Rectangle(scrolling, 0, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(scrolling + (roomWidth + borderWidth) / 2, 0, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling + (roomWidth + borderWidth) / 2, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    break;
                case CollisionSides.Left:
                    borderDestination1 = new Rectangle(scrolling, 0, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(scrolling - (roomWidth + borderWidth) / 2, 0, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2 + scrolling - (roomWidth + borderWidth) / 2, (borderHeight - roomHeight) / 2, roomWidth, roomHeight);
                    break;
                case CollisionSides.Up:
                    borderDestination1 = new Rectangle(0, scrolling, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(0, scrolling - borderHeight, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling - borderHeight, roomWidth, roomHeight);
                    break;
                case CollisionSides.Down:
                    borderDestination1 = new Rectangle(0, scrolling, borderWidth, borderHeight);
                    borderDestination2 = new Rectangle(0, scrolling + borderHeight, borderWidth, borderHeight);
                    destinationRoom1 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling, roomWidth, roomHeight);
                    destinationRoom2 = new Rectangle((borderWidth - roomWidth) / 2, (borderHeight - roomHeight) / 2 + scrolling + borderHeight, roomWidth, roomHeight);
                    break;
                default:
                    break;
            }
            sb.Draw(texture, borderDestination1, borderSource, Color.White);
            sb.Draw(texture, borderDestination2, borderSource, Color.White);
            sb.Draw(texture, destinationRoom1, sourceRoom1, Color.White);
            sb.Draw(texture, destinationRoom2, sourceRoom2, Color.White);
            
        }

        public void Update()
        {
            if (--delayLeft == 0)
            {
                game.currentState = game.currentGamePlayState;
            }
            switch (mySide)
            {
                case CollisionSides.Right:
                    scrolling -= scrollSpeed;
                    break;
                case CollisionSides.Left:
                    scrolling += scrollSpeed;
                    break;
                case CollisionSides.Up:
                    scrolling += scrollSpeed;
                    break;
                case CollisionSides.Down:
                    scrolling -= scrollSpeed;
                    break;
                default:
                    break;
            }
        }
    }
}
