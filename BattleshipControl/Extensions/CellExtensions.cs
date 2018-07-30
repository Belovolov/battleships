using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipControl.Boards;

namespace BattleshipControl.Extensions
{
    /// <summary>
    /// Extends List of Cells
    /// Author: Matthew Jones
    /// Modified: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    public static class CellExtensions
    {
        ///<Summary>
        ///Retrieves the cell out of a list of cells that has given coordinates
        ///</Summary>
        public static Cell At(this List<Cell> cells, int row, int column)
        {
            return cells.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }
        ///<Summary>
        ///Get the set of cells that are limited by given boundaries
        ///</Summary>
        public static List<Cell> Range(this List<Cell> cells, int startRow, int startColumn, int endRow, int endColumn)
        {
            return cells.Where(x => x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row <= endRow
                                     && x.Coordinates.Column <= endColumn).ToList();
        }

        ///<Summary>
        ///Get the set of cells that are limited by given boundaries plus all of the adjacent cells
        ///</Summary>
        public static List<Cell> ExtendedRange(this List<Cell> cells, int startRow, int startColumn, int endRow, int endColumn)
        {
            return cells.Where(x => x.Coordinates.Row >= startRow - 1 
                                     && x.Coordinates.Column >= startColumn - 1
                                     && x.Coordinates.Row <= endRow + 1
                                     && x.Coordinates.Column <= endColumn + 1).ToList();
        }
    }
}
