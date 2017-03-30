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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Wumpus wump = new Wumpus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wumpus wump = new Wumpus();
            wump.wumpusWakesUp(2,true);
            String wumpusWakesUp = wump.getWumpusState();
            textBox1.Text = wumpusWakesUp;

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
