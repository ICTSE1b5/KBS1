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
                                string damage = reader.GetAttribute("damage");
                                List<string> temp = new List<string> { reader.Name, hp, damage };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "start")
                            {
                                string hp = reader.GetAttribute("hp");
                                string damage = reader.GetAttribute("damage");
                                List<string> temp = new List<string> { reader.Name, hp, damage };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "finish")
                            {
                                string hp = reader.GetAttribute("hp");
                                string damage = reader.GetAttribute("damage");
                                List<string> temp = new List<string> { reader.Name, hp, damage };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "enemy")
                            {
                                string hp = reader.GetAttribute("hp");
                                string damage = reader.GetAttribute("damage");
                                List<string> temp = new List<string> { reader.Name, hp, damage };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "wall")
                            {
                                string hp = reader.GetAttribute("hp");
                                string damage = reader.GetAttribute("damage");
                                List<string> temp = new List<string> { reader.Name, hp, damage };
                                this.data.Add(temp);
                            }
                            break;
                    }
                }
            }
        }

    }
}