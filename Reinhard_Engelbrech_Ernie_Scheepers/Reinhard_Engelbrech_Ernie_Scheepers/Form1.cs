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
using System.IO;

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
        int hit;
        int Success;
        bool HQ;
        bool Hospital;
        bool barracks;
        bool armory;
        Random rnd = new Random();
        int FlightSpeed;

        public void unhide(PictureBox pb)
        {
            if (pb.Bounds.IntersectsWith(pbArmory.Bounds))
            {

                hit = rnd.Next(8);
                if (hit == 1)
                {
                    pbArmory.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    armory = true;
                }

            }
            if (pb.Bounds.IntersectsWith(pbBarrack.Bounds))
            {

                hit = rnd.Next(20 );
                if (hit == 1)
                {
                    pbBarrack.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    barracks = true;
                }
            }
            if (pb.Bounds.IntersectsWith(pbHeadquaters.Bounds))
            {
                hit = rnd.Next(2);
                if (hit == 1)
                {
                    pbHeadquaters.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    HQ = true;
                }
            }
            if (pb.Bounds.IntersectsWith(pbHospital.Bounds))
            {
                hit = rnd.Next(25);
                if (hit == 1)
                {
                    pbHospital.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    Hospital = true;
                }
            }
            if (pb.Bounds.IntersectsWith(pbTankDepo.Bounds))
            {
                hit = rnd.Next(20);
                if (hit == 1)
                {
                    pbTankDepo.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    barracks = true;
                }
 
            }
            //if (pb.Bounds.IntersectsWith(pbCannon.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon2.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon3.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon4.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon5.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon6.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon7.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            //if (pb.Bounds.IntersectsWith(pbCannon8.Bounds))
            //{
            //    MessageBox.Show("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    StopThreads();
            //}
            if ((pb.Bounds.IntersectsWith(pbCannon.Bounds)) || (pb.Bounds.IntersectsWith(pbCannon2.Bounds)) ||
                (pb.Bounds.IntersectsWith(pbCannon3.Bounds)) || (pb.Bounds.IntersectsWith(pbCannon4.Bounds)) ||
                (pb.Bounds.IntersectsWith(pbCannon5.Bounds)) || (pb.Bounds.IntersectsWith(pbCannon6.Bounds)) ||
                (pb.Bounds.IntersectsWith(pbCannon7.Bounds)) || (pb.Bounds.IntersectsWith(pbCannon8.Bounds)) ||
                (pb.Bounds.IntersectsWith(pbCannon9.Bounds)))
            {
                StopThreads("Plane was shot down", "Plane Hit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StopThreads(string message, string heading, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            tmrFuel.Stop();
            tmrAltitude.Stop();
            TmrSpeed.Stop();
            MessageBox.Show(message, heading, messageBoxButtons, messageBoxIcon);

            if (tMove != null)
            {
                tMove.Abort();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lstReports.Items.Clear();
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
                    FlightSpeed = 3;
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
                    FlightSpeed = 1;
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
                    FlightSpeed = 1; WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);
                }
            }
            prbFuel.Maximum = fuel;
            prbFuel.Value = fuel;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (pb.Location.Y > 69)
            //    {
            //        pb.Left -= 2;
            //        unhide(pb);
            //    }
            //    else
            //    {
            //        //timerLeft.Stop();
            //    }
            //}
            //catch (Exception)
            //{
            //    tmrFuel.Stop();
            //    //timerLeft.Stop();
            //    //timerTop.Stop();
            //    tmrAltitude.Stop();
            //    TmrSpeed.Stop();
            //    MessageBox.Show("Please choose a plane to fly with");

            //}

        }

        private void timerTop_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (pb.Location.Y > 53)
            //    {
            //        pb.Top -= 1;
            //        unhide(pb);
            //    }
            //    else
            //    {
            //        //timerTop.Stop();
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

        List<Point> lPoints = new List<Point>();

        Thread tMove = null;

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

            for (int i = endpoint.X; i < beginPoint.X; i += FlightSpeed)
            {
                Point point = new Point(i, (int)(i * m + c));
                lPoints.Add(point);
            }

            lPoints.Reverse();


            Thread tTest = new Thread(JetTest);

            tTest.Start();



            //tMove = new Thread(JetMove);

            //tMove.Start();

            tmrFuel.Start();
            tmrAltitude.Start();
            TmrSpeed.Start();


        }



        private void tmrFuel_Tick(object sender, EventArgs e)
        {
            int devider = 1;
            if (Plane == "Spitfire")
            {
                devider = Convert.ToInt32(WeightLoaded / 1000);
            }
            else if (Plane ==  "F-16 Falcon")
            {

                devider = Convert.ToInt32(WeightLoaded / 2000);
            }
            else if (Plane ==  "de Haviland")
            {

            }
        }
            List<Point> lRight = new List<Point>();

        public void JetTest()
        {
            pb = pbtest;
            Point point = new Point(0, 0);

            for (int i = 0; i < lPoints.Count(); i++)
            {
                JetMoveCrossThread(lPoints[i]);
                if (pb.Bounds.IntersectsWith(pbCannon.Bounds))
                {
                    for (int j = i; j < lPoints.Count(); j++)
                    {
                        lRight.Add(lPoints[j]);
                    }

                    
                }

                for (int k = 0; k < lRight.Count(); k++)
                {
                    while (pb.Bounds.IntersectsWith(pbCannon.Bounds))
                    {
                        Point newpoint = lRight[k];
                        newpoint.X += 10;
                        newpoint.Y += 10;
                        lRight[k] = newpoint;
                        JetMoveCrossThread(lRight[k]);
                    }
                    int iDiff = lPoints.Count() - lRight.Count();
                    //lPoints[k + iDiff - 1] = lRight[k];
                }
            }

            JetMoveCrossThread(lRight[0]);

            //foreach (Point item in lRight)
            //{

            //    JetMoveCrossThread(item);

            //    Thread.Sleep(100);
            //}
        }

        private void tmrFuel_Tick(object sender, EventArgs e)
        {
            if (TimerFuel >= 0)
            {
                prbFuel.Value -= devider;
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

        }

        delegate void delCrossThreadMove(Point point);
        delegate void delCrossThreadShow();


        public void JetMoveCrossThread(Point point) //solution vir jet se movement
        {
            if (this.pb.InvokeRequired)
            {
                delCrossThreadMove d = new delCrossThreadMove(JetMoveCrossThread);
                this.Invoke(d, point);
            }
            else
            {
                this.pb.Location = point;
            }
        }

        public void BaseCampVisibility() //solution vir jet se movement
        {
            if (this.pbArmory.InvokeRequired)
            {
                delCrossThreadShow d = new delCrossThreadShow(BaseCampVisibility);
                this.Invoke(d);
            }
            else
            {
                this.pbArmory.Visible = true;
                this.pbBarrack.Visible = true;
                this.pbHeadquaters.Visible = true;
                this.pbHospital.Visible = true;
                this.pbTankDepo.Visible = true;
            }
        }

        public void JetMove()
        {
            foreach (Point item in lPoints)
            {
                JetMoveCrossThread(item);

                if ((item.X <= 485) || (item.Y <= 260))
                {
                    BaseCampVisibility();
                }
                unhide(pb);
                //MessageBox.Show("Test");

                Thread.Sleep(100);
            }
        }

        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            StopThreads("Stopping all threads,\nApplication closing", "Application closed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            base.OnClosing(e);
        }

        public void DisplayReport()
        {

            FileStream fs = new FileStream("Report.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine("Success Rate of the Mission: " + Success + "%");
            writer.WriteLine("Buildings that was hit: ");
            if (HQ == true)
            {
                writer.WriteLine("Headquaters at Coordinates " + pbHeadquaters.Location.X + ", " + pbHeadquaters.Location.Y);
            }
            if (Hospital == true)
            {
                writer.WriteLine("Hospital at Coordinates " + pbHospital.Location.X + ", " + pbHospital.Location.Y);
            }
            if (barracks == true)
            {
                writer.WriteLine("Barracks at Coordinates " + pbBarrack.Location.X + ", " + pbBarrack.Location.Y);
            }
            if (armory == true)
            {
                writer.WriteLine("Armory at Coordinates " + pbArmory.Location.X + ", " + pbArmory.Location.Y);
            }


            //Add Line for object avoided


            writer.WriteLine("Plane That Was Chosen Was The: " + Plane);
            writer.WriteLine("Invintory still Full");
            writer.WriteLine("Amount of Fuel Left " + prbFuel.Value + "l");

        }

        public void DisplayReportOnEdit()
        {
            FileStream fs = new FileStream("Report.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(fs);

            string sline = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                lstReports.Items.Add(sline);
                sline = reader.ReadLine();
            }
        }

    }
}
