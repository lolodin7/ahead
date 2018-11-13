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
    class ProductTypesBuilder
    {
        private SqlConnection connection;
        private DataGridView dgv;
        private SqlCommand command;

        public ProductTypesBuilder(DataGridView _dgv)
        {
            connection = DBData.GetDBConnection();

            dgv = _dgv;
        }


        public void GetProductTypesAll()
        {
            RefreshTable_2(); //по умолчанию

            string sqlStatement = "SELECT * FROM ProductTypes WHERE [ProductTypeId] > 0";
            command = new SqlCommand(sqlStatement, connection);
            ExecuteCommand(command);
        }





        //-------------------------------МЕТОДЫ----------------------------------------


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
        public void RefreshTable_2()
        {
            dgv.Columns.Clear();
            AddColumns_2();
        }

        /* Программно создаем столбцы в dataGridView */
        public void AddColumns_2()
        {
            dgv.Columns.Add("categoryIdCl", "categoryIdCl");
            dgv.Columns.Add("categoryNameCl", "Название категории");

            dgv.Columns[1].Width = 150;

            dgv.Columns[0].Visible = false;

            dgv.Width = 210;
            dgv.ScrollBars = ScrollBars.Vertical;
        }
    }
}
