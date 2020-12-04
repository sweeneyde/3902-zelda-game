using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonDeath : INpcState
    {
        private Skeleton skeleton;

        public SkeletonDeath(Skeleton skeleton)
        {
            this.skeleton = skeleton;

            skeleton.myGame.collisionManager.removeNPC(skeleton);
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos) // make sure to set source = transparent frame if counter has been reached
        {
        }

        public void Update()
        {
        }

        public void TakeDamage()
        {
        }

        public void ChangeDirection()
        {
        }
    }
}