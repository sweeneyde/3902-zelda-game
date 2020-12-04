using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.WorldItem.WorldHandlers
{
    public class EmptyRoomNotifier : IWorldItem
    {
        private Rectangle hitbox;

        public EmptyRoomNotifier(float x, float y)
        {
            Rectangle roomSize = RoomTextureStorage.BORDER;
            roomSize.X = 0;
            roomSize.Y = 0;
            hitbox = roomSize;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }
}
