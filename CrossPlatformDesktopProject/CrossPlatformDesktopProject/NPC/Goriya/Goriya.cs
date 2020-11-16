using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.NPC
{
    class Goriya : INpc
    {
        public INpcState currentState;
        public float xPos, yPos;
        public Rectangle hitbox;
        public GoriyaBoomerang boomerang;

        private static int frames_per_damage_color_change = 4;
        public static float knockback_speed = 2.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        public Goriya(float xPos, float yPos, GoriyaBoomerang boomerang)
        {
            this.boomerang = boomerang;

            currentState = new GoriyaWalkEast(this, boomerang);
            this.xPos = xPos;
            this.yPos = yPos;
            hitbox = new Rectangle((int)xPos, (int)yPos, 0, 0);
        }

        public void Update()
        {
            currentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void TakeDamage(CollisionSides side)
        {
            currentState.TakeDamage(side);
        }

        public Rectangle GetRectangle()
        {
            return hitbox;
        }

        public void ChangeDirection()
        {
            currentState.ChangeDirection();
        }
    }

}