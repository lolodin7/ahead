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

        private TestForm controlForm;
        public List<SemCoreModel> scmList;


        public SemCoreController(TestForm _form)
        {
            connection = DBData.GetDBConnection();
            controlForm = _form;
        }

        public SemCoreController()
        {
            connection = DBData.GetDBConnection();
        }

        public void GetSemCoreByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }
        

        public void GetSemCoreByCategoryId(int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId + " AND CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }

        //-------------LEFT JOIN STATEMENTS-----------------


        public void GetSemCoreJOINKeywordCategoryByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreJOINKeywordCategoryByCategoryId(int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreJOINKeywordCategoryByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId + " AND SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreJOINKeywordCategoryAll()
        {
            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId";
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }
             

        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private void ExecuteCommand(SqlCommand _command)
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
                        testsetdata((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                
                controlForm.AddColumns_6();
                controlForm.RefreshData(scmList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении данных произошла ошибка!", "Ошибка");
            }
        }

        /* Заносим данные в List<SemCoreModel> */
        private void testsetdata(IDataRecord record)
        {
            SemCoreModel _scm = new SemCoreModel();
            scmList.Add(_scm);
            for (int i = 0; i < record.FieldCount; i++)
            {
                scmList[scmList.Count - 1].WriteData(i, record[i]);
            }
        }
    }
}
