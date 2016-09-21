using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TheHouse house;
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            house = new TheHouse();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Drawer.Draw(g);
        }
    }
}
