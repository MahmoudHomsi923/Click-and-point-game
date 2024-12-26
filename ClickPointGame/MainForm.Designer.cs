namespace ClickPointGame
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerKreis = new System.Windows.Forms.Timer(this.components);
            this.lblPointsCounter = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblLife = new System.Windows.Forms.Label();
            this.lblLifeCounter = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeCounter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFSPCounter = new System.Windows.Forms.Label();
            this.lblFPS = new System.Windows.Forms.Label();
            this.lblHighScoreCounter = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.lblLevelCounter = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.TimerTime = new System.Windows.Forms.Timer(this.components);
            this.lblGameMenu = new System.Windows.Forms.Label();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.TimerCreat = new System.Windows.Forms.Timer(this.components);
            this.TimerLevel = new System.Windows.Forms.Timer(this.components);
            this.TimerLive = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.rdbtnEasy = new System.Windows.Forms.RadioButton();
            this.rdbtnMedium = new System.Windows.Forms.RadioButton();
            this.rdbtnHard = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerKreis
            // 
            this.TimerKreis.Interval = 16;
            this.TimerKreis.Tick += new System.EventHandler(this.TimerKreis_Tick);
            // 
            // lblPointsCounter
            // 
            this.lblPointsCounter.BackColor = System.Drawing.Color.White;
            this.lblPointsCounter.Cursor = System.Windows.Forms.Cursors.No;
            this.lblPointsCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsCounter.Location = new System.Drawing.Point(662, 43);
            this.lblPointsCounter.Name = "lblPointsCounter";
            this.lblPointsCounter.Size = new System.Drawing.Size(102, 37);
            this.lblPointsCounter.TabIndex = 0;
            this.lblPointsCounter.Text = "0";
            // 
            // lblPoints
            // 
            this.lblPoints.BackColor = System.Drawing.Color.White;
            this.lblPoints.Cursor = System.Windows.Forms.Cursors.No;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(550, 43);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(105, 37);
            this.lblPoints.TabIndex = 1;
            this.lblPoints.Text = "Points";
            // 
            // lblLife
            // 
            this.lblLife.BackColor = System.Drawing.Color.White;
            this.lblLife.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLife.Location = new System.Drawing.Point(550, 1);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(105, 37);
            this.lblLife.TabIndex = 2;
            this.lblLife.Text = "Life";
            // 
            // lblLifeCounter
            // 
            this.lblLifeCounter.BackColor = System.Drawing.Color.White;
            this.lblLifeCounter.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLifeCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLifeCounter.Location = new System.Drawing.Point(662, 1);
            this.lblLifeCounter.Name = "lblLifeCounter";
            this.lblLifeCounter.Size = new System.Drawing.Size(102, 37);
            this.lblLifeCounter.TabIndex = 3;
            this.lblLifeCounter.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Cursor = System.Windows.Forms.Cursors.No;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(880, 43);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(105, 37);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Time";
            // 
            // lblTimeCounter
            // 
            this.lblTimeCounter.BackColor = System.Drawing.Color.White;
            this.lblTimeCounter.Cursor = System.Windows.Forms.Cursors.No;
            this.lblTimeCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeCounter.Location = new System.Drawing.Point(992, 43);
            this.lblTimeCounter.Name = "lblTimeCounter";
            this.lblTimeCounter.Size = new System.Drawing.Size(91, 37);
            this.lblTimeCounter.TabIndex = 60;
            this.lblTimeCounter.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Moccasin;
            this.groupBox1.Controls.Add(this.lblFSPCounter);
            this.groupBox1.Controls.Add(this.lblFPS);
            this.groupBox1.Controls.Add(this.lblHighScoreCounter);
            this.groupBox1.Controls.Add(this.lblHighScore);
            this.groupBox1.Controls.Add(this.lblLevelCounter);
            this.groupBox1.Controls.Add(this.lblLevel);
            this.groupBox1.Controls.Add(this.lblTimeCounter);
            this.groupBox1.Controls.Add(this.lblLife);
            this.groupBox1.Controls.Add(this.lblLifeCounter);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblPointsCounter);
            this.groupBox1.Controls.Add(this.lblPoints);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, -1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1354, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblFSPCounter
            // 
            this.lblFSPCounter.BackColor = System.Drawing.Color.White;
            this.lblFSPCounter.Cursor = System.Windows.Forms.Cursors.No;
            this.lblFSPCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFSPCounter.Location = new System.Drawing.Point(992, 0);
            this.lblFSPCounter.Name = "lblFSPCounter";
            this.lblFSPCounter.Size = new System.Drawing.Size(91, 37);
            this.lblFSPCounter.TabIndex = 64;
            this.lblFSPCounter.Text = "0";
            // 
            // lblFPS
            // 
            this.lblFPS.BackColor = System.Drawing.Color.White;
            this.lblFPS.Cursor = System.Windows.Forms.Cursors.No;
            this.lblFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPS.Location = new System.Drawing.Point(880, 0);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(105, 37);
            this.lblFPS.TabIndex = 63;
            this.lblFPS.Text = "FPS";
            // 
            // lblHighScoreCounter
            // 
            this.lblHighScoreCounter.BackColor = System.Drawing.Color.White;
            this.lblHighScoreCounter.Cursor = System.Windows.Forms.Cursors.No;
            this.lblHighScoreCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScoreCounter.Location = new System.Drawing.Point(369, -2);
            this.lblHighScoreCounter.Name = "lblHighScoreCounter";
            this.lblHighScoreCounter.Size = new System.Drawing.Size(71, 37);
            this.lblHighScoreCounter.TabIndex = 62;
            this.lblHighScoreCounter.Text = "0";
            // 
            // lblHighScore
            // 
            this.lblHighScore.BackColor = System.Drawing.Color.White;
            this.lblHighScore.Cursor = System.Windows.Forms.Cursors.No;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.Location = new System.Drawing.Point(187, 1);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(161, 37);
            this.lblHighScore.TabIndex = 61;
            this.lblHighScore.Text = "Highscore";
            // 
            // lblLevelCounter
            // 
            this.lblLevelCounter.BackColor = System.Drawing.Color.White;
            this.lblLevelCounter.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLevelCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelCounter.Location = new System.Drawing.Point(369, 39);
            this.lblLevelCounter.Name = "lblLevelCounter";
            this.lblLevelCounter.Size = new System.Drawing.Size(71, 37);
            this.lblLevelCounter.TabIndex = 7;
            this.lblLevelCounter.Text = "0";
            // 
            // lblLevel
            // 
            this.lblLevel.BackColor = System.Drawing.Color.White;
            this.lblLevel.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(187, 43);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(161, 37);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "Level";
            // 
            // TimerTime
            // 
            this.TimerTime.Interval = 1000;
            this.TimerTime.Tick += new System.EventHandler(this.TimerTime_Tick);
            // 
            // lblGameMenu
            // 
            this.lblGameMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblGameMenu.Cursor = System.Windows.Forms.Cursors.No;
            this.lblGameMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGameMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameMenu.ForeColor = System.Drawing.Color.Red;
            this.lblGameMenu.Location = new System.Drawing.Point(308, 121);
            this.lblGameMenu.Name = "lblGameMenu";
            this.lblGameMenu.Size = new System.Drawing.Size(775, 246);
            this.lblGameMenu.TabIndex = 15;
            this.lblGameMenu.Text = "Game Start";
            this.lblGameMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGameMenu.Visible = false;
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.Moccasin;
            this.btnResume.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(571, 450);
            this.btnResume.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(227, 50);
            this.btnResume.TabIndex = 19;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Visible = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Moccasin;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(571, 510);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(227, 50);
            this.btnRestart.TabIndex = 20;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Moccasin;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(571, 570);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(227, 50);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // TimerCreat
            // 
            this.TimerCreat.Interval = 1;
            this.TimerCreat.Tick += new System.EventHandler(this.TimerCreat_Tick);
            // 
            // TimerLevel
            // 
            this.TimerLevel.Interval = 15000;
            this.TimerLevel.Tick += new System.EventHandler(this.TimerLevel_Tick);
            // 
            // TimerLive
            // 
            this.TimerLive.Interval = 1;
            this.TimerLive.Tick += new System.EventHandler(this.TimerLive_Tick);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Moccasin;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(571, 390);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(227, 50);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rdbtnEasy
            // 
            this.rdbtnEasy.AutoSize = true;
            this.rdbtnEasy.Checked = true;
            this.rdbtnEasy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnEasy.Location = new System.Drawing.Point(458, 338);
            this.rdbtnEasy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnEasy.Name = "rdbtnEasy";
            this.rdbtnEasy.Size = new System.Drawing.Size(72, 28);
            this.rdbtnEasy.TabIndex = 23;
            this.rdbtnEasy.TabStop = true;
            this.rdbtnEasy.Text = "Easy";
            this.rdbtnEasy.UseVisualStyleBackColor = true;
            this.rdbtnEasy.CheckedChanged += new System.EventHandler(this.rdbtnEasy_CheckedChanged);
            // 
            // rdbtnMedium
            // 
            this.rdbtnMedium.AutoSize = true;
            this.rdbtnMedium.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnMedium.Location = new System.Drawing.Point(631, 338);
            this.rdbtnMedium.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnMedium.Name = "rdbtnMedium";
            this.rdbtnMedium.Size = new System.Drawing.Size(101, 28);
            this.rdbtnMedium.TabIndex = 24;
            this.rdbtnMedium.Text = "Medium";
            this.rdbtnMedium.UseVisualStyleBackColor = true;
            this.rdbtnMedium.CheckedChanged += new System.EventHandler(this.rdbtnMedium_CheckedChanged);
            // 
            // rdbtnHard
            // 
            this.rdbtnHard.AutoSize = true;
            this.rdbtnHard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnHard.Location = new System.Drawing.Point(837, 339);
            this.rdbtnHard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnHard.Name = "rdbtnHard";
            this.rdbtnHard.Size = new System.Drawing.Size(74, 28);
            this.rdbtnHard.TabIndex = 25;
            this.rdbtnHard.Text = "Hard";
            this.rdbtnHard.UseVisualStyleBackColor = true;
            this.rdbtnHard.CheckedChanged += new System.EventHandler(this.rdbtnHard_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1351, 751);
            this.Controls.Add(this.rdbtnHard);
            this.Controls.Add(this.rdbtnMedium);
            this.Controls.Add(this.rdbtnEasy);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.lblGameMenu);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(500, 200);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1369, 798);
            this.MinimumSize = new System.Drawing.Size(1369, 798);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point&Click Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimerKreis;
        private System.Windows.Forms.Label lblPointsCounter;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.Label lblLifeCounter;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeCounter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLevelCounter;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblHighScoreCounter;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Label lblFSPCounter;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Timer TimerTime;
        private System.Windows.Forms.Label lblGameMenu;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer TimerCreat;
        private System.Windows.Forms.Timer TimerLevel;
        private System.Windows.Forms.Timer TimerLive;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rdbtnEasy;
        private System.Windows.Forms.RadioButton rdbtnMedium;
        private System.Windows.Forms.RadioButton rdbtnHard;
    }
}

