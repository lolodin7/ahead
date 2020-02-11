using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class AllOrdersView : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private List<AllOrdersModel> ordersList;
        private List<AllOrdersModel> newOrdersList;

        private int allLines;
        private int addedLines;
        private int updatedLines;

        private MainFormView mf;

        public AllOrdersView(MainFormView _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;

            DrawTable();
        }

        private void DrawTable()
        {
            dgv_mp.Rows.Clear();
            if (rb_PDW.Checked)
            {
                int index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.com";
                dgv_mp.Rows[index].Cells[1].Value = "1";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.ca";
                dgv_mp.Rows[index].Cells[1].Value = "2";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.com.au";
                dgv_mp.Rows[index].Cells[1].Value = "3";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.com.mx";
                dgv_mp.Rows[index].Cells[1].Value = "4";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.co.jp";
                dgv_mp.Rows[index].Cells[1].Value = "7";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Others";
                dgv_mp.Rows[index].Cells[1].Value = "8";
            }
            else if (rb_LTB.Checked)
            {
                int index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.com";
                dgv_mp.Rows[index].Cells[1].Value = "5";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Amazon.ca";
                dgv_mp.Rows[index].Cells[1].Value = "6";

                index = dgv_mp.Rows.Add();
                dgv_mp.Rows[index].Cells[0].Value = "Others";
                dgv_mp.Rows[index].Cells[1].Value = "8";
            }
        }

        /* Вытаскиваем строки из Excel */
        public void GetOrdersFromExcel()//bool update)
        {
            openFileDialog1.Filter = "Выбери файл|*.csv;*.txt;*.xlsx";
            openFileDialog1.Title = "Выбор файла для открытия";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@openFileDialog1.FileName)))
                {
                    label1.Text = @openFileDialog1.FileName;
                    ordersList = new List<AllOrdersModel> { };
                    allLines = 0;
                    addedLines = 0;
                    updatedLines = 0;

                    ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    AllOrdersModel checkFields = new AllOrdersModel();
                    if (end.Column != checkFields.FieldCount)
                    {
                        MessageBox.Show("Выбранный файл не соответствует нужному формату отчета. Возможно, ошибочно был загружен некорректный файл. Попробуйте загрузить корректный файл.", "Ошибка");
                        return;
                    }

                    progressBar1.Maximum = end.Row;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        AllOrdersModel om = new AllOrdersModel();
                        ordersList.Add(om);

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            ordersList[ordersList.Count - 1].WriteData(col - 1, workSheet.Cells[row, col].Text);
                        }
                        ordersList[ordersList.Count - 1].MarketPlaceId = GetMarketPlaceIdByName(ordersList[ordersList.Count - 1].SalesChannel);
                        allLines++;
                        progressBar1.Value++;
                        progressBar1.Refresh();
                    }
                    progressBar1.Visible = false;

                    //if (!update)
                        //SetNewOrdersToDB();
                }
            }
        }



        /* Получаем id маркетплейса по выбранному имени в combobox */
        private int GetMarketPlaceIdByName(string _name)
        {
            for (int i = 0; i < dgv_mp.Rows.Count - 1; i++)
            {
                if (dgv_mp.Rows[i].Cells[0].Value.ToString().Equals(_name))
                    return int.Parse(dgv_mp.Rows[i].Cells[1].Value.ToString());
            }
            return 8;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            GetOrdersFromExcel();
        }

        private void AllOrdersView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }

        private void btn_saveToDB_Click(object sender, EventArgs e)
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();
            int errors = 0;

            progressBar1.Maximum = ordersList.Count;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            string str = "";
            for (int i = 0; i < ordersList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation], [MarketPlaceId]) VALUES ('" + ordersList[i].AmazonOrderId + "', '" + ordersList[i].MerchantOrderId + "', '" + ordersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].OrderStatus + "', '" + ordersList[i].FullfilmentChannel + "', '" + ordersList[i].SalesChannel + "', '" + ordersList[i].OrderChannel + "', '" + ordersList[i].Url + "', '" + ordersList[i].ShipServiceLevel + "', '" + ordersList[i].ProductName + "', '" + ordersList[i].Sku + "', '" + ordersList[i].Asin + "', '" + ordersList[i].ItemStatus + "', " + ordersList[i].Quantity + ", '" + ordersList[i].Currency + "', " + ordersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + ordersList[i].ShipCity + "', '" + ordersList[i].ShipState + "', '" + ordersList[i].ShipPostalCode + "', '" + ordersList[i].ShipCountry + "', '" + ordersList[i].PromotionIds + "', '" + ordersList[i].IsBusinessOrder + "', '" + ordersList[i].PurchaseOrderNumber + "', '" + ordersList[i].PriceDesignation + "', " + ordersList[i].MarketPlaceId + ")";
                
                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                    addedLines++;
                }
                catch (Exception ex)
                {
                    //errors++;
                    //str += ex.Message+ "\n";
                }

                progressBar1.Value++;
                progressBar1.Refresh();
            }
            Console.WriteLine(str);
            progressBar1.Visible = false;
            connection.Close();
            MessageBox.Show("Добавление прошло успешно!\nВсего строк: " + allLines + "\nДобавлено новых строк: " + addedLines + "\nОбновлено строк: " + updatedLines + "\nErrors: " + errors);
        }

        private void rb_LTB_CheckedChanged(object sender, EventArgs e)
        {
            DrawTable();
        }
    }
}
