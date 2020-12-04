using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class LinkShowingItem : ILinkState
    {
        private int my_texture_index;
        private Player player;
        private int frames_left = 85;
        private IWorldItem content;

        public LinkShowingItem(IWorldItem itemToShow, Player player)
        {
            this.player = player;
            content = itemToShow;
            this.my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getDamageTexture(my_texture_index);
            Rectangle source = LinkTextureStorage.LINK_PICKUP_ITEM;
            
            player.DrawSprite(spriteBatch, texture, source);
            content.Draw(spriteBatch);
        }
        void ILinkState.setTextureIndex(int index) { }

        void ILinkState.Update()
        {
            if (--frames_left <= 0)
            {
                // Add item to inventory
                player.linkInventory.ItemPickedUp(content);
                player.currentState = new LinkFacingSouthState(player);
            }
        }

        void ILinkState.TakeDamage() { }
        // Controls are not allowed during pick up sequence.
        void ILinkState.MoveDown() { }
        void ILinkState.MoveLeft() { }
        void ILinkState.MoveRight() { }
        void ILinkState.MoveUp() { }
        void ILinkState.UsePrimary() { }
        void ILinkState.UseSecondary() { }
        void ILinkState.PickUp(IWorldItem contentOfChest) { }

    }
}
