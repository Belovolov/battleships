using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipControl.Ships
{
    /// <summary>
    /// Represents a Submarine type of Ship
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Width = 3;
            OccupationType = OccupationType.Submarine;
        }
    }
}
