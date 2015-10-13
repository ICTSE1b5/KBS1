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
        static String wall_description = "Walls are objects that block the path of the player.forcing you to move around it.";

        public Wall(int pos_x, int pos_y, Form form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 0, form)
        {
                Type = ObjectType.WALL;
        }

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
