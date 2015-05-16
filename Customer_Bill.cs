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
    public partial class Customer_Bill : Form
    {
        Customer_Bill_Model Model;

        public Customer_Bill()
        {
            InitializeComponent();

            Model = new Customer_Bill_Model();
        }

        private void custSearch_btn_Click(object sender, EventArgs e)
        {
            name_txt.Text = ""; //Clear Name TextBox

            if (number_txt.Text == "")
                MessageBox.Show("Please enter a customer number");
            else
            {
                String name = Model.GetCustomer(number_txt.Text); //Retreive Customer Name according to the mobile number

                if (name == "-1")
                    MessageBox.Show("Customer does not exist");
                else
                {
                    name_txt.Text = name;
                    resSearch_btn.Enabled = true;
                }
            }
        }

        private void resSearch_btn_Click(object sender, EventArgs e)
        {
            int ResNum = Model.GetResNum(number_txt.Text, date_combo.Text); //Get number of reservations ending on the specified date belonging to the searched customer

            if (ResNum == -1)
                MessageBox.Show("No reservations in this day");
            else
            {
                int y_pos = 25;

                rooms_grp.Size = new Size(282, 50*ResNum);

                for (int i = 0; i < ResNum; i++)
                {
                    //add a CheckBox for each reservation ending on the specified date belonging to the searched customer
                    RadioButton Res = new RadioButton();
                    Res.Location = new Point(12, y_pos);
                    Res.Size = new Size(200, 20);
                    Res.Text = Model.GetReservationDetails(i, number_txt.Text, date_combo.Text);
                    Res.ForeColor = Color.Black;
                    rooms_grp.Controls.Add(Res);

                    y_pos += 30;
                }

                if (ResNum > 4)
                    this.WindowState = FormWindowState.Maximized;

                print_btn.Enabled = true;
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            String choice = "";

            foreach(Control t in rooms_grp.Controls)  //Checking how many CheckBoxes is checked
            {
                if (t is RadioButton)
                {
                    if (((RadioButton)t).Checked)
                        choice = ((RadioButton)t).Text;
                }
            }

            if (choice == "")
                MessageBox.Show("Please choose room(s) to bill customer for");
            else
            {
                String user = "";

                foreach (Form form in Application.OpenForms)
                {
                    if (((Form)form).Name == "MainScreen")
                        user = ((MainScreen)form).username;
                }

                Model.Print(user, date_combo.Text, choice, name_txt.Text, number_txt.Text);
            }
        }

        private void number_txt_TextChanged(object sender, EventArgs e)
        {
            name_txt.Text = ""; //Clear Name TextBox
            resSearch_btn.Enabled = false;
        }
    }
}