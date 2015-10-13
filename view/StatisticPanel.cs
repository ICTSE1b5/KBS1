using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;
using System.Drawing;

namespace KBS1.view
{
    class StatisticPanel : Panel
    {
        private Label xLabel;
        private Label xLabelData;
        private Label yLabel;
        private Label yLabelData;
        private Label speedLabel;
        private Label speedLabelData;
        private Label descriptionLabel;
        private PictureBox objectPicture;
        public GameObject gameObject { get; }

        //Creates a Panel for each gameobject
        public StatisticPanel(GameObject gameObject)
        {
            this.gameObject = gameObject;
            xLabel = new Label();
            xLabel.Text = "X = ";
            xLabel.Location = new Point(95, 11);
            xLabel.AutoSize = true;

            xLabelData = new Label();
            xLabelData.Text = gameObject.GetProperty(GameObject.ObjectProperties.Position_X).ToString();
            xLabelData.Location = new Point(118, 11);
            xLabelData.AutoSize = true;

            yLabel = new Label();
            yLabel.Text = "Y = ";
            yLabel.Location = new Point(95, 24);
            yLabel.AutoSize = true;

            yLabelData = new Label();
            yLabelData.Text = gameObject.GetProperty(GameObject.ObjectProperties.Position_X).ToString();
            yLabelData.Location = new Point(118, 24);
            yLabelData.AutoSize = true;

            speedLabel = new Label();
            speedLabel.Text = "Speed = ";
            speedLabel.Location = new Point(95, 37);
            speedLabel.AutoSize = true;

            speedLabelData = new Label();
            speedLabelData.Text = gameObject.GetProperty(GameObject.ObjectProperties.Speed_X).ToString();
            speedLabelData.Location = new Point(141, 37);
            speedLabelData.AutoSize = true;

            descriptionLabel = new Label();
            descriptionLabel.Text = gameObject.description;
            descriptionLabel.Location = new Point(16, 69);
            descriptionLabel.Size = new Size(200, 41);

            objectPicture = new PictureBox();
            objectPicture.Image = gameObject.image;
            objectPicture.Location = new Point(16, 11);
            objectPicture.Size = new Size(73, 54);
            objectPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            Controls.Add(xLabel);
            Controls.Add(xLabelData);
            Controls.Add(yLabel);
            Controls.Add(yLabelData);
            Controls.Add(speedLabel);
            Controls.Add(speedLabelData);
            Controls.Add(descriptionLabel);
            Controls.Add(objectPicture);
        }

        //Updates the info for each panel in the StatisticsScreen
        public void updatePanel()
        {
            xLabelData.Text = this.gameObject.GetProperty(GameObject.ObjectProperties.Position_X).ToString();
            yLabelData.Text = this.gameObject.GetProperty(GameObject.ObjectProperties.Position_Y).ToString();
            speedLabelData.Text = this.gameObject.GetProperty(GameObject.ObjectProperties.Speed_X).ToString();
        }
    }
}
