using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace KBS1.controller
{
    class HighscoreWriter
    {


        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public void SubmitScore(string name, string score, int currentLevel)
        {
            //file location
            string file = @"\scores\level" + currentLevel + ".xml";
            string ScoreRegistry = path + file;

            if (File.Exists(ScoreRegistry))
            {
                var xDoc = XElement.Load(ScoreRegistry);
                //write the score into an existing xml file
                var myNewElement = new XElement("Score", 
                   new XAttribute("name", name),
                   new XAttribute("score", score)
                );
                xDoc.Add(myNewElement);
                xDoc.Save(ScoreRegistry);
                MessageBox.Show("Uw score is toegevoegd. pad: " + ScoreRegistry);

            }
            else if (!File.Exists(ScoreRegistry))
            { 
            // write the XML file and add a new score
            XmlTextWriter writer = new XmlTextWriter(ScoreRegistry, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("highscore");
            writer.Indentation = 2;
            writer.WriteStartElement("Score");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("score", score);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("Uw score is geregistreerd. pad: " + ScoreRegistry);
            }
        }           

    }
}

