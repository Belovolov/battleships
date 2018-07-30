using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipControl.Extensions;

namespace BattleshipControl.Boards
{
    /// <summary>
    /// Represents a collection of Cells to show where the player has fired shots, and whether those shots are hits or misses.
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class FiringBoard : GameBoard
    {
        /// <summary>
        /// Get cells suitable for random shooting
        /// </summary>
        public List<Coordinates> GetOpenRandomCells()
        {
            return Cells.Where(x => x.OccupationType == OccupationType.Empty && x.IsRandomAvailable).Select(x => x.Coordinates).ToList();
        }
        /// <summary>
        /// Get empty neighboring (up, down, left, right) cells of the cell that has been hit
        /// </summary>
        public List<Coordinates> GetHitNeighbors()
        {
            List<Cell> cells = new List<Cell>();
            var hits = Cells.Where(x => x.OccupationType == OccupationType.Hit);
            foreach (var hit in hits)
            {
                cells.AddRange(GetNeighbors(hit.Coordinates).ToList());
            }
            return cells.Distinct().Where(x => x.OccupationType == OccupationType.Empty).Select(x => x.Coordinates).ToList();
        }
        /// <summary>
        /// Get neighboring (up, down, left, right) cells of a cell
        /// </summary>
        public List<Cell> GetNeighbors(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Cell> cells = new List<Cell>();
            if (column > 1)
            {
                cells.Add(Cells.At(row, column - 1));
            }
            if (row > 1)
            {
                cells.Add(Cells.At(row - 1, column));
            }
            if (row < 10)
            {
                cells.Add(Cells.At(row + 1, column));
            }
            if (column < 10)
            {
                cells.Add(Cells.At(row, column + 1));
            }
            return cells;
        }
    }
}
