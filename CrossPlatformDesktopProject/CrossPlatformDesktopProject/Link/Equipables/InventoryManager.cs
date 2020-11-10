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
    class InventoryManager
    {
        public static List<IEquipable> inventory;
        private Player player;
        private IEquipable currentItem;
        /* Once the user picks up an item, they are initd*/
        public static Boomerang boomerang;
        public static Bow bow;
        //Gonna have bow & prolly bomb here too
        public static Bomb bomb;

        public InventoryManager(Player player)
        {
            inventory = new List<IEquipable>();
            this.player = player;
            //for now this is added here
            inventory.Add(boomerang);
            inventory.Add(bomb);
            inventory.Add(bow);
        }

        /*This method is for later, just was sketching it up
        public void ItemPickedUp(IEquipable equipableObj)
        {
            Type eType = equipableObj.GetType();
            switch(eType.Name)
            {
                case "Boomerang":
                    inventory.Add(boomerang);
                    break;
                default:
                    Debug.Print("ERROR: could not find IEquipable. @ Inventory Manager.");
                    break;
            }
        }
        */

        public void UseBoomerang()
        {
            if (currentItem == null)
            {
                boomerang = new Boomerang(player);
                currentItem = boomerang;
            }
        }
        
        public void UseBow()
        {
            if (currentItem == null)
            {
                bow = new Bow(player);
                currentItem = bow;
            }
        }

        public void UseBomb() 
        {
            if (currentItem == null)
            {
                bomb = new Bomb(player);
                currentItem = bomb;
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
