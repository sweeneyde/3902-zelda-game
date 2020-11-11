using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Link
{
    public class Player : ICollider
    {
        public ILinkState currentState;
        
        public float xPos, yPos, previousXPos, previousYPos;
        public InventoryManager linkInventory;
        public static float walking_speed = 3.0f;
        public static int frames_per_step = 6;
        public bool itemInUse = false;
        public IEquipable currentItem { get; set; }
        public static int frames_for_sword = 18;
        private static int frames_per_damage_color_change = 5;
        private static int damage_frames = 24;

        public static float knockback_speed = 4.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        public static int use_item_frames = 10;

        private int damaged_frames_left;
        private int frames_until_color_change;

        public int link_health;

        public Player()
        {
            currentState = new LinkFacingSouthState(this);
            linkInventory = new InventoryManager(this);
            xPos = 100;
            yPos = 100;
            link_health = 0;
        }

        public bool IsDamaged()
        {
            return damaged_frames_left > 0;
        }

        public void TakeDamage()
        {
            if (!IsDamaged())
            {
                damaged_frames_left = damage_frames;
                frames_until_color_change = frames_per_damage_color_change;
                currentState.TakeDamage();
            }
        }

        public void MoveDown()
        {
            currentState.MoveDown();
        }

        public void MoveUp()
        {
            currentState.MoveUp();
        }

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }
        public void MoveRight()
        {
            currentState.MoveRight();
        }

        public void UsePrimary()
        {
            currentState.UsePrimary();
        }

        public void UseBomb()
        {
            linkInventory.UseBomb();
        }
        public void UseBoomerang()
        {
            linkInventory.UseBoomerang();
        }
        public void UseBow()
        {
            linkInventory.UseBow();
        }

        public void UseSecondary1()
        {
            currentState.UseSecondary1();
        }

        public void UseSecondary2()
        {
            currentState.UseSecondary2();
        }

        public void UseSecondary3()
        {
            currentState.UseSecondary3();
        }

        public void Update()
        {
            currentState.Update();
            if (IsDamaged() && --frames_until_color_change == 0)
            {
                frames_until_color_change = frames_per_damage_color_change;
                damaged_frames_left--;
                currentState.setTextureIndex(damaged_frames_left % 4);
            }
            linkInventory.Update();
            previousXPos = xPos;
            previousYPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
            linkInventory.Draw(spriteBatch);
        }

        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset=0, int YOffset=0)
        {
            Rectangle destination = new Rectangle(
                (int)xPos + XOffset, (int)yPos + YOffset,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public Rectangle GetRectangle()
        {
            Rectangle sameSize = LinkTextureStorage.LINK_IDLE_EAST;
            return new Rectangle((int)xPos, (int)yPos, sameSize.Width * 3, sameSize.Height * 3);
        }

        public List<ICollider> GetColliders()
        {
            var list = new List<ICollider>();
            list.Add(this);
            string stateName = this.currentState.GetType().Name;
            if (stateName.Contains("Sword"))
            {
                Rectangle rect;
                if (stateName.Contains("East"))
                {
                    rect = new Rectangle(
                        (int)xPos + 45, (int)yPos + 12,
                        Sword.LENGTH, Sword.BREADTH);
                }
                else if (stateName.Contains("West"))
                {
                    rect = new Rectangle(
                        (int)xPos + 3 - Sword.LENGTH, (int)yPos + 12,
                        Sword.LENGTH, Sword.BREADTH);
                }
                else if (stateName.Contains("North"))
                {
                    rect = new Rectangle(
                        (int)xPos + 12, (int)yPos + 3 - Sword.LENGTH,
                        Sword.BREADTH, Sword.LENGTH);
                }
                else if (stateName.Contains("South"))
                {
                    rect = new Rectangle(
                        (int)xPos + 12, (int)yPos + 45,
                        Sword.BREADTH, Sword.LENGTH);
                }
                else
                {
                    throw new NotImplementedException();
                }
                list.Add(new Sword(rect));
            }
            list.AddRange(linkInventory.GetColliders());
            return list;
        }
    }
}
