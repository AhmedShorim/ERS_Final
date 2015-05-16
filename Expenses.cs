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
    public partial class Expenses : Form
    {
        Expenses_Model Model;
        public Expenses()
        {
            InitializeComponent();
            Model = new Expenses_Model();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Expense.Text=="" || Cost.Text=="")
            {
                MessageBox.Show("Some Data is missing , Please recheck entered data");
                return;
            }
            double price = 0;

            try
            {
                price = Double.Parse(Cost.Text);
                if (price <= 0) throw new System.ArgumentException("Parameter cannot be null", "original");
            }
            catch
            {
                MessageBox.Show("Cost must be a positive integer.");
                    return;
            }

            int T =Model.SubmitExpense(Expense.Text, price, dateTimePicker1.Value);
            if(T==-1 || T==0)
            {
                MessageBox.Show("Failed in inset current expense");
                return;
            }
            else
            {
                MessageBox.Show("Expense inserted successfully.");
                return;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
