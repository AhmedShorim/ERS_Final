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
    public partial class Revenue_Report : Form
    {
        Revenue_Report_Model Model;

        public Revenue_Report()
        {
            InitializeComponent();

            Model = new Revenue_Report_Model();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            String user = "";

            foreach (Form form in Application.OpenForms)
            {
                if (((Form)form).Name == "MainScreen")
                    user = ((MainScreen)form).username;
            }

            if (!Model.Print(user, from_date.Text, to_date.Text))
                MessageBox.Show("Empty Results");
        }
    }
}
