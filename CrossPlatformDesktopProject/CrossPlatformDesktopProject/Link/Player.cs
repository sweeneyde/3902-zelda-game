using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.Equipables;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Link.Equipables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class Player
    {
        public ILinkState currentState;
        public float xPos, yPos;
        public static InventoryManager linkInventory;
        public static float walking_speed = 3.0f;
        public static int frames_per_step = 6;
        public static int frames_for_sword = 18;
        public bool itemInUse = false;
        public IEquipable currentItem { get; set; }

        public Player()
        {
            currentState = new LinkFacingSouthState1(this);
            linkInventory = new InventoryManager(this);
            xPos = 100;
            yPos = 100;
        }

        public void Update()
        {
            IButtonChecker instance = KeyButtonChecker.Instance;
            
            ISet<ButtonKind> buttons = instance.GetPressedButtons();
            currentState.Update(buttons);
            linkInventory.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
            linkInventory.Draw(spriteBatch);

        }
    }
}
