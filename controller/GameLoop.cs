using System;
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
        public Player player1;

        public enum FrameRate : int
        {
            SIXTY = 16,
            THIRTY = 33
        }

        //Game Loop Update Properties
        private bool properties_Gameover = false;
        private bool properties_Pause = false;
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
                if (properties_CurrentTime > properties_StartTime + properties_UpdateRate)
                {
                    //Reset the 'timer'
                    properties_StartTime = properties_CurrentTime;

                    //Makes the application availible to listen to events, like the KeyDown event or Button_Click
                    Application.DoEvents();

                    while (properties_Pause)
                    {
                        Application.DoEvents();
                    }
                    //Gives the command for the game to do its calculations
                    game_Controller.Update();

                    //Gives the command for the view to repaint the objects
                    /*--> Might couse slowness if used to often, because it needs to redraw the whole screen, */
                    /*--> Maybe needed to make a special view that only redraws the 4 surrounding backgrounds under the object and the object itself??*/
                    game_Form.Invalidate();

                }

                //Frame Rate Update
                properties_FrameCount++;
                if (properties_CurrentTime > properties_FrameTimer + properties_FrameUpdates)
                {
                    properties_FrameTimer = properties_CurrentTime;
                    properties_FrameRate = properties_FrameCount;
                    properties_FrameCount = 0;
                }
            }

            Game_End();
        }

        public void Game_Init()
        {
            //Initialize all components (ie. Player, Wall, Enemy,  etc.)
            properties_Gameover = false;
            properties_Pause = false;
            //Is replaced with information from the XML-file to make the enemies (loop)
            /*Right now this is a hardcoded placement*/

            game_objects = new List<GameObject>();
            // makes an XMLparser
            XmlParser parser = new XmlParser();
            parser.Parse("level_test");
            //Adds the player to the List
            player1 = new Player(0, 0, game_Form);
            game_objects.Add(player1);

            Finish finish = new Finish(720,500,50,50, game_Form);
            game_objects.Add(finish);
            Enemy_Following enemy3 = new Enemy_Following(500, 500, game_objects, game_Form);
            game_objects.Add(enemy3);

            Enemy_Following enemy4 = new Enemy_Following(50, 300, game_objects, game_Form);
            game_objects.Add(enemy4);
            Enemy_Following enemy5 = new Enemy_Following(300, 50, game_objects, game_Form);
            game_objects.Add(enemy5);
            Wall wall1 = new Wall(100, 100, game_Form);
            game_objects.Add(wall1);
            Wall wall2 = new Wall(200, 200, game_Form);
            game_objects.Add(wall2);
            Wall wall3 = new Wall(50, 300, game_Form);
            game_objects.Add(wall3);
            Wall wall4 = new Wall(400, 50, game_Form);
            game_objects.Add(wall4);
            Wall wall5 = new Wall(400, 400, game_Form);
            game_objects.Add(wall5);
            Wall wall6 = new Wall(600, 350, game_Form);
            game_objects.Add(wall6);
        }

        private void Game_End()
        {
            //Remove all existing components (ie. Objects, GameController, etc.)
            game_objects = new List<GameObject>();
        }

        public void Shutdown()
        {
            properties_Pause = false;
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

        public void Set_Properties_Pause(bool boolean)
        {
            properties_Pause = boolean;
        }

        public bool Get_Properties_Pause()
        {
            return properties_Pause;
        }
    }
}
