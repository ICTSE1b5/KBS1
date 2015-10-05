using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    class Enemy_Following : Enemy
    {
        public Enemy_Following(int pos_x, int pos_y, List<GameObject> props)
            : base(pos_x, pos_y, 20, 20, 1, 1, 5, 10, props)
        {

        }

        public override void AI()
        {

        }

        public override void Move()
        {
            int playerX = player1.GetProperty(ObjectProperties.Position_X);
            int playerY = player1.GetProperty(ObjectProperties.Position_Y);

            //Horisontal
            //Right
            if(playerX > Position_X)
            {
                Position_X += Speed_X;
            }
            //Left
            else if(playerX < Position_X)
            {
                Position_X -= Speed_X;
            }
            //Else don't move horisontally

            //Verticaly
            //Down
            if(playerY > Position_Y)
            {
                Position_Y += Speed_Y;
            }
            //UP
            else if(playerY < Position_Y)
            {
                Position_Y -= Speed_Y;
            }
            //Else don't move verticaly
        }
    }
}
