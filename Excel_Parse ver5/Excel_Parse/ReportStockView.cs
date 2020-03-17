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
    public partial class ReportStockView : Form
    {
        private MainFormView mf;
        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private ReportStockController stockController;
        private List<StockModel> stockList;

        private SqlConnection connection;
        private SqlCommand command;

        private DateTime latestDate;

        private List<AllOrdersModel> sales7daysList;
        private List<AllOrdersModel> sales30daysList;

        private bool filterEnabled;

        /* Конструктор */
        public ReportStockView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;
            connection = DBData.GetDBConnection();
            cb_FilterParameter.SelectedIndex = 0;

            mpController = new MarketplaceController(this);
            prodController = new ProductsController(this);
            stockController = new ReportStockController(this);

            stockList = new List<StockModel> { };
            pList = new List<ProductsModel> { };
            mpList = new List<MarketplaceModel> { };
            sales7daysList = new List<AllOrdersModel> { };
            sales30daysList = new List<AllOrdersModel> { };

            filterEnabled = false;

            if (mpController.GetMarketplaces() == 1)
                Fill_CB_Marketplace();

            prodController.GetProductsAllJOIN();
            stockController.GetStock(DateTime.Today.AddDays(-10), DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59));
            if (stockList.Count > 0)
            {
                GetLatestDateAndProcessStockList();
                CalcValues();
                DrawTableColumns();
                DrawTableValues();
            }
            else
            {
                dgv_Stock.Visible = false;
                label3.Visible = true;
                cb_MarketPlace.Enabled = false;
                cb_FilterParameter.Enabled = false;
                rtb_FilterParameterValue.Enabled = false;
                btn_GoFilter.Enabled = false;
            }
        }

        /* Заполняем combobox названиями маркетплейсов */
        private void Fill_CB_Marketplace()
        {
            cb_MarketPlace.Items.Clear();
            cb_MarketPlace.Items.Add("Все");

            for (int i = 0; i < mpList.Count; i++)
            {
                cb_MarketPlace.Items.Add(mpList[i].MarketPlaceName);
            }

            cb_MarketPlace.SelectedIndex = 0;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetStockFromDB(object _stockList)
        {
            stockList = (List<StockModel>)_stockList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetOrdersFromDB(object _allOrdersList)
        {
            //ordersList = (List<StockModel>)_allOrdersList;
        }

        /* Обработчик закрытия формы */
        private void ReportStockView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        /* Обрабатываем список стока, находим последнюю дату, выбираем значения в списке, которые соответствует этой дате */
        private void GetLatestDateAndProcessStockList()
        {
            if (stockList.Count > 0)
            {
                List<DateTime> datesList = new List<DateTime> { };
                List<StockModel> _stock = new List<StockModel> { };

                foreach (var t in stockList)
                {
                    datesList.Add(t.UpdateDate);
                }

                latestDate = datesList.Max();

                foreach (var t in stockList)
                {
                    if (t.UpdateDate == latestDate)
                        _stock.Add(t);
                }

                stockList.Clear();

                foreach (var stock in _stock)
                {
                    foreach (var product in pList)
                    {
                        if (stock.SKU.Equals(product.SKU) && stock.MarketPlaceId == product.MarketPlaceId)
                            stock.Name = product.Name;
                    }
                }

                foreach (var t in _stock)
                {
                    if (!t.Name.Equals(""))
                        stockList.Add(t);
                }

                _stock.Clear();

                this.Text = "Склад - " + latestDate.ToString().Substring(0, 10);
                lb_Info.Text = "По состоянию на:\n" + latestDate.ToString().Substring(0, 10);
            }
        }

        /* Получаем данные о продажа, считаем дни по формуле и сортируем stockList */
        private void CalcValues()
        {
            string sqlStatement = "";

            sales7daysList = new List<AllOrdersModel> { };
            sales30daysList = new List<AllOrdersModel> { };

            sqlStatement = "SELECT * FROM [Orders] WHERE [PurchaseDate] between '" + latestDate.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + latestDate.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd HH:mm:ss") + "'";

            command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetSalesToList((IDataRecord)reader, 7);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            sqlStatement = "SELECT * FROM [Orders] WHERE [PurchaseDate] between '" + latestDate.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + latestDate.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd HH:mm:ss") + "'";

            command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetSalesToList((IDataRecord)reader, 30);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            double sales7 = 0;
            double sales30 = 0;

            foreach (var stock in stockList)
            {
                sales7 = 0;
                sales30 = 0;

                foreach (var order in sales30daysList)
                {
                    if (stock.MarketPlaceId == order.MarketPlaceId && stock.SKU.Equals(order.Sku))
                    {
                        sales30 += order.Quantity;
                    }
                }

                foreach (var order in sales7daysList)
                {
                    if (stock.MarketPlaceId == order.MarketPlaceId && stock.SKU.Equals(order.Sku))
                    {
                        sales7 += order.Quantity;
                    }
                }

                stock.Sales30Days = (int)sales30;
                if (sales7 == 0 && sales30 == 0)
                    stock.DaysLeft = 0;
                else
                {
                    stock.DaysLeft = Math.Floor(stock.FulfillableItems / Math.Sqrt((Math.Pow((sales7 / 7), 2) + (Math.Pow((sales30 / 30), 2))) / 2));
                    stock.Average = Math.Round(Math.Sqrt((Math.Pow((sales7 / 7), 2) + (Math.Pow((sales30 / 30), 2))) / 2), 2);
                }
            }


            StockModel tmpObj;
            for (int i = 1; i < stockList.Count; i++)
            {
                for (int j = 0; j < stockList.Count - i; j++)
                {
                    if (stockList[j].DaysLeft > stockList[j + 1].DaysLeft)
                    {
                        tmpObj = stockList[j];
                        stockList[j] = stockList[j + 1];
                        stockList[j + 1] = tmpObj;
                    }
                }
            }

            List<StockModel> _tmpList = new List<StockModel> { };
            int cnt = stockList.Count;
            List<int> removeIndexes = new List<int> { };

            for (int i = 0; i < cnt; i++)
            {
                if (stockList[i].DaysLeft == 0)
                {
                    _tmpList.Add(stockList[i]);
                    removeIndexes.Add(i);
                }
            }
            for (int i = removeIndexes.Count - 1; i >= 0; i--)
            {
                stockList.RemoveAt(removeIndexes[i]);
            }
            foreach (var t in _tmpList)
            {
                stockList.Add(t);
            }
            _tmpList.Clear();
        }

        /* Заносим данные в List<AdvertisingProductsModel> */
        private void SetSalesToList(IDataRecord record, int _val)
        {
            AllOrdersModel adprModel = new AllOrdersModel();

            for (int i = 0; i < record.FieldCount; i++)
            {
                adprModel.WriteDataForUpdates(i, record[i]);
            }
            if (_val == 7)
                sales7daysList.Add(adprModel);
            else if (_val == 30)
                sales30daysList.Add(adprModel);
        }

        /* Рисуем структуру таблицы */
        private void DrawTableColumns()
        {
            dgv_Stock.Columns.Add("Name", "Name");
            dgv_Stock.Columns.Add("asin", "ASIN");
            dgv_Stock.Columns.Add("sku", "SKU");
            dgv_Stock.Columns.Add("fnsku", "FNSKU");
            dgv_Stock.Columns.Add("mp", "Marketplace");
            dgv_Stock.Columns.Add("fulfillable", "Fulfillable");
            dgv_Stock.Columns.Add("reserved", "Reserved");
            dgv_Stock.Columns.Add("inboundshipped", "Inbound (Shipped)");
            dgv_Stock.Columns.Add("inboundworking", "Inbound (Working)");
            dgv_Stock.Columns.Add("days", "Days left");
            dgv_Stock.Columns.Add("sales", "Sales (last 30 days)");
            dgv_Stock.Columns.Add("aver", "Average/day");

            dgv_Stock.Columns[0].Width = 200;
            dgv_Stock.Columns[4].Width = 150;

            dgv_Stock.Columns[5].Width = 80;
            dgv_Stock.Columns[6].Width = 80;
            dgv_Stock.Columns[7].Width = 80;
            dgv_Stock.Columns[8].Width = 80;
            dgv_Stock.Columns[9].Width = 80;
            dgv_Stock.Columns[10].Width = 80;
            dgv_Stock.Columns[11].Width = 80;

            dgv_Stock.Columns[9].DefaultCellStyle.BackColor = Color.LightGray;

            for (int i = 0; i < dgv_Stock.Columns.Count; i++)
            {
                dgv_Stock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 5)
                    dgv_Stock.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /* Заполняем таблицу данными */
        private void DrawTableValues()
        {
            dgv_Stock.Rows.Clear();

            if (stockList.Count > 0)
            {
                int index;
                foreach (var t in stockList)
                {
                    index = dgv_Stock.Rows.Add();

                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                }
            }
        }

        /* Получить название marketplace по MarketPlaceId */
        private string GetMarketplaceNameByMarketplaceId(int _mpId)
        {
            foreach (var t in mpList)
            {
                if (t.MarketPlaceId == _mpId)
                    return t.MarketPlaceName;
            }
            return "NOT_FOUND";
        }

        /* Получить название MarketPlaceId по marketplace*/
        private int GetMarketplaceIdByMarketplaceName(string _mpName)
        {
            foreach (var t in mpList)
            {
                if (t.MarketPlaceName.Equals(_mpName))
                    return t.MarketPlaceId;
            }
            return -1;
        }

        /* Обработчик изменения выделения в cb_Marketplace */
        private void cb_MarketPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawTableByMarketplace();
        }

        /* Перерисовка таблицы при изменении marketplace */
        private void RedrawTableByMarketplace()
        {
            if (stockList.Count > 0)
            {
                dgv_Stock.Rows.Clear();

                int index;
                if (cb_MarketPlace.SelectedIndex != 0)
                {
                    foreach (var t in stockList)
                    {
                        if (t.MarketPlaceId == GetMarketplaceIdByMarketplaceName(cb_MarketPlace.SelectedItem.ToString()))
                        {
                            index = dgv_Stock.Rows.Add();

                            dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                            dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                            dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                            dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                            dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                            dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                            dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                            dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                            dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                            dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                            dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                            dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                        }
                    }
                }
                else
                {
                    DrawTableValues();
                }
                FilterTheTable();
            }
        }

        /* Обработчик нажатия кнопки "Применить фильтр" */
        private void btn_GoFilter_Click(object sender, EventArgs e)
        {
            FilterTheTable();
        }

        /* Применение фильтра по нажатию кнопки Enter в richTextBox */
        private void rtb_FilterParameterValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FilterTheTable();
            }
        }
        
        /* Очистить фильтр */
        private void btn_ClearFilter_Click(object sender, EventArgs e)
        {
            filterEnabled = false;
            btn_ClearFilter.Visible = filterEnabled;
            rtb_FilterParameterValue.Text = "";
            FilterTheTable();
        }

        /* Метод фильтрации данных в таблице*/
        private void FilterTheTable()
        {
            if (stockList.Count > 0)
            {
                if (!rtb_FilterParameterValue.Text.Equals(""))
                {
                    filterEnabled = true;
                    btn_ClearFilter.Visible = filterEnabled;
                    string text = rtb_FilterParameterValue.Text.ToLower();
                    dgv_Stock.Rows.Clear();

                    int index;
                    if (cb_FilterParameter.SelectedIndex == 0)
                    {
                        if (cb_MarketPlace.SelectedIndex != 0)
                        {
                            foreach (var t in stockList)
                            {
                                if (t.MarketPlaceId == GetMarketplaceIdByMarketplaceName(cb_MarketPlace.SelectedItem.ToString()) && t.Name.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                        else
                        {
                            foreach (var t in stockList)
                            {
                                if (t.Name.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                    }
                    else if (cb_FilterParameter.SelectedIndex == 1)
                    {
                        if (cb_MarketPlace.SelectedIndex != 0)
                        {
                            foreach (var t in stockList)
                            {
                                if (t.MarketPlaceId == GetMarketplaceIdByMarketplaceName(cb_MarketPlace.SelectedItem.ToString()) && t.ASIN.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                        else
                        {
                            foreach (var t in stockList)
                            {
                                if (t.ASIN.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                    }
                    else if (cb_FilterParameter.SelectedIndex == 2)
                    {
                        if (cb_MarketPlace.SelectedIndex != 0)
                        {
                            foreach (var t in stockList)
                            {
                                if (t.MarketPlaceId == GetMarketplaceIdByMarketplaceName(cb_MarketPlace.SelectedItem.ToString()) && t.SKU.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                        else
                        {
                            foreach (var t in stockList)
                            {
                                if (t.SKU.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                    }
                    else if (cb_FilterParameter.SelectedIndex == 3)
                    {
                        if (cb_MarketPlace.SelectedIndex != 0)
                        {
                            foreach (var t in stockList)
                            {
                                if (t.MarketPlaceId == GetMarketplaceIdByMarketplaceName(cb_MarketPlace.SelectedItem.ToString()) && t.FNSKU.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                        else
                        {
                            foreach (var t in stockList)
                            {
                                if (t.FNSKU.ToLower().Contains(text))
                                {
                                    index = dgv_Stock.Rows.Add();

                                    dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                    dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                    dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                    dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                    dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                    dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                    dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                    dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                    dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                    dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                    dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                    dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                                }
                            }
                        }
                    }
                }
                else
                {
                    int index;
                    if (cb_MarketPlace.SelectedIndex != 0)
                    {
                        foreach (var t in stockList)
                        {
                            if (t.MarketPlaceId == GetMarketplaceIdByMarketplaceName(cb_MarketPlace.SelectedItem.ToString()))
                            {
                                index = dgv_Stock.Rows.Add();

                                dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                                dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                                dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                                dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                                dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                                dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                                dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                                dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                                dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                                dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                                dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                                dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                            }
                        }
                    }
                    else
                    {
                        foreach (var t in stockList)
                        {
                            index = dgv_Stock.Rows.Add();

                            dgv_Stock.Rows[index].Cells[0].Value = t.ReadData(2);
                            dgv_Stock.Rows[index].Cells[1].Value = t.ReadData(3);
                            dgv_Stock.Rows[index].Cells[2].Value = t.ReadData(4);
                            dgv_Stock.Rows[index].Cells[3].Value = t.ReadData(5);
                            dgv_Stock.Rows[index].Cells[4].Value = GetMarketplaceNameByMarketplaceId(int.Parse(t.ReadData(6).ToString()));
                            dgv_Stock.Rows[index].Cells[5].Value = t.ReadData(7);
                            dgv_Stock.Rows[index].Cells[6].Value = t.ReadData(8);
                            dgv_Stock.Rows[index].Cells[7].Value = t.ReadData(9);
                            dgv_Stock.Rows[index].Cells[8].Value = t.ReadData(10);
                            dgv_Stock.Rows[index].Cells[9].Value = t.ReadData(11);
                            dgv_Stock.Rows[index].Cells[10].Value = t.ReadData(12);
                            dgv_Stock.Rows[index].Cells[11].Value = t.ReadData(13);
                        }
                    }
                }
            }
        }
    }
}
