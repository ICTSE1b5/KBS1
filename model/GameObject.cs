using System.Drawing;

namespace KBS1.model {
    public abstract class GameObject {

        // Properties that all game objects have
        protected int X { get; }
        protected int Y { get; }
        protected int Width { get; }
        protected int Height { get; }
        protected int Speed { get; }
        protected int Damage { get; }
        protected int Health { get; }
        protected Bitmap Image { get; }

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