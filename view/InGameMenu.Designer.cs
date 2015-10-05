namespace KBS1.view
{
    partial class InGameMenu
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
            this.button_Main_Menu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Main_Menu
            // 
            this.button_Main_Menu.BackColor = System.Drawing.SystemColors.Control;
            this.button_Main_Menu.Location = new System.Drawing.Point(40, 40);
            this.button_Main_Menu.Name = "button_Main_Menu";
            this.button_Main_Menu.Size = new System.Drawing.Size(115, 39);
            this.button_Main_Menu.TabIndex = 0;
            this.button_Main_Menu.Text = "Main menu";
            this.button_Main_Menu.UseVisualStyleBackColor = false;
            this.button_Main_Menu.Click += new System.EventHandler(this.Button_Main_Menu_Click);
            // 
            // InGameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.button_Main_Menu);
            this.Name = "InGameMenu";
            this.Size = new System.Drawing.Size(199, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Main_Menu;
    }
}
