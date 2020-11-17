﻿using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.WorldItem
{
    class DungeonKey : IWorldItem
    {
        public float xPos, yPos;

        public DungeonKey(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ItemTextureStorage.Instance.getItemSpriteSheet();
            Rectangle source = ItemTextureStorage.KEY;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width, source.Height);
            spriteBatch.Draw(texture, getRectangle(), source, Color.White);
        }

        private Rectangle getRectangle()
        {
            return new Rectangle((int)xPos, (int)yPos,
                ItemTextureStorage.KEY.Width,
                ItemTextureStorage.KEY.Height);
        }
        Rectangle ICollider.GetRectangle()
        {
            return getRectangle();
        }

    }
}