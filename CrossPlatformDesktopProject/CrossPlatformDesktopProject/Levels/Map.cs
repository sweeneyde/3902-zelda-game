using System.Collections.Generic;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Levels
{
    public static class Map
    {
        // See documentation for CSV explanations
        public static Dictionary<string, string[]> adjacencies = CSVParser.ParseRoomAdjacencies();

    }
}
