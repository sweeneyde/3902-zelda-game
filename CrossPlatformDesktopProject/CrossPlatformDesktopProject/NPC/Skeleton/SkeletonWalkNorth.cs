using CrossPlatformDesktopProject.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.NPC
{
    class SkeletonWalkNorth : ISkeletonState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Skeleton skeleton;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NpcTextureStorage.SKELETON_1,
            NpcTextureStorage.SKELETON_2
        };

        public SkeletonWalkNorth(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            my_frame_index = 0;
            delay_frame_index = 0;
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
            if (skeleton.xPos == 400 && skeleton.yPos == 100)
            {
                skeleton.currentState = new SkeletonWalkEast(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.yPos -= 5;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}