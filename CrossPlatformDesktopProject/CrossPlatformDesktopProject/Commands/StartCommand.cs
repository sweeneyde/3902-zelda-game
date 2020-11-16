using CrossPlatformDesktopProject.GameStates;

namespace CrossPlatformDesktopProject.Commands
{
    class StartCommand : ICommand
    {
        private Game1 myGame;
        public StartCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            if (myGame.pauseCooldown == 0)
            {
                myGame.pauseCooldown = 10;
                myGame.currentState = new InventoryState(myGame);
            }
        }   
    }
}
