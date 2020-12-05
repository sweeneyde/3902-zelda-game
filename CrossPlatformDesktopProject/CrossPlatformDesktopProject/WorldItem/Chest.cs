using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class Chest : IWorldItem
    {
        public float xPos, yPos;
        public bool IsOpen { get; set; }
        public IWorldItem content;

        private int hitBoxOffset = 1;

        public Chest(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            IsOpen = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source;
            if (IsOpen)
            {
                source = ItemTextureStorage.CHEST_OPEN;
            }
            else
            {
                source = ItemTextureStorage.CHEST_CLOSED;
            }
            spriteBatch.Draw(texture, getRectangle(), source, Color.LightSteelBlue);
        }

        public void putItemInChest(IWorldItem contentOfChest)
        {
            content = contentOfChest;
        }

        public IWorldItem getItemInChest()
        {
            Type resolvedType = content.GetType();
            if (resolvedType.Equals(typeof(DungeonMap)))
            {
                return (DungeonMap)content;
            } else if (resolvedType.Equals(typeof(BowItem)))
            {
                return (BowItem)content;
            } else if (resolvedType.Equals(typeof(BoomerangItem)))
            {
                return (BoomerangItem)content;
            }
            else
            {
                Console.WriteLine("Type of WorldItem is not resolvable. May be unsafe to use.");
                return content;
            }
            
        }

        private Rectangle getRectangle()
        {
            
            return new Rectangle((int)xPos, (int)yPos,
                ItemTextureStorage.CHEST_CLOSED.Width,
                ItemTextureStorage.CHEST_CLOSED.Height);
        }

        Rectangle ICollider.GetRectangle()
        {          
            return getRectangle();
        }
    }
}