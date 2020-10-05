using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Commands
{
    class Sprint2ListStorage
    {
        public static List<IWorldItem> worldItems = new List<IWorldItem>();
        public static List<IObstacle> obstacles = new List<IObstacle>();
        public int worldItemsIndex = 0;
        public int obstaclesIndex = 0;

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

            // Obstacles to cycle through
            Statue stat = new Statue();
            Block block = new Block();

            // Into List
            obstacles.Add(stat);
            obstacles.Add(block);
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

        public int nextObstacleIndex()
        {
            obstaclesIndex++;
            if (obstaclesIndex == obstacles.Count)
            {
                obstaclesIndex = 0;
            }
            return obstaclesIndex;
        }
        public int lastObstacleIndex()
        {
            obstaclesIndex--;
            if (obstaclesIndex < 0)
            {
                obstaclesIndex = obstacles.Count - 1;
            }
            return obstaclesIndex;
        }
    }
}
