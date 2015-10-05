using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;

namespace KBS1.controller
{
    class GameController
    {
        private Form game_Form;
        private GameLoop game_Loop;

        
        public GameController(Form form, GameLoop loop)
        {
            game_Form = form;
            game_Loop = loop;
            //needs extra initialization items
        }

        public void Update()
        {
            //foreach loop to update all positions of enemies
            //-->enemies move with their AI = follow the player, run from player, give effects, etc.

            //player position gets updated


            /*Temporary solution that puts all the object in one simple loop*/
            /*Gets expanded with Delegations that call a 'Move()' in an object*/
            foreach(GameObject game_prop in game_Loop.GameEntities)
            {
                game_prop.Move();
            }



        }

    }
}
