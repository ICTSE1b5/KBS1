using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KBS1.controller
{
    class XmlParser
    {
        private XmlTextReader reader;
        private List<List<string>> data;

        public XmlParser(string name)
        {
            this.reader = new XmlTextReader(name);
            this.data = new List<List<string>>();
        }

        public void Parse()
        {
            if(this.reader != null)
            {
                while (this.reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if(reader.Name!= "level")
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