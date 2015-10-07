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
