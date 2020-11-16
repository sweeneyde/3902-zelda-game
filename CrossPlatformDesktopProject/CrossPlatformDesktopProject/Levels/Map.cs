using System.Collections.Generic;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Levels
{
    public static class Map
    {
        // See documentation for CSV explanations
        public static Dictionary<string, string[]> adjacencies = CSVParser.ParseRoomAdjacencies();

        public static void UnlockDoor(string roomID, string direction) {
            //Ex: roomID = 0011 --> this is a locked connection to room 001
            // When changed to 0010, the door is no longer locked.
            string unlocked;
            string[] adjacents = adjacencies[roomID];
            switch (direction)
            {
                case "top":
                    unlocked = adjacents[0].Substring(0, 3) + "0";
                    adjacents[1] = unlocked;
                    break;
                case "bottom":
                    unlocked = adjacents[1].Substring(0, 3) + "0";
                    adjacents[2] = unlocked;
                    break;
                case "left":
                    unlocked = adjacents[2].Substring(0, 3) + "0";
                    adjacents[3] = unlocked;
                    break;
                case "right":
                    unlocked = adjacents[2].Substring(0, 3) + "0";
                    adjacents[3] = unlocked;
                    break;
                default:
                    Debug.WriteLine("Could not unlock door, invalid direction");
                    break;
            }            
        }

    }
}
