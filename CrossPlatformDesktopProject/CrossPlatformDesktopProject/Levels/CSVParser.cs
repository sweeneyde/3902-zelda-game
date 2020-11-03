using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.NPC;
using Microsoft.VisualBasic.FileIO;

namespace CrossPlatformDesktopProject.Levels
{
    static class CSVParser
    {
        private static string cwdPath = Directory.GetCurrentDirectory();
        private static string levelPath = cwdPath.Replace(@"\bin\DesktopGL\AnyCPU\Debug", @"\Levels");
        private static string rootCSV = "LevelCSV";
        private static string roomCSV = "RoomCSV";
        private static string mapCSV = "Map.csv";
        private static string levelCSVPath = Path.Combine(levelPath, rootCSV);
        private static string roomCSVPath = Path.Combine(levelCSVPath, roomCSV);
        public static string mapCSVPath = Path.Combine(levelCSVPath, mapCSV);

        private static string[] commentTokens = { "#", "//", "/" };
        private static string[] delimiters = { ",", ";" };

        /// <summary>
        /// Look at the mapCSVPath and parse it into an adjacency list of room ids.
        /// </summary>
        /// <returns>A Dictionary that maps room id --> [] </returns>
        public static Dictionary<string, string[]> ParseRoomAdjacencies()
        {
            Dictionary<string, string[]> mapMemory = new Dictionary<string, string[]>();
            using (TextFieldParser csvParser = new TextFieldParser(mapCSVPath))
            {
                string[] readLine;
                string roomIDGrab;
                string[] adjacentsGrab;
                csvParser.CommentTokens = commentTokens;
                csvParser.SetDelimiters(delimiters);

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    readLine = csvParser.ReadFields();
                    roomIDGrab = readLine[0];
                    adjacentsGrab = new string[] { readLine[1], readLine[2], readLine[3], readLine[4], readLine[5] };
                    mapMemory.Add(roomIDGrab, adjacentsGrab);
                }
            }
            return mapMemory;
        }

        public static Room RoomParse(Game1 game, string roomID)
        {
            int i;
            string grabType;
            int grabX;
            int grabY;
            string roomTextureID;
            string[] readLine;
            // TODO: PUT THIS IN DOCS-----
            /* Room CSV Format- Filename = "roomID".csv
             * INPC1, startX, startY, INPC2, startX, startY, ...
             * 
             */
            // Since all room.csv files are named according to their id,
            // we get something like roomId = "000" & the file is "000.csv"
            string roomFile = roomID + ".csv";
            string roomPath = Path.Combine(roomCSVPath, roomFile);
            List<INpc> npcHolder = new List<INpc>();
            List<IObstacle> obstacleHolder = new List<IObstacle>();
            List<IWorldItem> worldItemHolder = new List<IWorldItem>();
            object[] args;
            INpc goriyaBoomerang;
            INpc topFireball;
            INpc midFireball;
            INpc botFireball;

            using (TextFieldParser csvParser = new TextFieldParser(roomPath))
            {
                csvParser.CommentTokens = commentTokens;
                csvParser.SetDelimiters(delimiters);

                //Read first line to grab RoomID for texture
                readLine = csvParser.ReadFields();
                roomTextureID = readLine[0];

                goriyaBoomerang = new GoriyaBoomerang();
                topFireball = new Fireball();
                midFireball = new Fireball();
                botFireball = new Fireball();

                while (!csvParser.EndOfData)
                {
                    i = 0;
                    // Read current line fields, pointer moves to the next line.
                    readLine = csvParser.ReadFields();
                    while(i < readLine.Length)
                    {
                        grabType = readLine[i];
                        i++;
                        grabX = Int32.Parse(readLine[i]);
                        i++;
                        grabY = Int32.Parse(readLine[i]);

                        Debug.Print(grabType);
                        Type resolvedType = Type.GetType(grabType);

                        if (resolvedType == typeof(Goriya))
                        {
                            args = new object[] { (float)grabX, (float)grabY, (GoriyaBoomerang)goriyaBoomerang };
                        } else if (resolvedType == typeof(Boss))
                        {
                            args = new object[] { (float)grabX, (float)grabY, (Fireball)topFireball, (Fireball)midFireball, (Fireball)botFireball };
                        } else
                        {
                            args = new object[] { (float)grabX, (float)grabY };
                        }

                        object grabObj = (Activator.CreateInstance(resolvedType, args));

                        if (grabObj is INpc)
                        {
                            npcHolder.Add((INpc)grabObj);
                            npcHolder.Add(goriyaBoomerang);
                            npcHolder.Add(topFireball);
                            npcHolder.Add(midFireball);
                            npcHolder.Add(botFireball);
                            Debug.Print("Added NPC");
                        } else if(grabObj is IObstacle)
                        {
                            obstacleHolder.Add((IObstacle)grabObj);
                            Debug.Print("Added Obstacle");
                        } else if(grabObj is IWorldItem)
                        {
                            worldItemHolder.Add((IWorldItem)grabObj);
                            Debug.Print("Added World Item");
                        }
                        else
                        {
                            Debug.Print("Couldn't finalize interface of Object");
                        }
                        i++;
                    }
                }
            }

            return new Room(game, npcHolder, obstacleHolder, worldItemHolder, roomTextureID);
        }
    }
}
