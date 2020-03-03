using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReportStockController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private ReportStockUploadView controlReportStockUploadView;
        private ReportStockView controlReportStockView;

        private List<StockModel> stockList;


        public ReportStockController(ReportStockUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportStockUploadView = _mf;
        }


        public ReportStockController(ReportStockView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportStockView = _mf;
        }


        /* Обработка загрузки отчета в БД */
        public int UploadStockReport(List<StockModel> stockList)
        {
            string specifier = "G";

            for (int i = 0; i < stockList.Count; i++)
            {
                string sqlStatement = "INSERT INTO [Stock] ([UpdateDate], [ProductId], [Name], [ASIN], [SKU], [FNSKU], [MarketplaceId], [FulfillableItems], [ReservedItems], [InboundShipped], [InboundWorking]) VALUES ('" + stockList[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " + stockList[i].ProductId + ", '" + stockList[i].Name + "', '" + stockList[i].ASIN + "', '" + stockList[i].SKU + "', '" + stockList[i].FNSKU + "', " + stockList[i].MarketPlaceId + ", " + stockList[i].FulfillableItems + ", " + stockList[i].ReservedItems + ", " + stockList[i].InboundShipped + ", " + stockList[i].InboundWorking + ")";
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return 0;
            }
            return 1;
        }

        public int GetStock(DateTime _dt1, DateTime _dt2)
        {
            string sqlStatement = "";

            sqlStatement = "SELECT * FROM [Stock] WHERE [UpdateDate] between '" + _dt1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + _dt2.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        /* Выполняем запрос к БД и заносим полученные данные в  */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            stockList = new List<StockModel> { };

            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetStockToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlReportStockView != null)
                    controlReportStockView.GetStockFromDB(stockList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Заносим данные в List<AdvertisingProductsModel> */
        private void SetStockToList(IDataRecord record)
        {
            StockModel adprModel = new StockModel();

            for (int i = 0; i < record.FieldCount; i++)
            {
                adprModel.WriteData(i, record[i]);
            }
            stockList.Add(adprModel);
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
