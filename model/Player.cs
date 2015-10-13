using System;
using System.Drawing;
using System.Windows.Forms;

namespace KBS1.model
{
    public class Player : GameObject
    {
        //needs direction enum (up, down, left, right) for the GameController to do its calculations
        private bool direction_UP, direction_DOWN, direction_LEFT, direction_RIGHT;


        public Player(int player_health,int player_speed, int pos_x, int pos_y, int player_width, int player_height, Form form) : base(pos_x, pos_y, player_width, player_height, player_speed, player_speed, player_health, player_health, form)
        {
            Type = ObjectType.PLAYER;
            this.image = Properties.Resources.playerDOWN;
            this.description = "This is the player, you can move it with using the arrow keys on the keyboard";
        }


        public override void Move()
        {
            //Checks up
            if(direction_UP && Position_Y >= (0 + Speed_Y))
            {
                Position_Y -= Speed_Y;
            }
            //Checks Down
            else if(direction_DOWN && Position_Y < (game_Form.Height - (Speed_Y + Height + 35)))
            {
                Position_Y += Speed_Y;
            }
            //If none, don't move

            //Checks left
            if (direction_LEFT && Position_X >= (0 + Speed_Y))
            {
                Position_X -= Speed_X;
            }
            //Checks right
            else if (direction_RIGHT && Position_X < (game_Form.Width - (Speed_X + Width + 14)))
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
                    if (enabled && !direction_DOWN) { direction_UP = true; Direction = ObjectDirection.UP; }
                    else { direction_UP = false; }
                    break;
                case Keys.Down:
                    if (enabled && !direction_UP) { direction_DOWN = true; Direction = ObjectDirection.DOWN; }
                    else { direction_DOWN = false; }
                    break;
                case Keys.Left:
                    if (enabled && !direction_RIGHT) { direction_LEFT = true; Direction = ObjectDirection.LEFT; }
                    else { direction_LEFT = false; }
                    break;
                case Keys.Right:
                    if (enabled && !direction_LEFT) { direction_RIGHT = true; Direction = ObjectDirection.RIGHT; }
                    else { direction_RIGHT = false; }
                    break;
                default:
                    break;
            }
        }

    }
}