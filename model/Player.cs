using System;
using System.Drawing;
using System.Windows.Forms;

namespace KBS1.model
{
    public class Player : GameObject
    {
        //needs direction enum (up, down, left, right) for the GameController to do its calculations
        static String player_description = "The player is the character that needs to avoid being attacked by the wolves, solve puzzles and make it to the finish.";
        private bool direction_UP, direction_DOWN, direction_LEFT, direction_RIGHT;


        public Player(int player_health,int player_speed, int pos_x, int pos_y, int player_width, int player_height, Form form) : base(pos_x, pos_y, player_width, player_height, player_speed, player_speed, player_health, player_health, form)
        {
            Type = ObjectType.PLAYER;
        }

        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.playerNORTHWEST;
            imageNorth = Properties.Resources.playerNORTH;
            imageNorthEast = Properties.Resources.playerNORTHEAST;

            imageWest = Properties.Resources.playerWEST;
            imageIdle = Properties.Resources.playerIDLE;
            imageEast = Properties.Resources.playerEAST;

            imageSouthWest = Properties.Resources.playerSOUTHWEST;
            imageSouth = Properties.Resources.playerSOUTH;
            imageSouthEast = Properties.Resources.playerSOUTHEAST;
        }

        //public override void Move()
        //{
        //    //Checks up
        //    if(direction_UP && Position_Y >= (0 + Speed_Y))
        //    {
        //        Position_Y -= Speed_Y;
        //    }
        //    //Checks Down
        //    else if(direction_DOWN && Position_Y < (game_Form.Height - (Speed_Y + Height + 35)))
        //    {
        //        Position_Y += Speed_Y;
        //    }
        //    //If none, don't move

        //    //Checks left
        //    if (direction_LEFT && Position_X >= (0 + Speed_Y))
        //    {
        //        Position_X -= Speed_X;
        //    }
        //    //Checks right
        //    else if (direction_RIGHT && Position_X < (game_Form.Width - (Speed_X + Width + 14)))
        //    {
        //        Position_X += Speed_X;
        //    }
        //    //If none, don't move
            
        //}


        public void changeDirections(Keys dir, bool enabled)
        {
            //There is an up down left right, so that you have the option to stand still
            switch (dir)
            {
                case Keys.Up:
                    if (enabled && verticalDirection != Direction.SOUTH)    { verticalDirection = Direction.NORTH; }
                    else if(!enabled && verticalDirection == Direction.NORTH){ verticalDirection = Direction.NONE; }
                    break;
                case Keys.Down:
                    if (enabled && verticalDirection != Direction.NORTH) { verticalDirection = Direction.SOUTH; }
                    else if (!enabled && verticalDirection == Direction.SOUTH) { verticalDirection = Direction.NONE; }
                    break;
                case Keys.Left:
                    if (enabled && horizontalDirection != Direction.EAST) { horizontalDirection = Direction.WEST; }
                    else if (!enabled && horizontalDirection == Direction.WEST) { horizontalDirection = Direction.NONE; }
                    break;
                case Keys.Right:
                    if (enabled && horizontalDirection != Direction.WEST) { horizontalDirection = Direction.EAST; }
                    else if (!enabled && horizontalDirection == Direction.EAST) { horizontalDirection = Direction.NONE; }
                    break;
                default:
                    break;
            }
        }

        protected override void AI()
        {
            //throw new NotImplementedException();
        }

        protected override void OnDeath()
        {
            //throw new NotImplementedException();
        }
    }
}