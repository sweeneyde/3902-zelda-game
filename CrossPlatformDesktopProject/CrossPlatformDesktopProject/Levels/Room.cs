using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
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
        public static Room FromId(Game1 game, string roomId)
        {
            return CSVParser.RoomParse(game, roomId);
        }

        public Room NewRoomAbove()
        {
            string id = Map.adjacencies[roomID][0];
            return Room.FromId(game, id);
        }
        public Room NewRoomBelow()
        {
            string id = Map.adjacencies[roomID][1];
            return Room.FromId(game, id);
        }
        public Room NewRoomToLeft()
        {
            string id = Map.adjacencies[roomID][2];
            return Room.FromId(game, id);
        }
        public Room NewRoomToRight()
        {
            string id = Map.adjacencies[roomID][3];
            return Room.FromId(game, id);
        }


        public Room(Game1 game,
                    List<INpc> npcList,
                    List<IObstacle> obList,
                    List<IWorldItem> itemList,
                    string name)
        {
            roomID = name.Remove(0, 5);
            this.game = game;
            worldItemsIndex = obstaclesIndex = npcIndex = 0;

            worldItems = itemList;
            obstacles = obList;
            npcs = npcList;
            background = new Background(game, roomID);
        }

        public void Update()
        {
            for (npcIndex = 0; npcIndex < npcs.Count; npcIndex++)
            {
                npcs[npcIndex].Update();
            }
        }

        public void Draw(SpriteBatch sb)
        {

            background.Draw(sb);
            foreach (IWorldItem  x in worldItems) { x.Draw(sb); }
            foreach (IObstacle x in obstacles) { x.Draw(sb); }
            foreach (INpc x in npcs) { x.Draw(sb); }
        }

        public List<ICollider> GetColliders()
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

            string[] adjacentRooms = Map.adjacencies[roomID];
            int width = game.GraphicsDevice.Viewport.Width;
            int height = game.GraphicsDevice.Viewport.Height;
            string[] strings = new string[] { "top", "bottom", "left", "right" };
            
            for (int i = 0; i < 4; i++)
            {
                if (adjacentRooms[i] != "-1")
                {
                    collidables.Add(new Door(strings[i], adjacentRooms[i], width, height));
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
