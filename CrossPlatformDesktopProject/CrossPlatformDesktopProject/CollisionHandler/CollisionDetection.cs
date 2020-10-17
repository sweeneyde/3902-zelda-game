using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionHandler
{
    class CollisionDetector
    {
        private static CollisionResponse responder = new CollisionResponse();
        private List<ICollider> room;

        public CollisionDetector(List<ICollider> colliders)
        {
            room = colliders;
        }

        public Boolean CheckCollision(Rectangle subject, Rectangle target)
        {
            return subject.Intersects(target);
        }

        public CollisionSides GetOrientation(Rectangle subject, Rectangle target)
        {
            //needs orientation logic
            return CollisionSides.Left;
        }

        public void Update()
        {
            Rectangle subjectRectangle, targetRectangle;
            foreach(ICollider subject in room)
            {
                foreach(ICollider target in room)
                {
                    if (subject == target) { continue; }

                    subjectRectangle = subject.GetRectangle();
                    targetRectangle = target.GetRectangle();

                    if (CheckCollision(subjectRectangle, targetRectangle))
                    {
                        Console.WriteLine("Collision Detected");
                        responder.HandleCollision(subject, target, GetOrientation(subjectRectangle, targetRectangle));
                    }
                }
            }
        } 
    }
}
