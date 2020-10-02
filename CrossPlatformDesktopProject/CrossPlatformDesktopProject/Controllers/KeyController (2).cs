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
        private Game1 myGame;
        private Keys[] currentState;
        private Player player1;
        private List<Keys> acceptedStates;
        private Dictionary<Keys, ICommand> mappings;

        public KeyboardController(Game1 game)
        {
            myGame = game;
            mappings = new Dictionary<Keys, ICommand>();
            acceptedStates = new List<Keys>();
            setDefaults();
        }

        public void assignPlayer(Player player){
            player1 = player;
        }
        
        private void setDefaults(){
            this.addCommand(Keys.D0, new Quit(myGame));
            this.addCommand(Keys.D0, new NewGame(myGame));
            this.addCommand(Keys.R, new SetLinkEastIdle(player1));
        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            acceptedStates.Add(key);
        }

        public void updateCommand(Keys key, ICommand command)
        {
            if(acceptedStates.Contains(key)){
                mappings[key] = command;
            }
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
