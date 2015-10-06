using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace KBS1
{
    class GameLevels
    {
        private Form1 form1;
        
        string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public GameLevels(Form1 form)
        {
            this.form1 = form;
        }

        public void SaveLevel(string name)
        {
            string file = @"\levels\" + name + ".xml";
            string savefile = path + file;

            // write the XML file
            XmlTextWriter writer = new XmlTextWriter(savefile, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("level");
            writeFinish(500, 500, writer);
            writePlayer(100, 1000, 200,0,0, writer);
            writer.WriteStartElement("elements");
            writeEnemy("1","Following", 300, 150, 500, 100, writer);
            writeEnemy("2","Static", 200, 200, 500, 100, writer);
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

        public void LoadLevel(string name)
        {
            string file = @"\levels\" + name + ".xml";
            string directory = path + file;
            MessageBox.Show("Gefeliciteerd, uw eigen level is geladen ! pad: " + directory);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(directory);

            //get elements
            XmlNodeList allnodes = xmlDoc.DocumentElement.SelectNodes("/level");
            string allnodestext = allnodes[0].InnerText;
            
        }

        private void writePlayer(int speed, int health, int damage,int posX,int posY, XmlTextWriter writer)
        {
            writer.WriteStartElement("player");
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
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

        private void writeEnemy(string pID, string type, int posX, int posY, int health, int damage, XmlTextWriter writer)
        {
            writer.WriteStartElement("enemy");
            writer.WriteStartElement("enemy_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("type");
            writer.WriteValue(posX);
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