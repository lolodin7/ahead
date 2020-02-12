using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ProductsController
    {
        private List<ProductsModel> pList;
        private List<ProductTypesModel> ptList;
        private List<MarketplaceModel> mpList;

        private SqlConnection connection;
        private SqlCommand command;
        private ProductsView controlFormProductsView;
        private LoggerView controlFormLoggerView;
        private LoggerAdd controlFormLoggerAdd;
        private ReportBusinessUploadView controlReportBusinessUploadView;
        private ReportAdvertisingUploadView controlFormAdvertisingUploadReportView;
        private ReportAdvertisingFilterView controlAdvertisingReportFilterView;
        private ReportBusinessFilterView controlReportBusinessFilterView;
        private ReportSessionsView controlReportSessionsView;
        private Advreport7days controlAdvreport7days;
        private EveryDayReportsUpdate controlEveryDayReportsUpdate;


        /* Конструктор */
        public ProductsController(EveryDayReportsUpdate _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlEveryDayReportsUpdate = _controlForm;
        }

        /* Конструктор */
        public ProductsController(Advreport7days _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlAdvreport7days = _controlForm;
        }

        /* Конструктор */
        public ProductsController(ProductsView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormProductsView = _controlForm;
        }

        /* Конструктор */
        public ProductsController(ReportSessionsView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlReportSessionsView = _controlForm;
        }

        /* Конструктор */
        public ProductsController(ReportBusinessFilterView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessFilterView = _controlForm;
        }

        /* Конструктор */
        public ProductsController(ReportBusinessUploadView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessUploadView = _controlForm;
        }

        /* Конструктор */
        public ProductsController(LoggerView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormLoggerView = _controlForm;
        }

        /* Конструктор */
        public ProductsController(ReportAdvertisingFilterView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingReportFilterView = _controlForm;
        }

        /* Конструктор */
        public ProductsController(LoggerAdd _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormLoggerAdd = _controlForm;
        }


        /* Конструктор */
        public ProductsController(ReportAdvertisingUploadView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormAdvertisingUploadReportView = _controlForm;
        }
        /* -------------------------SELECT Statements--------------------- */

        public int GetProductsAllJOIN()
        {
            string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECTJOIN_Command(command);
        }

        public int GetActiveProductsJOIN()
        {
            //string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.ActiveStatus = 'true'";
            string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.ActiveStatus = 1";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECTJOIN_Command(command);
        }

        public int GetProductsByMarketplaceId(int _id)
        {
            //string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.ActiveStatus = 'true' and Products.MarketPlaceId = " + _id;
            string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.MarketPlaceId = " + _id;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECTJOIN_Command(command);
        }

        public int GetProductsByFewMarketplaceId(List<int> _id)
        {
            string sqlStatement = "";
            if (_id.Count == 0)
                sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0";
            else if (_id.Count == 1)
                //sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.ActiveStatus = 'true' and Products.MarketPlaceId = " + _id[0];
                sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.MarketPlaceId = " + _id[0];
            else if (_id.Count >= 2)
            {
                //sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.ActiveStatus = 'true' and (Products.MarketPlaceId = " + _id[0];
                sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and (Products.MarketPlaceId = " + _id[0];

                for (int i = 1; i < _id.Count; i++)
                {
                    sqlStatement = sqlStatement + " or Products.MarketPlaceId = " + _id[i];
                }

                sqlStatement = sqlStatement + ")";
            }
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECTJOIN_Command(command);
        }


        /* -------------------------UPDATE Statements--------------------- */

        public int DeleteProductFromSemantics(int _productId)
        {
            string sqlStatement = "UPDATE [Semantics] SET [ProductId] = 0 WHERE ProductId = " + _productId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int DeleteProductFromFieldsLength(int _productId)
        {
            string sqlStatement = "UPDATE [FieldsLength] SET [ProductId] = 0 WHERE ProductId = " + _productId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int UpdateExistingProduct(string _name, string _asin, string _sku, int _prodTypeId, int _productId, int _marketPlaceId, bool _activeStatus, string _shortName)
        {
            string sqlStatement = "UPDATE [Products] SET [Name] = '" + _name + "', [ASIN] = '" + _asin + "', [SKU] = '" + _sku + "', [ProductTypeId] = " + _prodTypeId + ", [MarketPlaceId] = " + _marketPlaceId + ", [ActiveStatus] = '" + _activeStatus + "', [ProdShortName] = '" + _shortName + "' WHERE [ProductId] = " + _productId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int UpdateProductActiveStatus(int _productId, bool _activeStatus)
        {
            string sqlStatement = "UPDATE [Products] SET [ActiveStatus] = '" + _activeStatus + "' WHERE [ProductId] = " + _productId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }




        /* -------------------------DELETE Statements--------------------- */

        public int DeleteProductFromProducts(int _productId)
        {
            string sqlStatement = "DELETE FROM [Products] WHERE [ProductId] = " + _productId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }




        /* -------------------------INSERT Statements--------------------- */

        public int InsertNewProduct(string _name, string _asin, string _sku, int _prodTypeId, int _marketPlaceId, bool _activeStatus, string _shortName)
        {
            string sqlStatement = "INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName]) VALUES ('" + _name + "', '" + _asin + "', '" + _sku + "', " + _prodTypeId + ", " + _marketPlaceId + ", '" + _activeStatus + "', '" + _shortName + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }






        /* -------------------------------Methods---------------------------------------- */
        
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

        /* Выполняем запрос к БД и заносим полученные данные в List<ProductsModel> */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            pList = new List<ProductsModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlFormProductsView != null)                       //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    controlFormProductsView.GetProductsFromDB(pList);
                else if (controlFormLoggerView != null)
                    controlFormLoggerView.GetProductsFromDB(pList);
                else if (controlFormLoggerAdd != null)
                    controlFormLoggerAdd.GetProductsFromDB(pList);
                else if (controlFormAdvertisingUploadReportView != null)
                    controlFormAdvertisingUploadReportView.GetProductsFromDB(pList);
                else if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetProductsFromDB(pList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }


        /* Заносим данные в List<ProductsModel> */
        private void SetProductsToList(IDataRecord record)
        {
            ProductsModel pModel = new ProductsModel();
            pList.Add(pModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                pList[pList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Заносим данные в List<ProductsModel> */
        private void SetDataToList(object[] arr)
        {
            ProductsModel pModel = new ProductsModel();
            pList.Add(pModel);
            for (int i = 0; i < arr.Length; i++)
            {
                pList[pList.Count - 1].WriteData(i, arr[i]);
            }
        }

        /* Делаем SELECT с JOIN из БД и отдаем данные двумя List, чтобы потом вставить в одну таблицу
         * при чем, вставляем коряво (смотри SetProductTypesToList), но это потому, что у нас ProductModel имеет
         * только 5 полей и туда одним методом вставить не получится. Плюс всё равно нужно будет получать данные 
         * всех ProductTypes
         *  */
        private int Execute_SELECTJOIN_Command(SqlCommand _command)
        {
            pList = new List<ProductsModel> { };
            ptList = new List<ProductTypesModel> { };
            mpList = new List<MarketplaceModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToList((IDataRecord)reader);
                        SetProductTypesToList((IDataRecord)reader);
                        SetMarketPlacesToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlFormProductsView != null)                                    //вызывает нужный метод в зависимости, из какой формы нас вызывают
                {
                    controlFormProductsView.GetProductsFromDB(pList);
                    controlFormProductsView.GetProductTypesFromDB(ptList);
                    controlFormProductsView.GetMarketPlacesFromDB(mpList);
                }
                else if (controlFormLoggerView != null)
                    controlFormLoggerView.GetProductsFromDB(pList);
                else if (controlFormLoggerAdd != null)
                    controlFormLoggerAdd.GetProductsFromDB(pList);
                else if (controlFormAdvertisingUploadReportView != null)
                    controlFormAdvertisingUploadReportView.GetProductsFromDB(pList);
                else if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetProductsFromDB(pList);
                else if (controlReportBusinessUploadView != null)
                    controlReportBusinessUploadView.GetProductsFromDB(pList);
                else if (controlReportBusinessFilterView != null)
                    controlReportBusinessFilterView.GetProductsFromDB(pList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetProductsFromDB(pList);
                else if (controlAdvreport7days != null)
                    controlAdvreport7days.GetProductsFromDB(pList);
                else if (controlEveryDayReportsUpdate != null)
                    controlEveryDayReportsUpdate.GetProductsFromDB(pList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Построчно заносим данные o productType */
        private void SetProductTypesToList(IDataRecord record)
        {
            ProductTypesModel ptModel = new ProductTypesModel();
            ptList.Add(ptModel);

            ptList[ptList.Count - 1].WriteData(0, record[8]);
            ptList[ptList.Count - 1].WriteData(1, record[9]);

        }

        /* Построчно заносим данные o Marketplace */
        private void SetMarketPlacesToList(IDataRecord record)
        {
            MarketplaceModel mpModel = new MarketplaceModel();
            mpList.Add(mpModel);

            mpList[mpList.Count - 1].WriteData(0, record[10]);
            mpList[mpList.Count - 1].WriteData(1, record[11]);
        }
    }
}
