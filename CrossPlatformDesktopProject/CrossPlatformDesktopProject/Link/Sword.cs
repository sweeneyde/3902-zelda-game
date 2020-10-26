using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class Sword : ICollider
    {
        private Rectangle location;
        public static int LENGTH = 16;
        public static int BREADTH = 8;
        public Sword(Rectangle location)
        {
            this.location = location;
        }

        public Rectangle GetRectangle()
        {
            return location;
        }
    }
}
