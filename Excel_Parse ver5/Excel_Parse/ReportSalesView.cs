using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class ReportSalesView : Form
    {
        private MainFormView mf;

        private bool dailyMode, weeklyMode, customMode;
        private DateTime StartDate, EndDate;

        private List<AllOrdersModel> ordersList;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private List<string> checkedMarkeplaces;
        private List<int> currentProductIds;
        private List<ProductsModel> checkedProducts, searchresultsCheckedProducts;

        public ReportSalesView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;


            ordersList = new List<AllOrdersModel> { };

            dailyMode = true;
            weeklyMode = false;
            customMode = false;
            //customMode = true;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = StartDate.ToString().Substring(0, 10);


            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
            currentProductIds = new List<int> { };

            mpController = new MarketplaceController(this);
            prodController = new ProductsController(this);

            checkedMarkeplaces = new List<string> { };
            checkedProducts = new List<ProductsModel> { };
            searchresultsCheckedProducts = new List<ProductsModel> { };

            if (mpController.GetMarketplaces() == 1)
                Fill_CLB_Marketplace();
        }

        /* Заполняем combobox названиями маркетплейсов */
        private void Fill_CLB_Marketplace()
        {
            clb_Marketplace.Items.Clear();

            for (int i = 0; i < mpList.Count; i++)
            {
                clb_Marketplace.Items.Add(mpList[i].MarketPlaceName);
            }
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetOrdersFromDB(object _ordersList)
        {
            ordersList = (List<AllOrdersModel>)_ordersList;
        }

        /* Отобразить данные по неделям */
        private void btn_Weekly_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = true;
            customMode = false;
            
            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Custom.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
        }
        
        /* Отобразить данные по дням */
        private void btn_Daily_Click(object sender, EventArgs e)
        {
            dailyMode = true;
            weeklyMode = false;
            customMode = false;

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Custom.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
        }

        /* Отобразить данные за весь период */
        private void btn_Custom_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = false;
            customMode = true;

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Custom.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
        }

        /* Изменяем дату начала в календаре */
        private void mc_StartDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate = mc_StartDate.SelectionStart;

            lb_StartDate.Text = mc_StartDate.SelectionStart.ToShortDateString();
        }

        /* Изменяем дату окончания в календаре */
        private void mc_EndDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate = mc_EndDate.SelectionEnd;

            lb_EndDate.Text = mc_EndDate.SelectionStart.ToShortDateString();
        }

        /* Выделяем/снимаем выделение маркетплейса в clb_Marketplace */
        private void clb_Marketplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedMarkeplaces.Clear();

            for (int i = 0; i < clb_Marketplace.CheckedItems.Count; i++)
            {
                checkedMarkeplaces.Add(clb_Marketplace.CheckedItems[i].ToString());
            }

            if (checkedMarkeplaces.Count > 0)
            {
                int res = 0;
                res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames(checkedMarkeplaces));

                if (res == 1 && checkedMarkeplaces.Count > 0)
                {
                    if (checkedMarkeplaces.Count > 1)
                        Fill_clb_Products("few marketplaces");
                    else
                        Fill_clb_Products();
                }
            }
            else
            {
                clb_Products.Items.Clear();
                checkedProducts.Clear();
            }
        }

        /* Снимаем выделение в clb_Marketplace */
        private void btn_Clear_clb_Marketplace_Click(object sender, EventArgs e)
        {
            checkedMarkeplaces.Clear();
            clb_Marketplace.ClearSelected();
            checkedProducts.Clear();

            for (int i = 0; i < clb_Marketplace.Items.Count; i++)
            {
                clb_Marketplace.SetItemChecked(i, false);
            }

            pList.Clear();
            clb_Products.Items.Clear();
        }

        /* Изменяем выбор товара в clb_Products */
        private void clb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductsModel tmpObject = new ProductsModel { };
            string val = "";

            if (clb_Products.CheckedItems.Count == 0)
                checkedProducts.Clear();
            else
            {
                for (int i = 0; i < clb_Products.CheckedItems.Count; i++)
                {
                    val = clb_Products.CheckedItems[i].ToString();
                    tmpObject = GetProduct(val, "just object");
                    if (!checkedProducts.Contains(tmpObject))
                        checkedProducts.Add(tmpObject);
                }
            }
        }

        private void ReportSalesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        /* Снять выделение всех товаров в clb_Products */
        private void btn_Clear_clb_Products_Click(object sender, EventArgs e)
        {
            checkedProducts.Clear();

            for (int i = 0; i < clb_Products.Items.Count; i++)
            {
                clb_Products.SetItemChecked(i, false);
            }
        }

        /* Выделить все товары в clb_Products */
        private void btn_SelectAll_clb_Products_Click(object sender, EventArgs e)
        {
            checkedProducts.Clear();

            for (int i = 0; i < clb_Products.Items.Count; i++)
            {
                clb_Products.SetItemChecked(i, true);
                GetProduct(clb_Products.Items[i].ToString());
            }
        }

        /* Получаем список MarketplaceId по выделенным MarketplaceName */
        private List<int> GetMPIdsByNames(List<string> _checkedMarkeplaces)
        {
            List<int> resultList = new List<int> { };
            for (int i = 0; i < _checkedMarkeplaces.Count; i++)
            {
                for (int j = 0; j < mpList.Count; j++)
                {
                    if (_checkedMarkeplaces[i].Equals(mpList[j].MarketPlaceName))
                        resultList.Add(mpList[j].MarketPlaceId);
                }
            }
            return resultList;
        }

        /* Заполняем clb_Products данными */
        private void Fill_clb_Products()
        {
            ProductsModel tmpObject = new ProductsModel { };
            List<string> tmpProductList = new List<string> { };
            clb_Products.Items.Clear();

            for (int i = 0; i < pList.Count; i++)
            {
                if (!tmpProductList.Contains(pList[i].Name + " [" + pList[i].ASIN + "]"))
                    tmpProductList.Add(pList[i].Name + " [" + pList[i].ASIN + "]");
            }

            for (int i = 0; i < tmpProductList.Count; i++)
            {
                clb_Products.Items.Add(tmpProductList[i]);
            }

            for (int i = 0; i < clb_Products.Items.Count; i++)
            {
                tmpObject = GetProduct(clb_Products.Items[i].ToString(), "just object");
                foreach (var checkedproduct in checkedProducts)
                {
                    if (checkedproduct.ASIN.Equals(tmpObject.ASIN) && checkedproduct.MarketPlaceId == tmpObject.MarketPlaceId)
                    {
                        clb_Products.SetItemChecked(i, true);
                    }
                }
            }
        }

        /* Заполняем clb_Products данными */
        private void Fill_clb_Products(string _fewMarketplaces)
        {
            ProductsModel tmpObject = new ProductsModel { };
            List<string> tmpProductList = new List<string> { };
            clb_Products.Items.Clear();

            for (int i = 0; i < pList.Count; i++)
            {
                if (!tmpProductList.Contains(pList[i].Name + " [" + pList[i].ASIN + " - " + GetMarketPlaceNameById(pList[i].MarketPlaceId) + "]"))
                    tmpProductList.Add(pList[i].Name + " [" + pList[i].ASIN + " - " + GetMarketPlaceNameById(pList[i].MarketPlaceId) + "]");
            }

            for (int i = 0; i < tmpProductList.Count; i++)
            {
                clb_Products.Items.Add(tmpProductList[i]);
            }

            for (int i = 0; i < clb_Products.Items.Count; i++)
            {
                tmpObject = GetProduct(clb_Products.Items[i].ToString(), "just object");
                foreach (var checkedproduct in checkedProducts)
                {
                    if (checkedproduct.ASIN.Equals(tmpObject.ASIN) && checkedproduct.MarketPlaceId == tmpObject.MarketPlaceId)
                    {
                        clb_Products.SetItemChecked(i, true);
                    }
                }
            }
        }

        /* Заполняем clb_Products данными */
        private void Fill_clb_Products(List<ProductsModel> _list)
        {
            ProductsModel tmpObject = new ProductsModel { };
            List<string> tmpProductList = new List<string> { };
            clb_Products.Items.Clear();

            for (int i = 0; i < _list.Count; i++)
            {
                if (!tmpProductList.Contains(_list[i].Name + " [" + _list[i].ASIN + " - " + GetMarketPlaceNameById(_list[i].MarketPlaceId) + "]"))
                    tmpProductList.Add(_list[i].Name + " [" + _list[i].ASIN + " - " + GetMarketPlaceNameById(_list[i].MarketPlaceId) + "]");
            }

            for (int i = 0; i < tmpProductList.Count; i++)
            {
                clb_Products.Items.Add(tmpProductList[i]);
            }

            for (int i = 0; i < clb_Products.Items.Count; i++)
            {
                tmpObject = GetProduct(clb_Products.Items[i].ToString(), "just object");
                foreach (var checkedproduct in checkedProducts)
                {
                    if (checkedproduct.ASIN.Equals(tmpObject.ASIN) && checkedproduct.MarketPlaceId == tmpObject.MarketPlaceId)
                    {
                        clb_Products.SetItemChecked(i, true);
                    }
                }
            }
        }

        /* Получаем список выбранных товаров в clb_Products */
        private ProductsModel GetProduct(string _name, string _getJustName)
        {
            string name = "", asin = "", marketplace = "";
            int marketplaceId;
            bool nameFound = false;
            bool asinFound = false;

            for (int i = 0; i < _name.Length; i++)
            {
                if (!nameFound && _name[i].Equals('['))
                {
                    name = _name.Substring(0, i - 1);
                    nameFound = true;
                }
                if (nameFound && !asinFound)
                {
                    i++;
                    asin = _name.Substring(i, 10);
                    asinFound = true;
                    i += 10;
                }
                if (nameFound && asinFound && !_name[i].Equals(']'))
                {
                    i += 3;
                    marketplace = _name.Substring(i, _name.Length - i - 1);
                    i = _name.Length;
                }
                else if (nameFound && asinFound && _name[i].Equals(']'))
                {
                    marketplace = clb_Marketplace.CheckedItems[0].ToString();
                }
            }
            marketplaceId = GetMarketplaceIdByName(marketplace);

            if (marketplaceId != -1)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (pList[i].Name.Equals(name) && pList[i].ASIN.Equals(asin) && pList[i].MarketPlaceId == marketplaceId)
                        return pList[i];
                }
            }

            return new ProductsModel();
        }

        /* Поиск товара в clb_Products */
        private void tb_FindProductin_clb_Products_TextChanged(object sender, EventArgs e)
        {
            searchresultsCheckedProducts.Clear();
            string findStr = tb_FindProductin_clb_Products.Text.ToLower();
            if (!findStr.Equals(""))
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (pList[i].Name.ToLower().Contains(findStr) || pList[i].ASIN.ToLower().Contains(findStr))
                    {
                        searchresultsCheckedProducts.Add(pList[i]);
                    }
                }

                Fill_clb_Products(searchresultsCheckedProducts);
            }
            else
            {
                Fill_clb_Products(pList);
            }
        }

        /* Получаем список выбранных товаров в clb_Products */
        private void GetProduct(string _name)
        {
            string name = "", asin = "", marketplace = "";
            int marketplaceId;
            bool nameFound = false;
            bool asinFound = false;

            for (int i = 0; i < _name.Length; i++)
            {
                if (!nameFound && _name[i].Equals('['))
                {
                    name = _name.Substring(0, i - 1);
                    nameFound = true;
                }
                if (nameFound && !asinFound)
                {
                    i++;
                    asin = _name.Substring(i, 10);
                    asinFound = true;
                    i += 10;
                }
                if (nameFound && asinFound && !_name[i].Equals(']'))
                {
                    i += 3;
                    marketplace = _name.Substring(i, _name.Length - i - 1);
                    i = _name.Length;
                }
                else if (nameFound && asinFound && _name[i].Equals(']'))
                {
                    marketplace = clb_Marketplace.CheckedItems[0].ToString();
                }
            }
            marketplaceId = GetMarketplaceIdByName(marketplace);

            if (marketplaceId != -1)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (pList[i].Name.Equals(name) && pList[i].ASIN.Equals(asin) && pList[i].MarketPlaceId == marketplaceId)
                        checkedProducts.Add(pList[i]);
                }
            }
        }

        /* Получить MarketplaceId по названию */
        private int GetMarketplaceIdByName(string _name)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (_name.Equals(mpList[i].MarketPlaceName))
                    return mpList[i].MarketPlaceId;
            }
            return -1;
        }

        private string GetMonth(int index)
        {
            switch (index)
            {
                case 1:
                    return "Январь";
                    break;
                case 2:
                    return "Февраль";
                    break;
                case 3:
                    return "Март";
                    break;
                case 4:
                    return "Апрель";
                    break;
                case 5:
                    return "Май";
                    break;
                case 6:
                    return "Июнь";
                    break;
                case 7:
                    return "Июль";
                    break;
                case 8:
                    return "Август";
                    break;
                case 9:
                    return "Сентябрь";
                    break;
                case 10:
                    return "Октябрь";
                    break;
                case 11:
                    return "Ноябрь";
                    break;
                case 12:
                    return "Декабрь";
                    break;
                default:
                    return "";
            }
        }

        private string GetMarketPlaceNameById(object _var)
        {
            int marketplaceId = (int)_var;

            foreach (var t in mpList)
            {
                if (t.MarketPlaceId == marketplaceId)
                    return t.MarketPlaceName;
            }
            return "NOT_FOUND";
        }

        /* Экспорт данных из dataGridView1 в Excel */
        private void btn_Export_Click(object sender, EventArgs e)
        {
            bool okData = false;

            this.Cursor = Cursors.WaitCursor;

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            if (dgv_Sales.RowCount > 0)
            {
                for (int i = 0; i < dgv_Sales.ColumnCount - 4; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dgv_Sales.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgv_Sales.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_Sales.ColumnCount - 4; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dgv_Sales.Rows[i].Cells[j].Value;
                    }
                }

                saveFileDialog1.FileName = lb_StartDate.Text + "-" + lb_EndDate.Text + " Business Report";

                okData = true;
            }
            else
                MessageBox.Show("Нет данных для экспорта!", "Ошибка");


            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            this.Cursor = Cursors.Default;

            if (okData)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    ExcelWorkBook.Close(false);
                }
                else
                {
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    ExcelWorkBook.SaveAs(filename);
                    ExcelWorkBook.Close(false);
                    MessageBox.Show("Успешно сохранено!", "Успех");
                }
            }
        }

        private List<int> GetProductIds()
        {
            List<int> tmpList = new List<int> { };

            for (int i = 0; i < checkedProducts.Count; i++)
            {
                for (int j = 0; j < pList.Count; j++)
                {
                    if (checkedProducts[i].ASIN.Equals(pList[j].ASIN))
                        tmpList.Add(pList[j].ProductId);
                }
            }
            return tmpList;
        }

        /* Получение, обработка и отрисовка данных в таблице */
        private void btn_Show_Click(object sender, EventArgs e)
        {
            if (checkedMarkeplaces.Count == 0)
            {
                MessageBox.Show("Для начала выберите маркетплейс!", "Ошибка");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                if (StartDate > EndDate)
                    MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

                lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
                lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

                int businessResult = 0;
                int advProductsResult = 0;

                dgv_Sales.Rows.Clear();
                dgv_Sales.Columns.Clear();

                DateTime dstart;
                DateTime dend;
                bool firstRun = true;

                if (dailyMode)
                {
                    DateTime start_date, end_date;
                    end_date = EndDate;
                    start_date = end_date.AddHours(-23).AddMinutes(-59).AddSeconds(-59);
                    int diff = (EndDate - StartDate).Days + 1;

                    List<int> marketplaces, productIds;
                    marketplaces = GetMPIdsByNames(checkedMarkeplaces);
                    productIds = GetProductIds();

                    for (int i = 0; i < diff; i++)
                    {
                        //businessList.Clear();
                        //businessResult = businessController.GetFinalABusinessReport(start_date, end_date, marketplaces, productIds);

                        if (businessResult == 1 && advProductsResult == 1)
                        {
                            if (firstRun)
                            {
                                DrawTable(start_date, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(start_date, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");

                        start_date = start_date.AddDays(-1);
                        end_date = end_date.AddDays(-1);
                    }
                }
                else if (weeklyMode)
                {
                    DateTime start_date, end_date;
                    end_date = EndDate;
                    start_date = end_date.AddDays(-6).AddHours(-23).AddMinutes(-59).AddSeconds(-59);
                    int diff = ((EndDate - StartDate).Days + 1) / 7;

                    List<int> marketplaces, productIds;
                    marketplaces = GetMPIdsByNames(checkedMarkeplaces);
                    productIds = GetProductIds();

                    for (int i = 0; i < diff; i++)
                    {
                        //businessList.Clear();
                        //businessResult = businessController.GetFinalABusinessReport(start_date, end_date, marketplaces, productIds);

                        if (businessResult == 1 && advProductsResult == 1)
                        {
                            if (firstRun)
                            {
                                DrawTable(start_date, end_date, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(start_date, end_date, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");

                        start_date = start_date.AddDays(-7);
                        end_date = end_date.AddDays(-7);
                    }
                }
                else if (customMode)
                {
                    DateTime start_date, end_date;
                    end_date = EndDate;
                    start_date = StartDate;


                    List<int> marketplaces, productIds;
                    marketplaces = GetMPIdsByNames(checkedMarkeplaces);
                    productIds = GetProductIds();
                    
                    //businessList.Clear();
                    //businessResult = businessController.GetFinalABusinessReport(start_date, end_date, marketplaces, productIds);

                    if (businessResult == 1 && advProductsResult == 1)
                    {
                        if (firstRun)
                        {
                            //DrawTable(start_date, end_date, true);
                            firstRun = false;
                        }
                        //else
                            //DrawTable(start_date, end_date, false);
                    }
                    else
                        MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                }

                if (dgv_Sales.ColumnCount > 0)
                {
                    //DrawTableLastColumn();
                }
                this.Cursor = Cursors.Default;
                this.Enabled = true;
            }
        }

        private void DrawTableColumns()
        {
            dgv_Sales.Columns.Add("", "");
            var index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Сессии органика";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Сессии реклама";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Orders органика";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Orders реклама";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Orders всего";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Конверсия органики";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Конверсия рекламы";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Конверсия общая";
            index = dgv_Sales.Rows.Add();
            dgv_Sales.Rows[index].Cells[dgv_Sales.ColumnCount - 1].Value = "Доля органики";

            dgv_Sales.Columns[0].Width = 125;
            dgv_Sales.Columns[0].Frozen = true;
            dgv_Sales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /* Пишем суммирующий столбец */
        private void DrawTableLastColumn()
        {
            int SessionsOrganic = 0;
            int SessionsAdv = 0;
            int SalesOrganic = 0;
            int SalesAdv = 0;
            int SalesGeneral = 0;


            double ConversionOrganic = 0;
            double ConversionAdv = 0;
            double ConversionGeneral = 0;
            double OragnicShare = 0;

            for (int i = 1; i < dgv_Sales.Columns.Count; i++)
            {
                SessionsOrganic += int.Parse(dgv_Sales.Rows[0].Cells[i].Value.ToString());
                SessionsAdv += int.Parse(dgv_Sales.Rows[1].Cells[i].Value.ToString());

                SalesOrganic += int.Parse(dgv_Sales.Rows[2].Cells[i].Value.ToString());
                SalesAdv += int.Parse(dgv_Sales.Rows[3].Cells[i].Value.ToString());
                SalesGeneral += int.Parse(dgv_Sales.Rows[4].Cells[i].Value.ToString());
            }

            if (SessionsOrganic != 0)
                ConversionOrganic = Math.Round((double)SalesOrganic / SessionsOrganic * 100, 2);
            else
                ConversionOrganic = 0;

            if (SessionsAdv != 0)
                ConversionAdv = Math.Round((double)SalesAdv / SessionsAdv * 100, 2);
            else
                ConversionAdv = 0;

            if (SessionsOrganic != 0)
                ConversionGeneral = Math.Round((double)SalesGeneral / SessionsOrganic * 100, 2);
            else
                ConversionGeneral = 0;

            if (SalesGeneral != 0)
                OragnicShare = Math.Round((double)SalesOrganic / SalesGeneral * 100, 2);
            else
                OragnicShare = 0;

            dgv_Sales.Columns.Add("summ", "");
            dgv_Sales.Rows[0].Cells[dgv_Sales.ColumnCount - 1].Value = SessionsOrganic;
            dgv_Sales.Rows[1].Cells[dgv_Sales.ColumnCount - 1].Value = SessionsAdv;
            dgv_Sales.Rows[2].Cells[dgv_Sales.ColumnCount - 1].Value = SalesOrganic;
            dgv_Sales.Rows[3].Cells[dgv_Sales.ColumnCount - 1].Value = SalesAdv;
            dgv_Sales.Rows[4].Cells[dgv_Sales.ColumnCount - 1].Value = SalesGeneral;
            dgv_Sales.Rows[5].Cells[dgv_Sales.ColumnCount - 1].Value = ConversionOrganic;
            dgv_Sales.Rows[6].Cells[dgv_Sales.ColumnCount - 1].Value = ConversionAdv;
            dgv_Sales.Rows[7].Cells[dgv_Sales.ColumnCount - 1].Value = ConversionGeneral;
            dgv_Sales.Rows[8].Cells[dgv_Sales.ColumnCount - 1].Value = OragnicShare;
        }

        private void DrawTable(DateTime _dstart, DateTime _dend, bool _firstRun)
        {
            if (_firstRun)
                DrawTableColumns();

            int sessionsOrganic = 0;
            int sessionsAdv = 0;
            int ordersOrganic = 0;
            int ordersAdv = 0;
            int oredersGeneral = 0;
            double conversionOrganic = 0;
            double conversionAdv = 0;
            double conversionGeneral = 0;
            double share = 0;
            
            for (int i = 0; i < ordersList.Count; i++)
            {
                //sessionsAdv += ordersList[i].Clicks;
                //ordersAdv += ordersList[i].Orders;

            }

            ordersOrganic = oredersGeneral - ordersAdv;

            if (sessionsOrganic > 0)
                conversionOrganic = Math.Round((double)ordersOrganic / sessionsOrganic * 100, 2);
            else
                conversionOrganic = 0;

            if (sessionsAdv > 0)
                conversionAdv = Math.Round((double)ordersAdv / sessionsAdv * 100, 2);
            else
                conversionAdv = 0;

            if (sessionsOrganic > 0)
                conversionGeneral = Math.Round((double)oredersGeneral / sessionsOrganic * 100, 2);
            else
                conversionGeneral = 0;

            if (oredersGeneral > 0)
                share = Math.Round((double)ordersOrganic / oredersGeneral * 100, 2);
            else
                share = 0;

            dgv_Sales.Columns.Add(_dstart.ToString().Substring(0, 5) + "-" + _dend.ToString().Substring(0, 5), _dstart.ToString().Substring(0, 5) + "-" + _dend.ToString().Substring(0, 5) + "\n" + GetMonth(_dstart.Month));
            dgv_Sales.Rows[0].Cells[dgv_Sales.ColumnCount - 1].Value = sessionsOrganic;
            dgv_Sales.Rows[1].Cells[dgv_Sales.ColumnCount - 1].Value = sessionsAdv;
            dgv_Sales.Rows[2].Cells[dgv_Sales.ColumnCount - 1].Value = ordersOrganic;
            dgv_Sales.Rows[3].Cells[dgv_Sales.ColumnCount - 1].Value = ordersAdv;
            dgv_Sales.Rows[4].Cells[dgv_Sales.ColumnCount - 1].Value = oredersGeneral;
            dgv_Sales.Rows[5].Cells[dgv_Sales.ColumnCount - 1].Value = conversionOrganic;
            dgv_Sales.Rows[6].Cells[dgv_Sales.ColumnCount - 1].Value = conversionAdv;
            dgv_Sales.Rows[7].Cells[dgv_Sales.ColumnCount - 1].Value = conversionGeneral;
            dgv_Sales.Rows[8].Cells[dgv_Sales.ColumnCount - 1].Value = share;

            dgv_Sales.Columns[dgv_Sales.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void DrawTable(DateTime _dstart, bool _firstRun)
        {
            if (_firstRun)
                DrawTableColumns();

            int sessionsOrganic = 0;
            int sessionsAdv = 0;
            int ordersOrganic = 0;
            int ordersAdv = 0;
            int oredersGeneral = 0;
            double conversionOrganic = 0;
            double conversionAdv = 0;
            double conversionGeneral = 0;
            double share = 0;

            for (int i = 0; i < ordersList.Count; i++)
            {
                //sessionsOrganic += ordersList[i].Sessions;
                //oredersGeneral += ordersList[i].TotalOrderItems + ordersList[i].TotalOrderItemsB2B;
            }

            ordersOrganic = oredersGeneral - ordersAdv;

            if (sessionsOrganic > 0)
                conversionOrganic = Math.Round((double)ordersOrganic / sessionsOrganic * 100, 2);
            else
                conversionOrganic = 0;

            if (sessionsAdv > 0)
                conversionAdv = Math.Round((double)ordersAdv / sessionsAdv * 100, 2);
            else
                conversionAdv = 0;

            if (sessionsOrganic > 0)
                conversionGeneral = Math.Round((double)oredersGeneral / sessionsOrganic * 100, 2);
            else
                conversionGeneral = 0;

            if (oredersGeneral > 0)
                share = Math.Round((double)ordersOrganic / oredersGeneral * 100, 2);
            else
                share = 0;

            dgv_Sales.Columns.Add(_dstart.ToString().Substring(0, 10), _dstart.ToString().Substring(0, 10));
            dgv_Sales.Rows[0].Cells[dgv_Sales.ColumnCount - 1].Value = sessionsOrganic;
            dgv_Sales.Rows[1].Cells[dgv_Sales.ColumnCount - 1].Value = sessionsAdv;
            dgv_Sales.Rows[2].Cells[dgv_Sales.ColumnCount - 1].Value = ordersOrganic;
            dgv_Sales.Rows[3].Cells[dgv_Sales.ColumnCount - 1].Value = ordersAdv;
            dgv_Sales.Rows[4].Cells[dgv_Sales.ColumnCount - 1].Value = oredersGeneral;
            dgv_Sales.Rows[5].Cells[dgv_Sales.ColumnCount - 1].Value = conversionOrganic;
            dgv_Sales.Rows[6].Cells[dgv_Sales.ColumnCount - 1].Value = conversionAdv;
            dgv_Sales.Rows[7].Cells[dgv_Sales.ColumnCount - 1].Value = conversionGeneral;
            dgv_Sales.Rows[8].Cells[dgv_Sales.ColumnCount - 1].Value = share;

            dgv_Sales.Columns[dgv_Sales.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

    }
}
