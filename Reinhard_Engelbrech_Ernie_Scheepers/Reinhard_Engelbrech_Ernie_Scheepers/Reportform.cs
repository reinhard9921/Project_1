using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reinhard_Engelbrech_Ernie_Scheepers
{
    public partial class Reportform : Form
    {
        public Reportform()
        {
            InitializeComponent();
        }

        public Reportform(string sReport)
        {
            InitializeComponent();

            richTextBox1.Text = sReport;

        }

        private void Reportform_Load(object sender, EventArgs e)
        {

        }
    }
}
