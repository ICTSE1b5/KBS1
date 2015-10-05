using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace KBS1.view
{
    public partial class LevelSelectScreen : UserControl
    {
        public event EventHandler LevelSelectScreenClick;

        public LevelSelectScreen()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void Button_Load_Click(object sender, EventArgs e)
        {

            // get the path of the current project
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string file = @"\levels\level1.xml";
            string savefile = path + file;

            // write the XML file
            XmlTextWriter writer = new XmlTextWriter(savefile, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("level");
            writeStart(0, 0, writer);
            writeFinish(500, 500, writer);
            writePlayer(100, 1000, 200, writer);
            writer.WriteStartElement("elements");
            writeEnemy("1", 300, 150, 500, 100, writer);
            writeEnemy("2", 200, 200, 500, 100, writer);
            writeWall("1", 50, 50, writer);
            writeWall("2", 100, 100, writer);
            writeWall("3", 150, 150, writer);
            writeWall("4", 200, 200, writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Close();
            MessageBox.Show("Gefeliciteerd, uw eigen level is aangemaakt! pad: " + savefile);





        }

        private void Button_Main_Menu_Click(object sender, EventArgs e)
        {
            LevelSelectScreenClick(sender, e);
        }

        public Button Get_Button_Main_Click()
        {
            return button_Main_Menu;
        }


        private void writePlayer(int speed, int health, int damage, XmlTextWriter writer)
        {
            writer.WriteStartElement("player");
            writer.WriteStartElement("speed");
            writer.WriteValue(speed);
            writer.WriteEndElement();
            writer.WriteStartElement("health");
            writer.WriteValue(health);
            writer.WriteEndElement();
            writer.WriteStartElement("damage");
            writer.WriteValue(damage);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void writeStart(int posX, int posY, XmlTextWriter writer)
        {
            writer.WriteStartElement("start");
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void writeFinish(int posX, int posY, XmlTextWriter writer)
        {
            writer.WriteStartElement("finish");
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }



        private void writeWall(string pID, int posX, int posY, XmlTextWriter writer)
        {
            writer.WriteStartElement("wall");
            writer.WriteStartElement("wall_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void writeEnemy(string pID, int posX, int posY, int health, int damage, XmlTextWriter writer)
        {
            writer.WriteStartElement("enemy");
            writer.WriteStartElement("enemy_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteStartElement("health");
            writer.WriteValue(health);
            writer.WriteEndElement();
            writer.WriteStartElement("damage");
            writer.WriteValue(health);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
