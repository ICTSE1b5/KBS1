using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    class Enemy_Static : Enemy
    {
        public Enemy_Static(int pos_x, int pos_y)
            : base(pos_x, pos_y, 20, 20, 0, 0, 5, 10)
        {

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
