using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Levels
{
    class RoomTextureStorage : ISpriteFactory
    {
        private static RoomTextureStorage instance = null;
        public const int ROOM_WIDTH = 192;
        public const int ROOM_HEIGHT = 112;
        public const int BORDER_WIDTH = 256;
        public const int BORDER_HEIGHT = 176;
        public const int DOOR_SIDE = 32;

        public static RoomTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomTextureStorage();
                }
                return instance;
            }
        }


        private static Texture2D roomTexture = null;

        private RoomTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            roomTexture = content.Load<Texture2D>("Dungeon Tileset");
        }


        public Texture2D getRoomSpriteSheet()
        {
            return roomTexture;
        }

        public static Rectangle BORDER = new Rectangle(521, 11, BORDER_WIDTH, BORDER_HEIGHT);
        public static Dictionary<string, Rectangle> ROOM_RECTS = new Dictionary<string, Rectangle>()
        {
            ["001"] = new Rectangle(196, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["002"] = new Rectangle(391, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["003"] = new Rectangle(1, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["004"] = new Rectangle(586, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["005"] = new Rectangle(781, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["006"] = new Rectangle(976, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["007"] = new Rectangle(781, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["008"] = new Rectangle(391, 307, ROOM_WIDTH, ROOM_HEIGHT),
            ["009"] = new Rectangle(781, 307, ROOM_WIDTH, ROOM_HEIGHT),
            ["010"] = new Rectangle(976, 307, ROOM_WIDTH, ROOM_HEIGHT),
            ["011"] = new Rectangle(586, 192, ROOM_WIDTH, ROOM_HEIGHT),
            ["012"] = new Rectangle(1, 307, ROOM_WIDTH, ROOM_HEIGHT),
            ["013"] = new Rectangle(976, 882, ROOM_WIDTH, ROOM_HEIGHT),
            ["014"] = new Rectangle(196, 307, ROOM_WIDTH, ROOM_HEIGHT),
            ["015"] = new Rectangle(586, 307, ROOM_WIDTH, ROOM_HEIGHT),
            ["016"] = new Rectangle(196, 422, ROOM_WIDTH, ROOM_HEIGHT),
            ["017"] = new Rectangle(1, 422, ROOM_WIDTH, ROOM_HEIGHT),
        };
        public static Rectangle TOP_NO_DOOR = new Rectangle(815, 11, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle TOP_OPEN_DOOR = new Rectangle(848, 11, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle BOTTOM_NO_DOOR = new Rectangle(815, 110, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle BOTTOM_OPEN_DOOR = new Rectangle(848, 110, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle LEFT_NO_DOOR = new Rectangle(815, 44, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle LEFT_OPEN_DOOR = new Rectangle(848, 44, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle RIGHT_NO_DOOR = new Rectangle(815, 77, DOOR_SIDE, DOOR_SIDE);
        public static Rectangle RIGHT_OPEN_DOOR = new Rectangle(848, 77, DOOR_SIDE, DOOR_SIDE);

    }
}