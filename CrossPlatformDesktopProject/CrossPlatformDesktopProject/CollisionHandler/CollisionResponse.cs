using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.NPC;
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

            //Object Types
            Type boomerangType = typeof(Boomerang);
            Type bombType = typeof(Bomb);
            Type bowType = typeof(Gel);
            Type[] objectTypes = { boomerangType, bowType, bombType };

            //Obstacle Types

            //Enemy on player
            foreach(Type enemySubject in enemyTypes)
            {
                commandMap.Add(new Tuple<Type,Type,CollisionSides>(enemySubject, playerType, CollisionSides.Down), typeof(TakeDamageCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(enemySubject, playerType, CollisionSides.Left), typeof(TakeDamageCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(enemySubject, playerType, CollisionSides.Right), typeof(TakeDamageCommand));
                commandMap.Add(new Tuple<Type, Type, CollisionSides>(enemySubject, playerType, CollisionSides.Up), typeof(TakeDamageCommand));
            }
            

        }

        public void UpdateDictionary(Tuple<ICollider, ICollider, CollisionSides> tuple, Type commandType)
        {

        }

        public void HandleCollision(ICollider subject, ICollider target, CollisionSides side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
            Tuple<Type, Type, CollisionSides> key = new Tuple<Type, Type, CollisionSides>(subjectType, targetType, side);
            if (keySet.Contains(key))
            {
                Type commandType = commandMap[key];

                //Command has only the target type as parameter
                Type[] argumentTypes = { targetType };
                ConstructorInfo commandConstructor = commandType.GetConstructor(argumentTypes);

                //Command has target type and side as parameter
                if(commandConstructor is null) {
                    argumentTypes = new Type[]{ targetType, typeof(CollisionSides) };
                    commandConstructor = commandType.GetConstructor(argumentTypes);
                }
                if(commandConstructor is null) { return; }

                //Check constructor vs parameters

                //Call command
                ICommand commandClass;
                switch (commandConstructor.GetParameters().Length)
                {
                    case 1:
                        commandClass = (ICommand)commandConstructor.Invoke(new object[] { target });
                        break;
                    case 2:
                        commandClass = (ICommand)commandConstructor.Invoke(new object[] { target , side });
                        break;
                    default:
                        return;
                }
                commandClass.Execute();
            }
        }
    }
}
