namespace KBS1.view
{
    partial class gameOver
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
            this.Restart = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.Button();
            this.selectLevel = new System.Windows.Forms.Button();
            this.CloseGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(106, 126);
            this.Restart.Name = "Restart";
            this.Restart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Restart.Size = new System.Drawing.Size(109, 51);
            this.Restart.TabIndex = 0;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenu.Location = new System.Drawing.Point(106, 183);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(109, 51);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "Main menu";
            this.MainMenu.UseVisualStyleBackColor = true;
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // selectLevel
            // 
            this.selectLevel.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectLevel.Location = new System.Drawing.Point(224, 126);
            this.selectLevel.Name = "selectLevel";
            this.selectLevel.Size = new System.Drawing.Size(109, 51);
            this.selectLevel.TabIndex = 2;
            this.selectLevel.Text = "Select level";
            this.selectLevel.UseVisualStyleBackColor = true;
            this.selectLevel.Click += new System.EventHandler(this.selectLevel_Click);
            // 
            // CloseGame
            // 
            this.CloseGame.Location = new System.Drawing.Point(224, 183);
            this.CloseGame.Name = "CloseGame";
            this.CloseGame.Size = new System.Drawing.Size(109, 51);
            this.CloseGame.TabIndex = 3;
            this.CloseGame.Text = "Close game";
            this.CloseGame.UseVisualStyleBackColor = true;
            this.CloseGame.Click += new System.EventHandler(this.CloseGame_Click);
            // 
            // gameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::KBS1.Properties.Resources.gameover;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.CloseGame);
            this.Controls.Add(this.selectLevel);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Restart);
            this.Name = "gameOver";
            this.Size = new System.Drawing.Size(450, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button MainMenu;
        private System.Windows.Forms.Button selectLevel;
        private System.Windows.Forms.Button CloseGame;
    }
}
