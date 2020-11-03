using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Levels
{
    public static class Map
    {
        // See documentation for CSV explanations
        public static Dictionary<string, string[]> adjacencies = CSVParser.ParseRoomAdjacencies();
    }
}
