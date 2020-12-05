using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Sound;

namespace CrossPlatformDesktopProject
{
    class KeyMapping
    {
        private Game1 myGame;
        private Player myPlayer;
        private Dictionary<Keys, ICommand> mappings;
        private Dictionary<Keys, int> debouncing = new Dictionary<Keys,int>();
        private int debounceTimer = 10;
        private List<Keys> acceptedStates;
        private List<Keys> priorityActions;
        private List<Keys> sensitiveActions;
        private Keys lastAction;

        public KeyMapping(Game1 game, Player player)
        {
            myGame = game;
            myPlayer = player;


            mappings = new Dictionary<Keys, ICommand>();
            acceptedStates = new List<Keys>();
            priorityActions = new List<Keys>();
            sensitiveActions = new List<Keys>();

            lastAction = Keys.W;

            setDefaults();
        }
        
        private void setDefaults(){

            //Game Commands
            this.addCommand(Keys.D0, new Quit(myGame));
            this.addCommand(Keys.Q, new Quit(myGame));
            this.addCommand(Keys.R, new ResetGame(myGame));

            priorityActions.Add(Keys.D0);
            priorityActions.Add(Keys.Q);
            priorityActions.Add(Keys.R);

            //Player Commands
            this.addCommand(Keys.W, new MoveUpCommand(myPlayer));
            this.addCommand(Keys.S, new MoveDownCommand(myPlayer));
            this.addCommand(Keys.D, new MoveRightCommand(myPlayer));
            this.addCommand(Keys.A, new MoveLeftCommand(myPlayer));

            this.addCommand(Keys.Up, new MoveUpCommand(myPlayer));
            this.addCommand(Keys.Down, new MoveDownCommand(myPlayer));
            this.addCommand(Keys.Right, new MoveRightCommand(myPlayer));
            this.addCommand(Keys.Left, new MoveLeftCommand(myPlayer));

            this.addCommand(Keys.N, new UsePrimaryCommand(myPlayer));
            this.addCommand(Keys.Z, new UsePrimaryCommand(myPlayer));
            this.addCommand(Keys.X, new UseSecondaryCommand(myPlayer));
            this.addCommand(Keys.M, new UseSecondaryCommand(myPlayer));

            this.addCommand(Keys.RightShift, new SelectCommand(myGame));
            this.addCommand(Keys.Enter, new StartCommand(myGame));

            this.addCommand(Keys.Space, new MuteCommand(myGame));
            this.addCommand(Keys.J, new EnterThunderDome(myGame));

            priorityActions.Add(Keys.X);
            priorityActions.Add(Keys.Z);
            priorityActions.Add(Keys.N);
            priorityActions.Add(Keys.M);
            priorityActions.Add(Keys.Space);

            sensitiveActions.AddRange(priorityActions);

            acceptedStates.Remove(Keys.D0);
        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            acceptedStates.Add(key);
        }

        public void callCommands(List<Keys> heldKeys, List<Keys> pressedKeys)
        {
            //Update stored debounce keys and filter pressed keys
            List<Keys> storedKeys = new List<Keys>(debouncing.Keys);
            foreach (Keys k in storedKeys)
            {
                debouncing[k] -= 1;
                if(debouncing[k] < 0)
                {
                    debouncing.Remove(k);
                }
                else if(pressedKeys.Contains(k)){
                    pressedKeys.Remove(k);
                }

            }

            //Handle debounced keys and game actions
            foreach (Keys k in pressedKeys)
            {
                if (sensitiveActions.Contains(k))
                {
                    debouncing[k] = debounceTimer;
                }
            }

            //First handle Priority Actions
            foreach (Keys k in priorityActions)
            {
                if (pressedKeys.Contains(k))
                {
                    mappings[k].Execute();
                    return;
                }
            }

            //Second prioritize new inputs
            foreach (Keys k in pressedKeys)
            {
                if (!heldKeys.Contains(k) && acceptedStates.Contains(k))
                {
                    mappings[k].Execute();
                    lastAction = k;
                    return;
                }
            }

            //Fixes movement bugs
            if (pressedKeys.Contains(lastAction))
            {
                mappings[lastAction].Execute();
                return;
            }

            //Handle remaining inputs
            foreach (Keys k in pressedKeys)
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
