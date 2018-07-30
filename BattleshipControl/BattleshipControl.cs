using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleshipControl.Boards;
using BattleshipControl.Ships;

namespace BattleshipControl
{
    /// <summary>
    /// The class represents the interface of the game
    /// Author: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    public partial class BattleshipControl : UserControl
    {
        const int PANEL_SIZE = 23;
        const int GRID_SIZE = 10;
        Color CELL_COLOR = Color.White;
        Color CELL_COLOR_HIDDEN = Color.LightGray;
        Color SHIP_COLOR = Color.Navy;

        char[] letters = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        Ship activeShipSelection;
        ShipDirection selectedOrientation;
        Label[,] myCells;
        Label[,] enemyCells;
        List<Label> myShipLabels = new List<Label>();
        List<Label> myDshbShipLabels = new List<Label>();
        List<Label> shotResultLabels = new List<Label>();
        List<Label> enemyDshbShipLabels = new List<Label>();
        public bool BlockUserActions {
            set
            {
                pnlFiringBoard.Enabled = !value;
            }
            get
            {
                return !pnlFiringBoard.Enabled;
            }
        }
        GameController game;
        public BattleshipControl()
        {
            InitializeComponent();
            game = new GameController(this);
        }
        /// <summary>
        /// Opens help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenHelp_Click(object sender, EventArgs e)
        {
            txtHelp.BringToFront();
            btnCloseHelp.BringToFront();
            btnCloseHelp.Visible = true;
            txtHelp.Visible = true;
        }
        /// <summary>
        /// Closes previously opened help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseHelp_Click(object sender, EventArgs e)
        {
            txtHelp.Visible = false;
            
            btnCloseHelp.Visible = false;
        }

        /// <summary>
        /// Programmatically render 100 labels which represent cells of boards
        /// </summary>
        /// <param name="board"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public Label[,] renderPlainBoard(Panel board, bool enemy = false)
        {
            Label[,] cells = new Label[10, 10];
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Label newLbl = new Label
                    {
                        Name = letters[i].ToString() + (j + 1).ToString(),
                        Location = new Point(PANEL_SIZE * (i + 1), PANEL_SIZE * (j + 1)),
                        Size = new Size(PANEL_SIZE - 1, PANEL_SIZE - 1),
                        BackColor = (enemy) ? CELL_COLOR_HIDDEN : CELL_COLOR
                    };
                    if (enemy) newLbl.Click += lblFiringCell_Click;
                    else newLbl.Click += selectionCellClick;
                    cells[i, j] = newLbl;
                    board.Controls.Add(newLbl);
                }
            }
            renderAlphaNumericalLabels(board);
            return cells;
        }

        /// <summary>
        /// Programmatically render label for rows (1,2,..,10) and columns (A,B,..J)
        /// </summary>
        /// <param name="board"></param>
        public void renderAlphaNumericalLabels(Panel board)
        {
            Size size = new Size(PANEL_SIZE - 1, PANEL_SIZE - 1);
            for (int i = 0; i < 10; i++)
            {
                Label lblCol = new Label
                {
                    Location = new Point(PANEL_SIZE * (i + 1), 0),
                    Size = size,
                    Text = letters[i].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lblRow = new Label
                {
                    Location = new Point(0, PANEL_SIZE * (i + 1)),
                    Size = size,
                    Text = (i + 1).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                board.Controls.Add(lblCol);
                board.Controls.Add(lblRow);
            }
        }

        /// <summary>
        /// Handles game start button click (hide setup controls, render opponent's board,etc..)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //hide info label
            lblInformation.Visible = false;
            lblManualArrngeInfo.Visible = false;
            btnStart.Visible = false;
            btnArrngRandom.Visible = false;
            btnArrngManual.Visible = false;
            btnNewGame.Enabled = true;

            pnlShipSelection.Visible = false;

            //put gameboard where it should be
            pnlGameBoard.Location = new Point(this.Width / 2 - pnlGameBoard.Width - 20, pnlGameBoard.Location.Y);

            //draw opponent's board
            pnlFiringBoard.Location = new Point(this.Size.Width / 2 + 20, pnlGameBoard.Location.Y);
            if (enemyCells == null) enemyCells = renderPlainBoard(pnlFiringBoard, true);
            pnlFiringBoard.Visible = true;
            pnlFiringBoard.Enabled = true;

            lblYourGrid.Location = new Point(pnlGameBoard.Location.X + pnlGameBoard.Width / 3, pnlGameBoard.Location.Y + pnlGameBoard.Height + 15);
            lblYourGrid.Visible = true;

            lblOpponentsGrid.Location = new Point(pnlFiringBoard.Location.X + pnlFiringBoard.Width / 3, pnlFiringBoard.Location.Y + pnlFiringBoard.Height + 15);
            lblOpponentsGrid.Visible = true;

            pnlFiringBoard.Enabled = false;
            game.Start();
            pnlFiringBoard.Enabled = true;
        }
        /// <summary>
        /// Reneder initial setup state with pre-generated user's ships' arrangement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleshipControl_Load(object sender, EventArgs e)
        {
            //set up tooltip
            ttRestart.SetToolTip(btnNewGame, "Stop this game and start a new one");
            ttRestart.SetToolTip(btnOpenHelp, "Show help");
            //put game board in the center
            pnlGameBoard.Location = new Point((this.Width - pnlGameBoard.Width) / 2, pnlGameBoard.Location.Y);
            //draw field
            if (myCells == null) myCells = renderPlainBoard(pnlGameBoard);
            //render ships
            game.getHumanShips();
        }

        /// <summary>
        /// Method to invoke generation of a new arrangement of ships on click of the corresponding button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArrngRandom_Click(object sender, EventArgs e)
        {            
            game.getNewHumanRandom();
            btnStart.Enabled = true;
            pnlShipSelection.Visible = false;
            lblManualArrngeInfo.Visible = false;
            gpbOrientation.Visible = false;
        }

        /// <summary>
        /// Initiate manual ship selection feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArrngManual_Click(object sender, EventArgs e)
        {
            //remove ships from the board
            clearLabelList(myShipLabels);
            //disable Start button
            btnStart.Enabled = false;
            lblManualArrngeInfo.Visible = true;
            lblInformation.Visible = false;
            //add click listeners to cells
            selectedOrientation = ShipDirection.Horizontal;
            rbHorizontal.Checked = true;
            game.StartManualArrangement();
            
        }
        /// <summary>
        /// Renders the click on a cell for manual ship arrangement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectionCellClick(object sender, EventArgs e)
        {
            if (game.phase == GamePhase.ManualSetup)
            {
                if (activeShipSelection != null)
                {
                    Label lbl = (Label)sender;
                    Coordinates selectedCell = new Coordinates(
                        lbl.Location.Y / PANEL_SIZE,
                        lbl.Location.X / PANEL_SIZE
                    );
                    activeShipSelection.Direction = selectedOrientation;
                    activeShipSelection.Position = selectedCell;
                    if (game.PlaceToManualBoard(activeShipSelection))
                    {
                        renderOneHumanShip(activeShipSelection);
                        //disable corresponding radiobutton
                        RadioButton rb = (RadioButton)pnlShipSelection.Controls.Find(activeShipSelection.Name, false).First();
                        rb.Checked = false;
                        rb.Enabled = false;
                        activeShipSelection = null;
                        //check if all ships are arranged and set up player if yes
                        if (game.FinalizeManualArrangement())
                        {
                            btnStart.Enabled = true;
                        }
                        //if all ships are placed, Enable start button
                    }
                    else
                    {
                        MessageBox.Show("Invalid placement");
                    }
                }
            }
                        
        }
        /// <summary>
        /// renders the panel for ship selection
        /// </summary>
        /// <param name="ships"></param>
        public void renderShipSelection(List<Ship> ships)
        {
            int PADDING = (5 * PANEL_SIZE) / 6;
            pnlShipSelection.Height = PANEL_SIZE * GRID_SIZE;
            pnlShipSelection.Width = PANEL_SIZE * 5 + PADDING * 2;
            pnlShipSelection.Location = new Point(pnlGameBoard.Location.X + pnlGameBoard.Width + 10, pnlGameBoard.Location.Y + PANEL_SIZE);
            pnlShipSelection.Controls.Clear();

            for (int i = 0; i < ships.Count; i++)
            {
                RadioButton ship = new RadioButton()
                {
                    Name = ships[i].Name,
                    Width = ships[i].Width * PANEL_SIZE,
                    Appearance = Appearance.Button,
                    Height = PANEL_SIZE,
                    Location = new Point(PADDING, PADDING / 2 + i * (PANEL_SIZE + PADDING / 2)),
                    BackColor = SystemColors.MenuHighlight,
                    ForeColor = Color.White,
                    Tag = ships[i]
                };
                ship.CheckedChanged += rbShip_CheckedChanged;
                pnlShipSelection.Controls.Add(ship);
            }

            pnlShipSelection.Controls.Add(gpbOrientation);
            pnlShipSelection.Visible = true;
            gpbOrientation.Location = new Point(PADDING, pnlShipSelection.Height - gpbOrientation.Height);
            gpbOrientation.Visible = true;
        }

        /// <summary>
        /// Renders human player's ships on the GameBoard
        /// </summary>
        public void renderHumanShips(List<Ship> ships)
        {
            if (myShipLabels.Any())
            {
                clearLabelList(myShipLabels);
            }
            if (game != null)
            {
                foreach (var ship in ships)
                {
                    renderOneHumanShip(ship);
                }
            }
        }
        /// <summary>
        /// render one ship on the human gameboard
        /// </summary>
        /// <param name="ship"></param>
        public void renderOneHumanShip(Ship ship)
        {
            int width = (ship.Direction == ShipDirection.Horizontal) ? PANEL_SIZE * ship.Width - 1 : PANEL_SIZE - 1;
            int height = (ship.Direction == ShipDirection.Vertical) ? PANEL_SIZE * ship.Width - 1 : PANEL_SIZE - 1;
            Label lblShip = new Label()
            {
                Name = ship.Name,
                Location = new Point(PANEL_SIZE * ship.Position.Column, PANEL_SIZE * ship.Position.Row),
                Size = new Size(width, height),
                BackColor = SHIP_COLOR
            };
            myShipLabels.Add(lblShip);
            pnlGameBoard.Controls.Add(lblShip);
            lblShip.BringToFront();
        }
        /// <summary>
        /// Handles new game button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnNewGame.Enabled = false;
            game.Reset();
        }
        /// <summary>
        /// Click event handler for firing board cell (user's shooting)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiringCell_Click(object sender, EventArgs e)
        {
            Label firedLabel = (Label)sender;
            Coordinates firedCell = new Coordinates(
                firedLabel.Location.Y / PANEL_SIZE,
                firedLabel.Location.X / PANEL_SIZE
            );
            game.HandleHumanShot(firedCell);
            
        }
        /// <summary>
        /// Put a label on a board to show whether a shot was hit or miss
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="result"></param>
        /// <param name="humanBoard"></param>
        public void showShotResult(Coordinates coordinates, ShotResult result, bool humanBoard = true)
        {
            Label lblShotResult = new Label();
            lblShotResult.Location = new Point(coordinates.Column * PANEL_SIZE, coordinates.Row * PANEL_SIZE);
            lblShotResult.Size = new Size(PANEL_SIZE - 1, PANEL_SIZE - 1);
            if (result == ShotResult.Miss)
            {
                lblShotResult.Image = Properties.Resources.circle_gray;
                lblShotResult.BackColor = CELL_COLOR;
            }
            else
            {
                lblShotResult.Image = Properties.Resources.cancel_red;
                lblShotResult.BackColor = SHIP_COLOR;
            }

            if (humanBoard)
            {
                pnlGameBoard.Controls.Add(lblShotResult);
            }
            else
            {
                pnlFiringBoard.Controls.Add(lblShotResult);
            }
            lblShotResult.BringToFront();
            shotResultLabels.Add(lblShotResult);
        }
        /// <summary>
        /// Show inital state of controls
        /// </summary>
        public void showInitialView()
        {
            pnlGameBoard.Location = new Point((this.Width - pnlGameBoard.Width) / 2, pnlGameBoard.Location.Y);
            pnlFiringBoard.Visible = false;

            clearLabelList(shotResultLabels);
            lblInformation.Visible = true;
            btnStart.Visible = true;
            btnArrngRandom.Visible = true;
            btnArrngManual.Visible = true;

            pnlOpponentsDashboard.Visible = false;
            pnlMyDashboard.Visible = false;
            lblYourGrid.Visible = false;
            lblOpponentsGrid.Visible = false;
        }
        /// <summary>
        /// Helper method to dispose of a programatically generated list of labels
        /// </summary>
        /// <param name="list"></param>
        private void clearLabelList(List<Label> list)
        {
            foreach (var lbl in list)
            {
                lbl.Dispose();
            }
            list.Clear();
        }
        /// <summary>
        /// Render a dashboard to show the current status of one's fleet
        /// </summary>
        /// <param name="ships"></param>
        /// <param name="isForEnemy"></param>
        public void renderShipDashboard(List<Ship> ships, bool isForEnemy)
        {
            int PADDING = 4;
            int WIDTH_UNIT = 10;
            Panel panel = (isForEnemy) ? pnlOpponentsDashboard : pnlMyDashboard;
            panel.Controls.Clear();
            for (int i = 0; i < ships.Count; i++)
            {
                for (int j = 0; j < ships[i].Width; j++)
                {
                    Label lblShip = new Label()
                    {
                        Width = WIDTH_UNIT - 1,
                        Height = WIDTH_UNIT - 1,
                        BackColor = (ships[i].IsSunk) ? Color.Red : Color.Navy,
                        Location = new Point(PADDING + WIDTH_UNIT * j, PADDING + (WIDTH_UNIT + PADDING) * i)
                    };
                    panel.Controls.Add(lblShip);
                }
            }
            panel.Visible = true;
        }
        /// <summary>
        /// Indicate that the game is over
        /// </summary>
        public void renderGameOver(string message)
        {
            this.BlockUserActions = true;
            MessageBox.Show(message);
        }
        /// <summary>
        /// ship selection radiobutton handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbShip_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
            if (rb.Checked)
            {
                rb.BackColor = Color.Navy;
                activeShipSelection = (Ship)rb.Tag;
            }
            else
            {
                rb.BackColor = SystemColors.ActiveCaption;
            }
        }
        /// <summary>
        /// Orientation radio buttons change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbOrientation_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
            if (rb.Checked)
            {
                selectedOrientation = (rb.Text == "Horizontal") ? ShipDirection.Horizontal : ShipDirection.Vertical;
            }
        }
    }
}
 