using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public class Sprint2ListStorage
    {
        private List<IWorldItem> worldItems;
        private List<IObstacle> obstacles;
        private int worldItemsIndex;
        private int obstaclesIndex;
        private int cooldownFramesLeft;
        private static int cooldownFramesStart = 10;
        private Game1 game;

        public Sprint2ListStorage(Game1 game)
        {
            this.game = game;
            cooldownFramesLeft = 0;

            worldItems = new List<IWorldItem>
            {
                new DungeonKey(),
                new DungeonMap(),
                new Rupee(),
                new Heart(),
                new Triforce(),
            };

            obstacles = new List<IObstacle>
            {
                new Statue(),
                new Block(),
            };
        }

        public void Update()
        {
            if (cooldownFramesLeft > 0)
            {
                cooldownFramesLeft--;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            worldItems[worldItemsIndex].Draw(sb);
            obstacles[obstaclesIndex].Draw(sb);
        }

        public void nextWorldItem()
        {
            if (cooldownFramesLeft == 0)
            {
                worldItemsIndex++;
                worldItemsIndex %= worldItems.Count;
                cooldownFramesLeft = cooldownFramesStart;
            }
        }
        public void prevWorldItem()
        {
            if (cooldownFramesLeft == 0)
            {
                worldItemsIndex += worldItems.Count - 1;
                worldItemsIndex %= worldItems.Count;
                cooldownFramesLeft = cooldownFramesStart;
            }
        }
        public void nextObstacle()
        {
            if (cooldownFramesLeft == 0)
            {
                obstaclesIndex++;
                obstaclesIndex %= obstacles.Count;
                cooldownFramesLeft = cooldownFramesStart;
            }
        }
        public void prevObstacle()
        {
            if (cooldownFramesLeft == 0)
            {
                obstaclesIndex += obstacles.Count - 1;
                obstaclesIndex %= obstacles.Count;
                cooldownFramesLeft = cooldownFramesStart;
            }
        }
    }
}
