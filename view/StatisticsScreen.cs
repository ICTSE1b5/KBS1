using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.view
{
    public partial class StatisticsScreen : UserControl
    {
        public StatisticsScreen()
        {
            InitializeComponent();
            DrawPanel();
            SetStyle(ControlStyles.Selectable, false);
            AutoScroll = true;
        }

        public void DrawPanel()
        {
            List<Panel> panelList = new List<Panel>();
            int x = 0;
            string s1 = "X = 50";
            string s2 = "Y = 50";
            string s3 = "Speed = 5";
            string s4 = "This is the player, you can move it with \n using the arrow keys on the keyboard";
            
            for (int i = 0; i < 20; i++)
            {
                Label l1 = new Label();
                l1.Location = new Point(95, 11);
                l1.Size = new Size(35, 13);
                l1.AutoSize = true;
                l1.Text = s1;

                Label l2 = new Label();
                l2.Location = new Point(95, 24);
                l2.Size = new Size(35, 13);
                l2.AutoSize = true;
                l2.Text = s2;

                Label l3 = new Label();
                l3.Location = new Point(95, 37);
                l3.Size = new Size(35, 13);
                l3.AutoSize = true;
                l3.Text = s3;

                TextBox tb1 = new TextBox();
                tb1.BackColor = SystemColors.ActiveCaption;
                tb1.BorderStyle = BorderStyle.None;
                tb1.Location = new Point(16, 69);
                tb1.Multiline = true;
                tb1.Size = new Size(200, 41);
                tb1.Text = s4;

                Label l4 = new Label();
                l4.Location = new Point(16, 69);
                l4.Size = new Size(200, 41);
                l4.AutoSize = true;
                l4.Text = s4;

                PictureBox pb1 = new PictureBox();
                pb1.Image = Properties.Resources.playerDOWN;
                pb1.Location = new Point(16, 11);
                pb1.Size = new Size(73, 54);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;

                Panel p1 = new Panel();
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(l3);
                p1.Controls.Add(l4);
                p1.Controls.Add(pb1);
                p1.Location = new Point(0, x);
                p1.Size = new Size(220, 100);

                panelList.Add(p1);
                x += 100;
            }

            foreach (var list in panelList)
            {
                Controls.Add(list);
            }
        }
    }
}
