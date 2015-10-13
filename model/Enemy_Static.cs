using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Enemy_Static : Enemy
    {
        public Enemy_Static(int pos_x, int pos_y, List<GameObject> props, Form form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 5, 10, props, form) {
            this.image = Properties.Resources.wolf_up;
        }

        public override void AI()
        {

        }

        public override void Move()
        {
            //Doesn't move because it's immobile??
        }
    }
}
