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
    class CSVParser
    {
        private string levelCSVPath;
        private string roomCSVPath;
        private string mapCSVPath;
        private string cwdPath;
        private string levelPath;
        private Game1 game;

        private string rootCSV = "LevelCSV";
        private string roomCSV = "RoomCSV";
        private string mapCSV = "Map.csv";
        private string[] commentTokens = { "#", "//", "/" };
        private string[] delimiters = { ",", ";" };

       public CSVParser(Game1 game)
        {
            this.game = game;
            // Load paths on Init and store them as to save some time //
            // We want the path to ...\Level\LevelCSV\ because then we can access
            // "\RoomCSV\" & "\Map.csv" respectively. This is all the CSV info we need.

            // Retrieve assembly cwd: Path.GetDirectoryName(Assembly.GetAssembly(typeof("string assemblyName")).Location);
            // Debug for now

            cwdPath = Directory.GetCurrentDirectory();
            levelPath = cwdPath.Replace(@"\bin\DesktopGL\AnyCPU\Debug", @"\Levels");
            Debug.Print("Current Working Directory: " + levelPath);
      
            levelCSVPath = Path.Combine(levelPath, rootCSV);

            roomCSVPath = Path.Combine(levelCSVPath, roomCSV);

            mapCSVPath = Path.Combine(levelCSVPath, mapCSV);

            Debug.Print("Room CSV: " + roomCSVPath);
            Debug.Print("Map CSV Path: " + mapCSVPath);

        }


        public void MapParse(Dictionary<string, string[]> mapMemory)
        {
            
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

        }

        public Room RoomParse(string roomID)
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

            using (TextFieldParser csvParser = new TextFieldParser(roomPath))
            {
                csvParser.CommentTokens = commentTokens;
                csvParser.SetDelimiters(delimiters);

                //Read first line to grab RoomID for texture
                readLine = csvParser.ReadFields();
                roomTextureID = readLine[0];

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

                        args = new object[] { (float)grabX, (float)grabY};

                        Debug.Print(grabType);
                        Type resolvedType = Type.GetType(grabType);
                        object grabObj = (Activator.CreateInstance(resolvedType, args));

                        if (grabObj is INpc)
                        {
                            npcHolder.Add((INpc)grabObj);
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
