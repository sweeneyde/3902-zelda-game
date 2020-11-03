using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Levels
{
    class RoomTextureStorage : ISpriteFactory
    {
        private static RoomTextureStorage instance = null;

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

        public static Rectangle BORDER = new Rectangle(521, 11, 255, 175);
        public static Dictionary<string, Rectangle> ROOM_RECTS = new Dictionary<string, Rectangle>()
        {
            ["001"] = new Rectangle(196, 192, 191, 111),
            ["002"] = new Rectangle(391, 192, 191, 111),
            ["003"] = new Rectangle(1, 192, 191, 111),
            ["004"] = new Rectangle(586, 192, 191, 111),
            ["005"] = new Rectangle(781, 192, 191, 111),
            ["006"] = new Rectangle(976, 192, 191, 111),
            ["007"] = new Rectangle(781, 192, 191, 111),
            ["008"] = new Rectangle(391, 307, 191, 111),
            ["009"] = new Rectangle(781, 307, 191, 111),
            ["010"] = new Rectangle(976, 307, 191, 111),
            ["011"] = new Rectangle(586, 192, 191, 111),
            ["012"] = new Rectangle(1, 307, 191, 111),
            ["013"] = new Rectangle(976, 882, 191, 111),
            ["014"] = new Rectangle(196, 307, 191, 111),
            ["015"] = new Rectangle(586, 307, 191, 111),
            ["016"] = new Rectangle(196, 422, 191, 111),
            ["017"] = new Rectangle(1, 422, 191, 111),
        };
        public static Rectangle TOP_NO_DOOR = new Rectangle(815, 11, 31, 31);
        public static Rectangle TOP_OPEN_DOOR = new Rectangle(848, 11, 31, 31);
        public static Rectangle BOTTOM_NO_DOOR = new Rectangle(815, 110, 31, 31);
        public static Rectangle BOTTOM_OPEN_DOOR = new Rectangle(848, 110, 31, 31);
        public static Rectangle LEFT_NO_DOOR = new Rectangle(815, 44, 31, 31);
        public static Rectangle LEFT_OPEN_DOOR = new Rectangle(848, 44, 31, 31);
        public static Rectangle RIGHT_NO_DOOR = new Rectangle(815, 77, 31, 31);
        public static Rectangle RIGHT_OPEN_DOOR = new Rectangle(848, 77, 31, 31);

    }
}