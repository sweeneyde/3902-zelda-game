using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class KeyboardController : IController
    {
        private Keys[] currentState;
        private KeyMapping keyMap;

        public KeyboardController(Game1 game, Player player)
        {
            keyMap = new KeyMapping(game, player);
        }


        public void Update()
        {
            currentState = Keyboard.GetState().GetPressedKeys();
            keyMap.callCommands(currentState);
        }
    }
}
