using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public interface IGelState
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update();
    }
}
