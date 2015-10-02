using System.Drawing;

namespace KBS1.model {
    public class Player : GameObject {
        public Player(int x, int y, int width, int height, int speed, int damage, int health, Bitmap image) 
            : base(x, y, width, height, speed, damage, health, image) {
        }
    }
}