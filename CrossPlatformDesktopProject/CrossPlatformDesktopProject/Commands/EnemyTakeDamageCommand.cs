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
        public EnemyTakeDamageCommand(INpc npc, CollisionSides side)
        {
            this.npc = npc;
        }

        public void Execute(Game1 game)
        {
            Console.WriteLine("Enemy took damage!");
        }
    }
}
