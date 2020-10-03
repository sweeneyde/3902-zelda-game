using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class LinkKnockedEast : ILinkState
    {
        private Texture2D my_texture;
        private Player player;

        LinkKnockedEast(Player player)
        {
            this.player = player;
            my_texture = LinkTextureStorage.Instance.linkBlackDamageTexture;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = LinkTextureStorage.Link;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.SetTexture(Texture2D texture)
        {
            my_texture = texture;
        }

        void ILinkState.Update(ISet<ButtonKind> pressedButtons)
        {
            throw new NotImplementedException();
        }
    }
}
