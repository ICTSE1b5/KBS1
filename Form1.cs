using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KBS1.controller;
using KBS1.model;
using KBS1.view;

namespace KBS1
{
    public partial class Form1 : Form
    {
        private GameLoop game_loop;
        private GameView game_view;
        private GameLevels game_levels;


        public Form1()
        {
            InitializeComponent();
            this.mainMenuScreen.Button_Select_Level_Click(new EventHandler(UserControl_ButtonClick));

            mainMenuScreen.MainMenuScreenClick += new EventHandler(UserControl_ButtonClick);
            levelSelectScreen.LevelSelectScreenClick += new EventHandler(UserControl_ButtonClick);

            this.levelSelectScreen.Button_Main_Menu_Click(new       EventHandler(UserControl_ButtonClick));

            mainMenuScreen.Visible = false;
            mainMenuScreen.Enabled = false;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch the direction of the player
            //switch statement
            game_loop.player1.changeDirections(e.KeyCode, true);
            if (e.KeyCode == Keys.Escape)
            {
                game_loop.Shutdown();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //switch statement if key is released
            game_loop.player1.changeDirections(e.KeyCode, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Remove this when the main menu has been added.
            this.Show();
            this.Focus();
            game_loop = new GameLoop(this, GameLoop.FrameRate.SIXTY);
            game_view = new GameView(this, game_loop);
            game_levels = new GameLevels(this);
            game_loop.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics_GraphicDevice = e.Graphics;

            game_view.DrawGame(e.Graphics);
        }

        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event
            if (sender == mainMenuScreen.Get_Button_Select_Level())
            {
                this.mainMenuScreen.Visible = false;
                this.levelSelectScreen.Visible = true;
            }
            else if (sender == levelSelectScreen.Get_Button_Main_Click())
            {
                this.levelSelectScreen.Visible = false;
                this.mainMenuScreen.Visible = true;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game_loop.Shutdown();
            Application.Exit();
        }
    }
}
