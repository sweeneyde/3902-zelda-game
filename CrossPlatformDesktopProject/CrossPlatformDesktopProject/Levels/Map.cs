using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.WorldItem.WorldHandlers;
using CrossPlatformDesktopProject.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CrossPlatformDesktopProject.Levels
{
    public static class Map
    {
        // See documentation for CSV explanations
        public static Dictionary<string, string[]> adjacencies = CSVParser.ParseRoomAdjacencies();
    }
}
