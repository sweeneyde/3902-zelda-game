using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Equipables
{
    class Bow : IEquipable
    {
        private Player player;
        private Vector2 currentPos;
        private float startX;
        private float startY;
        private Vector2 endPoint;
        private Vector2 flight;
        private int delay_frame_index;
        private float arrowTravelDist = 1000f;
        private float arrowSpeed = 50f;
        private bool reachedEnd = false;
        private Texture2D texture;
        private Rectangle source;

        private static int delay_frames = 5;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            LinkTextureStorage.ARROW_EAST,
            LinkTextureStorage.ARROW_WEST,
            LinkTextureStorage.ARROW_SOUTH,
            LinkTextureStorage.ARROW_NORTH
        };

        public Bow(Player player, ButtonKind envokedWith)
        {
            texture = LinkTextureStorage.Instance.getArrowSpriteSheet();
            this.player = player;
            startX = player.xPos;
            startY = player.yPos;
            currentPos = new Vector2(startX, startY);
            endPoint = ArrowAssign(startX, startY, envokedWith);
            reachedEnd = false;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle(
                (int)currentPos.X, (int)currentPos.Y,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (!reachedEnd && (Math.Abs(currentPos.X - endPoint.X) < 5 && Math.Abs(currentPos.Y - endPoint.Y) < 5))
            {
                reachedEnd = true;
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                if (reachedEnd)
                {
                    //Here temp
                    Player.linkInventory.TerminateBoomerang();
                }
                else
                {
                    flight = DirectionV(endPoint, currentPos);
                    //Boomerang is going away from link.
                    currentPos += flight * arrowSpeed;

                }
            }
        }

        private Vector2 DirectionV(Vector2 targetV, Vector2 chaserV)
        {
            Vector2 directionVector = targetV - chaserV;
            directionVector.Normalize();
            return directionVector;
        }

        private Vector2 ArrowAssign(float startX, float startY, ButtonKind envokedWith)
        {
            float endX;
            float endY;
            switch (envokedWith)
            {
                case ButtonKind.UP:
                    endY = startY - arrowTravelDist;
                    endX = startX;
                    source = my_source_frames[3];
                    break;

                case ButtonKind.DOWN:
                    endY = startY + arrowTravelDist;
                    endX = startX;
                    source = my_source_frames[2];
                    break;

                case ButtonKind.RIGHT:
                    endY = startY;
                    endX = startX + arrowTravelDist;
                    source = my_source_frames[0];
                    break;

                case ButtonKind.LEFT:
                    endY = startY;
                    endX = startX - arrowTravelDist;
                    source = my_source_frames[1];
                    break;

                default:
                    endX = startX;
                    endY = startY;
                    break;
            }

            endPoint = new Vector2(endX, endY);
            return endPoint;
        }
    }
}