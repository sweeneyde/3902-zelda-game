using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
            int i, j, k;
            string grabType;
            int row;
            int column;
            string roomTextureID;
            string[] readLine;

            bool isChestContents = false;
            bool chestFlag = false;
            Chest grabChest = null;
            string parsedID = roomID.Substring(0, 3);
            string roomFile = parsedID + ".csv";
            string roomPath = Path.Combine(roomCSVPath, roomFile);
            List<INpc> npcHolder = new List<INpc>();
            List<IObstacle> obstacleHolder = new List<IObstacle>();
            List<IWorldItem> worldItemHolder = new List<IWorldItem>();
            object[] args;
            INpc goriyaBoomerang1;
            INpc goriyaBoomerang2;
            INpc goriyaBoomerang3;
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

                goriyaBoomerang1 = new GoriyaBoomerang();
                goriyaBoomerang2 = new GoriyaBoomerang();
                goriyaBoomerang3 = new GoriyaBoomerang();
                topFireball = new Fireball();
                midFireball = new Fireball();
                botFireball = new Fireball();

                while (!csvParser.EndOfData)
                {
                    i = 0;
                    j = 0;
                    k = 0;
                    // Read current line fields, pointer moves to the next line.
                    readLine = csvParser.ReadFields();
                    while(i < readLine.Length)
                    {
                        grabType = readLine[i];
                        i++;
                        row = Int32.Parse(readLine[i]);
                        i++;
                        column = Int32.Parse(readLine[i]);

                        float[] coords = RowsColumns.ConvertRowsColumns(row, column);

                        Type resolvedType = Type.GetType(grabType);

                        if (resolvedType == typeof(Goriya))
                        {
                            if (j == 0)
                            {
                                args = new object[] { coords[0], coords[1], (GoriyaBoomerang)goriyaBoomerang1, game };
                            } else if (j == 1)
                            {
                                args = new object[] { coords[0], coords[1], (GoriyaBoomerang)goriyaBoomerang2, game };
                            } else
                            {
                                args = new object[] { coords[0], coords[1], (GoriyaBoomerang)goriyaBoomerang3, game };
                            }
                        } else if (resolvedType == typeof(Boss))
                        {
                            args = new object[] { coords[0], coords[1], (Fireball)topFireball, (Fireball)midFireball, (Fireball)botFireball };
                        } else if(resolvedType == typeof(Chest))
                        {
                            chestFlag = true;
                            args = new object[] { coords[0], coords[1] };
                        } else if (resolvedType == typeof(Gel) || resolvedType == typeof(Bat) || resolvedType == typeof(Skeleton))
                        {
                            args = new object[] { coords[0], coords[1], game };
                        }
                        else
                        {
                            args = new object[] { coords[0], coords[1] };
                        }

                        object grabObj = (Activator.CreateInstance(resolvedType, args));

                        if (grabObj is INpc)
                        {
                            npcHolder.Add((INpc)grabObj);
                            Type npcType = grabObj.GetType();
                            if (npcType == typeof(Goriya))
                            {
                                if (j == 0)
                                {
                                    npcHolder.Add(goriyaBoomerang1);
                                } else if (j == 1)
                                {
                                    npcHolder.Add(goriyaBoomerang2);
                                } else
                                {
                                    npcHolder.Add(goriyaBoomerang3);
                                }
                            }
                            else if (npcType == typeof(Boss))
                            {
                                npcHolder.Add(topFireball);
                                npcHolder.Add(midFireball);
                                npcHolder.Add(botFireball);
                            }

                            Debug.Print("Added NPC");
                        } else if(grabObj is IObstacle)
                        {
                            obstacleHolder.Add((IObstacle)grabObj);
                            Debug.Print("Added Obstacle");
                        } else if(grabObj is IWorldItem && isChestContents)
                        {
                            isChestContents = false;
                            grabChest.putItemInChest((IWorldItem)grabObj);
                            Debug.Print("Added item into Chest");

                        }
                        else if (grabObj is IWorldItem && chestFlag)
                        {
                            grabChest = (Chest)grabObj;
                            worldItemHolder.Add(grabChest);
                            Debug.Print("Added Chest Item");
                        }
                        else if (grabObj is IWorldItem)
                        {
                            worldItemHolder.Add((IWorldItem)grabObj);
                            Debug.Print("Added World Item");
                        }
                        else
                        {
                            Debug.Print("Couldn't finalize interface of Object");
                        }

                        if (chestFlag)
                        {
                            chestFlag = false;
                            isChestContents = true;
                        }
                        i++;
                        j++;
                        k++;
                    }
                }
            }

            return new Room(game, npcHolder, obstacleHolder, worldItemHolder, roomTextureID);
        }
    }
}
