using CrossPlatformDesktopProject.Link;

namespace CrossPlatformDesktopProject.Commands
{
    class MoveRightCommand : ICommand
    {
        private Player myPlayer;
        public MoveRightCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.MoveRight();
    }
}
