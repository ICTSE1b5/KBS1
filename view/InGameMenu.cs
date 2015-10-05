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
    public partial class InGameMenu : UserControl
    {
        public event EventHandler InGameMenuScreenClick;

        public InGameMenu()
        {
            InitializeComponent();
        }

        private void Button_Main_Menu_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            InGameMenuScreenClick(sender, e);
        }

        public Button Get_Button_Main_Menu()
        {
            return button_Main_Menu;
        }
    }

}
