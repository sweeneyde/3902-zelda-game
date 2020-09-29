using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    class LinkIdleNorth : ILinkState
    {
        private int my_frame_index;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            LinkTextureStorage.LINK_IDLE_NORTH,
        };
        private Player player;

        public LinkIdleNorth(Player player)
        {
            this.player = player;
            my_frame_index = 0;
        }

        void ILinkState.Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        void ILinkState.Update(ISet<ButtonKind> buttons)
        {
            my_frame_index++;
            my_frame_index %= my_source_frames.Count;
        }
    }
}
