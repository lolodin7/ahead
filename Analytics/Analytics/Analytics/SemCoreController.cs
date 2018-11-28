using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    class SemCoreController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private SemCoreView controlForm;
        private List<SemCoreModel> scList;

        private SemCoreRebuildView controlFormSemCoreRebuildView;

        /* Конструктор */
        public SemCoreController(SemCoreView _form)
        {
            connection = DBData.GetDBConnection();
            controlForm = _form;
        }

        /* Конструктор */
        public SemCoreController()
        {
            connection = DBData.GetDBConnection();
        }

        /* Конструктор */
        public SemCoreController(SemCoreRebuildView _form)
        {
            connection = DBData.GetDBConnection();
            controlFormSemCoreRebuildView = _form;
        }


        //---------------------SELECT STATEMENTS-------------------


        public int GetSemCoreByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }
        

        public int GetSemCoreByCategoryId(int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public int GetSemCoreByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId + " AND CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        //-------------LEFT JOIN STATEMENTS-----------------


        public int GetSemCoreJOINKeywordCategoryByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public int GetSemCoreJOINKeywordCategoryByCategoryId(int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public int GetSemCoreJOINKeywordCategoryByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId + " AND SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public int GetSemCoreJOINKeywordCategoryAll()
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        //--------------------INSERT STATEMENTS-----------------


        public int InsertNewKeyword(int _prodTypeId, int _categoryId, string _keyword, int _value, DateTime _lastUpdated)
        {
            string sqlStatement = "INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated]) VALUES (" + _prodTypeId + ", " + _categoryId + ", '" + _keyword + "', " + _value + ", '" + _lastUpdated.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }

        //--------------------UPDATE STATEMENTS-----------------


        public int UpdateExistingKeywordBySemCoreId(int _prodTypeId, int _categoryId, string _keyword, int _value, DateTime _lastUpdated, int _semCoreId)
        {
            string sqlStatement = "UPDATE [SemCore] SET [ProductTypeId] = " + _prodTypeId + ", [CategoryId] = " + _categoryId + ", [Keyword] = '" + _keyword + "', [Value] = " + _value + ", [LastUpdated] = '" + _lastUpdated.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE [SemCoreId] = " + _semCoreId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }

        public int UpdateExistingKeywordByKeyword(int _prodTypeId, int _categoryId, string _keyword, int _value, DateTime _lastUpdated)
        {
            string sqlStatement = "UPDATE [SemCore] SET [ProductTypeId] = " + _prodTypeId + ", [CategoryId] = " + _categoryId + ", [Keyword] = '" + _keyword + "', [Value] = " + _value + ", [LastUpdated] = '" + _lastUpdated.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE [Keyword] = '" + _keyword + "'";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }

        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            scList = new List<SemCoreModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetData((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                    return -1;
                }
                reader.Close();
                connection.Close();

                if (controlForm != null)
                    controlForm.GetDataFromDB(scList);
                else if (controlFormSemCoreRebuildView != null)
                    controlFormSemCoreRebuildView.GetSemCoreFromDB(scList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Записываем данные в БД */
        private int Execute_INSERT_UPDATE_DELETE_Command(SqlCommand _command)
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

        /* Заносим данные в List<SemCoreModel> */
        private void SetData(IDataRecord record)
        {
            SemCoreModel _scm = new SemCoreModel();
            scList.Add(_scm);
            for (int i = 0; i < record.FieldCount; i++)
            {
                scList[scList.Count - 1].SetModelData(i, record[i]);
            }
        }

        /* Заносим данные в List<SemCoreModel> */
        private void SetData(object[] arr)
        {
            SemCoreModel _scm = new SemCoreModel();
            scList.Add(_scm);
            for (int i = 0; i < arr.Length; i++)
            {
                scList[scList.Count - 1].SetModelData(i, arr[i]);
            }
        }
    }
}
