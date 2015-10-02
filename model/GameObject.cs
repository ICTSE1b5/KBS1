using System.Drawing;

namespace KBS1.model {

    public abstract class GameObject {

        // Properties that all game objects have
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public int Speed { get; }
        public int Damage { get; }
        public int Health { get; }
        public Bitmap Image { get; }

        protected GameObject( int x, int y, int width, int height, int speed, int damage, int health, Bitmap image ) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Damage = damage;
            Health = health;
            Image = image;
        }

    }
}