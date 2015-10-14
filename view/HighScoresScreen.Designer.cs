namespace KBS1.view
{
    partial class HighScoresScreen
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
            this.listBoxLevel = new System.Windows.Forms.ListBox();
            this.panelHighscores = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listBoxLevel
            // 
            this.listBoxLevel.FormattingEnabled = true;
            this.listBoxLevel.Location = new System.Drawing.Point(0, 0);
            this.listBoxLevel.Name = "listBoxLevel";
            this.listBoxLevel.Size = new System.Drawing.Size(624, 251);
            this.listBoxLevel.TabIndex = 0;
            this.listBoxLevel.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panelHighscores
            // 
            this.panelHighscores.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHighscores.Location = new System.Drawing.Point(92, 0);
            this.panelHighscores.Name = "panelHighscores";
            this.panelHighscores.Size = new System.Drawing.Size(160, 250);
            this.panelHighscores.TabIndex = 1;
            // 
            // HighScoresScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelHighscores);
            this.Controls.Add(this.listBoxLevel);
            this.Name = "HighScoresScreen";
            this.Size = new System.Drawing.Size(255, 253);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLevel;
        private System.Windows.Forms.Panel panelHighscores;
    }
}
