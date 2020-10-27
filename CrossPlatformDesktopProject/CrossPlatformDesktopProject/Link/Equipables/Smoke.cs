using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link.Equipables
{
    public class Smoke : ICollider
    {
        private Rectangle position;
        public Smoke(Rectangle position)
        {
            this.position = position;
        }

        Rectangle ICollider.GetRectangle()
        {
            return position;
        }
    }
}
