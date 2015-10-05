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
            //Event handler for buttons that have been pressed
            mainMenuScreen.MainMenuScreenClick += new EventHandler(UserControl_ButtonClick);
            levelSelectScreen.LevelSelectScreenClick += new EventHandler(UserControl_ButtonClick);
            inGameMenu.InGameMenuScreenClick += new EventHandler(UserControl_ButtonClick);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch the direction of the player
            //switch statement
            game_loop.player1.changeDirections(e.KeyCode, true);
            if (e.KeyCode == Keys.Escape)
            {
                if (game_loop.Get_Properties_Pause())
                {
                    game_loop.Set_Properties_Pause(false);
                    inGameMenu.Visible = false;
                    inGameMenu.Enabled = false;
                }
                else
                {
                    game_loop.Set_Properties_Pause(true);
                    inGameMenu.Visible = true;
                    inGameMenu.Enabled = true;
                }
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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics_GraphicDevice = e.Graphics;

            game_view.DrawGame(e.Graphics);
        }

        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //Check what button is pressed.
            if (sender == mainMenuScreen.Get_Button_Select_Level())
            {
                this.mainMenuScreen.Visible = false;
                this.mainMenuScreen.Enabled = false;
                this.levelSelectScreen.Visible = true;
                this.levelSelectScreen.Visible = true;

            }
            else if (sender == mainMenuScreen.Get_Button_New_Game())
            {
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                game_loop.Start();

            }
            else if (sender == levelSelectScreen.Get_Button_Main_Click())
            {
                this.levelSelectScreen.Visible = false;
                this.levelSelectScreen.Enabled = false;
                this.mainMenuScreen.Visible = true;
                this.mainMenuScreen.Enabled = true;
            }
            else if (sender == levelSelectScreen.Get_Button_Load())
            {
                game_levels.LoadLevel("level1");
            }
            else if (sender == levelSelectScreen.Get_Button_Save())
            {
                game_levels.SaveLevel("level1");
            }
            else if (sender == inGameMenu.Get_Button_Main_Menu())
            {
                game_loop.Shutdown();
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
            }
            else if (sender == inGameMenu.Get_Button_Resume())
            {
                game_loop.Set_Properties_Pause(false);
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
            }
            else if (sender == inGameMenu.Get_Button_Close() || sender == mainMenuScreen.Get_Button_Close())
            {
                game_loop.Shutdown();
                Application.Exit();
                //The application doesn't close properly with only Application.Exit()
                Environment.Exit(1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game_loop.Shutdown();
            Application.Exit();
        }
    }
}
