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
    public partial class ReportAdvertisingView : Form 
    {
        private MainFormView mf;
        private ReportAdvertisingFilterView advFilter;

        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingBrandsModel> advBrandsList;
        private List<AdvertisingProductsModel>  advProductsListOriginal;

        private bool targetingInAdgroupsMode, adgroupsInCampaignsMode, campaignInProductsMode, productsInMarketplaces;
        private bool byDays, byWeeks, byMonths, byCustom;

        public bool SponsoredProductMode { get; set; }
        public bool SponsoredBrandMode { get; set; }
        public bool AdvertisingProductsShowMode { get; set; }
        public bool AdGroupShowMode { get; set; }
        public bool TargetingShowMode { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private List<ProductsModel> pList;


        /* Конструктор */
        public ReportAdvertisingView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            lb_StartDate.Text = DateTime.Today.ToString().Substring(0, 10);
            lb_EndDate.Text = DateTime.Today.ToString().Substring(0, 10);

            SponsoredProductMode = false;
            SponsoredBrandMode = false;

            AdvertisingProductsShowMode = true;
            AdGroupShowMode = false;
            TargetingShowMode = false;

            ResetCompareModes();

            advProductsList = new List<AdvertisingProductsModel> { };
            advProductsListOriginal = new List<AdvertisingProductsModel> { };
            advBrandsList = new List<AdvertisingBrandsModel> { };
        }

        private void ResetCompareModes()
        {
            targetingInAdgroupsMode = false;
            adgroupsInCampaignsMode = false;
            campaignInProductsMode = false;
            productsInMarketplaces = false;
        }

        private void ResetDateModes()
        {
            byDays = false;
            byWeeks = false;
            byMonths = false;
            byCustom = false;
        }

        /* Обрабатываем закрытие формы */
        private void AdvertisingReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }

        /* При закрытии окна фильтра устанавливаем значение его объекта как null */
        public void ClosingFilter()
        {
            advFilter = null;
        }

        /* Открываем форму фильтра */
        private void btn_Filter_Click(object sender, EventArgs e)
        {
            if (advFilter == null)
            {
                advFilter = new ReportAdvertisingFilterView(this);
                advFilter.Show();
            }
            else
            {
                advFilter.Focus();
                advFilter.WindowState = FormWindowState.Normal;
            }
        }

        /* Экспорт данных из таблицы */
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

            if (SponsoredProductMode)       //если смотрим Sponsored Products
            {
                if (AdvertisingProductsShowMode)        //если сохраняем из таблицы dgv_AdvProducts
                {
                    if (dgv_AdvProducts.RowCount > 0)
                    {
                        for (int i = 0; i < dgv_AdvProducts.ColumnCount - 4; i++)
                        {
                            ExcelApp.Cells[1, i + 1] = dgv_AdvProducts.Columns[i].HeaderText;
                        }

                        for (int i = 0; i < dgv_AdvProducts.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgv_AdvProducts.ColumnCount - 4; j++)
                            {
                                ExcelApp.Cells[i + 2, j + 1] = dgv_AdvProducts.Rows[i].Cells[j].Value;
                            }
                        }

                        saveFileDialog1.FileName = lb_StartDate.Text + "-" + lb_EndDate.Text + " Sponsored Products - All";

                        okData = true;
                    }
                    else
                        MessageBox.Show("Нет данных для экспорта!", "Ошибка");
                }
                /*else if (AdGroupShowMode)        //если сохраняем из таблицы dgv_adGroupss
                {
                    if (dgv_adGroups.RowCount > 0)
                    {
                        for (int i = 0; i < dgv_adGroups.ColumnCount - 4; i++)
                        {
                            ExcelApp.Cells[1, i + 1] = dgv_adGroups.Columns[i].HeaderText;
                        }

                        for (int i = 0; i < dgv_adGroups.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgv_adGroups.ColumnCount - 4; j++)
                            {
                                ExcelApp.Cells[i + 2, j + 1] = dgv_adGroups.Rows[i].Cells[j].Value;
                            }
                        }

                        saveFileDialog1.FileName = lb_StartDate.Text + "-" + lb_EndDate.Text + " Sponsored Products - AdGroups";

                        okData = true;
                    }
                    else
                        MessageBox.Show("Нет данных для экспорта!", "Ошибка");
                }
                else if (TargetingShowMode)        //если сохраняем из таблицы dgv_Targeting
                {
                    if (dgv_Targeting.RowCount > 0)
                    {
                        if (dgv_Targeting.RowCount > 0)
                        {
                            for (int i = 0; i < dgv_Targeting.ColumnCount - 4; i++)
                            {
                                ExcelApp.Cells[1, i + 1] = dgv_Targeting.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dgv_Targeting.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv_Targeting.ColumnCount - 4; j++)
                                {
                                    ExcelApp.Cells[i + 2, j + 1] = dgv_Targeting.Rows[i].Cells[j].Value;
                                }
                            }

                            saveFileDialog1.FileName = lb_StartDate.Text + "-" + lb_EndDate.Text + " Sponsored Products - Targeting";

                            okData = true;
                        }
                    }
                    else
                        MessageBox.Show("Нет данных для экспорта!", "Ошибка");
                }*/
            }
            /*else if (SponsoredBrandMode)       //если смотрим Sponsored Brands
            {
                if (dgv_AdvBrands.RowCount > 0)
                {
                    for (int i = 0; i < dgv_AdvBrands.ColumnCount - 4; i++)
                    {
                        ExcelApp.Cells[1, i + 1] = dgv_AdvBrands.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgv_AdvBrands.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv_AdvBrands.ColumnCount - 4; j++)
                        {
                            ExcelApp.Cells[i + 2, j + 1] = dgv_AdvBrands.Rows[i].Cells[j].Value;
                        }
                    }

                    saveFileDialog1.FileName = lb_StartDate.Text + "-" + lb_EndDate.Text + " Sponsored Brands - All";

                    okData = true;
                }
                else
                    MessageBox.Show("Нет данных для экспорта!", "Ошибка");
            }*/

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
        
        /* Рисуем "правильную" таблицу с заголовками и шириной столбцов для Sponsored Products */
        private void DrawCorrectColumnsForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList, DataGridView dgv)
        {
            dgv.Columns.Add("UpdateDate", "Date");
            dgv.Columns.Add("CurrencyCharCode", "Currency");
            dgv.Columns.Add("CampaignName", "Campaign");
            dgv.Columns.Add("AdGroupName", "AdGroup");            
            dgv.Columns.Add("Targeting", "Targeting");
            if (productsInMarketplaces)
                dgv.Columns.Add("ProductName", "Product");
            else
                dgv.Columns.Add("MatchType", "Match Type");
            dgv.Columns.Add("Impressions", "Impressions");
            dgv.Columns.Add("Clicks", "Clicks");
            dgv.Columns.Add("CTR", "CTR");
            dgv.Columns.Add("CPC", "CPC");
            dgv.Columns.Add("Spend", "Spend");
            dgv.Columns.Add("Sales", "Sales");
            dgv.Columns.Add("ACoS", "ACoS");
            dgv.Columns.Add("RoAS", "RoAS");
            dgv.Columns.Add("Orders", "Orders");
            dgv.Columns.Add("Units", "Units");
            dgv.Columns.Add("ConversionRate", "Conversion");
            dgv.Columns.Add("AdvSKUUnits", "Adv SKU Units");
            dgv.Columns.Add("OtherSKUUnits", "Other SKU Units");
            dgv.Columns.Add("AdvSKUSales", "Adv SKU Sales");
            dgv.Columns.Add("OtherSKUSales", "Other SKU Sales");
            dgv.Columns.Add("CampaignTypeId", "text");
            dgv.Columns.Add("MarketPlaceId", "text");
            dgv.Columns.Add("CampaignId", "text");
            dgv.Columns.Add("ProductId", "text");

            dgv.Columns[0].Visible = false;
            dgv.Columns[21].Visible = false;
            dgv.Columns[22].Visible = false;
            dgv.Columns[23].Visible = false;
            dgv.Columns[24].Visible = false;

            dgv.Columns[0].Frozen = true;
            dgv.Columns[1].Frozen = true;
            dgv.Columns[2].Frozen = true;
            dgv.Columns[3].Frozen = true;
            dgv.Columns[4].Frozen = true;
            dgv.Columns[5].Frozen = true;

            dgv.Columns[0].Width = 70;
            dgv.Columns[1].Width = 60;
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].Width = 200;
            dgv.Columns[4].Width = 200;

            for (int i = 0; i < _advProductsList[0].ColumnCount; i++)
            {
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 6)
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }           
        }

        /* Рисуем "правильную" таблицу с заголовками и шириной столбцов для Sponsored Brands */
        /*private void DrawCorrectColumnsForSponsoredBrands(List<AdvertisingBrandsModel> _advBrandsList)
        {
            dgv_AdvBrands.Columns.Add("UpdateDate", "Date");
            dgv_AdvBrands.Columns.Add("CurrencyCharCode", "Currency");
            dgv_AdvBrands.Columns.Add("CampaignName", "Campaign");
            dgv_AdvBrands.Columns.Add("Targeting", "Targeting");
            dgv_AdvBrands.Columns.Add("MatchType", "Match Type");
            dgv_AdvBrands.Columns.Add("Impressions", "Impressions");
            dgv_AdvBrands.Columns.Add("Clicks", "Clicks");
            dgv_AdvBrands.Columns.Add("CTR", "CTR");
            dgv_AdvBrands.Columns.Add("CPC", "CPC");
            dgv_AdvBrands.Columns.Add("Spend", "Spend");
            dgv_AdvBrands.Columns.Add("ACoS", "ACoS");
            dgv_AdvBrands.Columns.Add("RoAS", "RoAS");
            dgv_AdvBrands.Columns.Add("Sales", "Sales");
            dgv_AdvBrands.Columns.Add("Orders", "Orders");
            dgv_AdvBrands.Columns.Add("Units", "Units");
            dgv_AdvBrands.Columns.Add("ConversionRate", "Conversion");
            dgv_AdvBrands.Columns.Add("NewToBrandOrders", "New-To-Brand Orders");
            dgv_AdvBrands.Columns.Add("NewToBrandSales", "New-To-Brand Sales");
            dgv_AdvBrands.Columns.Add("NewToBrandUnits", "New-To-Brand Units");
            dgv_AdvBrands.Columns.Add("NewToBrandOrderRate", "New-To-Brand Order Rate");
            dgv_AdvBrands.Columns.Add("CampaignTypeId", "text");
            dgv_AdvBrands.Columns.Add("MarketPlaceId", "text");
            dgv_AdvBrands.Columns.Add("CampaignId", "text");
            dgv_AdvBrands.Columns.Add("ProductId1", "text");
            dgv_AdvBrands.Columns.Add("ProductId2", "text");
            dgv_AdvBrands.Columns.Add("ProductId3", "text");


            dgv_AdvBrands.Columns[0].Visible = false;
            dgv_AdvBrands.Columns[20].Visible = false;
            dgv_AdvBrands.Columns[21].Visible = false;
            dgv_AdvBrands.Columns[22].Visible = false;
            dgv_AdvBrands.Columns[23].Visible = false;
            dgv_AdvBrands.Columns[24].Visible = false;
            dgv_AdvBrands.Columns[25].Visible = false;

            dgv_AdvBrands.Columns[0].Frozen = true;
            dgv_AdvBrands.Columns[1].Frozen = true;
            dgv_AdvBrands.Columns[2].Frozen = true;
            dgv_AdvBrands.Columns[3].Frozen = true;
            dgv_AdvBrands.Columns[4].Frozen = true;

            dgv_AdvBrands.Columns[0].Width = 70;
            dgv_AdvBrands.Columns[1].Width = 60;
            dgv_AdvBrands.Columns[2].Width = 200;
            dgv_AdvBrands.Columns[3].Width = 200;

            for (int i = 0; i < _advBrandsList[0].ColumnCount; i++)
            {
                dgv_AdvBrands.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 6)
                    dgv_AdvBrands.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }*/

        /* Рисуем таблицу dgv_AdvProducts и заполняем её данными */
        private void DrawTableForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList)
        {
            this.Text = "Данные рекламы";
            dgv_AdvProducts.Visible = true;

            dgv_AdvProducts.Rows.Clear();
            dgv_AdvProducts.Columns.Clear();
            
            if (_advProductsList.Count > 0)
            {
                DrawCorrectColumnsForSponsoredProducts(_advProductsList, dgv_AdvProducts);

                DrawFirstRowForSponsoredProducts(_advProductsList);

                for (int i = 0; i < _advProductsList.Count; i++)
                {
                    var index = dgv_AdvProducts.Rows.Add();
                    for (int j = 1; j < _advProductsList[0].ColumnCount; j++)
                    {
                        dgv_AdvProducts.Rows[index].Cells[j].Value = _advProductsList[i].ReadData(j);
                    }
                }
                if (productsInMarketplaces)
                    for (int i = 0; i < _advProductsList.Count; i++)
                    {
                        dgv_AdvProducts.Rows[i + 1].Cells[5].Value = GetProductNameById(_advProductsList[i].ProductId);
                    }

                if (targetingInAdgroupsMode)
                { }
                else if (adgroupsInCampaignsMode)
                {
                    dgv_AdvProducts.Columns[4].Visible = false;
                }
                else if (campaignInProductsMode)
                {
                    dgv_AdvProducts.Columns[4].Visible = false;
                    dgv_AdvProducts.Columns[3].Visible = false;
                }
                else if (productsInMarketplaces)
                {
                    dgv_AdvProducts.Columns[4].Visible = false;
                    dgv_AdvProducts.Columns[3].Visible = false;
                    dgv_AdvProducts.Columns[2].Visible = false;
                }
            }

            btn_Export.Text = "Экспорт в файл (" + (dgv_AdvProducts.RowCount - 1) + ")";
        }

        /* Рисуем суммирующиую 1ю строку в dgv_AdvProducts */
        private void DrawFirstRowForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList)
        {
            int impr = 0;
            int clicks = 0;
            double ctr = 0;
            double cpc = 0;
            double spend = 0;
            double sales = 0;
            double acos = 0;
            double roas = 0;
            int orders = 0;
            int units = 0;
            double convers = 0;
            int advskuunt = 0;
            int otherskuunt = 0;
            double advskusales = 0;
            double otherskusales = 0;

            for (int i = 0; i < _advProductsList.Count; i++)
            {
                impr += _advProductsList[i].Impressions;
                clicks += _advProductsList[i].Clicks;
                spend += _advProductsList[i].Spend;
                sales += _advProductsList[i].Sales;
                orders += _advProductsList[i].Orders;
                units += _advProductsList[i].Units;
                advskuunt += _advProductsList[i].AdvSKUUnits;
                otherskuunt += _advProductsList[i].OtherSKUUnits;
                advskusales += _advProductsList[i].AdvSKUSales;
                otherskusales += _advProductsList[i].OtherSKUSales;
            }

            if(impr != 0)
                ctr = Math.Round(((double)clicks / impr) * 100, 2);
            else
                ctr = 0;

            if (clicks != 0)
                cpc = Math.Round(spend / clicks, 2);
            else
                cpc = 0;

            if (sales != 0)
                acos = Math.Round((spend / sales) * 100, 2);
            else
                acos = 0;

            if (spend != 0)
                roas = Math.Round(sales / spend, 2);
            else
                roas = 0;

            if (clicks != 0)
                convers = Math.Round(((double)orders / clicks) * 100, 2);
            else
                convers = 0;

            var index = dgv_AdvProducts.Rows.Add();
            
            dgv_AdvProducts.Rows[index].Cells[6].Value = impr;
            dgv_AdvProducts.Rows[index].Cells[7].Value = clicks;
            dgv_AdvProducts.Rows[index].Cells[8].Value = ctr;
            dgv_AdvProducts.Rows[index].Cells[9].Value = cpc;
            dgv_AdvProducts.Rows[index].Cells[10].Value = Math.Round(spend, 2);
            dgv_AdvProducts.Rows[index].Cells[11].Value = Math.Round(sales, 2);
            dgv_AdvProducts.Rows[index].Cells[12].Value = acos;
            dgv_AdvProducts.Rows[index].Cells[13].Value = roas;
            dgv_AdvProducts.Rows[index].Cells[14].Value = orders;
            dgv_AdvProducts.Rows[index].Cells[15].Value = units;
            dgv_AdvProducts.Rows[index].Cells[16].Value = convers;
            dgv_AdvProducts.Rows[index].Cells[17].Value = advskuunt;
            dgv_AdvProducts.Rows[index].Cells[18].Value = otherskuunt;
            dgv_AdvProducts.Rows[index].Cells[19].Value = Math.Round(advskusales, 2);
            dgv_AdvProducts.Rows[index].Cells[20].Value = Math.Round(otherskusales, 2);
        }


        /*private void DrawFirstRowForSponsoredBrands(List<AdvertisingBrandsModel> _advBrandsList)
        {
            int impr = 0;
            int clicks = 0;
            double ctr = 0;
            double cpc = 0;
            double spend = 0;
            double sales = 0;
            double acos = 0;
            double roas = 0;
            int orders = 0;
            int units = 0;
            double convers = 0;
            int newToBrandOrders = 0;
            int NewToBrandUnits = 0;
            double newToBrandSales = 0;
            double newToBrandOrderRate = 0;

            for (int i = 0; i < _advBrandsList.Count; i++)
            {
                impr += _advBrandsList[i].Impressions;
                clicks += _advBrandsList[i].Clicks;
                spend += _advBrandsList[i].Spend;
                sales += _advBrandsList[i].Sales;
                orders += _advBrandsList[i].Orders;
                units += _advBrandsList[i].Units;
                newToBrandOrders += _advBrandsList[i].NewToBrandOrders;
                newToBrandSales += _advBrandsList[i].NewToBrandSales;
                NewToBrandUnits += _advBrandsList[i].NewToBrandUnits;
            }

            if (impr != 0)
                ctr = Math.Round(((double)clicks / impr) * 100, 2);
            else
                ctr = 0;

            if (clicks != 0)
                cpc = Math.Round(spend / clicks, 2);
            else
                cpc = 0;

            if (sales != 0)
                acos = Math.Round((spend / sales) * 100, 2);
            else
                acos = 0;

            if (spend != 0)
                roas = Math.Round(sales / spend, 2);
            else
                roas = 0;

            if (clicks != 0)
                convers = Math.Round(((double)orders / clicks) * 100, 2);
            else
                convers = 0;

            if (clicks != 0)
                newToBrandOrderRate = Math.Round((double)newToBrandOrders / clicks, 2);
            else
                newToBrandOrderRate = 0;


            var index = dgv_AdvProducts.Rows.Add();

            dgv_AdvBrands.Rows[index].Cells[5].Value = impr;
            dgv_AdvBrands.Rows[index].Cells[6].Value = clicks;
            dgv_AdvBrands.Rows[index].Cells[7].Value = ctr;
            dgv_AdvBrands.Rows[index].Cells[8].Value = cpc;
            dgv_AdvBrands.Rows[index].Cells[9].Value = spend;
            dgv_AdvBrands.Rows[index].Cells[10].Value = Math.Round(sales, 2);
            dgv_AdvBrands.Rows[index].Cells[11].Value = acos;
            dgv_AdvBrands.Rows[index].Cells[12].Value = roas;
            dgv_AdvBrands.Rows[index].Cells[13].Value = orders;
            dgv_AdvBrands.Rows[index].Cells[14].Value = units;
            dgv_AdvBrands.Rows[index].Cells[15].Value = convers;
            dgv_AdvBrands.Rows[index].Cells[16].Value = newToBrandOrders;
            dgv_AdvBrands.Rows[index].Cells[17].Value = Math.Round(newToBrandSales, 2);
            dgv_AdvBrands.Rows[index].Cells[18].Value = Math.Round(newToBrandSales, 2);
            dgv_AdvBrands.Rows[index].Cells[19].Value = newToBrandOrderRate;

        }*/

        /* Рисуем таблицу dgv_adGroups и заполняем её данными */
        /*private void DrawTableForAdGroups(List<AdvertisingProductsModel> _advProductsList)
        {
            dgv_AdvProducts.Visible = false;
            dgv_adGroups.Visible = true;
            dgv_Targeting.Visible = false;

            dgv_adGroups.Rows.Clear();
            dgv_adGroups.Columns.Clear();

            if (_advProductsList.Count > 0)
            {
                //рисуем таблицу по фильтру AdGroup

                DrawCorrectColumnsForSponsoredProducts(_advProductsList, dgv_adGroups);

                for (int i = 0; i < _advProductsList.Count; i++)
                {
                    var index = dgv_adGroups.Rows.Add();
                    for (int j = 0; j < _advProductsList[0].ColumnCount; j++)
                    {
                        dgv_adGroups.Rows[index].Cells[j].Value = _advProductsList[i].ReadData(j);
                    }
                }
            }

            btn_Export.Text = "Экспорт в файл (" + dgv_adGroups.RowCount + ")";
        }*/
        
        /* Рисуем таблицу dgv_Targeting и заполняем её данными */
        /*private void DrawTableForTargeting(List<AdvertisingProductsModel> _advProductsList)
        {
            dgv_AdvProducts.Visible = false;
            dgv_adGroups.Visible = false;
            dgv_Targeting.Visible = true;

            dgv_Targeting.Rows.Clear();
            dgv_Targeting.Columns.Clear();

            if (_advProductsList.Count > 0)
            {
                //рисуем таблицу по фильтру AdGroup

                DrawCorrectColumnsForSponsoredProducts(_advProductsList, dgv_Targeting);

                for (int i = 0; i < _advProductsList.Count; i++)
                {
                    var index = dgv_Targeting.Rows.Add();
                    for (int j = 0; j < _advProductsList[0].ColumnCount; j++)
                    {
                        dgv_Targeting.Rows[index].Cells[j].Value = _advProductsList[i].ReadData(j);
                    }
                }
            }

            btn_Export.Text = "Экспорт в файл (" + dgv_Targeting.RowCount + ")";
        }*/
        
        /* Рисуем таблицу dgv_SponsoredBrands и заполняем её данными */
        /*private void DrawTableForSponsoredBrands(List<AdvertisingBrandsModel> _advBrandsList)
        {
            //рисуем таблицу для Sponsored Brands
            dgv_AdvProducts.Visible = false;
            dgv_adGroups.Visible = false;
            dgv_Targeting.Visible = false;

            dgv_AdvBrands.Visible = true;

            dgv_AdvBrands.Rows.Clear();
            dgv_AdvBrands.Columns.Clear();

            if (_advBrandsList.Count > 0)
            {
                //рисуем таблицу для Sponsored Products

                DrawCorrectColumnsForSponsoredBrands(_advBrandsList);

                DrawFirstRowForSponsoredBrands(_advBrandsList);

                for (int i = 0; i < _advBrandsList.Count; i++)
                {
                    var index = dgv_AdvBrands.Rows.Add();
                    for (int j = 0; j < _advBrandsList[0].ColumnCount; j++)
                    {
                        dgv_AdvBrands.Rows[index].Cells[j].Value = _advBrandsList[i].ReadData(j);
                    }
                }
            }

            btn_Export.Text = "Экспорт в файл (" + (dgv_AdvBrands.RowCount - 1) + ")";
        }*/

        /*public void GetAdvertisingBrandsListToShow(object _advBrandsList)
        {

            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            SponsoredProductMode = false;
            SponsoredBrandMode = true;

            advBrandsList = (List<AdvertisingBrandsModel>)_advBrandsList;
            DrawTableForSponsoredBrands(advBrandsList);
        }*/

        /* Получаем список advProductsList и рисуем его в таблице dgv_AdvProducts */
        public void GetAdvertisingProductsListToShow(object _advProductsList, object _advProductsListOriginal, string _compareMode, object _pList, string _dateMode, string _object, int _prodId)
        {
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            SponsoredProductMode = true;
            SponsoredBrandMode = false;

            advProductsList = (List<AdvertisingProductsModel>)_advProductsList;
            advProductsListOriginal = (List<AdvertisingProductsModel>)_advProductsListOriginal;

            if (_compareMode.Equals("targetinginadgroups"))
            {
                ResetCompareModes();
                targetingInAdgroupsMode = true;
            }
            else if (_compareMode.Equals("adgroupsincampaigns"))
            {
                ResetCompareModes();
                adgroupsInCampaignsMode = true;
                this.Text = "По группам";
            }
            else if (_compareMode.Equals("campaigninproducts"))
            {
                ResetCompareModes();
                campaignInProductsMode = true;
                this.Text = "По кампаниям";
            }
            else if (_compareMode.Equals("productsinmarketplaces"))
            {
                ResetCompareModes();
                productsInMarketplaces = true;
                this.Text = "По товарам";
            }

            if (_dateMode.Equals("days"))
            {
                ResetDateModes();
                byDays = true;
            }
            else if (_dateMode.Equals("weeks"))
            {
                ResetDateModes();
                byWeeks = true;
            }
            else if (_dateMode.Equals("months"))
            {
                ResetDateModes();
                byMonths = true;
            }
            else if (_dateMode.Equals("custom"))
            {
                ResetDateModes();
                byCustom = true;
            }

            pList = (List<ProductsModel>)_pList;

            if (byCustom)
                DrawTableForSponsoredProducts(advProductsList);
            else if (byMonths)
            {
                int timeSpan = ((EndDate - StartDate).Days + 1) / 31;
                if (adgroupsInCampaignsMode)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "months", _prodId);
                }
                else if (campaignInProductsMode)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "months", _prodId);
                }
                else if (productsInMarketplaces)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "months");
                }

                DrawLastColumn();
            }
            else if (byWeeks)
            {
                int timeSpan = ((EndDate - StartDate).Days + 1) / 7;
                if (adgroupsInCampaignsMode)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "weeks", _prodId);
                }
                else if (campaignInProductsMode)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "weeks", _prodId);
                }
                else if (productsInMarketplaces)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "weeks");
                }

                DrawLastColumn();
            }
            else if (byDays)
            {
                int timeSpan = (EndDate - StartDate).Days + 1;
                if (adgroupsInCampaignsMode)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "days", _prodId);
                }
                else if (campaignInProductsMode)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "days", _prodId);
                }
                else if (productsInMarketplaces)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "days");
                }

                DrawLastColumn();
            }
        }

        private void DrawTableForProductsInMarketplacesMode(string asins, int _timeSpan, string _mode)
        {
            DrawFirstColumn();
            this.Text += " - " + advFilter.GetProductNameFromAsins(asins);

            DateTime workingEndDate = EndDate;
            DateTime workingStartDate = workingEndDate.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

            if (_mode.Equals("months"))
            {
                workingStartDate = workingStartDate.AddDays(-30);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnProduct(workingStartDate, workingEndDate, asins);

                    workingEndDate = workingEndDate.AddDays(-31);
                    workingStartDate = workingStartDate.AddDays(-31);
                }
            }
            else if (_mode.Equals("weeks"))
            {
                workingStartDate = workingStartDate.AddDays(-6);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnProduct(workingStartDate, workingEndDate, asins);

                    workingEndDate = workingEndDate.AddDays(-7);
                    workingStartDate = workingStartDate.AddDays(-7);
                }
            }
            else if (_mode.Equals("days"))
            {
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnProduct(workingStartDate, workingEndDate, asins);

                    workingEndDate = workingEndDate.AddDays(-1);
                    workingStartDate = workingStartDate.AddDays(-1);
                }
            }
        }

        private void DrawColumnProduct(DateTime _startDate, DateTime _endDate, string _asins)
        {
            int Impressions = 0;
            int Clicks = 0;
            double CTR = 0;
            double CPC = 0;
            double Spend = 0;
            double Sales = 0;
            double ACoS = 0;
            double RoAS = 0;
            int Orders = 0;
            int Units = 0;
            double Conversion = 0;
            double AdvSKUUnits = 0;
            double OtherSKUUnits = 0;
            double AdvSKUSales = 0;
            double OtherSKUSales = 0;


            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (advProductsList[i].UpdateDate >= _startDate && advProductsList[i].UpdateDate <= _endDate && _asins.Contains(advProductsList[i].ProductId.ToString()))
                {
                    Impressions += advProductsList[i].Impressions;
                    Clicks += advProductsList[i].Clicks;
                    Spend += advProductsList[i].Spend;
                    Sales += advProductsList[i].Sales;
                    Orders += advProductsList[i].Orders;
                    Units += advProductsList[i].Units;
                    AdvSKUUnits += advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits += advProductsList[i].OtherSKUUnits;
                    AdvSKUSales += advProductsList[i].AdvSKUSales;
                    OtherSKUSales += advProductsList[i].OtherSKUSales;
                }
            }

            Spend = Math.Round(Spend, 2);
            Sales = Math.Round(Sales, 2);
            AdvSKUSales = Math.Round(AdvSKUSales, 2);
            OtherSKUSales = Math.Round(OtherSKUSales, 2);

            if (Impressions != 0)
                CTR = Math.Round((double)Clicks / Impressions * 100, 2);
            else
                CTR = 0;

            if (Clicks != 0)
                CPC = Math.Round(Spend / Clicks, 2);
            else
                CPC = 0;

            if (Sales != 0)
                ACoS = Math.Round(Spend / Sales * 100, 2);
            else
                ACoS = 0;

            if (Spend != 0)
                RoAS = Math.Round(Sales / Spend, 2);
            else
                RoAS = 0;

            if (Clicks != 0)
                Conversion = Math.Round((double)Orders / Clicks * 100, 2);
            else
                Conversion = 0;


            dgv_AdvProducts.Columns.Add(_startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5), _startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5) + "\n" + GetMonth(_startDate.Month));
            dgv_AdvProducts.Rows[0].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            dgv_AdvProducts.Rows[1].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            dgv_AdvProducts.Rows[2].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            dgv_AdvProducts.Rows[3].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            dgv_AdvProducts.Rows[4].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            dgv_AdvProducts.Rows[5].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            dgv_AdvProducts.Rows[6].Cells[dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            dgv_AdvProducts.Rows[7].Cells[dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            dgv_AdvProducts.Rows[8].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            dgv_AdvProducts.Rows[9].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Units;
            dgv_AdvProducts.Rows[10].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            dgv_AdvProducts.Rows[11].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            dgv_AdvProducts.Rows[12].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            dgv_AdvProducts.Rows[13].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            dgv_AdvProducts.Rows[14].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            dgv_AdvProducts.Columns[dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void DrawTableForCampaignInProductsMode(string _campaign, int _timeSpan, string _mode, int _prodId)
        {
            DrawFirstColumn();
            this.Text += " - " + _campaign;

            DateTime workingEndDate = EndDate;
            DateTime workingStartDate = workingEndDate.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

            if (_mode.Equals("months"))
            {
                workingStartDate = workingStartDate.AddDays(-30);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnCampaign(workingStartDate, workingEndDate, _campaign, _prodId);

                    workingEndDate = workingEndDate.AddDays(-31);
                    workingStartDate = workingStartDate.AddDays(-31);
                }
            }
            else if (_mode.Equals("weeks"))
            {
                workingStartDate = workingStartDate.AddDays(-6);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnCampaign(workingStartDate, workingEndDate, _campaign, _prodId);

                    workingEndDate = workingEndDate.AddDays(-7);
                    workingStartDate = workingStartDate.AddDays(-7);
                }
            }
            else if (_mode.Equals("days"))
            {
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnCampaign(workingStartDate, workingEndDate, _campaign, _prodId);

                    workingEndDate = workingEndDate.AddDays(-1);
                    workingStartDate = workingStartDate.AddDays(-1);
                }
            }
        }

        private void DrawColumnCampaign(DateTime _startDate, DateTime _endDate, string _campaign, int _prodId)
        {
            int Impressions = 0;
            int Clicks = 0;
            double CTR = 0;
            double CPC = 0;
            double Spend = 0;
            double Sales = 0;
            double ACoS = 0;
            double RoAS = 0;
            int Orders = 0;
            int Units = 0;
            double Conversion = 0;
            double AdvSKUUnits = 0;
            double OtherSKUUnits = 0;
            double AdvSKUSales = 0;
            double OtherSKUSales = 0;

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (advProductsList[i].UpdateDate >= _startDate && advProductsList[i].UpdateDate <= _endDate && advProductsList[i].ProductId == _prodId && _campaign.Contains(advProductsList[i].CampaignName))
                {
                    Impressions += advProductsList[i].Impressions;
                    Clicks += advProductsList[i].Clicks;
                    Spend += advProductsList[i].Spend;
                    Sales += advProductsList[i].Sales;
                    Orders += advProductsList[i].Orders;
                    Units += advProductsList[i].Units;
                    AdvSKUUnits += advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits += advProductsList[i].OtherSKUUnits;
                    AdvSKUSales += advProductsList[i].AdvSKUSales;
                    OtherSKUSales += advProductsList[i].OtherSKUSales;
                }
            }

            Spend = Math.Round(Spend, 2);
            Sales = Math.Round(Sales, 2);
            AdvSKUSales = Math.Round(AdvSKUSales, 2);
            OtherSKUSales = Math.Round(OtherSKUSales, 2);

            if (Impressions != 0)
                CTR = Math.Round((double)Clicks / Impressions * 100, 2);
            else
                CTR = 0;

            if (Clicks != 0)
                CPC = Math.Round(Spend / Clicks, 2);
            else
                CPC = 0;

            if (Sales != 0)
                ACoS = Math.Round(Spend / Sales * 100, 2);
            else
                ACoS = 0;

            if (Spend != 0)
                RoAS = Math.Round(Sales / Spend, 2);
            else
                RoAS = 0;

            if (Clicks != 0)
                Conversion = Math.Round((double)Orders / Clicks * 100, 2);
            else
                Conversion = 0;


            dgv_AdvProducts.Columns.Add(_startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5), _startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5) + "\n" + GetMonth(_startDate.Month));
            dgv_AdvProducts.Rows[0].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            dgv_AdvProducts.Rows[1].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            dgv_AdvProducts.Rows[2].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            dgv_AdvProducts.Rows[3].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            dgv_AdvProducts.Rows[4].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            dgv_AdvProducts.Rows[5].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            dgv_AdvProducts.Rows[6].Cells[dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            dgv_AdvProducts.Rows[7].Cells[dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            dgv_AdvProducts.Rows[8].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            dgv_AdvProducts.Rows[9].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Units;
            dgv_AdvProducts.Rows[10].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            dgv_AdvProducts.Rows[11].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            dgv_AdvProducts.Rows[12].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            dgv_AdvProducts.Rows[13].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            dgv_AdvProducts.Rows[14].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            dgv_AdvProducts.Columns[dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void DrawTableForAdGroupsInCampaignsMode(string _adGroup, int _timeSpan, string _mode, int _prodId)
        {
            DrawFirstColumn();
            this.Text += " - " + _adGroup;

            DateTime workingEndDate = EndDate;
            DateTime workingStartDate = workingEndDate.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

            if (_mode.Equals("months"))
            {
                workingStartDate = workingStartDate.AddDays(-30);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnAdGroup(workingStartDate, workingEndDate, _adGroup, _prodId);

                    workingEndDate = workingEndDate.AddDays(-31);
                    workingStartDate = workingStartDate.AddDays(-31);
                }
            }
            else if (_mode.Equals("weeks"))
            {
                workingStartDate = workingStartDate.AddDays(-6);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnAdGroup(workingStartDate, workingEndDate, _adGroup, _prodId);

                    workingEndDate = workingEndDate.AddDays(-7);
                    workingStartDate = workingStartDate.AddDays(-7);
                }
            }
            else if (_mode.Equals("days"))
            {
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnAdGroup(workingStartDate, workingEndDate, _adGroup, _prodId);
                    
                    workingEndDate = workingEndDate.AddDays(-1);
                    workingStartDate = workingStartDate.AddDays(-1);
                }
            }
        }

        private void DrawColumnAdGroup(DateTime _startDate, DateTime _endDate, string _adGroup, int _prodId)
        {
            int Impressions = 0;
            int Clicks = 0;
            double CTR = 0;
            double CPC = 0;
            double Spend = 0;
            double Sales = 0;
            double ACoS = 0;
            double RoAS = 0;
            int Orders = 0;
            int Units = 0;
            double Conversion = 0;
            double AdvSKUUnits = 0;
            double OtherSKUUnits = 0;
            double AdvSKUSales = 0;
            double OtherSKUSales = 0;

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (advProductsList[i].UpdateDate >= _startDate && advProductsList[i].UpdateDate <= _endDate && _adGroup.Contains(advProductsList[i].AdGroupName) && advProductsList[i].ProductId == _prodId)
                {
                    Impressions += advProductsList[i].Impressions;
                    Clicks += advProductsList[i].Clicks;
                    Spend += advProductsList[i].Spend;
                    Sales += advProductsList[i].Sales;
                    Orders += advProductsList[i].Orders;
                    Units += advProductsList[i].Units;
                    AdvSKUUnits += advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits += advProductsList[i].OtherSKUUnits;
                    AdvSKUSales += advProductsList[i].AdvSKUSales;
                    OtherSKUSales += advProductsList[i].OtherSKUSales;
                }
            }

            Spend = Math.Round(Spend, 2);
            Sales = Math.Round(Sales, 2);
            AdvSKUSales = Math.Round(AdvSKUSales, 2);
            OtherSKUSales = Math.Round(OtherSKUSales, 2);

            if (Impressions != 0)
                CTR = Math.Round((double)Clicks / Impressions * 100, 2);
            else
                CTR = 0;

            if (Clicks != 0)
                CPC = Math.Round(Spend / Clicks, 2);
            else
                CPC = 0;

            if (Sales != 0)
                ACoS = Math.Round(Spend / Sales * 100, 2);
            else
                ACoS = 0;

            if (Spend != 0)
                RoAS = Math.Round(Sales / Spend, 2);
            else
                RoAS = 0;

            if (Clicks != 0)
                Conversion = Math.Round((double)Orders / Clicks * 100, 2);
            else
                Conversion = 0;


            dgv_AdvProducts.Columns.Add(_startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5), _startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5) + "\n" + GetMonth(_startDate.Month));
            dgv_AdvProducts.Rows[0].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            dgv_AdvProducts.Rows[1].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            dgv_AdvProducts.Rows[2].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            dgv_AdvProducts.Rows[3].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            dgv_AdvProducts.Rows[4].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            dgv_AdvProducts.Rows[5].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            dgv_AdvProducts.Rows[6].Cells[dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            dgv_AdvProducts.Rows[7].Cells[dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            dgv_AdvProducts.Rows[8].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            dgv_AdvProducts.Rows[9].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Units;
            dgv_AdvProducts.Rows[10].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            dgv_AdvProducts.Rows[11].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            dgv_AdvProducts.Rows[12].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            dgv_AdvProducts.Rows[13].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            dgv_AdvProducts.Rows[14].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            dgv_AdvProducts.Columns[dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;             
        }

        private void DrawFirstColumn()
        {
            dgv_AdvProducts.Rows.Clear();
            dgv_AdvProducts.Columns.Clear();   
            dgv_AdvProducts.Columns.Add("", "");
            var index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Impressions";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Clicks";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "CTR";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "CPC";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Spend";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Sales";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "ACoS";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "RoAS";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Orders";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Units";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Conversion";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Adv SKU Units";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Other SKU Units";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Adv SKU Sales";
            index = dgv_AdvProducts.Rows.Add();
            dgv_AdvProducts.Rows[index].Cells[dgv_AdvProducts.ColumnCount - 1].Value = "Other SKU Sales";

            dgv_AdvProducts.Columns[0].Width = 125;
            dgv_AdvProducts.Columns[0].Frozen = true;
            dgv_AdvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void DrawLastColumn()
        {
            //int.Parse(dataGridView1.Rows[0].Cells[i].Value.ToString());
            int Impressions = 0;
            int Clicks = 0;
            double CTR = 0;
            double CPC = 0;
            double Spend = 0;
            double Sales = 0;
            double ACoS = 0;
            double RoAS = 0;
            int Orders = 0;
            int Units = 0;
            double Conversion = 0;
            double AdvSKUUnits = 0;
            double OtherSKUUnits = 0;
            double AdvSKUSales = 0;
            double OtherSKUSales = 0;

            for (int i = 1; i < dgv_AdvProducts.Columns.Count; i++)
            {
                Impressions += int.Parse(dgv_AdvProducts.Rows[0].Cells[i].Value.ToString());
                Clicks += int.Parse(dgv_AdvProducts.Rows[1].Cells[i].Value.ToString());
                Spend += double.Parse(dgv_AdvProducts.Rows[4].Cells[i].Value.ToString());
                Sales += double.Parse(dgv_AdvProducts.Rows[5].Cells[i].Value.ToString());
                Orders += int.Parse(dgv_AdvProducts.Rows[8].Cells[i].Value.ToString());
                Units += int.Parse(dgv_AdvProducts.Rows[9].Cells[i].Value.ToString());
                AdvSKUUnits += int.Parse(dgv_AdvProducts.Rows[11].Cells[i].Value.ToString());
                OtherSKUUnits += int.Parse(dgv_AdvProducts.Rows[12].Cells[i].Value.ToString());
                AdvSKUSales += double.Parse(dgv_AdvProducts.Rows[13].Cells[i].Value.ToString());
                OtherSKUSales += double.Parse(dgv_AdvProducts.Rows[14].Cells[i].Value.ToString());
            }

            Spend = Math.Round(Spend, 2);
            Sales = Math.Round(Sales, 2);
            AdvSKUSales = Math.Round(AdvSKUSales, 2);
            OtherSKUSales = Math.Round(OtherSKUSales, 2);

            if (Impressions != 0)
                CTR = Math.Round((double)Clicks / Impressions * 100, 2);
            else
                CTR = 0;

            if (Clicks != 0)
                CPC = Math.Round(Spend / Clicks, 2);
            else
                CPC = 0;

            if (Sales != 0)
                ACoS = Math.Round(Spend / Sales * 100, 2);
            else
                ACoS = 0;

            if (Spend != 0)
                RoAS = Math.Round(Sales / Spend, 2);
            else
                RoAS = 0;

            if (Clicks != 0)
                Conversion = Math.Round((double)Orders / Clicks * 100, 2);
            else
                Conversion = 0;


            dgv_AdvProducts.Columns.Add("summ", "Всего");
            dgv_AdvProducts.Rows[0].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            dgv_AdvProducts.Rows[1].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            dgv_AdvProducts.Rows[2].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            dgv_AdvProducts.Rows[3].Cells[dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            dgv_AdvProducts.Rows[4].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            dgv_AdvProducts.Rows[5].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            dgv_AdvProducts.Rows[6].Cells[dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            dgv_AdvProducts.Rows[7].Cells[dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            dgv_AdvProducts.Rows[8].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            dgv_AdvProducts.Rows[9].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Units;
            dgv_AdvProducts.Rows[10].Cells[dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            dgv_AdvProducts.Rows[11].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            dgv_AdvProducts.Rows[12].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            dgv_AdvProducts.Rows[13].Cells[dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            dgv_AdvProducts.Rows[14].Cells[dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            dgv_AdvProducts.Columns[dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        /* Получаем имя товара по заданному productId */
        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
        }

        /* Получаем список advProductsList с фильтром по выбранной AdGroup и рисуем его в таблице dgv_adGroups */
        public void GetAdGroupsListToShow(object _advProductsList)
        {
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            //DrawTableForAdGroups((List<AdvertisingProductsModel>)_advProductsList);
        }

        /* Получаем список advProductsList с фильтром по выбранной Targeting и рисуем его в таблице dgv_Targeting */
        public void GetTargetingListToShow(object _advProductsList)
        {
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            //DrawTableForTargeting((List<AdvertisingProductsModel>)_advProductsList);
        }

        /* Обрабатываем перемещение курсора по таблице dgv_AdvProducts */
        private void dgv_AdvProducts_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                //dgv_AdvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        /* Обрабатываем перемещение курсора по таблице dgv_adGroups */
        /*private void dgv_adGroups_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgv_adGroups.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }*/

        /* Обрабатываем перемещение курсора по таблице dgv_Targeting */
        /*private void dgv_Targeting_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgv_Targeting.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }*/

        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список */
        private void dgv_AdvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AdvertisingProductsShowMode = false;
            AdGroupShowMode = true;
            TargetingShowMode = false;

            string adGroupName = "";
            int marketpLaceId = 0;
            int campaignId = 0;
            int productId = 0;

            adGroupName = dgv_AdvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
            marketpLaceId = int.Parse(dgv_AdvProducts.Rows[e.RowIndex].Cells[22].Value.ToString());
            campaignId = int.Parse(dgv_AdvProducts.Rows[e.RowIndex].Cells[23].Value.ToString());
            productId = int.Parse(dgv_AdvProducts.Rows[e.RowIndex].Cells[24].Value.ToString());

            ReportAdvertisingFilterView af = new ReportAdvertisingFilterView(this);

            af.ShowDetailedByAdGroup(adGroupName, marketpLaceId, campaignId, productId, advProductsList);
        }

        /* Фильтруем записи по выбранной Targeting и получаем обновленный список */
        /*private void dgv_adGroups_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AdvertisingProductsShowMode = false;
            AdGroupShowMode = false;
            TargetingShowMode = true;

            string adGroupName = "";
            string targeting = "";
            int marketpLaceId = 0;
            int campaignId = 0;
            int productId = 0;

            adGroupName = dgv_adGroups.Rows[e.RowIndex].Cells[3].Value.ToString();
            targeting = dgv_adGroups.Rows[e.RowIndex].Cells[4].Value.ToString();
            marketpLaceId = int.Parse(dgv_adGroups.Rows[e.RowIndex].Cells[22].Value.ToString());
            campaignId = int.Parse(dgv_adGroups.Rows[e.RowIndex].Cells[23].Value.ToString());
            productId = int.Parse(dgv_adGroups.Rows[e.RowIndex].Cells[24].Value.ToString());

            ReportAdvertisingFilterView af = new ReportAdvertisingFilterView(this);

            af.ShowDetailedByTargeting(targeting, adGroupName, marketpLaceId, campaignId, productId, advProductsList);
        }*/

        private void AdvertisingReportView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (advFilter != null)
                advFilter.Close();
        }

        private void AdvertisingReportView_SizeChanged(object sender, EventArgs e)
        {
            dgv_AdvProducts.Width = this.Width - 30;
            dgv_AdvProducts.Height = this.Height - 80;

            /*dgv_adGroups.Width = this.Width - 30;
            dgv_adGroups.Height = this.Height - 80;

            dgv_Targeting.Width = this.Width - 30;
            dgv_Targeting.Height = this.Height - 80;

            dgv_AdvBrands.Width = this.Width - 30;
            dgv_AdvBrands.Height = this.Height - 80;*/
            
            btn_Filter.Location = new System.Drawing.Point(this.Width - btn_Filter.Size.Width - 20, btn_Filter.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportAdvertisingViewFixed advFix = new ReportAdvertisingViewFixed(StartDate, EndDate, advProductsListOriginal, this.Text);
            advFix.UpdateDGV(dgv_AdvProducts);
            advFix.Show();
        }
    }
}
