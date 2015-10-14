using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;

namespace KBS1.view
{
    public partial class HighScoresScreen : UserControl
    {
        public HighScoresScreen()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)this.listBoxLevel.SelectedItem == "level 1")
            {
                MessageBox.Show("Het werkt");
            }
        }

        public void AddItemsToListBox()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            // get file directory from levels
            string[] files = Directory.GetFiles(path + @"\levels\", "*.xml");
            
            // sort the levels ascending
            Array.Sort(files, (a, b) => int.Parse(Regex.Replace(a, "[^0-9]", "")) - int.Parse(Regex.Replace(b, "[^0-9]", "")));

            foreach (var filename in files)
            {
                listBoxLevel.Items.Add(Path.GetFileNameWithoutExtension(filename));
            }
        }
    }
}
