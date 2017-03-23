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
    public partial class MapTest : Form
    {
        public MapTest()
        {
            InitializeComponent();
        }
        public static void main(String[] args)
        {
            
            wumpusLocation(awake);
            return wumpusLocation;
        }
    }
}
