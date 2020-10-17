using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public class Sprint2ListStorage
    {
        private List<IWorldItem> worldItems;
        private List<IObstacle> obstacles;
        private List<INpc> npcs;
        private int worldItemsIndex;
        private int obstaclesIndex;
        private int npcIndex;

        private int cooldownFramesLeft;
        private static int cooldownFramesStart = 15;
        private Game1 game;

        public Sprint2ListStorage(Game1 game)
        {
            this.game = game;
            cooldownFramesLeft = 0;
            worldItemsIndex = obstaclesIndex = npcIndex = 0;

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
                new Statue2(),
                new Sand(),
                new PlainBlock(),
                new Stairs()
            };

            npcs = new List<INpc>
            {
                new Boss(),
                new Bat(),
                new Goriya(),
                new Gel(),
                new Skeleton(),
                new OldMan(),
            };
        }

        public void Update()
        {
            if (cooldownFramesLeft > 0)
            {
                cooldownFramesLeft--;
            }
            npcs[npcIndex].Update();
        }

        public void Draw(SpriteBatch sb)
        {
            worldItems[worldItemsIndex].Draw(sb);
            obstacles[obstaclesIndex].Draw(sb);
            npcs[npcIndex].Draw(sb);
        }

        public List<ICollider> getCollidables()
        {
            List<ICollider> colliders = new List<ICollider>();
            foreach(INpc x in npcs)
            {
                colliders.Add((ICollider) x);
            }
            return colliders;
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
        public void nextNpc()
        {
            if (cooldownFramesLeft == 0)
            {
                npcIndex++;
                npcIndex %= npcs.Count;
                cooldownFramesLeft = cooldownFramesStart;
            }
        }
        public void prevNpc()
        {
            if (cooldownFramesLeft == 0)
            {
                npcIndex += npcs.Count - 1;
                npcIndex %= npcs.Count;
                cooldownFramesLeft = cooldownFramesStart;
            }
        }
    }
}
