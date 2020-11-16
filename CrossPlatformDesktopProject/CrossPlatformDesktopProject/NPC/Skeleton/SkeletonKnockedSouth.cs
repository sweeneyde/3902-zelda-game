using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonKnockedSouth : INpcState
    {
        private int my_frame_index = 0;
        private int delay_frame_index = 0;
        private Skeleton skeleton;
        private int frames_left;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.SKELETON_HURT_1,
            //NpcTextureStorage.SKELETON_2
        };

        public SkeletonKnockedSouth(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            this.frames_left = Skeleton.knockback_frames;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getSkeletonGoriyaHurtSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            skeleton.yPos += Skeleton.knockback_speed;
            if (--frames_left <= 0)
            {
                skeleton.currentState = new SkeletonWalkSouth(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
        public void TakeDamage(CollisionSides side)
        {
        }
    }
}
