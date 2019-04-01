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

        int TimerFuel = 100;
        PictureBox pb = null;
        List<Point> lpath = new List<Point>();
        int y = 0;
        int x = 0;
        int yEnd = 53;
        int xEnd = 69;

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
            prbFuel.Value = 100;
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
            x = 757;
            y = 400;
            pb.Location = new Point(x, y);

        }

        private void btn747_Click(object sender, EventArgs e)
        {
            pb747.Show();
            pbF16.Hide();
            pbStealthBomber.Hide();
            pb = pb747;
            x = 757;
            y = 400;
            pb.Location = new Point(x, y);
        }

        private void btnBomber_Click(object sender, EventArgs e)
        {
            pb747.Hide();
            pbF16.Hide();
            pbStealthBomber.Show();
            pb = pbStealthBomber;
            x = 757;
            y = 400;
            pb.Location = new Point(x, y);
        }

        private void pbStealthBomber_Click(object sender, EventArgs e)
        {

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (pb.Location.X > xEnd)
            //    {
            //        pb.Left -= 2;
            //        unhide(pb);
            //    }
            //    else
            //    {
            //        timerLeft.Stop();
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Please choose a plane to fly with");
            //}

        }

        private void timerTop_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (pb.Location.Y > yEnd)
            //    {
            //        pb.Top -= 1;
            //        unhide(pb);
            //    }
            //    else
            //    {
            //        timerTop.Stop();
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Please choose a plane to fly with");
            //}

        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            pb.Left += 1;

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            //tmrFuel.Start();
            //timerLeft.Start();
            //timerTop.Start();
            int iCount = xEnd;

            while (iCount < x)
            {
                Point point = new Point(iCount, (int)(0.5 * iCount) + 18);
                lpath.Add(point);
                iCount += 10;
            }
            //for (int i = xEnd; i < x; i++)
            //{
            //    Point point = new Point(i, (int)(0.5 * i) + 18);
            //    lpath.Add(point);
            //}

            //lpath.Reverse();

            //foreach (Point item in lpath)
            //{
            //    pb.Location = item;
            //    MessageBox.Show(Convert.ToString(pb.Location));
            //}

            tmrMove.Start();

        }

        private void pb747_Click(object sender, EventArgs e)
        {

        }

        private void pbF16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tmrFuel_Tick(object sender, EventArgs e)
        {
            //if (TimerFuel >= 0)
            //{
            //    prbFuel.Value -= 2;
            //    TimerFuel -= 1;
            //}
            //else
            //{
            //    tmrFuel.Stop();
            //    timerTop.Stop();
            //    timerLeft.Stop();
            //}

        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            //lpath.Reverse();

            //foreach (Point item in lpath)
            //{
            //    pb.Location = item;
            //    MessageBox.Show(Convert.ToString(pb.Location));
            //}
        }

        private void timerDown_Tick(object sender, EventArgs e)
        {

        }

        private void timerRight_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
