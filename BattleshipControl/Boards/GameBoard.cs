using System;
using System.Collections.Generic;
using BattleshipControl.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipControl.Boards
{
    /// <summary>
    /// Represents a collection of Cells to provide a Player with their Game Board (e.g. where their ships are placed).
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class GameBoard
    {
        public List<Cell> Cells { get; set; }
        int GRID_SIZE = 10;
        /// <summary>
        /// GameBoard class constructor
        /// </summary>
        public GameBoard()
        {
            Cells = new List<Cell>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Cells.Add(new Cell(i, j));
                }
            }
        }
        /// <summary>
        /// Validates propposed placement
        /// </summary>
        /// <param name="position"></param>
        /// <param name="orientation"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool IsPlacementValid(Coordinates position, ShipDirection orientation, int width)
        {
            int endcolumn = position.Column;
            int endrow = position.Row;
            if (orientation == ShipDirection.Horizontal)
            {
                endcolumn += width - 1;
            }
            else
            {
                endrow += width - 1;
            }

            //We cannot place ships beyond the boundaries of the board
            if (endrow > GRID_SIZE || endcolumn > GRID_SIZE)
            {
                return false;
            }
            else
            {
                //Check if specified Cells are occupied
                var affectedCells = this.Cells.ExtendedRange(position.Row, position.Column, endrow, endcolumn);
                if (affectedCells.Any(x => x.IsOccupied))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
