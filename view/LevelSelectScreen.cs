using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.view
{
    public partial class LevelSelectScreen : UserControl
    {
        public LevelSelectScreen()
        {
            InitializeComponent();
        }

        public void Button_Main_Menu_Click(EventHandler handler)
        {
            this.button_Main_Menu.Click += handler;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void button_Load_Click(object sender, EventArgs e)
        {

        }
    }
}
