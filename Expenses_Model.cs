using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ERS
{
    class Expenses_Model
    {
        public int SubmitExpense(string Desc,double Price,DateTime Date)
        {
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "NewExpense";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@Descr", Desc);
            SQLConnection.cmd.Parameters.AddWithValue("@Cost", Price);
            SQLConnection.cmd.Parameters.AddWithValue("@DateT", Date);
            int effected = 0;
            try
            {
               effected =  SQLConnection.cmd.ExecuteNonQuery();
            }
            catch
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return -1;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            return effected;

        }
    }
}
