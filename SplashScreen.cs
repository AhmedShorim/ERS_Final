using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERS
{
    public partial class SplashScreen : Form
    {
        int time;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time = time - 1;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            time = 2;
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}
