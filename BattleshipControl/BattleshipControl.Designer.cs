namespace BattleshipControl
{
    partial class BattleshipControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleshipControl));
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.pnlFiringBoard = new System.Windows.Forms.Panel();
            this.lblInformation = new System.Windows.Forms.Label();
            this.ttRestart = new System.Windows.Forms.ToolTip(this.components);
            this.pnlShipSelection = new System.Windows.Forms.Panel();
            this.lblYourGrid = new System.Windows.Forms.Label();
            this.lblOpponentsGrid = new System.Windows.Forms.Label();
            this.pnlMyDashboard = new System.Windows.Forms.Panel();
            this.pnlOpponentsDashboard = new System.Windows.Forms.Panel();
            this.rbHorizontal = new System.Windows.Forms.RadioButton();
            this.rbVertical = new System.Windows.Forms.RadioButton();
            this.gpbOrientation = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCloseHelp = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnArrngManual = new System.Windows.Forms.Button();
            this.btnArrngRandom = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOpenHelp = new System.Windows.Forms.Button();
            this.lblManualArrngeInfo = new System.Windows.Forms.Label();
            this.gpbOrientation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtHelp.Location = new System.Drawing.Point(410, 13);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.Size = new System.Drawing.Size(274, 253);
            this.txtHelp.TabIndex = 2;
            this.txtHelp.Text = resources.GetString("txtHelp.Text");
            this.txtHelp.Visible = false;
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGameBoard.Location = new System.Drawing.Point(95, 43);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(253, 253);
            this.pnlGameBoard.TabIndex = 5;
            // 
            // pnlFiringBoard
            // 
            this.pnlFiringBoard.Location = new System.Drawing.Point(396, 43);
            this.pnlFiringBoard.Name = "pnlFiringBoard";
            this.pnlFiringBoard.Size = new System.Drawing.Size(253, 253);
            this.pnlFiringBoard.TabIndex = 8;
            this.pnlFiringBoard.Visible = false;
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInformation.Location = new System.Drawing.Point(17, 98);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(199, 150);
            this.lblInformation.TabIndex = 9;
            this.lblInformation.Text = resources.GetString("lblInformation.Text");
            // 
            // pnlShipSelection
            // 
            this.pnlShipSelection.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlShipSelection.Location = new System.Drawing.Point(561, 302);
            this.pnlShipSelection.Name = "pnlShipSelection";
            this.pnlShipSelection.Size = new System.Drawing.Size(123, 37);
            this.pnlShipSelection.TabIndex = 11;
            this.pnlShipSelection.Visible = false;
            // 
            // lblYourGrid
            // 
            this.lblYourGrid.AutoSize = true;
            this.lblYourGrid.Location = new System.Drawing.Point(49, 325);
            this.lblYourGrid.Name = "lblYourGrid";
            this.lblYourGrid.Size = new System.Drawing.Size(49, 13);
            this.lblYourGrid.TabIndex = 12;
            this.lblYourGrid.Text = "Your grid";
            this.lblYourGrid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblYourGrid.Visible = false;
            // 
            // lblOpponentsGrid
            // 
            this.lblOpponentsGrid.AutoSize = true;
            this.lblOpponentsGrid.Location = new System.Drawing.Point(124, 325);
            this.lblOpponentsGrid.Name = "lblOpponentsGrid";
            this.lblOpponentsGrid.Size = new System.Drawing.Size(81, 13);
            this.lblOpponentsGrid.TabIndex = 13;
            this.lblOpponentsGrid.Text = "Opponent\'s grid";
            this.lblOpponentsGrid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblOpponentsGrid.Visible = false;
            // 
            // pnlMyDashboard
            // 
            this.pnlMyDashboard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMyDashboard.Location = new System.Drawing.Point(14, 155);
            this.pnlMyDashboard.Name = "pnlMyDashboard";
            this.pnlMyDashboard.Size = new System.Drawing.Size(68, 141);
            this.pnlMyDashboard.TabIndex = 6;
            this.pnlMyDashboard.Visible = false;
            // 
            // pnlOpponentsDashboard
            // 
            this.pnlOpponentsDashboard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOpponentsDashboard.Location = new System.Drawing.Point(662, 155);
            this.pnlOpponentsDashboard.Name = "pnlOpponentsDashboard";
            this.pnlOpponentsDashboard.Size = new System.Drawing.Size(68, 141);
            this.pnlOpponentsDashboard.TabIndex = 7;
            this.pnlOpponentsDashboard.Visible = false;
            // 
            // rbHorizontal
            // 
            this.rbHorizontal.AutoSize = true;
            this.rbHorizontal.Checked = true;
            this.rbHorizontal.Location = new System.Drawing.Point(16, 19);
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.Size = new System.Drawing.Size(72, 17);
            this.rbHorizontal.TabIndex = 1;
            this.rbHorizontal.TabStop = true;
            this.rbHorizontal.Text = "Horizontal";
            this.rbHorizontal.UseVisualStyleBackColor = true;
            this.rbHorizontal.CheckedChanged += new System.EventHandler(this.rbOrientation_CheckedChanged);
            // 
            // rbVertical
            // 
            this.rbVertical.AutoSize = true;
            this.rbVertical.Location = new System.Drawing.Point(16, 42);
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.Size = new System.Drawing.Size(60, 17);
            this.rbVertical.TabIndex = 2;
            this.rbVertical.Text = "Vertical";
            this.rbVertical.UseVisualStyleBackColor = true;
            this.rbVertical.CheckedChanged += new System.EventHandler(this.rbOrientation_CheckedChanged);
            // 
            // gpbOrientation
            // 
            this.gpbOrientation.Controls.Add(this.pictureBox2);
            this.gpbOrientation.Controls.Add(this.pictureBox1);
            this.gpbOrientation.Controls.Add(this.rbVertical);
            this.gpbOrientation.Controls.Add(this.rbHorizontal);
            this.gpbOrientation.Location = new System.Drawing.Point(17, 14);
            this.gpbOrientation.Name = "gpbOrientation";
            this.gpbOrientation.Size = new System.Drawing.Size(133, 63);
            this.gpbOrientation.TabIndex = 3;
            this.gpbOrientation.TabStop = false;
            this.gpbOrientation.Text = "Orientation";
            this.gpbOrientation.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BattleshipControl.Properties.Resources.vertical;
            this.pictureBox2.Location = new System.Drawing.Point(82, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 17);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BattleshipControl.Properties.Resources.expand;
            this.pictureBox1.Location = new System.Drawing.Point(84, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 17);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnCloseHelp
            // 
            this.btnCloseHelp.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnCloseHelp.BackgroundImage = global::BattleshipControl.Properties.Resources.cancel;
            this.btnCloseHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCloseHelp.FlatAppearance.BorderSize = 0;
            this.btnCloseHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseHelp.Location = new System.Drawing.Point(661, 14);
            this.btnCloseHelp.Name = "btnCloseHelp";
            this.btnCloseHelp.Size = new System.Drawing.Size(22, 22);
            this.btnCloseHelp.TabIndex = 3;
            this.btnCloseHelp.UseVisualStyleBackColor = false;
            this.btnCloseHelp.Visible = false;
            this.btnCloseHelp.Click += new System.EventHandler(this.btnCloseHelp_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewGame.BackgroundImage = global::BattleshipControl.Properties.Resources.restart;
            this.btnNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNewGame.Enabled = false;
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Location = new System.Drawing.Point(690, 48);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(40, 39);
            this.btnNewGame.TabIndex = 10;
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnArrngManual
            // 
            this.btnArrngManual.Image = global::BattleshipControl.Properties.Resources.drag;
            this.btnArrngManual.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArrngManual.Location = new System.Drawing.Point(338, 301);
            this.btnArrngManual.Name = "btnArrngManual";
            this.btnArrngManual.Size = new System.Drawing.Size(162, 23);
            this.btnArrngManual.TabIndex = 7;
            this.btnArrngManual.Text = "Reset and arrange manually";
            this.btnArrngManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArrngManual.UseVisualStyleBackColor = true;
            this.btnArrngManual.Click += new System.EventHandler(this.btnArrngManual_Click);
            // 
            // btnArrngRandom
            // 
            this.btnArrngRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnArrngRandom.Image = global::BattleshipControl.Properties.Resources.shuffle;
            this.btnArrngRandom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArrngRandom.Location = new System.Drawing.Point(240, 301);
            this.btnArrngRandom.Name = "btnArrngRandom";
            this.btnArrngRandom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnArrngRandom.Size = new System.Drawing.Size(83, 23);
            this.btnArrngRandom.TabIndex = 7;
            this.btnArrngRandom.Text = "Randomise";
            this.btnArrngRandom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArrngRandom.UseVisualStyleBackColor = true;
            this.btnArrngRandom.Click += new System.EventHandler(this.btnArrngRandom_Click);
            // 
            // btnStart
            // 
            this.btnStart.Image = global::BattleshipControl.Properties.Resources.circular_target;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.Location = new System.Drawing.Point(264, 330);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(205, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOpenHelp
            // 
            this.btnOpenHelp.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenHelp.BackgroundImage = global::BattleshipControl.Properties.Resources.question;
            this.btnOpenHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpenHelp.FlatAppearance.BorderSize = 0;
            this.btnOpenHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenHelp.Location = new System.Drawing.Point(690, 3);
            this.btnOpenHelp.Name = "btnOpenHelp";
            this.btnOpenHelp.Size = new System.Drawing.Size(40, 39);
            this.btnOpenHelp.TabIndex = 1;
            this.btnOpenHelp.UseVisualStyleBackColor = false;
            this.btnOpenHelp.Click += new System.EventHandler(this.btnOpenHelp_Click);
            // 
            // lblManualArrngeInfo
            // 
            this.lblManualArrngeInfo.AutoSize = true;
            this.lblManualArrngeInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblManualArrngeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManualArrngeInfo.Location = new System.Drawing.Point(14, 134);
            this.lblManualArrngeInfo.Name = "lblManualArrngeInfo";
            this.lblManualArrngeInfo.Size = new System.Drawing.Size(204, 90);
            this.lblManualArrngeInfo.TabIndex = 14;
            this.lblManualArrngeInfo.Text = "You can not remove a deployed ship\r\nIf you made a mistake, \r\nreset and start agai" +
    "n\r\n\r\nWhy so brutal?\r\nWell, any whim for your money";
            this.lblManualArrngeInfo.Visible = false;
            // 
            // BattleshipControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.gpbOrientation);
            this.Controls.Add(this.lblManualArrngeInfo);
            this.Controls.Add(this.lblOpponentsGrid);
            this.Controls.Add(this.lblYourGrid);
            this.Controls.Add(this.pnlShipSelection);
            this.Controls.Add(this.btnCloseHelp);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pnlFiringBoard);
            this.Controls.Add(this.btnArrngManual);
            this.Controls.Add(this.btnArrngRandom);
            this.Controls.Add(this.pnlGameBoard);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOpenHelp);
            this.Controls.Add(this.pnlOpponentsDashboard);
            this.Controls.Add(this.pnlMyDashboard);
            this.Name = "BattleshipControl";
            this.Size = new System.Drawing.Size(744, 358);
            this.Load += new System.EventHandler(this.BattleshipControl_Load);
            this.gpbOrientation.ResumeLayout(false);
            this.gpbOrientation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenHelp;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.Button btnCloseHelp;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Button btnArrngRandom;
        private System.Windows.Forms.Button btnArrngManual;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.ToolTip ttRestart;
        private System.Windows.Forms.Panel pnlShipSelection;
        private System.Windows.Forms.Label lblYourGrid;
        private System.Windows.Forms.Label lblOpponentsGrid;
        private System.Windows.Forms.Panel pnlMyDashboard;
        private System.Windows.Forms.Panel pnlOpponentsDashboard;
        private System.Windows.Forms.Panel pnlFiringBoard;
        private System.Windows.Forms.GroupBox gpbOrientation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbVertical;
        private System.Windows.Forms.RadioButton rbHorizontal;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblManualArrngeInfo;
    }
}
