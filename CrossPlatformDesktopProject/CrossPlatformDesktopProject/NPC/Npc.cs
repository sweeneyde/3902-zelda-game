using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.NPC.Gel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.NPC
{
    class Npc
    {
        private INpc currentState;
        public float xPos, yPos;

        public Npc()
        {
            currentState = new OldManIdle(this);
            xPos = 200;
            yPos = 200;
        }

        public void Update()
        {
            currentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}
