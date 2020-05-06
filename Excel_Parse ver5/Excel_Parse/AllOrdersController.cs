using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class AllOrdersController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private List<AllOrdersModel> ordersList;

        private ReportSalesView controlReportSalesView;

        public AllOrdersController(ReportSalesView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportSalesView = _mf;
        }

        /*  */
        public int GetAllOrders()
        {
            string sqlStatement = "SELECT * FROM [Orders]";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        /* Выполняем запрос к БД и заносим полученные данные в  */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            ordersList = new List<AllOrdersModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetOrdersToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlReportSalesView != null)
                    controlReportSalesView.GetOrdersFromDB(ordersList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Заносим данные в List<AllOrdersModel> */
        private void SetOrdersToList(IDataRecord record)
        {
            AllOrdersModel adprModel = new AllOrdersModel();
            ordersList.Add(adprModel);

            for (int i = 0; i < record.FieldCount; i++)
            {
                ordersList[ordersList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Выполняем запрос UPDATE/INSERT/DELETE к БД */
        private int Execute_UPDATE_DELETE_INSERT_Command(SqlCommand _command)
        {
            try
            {
                connection.Open();
                _command.ExecuteScalar();
                connection.Close();
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }
    }
}
