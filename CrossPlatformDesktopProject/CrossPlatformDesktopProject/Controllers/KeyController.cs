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
        Game1 myGame;
        Keys[] currentState;
        List<Keys> acceptedStates;
        private Dictionary<Keys, ICommand> mappings;

        public KeyboardController(Game1 game)
        {
            myGame = game;
            mappings = new Dictionary<Keys, ICommand>();
            acceptedStates = new List<Keys>();
        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            acceptedStates.Add(key);
        }

        public void Update()
        {
            currentState = Keyboard.GetState().GetPressedKeys();

            foreach (Keys k in currentState)
            {
                if (acceptedStates.Contains(k))
                {
                    mappings[k].Execute();
                }
            }
        }
    }
}
