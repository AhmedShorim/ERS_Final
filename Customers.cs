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
    public partial class Customers : Form
    {
        //public int Customer_ID{ get; set; }
        //public string Customer_Name { get; set; }

        //public int Mobile { get; set; }

        Customer_Model Model;
        Label Info;
        public Customers()
        {
            InitializeComponent();
            Info = new Label();
            Info.Hide();
            Info.Name = "Info";
            Info.TextChanged += Info_TextChanged;
            this.Controls.Add(Info);
          Model = new Customer_Model();
            int ID = Model.Current_ID();
            if (ID == -1)
            {
                MessageBox.Show("Failed to retrieve Data, Please contact system administrator");

            }
            else
            {
                id_txt.Text = ID.ToString();
            }
           
        }
 
       
        private void AddCustomer(object sender, EventArgs e)
        {

          int Val =   Model.AddCustomerModel(name_txt.Text, mobile_txt.Text);
           
            if(Val==-2)
            {
                MessageBox.Show("Mobile number must consist of 11 digit and starts with a zero.");
                return;
            }
            else if(Val==-1)
            {
                MessageBox.Show("Please Check the mobile number format.");
                return;
            }
            else if(Val ==0)
            {
                MessageBox.Show("Failed to Add Customer , Check if Mobile or ID is alreay used.");
            }
            else if(Val ==1)
            {
                 MessageBox.Show("Customer Created successfully");
            Customers C2 = new Customers();
            C2.Show();
            this.Close();
            }
           

        }

        private void EditCustomer(object sender, EventArgs e)
        {
            int suc =0;
            int ID =-1;
            try
            {
                 ID = Int32.Parse(id_txt.Text);
            }
            catch
            {
                MessageBox.Show("ID must be a number");
                return;
            }
                try
           {
               suc = Model.EditCustomerModel(ID, name_txt.Text, mobile_txt.Text);
           }
            catch
           {
                MessageBox.Show("Failed to edit customer please contact the system administrator");
                return;
            }
            if(suc ==-3)
            {
                 MessageBox.Show("ID must be a positive number");
                return;
            }
            else if(suc==-2)
            {
                MessageBox.Show("Mobile number must consist of 11 digits and start with zero");
                return;
            }
            else if(suc ==-1)
            {
                MessageBox.Show("Mobile number shouldn't contain any non numeric characters");
                return;
            }
            else if(suc ==0)
            {
                MessageBox.Show("Failed to update any entries , check if this ID exists and Mobile Number isn't already used.");
                return;
            }
            else if (suc ==1)
            {
                MessageBox.Show("Customer Edited successfully");
                
            Customers C2 = new Customers();
            C2.Show();
            this.Close();
                return;
            }


        }


       
        private void Search_Click(object sender, EventArgs e)
        {
            Search s = new Search("Customer");
            s.y = this;
            s.MdiParent = this.MdiParent;
            this.Hide();
            s.Show();
        }
        void Info_TextChanged(object sender, EventArgs e)
        {
            this.Show();
            string SID = Info.Text;
            string[] Data = new string[10];
            Model.SearchCustomerModel(SID, Data);

            id_txt.Text = Data[0];
            name_txt.Text = Data[1];
            mobile_txt.Text = "0"+Data[2];
            
        }
    }
}








//private void FormatValue(object sender, ConvertEventArgs cevent)
//{
//    // The method converts only to string type. Test this using the DesiredType.
//    if (cevent.DesiredType != typeof(string)) return;

//    if (  (int)cevent.Value == 0 )
//    {
//        cevent.Value = string.Empty;

//    }
//    else
//    {
//        Mobile = (int)cevent.Value;
//    }

//}




//private void DeleteCustomer(object sender, EventArgs e)
//{
//    if (Customer_ID < 0)
//    {
//        MessageBox.Show("ID must be a positive number");
//    }

//    SQLConnection.cmd.Parameters.Clear();
//    SQLConnection.cmd.CommandText = "Delete_Customer";
//    SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
//    SQLConnection.conn.Open();
//    SQLConnection.cmd.Parameters.AddWithValue("@ID", Customer_ID);
//    try
//    {
//        int rows = SQLConnection.cmd.ExecuteNonQuery();
//        if (rows > 0)
//        {
//            MessageBox.Show("Customer Deleted successfully");
//        }

//        else
//        {
//            MessageBox.Show("ID not found");
//            SQLConnection.conn.Close();
//            SQLConnection.cmd.Parameters.Clear();
//            return;
//        }
//    }
//    catch (Exception T)
//    {
//        MessageBox.Show(T.Message.ToString());
//        SQLConnection.conn.Close();
//        SQLConnection.cmd.Parameters.Clear();
//        return;
//    }
//    SQLConnection.conn.Close();
//    SQLConnection.cmd.Parameters.Clear();
//    Customers C2 = new Customers();
//    C2.Show();
//    this.Close();
//}