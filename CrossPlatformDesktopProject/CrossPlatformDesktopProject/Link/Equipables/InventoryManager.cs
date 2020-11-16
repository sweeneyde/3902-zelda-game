using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link.Equipables
{
    public class InventoryManager
    {
        public static HashSet<IEquipable> inventory;
        private Player player;
        private IEquipable currentItem;
        /* Once the user picks up an item, they are initialize */
        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;

        /* If a user does not have the resource for an item, it cannot be used */
        public int rupeeCount;
        public int bombCount;
        public int keyCount;

        public IEquipable equippedItem;

        public InventoryManager(Player player)
        {
            inventory = new HashSet<IEquipable>();
            this.player = player;
            //for now this is added here
            inventory.Add(boomerang);
            inventory.Add(bomb);
            inventory.Add(bow);

            equippedItem = null;

            rupeeCount = keyCount = bombCount = 1;
        }

        public void ItemPickedUp(ICollider collidable)
        {
            Type eType = collidable.GetType();
            switch(eType.Name)
            {
                case "Boomerang":
                    inventory.Add(boomerang);
                    break;
                case "Bow":
                    inventory.Add(bow);
                    break;
                case "Bomb":
                    inventory.Add(bomb);
                    bombCount += 1;
                    break;
                case "DungeonKey":
                    keyCount += 1;
                    break;
                case "Heart":
                    keyCount += 1;
                    break;
                case "Rupee":
                    rupeeCount += 1;
                    break;
                case "Triforce":
                    keyCount += 1;
                    break;
                case "DungeonMap":
                    keyCount += 1;
                    break;
                default:
                    Debug.Print("ERROR: could not find IEquipable. @ Inventory Manager.");
                    break;
            }
        }
        

        public void UseBoomerang()
        {
            if (currentItem == null)
            {
                if (inventory.Contains(boomerang))
                {
                    boomerang = new Boomerang(player);
                    currentItem = boomerang;
                }
            }
        }
        
        public void UseBow()
        {
            if (currentItem == null)
            {
                if (inventory.Contains(bow))
                {
                    bow = new Bow(player);
                    currentItem = bow;
                }
            }
        }

        public void UseBomb() 
        {
            if (currentItem == null)
            {
                if (inventory.Contains(bomb) && bombCount > 0)
                {
                    bomb = new Bomb(player);
                    currentItem = bomb;
                    bombCount -= 1;
                }
            }
        }

        public void TerminateBoomerang()
        {
            if(currentItem != null)
            {
                currentItem = null;
                boomerang = null;
            }   
        }

        public void TerminateBomb()
        {
            if (currentItem != null)
            {
                currentItem = null;
                bomb = null;
            }
        }

        public void Update()
        {
            if (EquipmentInUse())
            {
                currentItem.Update();
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (EquipmentInUse())
            {
                currentItem.Draw(spriteBatch);
            }
            
        }

        public bool EquipmentInUse()
        {
            return currentItem != null;
        }

        public List<ICollider> GetColliders()
        {
            if (currentItem is null)
            {
                return new List<ICollider>();
            }
            else
            {
                return currentItem.GetColliders();
            }
        }
    }
}
