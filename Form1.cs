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
using System.Media;

namespace KBS1
{
    public partial class Form1 : Form
    {
        private GameLoop game_loop;
        private GameView game_view;
        private GameLevels game_levels;
        private SoundPlayer player;


        public Form1()
        {
            InitializeComponent();

            player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.MainMenuMusic;

            //Event handler for buttons that have been pressed
            mainMenuScreen.MainMenuScreenClick += new EventHandler(UserControl_ButtonClick);
            levelSelectScreen.LevelSelectScreenClick += new EventHandler(UserControl_ButtonClick);
            inGameMenu.InGameMenuScreenClick += new EventHandler(UserControl_ButtonClick);
            optionsMenu.OptionsMenuClick += new EventHandler(UserControl_ButtonClick);

            this.SetStyle(
          ControlStyles.UserPaint |
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch the direction of the player
            //switch statement
            try
            {
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
            catch (NullReferenceException d)
            {
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //switch statement if key is released
            try
            {
                game_loop.player1.changeDirections(e.KeyCode, false);
            }
            catch (NullReferenceException d)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                this.levelSelectScreen.Enabled = true;

            }
            else if (sender == mainMenuScreen.Get_Button_New_Game())
            {
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                game_loop = new GameLoop(this, GameLoop.FrameRate.SIXTY);
                game_view = new GameView(this, game_loop);
                game_levels = new GameLevels(this);
                game_loop.Start();
            }
            else if (sender == mainMenuScreen.Get_CheckBox1())
            {
                if (mainMenuScreen.Get_CheckBox1().Checked)
                {
                    optionsMenu.Set_CheckBox_Music(true);
                } else
                {
                    optionsMenu.Set_CheckBox_Music(false);
                }
                playMusic();
            }
            else if(sender == optionsMenu.Get_CheckBox_Music())
            {
                if (optionsMenu.Get_CheckBox_Music().Checked)
                {
                    mainMenuScreen.Set_CheckBox1(true);
                }
                else
                {
                    mainMenuScreen.Set_CheckBox1(false);
                }
                playMusic();
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
            else if (sender == levelSelectScreen.Get_Button_Show())
            {
                game_levels.ShowLevels();
            }
            else if (sender == inGameMenu.Get_Button_Main_Menu())
            {
                game_loop.Shutdown();
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
                game_loop = null;
            }
            else if (sender == inGameMenu.Get_Button_Resume())
            {
                game_loop.Set_Properties_Pause(false);
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
            }
            else if (sender == inGameMenu.Get_Button_Options())
            {
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
                optionsMenu.Visible = true;
                optionsMenu.Enabled = true;
            }
            else if (sender == optionsMenu.Get_Button_Return())
            {
                inGameMenu.Visible = true;
                inGameMenu.Enabled = true;
                optionsMenu.Visible = false;
                optionsMenu.Enabled = false;
            }
            else if (sender == inGameMenu.Get_Button_Close() || sender == mainMenuScreen.Get_Button_Close())
            {
                try
                {
                    game_loop.Shutdown();
                }
                catch (NullReferenceException d)
                {

                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private void playMusic()
        {
            if (mainMenuScreen.Get_CheckBox1().Checked || optionsMenu.Get_CheckBox_Music().Checked)
            {
                player.Play();
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                game_loop.Shutdown();
            }
            catch (NullReferenceException d)
            {

            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
