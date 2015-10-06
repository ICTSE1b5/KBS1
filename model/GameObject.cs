using System.Drawing;
using System.Windows.Forms;

namespace KBS1.model
{

    public abstract class GameObject
    {
        public enum Effects
        {
            NONE = 0,
            SLOW_1 = 1,
            SLOW_2 = 2,
            SPEED_1 = 3,
            SPEED_2 = 4
        }
        public enum ObjectType
        {
            PLAYER,
            ENEMY,
            WALL,
            HOME,
            GOAL
        }
        public enum ObjectProperties
        {
            Position_X,
            Position_Y,
            Speed_X,
            Speed_Y,
            Width,
            Height,
            Damage,
            Health,
            Type
        }

        public enum ObjectDirection
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            NONE
        }



        // Properties that all game objects have
        protected int Position_X;
        protected int Position_Y;
        protected int Width;
        protected int Height;
        protected int Speed_X;
        protected int Speed_Y;
        protected int Damage;
        protected int Health;
        public ObjectType Type { get; set; }
        public ObjectDirection Direction = ObjectDirection.NONE;
        protected Form game_Form;

        protected GameObject( int pos_x, int pos_y, int width, int height, int speed_x, int speed_y, int damage, int health, Form form)
        {
            Position_X = pos_x;
            Position_Y = pos_y;
            Width = width;
            Height = height;
            Speed_X = speed_x;
            Speed_Y = speed_y;
            Damage = damage;
            Health = health;
            game_Form = form;
        }

        public abstract void Move();
        
        /*Make a better GETTER for objects*/
        public int GetProperty(ObjectProperties propertyType)
        {
            switch(propertyType)
            {
                case ObjectProperties.Position_X:
                    return Position_X;
                case ObjectProperties.Position_Y:
                    return Position_Y;
                case ObjectProperties.Speed_X:
                    return Speed_X;
                case ObjectProperties.Speed_Y:
                    return Speed_Y;
                case ObjectProperties.Width:
                    return Width;
                case ObjectProperties.Height:
                    return Height;
                case ObjectProperties.Damage:
                    return Damage;
                case ObjectProperties.Health:
                    return Health;
                default:
                    return 0;
            }
        }

    }
}