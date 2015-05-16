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
    public partial class Rooms_Report : Form
    {
        Rooms_Report_Model Model;
        
        public Rooms_Report()
        {
            InitializeComponent();

            Model = new Rooms_Report_Model();

            SetRooms_ComboBox(Model.LoadRooms());

            rooms_combo.Enabled = false;
        }

        public void SetRooms_ComboBox(DataSet d)
        {
            rooms_combo.DataSource = d.Tables[0];
            rooms_combo.ValueMember = "R_ID";
            rooms_combo.DisplayMember = "R_ID";
            rooms_combo.SelectedItem = null;
            rooms_combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (oneroom_radio.Checked)
            {
                if (rooms_combo.Text == "")
                    MessageBox.Show("Please choose a room first");
                else
                {
                    String user = "";

                    foreach (Form form in Application.OpenForms)
                    {
                        if (((Form)form).Name == "MainScreen")
                            user = ((MainScreen)form).username;
                    }

                    if (!Model.Print_One(user, rooms_combo.Text, from_date.Text, to_date.Text))
                        MessageBox.Show("Empty Results");
                }
            }
            else if (allrooms_radio.Checked)
            {
                String user = "";

                foreach (Form form in Application.OpenForms)
                {
                    if (((Form)form).Name == "MainScreen")
                        user = ((MainScreen)form).username;
                }

                if (!Model.Print_ALL(user, from_date.Text, to_date.Text))
                    MessageBox.Show("Empty Results");
            }
        }

        private void oneroom_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (oneroom_radio.Checked)
                rooms_combo.Enabled = true;
            else
                rooms_combo.Enabled = false;
        }
    }
}
