using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionHandler
{
    public class CollisionDetector
    {
        private static CollisionResponse responder;
        private List<ICollider> colliders;
        private Player myPlayer;
        private Room myRoom;
        private List<ICollider> delete;

        public CollisionDetector(Room room, Player player, Game1 game)
        {
            myRoom = room;
            colliders = room.GetColliders();
            myPlayer = player;
            responder = new CollisionResponse(room, game);
            delete = new List<ICollider>();
        }

        public void AddColliders(ICollider collider)
        {
            colliders.Add(collider);
        }

        public void RemoveColliders(ICollider collider)
        {
            delete.Add(collider);
        }

        public void RemoveNPC(ICollider collider)
        {
            myRoom.RemoveNPC(collider);
        }

        public Boolean CheckCollision(Rectangle subject, Rectangle target)
        {
            return subject.Intersects(target);
        }

        public CollisionSides GetOrientation(Rectangle subject, Rectangle target)
        {
            float dx = subject.Center.X - target.Center.X;
            float dy = subject.Center.Y - target.Center.Y;
            CollisionSides xSide = dx > 0 ? CollisionSides.Left : CollisionSides.Right;
            CollisionSides ySide = dy > 0 ? CollisionSides.Up : CollisionSides.Down;
            float xGap = Math.Abs(dx) - (subject.Width / 2) - (target.Width / 2);
            float yGap = Math.Abs(dy) - (subject.Height / 2) - (target.Height / 2);
            float xOverlap = Math.Max(0, -xGap);
            float yOverlap = Math.Max(0, -yGap);
            // Choose the direction of the smaller overlap.
            return yOverlap > xOverlap ? xSide : ySide;
        }

        public void Update()
        {
            colliders = myRoom.GetColliders();            
            colliders.AddRange(myPlayer.GetColliders());
            Rectangle subjectRectangle, targetRectangle;
            foreach(ICollider subject in colliders)
            {
                foreach(ICollider target in colliders)
                {
                    if (subject == target) { continue; }

                    subjectRectangle = subject.GetRectangle();
                    targetRectangle = target.GetRectangle();

                    if (CheckCollision(subjectRectangle, targetRectangle))
                    {
                        CollisionSides orientation = GetOrientation(subjectRectangle, targetRectangle);
                        Console.WriteLine("{0} hit {1} side of {2}", target, orientation, subject);
                        responder.HandleCollision(subject, target, orientation);
                    }
                }
            }
            foreach(ICollider collider in delete)
            {
                colliders.Remove(collider);
            }
        } 
    }
}
