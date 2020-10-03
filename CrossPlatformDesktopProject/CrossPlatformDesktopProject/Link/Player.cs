using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class Player
    {
        public ILinkState currentState;
        public float xPos, yPos;
        public static float walking_speed = 3.0f;
        public static int frames_per_step = 6;
        public static int frames_for_sword = 18;
        private static int frames_per_damage_color_change = 5;
        private static int damage_frames = 24;

        public static float knockback_speed = 4.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        private int damaged_frames_left;
        private int frames_until_color_change;

        public Player()
        {
            currentState = new LinkFacingSouthState(this);
            xPos = 100;
            yPos = 100;
        }

        public bool IsDamaged()
        {
            return damaged_frames_left > 0;
        }

        public void TakeDamage()
        {
            if (!IsDamaged())
            {
                damaged_frames_left = damage_frames;
                frames_until_color_change = frames_per_damage_color_change;
                currentState.TakeDamage();
            }
        }

        public void MoveDown()
        {
            currentState.MoveDown();
        }

        public void MoveUp()
        {
            currentState.MoveUp();
        }

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }
        public void MoveRight()
        {
            currentState.MoveRight();
        }

        public void UsePrimary()
        {
            currentState.UsePrimary();
        }
        public void UseSecondary()
        {
            currentState.UseSecondary();
        }

        public void Update()
        {
            currentState.Update();
            if (IsDamaged() && --frames_until_color_change == 0)
            {
                frames_until_color_change = frames_per_damage_color_change;
                damaged_frames_left--;
                currentState.setTextureIndex(damaged_frames_left % 4);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }
}
