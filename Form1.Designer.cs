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
            this.mainMenuScreen = new KBS1.view.MainMenuScreen();
            this.levelSelectScreen = new KBS1.view.LevelSelectScreen();
            this.inGameMenu = new KBS1.view.InGameMenu();
            this.SuspendLayout();
            // 
            // mainMenuScreen
            // 
            this.mainMenuScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenuScreen.BackgroundImage")));
            this.mainMenuScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuScreen.Location = new System.Drawing.Point(0, 0);
            this.mainMenuScreen.Name = "mainMenuScreen";
            this.mainMenuScreen.Size = new System.Drawing.Size(784, 561);
            this.mainMenuScreen.TabIndex = 0;
            // 
            // levelSelectScreen
            // 
            this.levelSelectScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSelectScreen.Location = new System.Drawing.Point(0, 0);
            this.levelSelectScreen.Name = "levelSelectScreen";
            this.levelSelectScreen.Size = new System.Drawing.Size(784, 561);
            this.levelSelectScreen.TabIndex = 1;
            this.levelSelectScreen.Visible = false;
            // 
            // inGameMenu
            // 
            this.inGameMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.inGameMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inGameMenu.Location = new System.Drawing.Point(289, 144);
            this.inGameMenu.Name = "inGameMenu";
            this.inGameMenu.Size = new System.Drawing.Size(199, 250);
            this.inGameMenu.TabIndex = 2;
            this.inGameMenu.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mainMenuScreen);
            this.Controls.Add(this.levelSelectScreen);
            this.Controls.Add(this.inGameMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
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
    }
}

