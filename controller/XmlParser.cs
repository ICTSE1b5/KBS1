using KBS1.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KBS1.controller
{
    public class XmlParser
    {
        private XmlTextReader reader;
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public List<List<string>> data { get; }
        public Player player1;
        public Finish finish1;

        public XmlParser()
        {
            this.data = new List<List<string>>();
        }
        //dumps the data from the level xml file specified above in a List<List<string>>
        public void Parse(string name)
        {
            //finding the directory of the XML file
            string file = @"\levels\" + name + ".xml";
            string directory = path + file;

            this.reader = new XmlTextReader(directory);

            // if the reader exists, start reading
            if (this.reader != null)
            {
                //reads the nodes in the xml file
                while (this.reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        //if the nodetype is an element, read the name of the element, and add the data in the XML-attributes to the List<List<string>>
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

        public void Handle(List<GameObject> game_objects, Form1 game_Form,string levelslug)
        {
            // gets an XML file from a specific directory
            this.Parse(levelslug);
            // parser fills the variable list data

            // for each item in var data
            foreach (List<string> item in data)
            {
                if (item[0] == "player")
                {
                    //create new object
                    player1 = new Player(Int32.Parse(item[1]), Int32.Parse(item[2]), Int32.Parse(item[3]), Int32.Parse(item[4]), Int32.Parse(item[5]), Int32.Parse(item[6]), game_Form);
                    //Adds object to the list
                    game_objects.Add(player1);
                }
                if (item[0] == "finish")
                {
                    //create new object
                    finish1 = new Finish(Int32.Parse(item[1]), Int32.Parse(item[2]), Int32.Parse(item[3]), Int32.Parse(item[4]), game_Form);
                    //Adds object to the list
                    game_objects.Add(finish1);
                }
                if (item[0] == "enemy")
                {
                    //create new object
                    Enemy_Following enemy = new Enemy_Following(Int32.Parse(item[3]), Int32.Parse(item[4]), game_objects, game_Form);
                    //Adds object to the list
                    game_objects.Add(enemy);
                }
                if (item[0] == "static")
                {
                    //create new object
                    Wall wall = new Wall(Int32.Parse(item[1]), Int32.Parse(item[2]), game_Form);
                    //Adds object to the list
                    game_objects.Add(wall);
                }
            }
        }

            
        
    }
}