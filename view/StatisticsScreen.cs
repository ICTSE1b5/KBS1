using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KBS1.model;

namespace KBS1.view
{
    public partial class StatisticsScreen : UserControl
    {
        List<StatisticPanel> panelList;

        public StatisticsScreen()
        {
            panelList = new List<StatisticPanel>();
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
            AutoScroll = true;
        }

        //Loops through all gameobjects and creates a panel for each object
        public void DrawPanel(List<GameObject> gameobjects)
        {
            int x = 0;
            foreach (GameObject item in gameobjects)
            {
                if (item.GetType() == typeof(Player))
                {
                    StatisticPanel panel = new StatisticPanel(item);
                    panel.Location = new Point(0, x);
                    panel.Size = new Size(220, 100);
                    panel.Name = "Player";
                    panelList.Add(panel);
                    Controls.Add(panel);
                    x += 100;
                }
                else if (item is Enemy)
                {
                    StatisticPanel panel = new StatisticPanel(item);
                    panel.Location = new Point(0, x);
                    panel.Size = new Size(220, 100);
                    panel.Name = "Enemy";
                    panelList.Add(panel);
                    Controls.Add(panel);
                    x += 100;
                }
            }
        }

        //Loops through all gameobjects and updates each panel for each corresponding object
        public void updatePanel()
        {
                foreach (StatisticPanel panel in panelList)
                {
                    panel.updatePanel();
                }

        }
    }
}
