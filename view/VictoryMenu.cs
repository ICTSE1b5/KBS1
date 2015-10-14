﻿using System;
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
    public partial class VictoryMenu : UserControl
    {
        public event EventHandler VictoryMenuClick;
        public VictoryMenu()
        {
            InitializeComponent();
        }

        private void button_RestartLevel_Click(object sender, EventArgs e)
        {
            VictoryMenuClick(sender, e);
        }

        private void button_NextLevel_Click(object sender, EventArgs e)
        {
            VictoryMenuClick(sender, e);
        }

        private void button_MainMenu_Click(object sender, EventArgs e)
        {
            VictoryMenuClick(sender, e);
        }

        private void button_ExitGame_Click(object sender, EventArgs e)
        {
            VictoryMenuClick(sender, e);
        }

        public Button Get_Button_Restart_Level()
        {
            return button_RestartLevel;
        }

        public Button Get_Button_Next_Level()
        {
            return button_NextLevel;
        }

        public Button Get_Button_Main_Menu()
        {
            return button_MainMenu;
        }

        public Button Get_Button_Exit_Game()
        {
            return button_ExitGame;
        }
    }
}