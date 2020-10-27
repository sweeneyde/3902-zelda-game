using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using CrossPlatformDesktopProject.NPC;
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

        public CollisionResponse()
        {
            commandMap = new Dictionary<Tuple<Type, Type, CollisionSides>, Type>();
            BuildDictionary();
            keySet = new HashSet<Tuple<Type, Type, CollisionSides>>(commandMap.Keys);
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

            // Weapon Types
            Type[] weaponTypes = {typeof(Sword), typeof(Boomerang), typeof(Smoke), typeof(Bow) };

            //Obstacle Types
            var typeOfObstacle = typeof(IObstacle);
            var obstacleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeOfObstacle.IsAssignableFrom(p));

            //Enemy on player
            foreach (CollisionSides side in Enum.GetValues(typeof(CollisionSides)))
            {
                foreach (Type enemySubject in enemyTypes)
                {
                    commandMap.Add(new Tuple<Type,Type,CollisionSides>(enemySubject, playerType, side), typeof(TakeDamageCommand));
                    foreach (Type weapon in weaponTypes)
                    {
                        commandMap.Add(new Tuple<Type, Type, CollisionSides>(weapon, enemySubject, side), typeof(EnemyTakeDamageCommand));
                    }
                }
                foreach(Type obstacleSubject in obstacleTypes)
                {
                    commandMap.Add(new Tuple<Type, Type, CollisionSides>(obstacleSubject, playerType, side), typeof(ResetCommand));
                }
            }

            Type doorTarget = typeof(Door);
            commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, doorTarget, CollisionSides.Down), typeof(TransportRoomCommand));
            commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, doorTarget, CollisionSides.Left), typeof(TransportRoomCommand));
            commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, doorTarget, CollisionSides.Right), typeof(TransportRoomCommand));
            commandMap.Add(new Tuple<Type, Type, CollisionSides>(playerType, doorTarget, CollisionSides.Up), typeof(TransportRoomCommand));
            

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
