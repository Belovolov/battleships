using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipControl.Ships
{
    /// <summary>
    /// Represents a Carrier type of Ship
    /// Author: Matthew Jones
    /// Date: 14/03/2017
    /// </summary>
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Aircraft Carrier";
            Width = 5;
            OccupationType = OccupationType.Carrier;
        }
    }
}
