using CrossPlatformDesktopProject.CollisionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class EnemyTakeDamageCommand : ICommand
    {
        private INpc npc;
        CollisionSides side;
        public EnemyTakeDamageCommand(INpc npc, CollisionSides side)
        {
            this.npc = npc;
            this.side = side;
        }

        public void Execute() => npc.TakeDamage();
    }
}
