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
    public partial class IndexingStatus : Form
    {
        private string ProductName;
        private int ProductId;
        private string ASIN;
        private string SKU;
        private DateTime Date;

        private List<int> ProductIds;

        private SqlConnection connection;
        private SqlCommand command;

        private IndexingView controlIndexingView;

        private bool firstLoad;     //первая запуск формы, или нет

        public IndexingStatus(int _productId, string _asin, string _sku, string _productName, IndexingView _mf, DateTime _dt)
        {
            InitializeComponent();

            ProductId = _productId;
            ASIN = _asin;
            ProductName = _productName;
            SKU = _sku;
            Date = _dt;

            connection = DBData.GetDBConnection();

            controlIndexingView = _mf;
            firstLoad = true;

            GetAllProductWithSameASIN();

            this.Text = ProductName + " : " + ASIN;
        }


        /* Статус Ок (всё хорошо) */
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //сохраняем в БД со статусом Ок без каких-либо Notes
            for (int i = 0; i < ProductIds.Count; i++)
            {
                string sqlStatement = "INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status], [Notes]) VALUES (" + ProductId + ", '" + ASIN + "', '" + Date.ToString("yyyy-MM-dd") + "', 'Ok', '')";

                command = new SqlCommand(sqlStatement, connection);

                connection.Open();
                command.ExecuteScalar();
                connection.Close();
            }

            //если всё хорошо, то
            this.Close();
        }

        /* Статус Closed (листинг закрыт) */
        private void btn_Closed_Click(object sender, EventArgs e)
        {
            //сохраняем в БД со статусом Closed без каких-либо Notes
            for (int i = 0; i < ProductIds.Count; i++)
            {
                string sqlStatement = "INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status], [Notes]) VALUES (" + ProductId + ", '" + ASIN + "', '" + Date.ToString("yyyy-MM-dd") + "', 'Closed', '')";

                command = new SqlCommand(sqlStatement, connection);

                connection.Open();
                command.ExecuteScalar();
                connection.Close();
            }
            //если всё хорошо, то
            this.Close();
        }

        /* Статус Not Ok (не всё хорошо, открываем форму для внесения пометок) */
        private void btn_NotOk_Click(object sender, EventArgs e)
        {
            IndexingDetails id = new IndexingDetails(ProductId, ASIN, SKU, ProductName, this, Date);

            id.Show();

            this.Visible = false;
        }


        /* Закрытие формы */
        private void IndexingStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlIndexingView.Visible = true;
        }
        
        /* Изменение видимости формы */
        private void IndexingStatus_VisibleChanged(object sender, EventArgs e)
        {
            if (!firstLoad)     //если не первый запуск формы
            {
                if (this.Visible == true)       //если из "невидимого" изменились на "видимого"
                {
                    this.Close();
                }
            } 
            else            //если первый запуск формы
            {
                firstLoad = false;
            }
        }


        /* Получаем список всех товаров с таким же ASIN, чтобы потом продублировать индексацию на них, т.к. один ASIN = один товар и не важно, что SKU разные */
        private void GetAllProductWithSameASIN()
        {
            string sqlStatements;
            sqlStatements = "SELECT [ProductId] FROM [Products] WHERE [ASIN] = '" + ASIN + "'";
            IDataRecord record;
            ProductIds = new List<int> { };

            SqlCommand command = new SqlCommand(sqlStatements, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        record = (IDataRecord)reader;
                        ProductIds.Add(int.Parse(record[0].ToString()));
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
                this.Close();
            }
        }
    }
}
