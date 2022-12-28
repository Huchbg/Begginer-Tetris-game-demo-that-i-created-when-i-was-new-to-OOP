namespace experimenti_s_labeli
{
    partial class Tetris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoveDown = new System.Windows.Forms.Button();
            this.MoveRight = new System.Windows.Forms.Button();
            this.MoveLeft = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.Scorelbl = new System.Windows.Forms.Label();
            this.maxScorelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MoveDown
            // 
            this.MoveDown.Location = new System.Drawing.Point(405, 455);
            this.MoveDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(86, 31);
            this.MoveDown.TabIndex = 0;
            this.MoveDown.Text = "Down";
            this.MoveDown.UseVisualStyleBackColor = true;
            this.MoveDown.Visible = false;
            this.MoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // MoveRight
            // 
            this.MoveRight.Location = new System.Drawing.Point(498, 455);
            this.MoveRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MoveRight.Name = "MoveRight";
            this.MoveRight.Size = new System.Drawing.Size(86, 31);
            this.MoveRight.TabIndex = 1;
            this.MoveRight.Text = "MoveRight";
            this.MoveRight.UseVisualStyleBackColor = true;
            this.MoveRight.Visible = false;
            this.MoveRight.Click += new System.EventHandler(this.MoveRight_Click);
            // 
            // MoveLeft
            // 
            this.MoveLeft.Location = new System.Drawing.Point(463, 402);
            this.MoveLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MoveLeft.Name = "MoveLeft";
            this.MoveLeft.Size = new System.Drawing.Size(86, 31);
            this.MoveLeft.TabIndex = 2;
            this.MoveLeft.Text = "MoveLeft";
            this.MoveLeft.UseVisualStyleBackColor = true;
            this.MoveLeft.Visible = false;
            this.MoveLeft.Click += new System.EventHandler(this.MoveLeft_Click);
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.SpringGreen;
            this.StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGame.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartGame.Location = new System.Drawing.Point(437, 293);
            this.StartGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(94, 35);
            this.StartGame.TabIndex = 3;
            this.StartGame.Text = "StartGame";
            this.StartGame.UseVisualStyleBackColor = false;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // Scorelbl
            // 
            this.Scorelbl.AutoSize = true;
            this.Scorelbl.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Scorelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Scorelbl.Location = new System.Drawing.Point(403, 50);
            this.Scorelbl.Name = "Scorelbl";
            this.Scorelbl.Size = new System.Drawing.Size(86, 31);
            this.Scorelbl.TabIndex = 4;
            this.Scorelbl.Text = "Score=";
            this.Scorelbl.Click += new System.EventHandler(this.Scorelbl_Click);
            // 
            // maxScorelbl
            // 
            this.maxScorelbl.AutoSize = true;
            this.maxScorelbl.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxScorelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.maxScorelbl.Location = new System.Drawing.Point(403, 98);
            this.maxScorelbl.Name = "maxScorelbl";
            this.maxScorelbl.Size = new System.Drawing.Size(114, 31);
            this.maxScorelbl.TabIndex = 5;
            this.maxScorelbl.Text = "MaxScore";
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(639, 650);
            this.Controls.Add(this.maxScorelbl);
            this.Controls.Add(this.Scorelbl);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.MoveLeft);
            this.Controls.Add(this.MoveRight);
            this.Controls.Add(this.MoveDown);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Tetris";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button MoveRight;
        private System.Windows.Forms.Button MoveLeft;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Label Scorelbl;
        private System.Windows.Forms.Label maxScorelbl;
    }
}
