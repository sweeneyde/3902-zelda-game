using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingNorthState : ILinkState
    {
        private Player player;
        private int frames_left;
        private static List<Rectangle> my_sources = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_NORTH,
            LinkTextureStorage.LINK_STEP_NORTH,
        };
        private int my_source_index;
        private int my_texture_index;

        public LinkFacingNorthState(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
            my_source_index = 0;
            my_texture_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getDamageTexture(my_texture_index);
            Rectangle source = my_sources[my_source_index];
            player.DrawSprite(spriteBatch, texture, source);
        }

        void ILinkState.Update()
        {
        }
        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
        }
        void ILinkState.TakeDamage()
        {
            player.link_health--;
            player.currentState = new LinkKnockedSouth(player);
        }

        public void MoveDown()
        {
            player.currentState = new LinkFacingSouthState(player);
        }

        public void MoveLeft()
        {
            player.currentState = new LinkFacingWestState(player);
        }

        public void MoveRight()
        {
            player.currentState = new LinkFacingEastState(player);
        }

        public void MoveUp()
        {
            player.yPos -= Player.walking_speed;
            if (--frames_left <= 0)
            {
                frames_left = Player.frames_per_step;
                my_source_index++;
                my_source_index %= my_sources.Count;
            }
        }

        public void UsePrimary()
        {
            player.currentState = new LinkSword1North(player);
        }

        public void UseSecondary1()
        {
            player.UseBomb();
            player.currentState = new LinkUsingItemNorth(player);
        }

        public void UseSecondary2()
        {
            player.UseBoomerang();
            player.currentState = new LinkUsingItemNorth(player);
        }

        public void UseSecondary3()
        {
            player.UseBow();
            player.currentState = new LinkUsingItemNorth(player);
        }

    }
}
