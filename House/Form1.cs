using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace House
{
    public partial class Form1 : Form
    {
        TheHouse house;
        Graphics gScreen;
        Rectangle r;
        Bitmap bitmap;
        Graphics gBitmap;
        System.Timers.Timer drawTimer;

        public Form1()
        {
            InitializeComponent();
        }

        public TheHouse House
        {
            get
            {
                return house;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            gScreen = this.CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            gBitmap = Graphics.FromImage(bitmap);
            r = ClientRectangle;
            house = new TheHouse();
            textBox1.Text = Settings.TimeSpeed.ToString();
            textBox2.Text = Settings.LiftSpeed.ToString();
            drawTimer = new System.Timers.Timer(Settings.DrawInterval);
            drawTimer.Elapsed += RefreshScreen;
            drawTimer.AutoReset = true;
            drawTimer.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void RefreshScreen(Object source, ElapsedEventArgs e)
        {
            Drawer.Draw(gBitmap);
            try
            {
                gScreen.DrawImage(bitmap, r);
            }
            catch { }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int interv = Convert.ToInt32(textBox1.Text);
            if (interv >= Settings.MinTimeSpeed && interv <= Settings.MaxTimeSpeed) Settings.TimeSpeed = Convert.ToInt32(textBox1.Text);
            else textBox1.Text = Settings.TimeSpeed.ToString();

            interv = Convert.ToInt32(textBox2.Text);
            if (interv >= Settings.MinLiftSpeed && interv <= Settings.MaxLiftSpeed) Settings.LiftSpeed = Convert.ToInt32(textBox2.Text);
            else textBox2.Text = Settings.LiftSpeed.ToString();
        }
    }
}
