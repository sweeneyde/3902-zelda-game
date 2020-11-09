using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Skeleton : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        private Rectangle hitbox;

        private static int frames_per_damage_color_change = 5;
        private static int damage_frames = 24;

        public static float knockback_speed = 4.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        private int damaged_frames_left;
        private int frames_until_color_change;

        public Skeleton(float xPos, float yPos)
        {
            currentState = new SkeletonWalkEast(this);
            this.xPos = xPos;
            this.yPos = yPos;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Update()
        {
            currentState.Update();
            hitbox = new Rectangle((int)xPos, (int)yPos, 150, 150);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
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

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

    }

}