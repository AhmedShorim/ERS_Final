using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace ERS
{
    class Catering_Model
    {
        //public int ID { get; set; }
        //public string Description { get; set; }

        //public double Price { get; set; }
        //public double Cost { get; set; }

        //public int Stock { get; set; }
        
       

        public int Current_ID()
        {
            int ID;
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.cmd.CommandText = "SELECT IDENT_CURRENT('Catering') AS Current_Identity";
            SQLConnection.conn.Open();
             ID=Int32.Parse(SQLConnection.cmd.ExecuteScalar().ToString())+1;
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return ID;

        }


        public bool AddCateringModel(int ID, string Description,double Price,double Cost,int Stock)
        {
            bool success = false;
            SQLConnection.cmd.CommandText = "New_Catering";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@Name", Description);
            SQLConnection.cmd.Parameters.AddWithValue("@Cost", Cost);
            SQLConnection.cmd.Parameters.AddWithValue("@Price", Price);
            SQLConnection.cmd.Parameters.AddWithValue("@Stock", Stock);
            try{
               if( SQLConnection.cmd.ExecuteNonQuery() == 1) success = true;
                }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return false;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return success;

        }


        public bool EditCateringModel(int ID, string Description,double Price,double Cost,int Stock)
        {
            bool success = false;
            SQLConnection.cmd.CommandText = "Update_catering";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@Name", Description);
            SQLConnection.cmd.Parameters.AddWithValue("@Cost", Cost);
            SQLConnection.cmd.Parameters.AddWithValue("@Price", Price);
            SQLConnection.cmd.Parameters.AddWithValue("@Stock", Stock);
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (SQLConnection.cmd.ExecuteNonQuery() == 1) success = true;
            }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return false;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return success;
        }


        public bool DeleteCateringModel(int ID)
        {
            bool success = false;
            SQLConnection.cmd.CommandText = "Delete_catering";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (SQLConnection.cmd.ExecuteNonQuery() == 1) success = true;
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return success;
            }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return false;
            }

        }



        public void SearchCateringModel(string SID , string [] Data)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select F_ID, Name, Price , Cost,Stock from Catering where F_ID = " +SID;
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.reader = SQLConnection.cmd.ExecuteReader();
            SQLConnection.reader.Read();

            Data[0] = (Int32.Parse(SQLConnection.reader["F_ID"].ToString())).ToString();
           Data[1] = SQLConnection.reader["Name"].ToString();
            Data[2] = (Double.Parse(SQLConnection.reader["Price"].ToString())).ToString();
            Data[3] = (Double.Parse(SQLConnection.reader["Cost"].ToString())).ToString();
            Data[4] = (Int32.Parse(SQLConnection.reader["Stock"].ToString())).ToString();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.conn.Close();

        }
     }
}
