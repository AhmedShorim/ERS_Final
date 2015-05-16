using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Sql;
//using System.Data.SqlTypes;
using System.Windows.Forms;

namespace ERS
{
    public partial class Reservations : Form
    {
        //public int ID { get; set; }

        //public int Customer_ID { get; set; }

        //public int Room_ID { get; set; }

        //public string Start_Time { get; set; }

        //public string End_Time { get; set; }

        int CustomerID;
        int ReservationID=-1;
         Reservations_Model Model;
        
        public Reservations()
        {
            InitializeComponent();
            Model = new Reservations_Model();
            SetComboBox(Model.FillBox());
            CustomerID = -1;
            Duration.SelectedItem = null;
            Duration.DropDownStyle = ComboBoxStyle.DropDownList;
            room_combobox.SelectedIndexChanged += new EventHandler(Room_Changed);
            Duration.SelectedIndexChanged += new EventHandler(Duration_Changed);


            dataGridView1.ForeColor = Color.Black;
            dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill; ;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            

            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "Product";
            //cmb.Name = "Name";
            //cmb.MaxDropDownItems = 10;
            //cmb.Items.Add("Molto");
            //cmb.Items.Add("Hohos");
            //dataGridView1.Columns.Add(cmb);



            //dataGridView1.ColumnCount+=1;
            //dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name = "Price";
            //dataGridView1.Columns[dataGridView1.ColumnCount - 1].ReadOnly = true;

            
            //DataGridViewComboBoxColumn cmb2 = new DataGridViewComboBoxColumn();
            //cmb2.HeaderText = "Quantity";
            //cmb2.Name = "Quantity";
            //cmb2.MaxDropDownItems = 10;
            //for(int i=0;i<10;i++)
            //{
            //    string t = i.ToString();
            //    cmb2.Items.Add(t);
            //}

           
            //dataGridView1.Columns.Add(cmb2);



        }

        private void Duration_Changed(object sender, EventArgs e)
        {
            double hours;
            double minutes;
            try
            {
                string hourT = start_txt.Text.Substring(0, 2);
                string MinuteT = start_txt.Text.Substring(3, 2);
                 hours = double.Parse(hourT);
                 minutes = double.Parse(MinuteT);
                Exception E = new Exception();
                if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59) throw  E;
            }
            catch
            {
                MessageBox.Show("Please enter the start time in the correct format.");
                Duration.SelectedItem = null;
                return;
            }
            double dur = 0;
            double min = 0;
            switch (Duration.SelectedIndex)
            {
                case 0:
                    dur = 0;
                    min = 30;
                    break;

                case 1:
                    dur = 1;
                    break;

                case 2:
                    dur = 1;
                    min = 30;
                    break;

                case 3:
                    dur = 2;

                    break;

                default:
                    break;
            }

            hours += dur;
            minutes += min;

            if (minutes > 59)
            {
                hours++;
                minutes -= 60;
            }
            
            
            
            
            if (hours > 23) hours -= 24;
            
            if(hours < 10)
            {
                 end_txt.Text="0"+hours.ToString()+":";
            }
            else
            {
                end_txt.Text = hours.ToString()+":";
            }
            if (minutes<10)
            {
                end_txt.Text = end_txt.Text + "0" + minutes.ToString();
            }
            else
            {
                end_txt.Text = end_txt.Text + minutes.ToString();
            }

          
        }
        public void SetComboBox(DataSet ds)
        {
            room_combobox.DataSource = ds.Tables[0];
            room_combobox.ValueMember = "R_ID";
            room_combobox.DisplayMember = "R_ID";
            room_combobox.SelectedItem = null;
            room_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
           
        }



