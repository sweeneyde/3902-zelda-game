﻿using Microsoft.Xna.Framework;
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
        private int my_texture_index;
        private Player player;
        private int frames_left;

        public LinkKnockedEast(Player player)
        {
            this.player = player;
            this.frames_left = Player.knockback_frames;
            this.my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getMirroredDamageTexture(my_texture_index);
            Rectangle source = LinkTextureStorage.MIRRORED_LINK_IDLE_WEST;
            player.DrawSprite(spriteBatch, texture, source);
        }
        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
        }

        void ILinkState.Update()
        {
            player.xPos += Player.knockback_speed;
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingWestState(player);
            }
        }
        void ILinkState.TakeDamage()
        {
        }

        // Controls are not allowed during knocked state.
        void ILinkState.MoveDown() { }
        void ILinkState.MoveLeft() { }
        void ILinkState.MoveRight() { }
        void ILinkState.MoveUp() { }
        void ILinkState.UsePrimary() { }
        void ILinkState.UseSecondary() { }
        void ILinkState.PickUp(IWorldItem contentOfChest) { }
    }
}
