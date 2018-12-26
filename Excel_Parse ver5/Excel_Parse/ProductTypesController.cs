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
    class ProductTypesController
    {
        private SqlConnection connection;
        private SqlCommand command;
        private ProductTypesView controlFormProductTypesView;        //для вызова методов из формы View (для передачи данных)
        private SemCoreView controlFormSemCoreView;
        private ProductsView controlFormProductsView;
        private FullSemCoreView controlFormFullSemCoreView;
        private SemCoreRebuildView controlFormSemCoreRebuildView;
        private KeywordCategoryView controlKeywordCategoryView;
        private SemanticsView controlSemanticsView;

        public List<ProductTypesModel> ptList;       //список объектов (по факту, каждый элемент - одна строка из БД)

        /* Конструктор */
        public ProductTypesController(ProductTypesView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormProductTypesView = _controlForm;
        }

        /* Конструктор */
        public ProductTypesController(SemanticsView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlSemanticsView = _controlForm;
        }

        /* Конструктор */
        public ProductTypesController(KeywordCategoryView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlKeywordCategoryView = _controlForm;
        }

        /* Конструктор */
        public ProductTypesController(SemCoreView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormSemCoreView = _controlForm;
        }

        /* Конструктор */
        public ProductTypesController(ProductsView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormProductsView = _controlForm;
        }

        /* Конструктор */
        public ProductTypesController(FullSemCoreView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormFullSemCoreView = _controlForm;
        }

        /* Конструктор */
        public ProductTypesController(SemCoreRebuildView _controlForm)
        {
            connection = DBData.GetDBConnection();
            controlFormSemCoreRebuildView = _controlForm;
        }

        public bool GetProductTypesAll()
        {
            string sqlStatement = "SELECT * FROM ProductTypes WHERE ProductTypeId > 0";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public bool GetProductTypesByProductId(int _prodTypeId)
        {
            string sqlStatement = "SELECT * FROM ProductTypes WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int SetNewProductType(string name)
        {
            string sqlStatement = "INSERT INTO [ProductTypes] ([TypeName]) VALUES ('" + name + "')";
            command = new SqlCommand(sqlStatement, connection);
            return (Execute_INSERT_Command(command));
        }

        //-------------------------------МЕТОДЫ----------------------------------------


        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private bool Execute_SELECT_Command(SqlCommand _command)
        {
            ptList = new List<ProductTypesModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

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

                if (controlFormProductTypesView != null)                               //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    controlFormProductTypesView.GetProductTypesFromDB(ptList);
                else if (controlFormSemCoreView != null)
                    controlFormSemCoreView.GetProductTypesFromDB(ptList);
                else if (controlFormProductsView != null)
                    controlFormProductsView.GetProductTypesFromDB(ptList);
                else if (controlFormFullSemCoreView != null)
                    controlFormFullSemCoreView.GetProductTypesFromDB(ptList);
                else if (controlFormSemCoreRebuildView != null)
                    controlFormSemCoreRebuildView.GetProductTypesFromDB(ptList);
                else if (controlKeywordCategoryView != null)
                    controlKeywordCategoryView.GettFullProductTypesFromDB(ptList);
                else if (controlSemanticsView != null)
                    controlSemanticsView.GetProductTypesFromDB(ptList);
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
        private void SetData(IDataRecord record)
        {
            ProductTypesModel ptModel = new ProductTypesModel();
            ptList.Add(ptModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                ptList[ptList.Count - 1].WriteData(i, record[i]);
            }
        }

        private void SetData(object[] arr)
        {
            ProductTypesModel ptModel = new ProductTypesModel();
            ptList.Add(ptModel);
            for (int i = 0; i < arr.Length; i++)
            {
                ptList[ptList.Count - 1].WriteData(i, arr[i]);
            }
        }
    }
}
