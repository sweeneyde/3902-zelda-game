using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class ResetNPCCommand : ICommand
    {
        private INpc npc;
        private CollisionSides mySide;
        public ResetNPCCommand(INpc npc, CollisionSides side)
        {
            this.npc = npc;
            this.mySide = side;
        }
        public void Execute() => npc.ChangeDirection(mySide);
    }
}
