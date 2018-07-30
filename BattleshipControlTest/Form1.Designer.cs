namespace BattleshipControlTest
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.battleshipControl1 = new BattleshipControl.BattleshipControl();
            this.SuspendLayout();
            // 
            // battleshipControl1
            // 
            this.battleshipControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.battleshipControl1.Location = new System.Drawing.Point(12, 21);
            this.battleshipControl1.Name = "battleshipControl1";
            this.battleshipControl1.Size = new System.Drawing.Size(738, 393);
            this.battleshipControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 426);
            this.Controls.Add(this.battleshipControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Battleship Control Test";
            this.ResumeLayout(false);

        }

        #endregion

        private BattleshipControl.BattleshipControl battleshipControl1;
    }
}

