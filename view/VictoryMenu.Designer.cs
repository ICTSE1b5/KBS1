namespace KBS1.view
{
    partial class VictoryMenu
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
            this.button_RestartLevel = new System.Windows.Forms.Button();
            this.button_NextLevel = new System.Windows.Forms.Button();
            this.button_MainMenu = new System.Windows.Forms.Button();
            this.button_ExitGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_RestartLevel
            // 
            this.button_RestartLevel.Location = new System.Drawing.Point(113, 150);
            this.button_RestartLevel.Name = "button_RestartLevel";
            this.button_RestartLevel.Size = new System.Drawing.Size(84, 41);
            this.button_RestartLevel.TabIndex = 0;
            this.button_RestartLevel.Text = "Restart level";
            this.button_RestartLevel.UseVisualStyleBackColor = true;
            this.button_RestartLevel.Click += new System.EventHandler(this.button_RestartLevel_Click);
            // 
            // button_NextLevel
            // 
            this.button_NextLevel.Location = new System.Drawing.Point(228, 150);
            this.button_NextLevel.Name = "button_NextLevel";
            this.button_NextLevel.Size = new System.Drawing.Size(84, 41);
            this.button_NextLevel.TabIndex = 1;
            this.button_NextLevel.Text = "Next level";
            this.button_NextLevel.UseVisualStyleBackColor = true;
            this.button_NextLevel.Click += new System.EventHandler(this.button_NextLevel_Click);
            // 
            // button_MainMenu
            // 
            this.button_MainMenu.Location = new System.Drawing.Point(113, 197);
            this.button_MainMenu.Name = "button_MainMenu";
            this.button_MainMenu.Size = new System.Drawing.Size(84, 41);
            this.button_MainMenu.TabIndex = 2;
            this.button_MainMenu.Text = "Main menu";
            this.button_MainMenu.UseVisualStyleBackColor = true;
            this.button_MainMenu.Click += new System.EventHandler(this.button_MainMenu_Click);
            // 
            // button_ExitGame
            // 
            this.button_ExitGame.Location = new System.Drawing.Point(228, 197);
            this.button_ExitGame.Name = "button_ExitGame";
            this.button_ExitGame.Size = new System.Drawing.Size(84, 41);
            this.button_ExitGame.TabIndex = 3;
            this.button_ExitGame.Text = "Exit game";
            this.button_ExitGame.UseVisualStyleBackColor = true;
            this.button_ExitGame.Click += new System.EventHandler(this.button_ExitGame_Click);
            // 
            // VictoryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KBS1.Properties.Resources.victory;
            this.Controls.Add(this.button_ExitGame);
            this.Controls.Add(this.button_MainMenu);
            this.Controls.Add(this.button_NextLevel);
            this.Controls.Add(this.button_RestartLevel);
            this.Name = "VictoryMenu";
            this.Size = new System.Drawing.Size(450, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_RestartLevel;
        private System.Windows.Forms.Button button_NextLevel;
        private System.Windows.Forms.Button button_MainMenu;
        private System.Windows.Forms.Button button_ExitGame;
    }
}
