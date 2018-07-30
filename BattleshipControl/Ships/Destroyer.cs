using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipControl.Ships
{
    /// <summary>
    /// Represents a Destroyer type of Ship
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 2;
            OccupationType = OccupationType.Destroyer;
        }
    }
}
