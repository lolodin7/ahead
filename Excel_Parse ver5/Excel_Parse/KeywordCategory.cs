using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class KeywordCategory : Form
    {
        private Form mf;
        private SqlConnection connection;


        public KeywordCategory(Form _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;

            GetKeywordCategory();
        }

        /* Заполняем таблицу dgv_KeywordCategory */
        private void GetKeywordCategory()
        {
            try
            {
                dgv_KeywordCategory.Rows.Clear();

                connection.Open();
                string sqlStatement = "SELECT * FROM KeywordCategory WHERE CategoryId > 0";
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetKeywordCategoriesTo_dgv_KeywordCategory((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        private void SetKeywordCategoriesTo_dgv_KeywordCategory(IDataRecord record)
        {
            var index = dgv_KeywordCategory.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_KeywordCategory.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Добавить новую категори в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_CategoryName.Text != "")
            {
                if (!ChechForExisting())
                {
                    string sqlStatement;
                    try
                    {
                        connection.Open();
                        sqlStatement = "INSERT INTO [KeywordCategory] ([CategoryName]) VALUES ('" + tb_CategoryName.Text + "')";

                        SqlCommand command = new SqlCommand(sqlStatement, connection);
                        command.ExecuteScalar();

                        connection.Close();

                        tb_CategoryName.Text = "";
                        GetKeywordCategory();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте еще раз!", "Ошибка");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    MessageBox.Show("Такая категория уже существует!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите название новой категории.", "Ошибка");
            }
        }

        /* Проверка перед сохранение в БД на наличие существующей категории с таким же именем */
        private bool ChechForExisting()
        {
            bool flag = false;

            for (int i = 0; i < dgv_KeywordCategory.RowCount; i++)
            {
                if (dgv_KeywordCategory.Rows[i].Cells[1].Value.ToString().ToLower().Equals(tb_CategoryName.Text.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void KeywordCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        /* Закрыть окно */
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Скопировать название категории по двойному ЛКМ на ячейку */
        private void dgv_KeywordCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var str = dgv_KeywordCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Clipboard.SetText(str);
        }
    }
}
