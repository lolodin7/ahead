using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace Excel_Parse
{
    class DBData
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            
            builder.ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            string connectionString = builder.ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
