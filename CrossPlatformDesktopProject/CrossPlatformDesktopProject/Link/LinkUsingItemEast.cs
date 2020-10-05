using CrossPlatformDesktopProject.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkUsingItemEast : ILinkState
    {
        private Player player;
        private int frames_left;
        private int my_texture_index;

        public LinkUsingItemEast(Player player)
        {
            this.player = player;
            frames_left = Player.use_item_frames;
            my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getDamageTexture(my_texture_index);
            Rectangle source = LinkTextureStorage.LINK_USE_ITEM_EAST;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update()
        {
            if (--frames_left <= 0)
            {
                player.currentState = new LinkFacingEastState(player);
            }
        }

        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
        }
        void ILinkState.TakeDamage()
        {
            player.currentState = new LinkKnockedWest(player);
        }

        public void MoveDown() {}
        public void MoveLeft() {}
        public void MoveRight() {}
        public void MoveUp() {}
        public void UsePrimary() {}
        public void UseSecondary1() {}
        public void UseSecondary2() {}
        public void UseSecondary3() {}
    }
}