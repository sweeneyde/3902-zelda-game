using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Levels
{
    class RowsColumns
    {
        private const int X_ORIGIN = (RoomTextureStorage.BORDER_WIDTH - RoomTextureStorage.ROOM_WIDTH) / 2;
        private const int Y_ORIGIN = (RoomTextureStorage.BORDER_HEIGHT - RoomTextureStorage.ROOM_WIDTH) / 2;
        public static float[] ConvertRowsColumns(int row, int column)
        {
            float[] coords = { X_ORIGIN * row, Y_ORIGIN * column };

            return coords;
            
        }
    }
}
