using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Levels
{
    public class Room
    {
        private List<IWorldItem> worldItems;
        private List<IObstacle> obstacles;
        private List<INpc> npcs;
        private Background background;
        private int worldItemsIndex;
        private int obstaclesIndex;
        private int npcIndex;
        public string roomID { get; }

        private Game1 game;
        
        public Room(Game1 game, List<INpc> npcList, List<IObstacle> obList, List<IWorldItem> itemList, string name)
        {
            roomID = name.Remove(0, 5);
            this.game = game;
            worldItemsIndex = obstaclesIndex = npcIndex = 0;

            worldItems = itemList;
            obstacles = obList;
            npcs = npcList;
            background = new Background(game, name);

        }

        public void Update()
        {
            for (npcIndex = 0; npcIndex < npcs.Count; npcIndex++)
            {
                npcs[npcIndex].Update();
            }
        }

        public void Draw(SpriteBatch sb, string[] adjacents)
        {

            background.Draw(sb, adjacents);

            if (worldItems.Count > 0)
            {
                foreach (IWorldItem  x in worldItems) { x.Draw(sb); }
            }
            if (obstacles.Count > 0)
            {
                foreach (IObstacle x in obstacles) { x.Draw(sb); }
            }
            if (npcs.Count > 0)
            {
                foreach (INpc x in npcs) { x.Draw(sb); }
            }
        }

        public List<Door> FindDoors(string[] adjacentRooms, Map myMap)
        {
            return background.FindDoorColliders(adjacentRooms, myMap);
        } 

        public List<ICollider> GetColliders(string[] adjacentRooms, Map myMap)
        {
            List<ICollider> collidables = new List<ICollider>();
            foreach(IWorldItem x in worldItems){
                collidables.AddRange((List<ICollider>)x.GetColliders());
            }
            foreach (IObstacle x in obstacles)
            {
                collidables.AddRange((List<ICollider>)x.GetColliders());
            }
            foreach (INpc x in npcs)
            {
                collidables.AddRange((List<ICollider>)x.GetColliders());
            }

        List<Door> doors = FindDoors(adjacentRooms, myMap);
            foreach (Door x in doors)
            {
                collidables.Add((ICollider)x);
            }
            return collidables;
        }

        public void Remove(ICollider entity)
        {
            if (worldItems.Contains((IWorldItem) entity))
            {
                worldItems.Remove((IWorldItem) entity);
            } else if (npcs.Contains((INpc) entity))
            {
                npcs.Remove((INpc)entity);
            }
            else if (obstacles.Contains((IObstacle)entity))
            {
                obstacles.Remove((IObstacle)entity);
            }
        }

        public void Add(ICollider entity)
        {
            foreach (Type entityType in entity.GetType().GetInterfaces()) {
                if (entityType == typeof(IWorldItem))
                {
                    worldItems.Add((IWorldItem)entity);
                    return;
                }
                else if (entityType == typeof(INpc))
                {
                    npcs.Add((INpc)entity);
                    return;
                }
                else if (entityType == typeof(IObstacle))
                {
                    obstacles.Add((IObstacle)entity);
                    return;
                }
            }
        }



        /*public void TestAccessMethod()
        {
            foreach(IWorldItem item in worldItems)
            {
                Debug.Print(item.ToString());
            }

            foreach (IObstacle ob in obstacles)
            {
                Debug.Print(ob.ToString());
            }

            foreach (INpc npc in npcs)
            {
                Debug.Print(npc.ToString());
            }
        }*/

    }
}
