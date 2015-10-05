using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace KBS1.view
{
    public partial class LevelSelectScreen : UserControl
    {
        public event EventHandler LevelSelectScreenClick;

        public LevelSelectScreen()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            LevelSelectScreenClick(sender, e);
        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            LevelSelectScreenClick(sender, e);
        }

        private void Button_Main_Menu_Click(object sender, EventArgs e)
        {
            LevelSelectScreenClick(sender, e);
        }

        public Button Get_Button_Main_Click()
        {
            return button_Main_Menu;
        }

        public Button Get_Button_Load()
        {
            return button_Load;
        }
        public Button Get_Button_Save()
        {
            return button_Save;
        }

    }
}
