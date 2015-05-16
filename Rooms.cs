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
    public partial class Rooms : Form
    {
     //   public int ID { get; set; }

       // public string Description { get; set; }

    //    public double Price { get; set; }

        public Label Info { get; set; }
        RoomModel Model;

        public Rooms()
        {
            InitializeComponent();
            Info = new Label();
            Info.Hide();
            Info.Name = "Info";
            Info.TextChanged += Info_TextChanged;
            this.Controls.Add(Info);
            Model = new RoomModel();
           // id_txt.DataBindings.Add("Text", this, "ID");
            //description_txt.DataBindings.Add("Text", this, "Description");
          //  price_Txt.DataBindings.Add("Text", this, "Price");
        }
        void AddRoom(object sender, EventArgs e)
        {
            double Price;
            int ID;
            int suc;
            try
            {
                Price = double.Parse(price_Txt.Text);
            }
            catch(Exception X)
            {
                MessageBox.Show("Price must be a decimal number remove any characters.");
                return;
            }
            if(Price<=0)
            {
                MessageBox.Show("Price Can't be equal to or smaller than zero.");
                return;
            }

            try
            {
                ID = Int32.Parse(id_txt.Text);

            }
            catch
            {
                MessageBox.Show("ID must be a number remove any characters.");
                return;
            }

            if(ID<1)
            {
                MessageBox.Show("Error ID of room must be a positive number !");
                return;
            }
            suc = Model.AddRoomModel(ID, description_txt.Text, Price);
            
            if(suc ==-1)
            {
                MessageBox.Show("Error Couldn't Add entry to the database check if this ID isn't alredy used or was used with a deleted room");
                return;
            }
            else if(suc ==0)
            {
                MessageBox.Show("Unknown Error ,Failed to insert in database , Please contact you System Admin");
                return;
            }
            else if (suc==1)
            {
                MessageBox.Show("Room Created successfully");
                Rooms R = new Rooms();
                R.Show();
                this.Close();
            }
            
          
           
        }


        private void Rooms_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search s = new Search("Room");
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
            Model.SearchRoom(SID, Data);
            id_txt.Text = Data[0];
            description_txt.Text = Data[1];
            price_Txt.Text = Data[2];
            return;
        }

        private void EditRoom(object sender, EventArgs e)
        {
            double Price;
            int ID;
            int suc;
            try
            {
                Price = double.Parse(price_Txt.Text);
            }
            catch (Exception X)
            {
                MessageBox.Show("Price must be a decimal number remove any characters.");
                return;
            }
            if (Price <= 0)
            {
                MessageBox.Show("Price Can't be equal to or smaller than zero.");
                return;
            }

            try
            {
                ID = Int32.Parse(id_txt.Text);

            }
            catch
            {
                MessageBox.Show("ID must be a number remove any characters.");
                return;
            }

            if (ID < 1)
            {
                MessageBox.Show("Error ID of room must be a positive number !");
                return;
            }

            suc = Model.EditRoom(ID, description_txt.Text, Price);
            if(suc==-1)
            {
                MessageBox.Show("Room ID is not Found, Create Using New Button if needed");
                return;
            }
            else if(suc==-2)
            {
                MessageBox.Show("Failed to Edit Entry, Please contact the System Admin");
                return;
            }

            else if (suc==0)
            {
                MessageBox.Show("Entry updated successfully");
                return;
            }
           
        }

        private void DeleteRoom(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("If the room is deleted this ID will not  be usable for any other rooms , Use Edit if you want to edit a details.            Are you sure you want to delete this room ? ", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            int ID;
            try
            {
                ID = Int32.Parse(id_txt.Text);

            }
            catch
            {
                MessageBox.Show("ID must be a number remove any characters.");
                return;
            }

            if (ID < 1)
            {
                MessageBox.Show("Error ID of room must be a positive number !");
                return;
            }

          int suc =  Model.DeleteRoom(ID);

                if(suc == -1 )
                {
                    MessageBox.Show("Error Can't Delete room before printing its corresponding reports.");
                    return;
                }
                
                

        else if (suc == 1)
                   {
            MessageBox.Show("Room Deleted successfully");
            return;
                    }

                else if (suc ==0)
                {
                    MessageBox.Show("Room Coudln't be Found");
                    return;
                }

        }

       
    }
}