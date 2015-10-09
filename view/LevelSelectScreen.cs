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
        List<Button> listOfButtons = new List<Button>();
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

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
            //Fires event to the EventHandler and then sends it to Form1
            LevelSelectScreenClick(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LevelSelectScreenClick(sender, e);
        }

        private void Button_Main_Menu_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
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

      

        public void CreateDynamicButton()
        {
            string[] files = Directory.GetFiles(path + @"\levels\", "*.xml");
            
            int i = 0;
            
         

            for (int i2 = 0; i2 < files.Length; i2++)
            {
                if (i2 < 6)
                {
                    string path2 = files[i2];
                    String result = Path.GetFileNameWithoutExtension(path2);

                    i += 80;
                    Button btn = new Button();
                    btn.Location = new Point(100 + i, 200);
                    btn.Name = "btn1";
                    btn.Text = result;

                    btn.Click += new EventHandler(DynamicButton_Click);
                    this.Controls.Add(btn);
                    listOfButtons.Add(btn);
                }

                if (i2 >6)
                {
                    string path2 = files[i2];
                    String result = Path.GetFileNameWithoutExtension(path2);
                    i += 80;
                    Button btn = new Button();
                    btn.Location = new Point(100 + i, 300);
                    btn.Name = "btn1";
                    btn.Text = result;

                    btn.Click += new EventHandler(DynamicButton_Click);
                    this.Controls.Add(btn);
                    listOfButtons.Add(btn);
                }

            }


           
        }


        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case "level1":
                    System.Windows.Forms.MessageBox.Show("1");
                    break;
                case "Level2":
                    System.Windows.Forms.MessageBox.Show("2");
                    break;
                case "Level3":
                    System.Windows.Forms.MessageBox.Show("3");
                    break;
                case "Level4":
                    System.Windows.Forms.MessageBox.Show("4");
                    break;
                case "Level5":
                    System.Windows.Forms.MessageBox.Show("5");
                    break;
                case "Level6":
                    System.Windows.Forms.MessageBox.Show("6");
                    break;
                case "Level7":
                    System.Windows.Forms.MessageBox.Show("7");
                    break;
                case "Level8":
                    System.Windows.Forms.MessageBox.Show("8");
                    break;
                case "Level9":
                    System.Windows.Forms.MessageBox.Show("9");
                    break;
                case "Level10":
                    System.Windows.Forms.MessageBox.Show("10");
                    break;

            }




        }


    }
}


