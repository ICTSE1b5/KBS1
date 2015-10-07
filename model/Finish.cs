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
       public Finish(int pos_x, int pos_y, int width, int height, Form form)
            : base(pos_x, pos_y, width, height, 0, 0, 0, 0, form)
        {
            Type = ObjectType.GOAL;
        }
        

        public override void Move()
        {
            //Doesn't move because it's immobile;
        }
    }
}
