using System;
using System.Collections.Generic;
using BattleshipControl.Extensions;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BattleshipControl.Boards
{
    /// <summary>
    /// This class represents a single square on the game board.
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class Cell
    {
        public OccupationType OccupationType { get; set; }
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// This Cell constructor, where and with what it is occupied 
        /// </summary>
        public Cell(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
        }

        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.Battleship
                    || OccupationType == OccupationType.Destroyer
                    || OccupationType == OccupationType.Cruiser
                    || OccupationType == OccupationType.Submarine
                    || OccupationType == OccupationType.Carrier;
            }
        }
        /// <summary>
        /// This property identifies a cell which is suitable for the semi-random hiting strategy
        /// </summary>
        public bool IsRandomAvailable
        {
            get
            {
                return (Coordinates.Row % 2 == 0 && Coordinates.Column % 2 == 0)
                    || (Coordinates.Row % 2 == 1 && Coordinates.Column % 2 == 1);
            }
        }
    }
}
