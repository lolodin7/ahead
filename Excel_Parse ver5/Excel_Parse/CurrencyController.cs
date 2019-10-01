using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Windows.Forms;

namespace Excel_Parse
{
    class CurrencyController
    {
        private SqlConnection connection;
        private SqlCommand command;
        private List<CurrencyModel> currencyList;

        private Form ControlSomeForm;

        private List<listElement> currenciesList;

        struct listElement
        {
            public string key { get; set; }
            public double val { get; set; }
        }



        //public CurrencyController(SomeForm _mf)
        public CurrencyController()
        {
            connection = DBData.GetDBConnection();
            currencyList = new List<CurrencyModel> { };

            //ControlSomeForm = _mf;
        }


        

        /* Преобразовываем все валюты под доллар, просто поделив на значение доллара.
         * Да, точности нет, т.к. курс не тот. Но лучшего пока не нашел, а погрешность состовляет пару центов.
         * Поскольку у меня не строгий финансовый инструмент, пока это допущение вполне имеет право на жизнь.
        */
        private bool CurrencyConversion(List<KeyValuePair<string, decimal>> _list)
        {
            currenciesList = new List<listElement> { };
            double usdValue = -1;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Key.Equals("USD"))
                {
                    usdValue = (double)_list[i].Value;
                }
            }
            if (usdValue > 0)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    currenciesList.Add(new listElement());
                    var val = currenciesList[currenciesList.Count - 1];
                    val.key = _list[i].Key.ToString();
                    val.val = Math.Round((double)_list[i].Value / usdValue, 4);
                    currenciesList[currenciesList.Count - 1] = val;
                }

                return true;
            }
            return false;
        }

        /* Получаем курс валют относительно евро */
        private static List<KeyValuePair<string, decimal>> GetCurrencyListFromWeb(out DateTime currencyDate)
        {
            List<KeyValuePair<string, decimal>> returnList = new List<KeyValuePair<string, decimal>>();
            string date = string.Empty;
            using (XmlReader xmlr = XmlReader.Create(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"))
            {
                xmlr.ReadToFollowing("Cube");
                while (xmlr.Read())
                {
                    if (xmlr.NodeType != XmlNodeType.Element) continue;
                    if (xmlr.GetAttribute("time") != null)
                    {
                        date = xmlr.GetAttribute("time");
                    }
                    else returnList.Add(new KeyValuePair<string, decimal>(xmlr.GetAttribute("currency"), decimal.Parse(xmlr.GetAttribute("rate"), CultureInfo.InvariantCulture)));
                }
                currencyDate = DateTime.Parse(date);
            }
            returnList.Add(new KeyValuePair<string, decimal>("EUR", 1));
            return returnList;
        }


        /* Обновляем значения в БД полученными выше*/
        public int UpdateCurrencies()
        {
            bool result = false;
            DateTime dt = new DateTime();
            string sqlStatement = "";
            string specifier = "G";

            result = CurrencyConversion(GetCurrencyListFromWeb(out dt));
            
            if (result)
            {
                try
                {
                    for (int i = 0; i < currenciesList.Count; i++)
                    {
                        if (currenciesList[i].key.Equals("CAD"))
                        {
                            sqlStatement = "INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value]) VALUES ('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', " + 124 + ", 'CAD', " + 1 + ", 'Канадский доллар', " + currenciesList[i].val.ToString(specifier, CultureInfo.InvariantCulture) + ")";
                            command = new SqlCommand(sqlStatement, connection);
                            if (Execute_INSERT_Command(command) != 1)
                                return 0;
                        }
                        if (currenciesList[i].key.Equals("AUD"))
                        {
                            sqlStatement = "INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value]) VALUES ('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', " + 036 + ", 'AUD', " + 1 + ", 'Австралийский доллар', " + currenciesList[i].val.ToString(specifier, CultureInfo.InvariantCulture) + ")";
                            command = new SqlCommand(sqlStatement, connection);
                            if (Execute_INSERT_Command(command) != 1)
                                return 0;
                        }
                        if (currenciesList[i].key.Equals("MXN"))
                        {
                            sqlStatement = "INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value]) VALUES ('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', " + 484 + ", 'MXN', " + 1 + ", 'Мексиканский песо', " + currenciesList[i].val.ToString(specifier, CultureInfo.InvariantCulture) + ")";
                            command = new SqlCommand(sqlStatement, connection);
                            if (Execute_INSERT_Command(command) != 1)
                                return 0;
                        }
                    }
                    return 1;
                }
                catch (Exception ex) { return 0; }
            }
            else
                return 0;
        }




        public int GetLastDateValues()
        {
            string sqlStatement = "SELECT * FROM [Currency] WHERE [UpdateDate] = (SELECT min([UpdateDate]) FROM [Currency])";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }









        /* Выполняем запрос к БД и заносим полученные данные в List<ProductsModel> */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetCurrencyToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                //if (ControlSomeForm != null)                       //вызывает нужный метод в зависимости, из какой формы нас вызывают
                //    ControlSomeForm.GetCurrencyFromDB(currencyList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Заносим данные в List<ProductsModel> */
        private void SetCurrencyToList(IDataRecord record)
        {
            CurrencyModel currModel = new CurrencyModel();
            currencyList.Add(currModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                currencyList[currencyList.Count - 1].WriteData(i, record[i]);
            }
        }























        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
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
    }
}
