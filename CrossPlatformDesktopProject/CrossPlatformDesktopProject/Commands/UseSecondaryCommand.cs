using CrossPlatformDesktopProject.Link;

namespace CrossPlatformDesktopProject.Commands
{
    class UseSecondaryCommand : ICommand
    {
        private Player myPlayer;
        public UseSecondaryCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UseSecondary();
    }
}
