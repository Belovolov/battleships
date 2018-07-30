using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipControl.Ships
{
    /// <summary>
    /// Represents a Battleship type of Ship
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = 4;
            OccupationType = OccupationType.Battleship;
        }
    }
}
