﻿using System;
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
using KBS1.controller;
using System.Text.RegularExpressions;

namespace KBS1.view
{
    public partial class LevelSelectScreen : UserControl
    {
        public List<Button> listOfButtons = new List<Button>();
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      
        public event EventHandler LevelSelectScreenClick;
        public Form1 form;

        public LevelSelectScreen()
        {
            InitializeComponent();
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
            Array.Sort(files, (a, b) => int.Parse(Regex.Replace(a, "[^0-9]", "")) - int.Parse(Regex.Replace(b, "[^0-9]", "")));


            int i = 0;
            int i3 = 0;
            int i4 = 0;


            for (int i2 = 0; i2 < files.Length; i2++)
            {
                string path2 = files[i2];
                String result = Path.GetFileNameWithoutExtension(path2);
                Button btn = new Button();
                btn.Name = "btn1";
                btn.Text = result;

                btn.Click += new EventHandler(DynamicButton_Click);
                this.Controls.Add(btn);
                listOfButtons.Add(btn);
                if (i2 <= 4)
                {
                    i += 80;
                    
                    btn.Location = new Point(100 + i, 200);
                    
                }

                if (i2 >4 && i2 <= 9)
                {
                     i3 += 80;
                   
                    btn.Location = new Point(100 + i3, 300);
                   
                }
                if (i2 > 9)
                {
                    i4 += 80;

                    btn.Location = new Point(100 + i4, 400);

                }

            }


           
        }


        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            string XMLfile = path + @"\levels\" + button.Text + "*.xml";

            this.Visible = false;
            this.Enabled = false;
            form.StartGame(button.Text);
        }

        public void AddForm(Form1 form)
        {
            this.form = form;
        }


    }
}


