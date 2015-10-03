using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KBS1.controller;
using KBS1.model;
using KBS1.view;

namespace KBS1
{
    public partial class Form1 : Form
    {

        private GameLoop game_loop;
        private GameView game_view;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch the direction of the player
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Remove this when the main menu has been added.
            this.Show();
            game_loop = new GameLoop(this, GameLoop.FrameRate.THIRTY);
            game_view = new GameView(this, game_loop);
            game_loop.Start();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics_GraphicDevice = e.Graphics;

            game_view.DrawGame(e.Graphics);

        }
    }
}
