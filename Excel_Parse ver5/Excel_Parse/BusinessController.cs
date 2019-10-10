using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class BusinessController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private List<ReportBusinessModel> businessList;

        private ReportBusinessUploadView controlReportBusinessUploadView;
        private ReportBusinessFilterView controlReportBusinessFilterView;
        private ReportSessionsView controlReportSessionsView;

        public BusinessController(ReportBusinessUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessUploadView = _mf;
        }

        public BusinessController(ReportSessionsView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportSessionsView = _mf;
        }

        public BusinessController(ReportBusinessFilterView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessFilterView = _mf;
        }

        public int InsertBusinessReport(List<ReportBusinessModel> _businessList)
        {
            string specifier = "G";
            int noErrors = 1;

            for (int i = 0; i < _businessList.Count; i++)
            {
                if (_businessList[i].ProductId != -1)
                {
                    string sqlStatement = "INSERT INTO [BusinessReport] ([UpdateDate], [MarketPlaceId], [SKU], [Sessions], [SessionPercentage], [PageViews], [PageViewsPercentage], [UnitsOrdered], [UnitsOrdered-B2B], [UnitSessionPercentage], [UnitSessionPercentage-B2B], [OrderedProductSales], [OrderedProductSales-B2B], [TotalOrderItems], [TotalOrderItems-B2B], [ProductId]) VALUES ('" + _businessList[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " + _businessList[i].MarketPlaceId + ", '" + _businessList[i].SKU + "', " + _businessList[i].Sessions + ", " + _businessList[i].PageViews + ", " + _businessList[i].SessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].PageViewsPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].UnitsOrdered + ", " + _businessList[i].UnitsOrderedB2B + ", " + _businessList[i].UnitSessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].UnitSessionPercentageB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].OrderedProductSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].OrderedProductSalesB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].TotalOrderItems + ", " + _businessList[i].TotalOrderItemsB2B + ", " + _businessList[i].ProductId + ")";
                    command = new SqlCommand(sqlStatement, connection);
                    if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                        return 0;
                }
                else
                    noErrors = 0;
            }
            return noErrors;
        }

        public int UpdateBusinessReport(List<ReportBusinessModel> _businessList)
        {
            string specifier = "G";

            for (int i = 0; i < _businessList.Count; i++)
            {
                string sqlStatement = "UPDATE [BusinessReport] SET [Sessions] = " + _businessList[i].Sessions + ", [SessionPercentage] = " + _businessList[i].UnitSessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", [PageViews] = " + _businessList[i].PageViews + ", [PageViewsPercentage] = " + _businessList[i].PageViewsPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", [UnitsOrdered] = " + _businessList[i].UnitsOrdered + ", [UnitsOrdered-B2B] = " + _businessList[i].UnitsOrderedB2B + ", [UnitSessionPercentage] = " + _businessList[i].UnitSessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", [UnitSessionPercentage-B2B] = " + _businessList[i].UnitSessionPercentageB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", [OrderedProductSales] = " + _businessList[i].OrderedProductSales.ToString(specifier, CultureInfo.InvariantCulture) + ", [OrderedProductSales-B2B] = " + _businessList[i].OrderedProductSalesB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", [TotalOrderItems] = " + _businessList[i].TotalOrderItems + ", [TotalOrderItems-B2B] = " + _businessList[i].TotalOrderItemsB2B + " WHERE [UpdateDate] = '" + _businessList[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [ProductId] = '" + _businessList[i].ProductId;
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return -1;
            }
            return 1;
        }


        public int GetFinalABusinessReport(DateTime _dt1, DateTime _dt2, List<int> _mpList)
        {
            string sqlStatement = "";

            sqlStatement = "SELECT * FROM [BusinessReport] WHERE [UpdateDate] between '" + _dt1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + _dt2.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            if (_mpList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0] + ")";
            }
            else if (_mpList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0];

                for (int i = 1; i < _mpList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [MarketPlaceId] = " + _mpList[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int GetFinalABusinessReport(DateTime _dt1, DateTime _dt2, List<int> _mpList, List<int> _prodList)
        {
            string sqlStatement = "";

            sqlStatement = "SELECT * FROM [BusinessReport] WHERE [UpdateDate] between '" + _dt1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + _dt2.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            if (_mpList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0] + ")";
            }
            else if (_mpList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0];

                for (int i = 1; i < _mpList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [MarketPlaceId] = " + _mpList[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            if (_prodList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([ProductId] = " + _prodList[0] + ")";
            }
            else if (_prodList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([ProductId] = " + _prodList[0];

                for (int i = 1; i < _prodList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [ProductId] = " + _prodList[i];
                }

                sqlStatement = sqlStatement + ")";
            }
            
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        /* Выполняем запрос к БД и заносим полученные данные в  */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            businessList = new List<ReportBusinessModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlReportBusinessFilterView != null)
                    controlReportBusinessFilterView.GetBusinessReportFromDB(businessList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetBusinessReportFromDB(businessList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }


        /* Заносим данные в List<AdvertisingProductsModel> */
        private void SetDataToList(IDataRecord record)
        {
            ReportBusinessModel busModel = new ReportBusinessModel();
            businessList.Add(busModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                businessList[businessList.Count - 1].WriteData(i, record[i]);
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
