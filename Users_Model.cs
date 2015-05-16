using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ERS
{
    class Users_Model
    {
        public void SearchUserModel(string UID, string[] Data)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select  PW, type , Salary from [User] where U_ID = '" + UID+"'";
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.reader = SQLConnection.cmd.ExecuteReader();
            SQLConnection.reader.Read();

            Data[0] = UID;
            Data[1] = SQLConnection.reader["PW"].ToString();
            Data[2] = SQLConnection.reader["type"].ToString();
            Data[3] = SQLConnection.reader["Salary"].ToString();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.conn.Close();

        }


        public int AddUserModel(string ID, string password ,string type ,double Salary)
        {
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Create_User";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@PW", password);
            SQLConnection.cmd.Parameters.AddWithValue("@Type", type);
            SQLConnection.cmd.Parameters.AddWithValue("@Salary", Salary);
         try
         { 
            SQLConnection.cmd.ExecuteNonQuery();
         }
            catch
         {
             SQLConnection.conn.Close();
             SQLConnection.cmd.Parameters.Clear();
             return -1;
         }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return 1;

        }

        public int DeleteUserModel(string ID,string PW)
        {
            int Del = 0;
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Delete_User";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@PW", PW);
            try{
                 Del = SQLConnection.cmd.ExecuteNonQuery();
               }
            catch
            {
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
                return -1; 
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return Del ;
            
        }

        public int EditUserModel(string ID, string password ,string type ,double Salary)
        {
            int Tes = 0;
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Edit_User";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@U_ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@Password", password);
            SQLConnection.cmd.Parameters.AddWithValue("@type", type);
            SQLConnection.cmd.Parameters.AddWithValue("@Salary", Salary);
            try
            {
                Tes = SQLConnection.cmd.ExecuteNonQuery();
            }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return -1;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return Tes;


        }


    }
}
