using System;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;
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
        public string roomID { get; }

        private Game1 game;
        public static Room FromId(Game1 game, string roomId)
        {
            return CSVParser.RoomParse(game, roomId);
        }

        public Room(Game1 game,
                    List<INpc> npcList,
                    List<IObstacle> obList,
                    List<IWorldItem> itemList,
                    string name)
        {
            if (!name.StartsWith("ROOM_")) throw new ArgumentException();
            roomID = name.Remove(0, 5);
            this.game = game;
            worldItems = itemList;
            obstacles = obList;
            npcs = npcList;
            background = new Background(game, roomID);
        }

        public void Update()
        {
            foreach(INpc npc in npcs)
            {
                npc.Update();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            background.Draw(sb);
            foreach (IWorldItem x in worldItems) { x.Draw(sb); }
            foreach (IObstacle x in obstacles) { x.Draw(sb); }
            foreach (INpc x in npcs) { x.Draw(sb); }
        }

        public List<ICollider> GetColliders()
        {
            List<ICollider> collidables = new List<ICollider>();
            foreach(IWorldItem x in worldItems){
                collidables.Add((ICollider)x);
            }
            foreach (IObstacle x in obstacles)
            {
                collidables.Add((ICollider)x);
            }
            foreach (INpc x in npcs)
            {
                collidables.Add((ICollider)x);
            }

            string[] adjacentRooms = Map.adjacencies[roomID];
            int width = RoomTextureStorage.BORDER_WIDTH;
            int height = RoomTextureStorage.BORDER_HEIGHT;
            string[] strings = new string[] { "top", "bottom", "left", "right" };
            
            for (int i = 0; i < 4; i++)
            {
                // This needs changed for locked doors behavior
                // Locked doors can be detected by adjacentRooms[i].EndsWith("1")
                if (adjacentRooms[i].EndsWith("1"))
                {
                    LockedDoor newDoor = new LockedDoor(strings[i], width, height);
                    Wall newWall1 = new Wall(strings[i], width, height, false);
                    Wall newWall2 = new Wall(strings[i], width, height, true);
                    collidables.Add(newDoor);
                    collidables.Add(newWall1);
                    collidables.Add(newWall2);
                }
                else if (adjacentRooms[i] != "-1")
                {
                    Door newDoor = new Door(strings[i], adjacentRooms[i], width, height);
                    Wall newWall1 = new Wall(strings[i], width, height, false);
                    Wall newWall2 = new Wall(strings[i], width, height, true);
                    collidables.Add(newDoor);
                    collidables.Add(newWall1);
                    collidables.Add(newWall2);
                }
                else
                {
                    collidables.Add(new Wall(strings[i], width, height));
                }
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
    }
}
