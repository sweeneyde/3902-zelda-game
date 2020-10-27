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

        private float xPos = 400;
        private float yPos = 100;

        private INpc fireball1;
        private INpc fireball2;
        private INpc fireball3;
        private INpc boomerang;

        private int cooldownFramesLeft;
        private static int cooldownFramesStart = 15;
        private Game1 game;

        public DevRoom(Game1 game)
        {
            this.game = game;
            cooldownFramesLeft = 0;
            worldItemsIndex = obstaclesIndex = npcIndex = 0;

            fireball1 = new Fireball();
            fireball2 = new Fireball();
            fireball3 = new Fireball();
            boomerang = new GoriyaBoomerang();

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
                new Boss(xPos, yPos, (Fireball) fireball1, (Fireball) fireball2, (Fireball) fireball3),
                new Bat(xPos, yPos),
                new Goriya(xPos, yPos, (GoriyaBoomerang) boomerang),
                new Gel(xPos, yPos),
                new Skeleton(xPos, yPos),
                new OldMan(xPos, yPos),
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
            List<ICollider> colliders = new List<ICollider>();
            foreach(INpc x in npcs)
            {
                colliders.Add((ICollider) x);
            }
            foreach(IObstacle x in obstacles)
            {
                colliders.Add((ICollider)x);
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
