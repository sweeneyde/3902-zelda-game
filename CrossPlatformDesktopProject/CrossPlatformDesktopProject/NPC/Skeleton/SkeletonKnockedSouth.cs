using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonKnockedSouth : INpcState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private int counter;
        private int my_texture_index;
        private Skeleton skeleton;
        private int frames_left;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.SKELETON_1,
            NpcTextureStorage.SKELETON_2
        };

        public SkeletonKnockedSouth(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            this.frames_left = Skeleton.knockback_frames;
            this.my_texture_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NpcTextureStorage.Instance.getSkeletonSpriteSheet();
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
        }
        public void TakeDamage()
        {
        }
    }
}
