using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ERS
{
    class RoomModel
    {
        public int AddRoomModel(int ID,string Description,double price)
        {
            int suc;
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Create_Room";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@DISC", Description);
            SQLConnection.cmd.Parameters.AddWithValue("@Price", price);

  
            try
            {
              suc =   SQLConnection.cmd.ExecuteNonQuery();
            }
            catch (Exception X)
            {
                SQLConnection.cmd.Parameters.Clear();
                SQLConnection.conn.Close();
                return -1;
            }
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.conn.Close();
            return suc;

        }

        public void SearchRoom( string ID , string [] Data)
        {

            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID, Disc, Price from Room where R_ID = " + ID;
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.reader = SQLConnection.cmd.ExecuteReader();
            SQLConnection.reader.Read();
            Data[0] = SQLConnection.reader["R_ID"].ToString();
            Data[1] = SQLConnection.reader["Disc"].ToString();
            Data[2] = SQLConnection.reader["Price"].ToString();
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
        }

        public int EditRoom(int ID,string Description,double price)
        {
            int rows;
            SQLConnection.cmd.CommandText = "Edit_Room";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@DISC", Description);
            SQLConnection.cmd.Parameters.AddWithValue("@Price", price);
            try
            {


               rows = SQLConnection.cmd.ExecuteNonQuery();
            }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return -2;
            }
                if (rows < 1)
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return -1;
            }
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return 0;
            
        }

        public int DeleteRoom(int ID)
        {
            int rows;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Delete_Room";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                rows = SQLConnection.cmd.ExecuteNonQuery();

            }
            catch
            {
                SQLConnection.cmd.Parameters.Clear();
                SQLConnection.conn.Close();
                    return -1;
            }
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.conn.Close();
            SQLConnection.conn.Close();
            return rows;
        }
    }
}
