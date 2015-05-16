using System;
    using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ERS
{
    class Search_Model
    {
        public Boolean GetDataSource(Search s, String table_name)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            if (table_name == "Room")
            {
                SQLConnection.cmd.CommandText = "Select * from Room where Deleted = 'False' ";
            }
            else if(table_name == "Catering")
            {
                SQLConnection.cmd.CommandText = "Select * from Catering where Deleted = 'False' ";
            }
            else
            {
                SQLConnection.cmd.CommandText = "Select * from  \"" + table_name + "\"";
                
            }
            SQLConnection.cmd.CommandType = CommandType.Text;
            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();
            if (temp.HasRows)
            {
                s.SetBinding(temp);
                SQLConnection.conn.Close();
                return true;
            }
            else
            {
                SQLConnection.conn.Close();
                return false;
            }
           
        }
    }
}
