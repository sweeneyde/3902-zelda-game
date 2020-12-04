using CrossPlatformDesktopProject.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkUsingItemSouth : ILinkState
    {
        private Player player;
        private int frames_left;
        private int my_texture_index;

        public LinkUsingItemSouth(Player player)
        {
            this.player = player;
            frames_left = Player.use_item_frames;
            my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getDamageTexture(my_texture_index);
            Rectangle source = LinkTextureStorage.LINK_USE_ITEM_SOUTH;
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

        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void MoveUp() { }
        public void UsePrimary() { }
        public void UseSecondary() { }

        void ILinkState.PickUp(IWorldItem contentOfChest) { }
    }
}