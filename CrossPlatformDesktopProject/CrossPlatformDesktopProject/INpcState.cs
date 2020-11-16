using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject
{
    public interface INpcState
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update();
        void TakeDamage();
        void ChangeDirection();
    }
}
