using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Wall : GameObject
    {
        public Wall(int pos_x, int pos_y, Form1 form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 0, form)
        {
            Type = ObjectType.WALL;
            this.image = Properties.Resources.bush;
            this.description = "Walls are objects that block your path, forcing you to move around it";

        }

        //Sets the image for this Class
        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.bush;
            imageNorth = Properties.Resources.bush;
            imageNorthEast = Properties.Resources.bush;

            imageWest = Properties.Resources.bush;
            imageIdle = Properties.Resources.bush;
            imageEast = Properties.Resources.bush;

            imageSouthWest = Properties.Resources.bush;
            imageSouth = Properties.Resources.bush;
            imageSouthEast = Properties.Resources.bush;
        }

        //This method does nothing when there has been collision with this object because this is a wall
        protected override void AI()
        {
            //Can't do anything
        }

        protected override void OnDeath()
        {
            //Can't die
        }
    }
}
