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

        public void Handle(List<GameObject> game_objects, Form game_Form, List<List<string>> data)
        {
            //Adds the player to the List
            player1 = new Player(0, 0, game_Form);
            game_objects.Add(player1);

            Finish finish = new Finish(720, 500, 50, 50, game_Form);
            game_objects.Add(finish);
            Enemy_Following enemy3 = new Enemy_Following(500, 500, game_objects, game_Form);
            game_objects.Add(enemy3);

            Enemy_Following enemy4 = new Enemy_Following(50, 300, game_objects, game_Form);
            game_objects.Add(enemy4);
            Enemy_Following enemy5 = new Enemy_Following(300, 50, game_objects, game_Form);
            game_objects.Add(enemy5);
            Wall wall1 = new Wall(100, 100, game_Form);
            game_objects.Add(wall1);
            Wall wall2 = new Wall(200, 200, game_Form);
            game_objects.Add(wall2);
            Wall wall3 = new Wall(50, 300, game_Form);
            game_objects.Add(wall3);
            Wall wall4 = new Wall(400, 50, game_Form);
            game_objects.Add(wall4);
            Wall wall5 = new Wall(400, 400, game_Form);
            game_objects.Add(wall5);
            Wall wall6 = new Wall(600, 350, game_Form);
            game_objects.Add(wall6);

            
        }
    }
}