using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipControl.Boards;

namespace BattleshipControl.Players
{
    /// <summary>
    /// The class represents the Bot player (computer) and its automated playing routines
    /// Author: Roman Belovolov
    /// Inspired by: Matthew Jones
    /// Date: 08/04/2018
    /// </summary>
    public class BotPlayer:Player
    {
        public BotPlayer(string name) : base(name) { }

        /// <summary>
        /// Choose a cell for firing a shot and return its coordinates
        /// </summary>
        public Coordinates FireShot()
        {
            //If there are hits on the board with neighbors which don't have shots, we should fire at those first.
            Random r = new Random();
            var hitNeighbors = FiringBoard.GetHitNeighbors();
            Coordinates coords;
            if (hitNeighbors.Any())
            {
                coords = SearchingShot();
            }
            else
            {
                coords = RandomShot();
            }
            return coords;
        }

        /// <summary>
        /// Choose a random cell according to semi-random strategy
        /// </summary>
        /// <returns>Semi-random cell coordinates</returns>
        private Coordinates RandomShot()
        {
            var availableCells = FiringBoard.GetOpenRandomCells();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var CellID = rand.Next(availableCells.Count);
            return availableCells[CellID];
        }
        /// <summary>
        /// Choose a cell around the one that has been hit to completely destroy a ship
        /// </summary>
        /// <returns>Adjacent coordinates</returns>
        private Coordinates SearchingShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var hitNeighbors = FiringBoard.GetHitNeighbors();
            var neighborID = rand.Next(hitNeighbors.Count);
            return hitNeighbors[neighborID];
        }
    }
}
