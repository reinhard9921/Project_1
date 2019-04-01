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
            Jets.Add(new Jet("Spitfire", 600, 6100, 550, 2000, 2500));
            Jets.Add(new Jet("F-16 Falcon", 2400, 12000, 1143, 9000, 9500));
            Jets.Add(new Jet("de Haviland", 900, 18000, 750, 3000, 5000));
        }

        double TimerAltitude;
        double TimerSpeed;
        int TimerFuel = 100;
        PictureBox pb = null;
        string Plane = null;
        List<Jet> Jets = new List<Jet>();
        List<PictureBox> Guns = new List<PictureBox>();
        double altitude;
        double speed;
        double WeightLoaded;
        double WeightUnloaded;
        int fuel;
        int CannonNumber;
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
            if (pb.Bounds.IntersectsWith(pbCannon.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            if (pb.Bounds.IntersectsWith(pbCannon2.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            if (pb.Bounds.IntersectsWith(pbCannon3.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            if (pb.Bounds.IntersectsWith(pbCannon4.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
            }
            if (pb.Bounds.IntersectsWith(pbCannon5.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (pb.Bounds.IntersectsWith(pbCannon6.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
            }
            if (pb.Bounds.IntersectsWith(pbCannon7.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (pb.Bounds.IntersectsWith(pbCannon8.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (pb.Bounds.IntersectsWith(pbCannon9.Bounds))
            {
                MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            x = 757;
            y = 400;
            pb.Location = new Point(x, y);
            Plane = "F-16 Falcon";
            foreach (Jet item in Jets)
            {
                if (item.Name == "F-16 Falcon")
                {

                    altitude = item.TopAltitude;
                    speed = item.MaxSpeed;
                    WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);
                }
            }
            prbFuel.Maximum = fuel;
            prbFuel.Value = fuel;

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
            Plane = "Spitfire";
            foreach (Jet item in Jets)
            {
                if (item.Name == "Spitfire")
                {

                    altitude = item.TopAltitude;
                    speed = item.MaxSpeed;
                    WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);
                }
            }
            prbFuel.Maximum = fuel;
            prbFuel.Value = fuel;
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
            Plane = "de Haviland";
            foreach (Jet item in Jets)
            {
                if (item.Name == "de Haviland")
                {

                    altitude = item.TopAltitude;
                    speed = item.MaxSpeed;
                    WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);
                }
            }
            prbFuel.Maximum = fuel;
            prbFuel.Value = fuel;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pb.Location.Y > 69)
                {
                    pb.Left -= 2;
                    unhide(pb);
                }
                else
                {
                    timerLeft.Stop();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please choose a plane to fly with");
            }

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
            tmrFuel.Start();
            timerLeft.Start();
            timerTop.Start();
        }

            if (Plane == "Spitfire")
            {

            }

            if (Plane == "F-16 Falcon")
            {

            }

            if (Plane == "de Haviland")
            {

            }
        }



        private void tmrFuel_Tick(object sender, EventArgs e)
        {
            if (TimerFuel >= 0)
            {
                prbFuel.Value -= 2;
                TimerFuel -= 1;
            }
            else
            {
                tmrFuel.Stop();

            }
        }

        }
    }
}
