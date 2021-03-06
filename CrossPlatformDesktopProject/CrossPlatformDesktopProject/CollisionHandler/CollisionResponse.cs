﻿using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
using CrossPlatformDesktopProject.WorldItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CrossPlatformDesktopProject.CollisionHandler
{
    class CollisionResponse
    {
        private Dictionary<Tuple<Type, Type, CollisionSides>, Type> commandMap;
        private HashSet<Tuple<Type, Type, CollisionSides>> keySet;
        public Room myRoom;
        public Game1 myGame;

        public CollisionResponse(Room room, Game1 game)
        {
            myGame = game;
            commandMap = new Dictionary<Tuple<Type, Type, CollisionSides>, Type>();
            BuildDictionary();
            keySet = new HashSet<Tuple<Type, Type, CollisionSides>>(commandMap.Keys);
            myRoom = room;
        }

        private void BuildDictionary()
        {
            Type playerType = typeof(Player);

            //Enemy Types
            Type batType = typeof(Bat);
            Type bossType = typeof(Boss);
            Type gelType = typeof(Gel);
            Type goriyaType = typeof(Goriya);
            Type skeletonType = typeof(Skeleton);
            Type fireballType = typeof(Fireball);
            Type goriyaBoomerangType = typeof(GoriyaBoomerang);
            Type[] enemyTypes = { batType, bossType, gelType, goriyaType, skeletonType, fireballType, goriyaBoomerangType };

            //Object Types
            Type boomerangType = typeof(Boomerang);
            Type bombType = typeof(Bomb);
            Type bowType = typeof(Bow);
            Type[] objectTypes = { boomerangType, bowType, bombType };

            // Weapon Types
            Type[] weaponTypes = {typeof(Sword), typeof(Boomerang), typeof(Smoke), typeof(Bow) };

            //Obstacle Types
            var typeOfObstacle = typeof(IObstacle);
            var obstacleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeOfObstacle.IsAssignableFrom(p));

            //Item Types
            var typeOfItems = typeof(IWorldItem);
            var itemTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeOfItems.IsAssignableFrom(p));

            //Enemy on player
            foreach (CollisionSides side in Enum.GetValues(typeof(CollisionSides)))
            {
                foreach (Type enemySubject in enemyTypes)
                {
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(enemySubject, playerType, side), typeof(TakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Sword), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Bow), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Boomerang), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Smoke), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Wall), enemySubject, side), typeof(ResetNPCCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Door), enemySubject, side), typeof(ResetNPCCommand));
                    foreach (Type obstacleSubject in obstacleTypes)
                    {
                        commandMap.Add(new Tuple<Type, Type, CollisionSides>(obstacleSubject, enemySubject, side), typeof(ResetNPCCommand));
                    }
                }

                foreach (Type obstacleSubject in obstacleTypes)
                {
                    commandMap.Remove(new Tuple<Type, Type, CollisionSides>(obstacleSubject, batType, side));
                }

                commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(DoorBlock), batType, side), typeof(ResetNPCCommand));

                foreach (Type obstacleSubject in obstacleTypes)
                {
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(obstacleSubject, playerType, side), typeof(ResetCommand));
                }

                commandMap.Remove(new Tuple<Type, Type, CollisionSides>(typeof(DoorBlock), playerType, side));

                foreach (Type itemSubject in itemTypes)
                {
                    if (itemSubject.Equals(typeof(Chest)))
                    {
                        commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, itemSubject, side), typeof(ChestOpenCommand));
                    }
                    else
                    {
                        commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, itemSubject, side), typeof(KeyDisappearCommand));
                    }    
                }
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, typeof(Door), side), typeof(TransportRoomCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Wall), playerType, side), typeof(ResetCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, typeof(LockedDoor), side), typeof(UnlockDoorCommand));
                commandMap.Remove(new Tuple<Type, Type, CollisionSides>(playerType, typeof(EmptyRoomNotifier), side));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, typeof(EmptyRoomNotifier), side), typeof(ThunderDomeWaveCommand));
                commandMap.Remove(new Tuple<Type, Type, CollisionSides>(playerType, typeof(Triforce), side));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, typeof(Triforce), side), typeof(EnterThunderDome));

            }
        }

        public ICommand parseConstructor(ICollider subject, ICollider target, CollisionSides side, Type commandType)
        {
            Type targetType = target.GetType();
            Type subjectType = subject.GetType();

            // Search for a valid constructor for this commandType.
            List<Type[]> signatures = new List<Type[]> {
                new Type[] { targetType },
                new Type[] { typeof(Game1) },
                new Type[] { targetType, typeof(CollisionSides) },
                new Type[] { targetType, typeof(Room) },
                new Type[] { subjectType, targetType, typeof(CollisionSides) },
                new Type[] { subjectType, targetType, typeof(Room) },
                new Type[] { typeof(Game1), subjectType, targetType, typeof(CollisionSides) },
            };

            ConstructorInfo commandConstructor = null;
            foreach (Type[] signature in signatures)
            {
                commandConstructor = commandType.GetConstructor(signature);
                if (commandConstructor != null) { break; }
            }
            if (commandConstructor == null) { return null;}

            // Now invoke the constructor.
            switch (commandConstructor.GetParameters().Length)
            {
                case 1:
                    if (commandConstructor.GetParameters()[0].ParameterType == typeof(Game1)) 
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { myGame });
                    }
                    else 
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { target });
                    }
                case 2:
                    if (commandConstructor.GetParameters()[1].ParameterType == typeof(Room))
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { target, myRoom });
                    }
                    else
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { target, side });
                    }
                case 3:
                    if (commandConstructor.GetParameters()[2].ParameterType == typeof(Room))
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { subject, target, myRoom });
                    }
                    else
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { subject, target, side });
                    }
                case 4:
                    return (ICommand)commandConstructor.Invoke(new object[] { myGame, subject, target, side });
                default:
                    return null;
            }
        }

        public void HandleCollision(ICollider subject, ICollider target, CollisionSides side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
            if(targetType == typeof(EmptyRoomNotifier))
            {
                Console.WriteLine("die");
            }
            Tuple<Type, Type, CollisionSides> key = new Tuple<Type, Type, CollisionSides>(subjectType, targetType, side);
            if (keySet.Contains(key))
            {
                Type commandType = commandMap[key];
                Console.WriteLine(commandType);
                ICommand commandClass = parseConstructor(subject, target, side, commandType);

                if (commandClass != null) { commandClass.Execute(); }
            }
        }
    }
}