using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.Commands;

namespace CrossPlatformDesktopProject
{
    public interface ILinkState
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void setTextureIndex(int index);
        void TakeDamage();
        void Update();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void UsePrimary();
        void UseSecondary();
    }
}
