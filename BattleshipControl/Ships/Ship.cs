using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipControl.Boards;

namespace BattleshipControl.Ships
{
    /// <summary>
    /// Represents a player's ship as placed on their Game Board.
    /// Author: Matthew Jones
    /// Modified: Roman Belovolov
    /// Date: 14/03/2017
    /// </summary>
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Hits { get; set; }
        public Coordinates Position { get; set; }
        public ShipDirection Direction { get; set; }
        public OccupationType OccupationType { get; set; }
        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }
    }
}
