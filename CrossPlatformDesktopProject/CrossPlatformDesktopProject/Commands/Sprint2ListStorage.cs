using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Commands
{
    class Sprint2ListStorage
    {
        public static List<IWorldItem> worldItems = new List<IWorldItem>();
        public int worldItemsIndex = 0;

        public Sprint2ListStorage()
        {
            //Create World Items to Cycle Through
            DungeonKey keyDisplay = new DungeonKey();
            DungeonMap mapDisplay = new DungeonMap();
            Rupee rup = new Rupee();
            Heart heart = new Heart();
            Triforce tri = new Triforce();

            //Add them to designated list
            worldItems.Add(keyDisplay);
            worldItems.Add(mapDisplay);
            worldItems.Add(rup);
            worldItems.Add(heart);
            worldItems.Add(tri);

            // Can do the same for obstacles too.
        }

        public int nextWorldItemIndex()
        {
            worldItemsIndex++;
            if (worldItemsIndex == worldItems.Count)
            {
                worldItemsIndex = 0;
            }
            return worldItemsIndex;
        }
        public int lastWorldItemIndex()
        {
            worldItemsIndex--;
            if(worldItemsIndex < 0)
            {
                worldItemsIndex = worldItems.Count - 1;
            }
            return worldItemsIndex;
        }
    }
}
