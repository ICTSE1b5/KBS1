using System.IO;
using System.Windows.Forms;

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

        public void SaveLevel()
        {
            
        }

        public void LoadLevel(string name)
        {
            string file = @"\levels\"+name+".xml";
            string directory = path + file;
            MessageBox.Show("Gefeliciteerd, uw eigen level is geladen ! pad: " + directory);


        }
       





}
}