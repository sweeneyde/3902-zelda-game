using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkDeathPart2 : ILinkState
    {
        private Player player;
        private int my_frame_index;
        private int delay_frame_index;

        private static int delay_frames = 6;
        private static List<Rectangle> my_sources = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_EAST,
            LinkTextureStorage.LINK_IDLE_NORTH,
            LinkTextureStorage.LINK_IDLE_SOUTH
        };

        private int my_texture_index;
        public int counter;

        public LinkDeathPart2(Player player)
        {
            this.player = player;
            my_frame_index = 0;
            delay_frame_index = 0;

            counter = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getDamageTexture(my_texture_index);
            Rectangle source = my_sources[my_frame_index];
            player.DrawSprite(spriteBatch, texture, source);
        }

        void ILinkState.Update()
        {
            if (counter == 12)
            {
                //player.currentState = lin
            }

            if (++delay_frame_index >= delay_frames)
            {
                counter++;
                delay_frame_index = 0;
                my_frame_index++;
                my_frame_index %= my_sources.Count;
            }
        }
        void ILinkState.setTextureIndex(int index)
        {
            my_texture_index = index;
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
        void ILinkState.UseSecondary1() { }
        void ILinkState.UseSecondary2() { }
        void ILinkState.UseSecondary3() { }

    }
}
