﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;

namespace KBS1.controller
{
    class GameLoop
    {
        //Important Properties
        public Form game_Form;
        public GameController game_Controller;
        private List<GameObject> game_objects = new List<GameObject>();
        
        public enum FrameRate : int
        {
            SIXTY = 16,
            THIRTY = 33
        }

        //Game Loop Update Properties
        private bool properties_Gameover = false;
        private int properties_CurrentTime = 0;
        private int properties_StartTime = 0;

        //Frame Rate Properties
        private int properties_FrameUpdates = 1000; // Set in milliseconds to wait before updating the frame rate
        private int properties_FrameTimer = 0;
        private int properties_FrameCount = 0;
        private int properties_FrameRate = 0;
        private int properties_UpdateRate = 16; //60 FPS is the default


        public GameLoop(Form form, FrameRate updateRate)
        {
            game_Form = form;
            game_Controller = new GameController(form, this);

            SetUpdateRate(updateRate);
        }

        //Starts the game loop
        public void Start()
        {
            Game_Init();

            while (!properties_Gameover)
            {
                //Gets the current 'time'
                properties_CurrentTime = Environment.TickCount;

                
                //Every frame it updates, use the function SetUpdateRate to set the updateRate to 60FPS or 30FPS
                if(properties_CurrentTime > properties_StartTime + properties_UpdateRate)
                {
                    //Reset the 'timer'
                    properties_StartTime = properties_CurrentTime;

                    //Makes the application availible to listen to events, like the KeyDown event or Button_Click
                    Application.DoEvents();

                    //Gives the command for the game to do its calculations
                    game_Controller.Update();

                    //Gives the command for the view to repaint the objects
                    /*--> Might couse slowness if used to often, because it needs to redraw the whole screen, */
                    /*--> Maybe needed to make a special view that only redraws the 4 surrounding backgrounds under the object and the object itself??*/
                    game_Form.Invalidate();

                }


                //Frame Rate Update
                properties_FrameCount++;
                if(properties_CurrentTime > properties_FrameTimer + properties_FrameUpdates)
                {
                    properties_FrameTimer = properties_CurrentTime;
                    properties_FrameRate = properties_FrameCount;
                    properties_FrameCount = 0;
                }

            }


        }



        public void Game_Init()
        {
            //Initialize all components (ie. Player, Wall, Enemy,  etc.)

            //Is replaced with information from the XML-file to make the enemies (loop)
            /*Right now this is a hardcoded placement*/
            Player player1 = new Player(0, 0);
            game_objects.Add(player1);
            Enemy_Static enemy1 = new Enemy_Static(100, 100);
            game_objects.Add(enemy1);
            Enemy_Static enemy2 = new Enemy_Static(200, 100);
            game_objects.Add(enemy2);
        }

        private void Game_End()
        {
            //Remove all existing components (ie. Objects, GameController, etc.)
        }

        public void Shutdown()
        {
            properties_Gameover = true;
        }

        public void SetUpdateRate(FrameRate update)
        {
            properties_UpdateRate = (int)update;
        }


        public List<GameObject> GameEntities
        {
            get { return game_objects; }
        }
    }
}