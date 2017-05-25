using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusProject
{
    public partial class CaveDesign : Form
    {
        Scores myScores;
        public bool arrows;
        public bool secrets;
        public String wayMoved;
        public bool statsChosen;

        public CaveDesign()
          
        {
            InitializeComponent();
            wumpusBox.Hide();
            batBox.Hide();
            pitBox.Hide();
        }

        private void LeftBttn_Click(object sender, EventArgs e)
        {
            wayMoved = "Left";
        }

        private void RightBttn_Click(object sender, EventArgs e)
        {
            wayMoved = "Right";
        }

        private void StraightBttn_Click(object sender, EventArgs e)
        {
            wayMoved = "Forward";
        }

        private void StatsDisplay_Click(object sender, EventArgs e)
        {
            statsChosen = true;
            Scores myScores = new Scores();
            myScores.Show();
        }

        public PictureBox WumpusPicBox
        {
            get { return wumpusBox; }
        }
        public PictureBox BatPicBox
        {
            get { return batBox; }
        }
        public PictureBox PitPicBox
        {
            get { return pitBox; }
        }
        public Label HazardLabel
        {
            get { return hazardLbl; }
        }
        public Button ArrowBtn
        {
            get { return buyArrowBtn; }
        }
        public Button SecretsBtn
        {
            get { return buySecretsBtn; }
        }

        private void buySecretsBtn_Click(object sender, EventArgs e)
        {
            secrets = true;
        }

        private void buyArrowBtn_Click(object sender, EventArgs e)
        {
            arrows = true;
        }
    }
}
