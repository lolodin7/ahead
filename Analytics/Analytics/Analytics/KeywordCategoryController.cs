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
    class KeywordCategoryController
    {
        private SqlConnection connection;
        private SqlCommand command;
        private KeywordCategoryView controlFormKeywordCategoryView;        //для вызова методов из формы View (для передачи данных)
        private SemCoreView controlFormSemCoreView;
        private FullSemCoreView controlFormFullSemCoreView;
        private SemCoreRebuildView controlFormSemCoreRebuildView;


        public List<KeywordCategoryModel> kcList;       //список объектов (по факту, каждый элемент - одна строка из БД)

        /* Конструктор */
        public KeywordCategoryController(KeywordCategoryView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormKeywordCategoryView = _controlForm;
        }

        /* Конструктор */
        public KeywordCategoryController(SemCoreView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormSemCoreView = _controlForm;            
        }

        /* Конструктор */
        public KeywordCategoryController(FullSemCoreView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormFullSemCoreView = _controlForm;
        }

        /* Конструктор */
        public KeywordCategoryController(SemCoreRebuildView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormSemCoreRebuildView = _controlForm;
        }

        public bool GetKeywordCategoriesAll()
        {
            string sqlStatement = "SELECT * FROM KeywordCategory WHERE CategoryId > 0";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public bool GetKeywordCategoriesByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM KeywordCategory WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public bool GetKeywordCategoriesByCategoryId(int _categoryId)
        {
            string sqlStatement = "SELECT * FROM KeywordCategory WHERE CategoryId = " + _categoryId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int SetNewKeywordCategory(string name)
        {
            string sqlStatement = "INSERT INTO [KeywordCategory] ([CategoryName]) VALUES ('" + name + "')";     //переделать, т.к. теперь нужно указывать еще и productTypeId
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_Command(command);
        }

        //-------------------------------МЕТОДЫ----------------------------------------


        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private bool Execute_SELECT_Command(SqlCommand _command)
        {
            kcList = new List<KeywordCategoryModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlFormKeywordCategoryView != null)                       //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    controlFormKeywordCategoryView.GetCategoriesFromDB(kcList);
                else if (controlFormSemCoreView != null)
                    controlFormSemCoreView.GetCategoriesFromDB(kcList);
                else if (controlFormFullSemCoreView != null)
                    controlFormFullSemCoreView.GetCategoriesFromDB(kcList);
                else if (controlFormSemCoreRebuildView != null)
                    controlFormSemCoreRebuildView.GetCategoriesFromDB(kcList);
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
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

        /* Заносим данные в List<SemCoreModel> */
        private void SetDataToList(IDataRecord record)
        {
            KeywordCategoryModel kcModel = new KeywordCategoryModel();
            kcList.Add(kcModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                kcList[kcList.Count - 1].WriteData(i, record[i]);
            }
        }

        private void SetDataToList(object[] arr)
        {
            KeywordCategoryModel kcModel = new KeywordCategoryModel();
            kcList.Add(kcModel);
            for (int i = 0; i < arr.Length; i++)
            {
                kcList[kcList.Count - 1].WriteData(i, arr[i]);
            }
        }

    }
}
