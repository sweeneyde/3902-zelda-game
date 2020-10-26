using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem;
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
            npcs[npcIndex].Update();
        }

        public void Draw(SpriteBatch sb, string[] adjacents)
        {

            background.Draw(sb, adjacents);

            worldItems[worldItemsIndex].Draw(sb);
            obstacles[obstaclesIndex].Draw(sb);
            npcs[npcIndex].Draw(sb);
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
