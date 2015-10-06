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
                            graphics_GraphicsDevice.DrawImage(Properties.Resources.playerUP, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                            break;
                        case GameObject.ObjectDirection.DOWN:
                            graphics_GraphicsDevice.DrawImage(Properties.Resources.playerDOWN, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                            break;
                        case GameObject.ObjectDirection.LEFT:
                            graphics_GraphicsDevice.DrawImage(Properties.Resources.playerLEFT, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                            break;
                        case GameObject.ObjectDirection.RIGHT:
                            graphics_GraphicsDevice.DrawImage(Properties.Resources.playerRIGHT, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                            break;
                        case GameObject.ObjectDirection.NONE:
                            graphics_GraphicsDevice.DrawImage(Properties.Resources.playerUP, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                            break;
                    }
                }
                else if (game_prop.Type.Equals(GameObject.ObjectType.ENEMY))
                {
                    graphics_GraphicsDevice.FillRectangle(Brushes.Red, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                }
                else
                {
                    graphics_GraphicsDevice.FillRectangle(Brushes.Green, game_prop.GetProperty(GameObject.ObjectProperties.Position_X), game_prop.GetProperty(GameObject.ObjectProperties.Position_Y), game_prop.GetProperty(GameObject.ObjectProperties.Width), game_prop.GetProperty(GameObject.ObjectProperties.Height));
                }
                
            }

        }



    }
}
