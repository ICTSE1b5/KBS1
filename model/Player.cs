using System;
using System.Drawing;

namespace KBS1.model
{
    public class Player : GameObject
    {
        //needs direction enum (up, down, left, right) for the GameController to do its calculations
        static int player_speed = 2;
        static int player_size = 20;


        public Player(int pos_x, int pos_y) : base(pos_x, pos_y, player_size, player_size, player_speed, player_speed, 2, 5)
        {
            Type = ObjectType.PLAYER;
        }


        public override void Move()
        {
            Position_X += Speed_X;
            Position_Y += Speed_Y;
        }
    }
}