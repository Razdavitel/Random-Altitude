using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace randomAltitude
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rbFlat.Checked = true;
        }
        //global
        bool timerRunning = false;
        int baseAlt = 0;
        Random rand = new Random();
        private void btnStart_Click(object sender, EventArgs e)
        {           
            //altitude
            if (txtBaseAlt.Text == "" || txtBaseAlt.Text == null)
                MessageBox.Show("Textbox requires value.", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                baseAlt = int.Parse(txtBaseAlt.Text);
                txtBaseAlt.Enabled = false;
                btnStart.Enabled = false;
                timerRunning = true;
                timer1.Start();   
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        { //all done
            txtBaseAlt.Enabled = true;
            btnStart.Enabled = true;
            txtBaseAlt.Clear();
            lblAlt.Text = "0";
            timer1.Stop();
            timerRunning = false;
        }
        public void refreshAltitude(int baseAlt)
        {//all done
            int altitude = 0;
            int deviation = 0;
            if (rbFlat.Checked == true)
                deviation = rand.Next(1, 10);
            if (rbMedium.Checked == true)
                deviation = rand.Next(1, 15);
            if (rbHigh.Checked == true)
                deviation = rand.Next(1, 25);
            altitude = rand.Next(baseAlt, baseAlt+deviation);
            lblAlt.Text = altitude.ToString();
            //return altitude;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerRunning == true) { 
            refreshAltitude(baseAlt);
                int randTime = rand.Next(1000, 2000);
                timer1.Interval = randTime;
                timer1.Start();
            }
        }
    }
}
