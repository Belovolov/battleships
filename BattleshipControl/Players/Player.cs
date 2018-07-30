using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipControl.Ships;
using BattleshipControl.Boards;
using BattleshipControl.Extensions;

namespace BattleshipControl.Players
{
    /// <summary>
    /// The class represents a player
    /// Author: Matthew Jones
    /// Modified: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    public class Player
    {
        private const int GRID_SIZE = 10;
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        public FiringBoard FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public static List<Ship> AvailableShips = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        /// <summary>
        /// The class constructor which intializes players boards and ships
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            GameBoard = new GameBoard();
            FiringBoard = new FiringBoard();
        }
        /// <summary>
        /// Place ships randomly inside of the field and not touching each other
        /// </summary>
        public void PlaceShipsRandomly()
        {
            this.GameBoard = new GameBoard();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed Cells are occupied, place the ship
                //Do this for all ships
                bool isOpen = true;
                while (isOpen)
                {
                    var startcolumn = rand.Next(1, 11);
                    var startrow = rand.Next(1, 11);
                    int endrow = startrow, endcolumn = startcolumn;
                    var orientation = rand.Next(1, 101) % 2; //0 for Horizontal

                    if (orientation == 0)
                    {
                        endcolumn += ship.Width - 1;
                    }
                    else
                    {
                        endrow += ship.Width - 1;
                    }
                    if (GameBoard.IsPlacementValid(new Coordinates(startrow, startcolumn), (ShipDirection)orientation, ship.Width))
                    {
                        ship.Direction = (ShipDirection)orientation;
                        ship.Position = new Coordinates(startrow, startcolumn);
                        var shipCells = GameBoard.Cells.Range(startrow, startcolumn, endrow, endcolumn);
                        foreach (var cell in shipCells)
                        {
                            cell.OccupationType = ship.OccupationType;
                        }
                        isOpen = false;
                    }                    
                }
            }
        }        
        /// <summary>
        /// Method returns a result of the attempted shot by the oponent
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        public ShotResult ProcessShot(Coordinates coords)
        {
            var Cell = GameBoard.Cells.At(coords.Row, coords.Column);
            if (!Cell.IsOccupied)
            {
                return ShotResult.Miss;
            }
            var ship = Ships.First(x => x.OccupationType == Cell.OccupationType);
            ship.Hits++;
            
            if (ship.IsSunk)
            {
                return ShotResult.Sink;
            }
            else
            {
                return ShotResult.Hit;
            }            
        }
        /// <summary>
        /// Method handles result of the Player's attempt by marking the firing board
        /// </summary>
        /// <param name="coords"></param>
        /// <param name="result"></param>
        public void ProcessShotResult(Coordinates coords, ShotResult result)
        {
            var Cell = FiringBoard.Cells.At(coords.Row, coords.Column);
            switch (result)
            {
                case ShotResult.Hit:
                    Cell.OccupationType = OccupationType.Hit;
                    break;
                case ShotResult.Sink:
                    Cell.OccupationType = OccupationType.Sink;
                    break;
                default:
                    Cell.OccupationType = OccupationType.Miss;
                    break;
            }
        }
    }
}