        void AddReservation(object sender, EventArgs e)
        {

            int R_ID, C_ID;
            if(CustomerID==-1 || custName_txt.Text=="")
            {
                MessageBox.Show("Please choose a customer first by adding their mobile number and clicking search.");
                return;
            }
            C_ID = CustomerID;
            try
            {
                R_ID = Int32.Parse(room_combobox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid room selection.");
                return;
            }
            
           

            if (start_txt.Text == "")
            {
                MessageBox.Show("Please enter a start time for this reservation");
                return;
            }


            int suc = Model.AddReservationModel(C_ID, R_ID, start_txt.Text, end_txt.Text, room_status.Text);


            if (suc==-1)
            {
                MessageBox.Show("Start Time Format is incorrect , Please check");
                return;
            }
           

            else if(suc==-2)
            {
                MessageBox.Show("Incorrect End time please insert in format of HH:MM ");
                return;
            }
            else if (suc==-3)
            {

                MessageBox.Show("End Time can't be entered before the customer finish , Please set it later");
                MessageBox.Show("This reservation will be saved with empty End Time, please set it when customer finish");
                Reservations R = new Reservations();
                R.Show();
                this.Close();
                return;
            }
            else if (suc==-4)
            {
                 MessageBox.Show("End Time Can't be equal or less than  Start Time");
                 return;
            }
            else if(suc==-5)
            {
                MessageBox.Show("Unknow Error , Please Contact your System Administrator , Check if room is not already used");
                return;
            }
            else if (suc == -6)
            {
                MessageBox.Show("Start Time Can't be  more than  Current Time.");
                return;
            }
            else if( suc ==-8)
            {
                MessageBox.Show("End Time Can't be  less than  Current Time.");
                return;
            }
            else if (suc == -9)
            {
                MessageBox.Show("Reservation is already saved");
                return;
            }
            else if(suc==1)
            {
                MessageBox.Show("Reservation created successfully");
                Reservations R = new Reservations();
                R.Show();
                this.Close();
                return;
            }
            else if(suc==2)
            {
                MessageBox.Show("Reservation Saved successfully");
                Reservations R = new Reservations();
                R.Show();
                this.Close();
                return;
            }

            
        }
        
        
        
        private void Room_Changed(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = null;
            CustomerID = -1;
            ReservationID = -1;
            DataSet ds = Model.ChangeRoomModel(room_combobox.Text);

            if (ds.Tables[0].Rows.Count == 0)
            {
                room_status.Text = "Room is Empty";
                custName_txt.Text = "";
                start_txt.Text = "";
                end_txt.Text = ""; 
                custNum_txt.Text = "";
                dataGridView1.DataSource = null;
            }
            else
            {
                room_status.Text = "Room is Full";
                CustomerID =(int) ds.Tables[0].Rows[0][0];
                DateTime Strt = (DateTime)ds.Tables[0].Rows[0][1];
                ReservationID = Int16.Parse(ds.Tables[0].Rows[0][2].ToString());
                start_txt.Text = Strt.TimeOfDay.ToString();
                start_txt.Text = start_txt.Text.Remove(start_txt.Text.Length - 3);
                  DataSet ds2=   Model.GetCustomerDataModel(CustomerID);
                custName_txt.Text = (string)ds2.Tables[0].Rows[0][0];
                custNum_txt.Text = ds2.Tables[0].Rows[0][1].ToString();
                
                DataSet ds3 = Model.CateringUsed(ReservationID);
               if(ds3.Tables.Count==0)
               {

                   dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(Trial);

                   dataGridView1.Columns.Add("Name", "Name");
                   dataGridView1.Columns.Add("Price", "Price");
                   dataGridView1.Columns.Add("Quantity", "Quantity");
                   dataGridView1.Rows.Add();

                   DataGridViewComboBoxCell combocatering = new DataGridViewComboBoxCell();
                   DataSet ds6 = Model.AvailableCateringName();
                   combocatering.DataSource = ds6.Tables[0];
                   combocatering.ValueMember = "Name";
                   combocatering.Value = "";
                   dataGridView1.Rows[0].Cells[0] = combocatering;
                   

                   DataGridViewComboBoxCell combocatering2 = new DataGridViewComboBoxCell();
                   for (int i = 1; i < 11; i++)
                   {
                       combocatering2.Items.Add(i.ToString());
                   }
                   combocatering2.Value = "";
                   dataGridView1.Rows[0].Cells[2] = combocatering2;
                   return;
               }
 
                if(dataGridView1.Columns.Count!=0)
                {
                    for (int i = dataGridView1.Columns.Count-1; i >= 0; i--)
                    {
                        dataGridView1.Columns.RemoveAt(i);
                    }
                }
                dataGridView1.DataSource = ds3.Tables[0];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
			   dataGridView1.Rows[i].ReadOnly = true;
			}
               
              

                DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();

              DataSet ds4 = Model.AvailableCateringName();
 
              cmb.DataSource = ds4.Tables[0];
              cmb.ValueMember = "Name";

              cmb.Value = "";
                dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0] = cmb;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].ReadOnly = false;
                


                DataGridViewComboBoxCell cmb2 = new DataGridViewComboBoxCell();
                for (int i = 1; i < 11; i++)
                {
                    cmb2.Items.Add(i.ToString());
                }
                cmb2.Value = "";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2] = cmb2;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].ReadOnly = false;
                dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(Trial);

                //dataGridView1.AllowUserToAddRows = false;
            }
            return;
        }

        private void Trial(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;

            if(cell.ColumnIndex==0)
            {
                if (dataGridView1.Rows[cell.RowIndex].Cells[2].Value.ToString()=="") 
                    dataGridView1.AllowUserToAddRows = false;

                decimal price = Model.GetCateringPrice(cell.Value.ToString());
                dataGridView1.Rows[cell.RowIndex].Cells[1].Value = price;
            }
            else if(cell.ColumnIndex==2)
            {
              
                if ( dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() == "")
                {
                 //   cell.Value = null;
                    if(cell.Value!="")MessageBox.Show("Please choose a product first then the quantity.");
                   // DataGridViewComboBoxCell T = cell as DataGridViewComboBoxCell;
                  //  T.Value = "";
                   
                    cell.Value = "";
                   
                    return;
                }

               int suc =  Model.NewCatering(ReservationID, dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString(), int.Parse(cell.Value.ToString()));
                if(suc >=1 )
                {
                    MessageBox.Show("Catering Added successfully");
                    object S = new object();
                    EventArgs EV = new EventArgs();
                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.DataSource = null;
                     Room_Changed(S,EV);
                    return;
                }
                else if(suc ==-1)
                {
                    MessageBox.Show("Quantity is larger than stock");
                    dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(Trial);
                    cell.Value = "";
                    dataGridView1.Rows[cell.RowIndex].Cells[0].Value = "";
                    dataGridView1.Rows[cell.RowIndex].Cells[1].Value = 0;
                    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(Trial);
                   
                    return;
                }
                else
                {
                    MessageBox.Show("Failed to Add Catering");
                    return;
                }
            }
        }

        private void Customer_Search(object sender, EventArgs e)
        {
            double test;
            try
            {

                 test = Double.Parse(custNum_txt.Text);
            }
            catch (Exception X)
            {
                MessageBox.Show("Please enter a valid phone number");
                return;
            }

            DataSet ds = new DataSet();
            ds = Model.CustomerSearch(test);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Customer Not Found.");
                return;
            }
           
            else if(ds==null)
            {
                MessageBox.Show("Unknow Error Please Contact the System Administrator.");
                return;
            }
            else
            {
                CustomerID = (int)ds.Tables[0].Rows[0][0];
                custName_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }


            
        }

        private void Time_now_Click(object sender, EventArgs e)
        {

            start_txt.Text = DateTime.Now.ToString("HH:mm");

        }


    }
}