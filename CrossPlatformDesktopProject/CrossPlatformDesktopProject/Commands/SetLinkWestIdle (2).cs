using CrossPlatformDesktopProject.Link;

namespace CrossPlatformDesktopProject.Commands
{
    internal class SetLinkWestIdle : ICommand
    {
        private Player player1;

        public SetLinkWestIdle(Player player1)
        {
            this.player1 = player1;
        }
    }
}