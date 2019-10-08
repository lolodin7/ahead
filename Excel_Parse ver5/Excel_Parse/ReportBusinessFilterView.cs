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
    public partial class ReportBusinessFilterView : Form
    {
        private ReportBusinessView mf;
        private DateTime StartDate, EndDate;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private List<ReportBusinessModel> businessList;
        private List<ReportBusinessModel> summaryBusinessList;
        private List<ReportBusinessModel> filterBusinessListt;       //список BusinessList с применением фильтра по таблице

        private BusinessController businessController;

        List<string> checkedMarkeplaces, checkedProducts;

        private string equalSign;       //знак равенства из textBox
        private bool NoErrors;          //ошибка ввода в textBox пользователем при фильтре по таблице


        public ReportBusinessFilterView(ReportBusinessView _mf)
        {
            InitializeComponent();
            mf = _mf;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59);
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = StartDate.ToString().Substring(0, 10);


            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
            businessList = new List<ReportBusinessModel> { };
            summaryBusinessList = new List<ReportBusinessModel> { };
            filterBusinessListt = new List<ReportBusinessModel> { };

            mpController = new MarketplaceController(this);
            prodController = new ProductsController(this);
            businessController = new BusinessController(this);

            checkedMarkeplaces = new List<string> { };
            checkedProducts = new List<string> { };

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

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetBusinessReportFromDB(object _businessList)
        {
            businessList = (List<ReportBusinessModel>)_businessList;

            summaryBusinessList.Clear();
            MakeSummaryBusinessReportList();
        }


        /* Удаляем все повторы с businessList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryBusinessReportList()
        {
            List<int> alreadyUsed = new List<int> { };
            
            int Sessions;
            double SessionPercentage = 0;
            int PageViews;
            double PageViewPercentage = 0;
            int UnitsOrdered;
            int UnitsOrderedB2B;
            double UnitSessionPercentage = 0;
            double UnitSessionPercentageB2B = 0;
            double OrderedProductSales;
            double OrderedProductSalesB2B;
            int TotalOrderItems;
            int TotalOrderItemsB2B;
            

            for (int i = 0; i < businessList.Count; i++)
            {
                if (!alreadyUsed.Contains(i))
                {
                    Sessions = businessList[i].Sessions;
                    PageViews = businessList[i].PageViews;
                    UnitsOrdered = businessList[i].UnitsOrdered;
                    UnitsOrderedB2B = businessList[i].UnitsOrderedB2B;
                    OrderedProductSales = businessList[i].OrderedProductSales;
                    OrderedProductSalesB2B = businessList[i].OrderedProductSalesB2B;
                    TotalOrderItems = businessList[i].TotalOrderItems;
                    TotalOrderItemsB2B = businessList[i].TotalOrderItemsB2B;

                    if (i < (businessList.Count - 1))
                    {
                        for (int j = i + 1; j < businessList.Count; j++)
                        {
                            if (businessList[i].MarketPlaceId == businessList[j].MarketPlaceId && businessList[i].SKU.Equals(businessList[j].SKU) && businessList[i].ProductId == businessList[j].ProductId)
                            {
                                Sessions += businessList[j].Sessions;
                                PageViews += businessList[j].PageViews;
                                UnitsOrdered += businessList[j].UnitsOrdered;
                                UnitsOrderedB2B += businessList[j].UnitsOrderedB2B;
                                OrderedProductSales += businessList[j].OrderedProductSales;
                                OrderedProductSalesB2B += businessList[j].OrderedProductSalesB2B;
                                TotalOrderItems += businessList[j].TotalOrderItems;
                                TotalOrderItemsB2B += businessList[j].TotalOrderItemsB2B;
                                alreadyUsed.Add(j);
                            }
                        }
                    }
                    else
                    {
                        Sessions += businessList[i].Sessions;
                        PageViews += businessList[i].PageViews;
                        UnitsOrdered += businessList[i].UnitsOrdered;
                        UnitsOrderedB2B += businessList[i].UnitsOrderedB2B;
                        OrderedProductSales += businessList[i].OrderedProductSales;
                        OrderedProductSalesB2B += businessList[i].OrderedProductSalesB2B;
                        TotalOrderItems += businessList[i].TotalOrderItems;
                        TotalOrderItemsB2B += businessList[i].TotalOrderItemsB2B;
                        alreadyUsed.Add(i);
                    }
                    //summaryAdvProductsList.Add(ТО, ШО ПОЛУЧИЛОСЬ ОТ СУММИРОВАНИЯ + ДОПОЛНИТЕЛЬНО СЧИТАЕМ ТО, ЧТО НАДО ПОСЧИТАТЬ);

                    if (Sessions != 0)
                        businessList[i].SessionPercentage = Math.Round((double)businessList[i].Sessions / Sessions * 100, 2);
                    else
                        businessList[i].SessionPercentage = 0;

                    if (PageViews != 0)
                        businessList[i].PageViewsPercentage = Math.Round((double)businessList[i].PageViews / PageViews * 100, 2);
                    else
                        businessList[i].PageViewsPercentage = 0;

                    if (businessList[i].Sessions != 0)
                        businessList[i].UnitSessionPercentage = Math.Round((double)businessList[i].UnitsOrdered / businessList[i].Sessions * 100, 2);
                    else
                        businessList[i].UnitSessionPercentage = 0;

                    if (businessList[i].Sessions != 0)
                        businessList[i].UnitSessionPercentageB2B = Math.Round((double)businessList[i].UnitsOrderedB2B / businessList[i].Sessions * 100, 2);
                    else
                        businessList[i].UnitSessionPercentageB2B = 0;
                    

                    summaryBusinessList.Add(new ReportBusinessModel());

                    summaryBusinessList[summaryBusinessList.Count - 1].UpdateDate = businessList[i].UpdateDate;
                    summaryBusinessList[summaryBusinessList.Count - 1].MarketPlaceId = businessList[i].MarketPlaceId;
                    summaryBusinessList[summaryBusinessList.Count - 1].SKU = businessList[i].SKU;
                    summaryBusinessList[summaryBusinessList.Count - 1].Sessions = Sessions;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitSessionPercentage = SessionPercentage;
                    summaryBusinessList[summaryBusinessList.Count - 1].PageViews = PageViews;
                    summaryBusinessList[summaryBusinessList.Count - 1].PageViewsPercentage = PageViewPercentage;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitsOrdered = UnitsOrdered;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitsOrderedB2B = UnitsOrderedB2B;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitSessionPercentage = UnitSessionPercentage;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitSessionPercentageB2B = UnitSessionPercentageB2B;
                    summaryBusinessList[summaryBusinessList.Count - 1].OrderedProductSales = OrderedProductSales;
                    summaryBusinessList[summaryBusinessList.Count - 1].OrderedProductSalesB2B = OrderedProductSalesB2B;
                    summaryBusinessList[summaryBusinessList.Count - 1].TotalOrderItemsB2B = TotalOrderItemsB2B;
                    summaryBusinessList[summaryBusinessList.Count - 1].ProductId = businessList[i].ProductId;
                }
            }
            businessList.Clear();
            foreach (var t in summaryBusinessList)
            {
                businessList.Add(t);
            }
        }


        private void ReportBusinessFilterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mf.Enabled)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else { }
        }

        /* Отобразить данные за последний день */
        private void btn_LastDay_Click(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(1, 0, 0, 0, 0));
            mc_StartDate.SelectionStart = dd;
            mc_EndDate.SelectionEnd = dd.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные за последний месяц */
        private void btn_LastMonth_Click(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(30, 0, 0, 0, 0));
            mc_StartDate.SelectionStart = dd;
            mc_EndDate.SelectionEnd = DateTime.Today.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные за последние полгода */
        private void btn_LastHalfYear_Click(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(183, 0, 0, 0, 0));
            mc_StartDate.SelectionStart = dd;
            mc_EndDate.SelectionEnd = DateTime.Today.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные за последний год */
        private void btn_lastYear_Click(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(365, 0, 0, 0, 0));
            mc_StartDate.SelectionStart = dd;
            mc_EndDate.SelectionEnd = DateTime.Today.AddHours(23).AddMinutes(59);
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

            int res = 0;
            res = prodController.GetProductsByFewMarketplaceId(GetMPIdsByNames(checkedMarkeplaces));
            if (res == 1)
            {
                Draw_clb_Products();
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

        /* Заносим имена товаров в clb_Products */
        private void Draw_clb_Products()
        {
            clb_Product.Items.Clear();
            for (int i = 0; i < pList.Count; i++)
            {
                clb_Product.Items.Add(pList[i].Name);
            }
        }

        /* Очистить список выбранных товаров в clb_Products */
        private void btn_Clear_clb_Products_Click(object sender, EventArgs e)
        {
            clb_Product.ClearSelected();
            checkedProducts.Clear();
            for (int i = 0; i < clb_Product.Items.Count; i++)
            {
                clb_Product.SetItemChecked(i, false);
            }
        }

        /* Очистить список выбранных маркетплейсов в clb_Marketplace */
        private void btn_Clear_clb_Marketplace_Click(object sender, EventArgs e)
        {
            clb_Product.ClearSelected();
            clb_Product.Items.Clear();
            checkedProducts.Clear();
            checkedMarkeplaces.Clear();
            clb_Marketplace.ClearSelected();

            for (int i = 0; i < clb_Marketplace.Items.Count; i++)
            {
                clb_Marketplace.SetItemChecked(i, false);
            }
            clb_Product.Items.Clear();
        }

        /* Применить числовой фильтр по таблице */
        private void btn_Go_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            NoErrors = true;

            filterBusinessListt = new List<ReportBusinessModel> { };
            for (int i = 0; i < businessList.Count; i++)
            {
                if (CheckDoubleValues(CheckInput(tb_Sessions), businessList[i].Sessions) && CheckDoubleValues(CheckInput(tb_PageViews), businessList[i].PageViews) && CheckDoubleValues(CheckInput(tb_Units), businessList[i].UnitsOrdered) && CheckDoubleValues(CheckInput(tb_UnitsB2B), businessList[i].UnitsOrderedB2B) && CheckDoubleValues(CheckInput(tb_Sales), businessList[i].OrderedProductSales) && CheckDoubleValues(CheckInput(tb_SalesB2B), businessList[i].OrderedProductSalesB2B) && CheckDoubleValues(CheckInput(tb_Orders), businessList[i].TotalOrderItems) && CheckDoubleValues(CheckInput(tb_OrdersB2B), businessList[i].TotalOrderItemsB2B))
                {
                    filterBusinessListt.Add(businessList[i]);
                }
            }

            timer1.Start();
            if (NoErrors)
                mf.GetBusinessListToShow(filterBusinessListt);


            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        /* В зависимости от вычлененного знака равенства сравниваем значения в фильтре и в таблице */
        private bool CheckDoubleValues(double _val1, double _val2)
        {
            if (equalSign.Equals(">"))
            {
                return _val2 > _val1;
            }
            else if (equalSign.Equals("<"))
            {
                return _val2 < _val1;
            }
            else if (equalSign.Equals("="))
            {
                return _val2 == _val1;
            }
            else if (equalSign.Equals(">="))
            {
                return _val2 >= _val1;
            }
            else if (equalSign.Equals("<="))
            {
                return _val2 <= _val1;
            }
            return false;
        }

        /* Вычленяем с textBox число и знак равенства */
        private double CheckInput(TextBox _tb)
        {
            string text;
            double val;
            try
            {
                if (!_tb.Text.Equals(""))
                {
                    if (_tb.Text.Contains(">") && !_tb.Text.Contains("="))
                    {
                        text = _tb.Text.Substring(1, _tb.Text.Length - 1);
                        val = double.Parse(text);
                        equalSign = ">";
                    }
                    else if (_tb.Text.Contains("<") && !_tb.Text.Contains("="))
                    {
                        text = _tb.Text.Substring(1, _tb.Text.Length - 1);
                        val = double.Parse(text);
                        equalSign = "<";
                    }
                    //else if (_tb.Text.Contains("="))
                    //{
                    //    text = _tb.Text.Substring(1, _tb.Text.Length - 1);
                    //    val = double.Parse(text);
                    //    equalSign = "=";
                    //}
                    else if (_tb.Text.Contains(">="))
                    {
                        text = _tb.Text.Substring(2, _tb.Text.Length - 2);
                        val = double.Parse(text);
                        equalSign = ">=";
                    }
                    else if (_tb.Text.Contains("<="))
                    {
                        text = _tb.Text.Substring(2, _tb.Text.Length - 2);
                        val = double.Parse(text);
                        equalSign = "<=";
                    }
                    else          //если ничего не указываем, то по умолчанию считаем как '='
                    {
                        text = _tb.Text;
                        val = double.Parse(text);
                        equalSign = "=";
                    }
                }
                else
                {
                    equalSign = ">=";
                    return 0;
                }
            }
            catch (Exception ex)
            {
                equalSign = ">=";
                _tb.BackColor = Color.Red;
                NoErrors = false;
                return 0;
            }

            return val;
        }

        /* Сбрасываем фильтры по таблице и загружаем первичный список */
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            //перерисовываем таблицу по старым данным из advProductsList или advBrandsList

            tb_Sessions.Text = "";
            tb_PageViews.Text = "";
            tb_Units.Text = "";
            tb_UnitsB2B.Text = "";
            tb_Sales.Text = "";
            tb_SalesB2B.Text = "";
            tb_Orders.Text = "";
            tb_OrdersB2B.Text = "";
            tb_Units.Text = "";

            mf.GetBusinessListToShow(businessList);
        }

        private void btn_SearchBy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            NoErrors = true;
            filterBusinessListt = new List<ReportBusinessModel> { };

            string sku = tb_SearchBySKU.Text;

            if (sku.Equals("") || sku.Equals(" "))
                tb_SearchBySKU.BackColor = Color.Red;
            else
            {
                for (int i = 0; i < businessList.Count; i++)
                {
                    if (businessList[i].SKU.Equals(sku))
                    {
                        filterBusinessListt.Add(businessList[i]);
                    }
                }

                mf.GetBusinessListToShow(filterBusinessListt);
            }

            timer1.Start();
            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        /* Применяем фильтры и перерисовываем данные в форме AdvertisingReportView */
        private void btn_Show_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            if (StartDate > EndDate)
                MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

            mf.StartDate = StartDate;
            mf.EndDate = EndDate;
            
            int result = 0;
            businessList = null;

            result = businessController.GetFinalABusinessReport(StartDate, EndDate, GetMPIdsByNames(checkedMarkeplaces));

            if (result == 1)
            {
                mf.GetMarketplaceList(mpList);
                mf.GetProductList(pList);
                mf.GetBusinessListToShow(businessList);

                filterBusinessListt = new List<ReportBusinessModel> { };
            }

            if (mf.dataGridView1.RowCount > 0)
                groupBox1.Enabled = true;
            else
                groupBox1.Enabled = false;

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            tb_Sessions.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_PageViews.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_UnitsB2B.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_SalesB2B.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_OrdersB2B.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Sales.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Orders.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Units.BackColor = Color.FromKnownColor(KnownColor.Window);

            timer1.Stop();
        }

        /* Выделяем/снимаем выделение товара в clb_Product */
        private void clb_Product_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /* Получаем список ProductId по выделенным ProductName */
        private List<int> GetProductIdsByNames(List<string> _checkedProducts)
        {
            bool flag = false;
            List<int> resultList = new List<int> { };
            List<int> resultList1 = new List<int> { };
            for (int i = 0; i < _checkedProducts.Count; i++)
            {
                flag = false;
                for (int j = 0; j < pList.Count; j++)
                {
                    if (!flag && _checkedProducts[i].Equals(pList[j].Name))
                    {
                        resultList.Add(pList[j].ProductId);
                        flag = true;
                    }
                }
            }

            for (int i = 0; i < resultList.Count; i++)
            {
                if (!resultList1.Contains(resultList[i]))
                    resultList1.Add(resultList[i]);
            }

            return resultList1;
        }
    }
}
