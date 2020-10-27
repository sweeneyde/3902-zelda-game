
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public interface IWorldItem : ICollider
    {
        void Draw(SpriteBatch spriteBatch);
    }
}