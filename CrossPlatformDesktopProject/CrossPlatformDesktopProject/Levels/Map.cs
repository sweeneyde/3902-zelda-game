using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Levels
{
    public class Map
    {
        // See documentation for CSV explanations
        public Dictionary<string, string[]> map;
        public string[] currentAdjacentList;
        private CSVParser csvParser;
        private Game1 game;

        public Room currentRoom;
        /* Plan to preload
        private Room upRoom;
        private Room downRoom;
        private Room leftRoom;
        private Room rightRoom;
        private Room stairRoom;*/

        // Inits a Dict<String room, String[5] adjacents> loaded from MapParse
        public Map(Game1 game)
        {
            this.game = game;
            map = new Dictionary<string, string[]>();
            csvParser = new CSVParser(this.game);
            csvParser.MapParse(map);

            // init to dev room for now
            currentRoom = csvParser.RoomParse("013");
            map.TryGetValue("013", out currentAdjacentList);
            
        }

        public void Draw(SpriteBatch sb)
        {

            currentRoom.Draw(sb, currentAdjacentList);
            
        }

        public void Update()
        {
            currentRoom.Update();
        }

        public void RemoveEntity(ICollider entity)
        {
            currentRoom.Remove(entity);
        }

        public List<ICollider> GetColliders()
        {
            return currentRoom.GetColliders(currentAdjacentList, this);
        }
        
        public Door FindDoor(String roomCode)
        {
            String oldRoom = currentRoom.roomID;
            if (currentAdjacentList[0].Equals(roomCode))
            {
                RoomUp();
            }
            else if(currentAdjacentList[1].Equals(roomCode))
            {
                RoomDown();
            }
            else if (currentAdjacentList[2].Equals(roomCode))
            {
                RoomLeft();
            }
            else
            {
                RoomRight();
            }

            List<Door> doors = currentRoom.FindDoors(currentAdjacentList, this);
            foreach(Door x in doors)
            {
                if(x.myRoomKey == oldRoom)
                {
                    return x;
                }
            }
            return null;
        }

        private void RoomUp()
        {
            string upRoomID = currentAdjacentList[0];
            if (!upRoomID.Equals("-1"))
            {
                currentRoom = csvParser.RoomParse(upRoomID);
                map.TryGetValue(upRoomID, out currentAdjacentList);
            }
            
        }

        private void RoomDown()
        {
            string downRoomID = currentAdjacentList[1];
            if (!downRoomID.Equals("-1"))
            {
                currentRoom = csvParser.RoomParse(downRoomID);
                map.TryGetValue(downRoomID, out currentAdjacentList);
            }

        }
        private void RoomLeft()
        {
            string leftRoomID = currentAdjacentList[2];
            if (!leftRoomID.Equals("-1"))
            {
                currentRoom = csvParser.RoomParse(leftRoomID);
                map.TryGetValue(leftRoomID, out currentAdjacentList);
            }

        }

        private void RoomRight()
        {
            string rightRoomID = currentAdjacentList[3];
            if (!rightRoomID.Equals("-1"))
            {
                currentRoom = csvParser.RoomParse(rightRoomID);
                map.TryGetValue(rightRoomID, out currentAdjacentList);
            }

        }

        /*public void TestAccess()
        {
            Dictionary<string, string[]>.KeyCollection keyTest = map.Keys;
            Dictionary<string, string[]>.ValueCollection valueTest = map.Values;

            Debug.Print("Test Keys Recovered: ");
            foreach (string key in keyTest)
            {
                string[] valGrab;
                map.TryGetValue(key, out valGrab);
                Debug.Print("Key: " + key + " -- Values: " + valGrab[0] + " ... " + valGrab[valGrab.Length - 1]);
            }

            Debug.Print("Current Room:");
            currentRoom.TestAccessMethod();

        }*/
    }
}
