using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStates
{
    public class HUDWindow
    {
        private Player myPlayer;
        private Game myGame;
        private InventoryManager myInv;
        private Texture2D texture;
        private Texture2D emptyTexture;

        //Player info
        private int max_health = 6;
        private int health;
        private int rupeeCount;
        private int bombCount;
        private int keyCount;
        public HUDWindow(Player player, Game game)
        {
            myPlayer = player;
            myGame = game;
            myInv = player.linkInventory;
            rupeeCount = bombCount = keyCount = 0;

            emptyTexture = new Texture2D(myGame.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            emptyTexture.SetData<Color>(new Color[] { Color.Black });
        }

        public void Update()
        {
            health = 5;
            rupeeCount = myInv.rupeeCount;
            bombCount = myInv.bombCount;
            keyCount = myInv.keyCount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = HUDTextureStorage.Instance.texture;
            //Draw HUD Outline
            Rectangle Destination = new Rectangle(0, 0, HUDTextureStorage.WIDTH, HUDTextureStorage.HEIGHT);
            spriteBatch.Draw(texture, Destination, HUDTextureStorage.HUD_WINDOW, Color.White);

            DrawEquipped(spriteBatch, texture);
            DrawItems(spriteBatch, texture);
            DrawHealth(spriteBatch, texture);
        }

        public void DrawItems(SpriteBatch sb, Texture2D texture)
        {
            int windowXOffset = HUDTextureStorage.ITEM_WINDOW_OFFSET_X;
            int tokenHeight = HUDTextureStorage.TOKEN_HEIGHT;
            int tokenWidth = HUDTextureStorage.TOKEN_WIDTH;
            int[] itemCounts = { rupeeCount, bombCount, keyCount };
            int[] itemOffsets = { HUDTextureStorage.RUPEE_WINDOW_OFFSET_Y, HUDTextureStorage.BOMB_WINDOW_OFFSET_Y, HUDTextureStorage.KEY_WINDOW_OFFSET_Y };

            //Draw Rupees, Keys, Bombs
            for (int i = 0; i < itemCounts.Length; i++)
            {
                int yOffset = itemOffsets[i];
                Rectangle xDestination = new Rectangle(windowXOffset, yOffset, tokenWidth + 1, tokenHeight);
                Rectangle tensDestination = new Rectangle(windowXOffset + tokenWidth, yOffset, tokenWidth + 1, tokenHeight);
                Rectangle onesDestination = new Rectangle(windowXOffset + 2 * tokenWidth, yOffset, tokenWidth + 1, tokenHeight);

                sb.Draw(texture, xDestination, HUDTextureStorage.X_TOKEN, Color.White);
                sb.Draw(texture, tensDestination, HUDTextureStorage.getTensToken(itemCounts[i]), Color.White);
                sb.Draw(texture, onesDestination, HUDTextureStorage.getOnesToken(itemCounts[i]), Color.White);
            }
        }
        public void DrawEquipped(SpriteBatch sb, Texture2D texture)
        {
            Type eType;
            String name;
            if(myInv.equippedItem != null)
            {
                eType = myInv.equippedItem.GetType();
                name = eType.Name;
            }
            else{ name = "empty";}
            //Draw empty space
            Rectangle source;
            sb.Draw(emptyTexture, HUDTextureStorage.ITEM_SLOT_B, Color.White);
            sb.Draw(emptyTexture, HUDTextureStorage.ITEM_SLOT_A, Color.White);

            switch (name)
            {
                case "Boomerang":
                    source = HUDTextureStorage.BOOMERANG;
                    break;
                case "Bow":
                    source = HUDTextureStorage.BOW;
                    break;
                case "Bomb":
                    source = HUDTextureStorage.BOMB;
                    break;
                default:
                    source = HUDTextureStorage.EMPTY_ITEM;
                    break;
            }
            sb.Draw(texture, HUDTextureStorage.ITEM_SLOT_B, source, Color.White);
            sb.Draw(texture, HUDTextureStorage.ITEM_SLOT_A, HUDTextureStorage.SWORD, Color.White);
        }
        public void DrawHealth(SpriteBatch sb, Texture2D texture)
        {
            int i = 0, index = 0;
            int offsetX = HUDTextureStorage.HEALTH_OFFSET_X;
            int offsetY = HUDTextureStorage.HEALTH_OFFSET_Y;
            int tokenSize = HUDTextureStorage.TOKEN_HEIGHT;
            sb.Draw(emptyTexture, HUDTextureStorage.HEALTH_BAR, Color.White);
            for (i = 0; i < health/2; i++)
            {
                Rectangle destination = new Rectangle(offsetX + i * tokenSize, offsetY, tokenSize, tokenSize);
                sb.Draw(texture, destination, HUDTextureStorage.FULL_HEART, Color.White);
            }
            if (health % 2 == 1)
            {
                Rectangle destination = new Rectangle(offsetX + i * tokenSize, offsetY, tokenSize, tokenSize);
                sb.Draw(texture, destination, HUDTextureStorage.HALF_HEART, Color.White);
                index = i + 1;
            }
            for (i = index; i < max_health/2; i++)
            {
                Rectangle destination = new Rectangle(offsetX + i * tokenSize, offsetY, tokenSize, tokenSize);
                sb.Draw(texture, destination, HUDTextureStorage.EMPTY_HEART, Color.White);
            }
        }
    }
}
