using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KBS1.view
{
    public partial class HighScoresScreen : UserControl
    {
        private string[] files;
        public HighScoresScreen()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHighscore(listBoxLevel.SelectedItem.ToString());
        }

        public void AddItemsToListBox()
        {
            try
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                // get file directory from levels
                files = Directory.GetFiles(path + @"\levels\", "*.xml");
            
                // sort the levels ascending
                Array.Sort(files, (a, b) => int.Parse(Regex.Replace(a, "[^0-9]", "")) - int.Parse(Regex.Replace(b, "[^0-9]", "")));

                foreach (var filename in files)
                {
                    listBoxLevel.Items.Add(Path.GetFileNameWithoutExtension(filename));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong: " + e);
            }
        }


        public void LoadHighscore(string level)
        {
            MessageBox.Show(level);
        }

    }
}
