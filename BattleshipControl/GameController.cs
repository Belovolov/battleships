using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleshipControl.Players;
using BattleshipControl.Boards;
using BattleshipControl.Ships;
using BattleshipControl.Extensions;
using BattleshipControl.Helpers;

namespace BattleshipControl
{
    /// <summary>
    /// The class represents the controller class for the game
    /// Author: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    class GameController
    {
        private Random randProvider = new Random(Guid.NewGuid().GetHashCode());
        public event EventHandler machineFinished;
        public event EventHandler humanFinished;
        BattleshipControl viewForm;
        public GamePhase phase { get; set; }
        private Player human { get; set; }
        private BotPlayer machine { get; set; }
        private GameBoard manualBoard;
        private List<Ship> manualShips;
        private bool humanFirst;
        public GameController(BattleshipControl form)
        {
            humanFirst = (randProvider.Next(1, 101) % 3 != 0); //human will be first in 2 cases out of 3
            viewForm = form;
            human = new Player("You");
            machine = new BotPlayer("Skynet");
            phase = GamePhase.Setup;
            human.PlaceShipsRandomly();
            machine.PlaceShipsRandomly();
            humanFinished += HumanFinishedEventHandler;
            machineFinished += MachineFinishedEventHandler;
        }
        /// <summary>
        /// Starts the game
        /// </summary>
        public void Start()
        {
            phase = GamePhase.Play;
            viewForm.renderShipDashboard(human.Ships.OrderBy(x=>x.Width).ToList(), false);
            viewForm.renderShipDashboard(machine.Ships, true);
            if (!humanFirst)
            {
                PlayMachineRound();
            }
        }
        /// <summary>
        /// Reset the state of the game to start a new one
        /// </summary>
        public void Reset()
        {
            phase = GamePhase.Setup;
            humanFirst = (randProvider.Next(1, 101) % 3 != 0);
            human = new Player("Anonymous");
            machine = new BotPlayer("Skynet");
            human.PlaceShipsRandomly();
            machine.PlaceShipsRandomly();
            viewForm.showInitialView();
            viewForm.renderHumanShips(human.Ships);
        }
        /// <summary>
        /// Check if the game is over and notify
        /// </summary>
        public bool checkAndProcessGameOver()
        {
            if (human.HasLost || machine.HasLost)
            {
                String message = (human.HasLost)
                    ? machine.Name + " has won the game!"
                    : "You have won the game!";

                viewForm.renderGameOver(message);
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Manages shot made by machine
        /// </summary>
        /// <returns>Shot result</returns>
        private ShotResult ManageMachineShot()
        {
            Coordinates coordinates;
            ShotResult result;
            ///sleep for a while to imitate human player
            System.Threading.Thread.Sleep(randProvider.Next(300, 700));
            coordinates = machine.FireShot();
            result = human.ProcessShot(coordinates);
            machine.ProcessShotResult(coordinates, result);
            viewForm.showShotResult(coordinates, result, true);

            if (result == ShotResult.Sink)
            {
                viewForm.renderShipDashboard(human.Ships, false);
            }
            return result;
        }
        /// <summary>
        /// Method implements bot player's (machine) round
        /// </summary>
        private void PlayMachineRound()
        {
            ShotResult result = ManageMachineShot();        

            while (result != ShotResult.Miss)
            {
                if (result == ShotResult.Sink && checkAndProcessGameOver() == true)
                    break;
                result = ManageMachineShot();
            }            
            machineFinished(this, null);
        }
        /// <summary>
        /// Handles user's shot
        /// </summary>
        /// <param name="coordinates"></param>
        public void HandleHumanShot(Coordinates coordinates)
        {
            ShotResult result;
            result = machine.ProcessShot(coordinates);
            human.ProcessShotResult(coordinates, result);
            viewForm.showShotResult(coordinates, result, false);

            if (result == ShotResult.Miss)
            {
                viewForm.BlockUserActions = true;
                humanFinished(this, null);
            }
            else if (result == ShotResult.Sink)
            {
                viewForm.renderShipDashboard(machine.Ships, true);
                MessageBox.Show("You've sunk my ship");
                checkAndProcessGameOver();
            }
        }
        /// <summary>
        /// generate new arrangement and send it to the viewform
        /// </summary>
        public void getNewHumanRandom()
        {
            human.PlaceShipsRandomly();
            viewForm.renderHumanShips(human.Ships);
        }
        /// <summary>
        /// get human's ships and send them to the viewform
        /// </summary>
        public void getHumanShips()
        {
            viewForm.renderHumanShips(human.Ships);
        }
        /// <summary>
        /// Initalize manual arrangent operation
        /// </summary>
        public void StartManualArrangement()
        {
            phase = GamePhase.ManualSetup;
            manualBoard = new GameBoard();
            manualShips = new List<Ship>();
            viewForm.renderShipSelection(Player.AvailableShips);            
        }
        /// <summary>
        /// Check if all ships are placed and sets up human if they are
        /// </summary>
        /// <returns></returns>
        public bool FinalizeManualArrangement()
        {
            if (manualShips.Count == Player.AvailableShips.Count)
            {
                human.GameBoard = manualBoard;
                human.Ships = manualShips;
                return true;
            }
            else return false;
            
        }
        /// <summary>
        /// Try to place a ship wth parameters from view form.
        /// If not valid just return false, otherwise true
        /// </summary>
        /// <param name="ship"></param>
        /// <returns></returns>
        public bool PlaceToManualBoard(Ship ship)
        {
            int endcolumn = ship.Position.Column;
            int endrow = ship.Position.Row;
            if (ship.Direction == ShipDirection.Horizontal)
            {
                endcolumn += ship.Width - 1;
            }
            else
            {
                endrow += ship.Width - 1;
            }
            if (manualBoard.IsPlacementValid(ship.Position, ship.Direction, ship.Width))
            {
                manualShips.Add(ship);
                var shipCells = manualBoard.Cells.Range(ship.Position.Row, ship.Position.Column, endrow, endcolumn);
                foreach (var cell in shipCells)
                {
                    cell.OccupationType = ship.OccupationType;
                }
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Machine finshed it's round handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MachineFinishedEventHandler(object sender, EventArgs e)
        {
            if (!human.HasLost)
            {
                EventHelper.FlushMouseMessages();
                viewForm.BlockUserActions = false;
            }                       
        }
        /// <summary>
        /// Human finished their round event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HumanFinishedEventHandler(object sender, EventArgs e)
        {
            viewForm.BlockUserActions = true;
            PlayMachineRound();
        }
    }
}
