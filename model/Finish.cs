using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Finish : GameObject
    {
       
       public Finish(int pos_x, int pos_y, int width, int height, Form form)
            : base(pos_x, pos_y, width, height, 0, 0, 0, 0, form)
        {
            Type = ObjectType.GOAL;
            this.image = Properties.Resources.loghouse;
            this.description = "When you reach the finish you complete the level";
        }

        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.loghouse;
            imageNorth = Properties.Resources.loghouse;
            imageNorthEast = Properties.Resources.loghouse;

            imageWest = Properties.Resources.loghouse;
            imageIdle = Properties.Resources.loghouse;
            imageEast = Properties.Resources.loghouse;

            imageSouthWest = Properties.Resources.loghouse;
            imageSouth = Properties.Resources.loghouse;
            imageSouthEast = Properties.Resources.loghouse;
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
