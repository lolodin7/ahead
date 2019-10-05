using System;
using System.Collections.Generic;
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

        public BusinessController(ReportBusinessUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessUploadView = _mf;
        }

        public int InsertBusinessReport(List<ReportBusinessModel> _businessList)
        {
            string specifier = "G";

            for (int i = 0; i < _businessList.Count; i++)
            {
                string sqlStatement = "INSERT INTO [BusinessReport] ([UpdateDate], [MarketPlaceId], [SKU], [Sessions], [SessionPercentage], [PageViews], [PageViewsPercentage], [UnitsOrdered], [UnitsOrdered-B2B], [UnitSessionPercentage], [UnitSessionPercentage-B2B], [OrderedProductSales], [OrderedProductSales-B2B], [TotalOrderItems], [TotalOrderItems-B2B]) VALUES ('" + _businessList[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " + _businessList[i].MarketPlaceId + ", '" + _businessList[i].SKU + "', " + _businessList[i].Sessions + ", " + _businessList[i].PageViews + ", " + _businessList[i].SessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].PageViewsPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].UnitsOrdered + ", " + _businessList[i].UnitsOrderedB2B + ", " + _businessList[i].UnitSessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].UnitSessionPercentageB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].OrderedProductSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].OrderedProductSalesB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", " + _businessList[i].TotalOrderItems + ", " + _businessList[i].TotalOrderItemsB2B + ")";
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return 0;
            }
            return 1;
        }

        public int UpdateBusinessReport(List<ReportBusinessModel> _businessList)
        {
            string specifier = "G";

            for (int i = 0; i < _businessList.Count; i++)
            {
                string sqlStatement = "UPDATE [BusinessReport] SET [Sessions] = " + _businessList[i].Sessions + ", [SessionPercentage] = " + _businessList[i].UnitSessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", [PageViews] = " + _businessList[i].PageViews + ", [PageViewsPercentage] = " + _businessList[i].PageViewsPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", [UnitsOrdered] = " + _businessList[i].UnitsOrdered + ", [UnitsOrdered-B2B] = " + _businessList[i].UnitsOrderedB2B + ", [UnitSessionPercentage] = " + _businessList[i].UnitSessionPercentage.ToString(specifier, CultureInfo.InvariantCulture) + ", [UnitSessionPercentage-B2B] = " + _businessList[i].UnitSessionPercentageB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", [OrderedProductSales] = " + _businessList[i].OrderedProductSales.ToString(specifier, CultureInfo.InvariantCulture) + ", [OrderedProductSales-B2B] = " + _businessList[i].OrderedProductSalesB2B.ToString(specifier, CultureInfo.InvariantCulture) + ", [TotalOrderItems] = " + _businessList[i].TotalOrderItems + ", [TotalOrderItems-B2B] = " + _businessList[i].TotalOrderItemsB2B + " WHERE [UpdateDate] = '" + _businessList[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [SKU] = '" + _businessList[i].SKU + "' AND [MarketPlaceId] = " + _businessList[i].MarketPlaceId;
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return -1;
            }
            return 1;
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
