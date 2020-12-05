using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.GameStates
{
    public class InventoryState : IGameState
    {
        Player player;
        Game1 game;

        private static List<EquippedEnum> item_kinds = new List<EquippedEnum>()
        {
            EquippedEnum.bomb, EquippedEnum.boomerang, EquippedEnum.bow, EquippedEnum.none
        };
        private Texture2D emptyTexture;
        private Boolean[] player_has_item;
        private int item_index;
        private int framecount;
        private IGameState previousState;
        public InventoryState(Game1 game, IGameState pvsState)
        {
            this.game = game;
            previousState = pvsState;
            game.currentHUD.activate(false);
            this.player = game.player;
            this.item_index = item_kinds.FindIndex(x => x == player.currentlyEquipped);
            if (item_index == -1) { throw new ArgumentException(); }
            player_has_item = new Boolean[]
            {
                player.linkInventory.inventory.Contains(typeof(Bomb)), // if player can equip bomb
                player.linkInventory.inventory.Contains(typeof(Boomerang)), // if player can equip boomerang
                player.linkInventory.inventory.Contains(typeof(Bow)), // if player can equip bow
                true, // if player can equip none
            };
            emptyTexture = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            emptyTexture.SetData<Color>(new Color[] { Color.Black });
        }

        static List<List<int>> room_map = new List<List<int>>
        {
            // bits are presence of top, bottom, left, right door
            new List<int> { 0b0000, 0b0000, 0b0000, 0b0000,   0b0000, 0b0000, 0b0000, 0b0000},
            new List<int> { 0b0000, 0b0000, 0b0000, 0b0000,   0b0000, 0b0000, 0b0000, 0b0000},
            new List<int> { 0b0000, 0b0000, 0b0001, 0b0110,   0b0000, 0b0000, 0b0000, 0b0000},
            new List<int> { 0b0000, 0b0000, 0b0000, 0b1100,   0b0000, 0b0101, 0b0010, 0b0000},
            new List<int> { 0b0000, 0b0001, 0b0111, 0b1011,   0b0011, 0b1010, 0b0000, 0b0000},
            new List<int> { 0b0000, 0b0000, 0b1001, 0b0111,   0b0010, 0b0000, 0b0000, 0b0000},
            new List<int> { 0b0000, 0b0000, 0b0000, 0b1100,   0b0000, 0b0000, 0b0000, 0b0000},
            new List<int> { 0b0000, 0b0000, 0b0001, 0b1011,   0b0010, 0b0000, 0b0000, 0b0000},
        };

        static Dictionary<string, int[]> key_to_pos = new Dictionary<string, int[]>{
            ["001"] = new int[] { 7, 3 },
            ["002"] = new int[] { 7, 4 },
            ["003"] = new int[] { 7, 2 },
            ["004"] = new int[] { 6, 3 },
            ["005"] = new int[] { 5, 3 },
            ["006"] = new int[] { 5, 4 },
            ["007"] = new int[] { 4, 4 },
            ["008"] = new int[] { 4, 5 },
            ["009"] = new int[] { 3, 5 },
            ["010"] = new int[] { 3, 6 },
            ["011"] = new int[] { 5, 2 },
            ["012"] = new int[] { 4, 2 },
            ["013"] = new int[] { 4, 1 },
            ["014"] = new int[] { 4, 3 },
            ["015"] = new int[] { 3, 3 },
            ["016"] = new int[] { 2, 3 },
            ["017"] = new int[] { 2, 2 },
            ["018"] = new int[] { 0, 0 },

        };

        public void Draw(SpriteBatch sb)
        {
            Texture2D texture = InventoryTextureStorage.Instance.texture;

            // first draw the big blocks.            
            Rectangle[] sources = {
                InventoryTextureStorage.TOP_THIRD,
                InventoryTextureStorage.MIDDLE_THIRD,
                InventoryTextureStorage.BOTTOM_THIRD,
            };
            int top_y = -sources[2].Height;
            Rectangle[] destinations = {
                new Rectangle(
                    0,
                    top_y,
                    sources[0].Width,
                    sources[0].Height
                ),
                new Rectangle(
                    0,
                    top_y + sources[0].Height,
                    sources[1].Width,
                    sources[1].Height
                ),
                new Rectangle(
                    0,
                    top_y + sources[0].Height + sources[1].Height,
                    sources[2].Width,
                    sources[2].Height
                ),
            };

            for (int i=0; i<sources.Length; i++)
            {
                sb.Draw(texture, destinations[i], sources[i], Color.White);
            }

            int squaresize = InventoryTextureStorage.getDoorSetRectangle(room_map[0][0]).Width;
            const int base_x = 128;
            const int base_y = 40;

            // now draw the map
            {
                sb.Draw(
                    texture,
                    new Rectangle(
                        base_x - 1,
                        base_y - 1,
                        8 * squaresize + 2,
                        8 * squaresize + 2
                    ),
                    InventoryTextureStorage.getDoorSetRectangle(0),
                    Color.White
                );
                for (int i=0; i<room_map.Count; i++)
                {
                    var row = room_map[i];
                    for (int j=0; j<row.Count; j++)
                    {
                        Rectangle source = InventoryTextureStorage.getDoorSetRectangle(row[j]);
                        Rectangle destination = new Rectangle(
                            base_x + source.Width * j,
                            base_y + source.Height * i,
                            source.Width, source.Height
                        );
                        sb.Draw(texture, destination, source, Color.White);
                    }
                }
            }

            // now draw the point on the map
            {
                string roomID = game.currentGamePlayState.CurrentRoom.roomID;
                var pair = key_to_pos[roomID];
                int i = pair[0], j = pair[1];
                Rectangle source = InventoryTextureStorage.YOU_ARE_HERE;
                Rectangle destination = new Rectangle(
                    base_x + squaresize * j + squaresize / 2 - source.Width / 2,
                    base_y + squaresize * i + squaresize / 2 - source.Height / 2,
                    source.Width, source.Height
                );
                sb.Draw(texture, destination, source, Color.White);
            }

            // if (player has map)
            {
                Rectangle source = InventoryTextureStorage.MAP;
                Rectangle destination = new Rectangle(
                    48,
                    destinations[1].Y + 24,
                    source.Width, source.Height
                );
                sb.Draw(texture, destination, source, Color.White);
            }

            // if (player has compass)
            {
                Rectangle source = InventoryTextureStorage.COMPASS;
                Rectangle destination = new Rectangle(
                    44,
                    destinations[1].Y + 64,
                    source.Width, source.Height
                );
                sb.Draw(texture, destination, source, Color.White);
            }

            // if (player has bombs)
            if (player_has_item[0])
            {
                Rectangle source = InventoryTextureStorage.BOMB;
                Rectangle destination = new Rectangle(
                    130,
                    destinations[0].Y + 47,
                    source.Width, source.Height
                );
                sb.Draw(texture, destination, source, Color.White);
            }

            // if (player has boomerang)
            if (player_has_item[1])
            {
                Rectangle source = InventoryTextureStorage.BOOMERANG;
                Rectangle destination = new Rectangle(
                    156,
                    destinations[0].Y + 47,
                    source.Width, source.Height
                );
                sb.Draw(texture, destination, source, Color.White);
            }

            // if (player has bow)
            if (player_has_item[2])
            {
                Rectangle source = InventoryTextureStorage.BOW;
                Rectangle destination = new Rectangle(
                    180,
                    destinations[0].Y + 47,
                    source.Width, source.Height
                );
                sb.Draw(texture, destination, source, Color.White);
            }

            // draw the selected item
            {
                Rectangle destination = new Rectangle(
                    68,
                    destinations[0].Y + 47,
                    InventoryTextureStorage.BOMB.Width,
                    InventoryTextureStorage.BOMB.Height
                );
                Rectangle source;
                switch (player.currentlyEquipped)
                {
                    case EquippedEnum.bomb:
                        source = InventoryTextureStorage.BOMB;
                        break;
                    case EquippedEnum.boomerang:
                        source = InventoryTextureStorage.BOOMERANG;
                        break;
                    case EquippedEnum.bow:
                        source = InventoryTextureStorage.BOW;
                        break;
                    default:
                        source = HUDTextureStorage.EMPTY_ITEM;
                        break;
                }
                sb.Draw(texture, destination, source, Color.White);
            }

            // draw the cursor
            {
                Rectangle source = (framecount / 8) % 2 == 0
                    ? InventoryTextureStorage.BLUE_CURSOR
                    : InventoryTextureStorage.RED_CURSOR;
                Rectangle destination = new Rectangle(
                    128 + item_index * 24,
                    -9,
                    source.Width, source.Height
                    );
                sb.Draw(texture, destination, source, Color.White);
            }

            // HUD Elements
            int yOffsetHUD = 118;
            {
                int windowXOffset = HUDTextureStorage.ITEM_WINDOW_OFFSET_X;
                int tokenHeight = HUDTextureStorage.TOKEN_HEIGHT;
                int tokenWidth = HUDTextureStorage.TOKEN_WIDTH;
                int[] itemCounts = { player.linkInventory.rupeeCount, player.linkInventory.bombCount, player.linkInventory.keyCount };
                int[] itemOffsets = { HUDTextureStorage.RUPEE_WINDOW_OFFSET_Y, HUDTextureStorage.BOMB_WINDOW_OFFSET_Y, HUDTextureStorage.KEY_WINDOW_OFFSET_Y };

                //Draw Rupees, Keys, Bombs
                for (int k = 0; k < itemCounts.Length; k++)
                {
                    int yOffset = itemOffsets[k] + yOffsetHUD;
                    Rectangle xDestination = new Rectangle(windowXOffset, yOffset, tokenWidth + 1, tokenHeight);
                    Rectangle tensDestination = new Rectangle(windowXOffset + tokenWidth, yOffset, tokenWidth + 1, tokenHeight);
                    Rectangle onesDestination = new Rectangle(windowXOffset + 2 * tokenWidth, yOffset, tokenWidth + 1, tokenHeight);

                    sb.Draw(texture, xDestination, HUDTextureStorage.X_TOKEN, Color.White);
                    sb.Draw(texture, tensDestination, HUDTextureStorage.getTensToken(itemCounts[k]), Color.White);
                    sb.Draw(texture, onesDestination, HUDTextureStorage.getOnesToken(itemCounts[k]), Color.White);
                }


                //Draw item slots
                Rectangle source;
                switch (item_index)
                {
                    case 1:
                        source = HUDTextureStorage.BOOMERANG;
                        break;
                    case 2:
                        source = HUDTextureStorage.BOW;
                        break;
                    case 0:
                        source = HUDTextureStorage.BOMB;
                        break;
                    default:
                        source = HUDTextureStorage.EMPTY_ITEM;
                        break;
                }
                
                Rectangle slotB = HUDTextureStorage.ITEM_SLOT_B;
                Rectangle destinationB = new Rectangle(slotB.X, slotB.Y + yOffsetHUD, slotB.Width, slotB.Height);
                sb.Draw(emptyTexture, destinationB, Color.White);
                sb.Draw(texture, destinationB, source, Color.White);
                Rectangle slotA = HUDTextureStorage.ITEM_SLOT_A;
                Rectangle destinationA = new Rectangle(slotA.X, slotA.Y + yOffsetHUD, slotA.Width, slotA.Height);
                sb.Draw(emptyTexture, destinationA, Color.White);
                sb.Draw(texture, destinationA, HUDTextureStorage.SWORD, Color.White);

                //Draw health
                int i = 0, index = 0;
                int offsetX = HUDTextureStorage.HEALTH_OFFSET_X;
                int offsetY = HUDTextureStorage.HEALTH_OFFSET_Y + yOffsetHUD;
                int tokenSize = HUDTextureStorage.TOKEN_HEIGHT;
                sb.Draw(emptyTexture, HUDTextureStorage.HEALTH_BAR, Color.White);
                for (i = 0; i < (player.link_max_health) / 2; i++)
                {
                    Rectangle destination = new Rectangle(offsetX + i * tokenSize, offsetY, tokenSize, tokenSize);
                    sb.Draw(texture, destination, HUDTextureStorage.EMPTY_HEART, Color.White);
                }
                for (i = 0; i < player.link_health / 2; i++)
                {
                    Rectangle destination = new Rectangle(offsetX + i * tokenSize, offsetY, tokenSize, tokenSize);
                    sb.Draw(texture, destination, HUDTextureStorage.FULL_HEART, Color.White);
                    index = i + 1;
                }
                if (player.link_health % 2 == 1)
                {
                    Rectangle destination = new Rectangle(offsetX + index * tokenSize, offsetY, tokenSize, tokenSize);
                    sb.Draw(texture, destination, HUDTextureStorage.HALF_HEART, Color.White);
                }
            }
        }

        public void CursorLeft()
        {
            int n = player_has_item.Length;
            int item_index_0 = item_index;
            do
            {
                item_index += n - 1;
                item_index %= n;
                if (item_index == item_index_0)
                {
                    // no items
                    return;
                }
            } while (!player_has_item[item_index]);
            player.currentlyEquipped = item_kinds[item_index];
        }

        public void CursorRight()
        {
            int n = player_has_item.Length;
            int item_index_0 = item_index;
            do
            {
                item_index += 1;
                item_index %= n;
                if (item_index == item_index_0)
                {
                    // no items
                    return;
                }
            } while (!player_has_item[item_index]);
            player.currentlyEquipped = item_kinds[item_index];
        }

        private int keypressCooldown = 10;
        public void Update()
        {
            framecount++;
            if (keypressCooldown > 0)
            {
                keypressCooldown--;
                return;
            }

            var keys = new HashSet<Keys>(Keyboard.GetState().GetPressedKeys());
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            if (keys.Contains(Keys.Enter) || state.IsButtonDown(Buttons.X))
            {
                game.currentState = previousState;
                game.currentHUD.activate(true);
                return;
            }

            if (keys.Contains(Keys.Left) || state.ThumbSticks.Left.X < -0.5f || state.IsButtonDown(Buttons.DPadLeft))
            {
                keypressCooldown = 10;
                CursorLeft();
                return;
            }

            if (keys.Contains(Keys.Right) || state.ThumbSticks.Left.X > 0.5f || state.IsButtonDown(Buttons.DPadRight))
            {
                keypressCooldown = 10;
                CursorRight();
                return;
            }
        }
    }
}
