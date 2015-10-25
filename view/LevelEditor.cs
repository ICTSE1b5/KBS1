using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.controller;

namespace KBS1.view {
    public partial class LevelEditor : UserControl {

        public event EventHandler LevelEditorButtonClick;

        private Dictionary<string, Image> items;
        private Dictionary<string, Dictionary<string, int>> addedObjects;

        public LevelEditor() {
            InitializeComponent();
        }

        public void Init( Dictionary<string, Image> d ) {
            this.items = d;
            this.CreateList();
            this.addedObjects = new Dictionary<string, Dictionary<string, int>>();
            this.MouseClick += this.MouseClicked;

            // Overwrite ListView properties
            listView1.VirtualListSize = items.Count;
            listView1.Size = new Size(240, this.ClientSize.Height);
            listView1.Location = new Point(this.ClientSize.Width - this.listView1.Width, 0);

            // Overwrite ImageList image size
            this.imageList1.ImageSize = new Size(50, 50);

            // Set background image for form
            this.BackgroundImage = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            // Overwrite button properties
            int btnX = this.ClientSize.Width - this.button1.Width - 40;
            int btnY = this.ClientSize.Height - 50;
            this.button1.Text = "Save";
            this.button2.Text = "Cancel";
            this.button1.Location = new Point(btnX, btnY);
            this.button2.Location = new Point(btnX - 100, btnY);
        }

        public void Destruct() {
            this.listView1.Items.Clear();
            this.items = null;
            this.addedObjects = null;
            this.Visible = false;
            this.Enabled = false;
        }


        public Button Get_Button_Cancel() {
            return this.button2;
        }

        public Button Get_Button_Save() {
            return this.button1;
        }

        public Dictionary<string, Dictionary<string, int>> GetAddedObjects() {
            return this.addedObjects;
        }

        private void CreateList() {
            foreach( KeyValuePair<string, Image> item in this.items ) {
                this.imageList1.Images.Add(item.Key, item.Value);
                ListViewItem temp = listView1.Items.Add(item.Key);
                temp.ImageKey = item.Key;
            }
            listView1.LargeImageList = imageList1;
        }

        private void MouseClicked( object sender, MouseEventArgs e ) {
            if( listView1.SelectedItems.Count > 0 ) {
                string selectedItemName = listView1.SelectedItems[ 0 ].Text.ToLower();
                Image i = this.items[ selectedItemName ];
                Bitmap b = ( Bitmap ) this.BackgroundImage;
                using( Graphics g = Graphics.FromImage(b) ) {
                    g.DrawImage(i, e.X, e.Y, 50, 50);

                    this.Invalidate();
                }
                using( Dialog d = new Dialog() ) {
                    if (selectedItemName == "enemy") {
                        DialogResult result = d.ShowDialog(this);
                        if (result == DialogResult.OK) {
                            this.AddObjectToMap(selectedItemName, e.X, e.Y, d.GetValue());
                        }
                    }
                    else {
                        if( selectedItemName == "player" && !this.addedObjects.ContainsKey("player") )
                            this.AddObjectToMap(selectedItemName, e.X, e.Y, 5);
                        else if( selectedItemName == "finish" && !this.addedObjects.ContainsKey("finish") )
                            this.AddObjectToMap(selectedItemName, e.X, e.Y, 0);
                        else
                            this.AddObjectToMap(selectedItemName, e.X, e.Y, 0);
                    }
                }
            }
        }

        private void AddObjectToMap( string name, int x, int y, int speed ) {
            Dictionary<string, int> temp = new Dictionary<string, int>();
            temp[ "x" ] = x;
            temp[ "y" ] = y;
            temp[ "speed" ] = speed;
            this.addedObjects[ name ] = temp;
        }
        
        private void Save_Click(object sender, EventArgs e) {
            this.LevelEditorButtonClick(sender, e);
        }

        private void Cancel_Click(object sender, EventArgs e) {
            this.LevelEditorButtonClick(sender, e);
        }

    }
}
