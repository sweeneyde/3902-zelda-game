﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionHandler
{
    class CollisionDetector
    {
        private static CollisionResponse responder = new CollisionResponse();
        private List<ICollider> room;
        private static int collisionMargin = 15;

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
            int xOverlap = 0;
            int yOverlap = 0;
            CollisionSides x;
            CollisionSides y;
            //get relative position
            if(subject.Center.X - target.Center.X > 0)
            {
                //left of subject
                xOverlap = subject.Center.X - target.Center.X - (subject.Width / 2) - (target.Width / 2);
                x = CollisionSides.Left;

            } else
            {
                //right of subject
                xOverlap = target.Center.X - subject.Center.X - (subject.Width / 2) - (target.Width / 2);
                x = CollisionSides.Right;

            }

            if (subject.Center.Y - target.Center.Y > 0)
            {
                // top of subject
                yOverlap = subject.Center.Y - target.Center.Y - (subject.Height / 2) - (target.Height / 2);
                y = CollisionSides.Up;
            }
            else
            {
                //bottom of subject
                yOverlap = target.Center.Y - subject.Center.Y - (subject.Height / 2) - (target.Height / 2);
                y = CollisionSides.Down;
            }

            if(yOverlap < -collisionMargin)
            {
                yOverlap = 0;
            }
            if (xOverlap < -collisionMargin)
            {
                xOverlap = 0;
            }

            if (Math.Pow(xOverlap,2) > Math.Pow(yOverlap, 2))
            {
                return x;
            } else
            {
                return y;
            }
            
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
                        Console.WriteLine("{0} hit {1} side of {2}", target, GetOrientation(subjectRectangle, targetRectangle), subject);
                        responder.HandleCollision(subject, target, GetOrientation(subjectRectangle, targetRectangle));
                    }
                }
            }
        } 
    }
}
