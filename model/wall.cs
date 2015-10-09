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
            


        public override void Move()
        {
            //Doesn't move because it's immobile
        }
    }
}
