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
    public partial class IndexingDetails : Form
    {
        private string ProductName;
        private int ProductId;
        private string ASIN;
        private DateTime Date;
        private string Notes;           //для работы анализатора по разбиению/склейке инфы

        private IndexingStatus controlIndexingStatus;
        private IndexingView controlIndexingView;

        private SqlConnection connection;
        private SqlCommand command;

        private string Status = "Not Ok";           //статус, который заносим в БД

        private bool isSaved;           //проверка, чтобы не выйти без сохранения

        /* Конструктор, если будем сохранять результаты индексации в БД */
        public IndexingDetails(int _productId, string _asin, string _productName, IndexingStatus _mf)
        {
            InitializeComponent();

            ProductId = _productId;
            ASIN = _asin;
            ProductName = _productName;

            controlIndexingStatus = _mf;
            connection = DBData.GetDBConnection();

            isSaved = false;

            this.Text = ProductName + " : " + ASIN;
        }

        /* Конструктор, просто смотрим результаты индексации за какое-то число */
        public IndexingDetails(int _productId, string _asin, string _productName, IndexingView _mf, DateTime _date)
        {
            InitializeComponent();

            ProductId = _productId;
            ASIN = _asin;
            ProductName = _productName;
            Date = _date;

            controlIndexingView = _mf;
            connection = DBData.GetDBConnection();

            this.Text = ProductName + " : " + ASIN;
            btn_Save.Visible = false;

            isSaved = true;

            //тут метод для заполнения всех полей
            getDetailsFromDB();
        }

        /* Получаем все данные из БД и заносим их по полям на форме */
        private void getDetailsFromDB()
        {
            tb_Title.Enabled = false;
            tb_Bullet1.Enabled = false;
            tb_Bullet2.Enabled = false;
            tb_Bullet3.Enabled = false;
            tb_Bullet4.Enabled = false;
            tb_Bullet5.Enabled = false;
            tb_Backend.Enabled = false;

            //получаем все поля из БД и заполняем форму
            GetNotesFromDB();       //получаем Notes из БД
            RunNotesAnalyser();     //разбивает Notes и заносим по полям
        }

        /* Получаем Notes из БД */
        private void GetNotesFromDB()
        {
            string sqlStatement = "SELECT [Notes] FROM [Indexing] WHERE ProductId = " + ProductId + " AND [Date] = '" + Date.ToString("yyyy-MM-dd") +"'";

            command = new SqlCommand(sqlStatement, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;

                    Notes = record[0].ToString();
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connection.Close();
        }

        /* Разбиваем текст в Notes по полям */
        private void RunNotesAnalyser()
        {
            string field = "";
            int fieldNumber = 0;

            for (int i = 0; i < Notes.Length; i++)
            {
                if (!Notes[i].Equals('@') && i + 1 < Notes.Length)
                    field += Notes[i];
                else
                {
                    switch (fieldNumber)
                    {
                        case 0:
                            tb_Title.Text = field;
                            break;
                        case 1:
                            tb_Bullet1.Text = field;
                            break;
                        case 2:
                            tb_Bullet2.Text = field;
                            break;
                        case 3:
                            tb_Bullet3.Text = field;
                            break;
                        case 4:
                            tb_Bullet4.Text = field;
                            break;
                        case 5:
                            tb_Bullet5.Text = field;
                            break;
                        case 6:
                            tb_Backend.Text = field;
                            break;
                    }
                    fieldNumber++;
                    field = "";
                }
            }
        }


        /*  */
        private void RunNotesCompress()
        {
            Notes = tb_Title.Text + "@" + tb_Bullet1.Text + "@" + tb_Bullet2.Text + "@" + tb_Bullet3.Text + "@" + tb_Bullet4.Text + "@" + tb_Bullet5.Text + "@" + tb_Backend.Text + "@";
        }


        /* Сохраняем данные в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы собираетесь сохранить все введенные данные. Продолжить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //тут функция преобразования текста из полей в формат по шаблону для БД
                RunNotesCompress();
                //сохраняем статус, дату, текст в БД
                string sqlStatement = "INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status], [Notes]) VALUES (" + ProductId + ", '" + ASIN + "', '" + Date.ToString("yyyy-mm-dd") + "', 'Not Ok', '" + Notes + "')";
                
                command = new SqlCommand(sqlStatement, connection);

                connection.Open();
                command.ExecuteScalar();
                connection.Close();

                //если всё прошло хорошо, то {
                MessageBox.Show("Все данные сохранены успешно!", "Успешно");
                isSaved = true;
                this.Close();
                //}
            }
        }

        /* Закрытие формы */
        private void IndexingDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSaved)
            {
                if (controlIndexingStatus != null)
                    controlIndexingStatus.Visible = true;
                else
                    controlIndexingView.Visible = true;
            }
            else
            {
                MessageBox.Show("Перед выходом сохраните, пожалуйста, данные!", "Ошибка");
                e.Cancel = true;
            }
        }
    }
}
