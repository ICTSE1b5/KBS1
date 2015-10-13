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
            : base(pos_x, pos_y, 80, 80, 1, 1, 5, 10, props, form)
        {
            
        }

        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.wolf_up_left;
            imageNorth = Properties.Resources.wolf_up;
            imageNorthEast = Properties.Resources.wolf_up_right;

            imageWest = Properties.Resources.wolf_left;
            imageIdle = Properties.Resources.wolf_down;
            imageEast = Properties.Resources.wolf_right;

            imageSouthWest = Properties.Resources.wolf_down_left;
            imageSouth = Properties.Resources.wolf_down;
            imageSouthEast = Properties.Resources.wolf_down_right;
        }

        protected override void AI()
        {
            int playerX = player1.pos_x;
            int playerY = player1.pos_y;

            //Horisontal
            //Right
            if (playerX > Position_X)
            {
                setHorizontalDirection(Direction.EAST);
            }
            //Left
            else if (playerX < Position_X)
            {
                setHorizontalDirection(Direction.WEST);
            }
            //Else don't move horisontally
            else
            {
                setHorizontalDirection(Direction.NONE);
            }

            //Verticaly
            //Down
            if (playerY > Position_Y)
            {
                setVerticalDirection(Direction.SOUTH);
            }
            //UP
            else if (playerY < Position_Y)
            {
                setVerticalDirection(Direction.NORTH);
            }
            //Else don't move verticaly
            else
            {
                setVerticalDirection(Direction.NONE);
            }

        }

        /*
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
        */
        protected override void OnDeath()
        {
            //throw new NotImplementedException();
        }

        
    }
}
