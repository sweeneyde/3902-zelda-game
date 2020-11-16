using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Levels
{
    class RowsColumns
    {
        private const int X_ORIGIN = (RoomTextureStorage.BORDER_WIDTH - RoomTextureStorage.ROOM_WIDTH) / 4;
        private const int Y_ORIGIN = (RoomTextureStorage.BORDER_HEIGHT - RoomTextureStorage.ROOM_HEIGHT) / 4;
        public static float[] ConvertRowsColumns(int row, int column)
        {
            row++;
            column++;
            float[] coords = { X_ORIGIN * column, Y_ORIGIN * row };

            return coords;
            
        }
    }
}
