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
    public partial class Users : Form
    {


        private Users_Model Model;

        public Label Info;

        public Users()
        {
            InitializeComponent();
            Info = new Label();
            Info.Hide();
            Info.Name = "Info";
            Info.TextChanged += Info_TextChanged;
            this.Controls.Add(Info);
            Model = new Users_Model();
            type_txt.SelectedItem = null;
        }

        private void Info_TextChanged(object sender, EventArgs e)
        {
            this.Show();
            string SID = Info.Text;
            string[] Data = new string[10];
            Model.SearchUserModel(SID, Data);

            username_txt.Text = Data[0];
            password_txt.Text = Data[1];
            confirm_txt.Text = Data[1];
            type_txt.Text = Data[2];
            salary_txt.Text = Data[3];
            
        }



        private void AddUser(object sender, EventArgs e)
        {
            if(password_txt.Text=="" || username_txt.Text=="" || salary_txt.Text=="" || type_txt.Text=="")
            {
                MessageBox.Show("Some of the Required data was not provided, Please check the entered data");
                return;
            }
            if(password_txt.Text!=confirm_txt.Text)
            {
                MessageBox.Show("Error Passwords don't match !!");
                password_txt.Text = "";
                confirm_txt.Text = "";
                return;
            }
            if( ! (type_txt.Text=="User" || type_txt.Text=="Admin"))
            {
                MessageBox.Show("Please select a valid Account type");
                return;
            }
            try
            {
                double Sal = Double.Parse(salary_txt.Text);
                if (Sal <= 0) throw new System.ArgumentException("Parameter cannot be null", "original");            
            }
            catch
            {
                MessageBox.Show("Invalid Salary, Salary must be a positive Integer");
                return;
            }
                
                int T = Model.AddUserModel(username_txt.Text, password_txt.Text, type_txt.Text, Double.Parse(salary_txt.Text));
           
            if(T==-1)
            {
                MessageBox.Show("Failed to create user , Check if ID is not already used");
                return;
            }
            else if (T == 1)
            {
                MessageBox.Show("User Created successfully !");
                Users C2 = new Users();
                C2.Show();
                this.Close();
                return;
            }

        }


        private void DeleteUser(object sender, EventArgs e)
        {
            
            if(username_txt.Text=="" || password_txt.Text=="")
            {
                MessageBox.Show("Username or Password wasn't provided ,Please recheck them");
                return;
            }
            
         int Test = Model.DeleteUserModel(username_txt.Text, password_txt.Text);

            if(Test==-1  || Test==0)
            {
                MessageBox.Show("Failed to delete User, Check if user exists.");
                return;
            }
            else if (Test==1)
            {
                MessageBox.Show("User Deleted Successfully");
                Users C2 = new Users();
                C2.Show();
                this.Close();
                return; 
            }

        }


        private void Users_Load(object sender, EventArgs e)
        {

        }
        private void Search_Click(object sender, EventArgs e)
        {
            Search s = new Search("User");
            s.y = this;
            s.MdiParent = this.MdiParent;
            this.Hide();
            s.Show();
        }

        private void EditUser(object sender, EventArgs e)
        {
            if (password_txt.Text == "" || username_txt.Text == "" || salary_txt.Text == "" || type_txt.Text == "")
            {
                MessageBox.Show("Some of the Required data was not provided, Please check the entered data");
                return;
            }
            if (password_txt.Text != confirm_txt.Text)
            {
                MessageBox.Show("Error Passwords don't match !!");
                password_txt.Text = "";
                confirm_txt.Text = "";
                return;
            }
            if (!(type_txt.Text == "User" || type_txt.Text == "Admin"))
            {
                MessageBox.Show("Please select a valid Account type");
                return;
            }
            try
            {
                double Sal = Double.Parse(salary_txt.Text);
                if (Sal <= 0) throw new System.ArgumentException("Parameter cannot be null", "original");
            }
            catch
            {
                MessageBox.Show("Invalid Salary, Salary must be a positive Integer");
                return;
            }

            int T = Model.EditUserModel(username_txt.Text, password_txt.Text, type_txt.Text, Double.Parse(salary_txt.Text));

            if (T == -1 || T ==0)
            {
                MessageBox.Show("Failed to Edit user , Check if ID exists");
                return;
            }
            else if (T == 1)
            {
                MessageBox.Show("User Edited successfully !");
                Users C2 = new Users();
                C2.Show();
                this.Close();
                return;
            }
            
        
        }

    }
}
