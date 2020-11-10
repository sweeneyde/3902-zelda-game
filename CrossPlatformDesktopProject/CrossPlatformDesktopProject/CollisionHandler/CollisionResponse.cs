﻿using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.WorldItem;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionHandler
{
    class CollisionResponse
    {
        private Dictionary<Tuple<Type, Type, CollisionSides>, Type> commandMap;
        private HashSet<Tuple<Type, Type, CollisionSides>> keySet;
        public static Map myMap;

        public CollisionResponse(Map map)
        {
            commandMap = new Dictionary<Tuple<Type, Type, CollisionSides>, Type>();
            BuildDictionary();
            keySet = new HashSet<Tuple<Type, Type, CollisionSides>>(commandMap.Keys);
            myMap = map;
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
            Type[] enemyTypes = { batType, bossType, gelType, goriyaType, skeletonType };

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

            //Obstacle Types
            var typeOfItems = typeof(IWorldItem);
            var itemTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeOfItems.IsAssignableFrom(p));

            
            foreach (CollisionSides side in Enum.GetValues(typeof(CollisionSides)))
            {
                
                foreach (Type enemySubject in enemyTypes)
                {
                    //Enemy on player
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(enemySubject, playerType, side), typeof(TakeDamageCommand));
                    //Player on enemy
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Sword), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Bow), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Boomerang), enemySubject, side), typeof(EnemyTakeDamageCommand));
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Smoke), enemySubject, side), typeof(EnemyTakeDamageCommand));
                }

                //Obstacle on player
                foreach (Type obstacleSubject in obstacleTypes)
                {
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(obstacleSubject, playerType, side), typeof(ResetCommand));
                }
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Bomb), playerType, side), typeof(ResetCommand));
                //Player on WorldItems
                foreach (Type worldItemTarget in itemTypes)
                {
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, worldItemTarget, side), typeof(KeyDisappearCommand));
                }

                commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(Fireball), playerType, side), typeof(TakeDamageCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(typeof(GoriyaBoomerang), playerType, side), typeof(TakeDamageCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, typeof(Door), side), typeof(TransportRoomCommand));
            }
        }

        public ICommand parseConstructor(ICollider subject, ICollider target, CollisionSides side, Type commandType)
        {
            //Command has only the target type as parameter
            Type targetType = target.GetType();
            Type subjectType = subject.GetType();
            Type[] argumentTypes = { targetType };
            ConstructorInfo commandConstructor = commandType.GetConstructor(argumentTypes);

            //Command has target type and side as parameter
            if (commandConstructor is null)
            {
                argumentTypes = new Type[] { targetType, typeof(CollisionSides) };
                commandConstructor = commandType.GetConstructor(argumentTypes);
            }
            if (commandConstructor is null)
            {
                argumentTypes = new Type[] { targetType, typeof(Map) };
                commandConstructor = commandType.GetConstructor(argumentTypes);
            }
            if (commandConstructor is null)
            {
                argumentTypes = new Type[] { subjectType, targetType, typeof(CollisionSides) };
                commandConstructor = commandType.GetConstructor(argumentTypes);
            }
            if (commandConstructor is null) { return null; }

            //Check constructor vs parameters

            //Call command
            ICommand commandClass;
            Console.WriteLine(commandConstructor.GetParameters().Length);
            switch (commandConstructor.GetParameters().Length)
            {
                case 1:
                    commandClass = (ICommand)commandConstructor.Invoke(new object[] { target });
                    break;
                case 2:
                    foreach(ParameterInfo p in commandConstructor.GetParameters())
                    {
                        if(p.ParameterType == typeof(Map))
                        {
                            commandClass = (ICommand)commandConstructor.Invoke(new object[] { target, myMap });
                            return commandClass;
                        }
                    }
                    commandClass = (ICommand)commandConstructor.Invoke(new object[] { target, side });
                    break;
                case 3:
                    commandClass = (ICommand)commandConstructor.Invoke(new object[] { subject, target, side });
                    break;
                default:
                    return null;
            }
            return commandClass;
        }

        public void HandleCollision(ICollider subject, ICollider target, CollisionSides side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
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