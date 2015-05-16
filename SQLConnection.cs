using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ERS
{
    class SQLConnection
    {
        
        static public SqlConnection conn = new SqlConnection("data source =localhost;initial catalog =ERS;integrated security =true");
        static public SqlCommand cmd = new SqlCommand("",conn);
        static public SqlDataReader reader;
        static public SqlDataAdapter adapter = new SqlDataAdapter("",conn);
        
    }

   
}
