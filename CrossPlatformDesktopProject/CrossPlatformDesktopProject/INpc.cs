using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public interface INpc
    {
        void Draw(Texture2D img, SpriteBatch spriteBatch, Vector2 vector);
        void Update();
    }
    //test test test
}
