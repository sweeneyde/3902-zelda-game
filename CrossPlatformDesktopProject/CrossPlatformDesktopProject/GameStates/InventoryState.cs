using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.GameStates
{
    public class InventoryState : IGameState
    {
        Player player;
        public InventoryState(Player player)
        {
            this.player = player;
        }
        public void Draw(SpriteBatch sb)
        {
            Texture2D texture = InventoryTextureStorage.Instance.texture;
            Rectangle[] sources = {
                InventoryTextureStorage.TOP_THIRD,
                InventoryTextureStorage.MIDDLE_THIRD,
                InventoryTextureStorage.BOTTOM_THIRD,
            };

            Rectangle[] destinations = {
                new Rectangle(
                    0,
                    0,
                    sources[0].Width, sources[0].Height
                ),
                new Rectangle(
                    0,
                    sources[0].Height,
                    sources[1].Width,
                    sources[1].Height
                ),
                new Rectangle(
                    0,
                    sources[0].Height + sources[1].Height,
                    sources[2].Width,
                    sources[2].Height
                ),
            };

            for (int i=0; i<sources.Length; i++)
            {
                sb.Draw(texture, destinations[i], sources[i], Color.White);
            }
        }

        public void Update()
        {
        }
    }
}
