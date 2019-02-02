using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class SemCoreArchiveController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private SemCoreArchiveView controlSemCoreArchiveView;
        private SemCoreView controlSemCoreView;


        private List<SemCoreArchiveModel> scaList;
        

        public SemCoreArchiveController(SemCoreArchiveView _form)
        {
            connection = DBData.GetDBConnection();
            controlSemCoreArchiveView = _form;
        }

        public SemCoreArchiveController(SemCoreView _form)
        {
            connection = DBData.GetDBConnection();
            controlSemCoreView = _form;
        }







        /* Добавляем новый ключ в БД из SemCoreView */
        public int SetNewKeywordToSemCoreArchive(int _productTypeId, int _keyCategoryId, string _keyName, int _keyValue, DateTime dt, int _semcoreId)
        {
            string sqlStatement = "INSERT INTO [SemCoreArchive] ([ProductTypeId], [CategoryId], [Keyword], [SemCoreId], [ValuesAndDates]) VALUES (" + _productTypeId + ", " + _keyCategoryId + ", '" + _keyName + "', " + _semcoreId + ", '" + TransformValuesAndDatesToString(_keyValue, dt) + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        /* Получаем SemCoreId для заданного Keyword */
        public int GetSemCoreIdForKey(string _name)
        {
            string sqlStatement = "SELECT [SemCoreId] FROM [SemCore] WHERE [Keyword] = '" + _name + "'";
            command = new SqlCommand(sqlStatement, connection);
            IDataRecord record = null;
            int result = -1;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        record = (IDataRecord)reader;
                        result = int.Parse(record[0].ToString());
                    }
                }
                reader.Close();
                connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Получаем ключи по заданным ProductTypeId и CategoryId */
        public int GetSemCoreByProductAndCategory(int _prodId, int _categoryId)
        {
            string sqlStatement = ""; ;
            if (_prodId != -1 && _categoryId != -1)
            {
                sqlStatement = "SELECT * FROM SemCoreArchive LEFT JOIN KeywordCategory ON SemCoreArchive.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCoreArchive.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId = " + _categoryId + "AND SemCoreArchive.ProductTypeId = " + _prodId;
            }
            else if (_prodId == -1 && _categoryId != -1)
            {
                sqlStatement = "SELECT * FROM SemCoreArchive LEFT JOIN KeywordCategory ON SemCoreArchive.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCoreArchive.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId = " + _categoryId + "AND SemCoreArchive.ProductTypeId > 0";
            }
            else if (_prodId != -1 && _categoryId == -1)
            {
                sqlStatement = "SELECT * FROM SemCoreArchive LEFT JOIN KeywordCategory ON SemCoreArchive.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCoreArchive.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCoreArchive.ProductTypeId = " + _prodId;
            }
            else if (_prodId == -1 && _categoryId == -1)
            {
                sqlStatement = "SELECT * FROM SemCoreArchive LEFT JOIN KeywordCategory ON SemCoreArchive.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCoreArchive.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCoreArchive.ProductTypeId > 0";
            }

            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
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
            scaList = new List<SemCoreArchiveModel> { };
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

                if (controlSemCoreArchiveView != null)                       //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    controlSemCoreArchiveView.GetKeywordsFromDB(scaList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Заносим данные в List<SemCoreArchiveModel> */
        private void SetProductsToList(IDataRecord record)
        {
            SemCoreArchiveModel scaModel = new SemCoreArchiveModel();
            scaList.Add(scaModel);

            scaList[scaList.Count - 1].WriteData(0, record[0]);
            scaList[scaList.Count - 1].WriteData(1, record[1]);
            scaList[scaList.Count - 1].WriteData(2, record[2]);
            scaList[scaList.Count - 1].WriteData(3, record[3]);
            scaList[scaList.Count - 1].WriteData(4, record[4]);
            scaList[scaList.Count - 1].WriteData(5, record[6]);
            scaList[scaList.Count - 1].WriteData(6, record[9]);

        }

        private string TransformValuesAndDatesToString(int _value, DateTime _date)
        {
            string result = _value.ToString() + "&" + _date.ToString() + "@";
            return result;
        }

        public DateTime TransformStringToValuesAndDates(string _text)
        {
            List<int> valuesList = new List<int> { };
            List<DateTime> datesList = new List<DateTime> { };

            int posStart = 0;
            int posEnd = -1;

            for (int i = 0; i < _text.Length; i++)
            {
                if (_text[i].Equals("@"))
                {
                    posEnd++;

                }
                else
                    posEnd++;
            }
            return DateTime.Now;
        }


    }
}
