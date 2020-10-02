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
    class KeyMapping
    {
        private Game1 myGame;
        private Player myPlayer;
        private Dictionary<Keys, ICommand> mappings;

        private List<Keys> acceptedStates;
        private List<Keys> gameActions;
        private List<Keys> priorityActions;

        public KeyMapping(Game1 game, Player player)
        {
            myGame = game;
            myPlayer = player;

            mappings = new Dictionary<Keys, ICommand>();
            acceptedStates = new List<Keys>();
            gameActions = new List<Keys>();
            priorityActions = new List<Keys>();

            setDefaults();
        }

        public void assignPlayer(Player player){
            myPlayer = player;
        }
        
        private void setDefaults(){

            //Game Commands
            this.addCommand(Keys.D0, new Quit(myGame));
            gameActions.Add(Keys.D0);

            //Player Commands
            this.addCommand(Keys.W, new MoveUpCommand(myPlayer));
            this.addCommand(Keys.S, new MoveDownCommand(myPlayer));
            this.addCommand(Keys.D, new MoveRightCommand(myPlayer));
            this.addCommand(Keys.A, new MoveLeftCommand(myPlayer));

            this.addCommand(Keys.Up, new MoveUpCommand(myPlayer));
            this.addCommand(Keys.Down, new MoveDownCommand(myPlayer));
            this.addCommand(Keys.Right, new MoveRightCommand(myPlayer));
            this.addCommand(Keys.Left, new MoveLeftCommand(myPlayer));
            
            this.addCommand(Keys.Space, new UsePrimaryCommand(myPlayer));
            this.addCommand(Keys.E, new UseSecondaryCommand(myPlayer));

            this.addCommand(Keys.RightShift, new SelectCommand(myPlayer));
            this.addCommand(Keys.Enter, new StartCommand(myPlayer));

            priorityActions.Add(Keys.Space);
            priorityActions.Add(Keys.E);

            acceptedStates.Remove(Keys.D0);
        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            acceptedStates.Add(key);
        }

        //public void updateKeyCommand(Keys key, ICommand command)
        //{
        //    if(acceptedStates.Contains(key)){
        //        mappings[key] = command;
        //    }
        //}

        public void callCommands(Keys[] heldKeys, Keys[] pressedKeys)
        {
            Keys[] currentState = pressedKeys;

            foreach (Keys k in gameActions)
            {
                if (currentState.Contains(k))
                {
                    mappings[k].Execute();
                    return;
                }
            }

            foreach (Keys k in priorityActions)
            {
                if (currentState.Contains(k))
                {
                    mappings[k].Execute();
                    return;
                }
            }

            foreach (Keys k in currentState)
            {
                if (acceptedStates.Contains(k) && !heldKeys.Contains(k))
                {
                    mappings[k].Execute();
                    return;
                }
            }

            foreach (Keys k in currentState)
            {
                if (acceptedStates.Contains(k))
                {
                    mappings[k].Execute();
                    return;
                }
            }
        }
    }
}
