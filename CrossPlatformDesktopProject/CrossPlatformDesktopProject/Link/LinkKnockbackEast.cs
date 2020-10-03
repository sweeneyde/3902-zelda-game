using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class LinkKnockbackEast : ILinkState
    {
        private Player player;
        private Texture2D my_texture;
        void ILinkState.setTexture(Texture2D texture)
        {
            my_texture = texture;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            throw new NotImplementedException();
        }
        void ILinkState.Update()
        {
        }

        void ILinkState.MoveDown()
        {
        }

        void ILinkState.MoveLeft()
        {
        }

        void ILinkState.MoveRight()
        {
        }

        void ILinkState.MoveUp()
        {
        }

        void ILinkState.UsePrimary()
        {
        }

        void ILinkState.UseSecondary()
        {
        }

    }
}
