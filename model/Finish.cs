using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Finish : GameObject
    {
        static String finish_description = "The goal is where you (the player) want to go. When you reach the goal, you finish the level.";
       public Finish(int pos_x, int pos_y, int width, int height, Form form)
            : base(pos_x, pos_y, width, height, 0, 0, 0, 0, form)
        {
            Type = ObjectType.GOAL;
        }

        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.loghouse;
            imageNorth = Properties.Resources.loghouse;
            imageNorthEast = Properties.Resources.loghouse;

            imageWest = Properties.Resources.loghouse;
            imageIdle = Properties.Resources.loghouse;
            imageEast = Properties.Resources.loghouse;

            imageSouthWest = Properties.Resources.loghouse;
            imageSouth = Properties.Resources.loghouse;
            imageSouthEast = Properties.Resources.loghouse;
        }

        protected override void AI()
        {
            //throw new NotImplementedException();
        }

        protected override void OnDeath()
        {
            //throw new NotImplementedException();
        }
    }
}
