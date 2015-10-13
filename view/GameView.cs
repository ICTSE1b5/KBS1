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

            foreach(GameObject game_prop in game_loop.GameEntities)
            {
                if (game_prop.Type.Equals(GameObject.ObjectType.PLAYER))
                {
                    switch (game_prop.Direction)
                    {
                        case GameObject.ObjectDirection.UP:
                            game_prop.image = Properties.Resources.playerUPreverse;
                            break;
                        case GameObject.ObjectDirection.DOWN:
                            game_prop.image = Properties.Resources.playerDOWN;
                            break;
                        case GameObject.ObjectDirection.LEFT:
                            game_prop.image = Properties.Resources.playerLEFT;
                            break;
                        case GameObject.ObjectDirection.RIGHT:
                            game_prop.image = Properties.Resources.playerRIGHT;
                            break;
                        case GameObject.ObjectDirection.NONE:
                            game_prop.image = Properties.Resources.playerUP;
                            break;
                    }
                }
                else if (game_prop.Type.Equals(GameObject.ObjectType.ENEMY))
                {
                    switch (game_prop.Direction)
                    {
                        case GameObject.ObjectDirection.UP:
                            game_prop.image = Properties.Resources.wolf_up;
                            break;
                        case GameObject.ObjectDirection.DOWN:
                            game_prop.image = Properties.Resources.wolf_down;
                            break;
                        case GameObject.ObjectDirection.LEFT:
                            game_prop.image = Properties.Resources.wolf_left;
                            break;
                        case GameObject.ObjectDirection.RIGHT:
                            game_prop.image = Properties.Resources.wolf_right;
                            break;
                        case GameObject.ObjectDirection.NONE:
                            game_prop.image = Properties.Resources.wolf_up;
                            break;
                    }
                }

                graphics_GraphicsDevice.DrawImage(game_prop.image, game_prop.getRectangle());

            }

        }



    }
}
