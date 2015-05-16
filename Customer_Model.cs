using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ERS
{
    class Customer_Model
    {
        public int Current_ID()
        {
            int ID;
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "SELECT IDENT_CURRENT('Customer') AS Current_Identity";
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.conn.Open();
            try
            {
               ID = Int32.Parse(SQLConnection.cmd.ExecuteScalar().ToString()) + 1;
            }
            catch(Exception E)
            {
                return -1;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return ID;

        }
        public int AddCustomerModel(string Name,string Mobile)
        {
            double Mob;
            int success = 0;
            if (Mobile.Length < 11 || Mobile[0]!='0')
            {
                return -2;
            }
            try
            {
                Mob = Double.Parse(Mobile);
            }
            catch
            {
                return -1;
            }
            
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "New_Customer";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@Name", Name);
            SQLConnection.cmd.Parameters.AddWithValue("@Mobile", Mob);
            try
           {
              success =  SQLConnection.cmd.ExecuteNonQuery();
                SQLConnection.conn.Close();
               SQLConnection.cmd.Parameters.Clear();
               return success;
           }
            catch
            {
                SQLConnection.conn.Close();
               SQLConnection.cmd.Parameters.Clear();
               return 0;
            }

        }


        public int EditCustomerModel(int ID,string Name,string Mobile)
        {
            double Mob;
            int success = 0;
            if (Mobile.Length < 11 || Mobile[0] != '0')
            {
                return -2;
            }
            if (ID < 0)
            {

                return -3;

            }
            try
            {
                Mob = Double.Parse(Mobile);
            }
            catch
            {
                return -1;
            }

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Edit_customer";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@New_Name", Name);
            SQLConnection.cmd.Parameters.AddWithValue("@New_Mobile", Mob);
            SQLConnection.cmd.Parameters.AddWithValue("@ID",ID);

            try
            {
              success = SQLConnection.cmd.ExecuteNonQuery();
              SQLConnection.conn.Close();
              SQLConnection.cmd.Parameters.Clear();
              return success;
            }
            catch
            {
              SQLConnection.conn.Close();
              SQLConnection.cmd.Parameters.Clear();
              return success;
            }

        }

        public void SearchCustomerModel(string SID, string[] Data)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select C_ID, Name, Mobile from Customer where C_ID = " + SID;
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.reader = SQLConnection.cmd.ExecuteReader();
            SQLConnection.reader.Read();

            Data[0] = (Int32.Parse(SQLConnection.reader["C_ID"].ToString())).ToString();
            Data[1] = SQLConnection.reader["Name"].ToString();
            Data[2] = (Double.Parse(SQLConnection.reader["Mobile"].ToString())).ToString();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.conn.Close();

        }
    }
}
