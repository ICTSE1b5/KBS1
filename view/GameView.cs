using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Windows.Forms;
using KBS1.controller;
using KBS1.model;

namespace KBS1.view
{
    class GameView
    {
        Form game_Form;
        GameLoop game_loop;

        public GameView(Form form, GameLoop loop)
        {
            game_Form = form;
            game_loop = loop;
        }

        public void DrawGame(Graphics graphics_GraphicsDevice)
        //public void DrawGame(ref Graphics graphics_GraphicsDevice)
        { 
            //draw background?? or is this done at initialization
            graphics_GraphicsDevice.FillRectangle(Brushes.Red, 0, 0, game_Form.Width, game_Form.Height);
            //go through each object currently alive and draw them

            /*Test Block*/
            //graphics_GraphicsDevice.FillRectangle(Brushes.Blue, 50, 50, 20, 20);
            game_loop.GameEntities.ForEach(obj => graphics_GraphicsDevice.DrawImage(obj.getObjectImage(), obj.ObjectRectangle));
            

        }



    }
}
