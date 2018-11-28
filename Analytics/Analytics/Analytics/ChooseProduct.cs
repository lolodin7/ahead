using Analytics;
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
    public partial class ChooseProduct : Form
    {
        private SqlConnection connection;
        public int ProductId { get; set; }
        private MainFormView mf;
        private AnalyticsForm analyticsForm;
        private bool OpenSuccess;
        private bool bySKU = false;
        private bool byASIN = false;

        public ChooseProduct(MainFormView _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;
            OpenSuccess = false;

            getDBProductInfo();
        }

        public ChooseProduct(AnalyticsForm _analyticsForm, string _value)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            analyticsForm = _analyticsForm;
            OpenSuccess = false;

            if (_value.Equals("sku"))
                bySKU = true;
            else
                byASIN = true;
            if (bySKU)
                getDBProductInfo();
            else if (byASIN)
                getDBProductASINInfo();
        }

        private void getDBProductASINInfo()
        {
            string sqlSemanticsIds = "SELECT * FROM Products WHERE [ProductId] > 0";            //ТУТ НУЖНО БУДЕТ ПОМЕНЯТЬ ЗАПРОС ДЛЯ ВЫБОРКИ УНИКАЛЬНЫЙ ASIN
            SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToDataGrid((IDataRecord)reader);
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

        /* Заполняем поля на форме инфо о продукте */
        private void getDBProductInfo()
        {
            string sqlSemanticsIds = "SELECT * FROM Products WHERE [ProductId] > 0";
            SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToDataGrid((IDataRecord)reader);
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

        /* Заполняем "невидимую" dgv_Products, содержащую инфо о продукте */
        private void SetProductsToDataGrid(IDataRecord record)
        {
            var index = dgv_Products.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_Products.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Открываем семантику для выбранного товара */
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (analyticsForm != null)
            {                
                PnL pnl = new PnL(this, dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[3].Value.ToString(););
                pnl.Show();
                this.Hide();
            }
            else if (mf != null)
            {

                ProductId = int.Parse(dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[0].Value.ToString());

                string sqlSemanticsIds = "SELECT * FROM Semantics WHERE [ProductId] = " + ProductId;
                SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //Semantics semantics = new Semantics(ProductId, mf);
                        OpenSuccess = true;
                        //semantics.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("У данного товара пока что нет ни одной семантики", "Ошибка");
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                    Environment.Exit(0);
                }
            }
        }

        private void ChooseProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OpenSuccess)
            {
                if (analyticsForm != null)
                    analyticsForm.Show();
                else if (mf != null)
                    mf.Show();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
