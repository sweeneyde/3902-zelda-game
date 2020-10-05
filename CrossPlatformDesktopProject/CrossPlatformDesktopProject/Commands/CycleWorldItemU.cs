using CrossPlatformDesktopProject.WorldItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class CycleWorldItemU : ICommand
    {
        private Game1 myGame;
        private Sprint2ListStorage sL;
        public CycleWorldItemU(Game1 game, Sprint2ListStorage sL)
        {
            myGame = game;
            this.sL = sL;
        }
        public void Execute() => myGame.worldItem = Sprint2ListStorage.worldItems[sL.lastWorldItemIndex()];
    }
}
