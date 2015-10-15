using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace KBS1.controller {

    public class XMLWriter {

        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public void SaveLevel( string levelName, Dictionary<string, Dictionary<string, int>> levelData ) {
            string directory = path + @"\levels\";
            if( !Directory.Exists(directory) )
                Directory.CreateDirectory(directory);

            string finalPath = directory + levelName + ".xml";
            if( !File.Exists(finalPath) ) {
                XmlTextWriter writer = new XmlTextWriter(finalPath, System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("level");
                foreach( KeyValuePair<string, Dictionary<string, int>> pair in levelData ) {
                    this.Write(writer, pair.Key, pair.Value);
                }
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        public string GetPath() {
            return this.path;
        }

        private void Write( XmlTextWriter writer, string name, Dictionary<string, int> objectData ) {
            writer.WriteStartElement(name);
            foreach( KeyValuePair<string, int> pair in objectData ) {
                writer.WriteAttributeString(pair.Key, pair.Value.ToString());
            }
            writer.WriteEndElement();
        }
    }
}