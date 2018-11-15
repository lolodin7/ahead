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
    public partial class ProductsView : Form
    {
        private SqlConnection connection;
        private int ProductId;
        private int CurrentEditingRowIndex;     //для хранения номера строки во время редактирования
        private int NewProductCount;
        private int LastProductId;              //для корректного присвоения ProductId для новых товаров 
        MainForm mf;

        public ProductsView(MainForm _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            CurrentEditingRowIndex = -1;
            NewProductCount = 0;
            mf = _mf;

            GetProducts();
            GetProductTypes();
        }

        public ProductsView()
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            CurrentEditingRowIndex = -1;
            NewProductCount = 0;

            GetProducts();
            GetProductTypes();
        }

        /* Получаем список товаров с БД */
        private void GetProducts()
        {
            try
            {
                dgv_Products.Rows.Clear();

                connection.Open();
                string sqlStatement = "SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId WHERE Products.ProductId > 0";
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsTo_dgv_Products((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                LastProductId = int.Parse(dgv_Products.Rows[dgv_Products.RowCount - 1].Cells[0].Value.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заносим построчно товары в таблицу dgv_Product */
        private void SetProductsTo_dgv_Products(IDataRecord record)
        {
            var index = dgv_Products.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_Products.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Получаем список существующих типов товаров из БД */
        private void GetProductTypes()
        {
            try
            {
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
                FillProductTypesTo_cb_ProductTypes();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заносим построчно типы товаров в таблицу dgv_ProductTypes */
        private void SetProductTypesTo_dgv_ProductTypes(IDataRecord record)
        {
            var index = dgv_ProductTypes.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_ProductTypes.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем cb_ProductTypes существующими типами продуктов */
        private void FillProductTypesTo_cb_ProductTypes()
        {
            cb_editing_ProductTypes.Items.Clear();

            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                cb_editing_ProductTypes.Items.Add(dgv_ProductTypes.Rows[i].Cells[1].Value.ToString());
                cb_adding_ProductTypes.Items.Add(dgv_ProductTypes.Rows[i].Cells[1].Value.ToString());
            }

            cb_editing_ProductTypes.SelectedItem = dgv_ProductTypes.Rows[0].Cells[1].Value.ToString();
            cb_adding_ProductTypes.SelectedItem = dgv_ProductTypes.Rows[0].Cells[1].Value.ToString();
        }

        /* Вызов справка */
        private void btn_Help_Click(object sender, EventArgs e)
        {
            string str1 = "Дважды ЛКМ по товару в таблице, чтобы перейти в режим его редактирования.\n";
            string str2 = "\nПКМ по товару для его удаления.\n";
            MessageBox.Show(str1 + str2, "Справка");
        }

        /* Включаем режим редактировани выбранного в таблице товара */
        private void dgv_Products_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_editing_ProductName.Enabled = true;
            tb_editing_ASIN.Enabled = true;
            tb_editing_SKU.Enabled = true;
            cb_editing_ProductTypes.Enabled = true;
            btn_SaveEditing.Enabled = true;
            btn_CancelEditing.Enabled = true;

            tb_editing_ProductId.Text = dgv_Products.Rows[e.RowIndex].Cells[0].Value.ToString();
            tb_editing_ProductName.Text = dgv_Products.Rows[e.RowIndex].Cells[1].Value.ToString();
            tb_editing_ASIN.Text = dgv_Products.Rows[e.RowIndex].Cells[2].Value.ToString(); 
            tb_editing_SKU.Text = dgv_Products.Rows[e.RowIndex].Cells[3].Value.ToString();
            tb_editing_ProductTypeId.Text = dgv_Products.Rows[e.RowIndex].Cells[4].Value.ToString();

            for (int i = 0; i < cb_editing_ProductTypes.Items.Count; i++)
            {
                if (dgv_Products.Rows[e.RowIndex].Cells[6].Value.ToString().Equals(cb_editing_ProductTypes.Items[i].ToString()))
                {
                    cb_editing_ProductTypes.SelectedItem = cb_editing_ProductTypes.Items[i];
                }
            }

            CurrentEditingRowIndex = e.RowIndex;

            groupBox2.Enabled = false;
        }

        /* Сохраняем изменения */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!tb_editing_ProductName.Text.Equals("") && !tb_editing_ASIN.Text.Equals("") && !tb_editing_SKU.Text.Equals(""))
            {
                SetEditedProductToDB();
                RefreshFieldsAfterEditing();
                GetProducts();
            }
            else
                MessageBox.Show("Не все поля заполнены. Пожалуйста, заполните все поля чтобы продолжить.", "Ошибка");
        }

        /* Отменяем изменения */
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            RefreshFieldsAfterEditing();
        }

        /* Очищаем поля после отмены редактирования товара */
        private void RefreshFieldsAfterEditing()
        {
            tb_editing_ProductName.Enabled = false;
            tb_editing_ASIN.Enabled = false;
            tb_editing_SKU.Enabled = false;
            cb_editing_ProductTypes.Enabled = false;
            btn_SaveEditing.Enabled = false;
            btn_CancelEditing.Enabled = false;

            tb_editing_ProductId.Text = "";
            tb_editing_ProductName.Text = "";
            tb_editing_ASIN.Text = "";
            tb_editing_SKU.Text = "";
            tb_editing_ProductTypeId.Text = "";
            
            CurrentEditingRowIndex = -1;

            groupBox2.Enabled = true;
        }

        /* Сохраняем изменения в dgv_Products после редактирования товара */
        private void UpdateProductInDGV()
        {
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[0].Value = tb_editing_ProductId.Text;
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[1].Value = tb_editing_ProductName.Text;
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[2].Value = tb_editing_ASIN.Text;
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[3].Value = tb_editing_SKU.Text;
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[4].Value = tb_editing_ProductTypeId.Text;
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[5].Value = tb_editing_ProductTypeId.Text;
            dgv_Products.Rows[CurrentEditingRowIndex].Cells[6].Value = cb_editing_ProductTypes.SelectedItem.ToString();

            RefreshFieldsAfterEditing();
        }


        /* Сохраняем отредактированный товар в БД */
        private void SetEditedProductToDB()
        {
            string sqlStatement;
            try
            {
                connection.Open();

                sqlStatement = "UPDATE [Products] SET [Name] = '" + tb_editing_ProductName.Text + "', [ASIN] = '" + tb_editing_ASIN.Text + "', [SKU] = '" + tb_editing_SKU.Text + "', [ProductTypeId] = " + tb_editing_ProductTypeId.Text + " WHERE [ProductId] = " + tb_editing_ProductId.Text;

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте еще раз!", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Сохраняем удаленный товар в БД */
        private void SetDeletedProductToDB(int row)
        {
            string sqlStatement;
            try
            {
                connection.Open();

                sqlStatement = "UPDATE [Semantics] SET [ProductId] = 0 WHERE ProductId = " + dgv_Products.Rows[row].Cells[0].Value.ToString();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.ExecuteScalar();

                sqlStatement = "UPDATE [FieldsLength] SET [ProductId] = 0 WHERE ProductId = " + dgv_Products.Rows[row].Cells[0].Value.ToString();

                command = new SqlCommand(sqlStatement, connection);
                command.ExecuteScalar();

                sqlStatement = "DELETE FROM [Products] WHERE [ProductId] = " + dgv_Products.Rows[row].Cells[0].Value.ToString();

                command = new SqlCommand(sqlStatement, connection);
                command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте еще раз!", "Ошибка");
                MessageBox.Show(e.ToString());
                Environment.Exit(0);
            }
        }

        /* Чтобы при изменении в tb_editing_ProductTypeId появлялся корректный Id */
        private void cb_editing_ProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                if (cb_editing_ProductTypes.SelectedItem.ToString().Equals(dgv_ProductTypes.Rows[i].Cells[1].Value.ToString()))
                {
                    tb_editing_ProductTypeId.Text = dgv_ProductTypes.Rows[i].Cells[0].Value.ToString();
                }
            }
        }

        /* Делает активной ячейку под курсором */
        private void dgv_Products_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >=0)
                dgv_Products.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        /* Удаление товара по клику ПКМ в dgv_Products */
        private void dgv_Products_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgv_Products.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                if (MessageBox.Show("Товар \"" + dgv_Products.Rows[e.RowIndex].Cells[1].Value.ToString() + "\" будет удален навсегда. Вы уверены?", "Удаление товара", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SetDeletedProductToDB(e.RowIndex);
                    GetProducts();
                }
            }
        }

        /* Очищаем поля с данными нового товара */
        private void btn_ClearAdding_Click(object sender, EventArgs e)
        {
            tb_adding_ASIN.Text = "";
            tb_adding_ProductName.Text = "";
            tb_adding_SKU.Text = "";            
        }

        /* Чтобы при изменении в tb_adding_ProductTypeId появлялся корректный Id */
        private void cb_adding_ProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                if (cb_adding_ProductTypes.SelectedItem.ToString().Equals(dgv_ProductTypes.Rows[i].Cells[1].Value.ToString()))
                {
                    tb_adding_ProductTypeId.Text = dgv_ProductTypes.Rows[i].Cells[0].Value.ToString();
                }
            }
        }

        /* Сохраняем новый товар в БД */
        private void btn_SaveAdding_Click(object sender, EventArgs e)
        {
            if (!tb_adding_ProductName.Text.Equals("") && !tb_adding_ASIN.Text.Equals("") && !tb_adding_SKU.Text.Equals(""))
            {
                SetAddedProductToDB();

                tb_adding_ASIN.Text = "";
                tb_adding_ProductName.Text = "";
                tb_adding_SKU.Text = "";

                GetProducts();
            }
            else
                MessageBox.Show("Не все поля заполнены. Пожалуйста, заполните все поля чтобы продолжить.", "Ошибка");
        }

        /* Метод для сохранения нового товара в БД */
        private void SetAddedProductToDB()
        {
            string sqlStatement;
            try
            {
                connection.Open();
                sqlStatement = "INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId]) VALUES ('" + tb_adding_ProductName.Text + "', '" + tb_adding_ASIN.Text + "', '" + tb_adding_SKU.Text + "', " + tb_adding_ProductTypeId.Text + ")";

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте еще раз!", "Ошибка");
                Environment.Exit(0);
            }
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.Show();
        }
    }
}
