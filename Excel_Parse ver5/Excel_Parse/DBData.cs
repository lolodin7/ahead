using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using System.Net;

namespace Excel_Parse
{
    class DBData
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();            

            string ip = "";
            SqlConnection connection;

            ip = new WebClient().DownloadString("http://icanhazip.com/");       //узнаем ip на 1м сервисе
            if (ip.Equals(""))
                ip = new WebClient().DownloadString("https://api.ipify.org");        //если 1й не работает, проверяем на 2м

            if (!ip.Equals(""))
            {
                if (ip.Contains(ConfigurationManager.AppSettings.Get("serverIp")))  //сравниваем полученный внешний ip с тем ip сервера, который хранится в конфиге
                    builder.ConnectionString = ConfigurationManager.ConnectionStrings["connStrLocal"].ConnectionString;
                else
                    builder.ConnectionString = ConfigurationManager.ConnectionStrings["connStrGlobal"].ConnectionString;

                string connectionString = builder.ConnectionString;

                connection = new SqlConnection(connectionString);
                return connection;
            }

            return new SqlConnection();
        }
    }
}
