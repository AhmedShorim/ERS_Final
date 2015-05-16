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
    public partial class MainScreen : Form
    {
        private string user;
        public string username;
        public MainScreen(string current,string username)
        {
            InitializeComponent();
            this.user = current;
            this.username = username;
            this.LabelType.Text = username;
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            cust.MdiParent = this;
            cust.Show();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(user!="Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }

            Rooms r = new Rooms();
            r.MdiParent = this;
            r.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != "Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }
            Users u = new Users();
            u.MdiParent = this;
            u.Show();
        }

        private void cateringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != "Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }
            Catering c = new Catering();
            c.MdiParent = this;
            c.Show();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservations res = new Reservations();
            res.MdiParent = this;
            res.Show();
        }

        private void roomsStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms_Status rs = new Rooms_Status();
            rs.MdiParent = this;
            rs.Show();
        }

        private void customerBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Bill cb = new Customer_Bill();
            cb.MdiParent = this;
            cb.Show();
        }

        private void roomsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != "Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }
            Rooms_Report rr = new Rooms_Report();
            rr.MdiParent = this;
            rr.Show();
        }

        private void cateringReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != "Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }
            Catering_Report catrep = new Catering_Report();
            catrep.MdiParent = this;
            catrep.Show();
        }

        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != "Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }
            Revenue_Report rev = new Revenue_Report();
            rev.MdiParent = this;
            rev.Show();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login Main = new Login();
            Main.Show();
            this.Hide();
        }

        private void Expenses(object sender, EventArgs e)
        {
            if (user != "Admin")
            {
                MessageBox.Show("Current operation is not permitted for your account");
                return;
            }
            Expenses rev = new Expenses();
            rev.MdiParent = this;
            
            rev.Show();
        }
    }
}
