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
            Jets.Add(new Jet("Spitfire", 100, 6100, 550, 2000));
            Jets.Add(new Jet("F-16 Falcon", 200, 12000, 1143, 9500));
            Jets.Add(new Jet("de Haviland", 100, 18000, 750, 5000));
        }

        double TimerAltitude;
        //double TimerSpeed;
        int TimerFuel = 100;
        PictureBox pb = null;
        string Plane = null;
        List<Jet> Jets = new List<Jet>();
        List<PictureBox> Guns = new List<PictureBox>();
        double altitude;
        //double speed;
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
        //int FlightSpeed;

        public void Unhide(PictureBox pb)
        {
            if (pb.Bounds.IntersectsWith(pbArmory.Bounds))
            {

                hit = rnd.Next(8);
                if (hit == 1)
                {
                    pbArmory.ImageLocation = "Cloud.jpg";
                    Success += 25;
                    armory = true;
                }

            }
            if (pb.Bounds.IntersectsWith(pbBarrack.Bounds))
            {

                hit = rnd.Next(20);
                if ((hit == 1) && (barracks = false))
                {
                    pbBarrack.ImageLocation = "Cloud.jpg";
                    Success += 25;
                    barracks = true;
                }
            }
            if (pb.Bounds.IntersectsWith(pbHeadquaters.Bounds))
            {
                hit = rnd.Next(2);
                if ((hit == 1) && (HQ = false))
                {
                    pbHeadquaters.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    HQ = true;
                }
            }
            if (pb.Bounds.IntersectsWith(pbHospital.Bounds))
            {
                hit = rnd.Next(25);
                if ((hit == 1) && (Hospital = false))
                {
                    pbHospital.ImageLocation = "Cloud.jpg";
                    Success += hit;
                    Hospital = true;
                }
            }
            //if (pb.Bounds.IntersectsWith(pbTankDepo.Bounds))
            //{
            //    hit = rnd.Next(20);
            //    if (hit == 1)
            //    {
            //        pbTankDepo.ImageLocation = "Cloud.jpg";
            //        Success += hit;
            //        barracks = true;
            //    }

            //}
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
            if (CheckCollission(pb) != null)
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
            lstReports.Clear();
            pb747.Hide();
            pbF16.Hide();
            pbStealthBomber.Hide();
        }

        int x = 602;
        int y = 701;

        private void btnF16_Click(object sender, EventArgs e)
        {
            pb747.Hide();
            pbF16.Show();
            pbStealthBomber.Hide();
            pb = pbF16;

            pb.Location = new Point(x, y);
            Plane = "F-16 Falcon";
            foreach (Jet item in Jets)
            {
                if (item.Name == "F-16 Falcon")
                {
                    item.LInventory.Add(new InventoryObjects("V2 Rocket missile", 1500));
                    item.LInventory.Add(new InventoryObjects("Fat-B0y", 2000));

                    altitude = item.TopAltitude;
                    TopSpeed = item.MaxSpeed;
                    CurrentSpeed = 500;
                    item.CalculateInventoryWeight();
                    WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);

                    lstJetDetails.Items.Clear();
                    lstJetDetails.Items.Add(string.Format("Jet Name: {0}", item.Name));
                    lstJetDetails.Items.Add(string.Format("Top speed: {0} km/h", item.MaxSpeed.ToString()));
                    lstJetDetails.Items.Add(string.Format("Jet weight: {0} kg", item.WeightWithoutInventory.ToString()));
                    lstJetDetails.Items.Add(string.Format("Inverntory weight: {0} kg", (item.WeightWithInventory - item.WeightWithoutInventory).ToString()));

                    lstJetDetails.Items.Add(string.Format("Items in inventory: {0}", item.Name));

                    foreach (InventoryObjects inventoryObject in item.LInventory)
                    {
                        lstJetDetails.Items.Add(string.Format("\t{0}: {1} kg", inventoryObject.Name, inventoryObject.Weight));

                    }
                    lstJetDetails.Items.Add("");

                    lstJetDetails.Items.Add(string.Format("Total weight: {0} kg", item.WeightWithInventory.ToString()));
                    lstJetDetails.Items.Add(string.Format("Fueltank Size: {0} l", item.MaxSpeed.ToString()));
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
            pb.Location = new Point(x, y);
            Plane = "Spitfire";
            foreach (Jet item in Jets)
            {
                if (item.Name == "Spitfire")
                {
                    item.LInventory.Add(new InventoryObjects("V2 Rocket missile", 1500));
                    item.LInventory.Add(new InventoryObjects("Fat-B0y", 2000));

                    altitude = item.TopAltitude;
                    TopSpeed = item.MaxSpeed;
                    CurrentSpeed = 500;
                    item.CalculateInventoryWeight();
                    WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);

                    lstJetDetails.Items.Clear();
                    lstJetDetails.Items.Add(string.Format("Jet Name: {0}", item.Name));
                    lstJetDetails.Items.Add(string.Format("Top speed: {0} km/h", item.MaxSpeed.ToString()));
                    lstJetDetails.Items.Add(string.Format("Jet weight: {0} kg", item.WeightWithoutInventory.ToString()));
                    lstJetDetails.Items.Add(string.Format("Inverntory weight: {0} kg", (item.WeightWithInventory - item.WeightWithoutInventory).ToString()));

                    lstJetDetails.Items.Add(string.Format("Items in inventory: {0}", item.Name));

                    foreach (InventoryObjects inventoryObject in item.LInventory)
                    {
                        lstJetDetails.Items.Add(string.Format("\t{0}: {1} kg", inventoryObject.Name, inventoryObject.Weight));

                    }
                    lstJetDetails.Items.Add("");

                    lstJetDetails.Items.Add(string.Format("Total weight: {0} kg", item.WeightWithInventory.ToString()));
                    lstJetDetails.Items.Add(string.Format("Fueltank Size: {0} l", item.MaxSpeed.ToString()));
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
            pb.Location = new Point(x, y);
            Plane = "de Haviland";
            foreach (Jet item in Jets)
            {
                if (item.Name == "de Haviland")
                {
                    item.LInventory.Add(new InventoryObjects("V2 Rocket missile", 1500));
                    item.LInventory.Add(new InventoryObjects("Fat-B0y", 2000));

                    altitude = item.TopAltitude;
                    TopSpeed = item.MaxSpeed;
                    CurrentSpeed = 500;
                    item.CalculateInventoryWeight();
                    WeightLoaded = item.WeightWithInventory;
                    WeightUnloaded = item.WeightWithoutInventory;
                    fuel = Convert.ToInt32(item.FuelTankSize);

                    lstJetDetails.Items.Clear();
                    lstJetDetails.Items.Add(string.Format("Jet Name: {0}", item.Name));
                    lstJetDetails.Items.Add(string.Format("Top speed: {0} km/h", item.MaxSpeed.ToString()));
                    lstJetDetails.Items.Add(string.Format("Jet weight: {0} kg", item.WeightWithoutInventory.ToString()));
                    lstJetDetails.Items.Add(string.Format("Inverntory weight: {0} kg", (item.WeightWithInventory - item.WeightWithoutInventory).ToString()));

                    lstJetDetails.Items.Add(string.Format("Items in inventory: {0}", item.Name));

                    foreach (InventoryObjects inventoryObject in item.LInventory)
                    {
                        lstJetDetails.Items.Add(string.Format("\t{0}: {1} kg", inventoryObject.Name, inventoryObject.Weight));

                    }
                    lstJetDetails.Items.Add("");

                    lstJetDetails.Items.Add(string.Format("Total weight: {0} kg", item.WeightWithInventory.ToString()));
                    lstJetDetails.Items.Add(string.Format("Fueltank Size: {0} l", item.MaxSpeed.ToString()));
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
        Point beginPoint = new Point(602, 701);

        public PictureBox CheckCollission(PictureBox pb1)
        {
            if (pb1.Bounds.IntersectsWith(pbCannon4.Bounds))
            {
                return pbCannon4;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon7.Bounds))
            {
                return pbCannon7;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon3.Bounds))
            {
                return pbCannon3;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon8.Bounds))
            {
                return pbCannon8;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon2.Bounds))
            {
                return pbCannon2;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon6.Bounds))
            {
                return pbCannon6;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon9.Bounds))
            {
                return pbCannon9;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon5.Bounds))
            {
                return pbCannon5;
            }
            else if (pb1.Bounds.IntersectsWith(pbCannon.Bounds))
            {
                return pbCannon;
            }

            return null;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (pb == null)
                {
                    throw new CustomeException("Please select a plane first!!!");
                }

                lPoints = GetLine(beginPoint, endpoint);

                bool bFoundColision = false;

                MessageBox.Show("Planning safests path...", "Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < lPoints.Count(); i++)
                {
                    JetMoveCrossThread(lPoints[i]);
                    if (CheckCollission(pb) != null)
                    {
                        bFoundColision = true;

                        break;
                    }
                }

                while (bFoundColision)
                {
                    bFoundColision = false;

                    for (int i = 0; i < lPoints.Count(); i++)
                    {
                        JetMoveCrossThread(lPoints[i]);
                        if (CheckCollission(pb) != null)
                        {
                            bFoundColision = true;

                            break;
                        }
                    }

                    if (JetTest(-1).Count() > JetTest(1).Count())
                    {
                        lPoints = JetTest(1);
                    }
                    else
                    {
                        lPoints = JetTest(-1);
                    }

                }

                tMove = new Thread(JetMove);

                MessageBox.Show("Safest path found.\nPreparing for liftoff...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tMove.Start();

                tmrFuel.Start();
                tmrAltitude.Start();
                TmrSpeed.Start();
            }
            catch (CustomeException)
            {


            }





        }



        private void tmrFuel_Tick(object sender, EventArgs e)
        {
            int devider = 1;
            if (Plane == "Spitfire")
            {
                devider = Convert.ToInt32(WeightLoaded / 1000);
            }
            else if (Plane == "F-16 Falcon")
            {

                devider = Convert.ToInt32(WeightLoaded / 2000);
            }
            else if (Plane == "de Haviland")
            {
                devider = Convert.ToInt32(WeightLoaded / 1500);

            }

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

        public List<Point> JetTest(int iIncerementation)
        {


            List<Point> lNew = lPoints;

            List<Point> lLastLine = new List<Point>();
            List<Point> lRight = new List<Point>();
            List<Point> lFirstLine = new List<Point>();

            bool bFoundColision = false;

            PictureBox pbCollide = null;

            for (int i = 0; i < lNew.Count(); i++)
            {
                JetMoveCrossThread(lNew[i]);
                if (CheckCollission(pb) != null)
                {
                    //MessageBox.Show(string.Format("Possible collission detected at {0}\nRerouting...", pb.Location.ToString()));
                    bFoundColision = true;
                    pbCollide = CheckCollission(pb);
                    for (int j = i; j < lNew.Count(); j++)
                    {
                        lRight.Add(lNew[j]);
                    }
                    break;
                }
            }
            if (bFoundColision)
            {
                int iLastLinePos = 0;
                int iFirstLinePos = 0;

                for (int k = 0; k < lRight.Count(); k++)
                {
                    bool bChanged = false;
                    JetMoveCrossThread(lRight[k]);
                    Point newpoint = new Point();

                    while (pb.Bounds.IntersectsWith(pbCollide.Bounds))
                    {
                        bChanged = true;
                        newpoint = lRight[k];
                        newpoint.X += (10 * iIncerementation);
                        lRight[k] = newpoint;

                        JetMoveCrossThread(lRight[k]);

                        iLastLinePos = k;
                    }

                    if (bChanged)
                    {
                        if (iFirstLinePos != 0)
                        {
                            iFirstLinePos = k;
                        }
                        newpoint = lRight[k];
                        newpoint.X += (15 * iIncerementation);
                        lRight[k] = newpoint;
                    }
                }

                lLastLine = GetLine(lRight[iLastLinePos - 1], endpoint);
                lFirstLine = GetLine(beginPoint, lRight[iLastLinePos]);

                lNew.Clear();

                foreach (Point item in lFirstLine)
                {
                    if (item == lRight[iLastLinePos])
                    {
                        break;
                    }

                    lNew.Add(item);


                }


                foreach (Point item in lLastLine)
                {
                    lNew.Add(item);
                }
            }
            return lNew;
        }

        public List<Point> GetLine(Point pBegin, Point pEnd)
        {


            List<Point> lNew = new List<Point>();

            decimal m = 0;
            decimal c = 0;

            decimal yDiff = pBegin.Y - pEnd.Y;
            decimal xDiff = pBegin.X - pEnd.X;

            m = (yDiff / xDiff);

            c = (decimal)(pBegin.Y + (-1 * ((m) * (pBegin.X))));

            for (int i = pEnd.X; i < pBegin.X; i += 10)
            {
                Point point = new Point(i, (int)(i * m + c));
                lNew.Add(point);
            }

            lNew.Reverse();

            return lNew;
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
            //if (CurrentSpeed >= TopSpeed)
            //{
            //    CurrentSpeed -= 100;
            //    lblSpeed.Text = Convert.ToString(CurrentSpeed);
            //}
            //else
            //{
            //    TmrSpeed.Stop();
            //}
        }



        Point dragPoint = Point.Empty;
        bool dragging = false;




        private void pbCannon_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pbCannon4.Location = new Point(pbCannon4.Location.X + e.X - dragPoint.X, pbCannon4.Location.Y + e.Y - dragPoint.Y);
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
                pbCannon7.Location = new Point(pbCannon7.Location.X + e.X - dragPoint.X, pbCannon7.Location.Y + e.Y - dragPoint.Y);
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
                pbCannon8.Location = new Point(pbCannon8.Location.X + e.X - dragPoint.X, pbCannon8.Location.Y + e.Y - dragPoint.Y);
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
                pbCannon2.Location = new Point(pbCannon2.Location.X + e.X - dragPoint.X, pbCannon2.Location.Y + e.Y - dragPoint.Y);
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
                pbCannon9.Location = new Point(pbCannon9.Location.X + e.X - dragPoint.X, pbCannon9.Location.Y + e.Y - dragPoint.Y);
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
                pbCannon5.Location = new Point(pbCannon5.Location.X + e.X - dragPoint.X, pbCannon5.Location.Y + e.Y - dragPoint.Y);
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
                pbCannon.Location = new Point(pbCannon.Location.X + e.X - dragPoint.X, pbCannon.Location.Y + e.Y - dragPoint.Y);
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
        delegate void delCrossThreadShow();

        delegate void delCrossThreadMove(Point point);

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

        double CurrentSpeed;
        double TopSpeed;

        delegate void delCrossThreadSpeed(string speed);

        public void JetSpeedCrossThread(string speed) //solution vir jet se movement
        {
            if (this.lblSpeed.InvokeRequired)
            {
                delCrossThreadSpeed d = new delCrossThreadSpeed(JetSpeedCrossThread);
                this.Invoke(d, speed);
            }
            else
            {
                lblSpeed.Text = speed;
            }
        }
        delegate void delCrossThreadReport(string line);

        public void JetReportCrossThread(string line) //solution vir jet se movement
        {
            if (this.lblSpeed.InvokeRequired)
            {
                delCrossThreadReport d = new delCrossThreadReport(JetReportCrossThread);
                this.Invoke(d, line);
            }
            else
            {
                lstReports.Text = (line);
            }
        }
        public void JetMove()
        {

            foreach (Point item in lPoints)
            {
                JetMoveCrossThread(item);
                if ((item.X <= 458) && (item.Y <= 257))
                {
                    BaseCampVisibility();
                }
                Unhide(pb);
                Thread.Sleep((int)CurrentSpeed);

                if (CurrentSpeed > TopSpeed)
                {
                    CurrentSpeed -= 25;
                    JetSpeedCrossThread((1000 - CurrentSpeed).ToString());
                }
            }

            List<Point> lBack = lPoints;
            lBack.Reverse();

            foreach (Point item in lBack)
            {
                JetMoveCrossThread(item);
                Thread.Sleep((int)CurrentSpeed);


            }

            DisplayReport();

        }

        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            StopThreads("Stopping all threads,\nApplication closing", "Application closed", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            StringBuilder report = new StringBuilder();

            writer.WriteLine("Success Rate of the Mission: " + Success + "%");
            writer.WriteLine("Buildings that was hit: ");

            report.AppendLine("Success Rate of the Mission: " + Success + " % ");
            //JetReportCrossThread("Success Rate of the Mission: " + Success + " % ");

            if (Success == 0)
            {
                report.AppendLine("No buildings was hit");
                //JetReportCrossThread("No buildings was hit");
            }
            else
            {
                report.AppendLine("Buildings that was hit:");
                //JetReportCrossThread("Buildings that was hit:");
            }

            if (HQ == true)
            {
                report.AppendLine("Headquaters at Coordinates: " + pbHeadquaters.Location.X + ", " + pbHeadquaters.Location.Y);

                //JetReportCrossThread("\tHeadquaters at Coordinates: " + pbHeadquaters.Location.X + ", " + pbHeadquaters.Location.Y);
                writer.WriteLine("Headquaters at Coordinates " + pbHeadquaters.Location.X + ", " + pbHeadquaters.Location.Y);
            }
            if (Hospital == true)
            {
                report.AppendLine("Hospital at Coordinates: " + pbHospital.Location.X + ", " + pbHospital.Location.Y);

                //JetReportCrossThread("\tHospital at Coordinates: " + pbHospital.Location.X + ", " + pbHospital.Location.Y);
                writer.WriteLine("Hospital at Coordinates " + pbHospital.Location.X + ", " + pbHospital.Location.Y);
            }
            if (barracks == true)
            {
                report.AppendLine("Barracks at Coordinates: " + pbBarrack.Location.X + ", " + pbBarrack.Location.Y);

                //JetReportCrossThread("\tBarracks at Coordinates: " + pbBarrack.Location.X + ", " + pbBarrack.Location.Y);
                writer.WriteLine("Barracks at Coordinates " + pbBarrack.Location.X + ", " + pbBarrack.Location.Y);
            }
            if (armory == true)
            {
                report.AppendLine("Armory at Coordinates: " + pbArmory.Location.X + ", " + pbArmory.Location.Y);

                //JetReportCrossThread("\tArmory at Coordinates: " + pbArmory.Location.X + ", " + pbArmory.Location.Y);
                writer.WriteLine("Armory at Coordinates " + pbArmory.Location.X + ", " + pbArmory.Location.Y);
            }

            JetReportCrossThread(report.ToString());

            //Add Line for object avoided



            writer.WriteLine("Plane That Was Chosen Was The: " + Plane);
            writer.WriteLine("Invintory still Full");
            writer.WriteLine("Amount of Fuel Left " + prbFuel.Value + "l");

            fs.Close();

            //Reportform frmReport = new Reportform(report.ToString());
            //frmReport.Show();

            StopThreads(report.ToString(), "End", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void DisplayReportOnEdit()
        {
            FileStream fs = new FileStream("Report.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(fs);

            string sline = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                lstReports.Text = sline;
                sline = reader.ReadLine();
            }
        }

    }
}
