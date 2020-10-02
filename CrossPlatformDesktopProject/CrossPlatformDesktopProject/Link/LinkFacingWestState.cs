using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkFacingWestState : ILinkState
    {
        private Player player;
        private int frames_left;
        private static List<Rectangle> my_sources = new List<Rectangle>
        {
            LinkTextureStorage.MIRRORED_LINK_IDLE_WEST,
            LinkTextureStorage.MIRRORED_LINK_STEP_WEST,
        };
        private int my_source_index;

        public LinkFacingWestState(Player player)
        {
            this.player = player;
            frames_left = Player.frames_per_step;
            my_source_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheetMirrored();
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
                player.currentState = new LinkSword1West(player);
            }
            if (buttons.Contains(ButtonKind.LEFT))
            {
                player.xPos -= Player.walking_speed;
                if (--frames_left <= 0)
                {
                    frames_left = Player.frames_per_step;
                    my_source_index++;
                    my_source_index %= my_sources.Count;
                }
            }
            else if (buttons.Contains(ButtonKind.DOWN))
            {
                player.currentState = new LinkFacingSouthState(player);
            }
            else if (buttons.Contains(ButtonKind.UP))
            {
                player.currentState = new LinkFacingNorthState(player);
            }
            else if (buttons.Contains(ButtonKind.RIGHT))
            {
                player.currentState = new LinkFacingEastState(player);
            }
        }
    }
}
