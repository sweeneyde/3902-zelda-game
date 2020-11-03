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
        private Keys lastAction;

        public KeyMapping(Game1 game, Player player)
        {
            myGame = game;
            myPlayer = player;

            mappings = new Dictionary<Keys, ICommand>();
            acceptedStates = new List<Keys>();
            gameActions = new List<Keys>();
            priorityActions = new List<Keys>();

            lastAction = Keys.W;

            setDefaults();
        }
        
        private void setDefaults(){

            //Game Commands
            this.addCommand(Keys.D0, new Quit(myGame));
            this.addCommand(Keys.Q, new Quit(myGame));
            this.addCommand(Keys.R, new ResetGame(myGame));

            gameActions.Add(Keys.D0);
            gameActions.Add(Keys.T);
            gameActions.Add(Keys.Y);
            gameActions.Add(Keys.U);
            gameActions.Add(Keys.I);
            gameActions.Add(Keys.O);
            gameActions.Add(Keys.P);
            gameActions.Add(Keys.Q);
            gameActions.Add(Keys.R);

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
            this.addCommand(Keys.D1, new UseSecondaryCommand1(myPlayer));
            this.addCommand(Keys.D2, new UseSecondaryCommand2(myPlayer));
            this.addCommand(Keys.D3, new UseSecondaryCommand3(myPlayer));

            this.addCommand(Keys.RightShift, new SelectCommand(myPlayer));
            this.addCommand(Keys.Enter, new StartCommand(myPlayer));

            this.addCommand(Keys.E, new TakeDamageCommand(myPlayer));

            

            priorityActions.Add(Keys.N);
            priorityActions.Add(Keys.Z);
            priorityActions.Add(Keys.E);

            acceptedStates.Remove(Keys.D0);
        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            acceptedStates.Add(key);
        }

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
                if (!heldKeys.Contains(k) && acceptedStates.Contains(k))
                {
                    mappings[k].Execute();
                    lastAction = k;
                    return;
                }
            }

            if (currentState.Contains(lastAction))
            {
                mappings[lastAction].Execute();
                return;
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
