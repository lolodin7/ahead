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

        private List<SemCoreArchiveModel> scaList;

        private SemCoreView controlSemCoreView;
        private SemCoreRebuildView controlSemCoreRebuildView;
        private FullSemCoreView controlFullSemCoreView;
        private SemCoreArchiveView controlSemCoreArchiveView;



        public SemCoreArchiveController(SemCoreView _form)
        {
            connection = DBData.GetDBConnection();
            controlSemCoreView = _form;
        }

        public SemCoreArchiveController(SemCoreRebuildView _form)
        {
            connection = DBData.GetDBConnection();
            controlSemCoreRebuildView = _form;
        }

        public SemCoreArchiveController(SemCoreArchiveView _form)
        {
            connection = DBData.GetDBConnection();
            controlSemCoreArchiveView = _form;
        }

        public SemCoreArchiveController(FullSemCoreView _form)
        {
            connection = DBData.GetDBConnection();
            controlFullSemCoreView = _form;
        }


        /* Добавляем новый ключ в БД */
        public int InsertNewKeywordToSemCoreArchive(int _productTypeId, int _keyCategoryId, string _keyName, int _keyValue, DateTime dt, int _semcoreId, int _marketPlaceId)
        {
            string sqlStatement = "INSERT INTO [SemCoreArchive] ([ProductTypeId], [CategoryId], [Keyword], [SemCoreId], [ValuesAndDates], [MarketPlaceId]) VALUES (" + _productTypeId + ", " + _keyCategoryId + ", '" + _keyName + "', " + _semcoreId + ", '" + TransformValuesAndDatesToString(_keyValue, dt) + "', " + _marketPlaceId + ")";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }


        public int UpdateExistingKeywordBySemCoreId(int _prodTypeId, int _categoryId, string _keyName, int _value, DateTime _dt, int _semCoreId)
        {
            string sqlStatement = "UPDATE [SemCoreArchive] SET [ProductTypeId] = " + _prodTypeId + ", [CategoryId] = " + _categoryId + ", [Keyword] = '" + _keyName + "',  [ValuesAndDates] = '" + TransformValuesAndDatesToString(_value, _dt, GetValuesAndDatesForKey(_semCoreId)) + "' WHERE [SemCoreId] = " + _semCoreId;
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

        public string GetValuesAndDatesForKey(int _semCoreId)
        {
            string sqlStatement = "SELECT [ValuesAndDates] FROM [SemCoreArchive] WHERE [SemCoreId] = " + _semCoreId;
            command = new SqlCommand(sqlStatement, connection);
            IDataRecord record = null;
            string result = "";

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        record = (IDataRecord)reader;
                        result = record[0].ToString();
                    }
                }
                reader.Close();
                connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult.ToString();
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
                {
                    controlSemCoreArchiveView.GetKeywordsFromDB(scaList);
                }
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

        private string TransformValuesAndDatesToString(int _value, DateTime _date, string _oldText)
        {
            string result = _value.ToString() + "&" + _date.ToString() + "@";
            return _oldText + result;
        }


        public void TransformStringToValuesAndDates(string _text)
        {
            List<int> valuesList = new List<int> { };
            List<DateTime> datesList = new List<DateTime> { };

            int posStart = 0;
            int posEnd = -1;

            bool checkForValue = true;

            for (int i = 0; i < _text.Length; i++)
            {
                switch (checkForValue)
                {
                    case true:
                        if (_text[i].Equals('&'))
                        {
                            posEnd = i;
                            string ghj = _text.Substring(posStart, posEnd - posStart);
                            valuesList.Add(int.Parse(ghj));
                            checkForValue = false;
                            posStart = i + 1;
                        }
                        break;
                    case false:
                        if (_text[i].Equals('@'))
                        {
                            posEnd = i;
                            string gh = _text.Substring(posStart, posEnd - posStart);
                            datesList.Add(DateTime.Parse(gh));
                            checkForValue = true;
                            posStart = i + 1;
                        }
                        break;
                }
            }

            //тут, в зависимости откуда вызвали, передаем в нужный класс два списка
            if (controlSemCoreArchiveView != null)
            {
                //вызывает два метода из этого класса
                controlSemCoreArchiveView.GetDatesForKey(datesList);
                controlSemCoreArchiveView.GetValuesForKey(valuesList);
            }
        }

        private void ReturnValuesAndDates(List<DateTime> _dt, List<int> _values)
        {
            //тут, в зависимости откуда вызвали, передаем в нужный класс два списка
            if (controlSemCoreArchiveView != null)
            {
                //вызывает два метода из этого класса
                controlSemCoreArchiveView.GetDatesForKey(_dt);
                controlSemCoreArchiveView.GetValuesForKey(_values);
            }
        }

    }
}
