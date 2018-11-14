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
        public List<SemCoreModel> scmList;


        public SemCoreController(SemCoreView _form)
        {
            connection = DBData.GetDBConnection();
            controlForm = _form;
        }

        public SemCoreController()
        {
            connection = DBData.GetDBConnection();
        }

        public bool GetSemCoreByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }
        

        public bool GetSemCoreByCategoryId(int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public bool GetSemCoreByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId + " AND CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        //-------------LEFT JOIN STATEMENTS-----------------


        public bool GetSemCoreJOINKeywordCategoryByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public bool GetSemCoreJOINKeywordCategoryByCategoryId(int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public bool GetSemCoreJOINKeywordCategoryByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId + " AND SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public bool GetSemCoreJOINKeywordCategoryAll()
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        //--------------------INSERT STATEMENTS-----------------


        public int SetNewKeyword(int _prodTypeId, int _categoryId, string _keyword, int _value, DateTime _lastUpdated)
        {
            string sqlStatement = "INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated]) VALUES (" + _prodTypeId + ", " + _categoryId + ", '" + _keyword + "', " + _value + ", " + _lastUpdated.ToOADate() + ")";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_Command(command);
        }


        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private bool Execute_SELECT_Command(SqlCommand _command)
        {
            scmList = new List<SemCoreModel> { };
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
                }
                reader.Close();
                connection.Close();

                controlForm.GetDataFromDB(scmList);
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }

        /* Записываем данные в БД */
        private int Execute_INSERT_Command(SqlCommand _command)
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
            scmList.Add(_scm);
            for (int i = 0; i < record.FieldCount; i++)
            {
                scmList[scmList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Заносим данные в List<SemCoreModel> */
        private void SetData(object[] arr)
        {
            SemCoreModel _scm = new SemCoreModel();
            scmList.Add(_scm);
            for (int i = 0; i < arr.Length; i++)
            {
                scmList[scmList.Count - 1].WriteData(i, arr[i]);
            }
        }
    }
}
