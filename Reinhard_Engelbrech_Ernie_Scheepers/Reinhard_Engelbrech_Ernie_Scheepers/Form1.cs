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


        public void unhide(PictureBox pb)
        {
            if (pb.Bounds.IntersectsWith(pbArmory.Bounds))
            {
                pbArmory.Visible = true;
                pbArmory.ImageLocation = "Cloud.jpg";
            }
            if (pb.Bounds.IntersectsWith(pbBarrack.Bounds))
            {
                pbBarrack.Visible = true;

                pbBarrack.ImageLocation = "Cloud.jpg";
            }
            if (pb.Bounds.IntersectsWith(pbHeadquaters.Bounds))
            {
                pbHeadquaters.Visible = true;

                pbHeadquaters.ImageLocation = "Cloud.jpg";
            }
            if (pb.Bounds.IntersectsWith(pbHospital.Bounds))
            {
                pbHospital.Visible = true;
                pbHospital.ImageLocation = "Cloud.jpg";
            }
            if (pb.Bounds.IntersectsWith(pbTankDepo.Bounds))
            {
                pbTankDepo.Visible = true;
                pbTankDepo.ImageLocation = "Cloud.jpg";
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
            int x = 757;
            int y = 400;
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
            int x = 757;
            int y = 400;
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
            int x = 757;
            int y = 400;
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
                tmrFuel.Stop();
                timerLeft.Stop();
                timerTop.Stop();
                tmrAltitude.Stop();
                TmrSpeed.Stop();
                MessageBox.Show("Please choose a plane to fly with");

            }

        }

        private void timerTop_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pb.Location.Y > 53)
                {
                    pb.Top -= 1;
                    unhide(pb);
                }
                else
                {
                    timerTop.Stop();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please choose a plane to fly with");
            }

        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            pb.Left += 1;

        }

        List<Point> lPoints = new List<Point>();

        Point endpoint = new Point(69, 53);
        Point beginPoint = new Point(757, 400);
        decimal m = 0;
        decimal c = 0;

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            decimal yDiff = beginPoint.Y - endpoint.Y;
            decimal xDiff = beginPoint.X - endpoint.X;

            m = (yDiff / xDiff);

            c = (decimal)(beginPoint.Y + (-1 * ((m) * (beginPoint.X))));

            for (int i = endpoint.X; i < beginPoint.X; i += 10)
            {
                Point point = new Point(i, (int)(i * m + c));
                lPoints.Add(point);
            }

            lPoints.Reverse();

            //tmrMove.Start();
            //tmrMove Code start
            foreach (Point item in lPoints)
            {
                pb.Location = item;
                MessageBox.Show("Test");
            }
            //tmrMove Code end

            tmrFuel.Start();
            //timerLeft.Start();
            //timerTop.Start();
            tmrAltitude.Start();
            TmrSpeed.Start();

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
                prbFuel.Value -= Convert.ToInt32(WeightLoaded / 1000);
                TimerFuel -= 1;
            }
            else
            {
                tmrFuel.Stop();

            }

        }


        private void tmrAltitude_Tick(object sender, EventArgs e)
        {
            if (TimerAltitude <= altitude)
            {
                TimerAltitude += 10;
                lblAltitude.Text = Convert.ToString(TimerAltitude);
            }
            else
            {
                tmrAltitude.Stop();
            }
        }

        private void TmrSpeed_Tick(object sender, EventArgs e)
        {
            if (TimerSpeed <= speed)
            {
                TimerSpeed += 10;
                lblSpeed.Text = Convert.ToString(TimerSpeed);
            }
            else
            {
                TmrSpeed.Stop();
            }
        }

        private void btnAddCannon_Click(object sender, EventArgs e)
        {
            PictureBox picture = new PictureBox
            {
                //Name = "Cannon" + CannonNumber,
                Size = new Size(60, 60),
                Location = new Point(100, 100),
                Image = Image.FromFile("Cannon1.png"),
            };
            Guns.Add(pb);
            this.Controls.Add(pb);

        }



        Point dragPoint = Point.Empty;
        bool dragging = false;




        private void pbCannon_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon.Location = new Point(pbCannon.Location.X + e.X - dragPoint.X, pbCannon.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon2.Location = new Point(pbCannon2.Location.X + e.X - dragPoint.X, pbCannon2.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon2_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon3.Location = new Point(pbCannon3.Location.X + e.X - dragPoint.X, pbCannon3.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon3_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon4_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon4.Location = new Point(pbCannon4.Location.X + e.X - dragPoint.X, pbCannon4.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon4_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon5_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon5.Location = new Point(pbCannon5.Location.X + e.X - dragPoint.X, pbCannon5.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon5_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon6_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon6.Location = new Point(pbCannon6.Location.X + e.X - dragPoint.X, pbCannon6.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon6_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon7_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon7.Location = new Point(pbCannon7.Location.X + e.X - dragPoint.X, pbCannon7.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon7_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon8_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon8.Location = new Point(pbCannon8.Location.X + e.X - dragPoint.X, pbCannon8.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon8_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void pbCannon9_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon9.Location = new Point(pbCannon9.Location.X + e.X - dragPoint.X, pbCannon9.Location.Y + e.Y - dragPoint.Y);
        }

        private void pbCannon9_MouseClick(object sender, MouseEventArgs e)
        {
            if (dragging == false)
            {
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            //foreach (Point item in lPoints)
            //{
            //    pb.Location = item;
            //    MessageBox.Show("Test");

            //}
        }
        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
