using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ERS
{
    class Rooms_Status_Model
    {
        public int GetNumberOfRooms()
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select Count(R_ID) from Reservation where EndTime IS NULL";
            SQLConnection.cmd.CommandType = CommandType.Text;

            int temp = int.Parse(SQLConnection.cmd.ExecuteScalar().ToString());

            SQLConnection.conn.Close();

            return temp;
        }

        public String GetRoomName(int i)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID from Reservation where EndTime IS NULL";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(SQLConnection.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String RoomName = dt.Rows[i]["R_ID"].ToString();

            SQLConnection.conn.Close();

            return RoomName;
        }

        public String GetRoomDesc(String ID)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select Disc from Room where R_ID = " + ID;
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(SQLConnection.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String RoomDesc = dt.Rows[0]["Disc"].ToString();

            SQLConnection.conn.Close();

            return RoomDesc;
        }

        public String GetStartTime(int i)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select cast(StartTime as Time) from Reservation where EndTime IS NULL";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(SQLConnection.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String time = dt.Rows[i][0].ToString();

            SQLConnection.conn.Close();

            return time;
        }

        public String Calc_ReservationLength(int i)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select CAST((GETDATE()-Reservation.StartTime) as time(0)) as ResLength from Reservation where EndTime is NULL";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(SQLConnection.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String time = dt.Rows[i][0].ToString();

            SQLConnection.conn.Close();

            return time;
        }

        public List<String> GetEmptyRooms()
        {
            List<String> temp = new List<string>();

            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID from Room Except Select R_ID from Reservation where EndTime is NULL";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(SQLConnection.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SQLConnection.cmd.Parameters.Clear();
                SQLConnection.cmd.CommandText = "Select Disc from Room where R_ID = " + dt.Rows[i][0].ToString();
                SQLConnection.cmd.CommandType = CommandType.Text;
                temp.Add("Room: " + dt.Rows[i][0].ToString() + "                       Description: " + (String)SQLConnection.cmd.ExecuteScalar());
            }

            SQLConnection.conn.Close();

            return temp;
        }
    }
}