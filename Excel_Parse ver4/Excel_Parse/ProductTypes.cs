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
    public partial class ProductTypes : Form
    {
        private MainForm mf;
        private SqlConnection connection;


        public ProductTypes(MainForm _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;

            GetProductTypes();
        }

        /* Заполняем таблицу dgv_ProductTypes */
        private void GetProductTypes()
        {
            try
            {
                dgv_ProductTypes.Rows.Clear();

                connection.Open();
                string sqlStatement = "SELECT * FROM ProductTypes WHERE ProductTypeId > 0";
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductTypesTo_dgv_ProductTypes((IDataRecord)reader);
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

        private void SetProductTypesTo_dgv_ProductTypes(IDataRecord record)
        {
            var index = dgv_ProductTypes.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_ProductTypes.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Добавить новую категори в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_ProductType.Text != "")
            {
                if (!ChechForExisting())
                {
                    string sqlStatement;
                    try
                    {
                        connection.Open();
                        sqlStatement = "INSERT INTO [ProductTypes] ([TypeName]) VALUES ('" + tb_ProductType.Text + "')";

                        SqlCommand command = new SqlCommand(sqlStatement, connection);
                        command.ExecuteScalar();

                        connection.Close();

                        tb_ProductType.Text = "";
                        GetProductTypes();
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

            for (int i = 0; i < dgv_ProductTypes.RowCount; i++)
            {
                if (dgv_ProductTypes.Rows[i].Cells[1].Value.ToString().ToLower().Equals(tb_ProductType.Text.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void ProductTypes_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        /* Закрыть окно */
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Скопировать название категории по двойному ЛКМ на ячейку */
        private void dgv_ProductTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var str = dgv_ProductTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Clipboard.SetText(str);
        }

    }
}
