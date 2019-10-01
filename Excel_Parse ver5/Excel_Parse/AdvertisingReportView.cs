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
    public partial class AdvertisingReportView : Form
    {
        private MainFormView mf;
        private AdvertisingReportFilterView advFilter;

        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingBrandsModel> advBrandsList;

        public bool SponsoredProductMode { get; set; }
        public bool SponsoredBrandMode { get; set; }
        public bool AdvertisingProductsShowMode { get; set; }
        public bool AdGroupShowMode { get; set; }
        public bool TargetingShowMode { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        /* Конструктор */
        public AdvertisingReportView(MainFormView _mf)
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



            advProductsList = new List<AdvertisingProductsModel> { };
            advBrandsList = new List<AdvertisingBrandsModel> { };
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
                advFilter = new AdvertisingReportFilterView(this);
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
                else if (AdGroupShowMode)        //если сохраняем из таблицы dgv_adGroupss
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
                }
            }
            else if (SponsoredBrandMode)       //если смотрим Sponsored Brands
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
            }

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

            dgv.Columns[0].Width = 70;
            dgv.Columns[1].Width = 60;
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].Width = 200;
            dgv.Columns[4].Width = 200;

            for (int i = 0; i < _advProductsList[0].ColumnCount; i++)
            {
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /* Рисуем "правильную" таблицу с заголовками и шириной столбцов для Sponsored Brands */
        private void DrawCorrectColumnsForSponsoredBrands(List<AdvertisingBrandsModel> _advBrandsList)
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

            dgv_AdvBrands.Columns[0].Width = 70;
            dgv_AdvBrands.Columns[1].Width = 60;
            dgv_AdvBrands.Columns[2].Width = 200;
            dgv_AdvBrands.Columns[3].Width = 200;

            for (int i = 0; i < _advBrandsList[0].ColumnCount; i++)
            {
                dgv_AdvBrands.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /* Рисуем таблицу dgv_AdvProducts и заполняем её данными */
        private void DrawTableForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList)
        {
            dgv_AdvProducts.Visible = true;
            dgv_AdvBrands.Visible = false;
            dgv_adGroups.Visible = false;
            dgv_Targeting.Visible = false;

            dgv_AdvProducts.Rows.Clear();
            dgv_AdvProducts.Columns.Clear();

            if (_advProductsList.Count > 0)
            {
                DrawCorrectColumnsForSponsoredProducts(_advProductsList, dgv_AdvProducts);

                for (int i = 0; i < _advProductsList.Count; i++)
                {
                    var index = dgv_AdvProducts.Rows.Add();
                    for (int j = 1; j < _advProductsList[0].ColumnCount; j++)
                    {
                        dgv_AdvProducts.Rows[index].Cells[j].Value = _advProductsList[i].ReadData(j);
                    }
                }
            }

            btn_Export.Text = "Экспорт в файл (" + dgv_AdvProducts.RowCount + ")";
        }

        /* Рисуем таблицу dgv_adGroups и заполняем её данными */
        private void DrawTableForAdGroups(List<AdvertisingProductsModel> _advProductsList)
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
        }

        /* Рисуем таблицу dgv_Targeting и заполняем её данными */
        private void DrawTableForTargeting(List<AdvertisingProductsModel> _advProductsList)
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
        }
        
        /* Рисуем таблицу dgv_SponsoredBrands и заполняем её данными */
        private void DrawTableForSponsoredBrands(List<AdvertisingBrandsModel> _advBrandsList)
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

                for (int i = 0; i < _advBrandsList.Count; i++)
                {
                    var index = dgv_AdvBrands.Rows.Add();
                    for (int j = 0; j < _advBrandsList[0].ColumnCount; j++)
                    {
                        dgv_AdvBrands.Rows[index].Cells[j].Value = _advBrandsList[i].ReadData(j);
                    }
                }
            }

            btn_Export.Text = "Экспорт в файл (" + dgv_AdvBrands.RowCount + ")";
        }

        public void GetAdvertisingBrandsListToShow(object _advBrandsList)
        {

            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            SponsoredProductMode = false;
            SponsoredBrandMode = true;

            advBrandsList = (List<AdvertisingBrandsModel>)_advBrandsList;
            DrawTableForSponsoredBrands(advBrandsList);
        }

        /* Получаем список advProductsList и рисуем его в таблице dgv_AdvProducts */
        public void GetAdvertisingProductsListToShow(object _advProductsList)
        {
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            SponsoredProductMode = true;
            SponsoredBrandMode = false;

            advProductsList = (List<AdvertisingProductsModel>)_advProductsList;
            DrawTableForSponsoredProducts(advProductsList);
        }

        /* Получаем список advProductsList с фильтром по выбранной AdGroup и рисуем его в таблице dgv_adGroups */
        public void GetAdGroupsListToShow(object _advProductsList)
        {
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            DrawTableForAdGroups((List<AdvertisingProductsModel>)_advProductsList);
        }

        /* Получаем список advProductsList с фильтром по выбранной Targeting и рисуем его в таблице dgv_Targeting */
        public void GetTargetingListToShow(object _advProductsList)
        {
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            DrawTableForTargeting((List<AdvertisingProductsModel>)_advProductsList);
        }

        /* Обрабатываем перемещение курсора по таблице dgv_AdvProducts */
        private void dgv_AdvProducts_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                //dgv_AdvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        /* Обрабатываем перемещение курсора по таблице dgv_adGroups */
        private void dgv_adGroups_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgv_adGroups.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        /* Обрабатываем перемещение курсора по таблице dgv_Targeting */
        private void dgv_Targeting_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgv_Targeting.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

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

            AdvertisingReportFilterView af = new AdvertisingReportFilterView(this);

            af.ShowDetailedByAdGroup(adGroupName, marketpLaceId, campaignId, productId, advProductsList);
        }

        /* Фильтруем записи по выбранной Targeting и получаем обновленный список */
        private void dgv_adGroups_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

            AdvertisingReportFilterView af = new AdvertisingReportFilterView(this);

            af.ShowDetailedByTargeting(targeting, adGroupName, marketpLaceId, campaignId, productId, advProductsList);
        }

        private void AdvertisingReportView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (advFilter != null)
                advFilter.Close();
        }

        private void AdvertisingReportView_SizeChanged(object sender, EventArgs e)
        {
            dgv_AdvProducts.Width = this.Width - 30;
            dgv_AdvProducts.Height = this.Height - 80;

            dgv_adGroups.Width = this.Width - 30;
            dgv_adGroups.Height = this.Height - 80;

            dgv_Targeting.Width = this.Width - 30;
            dgv_Targeting.Height = this.Height - 80;

            dgv_AdvBrands.Width = this.Width - 30;
            dgv_AdvBrands.Height = this.Height - 80;
            
            btn_Filter.Location = new System.Drawing.Point(this.Width - btn_Filter.Size.Width - 20, btn_Filter.Location.Y);
        }
    }
}
