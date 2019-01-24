using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class FullSemCoreController
    {
        private List<FullSemCoreModel> fscList;
        private SqlConnection connection;
        private SqlCommand command;

        private KeywordsAreExistedView ControlFormKeywordsAreExisted;
        private MainFormView ControlFormMF;
        private FullSemCoreView ControlFullSemCoreView;


        public FullSemCoreController(KeywordsAreExistedView _form)
        {
            connection = DBData.GetDBConnection();
            ControlFormKeywordsAreExisted = _form;
        }

        public FullSemCoreController(MainFormView _form)
        {
            connection = DBData.GetDBConnection();
            ControlFormMF = _form;
        }

        public FullSemCoreController(FullSemCoreView _form)
        {
            connection = DBData.GetDBConnection();
            ControlFullSemCoreView = _form;
        }




        /* -------------------------SELECT Statements--------------------- */

        public int GetSemCoreAll()
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE ProductTypes.ProductTypeId > 0 AND KeywordCategory.CategoryId > 0";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int GetSemCoreByProductId(int _prodId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCore.ProductTypeId = " + _prodId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }
        public int GetSemCoreByCategoryId(int _categoryId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE ProductTypes.ProductTypeId > 0 AND SemCore.CategoryId = " + _categoryId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }
        public int GetSemCoreByProductAndCategory(int _prodId, int _categoryId)
        {
            string sqlStatement = ""; ;
            if (_prodId != -1 && _categoryId != -1)
            {
                sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId = " + _categoryId + "AND SemCore.ProductTypeId = " + _prodId;
            }
            else if (_prodId == -1 && _categoryId != -1)
            {
                sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId = " + _categoryId + "AND SemCore.ProductTypeId > 0";
            }
            else if (_prodId != -1 && _categoryId == -1)
            {
                sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCore.ProductTypeId = " + _prodId;
            }
            else if (_prodId == -1 && _categoryId == -1)
            {
                sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCore.ProductTypeId > 0";
            }

            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }




        public int SetNewKeywordToSemCore(int _productTypeId, int _keyCategoryId, string _keyName, int _keyValue, DateTime dt)
        {
            string sqlStatement = "INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated]) VALUES (" + _productTypeId + ", " + _keyCategoryId + ", '" + _keyName + "', " + _keyValue + ", '" + dt.ToString("yyyy-MM-dd") + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int SetEditedKeywordToSemCore(int _productTypeId, int _keyCategoryId, string _keyName, int _keyValue, DateTime dt, int _semCoreId)
        {
            string sqlStatement = "UPDATE [SemCore] SET [ProductTypeId] = " + _productTypeId + ", [CategoryId] = " + _keyCategoryId + ", [Keyword] = '" + _keyName + "', [Value] = " + _keyValue + ", [LastUpdated] = '" + dt.ToString("yyyy-MM-dd") + "' WHERE [SemCoreId] = " + _semCoreId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }


        public int DeleteKeywordFromSemCore(int _semCoreId)
        {
            string sqlStatement = "DELETE FROM [SemCore] WHERE [SemCoreId] = " + _semCoreId;
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
            fscList = new List<FullSemCoreModel> { };
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

                if (ControlFullSemCoreView != null)                       //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    ControlFullSemCoreView.GetKeywordsFromDB(fscList);
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
            FullSemCoreModel fscModel = new FullSemCoreModel();
            fscList.Add(fscModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                fscList[fscList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Заносим данные в List<ProductsModel> */
        private void SetDataToList(object[] arr)
        {
            FullSemCoreModel fscModel = new FullSemCoreModel();
            fscList.Add(fscModel);
            for (int i = 0; i < arr.Length; i++)
            {
                fscList[fscList.Count - 1].WriteData(i, arr[i]);
            }
        }

    }
}
