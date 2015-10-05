using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KBS1.model
{
    abstract class Enemy : GameObject
    {
        protected Player player1;

        public Enemy(int pos_x, int pos_y, int width, int height, int speed_x, int speed_y, int damage, int health, List<GameObject> props)
            : base(pos_x, pos_y, width, height, speed_x, speed_y, damage, health)
        {
            Type = ObjectType.ENEMY;
            MessageBox.Show("Starting to look for the player");
            foreach(GameObject player in props)
            {
                MessageBox.Show("Looking...");
                if(player.Type.Equals(ObjectType.PLAYER))
                {
                    player1 = (Player)player;
                    MessageBox.Show("Player has been found!");
                }                
                
            }
            MessageBox.Show("Done looking");
        }

        public abstract void AI();  //Reserved for special effects that happen, this has nothing to do with movement
    }
}