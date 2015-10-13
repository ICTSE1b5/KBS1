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
            this.image = Properties.Resources.bush;
            this.description = "Walls are objects that block your path, forcing you to move around it";
        }
            
        public override void Move()
        {
            //Doesn't move because it's immobile
        }
    }
}
