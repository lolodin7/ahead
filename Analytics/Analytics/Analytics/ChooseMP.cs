using Excel_Parse;
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

namespace Analytics
{
    public partial class ChooseMP : Form
    {
        private SqlConnection connection;
        private MainFormView mainForm;
        private AnalyticsForm analyticsForm;
        private bool OpenSuccess = false;


        public ChooseMP(MainFormView _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mainForm = _mf;
            getMarketplaces();
        }

        public ChooseMP(AnalyticsForm _af)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            analyticsForm = _af;
            getMarketplaces();
        }


        private void getMarketplaces()
        {
            string sqlSemanticsIds = "SELECT * FROM Marketplace WHERE [MarketplaceId] > 1";
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

        /* Заполняем dgv_Products, содержащую инфо о продукте */
        private void SetProductsToDataGrid(IDataRecord record)
        {
            var index = dataGridView1.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dataGridView1.Rows[index].Cells[i].Value = record[i];
            }
        }



        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (analyticsForm != null)
            {
                //PnL pnl = new PnL(this, dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[3].Value.ToString());
                PnL pnl = new PnL(this, dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString(), int.Parse(dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString()));
                pnl.Show();
                this.Hide();
            } 
            else if (mainForm != null)
            {

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseMP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OpenSuccess)
            {
                if (analyticsForm != null)
                    analyticsForm.Show();
                else if (mainForm != null)
                    mainForm.Show();
            }
        }
    }
}
