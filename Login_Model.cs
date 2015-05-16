using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ERS
{
    class Login_Model
    {
        public int TryLogin(string ID,string PW )
        {
            string type;
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.cmd.CommandText = "LoginU";
            SQLConnection.cmd.Parameters.AddWithValue("@ID",ID);
            SQLConnection.cmd.Parameters.AddWithValue("@PW", PW);
            SQLConnection.conn.Open();
            try
            {
                type = SQLConnection.cmd.ExecuteScalar().ToString();
            }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return -1;
            }
            
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            if (type == "User") return 0;
            if (type == "Admin") return 1;

            return -1;
        }
    }
}
