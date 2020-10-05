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
    class LinkSword1West : ILinkState
    {
        private Player player;
        private int frames_left;
        private int my_texture_index;
        public LinkSword1West(Player player)
        {
            this.player = player;
            this.frames_left = Player.frames_for_sword;
            my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getMirroredDamageTexture(my_texture_index);
            Rectangle source = LinkTextureStorage.MIRRORED_LINK_SWORD_WEST;
            player.DrawSprite(spriteBatch, texture, source, -33, 0);
        }

        void ILinkState.Update()
        {
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingWestState(player);
            }
        }

        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
        }

        void ILinkState.TakeDamage()
        {
            player.currentState = new LinkKnockedEast(player);
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

        public void UseSecondary1()
        {
        }

        public void UseSecondary2()
        {
        }

        public void UseSecondary3()
        {
        }
    }
}
