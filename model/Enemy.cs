using System.Drawing;

namespace KBS1.model
{
    abstract class Enemy : GameObject
    {
        public Enemy(int pos_x, int pos_y, int width, int height, int speed_x, int speed_y, int damage, int health)
            : base(pos_x, pos_y, width, height, speed_x, speed_y, damage, health)
        {
            Type = ObjectType.ENEMY;
        }

        public abstract void AI();
    }
}