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
        private bool mainOptions;


        public Form1()
        {
            InitializeComponent();

            player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.MainMenuMusic;

            //Event handler for buttons that have been pressed
            mainMenuScreen.MainMenuScreenClick += new EventHandler(MainMenu_ButtonHandler);
            levelSelectScreen.LevelSelectScreenClick += new EventHandler(LevelSelect_ButtonHandler);
            inGameMenu.InGameMenuScreenClick += new EventHandler(InGameMenu_ButtonHandler);
            optionsMenu.OptionsMenuClick += new EventHandler(OptionMenu_ButtonHandler);
            gameoverMenu.GameOverScreenClick += new EventHandler(GameOver_ButtonHandler);
            levelSelectScreen.AddForm(this);
            

            this.SetStyle(
          ControlStyles.UserPaint |
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.OptimizedDoubleBuffer, true);
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch the direction of the player
            //switch statement
            try
            {
                game_loop.parser.player1.changeDirections(e.KeyCode, true);
                if (e.KeyCode == Keys.Escape)
                {
                    //if options menu is opened while in-game it will close by pressing escape
                    if (optionsMenu.Visible == true)
                    {
                        optionsMenu.Visible = false;
                        optionsMenu.Enabled = false;
                        inGameMenu.Visible = true;
                        inGameMenu.Enabled = true;
                    }
                    //pressing escape will close the in-game menu if it is already open
                    else if (game_loop.Get_Properties_Pause())
                    {
                        game_loop.Set_Properties_Pause(false);
                        inGameMenu.Visible = false;
                        inGameMenu.Enabled = false;
                    }
                    //pressing escape will open the in-game menu if it is not already open
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
                game_loop.parser.player1.changeDirections(e.KeyCode, false);
            }
            catch (NullReferenceException d)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game_loop = new GameLoop(this, GameLoop.FrameRate.SIXTY, statisticsScreen1);
            game_view = new GameView(this, game_loop);
            game_levels = new GameLevels(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics_GraphicDevice = e.Graphics;
            game_view.DrawGame(e.Graphics);
        }

        public void MainMenu_ButtonHandler(object sender, EventArgs e)
        {
            //Check what button is pressed.
            if (sender == mainMenuScreen.Get_Button_Select_Level())
            {
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                levelSelectScreen.Visible = true;
                levelSelectScreen.Enabled = true;
                levelSelectScreen.CreateDynamicButton();
            }
            else if (sender == mainMenuScreen.Get_Button_New_Game())
            {
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                StartGame("level1");
            }
            else if (sender == mainMenuScreen.Get_Button_Options())
            {
                optionsMenu.Visible = true;
                optionsMenu.Enabled = true;
                optionsMenu.BringToFront();
                mainOptions = true;
            }
            else if (sender == mainMenuScreen.Get_Button_Close())
            {
                CloseGame();
            }
        }

        // the button handler for the level select screen
        public void LevelSelect_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == levelSelectScreen.Get_Button_Main_Click())
            {
                levelSelectScreen.Visible = false;
                levelSelectScreen.Enabled = false;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
            }
        }


        // the button handler for the game over screen
        public void GameOver_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == gameoverMenu.Get_Button_selectLevel())
            {
                gameoverMenu.Visible = false;
                gameoverMenu.Enabled = false;
                levelSelectScreen.Visible = true;
                levelSelectScreen.Enabled = true;
                levelSelectScreen.CreateDynamicButton();
            }
            else if (sender == gameoverMenu.Get_Button_MainMenu())
            {
                game_loop.Shutdown();
                
                gameoverMenu.Visible = false;
                gameoverMenu.Enabled = false;
                statisticsScreen1.Visible = false;
                Width = 800;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;

            }
            else if (sender == gameoverMenu.Get_Button_CloseGame())
            {
                CloseGame();
            }
            else if (sender == gameoverMenu.Get_Button_Restart())
            {
                game_loop.Shutdown();
                gameoverMenu.Visible = false;
                gameoverMenu.Enabled = false;
                StartGame("level1");
            }
        }

        //method to show the gameOverMenu
        public void showGameOver()
        {
            game_loop.Set_Properties_Pause(true);
            gameoverMenu.Visible = true;
            gameoverMenu.Enabled = true;
        }


        //The button handler for the in game menu
        public void InGameMenu_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == inGameMenu.Get_Button_Main_Menu())
            {
                game_loop.Shutdown();
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
                statisticsScreen1.Visible = false;
                Width = 800;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
                
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
                mainOptions = false;
            }
            else if (sender == inGameMenu.Get_Button_Close())
            {
                CloseGame();
            }
        }

        //The button handler for the options menu
        public void OptionMenu_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == optionsMenu.Get_CheckBox_Music())
            {
                playMusic();
            }
            else if (sender == optionsMenu.Get_Button_Return())
            {
                if (!mainOptions)
                {
                    inGameMenu.Visible = true;
                    inGameMenu.Enabled = true;
                }
                optionsMenu.Visible = false;
                optionsMenu.Enabled = false;
            }
            else if (sender == optionsMenu.Get_CheckBox_Statistics())
            {
                if (optionsMenu.Get_CheckBox_Statistics().Checked)
                {
                    if (!mainOptions)
                    {
                        statisticsScreen1.Visible = true;
                        statisticsScreen1.Enabled = true;
                        Width = 1040;
                        statisticsScreen1.DrawPanel(game_loop.GameEntities);
                        optionsMenu.Enabled = false;
                        optionsMenu.Enabled = true;
                    }
                }
                else
                {
                    statisticsScreen1.Visible = false;
                    Width = 800;
                    optionsMenu.Enabled = false;
                    optionsMenu.Enabled = true;
                }
            }
        }

        private void playMusic()
        {
            if (optionsMenu.Get_CheckBox_Music().Checked)
            {
                player.Play();
                player.PlayLooping();
                optionsMenu.Enabled = false;
                optionsMenu.Enabled = true;
            }
            else
            {
                player.Stop();
                optionsMenu.Enabled = false;
                optionsMenu.Enabled = true;
            }
        }

        public void StartGame(string level)
        {
            game_loop = new GameLoop(this, GameLoop.FrameRate.SIXTY, statisticsScreen1);
            game_view = new GameView(this, game_loop);
            game_levels = new GameLevels(this);

            if (optionsMenu.Get_CheckBox_Statistics().Checked)
            {
                statisticsScreen1.Visible = true;
                statisticsScreen1.Enabled = true;
                Width = 1040;
                //statisticsScreen1.DrawPanel(game_loop.GameEntities);
            }

            game_loop.Start(level);

        }

        private void CloseGame()
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseGame();
        }
    }
}
