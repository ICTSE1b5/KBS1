namespace KBS1.view
{
    partial class MainMenuScreen
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
            this.button_New_Game = new System.Windows.Forms.Button();
            this.button_Select_Level = new System.Windows.Forms.Button();
            this.button_Level_Editor = new System.Windows.Forms.Button();
            this.button_Highscores = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_New_Game
            // 
            this.button_New_Game.Location = new System.Drawing.Point(45, 394);
            this.button_New_Game.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_New_Game.Name = "button_New_Game";
            this.button_New_Game.Size = new System.Drawing.Size(153, 48);
            this.button_New_Game.TabIndex = 0;
            this.button_New_Game.Text = "New game";
            this.button_New_Game.UseVisualStyleBackColor = true;
            this.button_New_Game.Click += new System.EventHandler(this.button_New_Game_Click);
            // 
            // button_Select_Level
            // 
            this.button_Select_Level.Location = new System.Drawing.Point(45, 449);
            this.button_Select_Level.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Select_Level.Name = "button_Select_Level";
            this.button_Select_Level.Size = new System.Drawing.Size(153, 48);
            this.button_Select_Level.TabIndex = 1;
            this.button_Select_Level.Text = "Select level";
            this.button_Select_Level.UseVisualStyleBackColor = true;
            this.button_Select_Level.Click += new System.EventHandler(this.Button_Select_Level_Click);
            // 
            // button_Level_Editor
            // 
            this.button_Level_Editor.Location = new System.Drawing.Point(45, 505);
            this.button_Level_Editor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Level_Editor.Name = "button_Level_Editor";
            this.button_Level_Editor.Size = new System.Drawing.Size(153, 48);
            this.button_Level_Editor.TabIndex = 2;
            this.button_Level_Editor.Text = "Level editor";
            this.button_Level_Editor.UseVisualStyleBackColor = true;
            // 
            // button_Highscores
            // 
            this.button_Highscores.Location = new System.Drawing.Point(45, 560);
            this.button_Highscores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Highscores.Name = "button_Highscores";
            this.button_Highscores.Size = new System.Drawing.Size(153, 48);
            this.button_Highscores.TabIndex = 3;
            this.button_Highscores.Text = "Highscores";
            this.button_Highscores.UseVisualStyleBackColor = true;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(45, 615);
            this.button_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(153, 48);
            this.button_Close.TabIndex = 4;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KBS1.Properties.Resources.background;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Highscores);
            this.Controls.Add(this.button_Level_Editor);
            this.Controls.Add(this.button_Select_Level);
            this.Controls.Add(this.button_New_Game);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenuScreen";
            this.Size = new System.Drawing.Size(1067, 689);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_New_Game;
        private System.Windows.Forms.Button button_Select_Level;
        private System.Windows.Forms.Button button_Level_Editor;
        private System.Windows.Forms.Button button_Highscores;
        private System.Windows.Forms.Button button_Close;
    }
}
