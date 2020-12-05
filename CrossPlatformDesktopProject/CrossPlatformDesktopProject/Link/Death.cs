using System;
using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Sound;

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
        private int first_frame_change_delay;
        private int end_game_frames;
        private int pop_frames;
        private int blank_frames;
        private Boolean changed;
        private Boolean endGame;

        private static List<Rectangle> my_source_frames = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_SOUTH,
            LinkTextureStorage.LINK_IDLE_EAST,
            LinkTextureStorage.LINK_IDLE_NORTH,
            LinkTextureStorage.MIRRORED_LINK_IDLE_WEST,
            LinkTextureStorage.POP,
            LinkTextureStorage.BLANK
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
            first_frame_change_delay = 60;
            changed = false;
            endGame = false;
            end_game_frames = 120;
            pop_frames = 60;
            blank_frames = 70;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination;
            destination = new Rectangle((int)currentPos.X, (int)currentPos.Y, source.Width, source.Height);
            if (my_frame_index == 4)
            {
                player.DrawSprite(spriteBatch, texture, source, 4, 4);
            }
            else
            {
                player.DrawSprite(spriteBatch, texture, source);
            }
        }

        public void Update()
        {
            delay_frame_index++;
            if (delay_frame_index == first_frame_change_delay && !changed)
            {
                changed = true;
                delay_frame_index = 0;
                SoundStorage.Instance.getLinkDieSound().Play();
            }
            if (changed && !endGame)
            {
                if (times_spun == 5)
                {
                    endGame = true;
                    my_frame_index = 0;
                }
                if (delay_frame_index == delay_frames)
                {
                    my_frame_index++;
                    delay_frame_index = 0;
                }
                if (my_frame_index > 3)
                {
                    my_frame_index = 0;
                    times_spun++;
                }
            }
            if (endGame && delay_frame_index == end_game_frames)
            {
                (new DeathStateCommand(myGame)).Execute();
            } else if (endGame && delay_frame_index == pop_frames)
            {
                my_frame_index = 4;
            } else if (endGame && delay_frame_index == blank_frames)
            {
                my_frame_index = 5;
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

        public void PickUp(IWorldItem contentOfChest) { }
    }
}