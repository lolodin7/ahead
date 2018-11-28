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

        private SqlConnection connection;
        private SqlCommand command;
        private ProductsView controlFormProductsView;


        /* Конструктор */
        public ProductsController(ProductsView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormProductsView = _controlForm;
        }




        /* -------------------------SELECT Statements--------------------- */

        public int GetProductsAllJOIN()
        {
            string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId WHERE Products.ProductId > 0";
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

        public int UpdateExistingProduct(string _name, string _asin, string _sku, int _prodTypeId, int _productId)
        {
            string sqlStatement = "UPDATE [Products] SET [Name] = '" + _name + "', [ASIN] = '" + _asin + "', [SKU] = '" + _sku + "', [ProductTypeId] = " + _prodTypeId + " WHERE [ProductId] = " + _productId;
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

        public int InsertNewProduct(string _name, string _asin, string _sku, int _prodTypeId)
        {
            string sqlStatement = "INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId]) VALUES ('" + _name + "', '" + _asin + "', '" + _sku + "', " + _prodTypeId + ")";
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
                //else if (controlForm2 != null)
                //    controlForm2.GetCategoriesFromDB(kcList);
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
                }
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

            ptList[ptList.Count - 1].WriteData(0, record[5]);
            ptList[ptList.Count - 1].WriteData(1, record[6]);

        }
    }
}
