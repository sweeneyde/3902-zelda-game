
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public interface IWorldItem : CollisionHandler.ICollider
    {
        void Draw(SpriteBatch spriteBatch);
    }
}