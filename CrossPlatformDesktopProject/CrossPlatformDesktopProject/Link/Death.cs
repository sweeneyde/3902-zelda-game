using System;
using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
	public class Death
	{
        private Player player;
        private Vector2 currentPos;
        private Game1 myGame;
        private float usedX;
        private float usedY;
        private int my_frame_index;
        private int delay_frame_index;
        private int delay_frames;
        private int explode_time;
        private int current_frame;
        private int swap_frame;
        private int swap_frame_index;

        private static List<Rectangle> my_source_frames = new List<Rectangle>
        {
            LinkTextureStorage.LINK_IDLE_SOUTH,
            LinkTextureStorage.LINK_IDLE_EAST,
            LinkTextureStorage.LINK_IDLE_NORTH,
            LinkTextureStorage.MIRRORED_LINK_IDLE_WEST
        };

        public Death(Player player, Game1 game)
		{

		}
	}
}