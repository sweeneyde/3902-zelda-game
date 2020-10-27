using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.WorldItem.WorldHandlers
{
    public class Door : ICollider
    {
        private Rectangle hitbox;
        public Map myMap { get; private set; }
        public String myRoomKey { get; private set; }
        public Door(Rectangle collider, Map map, String roomCode)
        {
            //x,y is center
            hitbox = collider;
            myMap = map;
            myRoomKey = roomCode;
        }
        public Rectangle GetRectangle()
        {
            return hitbox;
        }
    }
}
