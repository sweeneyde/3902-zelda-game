using CrossPlatformDesktopProject.Link;

namespace CrossPlatformDesktopProject.Commands
{
    class UseSecondaryCommand3 : ICommand
    {
        private Player myPlayer;
        public UseSecondaryCommand3(Player player)
        {
            myPlayer = player;
        }
        public void Execute() => myPlayer.UseSecondary3();
    }
}
