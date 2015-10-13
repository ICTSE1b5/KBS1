﻿namespace KBS1
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
            this.gameoverMenu = new KBS1.view.gameOver();
            this.statisticsScreen1 = new KBS1.view.StatisticsScreen();
            this.mainMenuScreen = new KBS1.view.MainMenuScreen();
            this.levelSelectScreen = new KBS1.view.LevelSelectScreen();
            this.inGameMenu = new KBS1.view.InGameMenu();
            this.optionsMenu = new KBS1.view.OptionsMenu();
            this.SuspendLayout();
            // 
            // gameoverMenu
            // 
            this.gameoverMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gameoverMenu.Location = new System.Drawing.Point(291, 211);
            this.gameoverMenu.Name = "gameoverMenu";
            this.gameoverMenu.Size = new System.Drawing.Size(450, 250);
            this.gameoverMenu.TabIndex = 5;
            this.gameoverMenu.Visible = false;
            // 
            // statisticsScreen1
            // 
            this.statisticsScreen1.AutoScroll = true;
            this.statisticsScreen1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statisticsScreen1.Enabled = false;
            this.statisticsScreen1.Location = new System.Drawing.Point(1045, 0);
            this.statisticsScreen1.Margin = new System.Windows.Forms.Padding(5);
            this.statisticsScreen1.Name = "statisticsScreen1";
            this.statisticsScreen1.Size = new System.Drawing.Size(320, 690);
            this.statisticsScreen1.TabIndex = 4;
            this.statisticsScreen1.Visible = false;
            // 
            // mainMenuScreen
            // 
            this.mainMenuScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenuScreen.BackgroundImage")));
            this.mainMenuScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuScreen.Location = new System.Drawing.Point(0, 0);
            this.mainMenuScreen.Margin = new System.Windows.Forms.Padding(5);
            this.mainMenuScreen.Name = "mainMenuScreen";
            this.mainMenuScreen.Size = new System.Drawing.Size(1045, 690);
            this.mainMenuScreen.TabIndex = 0;
            // 
            // levelSelectScreen
            // 
            this.levelSelectScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("levelSelectScreen.BackgroundImage")));
            this.levelSelectScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSelectScreen.Location = new System.Drawing.Point(0, 0);
            this.levelSelectScreen.Margin = new System.Windows.Forms.Padding(5);
            this.levelSelectScreen.Name = "levelSelectScreen";
            this.levelSelectScreen.Size = new System.Drawing.Size(1045, 690);
            this.levelSelectScreen.TabIndex = 1;
            this.levelSelectScreen.Visible = false;
            // 
            // inGameMenu
            // 
            this.inGameMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.inGameMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inGameMenu.Location = new System.Drawing.Point(385, 177);
            this.inGameMenu.Margin = new System.Windows.Forms.Padding(5);
            this.inGameMenu.Name = "inGameMenu";
            this.inGameMenu.Size = new System.Drawing.Size(265, 307);
            this.inGameMenu.TabIndex = 2;
            this.inGameMenu.Visible = false;
            // 
            // optionsMenu
            // 
            this.optionsMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.optionsMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsMenu.Location = new System.Drawing.Point(260, 177);
            this.optionsMenu.Margin = new System.Windows.Forms.Padding(5);
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(586, 284);
            this.optionsMenu.TabIndex = 3;
            this.optionsMenu.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KBS1.Properties.Resources.Gamebackground;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.gameoverMenu);
            this.Controls.Add(this.statisticsScreen1);
            this.Controls.Add(this.mainMenuScreen);
            this.Controls.Add(this.levelSelectScreen);
            this.Controls.Add(this.inGameMenu);
            this.Controls.Add(this.optionsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private view.MainMenuScreen mainMenuScreen;
        private view.LevelSelectScreen levelSelectScreen;
        private view.InGameMenu inGameMenu;
        private view.OptionsMenu optionsMenu;
        private view.StatisticsScreen statisticsScreen1;
        private view.gameOver gameoverMenu;
    }
}

