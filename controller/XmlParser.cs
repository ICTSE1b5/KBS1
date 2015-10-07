using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KBS1.controller
{
    class XmlParser
    {
        private XmlTextReader reader;
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public List<List<string>> data { get; }

        public XmlParser()
        {
            this.data = new List<List<string>>();
        }
        //dumps the data from the level xml file specified above in a List<List<string>>
        public void Parse(string name)
        {
            string file = @"\levels\" + name + ".xml";
            string directory = path + file;
            this.reader = new XmlTextReader(directory);

            if (this.reader != null)
            {
                while (this.reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        // contents of the if-statements will be changed after a definitive format for the level-xml has been decided.
                        case XmlNodeType.Element:
                            if(reader.Name!= "level" && reader.Name == "player")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "finish")
                            {
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, x, y, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "enemy")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "aura")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string range = reader.GetAttribute("range");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, range, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "static")
                            {
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, x, y, width, height };
                                this.data.Add(temp);
                            }
                            break;
                    }
                }
            }
        }

    }
}