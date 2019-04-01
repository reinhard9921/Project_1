using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Reinhard_Engelbrech_Ernie_Scheepers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox pb = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            pb747.Hide();
            pbF16.Hide();
            pbStealthBomber.Hide();
        }

        private void btnF16_Click(object sender, EventArgs e)
        {
            pb747.Hide();
            pbF16.Show();
            pbStealthBomber.Hide();
            pb = pbF16;

        }

        private void btn747_Click(object sender, EventArgs e)
        {
            pb747.Show();
            pbF16.Hide();
            pbStealthBomber.Hide();
            pb = pb747;
        }

        private void btnBomber_Click(object sender, EventArgs e)
        {
            pb747.Hide();
            pbF16.Hide();
            pbStealthBomber.Show();
            pb = pbStealthBomber;
        }

        private void pbStealthBomber_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerLeft.Start();
            timerTop.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pb.Left -= 1;
        }

        private void timerTop_Tick(object sender, EventArgs e)
        {
            pb.Top -= 1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            int x = 1010;
            int y = 500;

            while (//Run tot hy by die base is die base se x = 220 en y = 42)
            {
                x -= 3;
                y -= 1;
                pb747.Location = new Point(x, y);


            }
        }
    }
}
