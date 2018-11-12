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
    public partial class FullSemCore : Form
    {
        private Form ControlForm;
        private SqlConnection connection;
        private string AllProductTypesCBName = "Все виды товаров";
        private string AllKeywordCategoriesCBName = "Все категории ключей";

        //WHERE SemCore.ProductTypeId = 1 AND SemCore.CategoryId = 2

        public FullSemCore(Form _form)
        {
            InitializeComponent();
            ControlForm = _form;
            connection = DBData.GetDBConnection();

            GetProductTypes();
            GetCategories();

            GetKeywords();
        }

        public FullSemCore()
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();

            GetProductTypes();
            GetCategories();

            GetKeywords();
        }

        /* Получаем значение productTypeId по выбранному названию в cb_ProductType */
        private int GetSelectedProductTypeId()
        {
            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                if (dgv_ProductTypes.Rows[i].Cells[1].Value.ToString().Equals(cb_ProductType.SelectedItem.ToString()))
                {
                    return int.Parse(dgv_ProductTypes.Rows[i].Cells[0].Value.ToString());
                }
            }
            return -1;
        }

        /* Получаем значение keywordCategoryId по выбранному названию в cb_KeywordCategory */
        private int GetSelectedCategoryId()
        {
            for (int i = 0; i < dgv_Categories.RowCount - 1; i++)
            {
                if (dgv_Categories.Rows[i].Cells[1].Value.ToString().Equals(cb_KeywordCategory.SelectedItem.ToString()))
                {
                    return int.Parse(dgv_Categories.Rows[i].Cells[0].Value.ToString());
                }
            }
            return -1;
        }

        /* Заполняем таблицу с ключами из БД */
        private void GetKeywords()
        {
            dgv_Keywords.Rows.Clear();

            bool AllKeys = false;

            //if (cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
            //{
            //    AllKeys = true;
            //}

            try
            {
                connection.Open();
                string sqlStatement = "";
                //if (!AllKeys)
                //{
                //    sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + GetSelectedProductTypeId() + " AND SemCore.CategoryId = " + GetSelectedCategoryId();
                //}
                //else
                //{
                    if (!cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
                    {
                        sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + GetSelectedProductTypeId();
                    }
                    else if (cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && !cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
                    {
                        sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.CategoryId = " + GetSelectedCategoryId();
                    }
                    else if (!cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && !cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
                    {
                        sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE SemCore.ProductTypeId = " + GetSelectedProductTypeId() + " AND SemCore.CategoryId = " + GetSelectedCategoryId();
                    } else if (cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
                {
                    sqlStatement = "SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId";
                }
                //}
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetKeywordsTodgv_Keywords((IDataRecord)reader);
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

        private void SetKeywordsTodgv_Keywords(IDataRecord record)
        {
            var index = dgv_Keywords.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_Keywords.Rows[index].Cells[i].Value = record[i];
            }
        }

        private void FullSemCore_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ControlForm.Visible = true;
        }


        //-----------------------

        /* Загружем список типов продуктов из ProductTypes */
        private void GetProductTypes()
        {
            string sqlStatement = "SELECT * FROM ProductTypes WHERE [ProductTypeId] > 0";
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv_ProductTypes((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                SetDataTo_cb_ProductType();
            }
            catch (Exception ex) { }
        }

        /* Заполняем dgv_ProductTypes */
        private void SetDataTo_dgv_ProductTypes(IDataRecord record)
        {
            var index = dgv_ProductTypes.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_ProductTypes.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем cb_ProductType */
        private void SetDataTo_cb_ProductType()
        {
            cb_ProductType.Items.Clear();
            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                cb_ProductType.Items.Add(dgv_ProductTypes.Rows[i].Cells[1].Value.ToString());
            }

            cb_ProductType.Items.Add(AllProductTypesCBName);
            cb_ProductType.SelectedItem = cb_ProductType.Items[0];
        }


        /* Загружем список категорий ключей из KeywordCategories */
        private void GetCategories()
        {
            string sqlStatement = "SELECT * FROM KeywordCategory WHERE CategoryId > 0";
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv_Categories((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                SetDataTo_cb_KeywordCategory();
            }
            catch (Exception ex) { }
        }

        /* Заполняем dgv_Categories */
        private void SetDataTo_dgv_Categories(IDataRecord record)
        {
            var index = dgv_Categories.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_Categories.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем cb_KeywordCategory */
        private void SetDataTo_cb_KeywordCategory()
        {
            cb_KeywordCategory.Items.Clear();

            for (int i = 0; i < dgv_Categories.RowCount - 1; i++)
            {
                cb_KeywordCategory.Items.Add(dgv_Categories.Rows[i].Cells[1].Value.ToString());
            }

            cb_KeywordCategory.Items.Add(AllKeywordCategoriesCBName);
            cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_GetKeywords_Click(object sender, EventArgs e)
        {
            GetKeywords();
        }

        //-------------------
    }
}
