using System;
using System.Drawing;
using System.Windows.Forms;

namespace KBS1.model
{
    public class Player : GameObject
    {
        //needs direction enum (up, down, left, right) for the GameController to do its calculations
        static int player_speed = 2;
        static int player_size = 20;
        

        private bool direction_UP, direction_DOWN, direction_LEFT, direction_RIGHT;


        public Player(int pos_x, int pos_y) : base(pos_x, pos_y, player_size, player_size, player_speed, player_speed, 2, 5)
        {
            Type = ObjectType.PLAYER;
        }


        public override void Move()
        {
            //Checks up
            if(direction_UP)
            {
                Position_Y -= Speed_Y;
            }
            //Checks Down
            else if(direction_DOWN)
            {
                Position_Y += Speed_Y;
            }
            //If none, don't move

            //Checks left
            if (direction_LEFT)
            {
                Position_X -= Speed_X;
            }
            //Checks right
            else if (direction_RIGHT)
            {
                Position_X += Speed_X;
            }
            //If none, don't move
            
        }


        public void changeDirections(Keys dir, bool enabled)
        {            
            //There is an up down left right, so that you have the option to stand still
            switch (dir)
            {
                case Keys.Up:
                    if (enabled && !direction_DOWN) { direction_UP = true; }
                    else { direction_UP = false; }
                    break;
                case Keys.Down:
                    if (enabled && !direction_UP) { direction_DOWN = true; }
                    else { direction_DOWN = false; }
                    break;
                case Keys.Left:
                    if (enabled && !direction_RIGHT) { direction_LEFT = true; }
                    else { direction_LEFT = false; }
                    break;
                case Keys.Right:
                    if (enabled && !direction_LEFT) { direction_RIGHT = true; }
                    else { direction_RIGHT = false; }
                    break;
                default:
                    break;
            }
        }

    }
}