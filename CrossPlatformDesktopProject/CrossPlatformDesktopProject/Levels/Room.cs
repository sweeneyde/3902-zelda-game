using System;
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
        private int length;
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
                collidables.Add((ICollider) x);
            }
            foreach (IObstacle x in obstacles)
            {
                collidables.Add((ICollider)x);
            }
            foreach (INpc x in npcs)
            {
                collidables.Add((ICollider)x);
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
            //not yet implemented

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
