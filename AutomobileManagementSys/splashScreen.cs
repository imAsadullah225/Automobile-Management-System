using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomobileManagementSys
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        multiForms mltfrm = new multiForms();
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            ProgressBar.Value += 2;
            CircleProgressbar.Value += 2;

            if (ProgressBar.Value >= 100)
            {
                ProgressTimer.Stop();
                this.Hide();
                mltfrm.Closed += (s, args) => this.Close();
                mltfrm.Show();
            }
            
        }
    }
}
