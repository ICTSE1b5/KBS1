using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Enemy_Following : Enemy
    {
        public Enemy_Following(int pos_x, int pos_y, int speed, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, 80, 80, speed, speed, 5, 10, props, form)
        {
            this.image = Properties.Resources.wolf_up;
            this.description = "The wolf will chase you and when he reaches you, you are dead";
        }

        //Sets the image for this Class
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

        //This method lets the player die when there has been collision with this object.
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


            foreach (GameObject ob in currentCollisionObjectsList)
            {
                switch (ob.Type)
                {
                    case ObjectType.PLAYER:
                        ob.Kill();
                        break;
                    default:
                        break;
                }

            }
        }
        
        protected override void OnDeath()
        {
            //Can't die -yet-
        }


    }
}
