using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ERS
{
    public partial class Search : Form
    {
        Search_Model Model;
        public object y;

        public Search(String TableName)
        {
            InitializeComponent();
            Model = new Search_Model();

            bindingSource1 = new BindingSource();

            if (! (Model.GetDataSource(this, TableName)) )
            {
                MessageBox.Show("No data to show");
            }
        }

        public void SetBinding(SqlDataReader b)
        {
            bindingSource1.DataSource = b;

            dataGridView.ForeColor = Color.FromArgb(0, 0, 0, 0);
            dataGridView.DataSource = bindingSource1;

            try
            {
                dataGridView.Columns["Deleted"].Visible = false;
            }
            catch (Exception e) { }

            dataGridView.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Show();
            dataGridView.MultiSelect = false;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView.CurrentCell;
            int row = cell.RowIndex;

            ((Form)y).Focus();
            Label temp = (Label)((Form)y).Controls.Find("Info", true)[0];
            temp.Text = dataGridView.Rows[row].Cells[0].Value.ToString();

            this.Close();
        }
    }
}
