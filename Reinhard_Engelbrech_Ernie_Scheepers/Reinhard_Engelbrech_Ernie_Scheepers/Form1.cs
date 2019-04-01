﻿using System;
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

        public void unhide(PictureBox pb)
        {
            if (pb.Bounds.IntersectsWith(pbArmory.Bounds))
            {
                pbArmory.Visible = true;
            }
            if (pb.Bounds.IntersectsWith(pbBarrack.Bounds))
            {
                pbBarrack.Visible = true;
            }
            if (pb.Bounds.IntersectsWith(pbHeadquaters.Bounds))
            {
                pbHeadquaters.Visible = true;
            }
            if (pb.Bounds.IntersectsWith(pbHospital.Bounds))
            {
                pbHospital.Visible = true;
            }
            if (pb.Bounds.IntersectsWith(pbTankDepo.Bounds))
            {
                pbTankDepo.Visible = true;
            }
        }
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

        
 

        private void timer1_Tick(object sender, EventArgs e)
        {
            pb.Left -= 2;
        }

        private void timerTop_Tick(object sender, EventArgs e)
        {
            if (pb.Location.Y > 53)
            {
                pb.Top -= 1;
            }
        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            pb.Left += 1;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            int x = 1010;
            int y = 500;

            pb.Location = new Point(x, y);

            timerLeft.Start();
            timerTop.Start();

        }
    }
}
