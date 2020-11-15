using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        int scrollSpeed;

        public RoomTransitionState(Game1 game, Room room1, Room room2)
        {
            this.game = game;
            this.room1 = room1;
            this.room2 = room2;
            scrolling = 0;
            delayLeft = 112;
            screenshot = GameScreenTextureStorage.Instance.screenshot;
            texture = RoomTextureStorage.Instance.getRoomSpriteSheet();
            sourceRoom1 = RoomTextureStorage.ROOM_RECTS[room1.roomID];
            sourceRoom2 = RoomTextureStorage.ROOM_RECTS[room2.roomID];
            scrollSpeed = 2;
        }

        public void Draw(SpriteBatch sb)
        {
            Rectangle borderSource = RoomTextureStorage.BORDER;
            Rectangle borderDestination1 = new Rectangle(scrolling, 0, RoomTextureStorage.BORDER_WIDTH, RoomTextureStorage.BORDER_HEIGHT);
            Rectangle borderDestination2 = new Rectangle(scrolling + (RoomTextureStorage.ROOM_WIDTH + RoomTextureStorage.BORDER_WIDTH) / 2, 0, RoomTextureStorage.BORDER_WIDTH, RoomTextureStorage.BORDER_HEIGHT);
            destinationRoom1 = new Rectangle((RoomTextureStorage.BORDER_WIDTH - RoomTextureStorage.ROOM_WIDTH) / 2 + scrolling, (RoomTextureStorage.BORDER_HEIGHT - RoomTextureStorage.ROOM_HEIGHT) / 2, RoomTextureStorage.ROOM_WIDTH, RoomTextureStorage.ROOM_HEIGHT);
            destinationRoom2 = new Rectangle((RoomTextureStorage.BORDER_WIDTH - RoomTextureStorage.ROOM_WIDTH) / 2 + scrolling + (RoomTextureStorage.ROOM_WIDTH + RoomTextureStorage.BORDER_WIDTH) / 2, (RoomTextureStorage.BORDER_HEIGHT - RoomTextureStorage.ROOM_HEIGHT) / 2, RoomTextureStorage.ROOM_WIDTH, RoomTextureStorage.ROOM_HEIGHT);
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
            scrolling -= scrollSpeed;
            
        }
    }
}
