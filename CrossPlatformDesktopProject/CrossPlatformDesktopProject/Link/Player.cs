using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Link.Equipables;
using CrossPlatformDesktopProject.Sound;
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
        public static float walking_speed = 1.0f;
        public static int frames_per_step = 6;
        public bool itemInUse = false;
        public EquippedEnum currentlyEquipped;


        public static int frames_for_sword = 18;
        private static int frames_per_damage_color_change = 5;
        private static int damage_frames = 24;

        public static float knockback_speed = 1.0f;
        public static int knockback_frames = frames_per_damage_color_change * 5;

        public static int use_item_frames = 10;

        private int damaged_frames_left;
        private int frames_until_color_change;

        public int link_health;
        public int link_max_health;

        public Player()
        {
            currentState = new LinkFacingSouthState(this);
            linkInventory = new InventoryManager(this);
            xPos = 30;
            yPos = 30;

            currentlyEquipped = EquippedEnum.none;
            link_max_health = link_health = 6;
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
                SoundStorage.Instance.getLinkHitSound().Play();
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

        public void PickupItem(IWorldItem contentOfChest)
        {
            currentState.PickUp(contentOfChest);
        }

        public void UsePrimary()
        {
            currentState.UsePrimary();
            SoundStorage.Instance.getSwordSound().Play();
        }

        public void UseBomb()
        {
            linkInventory.UseBomb();
            SoundStorage.Instance.getdropBombSound().Play();
        }
        public void UseBoomerang()
        {
            linkInventory.UseBoomerang();
            SoundStorage.Instance.getArrowBoomerangSound().Play();
        }
        public void UseBow()
        {
            linkInventory.UseBow();
            SoundStorage.Instance.getArrowBoomerangSound().Play();

        }

        public void UseSecondary()
        {
            switch (currentlyEquipped)
            {
                case EquippedEnum.bomb: UseBomb(); break;
                case EquippedEnum.boomerang: UseBoomerang(); break;
                case EquippedEnum.bow: UseBow(); break;
            }
            currentState.UseSecondary();
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
                source.Width, source.Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public Rectangle GetRectangle()
        {
            int boxOffset = 4;
            Rectangle sameSize = LinkTextureStorage.LINK_IDLE_EAST;
            return new Rectangle((int)xPos + boxOffset/2, (int)yPos + boxOffset/2, sameSize.Width - boxOffset, sameSize.Height - boxOffset);
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
