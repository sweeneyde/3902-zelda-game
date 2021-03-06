﻿using System;
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

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getDamageTexture(my_texture_index);
            Rectangle source = LinkTextureStorage.LINK_SWORD_SOUTH;
            player.DrawSprite(spriteBatch, texture, source);
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
        void ILinkState.TakeDamage()
        {
            player.link_health--;
            player.currentState = new LinkKnockedNorth(player);
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

        public void UseSecondary() { }
        void ILinkState.PickUp(IWorldItem contentOfChest) { }
    }
}
