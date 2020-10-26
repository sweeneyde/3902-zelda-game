﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public interface IObstacle : ICollider
    {
        void Update();

        /* This Draw method's parameters are from the O.G. sprite drawing class*/
        /* Change as needed*/
        void Draw(SpriteBatch spriteBatch);
    }
}