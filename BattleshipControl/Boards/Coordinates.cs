using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipControl.Boards
{
    /// <summary>
    /// Represents a certain location on a board by row and column
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
