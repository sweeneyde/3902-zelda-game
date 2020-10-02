using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingSouthState : ILinkState
    {
        private Player player;
        private int frames_left;
        private static List<Rectangle> my_sources = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_SOUTH,
            LinkTextureStorage.LINK_STEP_SOUTH,
        };
        private int my_source_index;

        public LinkFacingSouthState(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
            my_source_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = my_sources[my_source_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update(ISet<ButtonKind> buttons)
        {
            if (buttons.Contains(ButtonKind.PRIMARY))
            {
                player.currentState = new LinkSword1South(player);
            }
            else if (buttons.Contains(ButtonKind.DOWN))
            {
                player.yPos += Player.walking_speed;
                if (--frames_left <= 0)
                {
                    frames_left = Player.frames_per_step;
                    my_source_index++;
                    my_source_index %= my_sources.Count;
                }
            }
            else if (buttons.Contains(ButtonKind.RIGHT))
            {
                player.currentState = new LinkFacingEastState(player);
            }
            else if (buttons.Contains(ButtonKind.UP))
            {
                player.currentState = new LinkFacingNorthState(player);
            }
            else if (buttons.Contains(ButtonKind.LEFT))
            {
                player.currentState = new LinkFacingWestState(player);
            }
        }
    }
}
