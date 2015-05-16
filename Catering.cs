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
    public partial class Catering : Form
    {
        Catering_Model Model = new Catering_Model();
        Label Info;
        public Catering()
        {

            InitializeComponent();
            id_txt.Text = (Model.Current_ID()).ToString();
            Info = new Label();
            Info.Hide();
            Info.Name = "Info";
            Info.TextChanged += Info_TextChanged;
            this.Controls.Add(Info);

            //;
            //description_txt.DataBindings.Add("Text", this, "Description");
            //price_txt.DataBindings.Add("Text",this,"Price");
            //cost_txt.DataBindings.Add("Text", this, "Cost");
            //stock_txt.DataBindings.Add("Text", this, "Stock");
        }

      

       
        private void AddCatering(object sender, EventArgs e)
        {
            bool success = false;

            try
            {
               success =  Model.AddCateringModel(Int32.Parse(id_txt.Text), description_txt.Text, Double.Parse(price_txt.Text), Double.Parse(cost_txt.Text), Int32.Parse(stock_txt.Text));
            }
            catch
            {
                MessageBox.Show("Check Data Entered Format");
                return;
            }
            if (success)
            {
                MessageBox.Show("Catering Added successfully");
                Catering two = new Catering();
                this.Close();
                two.Show();
            }
            else
            {
                MessageBox.Show("Failed to insert catering , Check if ID already used or was used with a deleted Product");
            }
            
        }

       
        private void EditCatering(object sender, EventArgs e)
        {
            bool success = false;

            try
            {
                success = Model.EditCateringModel(Int32.Parse(id_txt.Text), description_txt.Text, Double.Parse(price_txt.Text), Double.Parse(cost_txt.Text), Int32.Parse(stock_txt.Text));
            }
            catch
            {
                MessageBox.Show("Check Data Entered Format");
                return;
            }
            if (success)
            {
                MessageBox.Show("Catering Edited successfully");
                Catering two = new Catering();
                this.Close();
                two.Show();
            }
            else
            {
                MessageBox.Show("Failed to insert catering , Check if ID exists and Price is greater than Cost");
            }
            
        }
       
        private void DeleteCatering(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("If the Catering is deleted this ID will not  be usable for any other products , Use Edit if you want to edit a details.            Are you sure you want to delete this room ? ", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            bool success = false;
            try
            {
                success = Model.DeleteCateringModel(Int32.Parse(id_txt.Text));
            }
            catch
            {
                MessageBox.Show("Check Data Entered Format");
                return;
            }
            if (success)
            {
                MessageBox.Show("Catering Deleted successfully");
                Catering two = new Catering();
                this.Close();
                two.Show();
            }
            else
            {
                MessageBox.Show("Failed to Delete catering , Check if ID exists");
            }
            

        }

        private void Search_Catering(object sender, EventArgs e)
        {
            Search s = new Search("Catering");
            s.y = this;
            s.MdiParent = this.MdiParent;
            this.Hide();
            s.Show();
        }

        void Info_TextChanged(object sender, EventArgs e)
        {
            this.Show();
            string SID = Info.Text;
            string [] Data = new string[10];
            Model.SearchCateringModel(SID,Data);

            id_txt.Text = Data[0];
            description_txt.Text = Data[1];
            price_txt.Text = Data[2];
            cost_txt.Text =Data[3];
            stock_txt.Text = Data[4];
        }

        
    }   
}
