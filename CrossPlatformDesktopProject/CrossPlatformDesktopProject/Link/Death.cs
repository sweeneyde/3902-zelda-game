using System;
using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.GameStates;

namespace CrossPlatformDesktopProject.Link
{
	public class Death : ILinkState
	{
        private Player player;
        private Vector2 currentPos;
        private Game1 myGame;
        private SpriteFont myFont;
        private float playerX;
        private float playerY;
        private int my_frame_index;
        private int delay_frame_index;
        private int delay_frames;
        private int times_spun;

        private static List<Rectangle> my_source_frames = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_SOUTH,
            LinkTextureStorage.LINK_IDLE_EAST,
            LinkTextureStorage.LINK_IDLE_NORTH,
            LinkTextureStorage.MIRRORED_LINK_IDLE_WEST
        };

        public Death(Player player, Game1 game, SpriteFont font)
		{
            this.player = player;
            this.myGame = game;
            this.playerX = player.xPos;
            this.playerY = player.yPos;
            this.myFont = font;
            currentPos = new Vector2(playerX, playerY);
            my_frame_index = 0;
            delay_frame_index = 0;
            delay_frames = 5;
            times_spun = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination;
            destination = new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width, source.Height);
            //spriteBatch.Draw(texture, destination, source, Color.White);
            player.DrawSprite(spriteBatch, texture, source);
        }

        public void Update()
        {
            delay_frame_index++;
            if (delay_frame_index >= delay_frames)
            {
                my_frame_index++;
                delay_frame_index = 0;
            }
            if (my_frame_index > 3)
            {
                my_frame_index = 0;
                times_spun++;
            }
            if (times_spun == 4)
            {
                myGame.currentState = new DeathMenuState(myGame, myFont);
            }
        }

        public void setTextureIndex(int index) { }
        public void TakeDamage() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UsePrimary() { }
        public void UseSecondary() { }
    }
}