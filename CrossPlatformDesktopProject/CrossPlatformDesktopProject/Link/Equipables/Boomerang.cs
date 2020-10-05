using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Equipables
{
    class Boomerang : IEquipable
    {
        private Player player;
        private Vector2 currentPos;
        private float startX;
        private float startY;
        private Vector2 endPoint;
        private Vector2 flight;
        private Vector2 returnFlight;
        private int my_frame_index;
        private int delay_frame_index;
        private float boomerangTravelDist = 400f;
        private float boomSpeed = 50f;
        private bool reachedEnd = false;

        private static int delay_frames = 5;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            LinkTextureStorage.BOOMERANG_1,
            LinkTextureStorage.BOOMERANG_2,
            LinkTextureStorage.BOOMERANG_3,
            LinkTextureStorage.BOOMERANG_4,
            LinkTextureStorage.BOOMERANG_5
        };

        public Boomerang(Player player)
        {
            this.player = player;
            startX = player.xPos;
            startY = player.yPos;
            currentPos = new Vector2(startX, startY);
            endPoint = GetEndpoint(startX, startY, player);
            flight = DirectionV(endPoint, currentPos);
            reachedEnd = false;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture;
            if(my_frame_index == 3 || my_frame_index == 4)
            {
                texture = LinkTextureStorage.Instance.getLinkSpriteSheetMirrored();
            }
            else
            {
                texture = LinkTextureStorage.Instance.getLinkSpriteSheet();
            }
                
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)currentPos.X, (int)currentPos.Y,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (!reachedEnd && (Math.Abs(currentPos.X - endPoint.X) < 1 && Math.Abs(currentPos.Y - endPoint.Y) < 1))
            {
                reachedEnd = true;
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                if (reachedEnd)
                {    
                    //Boomerang is going back to link.
                    returnFlight = DirectionV(new Vector2(player.xPos, player.yPos), currentPos);
                    currentPos += returnFlight * boomSpeed/1.7f;
                }
                else
                {
                    flight = DirectionV(endPoint, currentPos);
                    //Boomerang is going away from link.
                    currentPos += flight * boomSpeed;
                }
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }

            if (reachedEnd && (Math.Abs(currentPos.X - player.xPos) < 30 && Math.Abs(currentPos.Y - player.yPos) < 30))
            {
                player.linkInventory.TerminateBoomerang();
            }
        }

        private Vector2 DirectionV(Vector2 targetV, Vector2 chaserV)
        {
            Vector2 directionVector = targetV - chaserV;
            directionVector.Normalize();
            return directionVector;
        }

        private Vector2 GetEndpoint(float startX, float startY, Player player)
        {
            float endX;
            float endY;
            switch (player.currentState.GetType().Name)
            {
                case "LinkFacingNorthState":
                    endY = startY - boomerangTravelDist;
                    endX = startX;
                    break;

                case "LinkFacingSouthState":
                    endY = startY + boomerangTravelDist;
                    endX = startX;
                    break;

                case "LinkFacingEastState":
                    endY = startY;
                    endX = startX + boomerangTravelDist;
                    break;

                case "LinkFacingWestState":
                    endY = startY;
                    endX = startX - boomerangTravelDist;
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