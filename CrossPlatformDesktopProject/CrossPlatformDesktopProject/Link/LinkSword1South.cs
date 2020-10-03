using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace CrossPlatformDesktopProject.Link
{
    class LinkSword1South : ILinkState
    {
        private Player player;
        private int frames_left;
        private int my_texture_index;
        public LinkSword1South(Player player)
        {
            this.player = player;
            this.frames_left = Player.frames_for_sword;
            my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getTextures()[my_texture_index];
            Rectangle source = LinkTextureStorage.LINK_SWORD_SOUTH;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update()
        {
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingSouthState(player);
            }
        }

        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }


        public void UsePrimary()
        {
        }

        public void UseSecondary()
        {
        }
    }
}
