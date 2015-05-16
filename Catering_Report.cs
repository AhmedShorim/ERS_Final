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
    public partial class Catering_Report : Form
    {
        Catering_Report_Model Model;

        public Catering_Report()
        {
            InitializeComponent();

            Model = new Catering_Report_Model();

            SetItems_ComboBox(Model.LoadItems());

            items_combo.Enabled = false;
        }

        public void SetItems_ComboBox(DataSet d)
        {
            items_combo.DataSource = d.Tables[0];
            items_combo.ValueMember = "F_ID";
            items_combo.DisplayMember = "Name";
            items_combo.SelectedItem = null;
            items_combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (oneitem_radio.Checked)
            {
                if (items_combo.Text == "")
                    MessageBox.Show("Please choose an item first");
                else
                {
                    String user = "";

                    foreach (Form form in Application.OpenForms)
                    {
                        if (((Form)form).Name == "MainScreen")
                            user = ((MainScreen)form).username;
                    }

                    if (!Model.PrintOne(user, items_combo.SelectedValue.ToString(), items_combo.Text, from_date.Text, to_date.Text))
                        MessageBox.Show("Empty Results");
                }
            }
            else if (allitems_radio.Checked)
            {
                String user = "";

                foreach (Form form in Application.OpenForms)
                {
                    if (((Form)form).Name == "MainScreen")
                        user = ((MainScreen)form).username;
                }

                if (!Model.PrintAll(user, from_date.Text, to_date.Text))
                    MessageBox.Show("Empty Results");
            }
        }

        private void oneitem_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (oneitem_radio.Checked)
                items_combo.Enabled = true;
            else
                items_combo.Enabled = false;
        }
    }
}
