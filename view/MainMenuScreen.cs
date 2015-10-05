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
    public partial class MainMenuScreen : UserControl
    {
        public event EventHandler MainMenuScreenClick;

        public MainMenuScreen()
        {
            InitializeComponent();
        }

        public void Button_Select_Level_Click(EventHandler handler)
        {
            this.button_Select_Level.Click += handler;
        }

        private void Button_Select_Level_Click(object sender, EventArgs e)
        {
            MainMenuScreenClick(sender, e);
        }

        public Button Get_Button_Select_Level()
        {
            return button_Select_Level;
        }
    }
}
