using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Enemy_Following : Enemy
    {
        static String enemy_description = "The wolf will attack the player when you get too close. getting attacked by the wolf will kill you.";
        public Enemy_Following(int pos_x, int pos_y, List<GameObject> props, Form form)
            : base(pos_x, pos_y, 80, 80, 1, 1, 5, 10, props, form) {
            this.image = Properties.Resources.wolf_up;
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
                Direction = ObjectDirection.RIGHT;
            }
            //Left
            else if(playerX < Position_X)
            {
                Position_X -= Speed_X;
                Direction = ObjectDirection.LEFT;
            }
            //Else don't move horisontally

            //Verticaly
            //Down
            if(playerY > Position_Y)
            {
                Position_Y += Speed_Y;
                Direction = ObjectDirection.DOWN;
            }
            //UP
            else if(playerY < Position_Y)
            {
                Position_Y -= Speed_Y;
                Direction = ObjectDirection.UP;
            }
            //Else don't move verticaly
        }
    }
}
