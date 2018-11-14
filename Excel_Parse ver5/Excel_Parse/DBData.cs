using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class DBData
    {
        //Data Source = LOLODIN; Initial Catalog = AHEAD; Integrated Security = True

        //private const string InitialCatalog = "AHEAD";
        //private const string DataSource = "KCRF1NH-AHEAD-M";
        //private const bool IntegratedSecurity = true;
        private const string InitialCatalog = "AHEAD";
        private const string DataSource = "LOLODIN";
        private const bool IntegratedSecurity = true;

        public static SqlConnection GetDBConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder["Initial Catalog"] = InitialCatalog;
            builder["Data Source"] = DataSource;
            builder["integrated Security"] = IntegratedSecurity;

            string connectionString = builder.ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
