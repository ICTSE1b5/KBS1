﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Wall : GameObject
    {
        public Wall(int pos_x, int pos_y, Form form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 0, form)
        {
            Type = ObjectType.WALL;
            this.image = Properties.Resources.bush;
            this.description = "Walls are objects that block your path, forcing you to move around it";

        }

        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.bush;
            imageNorth = Properties.Resources.bush;
            imageNorthEast = Properties.Resources.bush;

            imageWest = Properties.Resources.bush;
            imageIdle = Properties.Resources.bush;
            imageEast = Properties.Resources.bush;

            imageSouthWest = Properties.Resources.bush;
            imageSouth = Properties.Resources.bush;
            imageSouthEast = Properties.Resources.bush;
        }

        protected override void AI()
        {
            //throw new NotImplementedException();
        }

        protected override void OnDeath()
        {
            //TODO
        }
        
    }
}
