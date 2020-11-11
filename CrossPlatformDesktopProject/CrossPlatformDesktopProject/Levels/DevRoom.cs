using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

// This file was for the temporary Sprint2 Storage

namespace CrossPlatformDesktopProject.Levels
{
    public class DevRoom
    {
        private List<IWorldItem> worldItems;
        private List<IObstacle> obstacles;
        private List<INpc> npcs;
        private int worldItemsIndex;
        private int obstaclesIndex;
        private int npcIndex;

        private float xPosNPC = 400;
        private float yPosNPC = 100;
        private float xPosItem = 300;
        private float yPosItem = 300;
        private float xPosBlock = 200;
        private float yPosBlock = 200;

        private INpc fireball1;
        private INpc fireball2;
        private INpc fireball3;
        private INpc boomerang;

        private int cooldownFramesLeft;
        private static int cooldownFramesStart = 15;

        public DevRoom(Game1 game)
        {
            cooldownFramesLeft = 0;

            worldItemsIndex = obstaclesIndex = 0;
            npcIndex = 2;

            fireball1 = new Fireball();
            fireball2 = new Fireball();
            fireball3 = new Fireball();
            boomerang = new GoriyaBoomerang();

            worldItems = new List<IWorldItem>
            {
                new DungeonKey(xPosItem, yPosItem),
                new DungeonMap(xPosItem, yPosItem),
                new Rupee(xPosItem, yPosItem),
                new Heart(xPosItem, yPosItem),
                new Triforce(xPosItem, yPosItem),
            };

            obstacles = new List<IObstacle>
            {
                new Statue(xPosItem, yPosItem),
                new Block(xPosBlock, yPosBlock),
                new Statue2(xPosItem, yPosItem),
                new Sand(xPosItem, yPosItem),
                new PlainBlock(xPosItem, yPosItem),
                new Stairs(xPosBlock, yPosBlock)
            };

            npcs = new List<INpc>
            {
                new Boss(xPosNPC, yPosNPC, (Fireball) fireball1, (Fireball) fireball2, (Fireball) fireball3),
                new Bat(xPosNPC, yPosNPC),
                new Goriya(xPosNPC, yPosNPC, (GoriyaBoomerang) boomerang),
                new Gel(xPosNPC, yPosNPC),
                new Skeleton(xPosNPC, yPosNPC),
                new OldMan(xPosNPC, yPosNPC),
            };
        }

        public void Update()
        {
            if (cooldownFramesLeft > 0)
            {
                cooldownFramesLeft--;
            }
            npcs[npcIndex].Update();

            fireball1.Update();
            fireball2.Update();
            fireball3.Update();
            boomerang.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            worldItems[worldItemsIndex].Draw(sb);
            obstacles[obstaclesIndex].Draw(sb);
            npcs[npcIndex].Draw(sb);

            fireball1.Draw(sb);
            fireball2.Draw(sb);
            fireball3.Draw(sb);
            boomerang.Draw(sb);
        }

        public List<ICollider> getCollidables()
        {
            return new List<ICollider>
            {
                worldItems[worldItemsIndex],
                npcs[npcIndex],
                obstacles[obstaclesIndex],
                fireball1,
                fireball2,
                fireball3,
                boomerang
            };
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
