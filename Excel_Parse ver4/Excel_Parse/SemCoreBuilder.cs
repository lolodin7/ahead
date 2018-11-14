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
    class SemCoreBuilder
    {
        private SqlConnection connection;
        private DataGridView dgv;
        private SqlCommand command;

        public SemCoreBuilder(DataGridView _dgv)
        {
            connection = DBData.GetDBConnection();

            dgv = _dgv;
        }


        public void GetSemCoreByProductId(int _prodTypeId)
        {
            RefreshTable_6(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }
        

        public void GetSemCoreByCategoryId(int _catId)
        {
            RefreshTable_6(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore WHERE CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            RefreshTable_6(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId + " AND CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }

        //-------------LEFT JOIN STATEMENTS-----------------


        public void GetSemCoreJOINKeywordCategoryByProductId(int _prodTypeId)
        {
            AddColumns_10(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreJOINKeywordCategoryByCategoryId(int _catId)
        {
            AddColumns_10(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreJOINKeywordCategoryByProductAndCategoryId(int _prodTypeId, int _catId)
        {
            AddColumns_10(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + _prodTypeId + " AND SemCore.CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        public void GetSemCoreJOINKeywordCategoryAll()
        {
            AddColumns_10(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId";
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }


        /* Выполняем запрос к БД и заносим полученные данные в dataGridView */
        private bool ExecuteCommand(SqlCommand _command)
        {
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении данных произошла ошибка!", "Ошибка");
                return false;
            }
        }

        /* Заносим данные в таблицу построчно */
        private void SetDataTo_dgv(IDataRecord record)
        {
            var index = dgv.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Перерисовываем таблицу на 6 столбцов */
        public void RefreshTable_6()
        {
            dgv.Columns.Clear();
            AddColumns_6();
        }

        /* Перерисовываем таблицу на 10 столбцов */
        public void RefreshTable_10()
        {
            dgv.Columns.Clear();
            AddColumns_10();
        }


        /* Программно создаем столбцы в dataGridView */
        public void AddColumns_10()
        {
            dgv.Columns.Add("categoryIdCl", "categoryIdCl");
            dgv.Columns.Add("productTypeIdCl", "productTypeIdCl");
            dgv.Columns.Add("keywordCl", "Ключ");
            dgv.Columns.Add("valueCl", "Частота");
            dgv.Columns.Add("LastUpdatedCl", "Обновлено");
            dgv.Columns.Add("semCoreIdCl", "semCoreIdCl");
            dgv.Columns.Add("categIdCl", "categIdCl");
            dgv.Columns.Add("categNameCl", "Название категории");
            dgv.Columns.Add("prodTypeIdCl", "prodTypeIdCl");
            dgv.Columns.Add("prodTypeNameCl", "Вид товара");

            dgv.Columns[2].Width = 250;
            dgv.Columns[3].Width = 100;
            dgv.Columns[4].Width = 150;
            dgv.Columns[7].Width = 150;
            dgv.Columns[9].Width = 150;

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            dgv.Columns[8].Visible = false;
            
            dgv.Width = 860;
            dgv.ScrollBars = ScrollBars.Vertical;
        }


        /* Программно создаем столбцы в dataGridView */
        public void AddColumns_6()
        {
            dgv.Columns.Add("categoryIdCl", "categoryIdCl");
            dgv.Columns.Add("productTypeIdCl", "productTypeIdCl");
            dgv.Columns.Add("keywordCl", "Ключ");
            dgv.Columns.Add("valueCl", "Частота");
            dgv.Columns.Add("LastUpdatedCl", "Обновлено");
            dgv.Columns.Add("semCoreIdCl", "semCoreIdCl");

            dgv.Columns[2].Width = 250;
            dgv.Columns[3].Width = 100;
            dgv.Columns[4].Width = 150;

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[5].Visible = false;

            dgv.Width = 560;
            dgv.ScrollBars = ScrollBars.Vertical;
        }

    }
}
