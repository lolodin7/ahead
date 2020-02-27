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
        
        /* 
        // Экспорт данных из таблицы 
        private void btn_Export1_Click(object sender, EventArgs e)
        {
            bool okData = false;

            this.Cursor = Cursors.WaitCursor;

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);


            if (dgv_AdvProducts1.RowCount > 0)
            {
                for (int i = 0; i < dgv_AdvProducts1.ColumnCount - 4; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dgv_AdvProducts1.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgv_AdvProducts1.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_AdvProducts1.ColumnCount - 4; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dgv_AdvProducts1.Rows[i].Cells[j].Value;
                    }
                }

                saveFileDialog1.FileName = lb_StartDate1.Text + "-" + lb_EndDate1.Text + " Sponsored Products - All";

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
                
        // Создаем "фиксированное окно"; делаем слепок таблицы в новое окно 
        private void button1_Click(object sender, EventArgs e)
        {
            ReportAdvertisingViewFixed advFix = new ReportAdvertisingViewFixed(StartDate1, EndDate1, advProductsListOriginal1, this.Text);
            advFix.UpdateDGV(dgv_AdvProducts1);

            if (adgroupsInCampaignsMode1) { advFix.SetAdgroupsInCampaignsMode(); }
            else if (campaignInProductsMode1) { advFix.SetCampaignInProductsMode(); }
            else if (productsInMarketplaces1) { advFix.SetProductsInMarketplaces(); }
            else if (targetingInAdgroupsMode1) { advFix.SetTargetingInAdgroupsMode(); }

            if (byDays1) { advFix.SetByDaysMode(); }
            else if (byWeeks1) { advFix.SetByWeeksMode(); }
            else if (byMonths1) { advFix.SetByMonthsMode(); }
            else if (byCustom1) { advFix.SetByCustomDateMode(); }

            advFix.Show();
        }
        */




        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        /* -------------------------------------------------------------------- General -------------------------------------------------------------------- */
        private MainFormView mf;
        private ProductsController prodController;
        private AdvertisingController advertController;
        private MarketplaceController mpController;
        private bool copying;

        /* -------------------------------------------------------------------- 1 -------------------------------------------------------------------- */
        private bool targetingInAdgroupsMode1, adgroupsInCampaignsMode1, campaignInProductsMode1, productsInMarketplaces1;
        private bool byDays1, byWeeks1, byMonths1, byCustom1;

        private DateTime StartDate1, EndDate1;

        List<string> checkedMarkeplaces1, checkedProducts1, checkedCampaigns1, checkedAdGroups1, AdGroupsList1, checkedTargeting1, targetingList1;
        List<string> checkedMarkeplacesTMP1, checkedProductsTMP1, checkedCampaignsTMP1, checkedAdGroupsTMP1, checkedTargetingTMP1;
        List<string> tbProductsFilterItems1, tbCampaignsFilterItems1, tbAdGroupsFilterItems1, tbTargetingFilterItems1;
        List<string> tbProductsFilterItemsPrev1, tbCampaignsFilterItemsPrev1, tbAdGroupsFilterItemsPrev1, tbTargetingFilterItemsPrev1;
        
        private List<string> uniqueCampaigns1;
        private List<string> uniqueAdGroups1;
        private List<string> uniqueTargeting1;
        private List<CmapaignAndIdStruct> campsidsList1;

        private List<AdvertisingProductsModel> advProductsList1;
        private List<AdvertisingProductsModel> summaryAdvProductsList1;
        private List<AdvertisingProductsModel> advProductsListOriginal1;
        
        private List<AdvertisingBrandsModel> advBrandsList1;
        private List<AdvertisingBrandsModel> summaryAdvBrandsList1;

        private List<ProductsModel> pList1;

        private List<MarketplaceModel> mpList1;

        private List<MapNameId> AP_campaignIdsList1;
        private List<MapNameId> AB_campaignIdsList1;

        private List<MapNameId> AP_campaignIdsListForActiveCheck1;

        private List<AdvertisingProductsModel> filterAdvProductsList1;       //список Sponsored Products с применением фильтра по таблице
        private List<AdvertisingBrandsModel> filterAdvBrandsList1;           //список Sponsored Brands с применением фильтра по таблице       



        /* -------------------------------------------------------------------- 2 -------------------------------------------------------------------- */
        private bool targetingInAdgroupsMode2, adgroupsInCampaignsMode2, campaignInProductsMode2, productsInMarketplaces2;
        private bool byDays2, byWeeks2, byMonths2, byCustom2;

        List<string> checkedMarkeplaces2, checkedProducts2, checkedCampaigns2, checkedAdGroups2, AdGroupsList2, checkedTargeting2, targetingList2;
        List<string> checkedMarkeplacesTMP2, checkedProductsTMP2, checkedCampaignsTMP2, checkedAdGroupsTMP2, checkedTargetingTMP2;
        List<string> tbProductsFilterItems2, tbCampaignsFilterItems2, tbAdGroupsFilterItems2, tbTargetingFilterItems2;
        List<string> tbProductsFilterItemsPrev2, tbCampaignsFilterItemsPrev2, tbAdGroupsFilterItemsPrev2, tbTargetingFilterItemsPrev2;

        private DateTime StartDate2, EndDate2;

        private List<string> uniqueCampaigns2;
        private List<string> uniqueAdGroups2;
        private List<string> uniqueTargeting2;
        private List<CmapaignAndIdStruct> campsidsList2;

        private List<AdvertisingProductsModel> advProductsList2;
        private List<AdvertisingProductsModel> summaryAdvProductsList2;
        private List<AdvertisingProductsModel> advProductsListOriginal2;

        private List<AdvertisingBrandsModel> advBrandsList2;
        private List<AdvertisingBrandsModel> summaryAdvBrandsList2;

        private List<MarketplaceModel> mpList2;

        private List<ProductsModel> pList2;

        private List<MapNameId> AP_campaignIdsList2;
        private List<MapNameId> AB_campaignIdsList2;

        private List<MapNameId> AP_campaignIdsListForActiveCheck2;

        private List<AdvertisingProductsModel> filterAdvProductsList2;      //список Sponsored Products с применением фильтра по таблице
        private List<AdvertisingBrandsModel> filterAdvBrandsList2;          //список Sponsored Brands с применением фильтра по таблице  



        /* -------------------------------------------------------------------- 3 -------------------------------------------------------------------- */
        private bool targetingInAdgroupsMode3, adgroupsInCampaignsMode3, campaignInProductsMode3, productsInMarketplaces3;
        private bool byDays3, byWeeks3, byMonths3, byCustom3;

        List<string> checkedMarkeplaces3, checkedProducts3, checkedCampaigns3, checkedAdGroups3, AdGroupsList3, checkedTargeting3, targetingList3;
        List<string> checkedMarkeplacesTMP3, checkedProductsTMP3, checkedCampaignsTMP3, checkedAdGroupsTMP3, checkedTargetingTMP3;
        List<string> tbProductsFilterItems3, tbCampaignsFilterItems3, tbAdGroupsFilterItems3, tbTargetingFilterItems3;
        List<string> tbProductsFilterItemsPrev3, tbCampaignsFilterItemsPrev3, tbAdGroupsFilterItemsPrev3, tbTargetingFilterItemsPrev3;

        private DateTime StartDate3, EndDate3;

        private List<string> uniqueCampaigns3;
        private List<string> uniqueAdGroups3;
        private List<string> uniqueTargeting3;
        private List<CmapaignAndIdStruct> campsidsList3;

        private List<AdvertisingProductsModel> advProductsList3;
        private List<AdvertisingProductsModel> summaryAdvProductsList3;
        private List<AdvertisingProductsModel> advProductsListOriginal3;

        private List<AdvertisingBrandsModel> advBrandsList3;
        private List<AdvertisingBrandsModel> summaryAdvBrandsList3;

        private List<MarketplaceModel> mpList3;

        private List<ProductsModel> pList3;

        private List<MapNameId> AP_campaignIdsList3;
        private List<MapNameId> AB_campaignIdsList3;

        private List<MapNameId> AP_campaignIdsListForActiveCheck3;

        private List<AdvertisingProductsModel> filterAdvProductsList3;      //список Sponsored Products с применением фильтра по таблице
        private List<AdvertisingBrandsModel> filterAdvBrandsList3;          //список Sponsored Brands с применением фильтра по таблице  



        /* Конструктор */
        public ReportAdvertisingView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;
            mpController = new MarketplaceController(this);
            advertController = new AdvertisingController(this);
            prodController = new ProductsController(this);

            /* -------------------------- 1 -------------------------- */
            StartDate1 = DateTime.Today;
            EndDate1 = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            lb_StartDate1.Text = StartDate1.ToString().Substring(0, 10);
            lb_EndDate1.Text = StartDate1.ToString().Substring(0, 10);

            label3.Text = StartDate1.ToString().Substring(0, 10);
            label2.Text = EndDate1.ToString().Substring(0, 10);            

            advProductsList1 = new List<AdvertisingProductsModel> { };
            advProductsListOriginal1 = new List<AdvertisingProductsModel> { };
            summaryAdvProductsList1 = new List<AdvertisingProductsModel> { };
            advBrandsList1 = new List<AdvertisingBrandsModel> { };
            summaryAdvBrandsList1 = new List<AdvertisingBrandsModel> { };
            mpList1 = new List<MarketplaceModel> { };
            pList1 = new List<ProductsModel> { };

            AP_campaignIdsList1 = new List<MapNameId> { };
            AB_campaignIdsList1 = new List<MapNameId> { };

            filterAdvProductsList1 = new List<AdvertisingProductsModel> { };
            filterAdvBrandsList1 = new List<AdvertisingBrandsModel> { };
            
            checkedMarkeplaces1 = new List<string> { };
            checkedProducts1 = new List<string> { };
            checkedCampaigns1 = new List<string> { };
            checkedAdGroups1 = new List<string> { };
            AdGroupsList1 = new List<string> { };
            checkedTargeting1 = new List<string> { };
            targetingList1 = new List<string> { };
            
            checkedMarkeplacesTMP1 = new List<string> { };
            checkedProductsTMP1 = new List<string> { };
            checkedCampaignsTMP1 = new List<string> { };
            checkedAdGroupsTMP1 = new List<string> { };
            checkedTargetingTMP1 = new List<string> { };
            
            tbProductsFilterItems1 = new List<string> { };
            tbCampaignsFilterItems1 = new List<string> { };
            tbAdGroupsFilterItems1 = new List<string> { };
            tbTargetingFilterItems1 = new List<string> { };
            
            tbProductsFilterItemsPrev1 = new List<string> { };
            tbCampaignsFilterItemsPrev1 = new List<string> { };
            tbAdGroupsFilterItemsPrev1 = new List<string> { };
            tbTargetingFilterItemsPrev1 = new List<string> { };
            
            byTargetingInAdGroupsToolStripMenuItem1.Checked = true;
            by_CustomToolStripMenuItem1.Checked = true;
            DisableCustomTimeMode1();

            /* -------------------------- 2 -------------------------- */
            StartDate2 = DateTime.Today;
            EndDate2 = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            lb_StartDate2.Text = StartDate2.ToString().Substring(0, 10);
            lb_EndDate2.Text = StartDate2.ToString().Substring(0, 10);

            label10.Text = StartDate2.ToString().Substring(0, 10);
            label9.Text = EndDate2.ToString().Substring(0, 10);

            advProductsList2 = new List<AdvertisingProductsModel> { };
            advProductsListOriginal2 = new List<AdvertisingProductsModel> { };
            summaryAdvProductsList2 = new List<AdvertisingProductsModel> { };
            advBrandsList2 = new List<AdvertisingBrandsModel> { };
            summaryAdvBrandsList2 = new List<AdvertisingBrandsModel> { };
            mpList2 = new List<MarketplaceModel> { };
            pList2 = new List<ProductsModel> { };

            AP_campaignIdsList2 = new List<MapNameId> { };
            AB_campaignIdsList2 = new List<MapNameId> { };

            filterAdvProductsList2 = new List<AdvertisingProductsModel> { };
            filterAdvBrandsList2 = new List<AdvertisingBrandsModel> { };

            checkedMarkeplaces2 = new List<string> { };
            checkedProducts2 = new List<string> { };
            checkedCampaigns2 = new List<string> { };
            checkedAdGroups2 = new List<string> { };
            AdGroupsList2 = new List<string> { };
            checkedTargeting2 = new List<string> { };
            targetingList2 = new List<string> { };

            checkedMarkeplacesTMP2 = new List<string> { };
            checkedProductsTMP2 = new List<string> { };
            checkedCampaignsTMP2 = new List<string> { };
            checkedAdGroupsTMP2 = new List<string> { };
            checkedTargetingTMP2 = new List<string> { };

            tbProductsFilterItems2 = new List<string> { };
            tbCampaignsFilterItems2 = new List<string> { };
            tbAdGroupsFilterItems2 = new List<string> { };
            tbTargetingFilterItems2 = new List<string> { };

            tbProductsFilterItemsPrev2 = new List<string> { };
            tbCampaignsFilterItemsPrev2 = new List<string> { };
            tbAdGroupsFilterItemsPrev2 = new List<string> { };
            tbTargetingFilterItemsPrev2 = new List<string> { };

            byTargetingInAdGroupsToolStripMenuItem2.Checked = true;
            by_CustomToolStripMenuItem2.Checked = true;
            DisableCustomTimeMode2();

            /* -------------------------- 3 -------------------------- */
            StartDate3 = DateTime.Today;
            EndDate3 = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            label23.Text = StartDate3.ToString().Substring(0, 10);
            label22.Text = StartDate3.ToString().Substring(0, 10);

            lb_StartDate3.Text = StartDate3.ToString().Substring(0, 10);
            lb_EndDate3.Text = EndDate3.ToString().Substring(0, 10);

            advProductsList3 = new List<AdvertisingProductsModel> { };
            advProductsListOriginal3 = new List<AdvertisingProductsModel> { };
            summaryAdvProductsList3 = new List<AdvertisingProductsModel> { };
            advBrandsList3 = new List<AdvertisingBrandsModel> { };
            summaryAdvBrandsList3 = new List<AdvertisingBrandsModel> { };
            mpList3 = new List<MarketplaceModel> { };
            pList3 = new List<ProductsModel> { };

            AP_campaignIdsList3 = new List<MapNameId> { };
            AB_campaignIdsList3 = new List<MapNameId> { };

            filterAdvProductsList3 = new List<AdvertisingProductsModel> { };
            filterAdvBrandsList3 = new List<AdvertisingBrandsModel> { };

            checkedMarkeplaces3 = new List<string> { };
            checkedProducts3 = new List<string> { };
            checkedCampaigns3 = new List<string> { };
            checkedAdGroups3 = new List<string> { };
            AdGroupsList3 = new List<string> { };
            checkedTargeting3 = new List<string> { };
            targetingList3 = new List<string> { };

            checkedMarkeplacesTMP3 = new List<string> { };
            checkedProductsTMP3 = new List<string> { };
            checkedCampaignsTMP3 = new List<string> { };
            checkedAdGroupsTMP3 = new List<string> { };
            checkedTargetingTMP3 = new List<string> { };

            tbProductsFilterItems3 = new List<string> { };
            tbCampaignsFilterItems3 = new List<string> { };
            tbAdGroupsFilterItems3 = new List<string> { };
            tbTargetingFilterItems3 = new List<string> { };

            tbProductsFilterItemsPrev3 = new List<string> { };
            tbCampaignsFilterItemsPrev3 = new List<string> { };
            tbAdGroupsFilterItemsPrev3 = new List<string> { };
            tbTargetingFilterItemsPrev3 = new List<string> { };

            byTargetingInAdGroupsToolStripMenuItem3.Checked = true;
            by_CustomToolStripMenuItem3.Checked = true;
            DisableCustomTimeMode3();


            /* -------------------------- General -------------------------- */
            if (mpController.GetMarketplaces() == 1)
            {
                Fill_CLB_Marketplace1();
                Fill_CLB_Marketplace2();
                Fill_CLB_Marketplace3();
            }

            advertController.GetAP_CampaignIds(1);
            advertController.GetAP_CampaignIds(2);
            advertController.GetAP_CampaignIds(3);


            dgv_AdGroups1.Width = 1325;
            dgv_Targetings1.Width = 1325;

            dgv_AdGroups2.Width = 1325;
            dgv_Targetings2.Width = 1325;

            dgv_AdGroups3.Width = 1325;
            dgv_Targetings3.Width = 1325;
        }




        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------1--------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





        /* Получаем из контроллера данные, полученные с БД 1 */
        public void GetProductsFromDB1(object _pList)
        {
            pList1 = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД 1 */
        public void GetMarketPlacesFromDB1(object _mpList)
        {
            mpList1 = (List<MarketplaceModel>)_mpList;
        }

        /* Получаем список кампания/кампания_ид из БД 1 */
        public void GetCampaignsAndIds1(object _tmp)
        {
            campsidsList1 = (List<CmapaignAndIdStruct>)_tmp;
        }

        /* Получаем список id кампаниий AdvertisingProducts из БД 1 */
        public void GetAP_CampaignIdsFromDB1(object _campTList)
        {
            AP_campaignIdsListForActiveCheck1 = (List<MapNameId>)_campTList;
        }

        /* Получаем список кампания/кампания_ид из БД 1 */
        public void GetAdGroups1(object _tmp)
        {
            AdGroupsList1 = (List<string>)_tmp;
        }

        /* Получаем список ключей для AdGroup из БД 1 */
        public void GetTargeting1(object _tmp)
        {
            targetingList1 = (List<string>)_tmp;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetAdvertisingProductsFromDBOriginalValues1(object _advProductList)
        {
            advProductsListOriginal1 = (List<AdvertisingProductsModel>)_advProductList;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД и суммируем значения */
        public void GetAdvertisingProductsFromDBwithSummary1(object _advProductList)
        {
            advProductsList1 = (List<AdvertisingProductsModel>)_advProductList;
            if (by_CustomToolStripMenuItem1.Checked)
            {
                summaryAdvProductsList1.Clear();
                if (byTargetingInAdGroupsToolStripMenuItem1.Checked)
                {
                    MakeSummaryAdvProductListbyTargetingInAdGroups1();
                }
                else if (byAdGroupsInCampaignsToolStripMenuItem1.Checked)
                {
                    MakeSummaryAdvProductListbyAdGroupsInCampaigns1();
                }
                else if (byCampaignInProductsToolStripMenuItem1.Checked)
                {
                    MakeSummaryAdvProductListbyCampaignInProducts1();
                }
                else if (byProductsToolStripMenuItem1.Checked)
                {
                    MakeSummaryAdvProductListbyProducts1();
                }
            }
        }

        /* Заполняем combobox названиями маркетплейсов 1 */
        private void Fill_CLB_Marketplace1()
        {
            clb_Marketplace1.Items.Clear();

            for (int i = 0; i < mpList1.Count; i++)
            {
                clb_Marketplace1.Items.Add(mpList1[i].MarketPlaceName);
            }
        }

        /* Удаляем все повторы с advProductsList1, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyTargetingInAdGroups1()
        {
            List<int> alreadyUsed = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList1.Count; i++)
            {
                if (i == advProductsList1.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsList1[i].Impressions;
                    Clicks = advProductsList1[i].Clicks;
                    Spend = advProductsList1[i].Spend;
                    Sales = advProductsList1[i].Sales;
                    Orders = advProductsList1[i].Orders;
                    Units = advProductsList1[i].Units;
                    AdvSKUUnits = advProductsList1[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList1[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList1[i].AdvSKUSales;
                    OtherSKUSales = advProductsList1[i].OtherSKUSales;

                    if (i < (advProductsList1.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList1.Count; j++)
                        {
                            if (advProductsList1[i].CampaignName.Equals(advProductsList1[j].CampaignName) && advProductsList1[i].AdGroupName.Equals(advProductsList1[j].AdGroupName) && advProductsList1[i].Targeting.Equals(advProductsList1[j].Targeting) && advProductsList1[i].MatchType.Equals(advProductsList1[j].MatchType))
                            {
                                Impressions += advProductsList1[j].Impressions;
                                Clicks += advProductsList1[j].Clicks;
                                Spend += advProductsList1[j].Spend;
                                Sales += advProductsList1[j].Sales;
                                Orders += advProductsList1[j].Orders;
                                Units += advProductsList1[j].Units;
                                AdvSKUUnits += advProductsList1[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList1[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList1[j].AdvSKUSales;
                                OtherSKUSales += advProductsList1[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList1.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].UpdateDate = advProductsList1[i].UpdateDate;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CurrencyCharCode = advProductsList1[i].CurrencyCharCode;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignName = advProductsList1[i].CampaignName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdGroupName = advProductsList1[i].AdGroupName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Targeting = advProductsList1[i].Targeting;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MatchType = advProductsList1[i].MatchType;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Orders = Orders;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Units = Units;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignTypeId = advProductsList1[i].CampaignTypeId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MarketPlaceId = advProductsList1[i].MarketPlaceId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignId = advProductsList1[i].CampaignId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ProductId = advProductsList1[i].ProductId;
                }
            }
            advProductsList1.Clear();
            foreach (var t in summaryAdvProductsList1)
            {
                advProductsList1.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList1, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyAdGroupsInCampaigns1()
        {
            List<int> alreadyUsed = new List<int> { };
            List<string> alreadyUsedAdGroups = new List<string> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList1.Count; i++)
            {
                if (i == advProductsList1.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedAdGroups.Contains(advProductsList1[i].AdGroupName))
                {
                    Impressions = advProductsList1[i].Impressions;
                    Clicks = advProductsList1[i].Clicks;
                    Spend = advProductsList1[i].Spend;
                    Sales = advProductsList1[i].Sales;
                    Orders = advProductsList1[i].Orders;
                    Units = advProductsList1[i].Units;
                    AdvSKUUnits = advProductsList1[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList1[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList1[i].AdvSKUSales;
                    OtherSKUSales = advProductsList1[i].OtherSKUSales;

                    if (i < (advProductsList1.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList1.Count; j++)
                        {
                            if (advProductsList1[i].CampaignName.Equals(advProductsList1[j].CampaignName) && advProductsList1[i].AdGroupName.Equals(advProductsList1[j].AdGroupName) && advProductsList1[i].MatchType.Equals(advProductsList1[j].MatchType))
                            {
                                Impressions += advProductsList1[j].Impressions;
                                Clicks += advProductsList1[j].Clicks;
                                Spend += advProductsList1[j].Spend;
                                Sales += advProductsList1[j].Sales;
                                Orders += advProductsList1[j].Orders;
                                Units += advProductsList1[j].Units;
                                AdvSKUUnits += advProductsList1[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList1[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList1[j].AdvSKUSales;
                                OtherSKUSales += advProductsList1[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList1.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].UpdateDate = advProductsList1[i].UpdateDate;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CurrencyCharCode = advProductsList1[i].CurrencyCharCode;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignName = advProductsList1[i].CampaignName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdGroupName = advProductsList1[i].AdGroupName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Targeting = advProductsList1[i].Targeting;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MatchType = advProductsList1[i].MatchType;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Orders = Orders;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Units = Units;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignTypeId = advProductsList1[i].CampaignTypeId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MarketPlaceId = advProductsList1[i].MarketPlaceId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignId = advProductsList1[i].CampaignId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ProductId = advProductsList1[i].ProductId;

                    alreadyUsedAdGroups.Add(advProductsList1[i].AdGroupName);
                }
            }
            advProductsList1.Clear();
            foreach (var t in summaryAdvProductsList1)
            {
                advProductsList1.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList1, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyCampaignInProducts1()
        {
            List<int> alreadyUsed = new List<int> { };
            List<string> alreadyUsedCampaigns = new List<string> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList1.Count; i++)
            {
                if (i == advProductsList1.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedCampaigns.Contains(advProductsList1[i].CampaignName))
                {
                    Impressions = advProductsList1[i].Impressions;
                    Clicks = advProductsList1[i].Clicks;
                    Spend = advProductsList1[i].Spend;
                    Sales = advProductsList1[i].Sales;
                    Orders = advProductsList1[i].Orders;
                    Units = advProductsList1[i].Units;
                    AdvSKUUnits = advProductsList1[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList1[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList1[i].AdvSKUSales;
                    OtherSKUSales = advProductsList1[i].OtherSKUSales;

                    if (i < (advProductsList1.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList1.Count; j++)
                        {
                            if (advProductsList1[i].CampaignName.Equals(advProductsList1[j].CampaignName) && advProductsList1[i].MatchType.Equals(advProductsList1[j].MatchType))
                            {
                                Impressions += advProductsList1[j].Impressions;
                                Clicks += advProductsList1[j].Clicks;
                                Spend += advProductsList1[j].Spend;
                                Sales += advProductsList1[j].Sales;
                                Orders += advProductsList1[j].Orders;
                                Units += advProductsList1[j].Units;
                                AdvSKUUnits += advProductsList1[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList1[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList1[j].AdvSKUSales;
                                OtherSKUSales += advProductsList1[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList1.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].UpdateDate = advProductsList1[i].UpdateDate;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CurrencyCharCode = advProductsList1[i].CurrencyCharCode;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignName = advProductsList1[i].CampaignName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdGroupName = advProductsList1[i].AdGroupName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Targeting = advProductsList1[i].Targeting;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MatchType = advProductsList1[i].MatchType;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Orders = Orders;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Units = Units;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignTypeId = advProductsList1[i].CampaignTypeId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MarketPlaceId = advProductsList1[i].MarketPlaceId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignId = advProductsList1[i].CampaignId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ProductId = advProductsList1[i].ProductId;

                    alreadyUsedCampaigns.Add(advProductsList1[i].CampaignName);
                }
            }
            advProductsList1.Clear();
            foreach (var t in summaryAdvProductsList1)
            {
                advProductsList1.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList1, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyProducts1()
        {
            List<int> alreadyUsed = new List<int> { };
            List<int> alreadyUsedProductIds = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList1.Count; i++)
            {
                if (i == advProductsList1.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedProductIds.Contains(advProductsList1[i].ProductId))
                {
                    Impressions = advProductsList1[i].Impressions;
                    Clicks = advProductsList1[i].Clicks;
                    Spend = advProductsList1[i].Spend;
                    Sales = advProductsList1[i].Sales;
                    Orders = advProductsList1[i].Orders;
                    Units = advProductsList1[i].Units;
                    AdvSKUUnits = advProductsList1[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList1[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList1[i].AdvSKUSales;
                    OtherSKUSales = advProductsList1[i].OtherSKUSales;

                    if (i < (advProductsList1.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList1.Count; j++)
                        {
                            if (advProductsList1[i].ProductId == advProductsList1[j].ProductId)
                            {
                                Impressions += advProductsList1[j].Impressions;
                                Clicks += advProductsList1[j].Clicks;
                                Spend += advProductsList1[j].Spend;
                                Sales += advProductsList1[j].Sales;
                                Orders += advProductsList1[j].Orders;
                                Units += advProductsList1[j].Units;
                                AdvSKUUnits += advProductsList1[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList1[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList1[j].AdvSKUSales;
                                OtherSKUSales += advProductsList1[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList1.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].UpdateDate = advProductsList1[i].UpdateDate;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CurrencyCharCode = advProductsList1[i].CurrencyCharCode;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignName = advProductsList1[i].CampaignName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdGroupName = advProductsList1[i].AdGroupName;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Targeting = advProductsList1[i].Targeting;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MatchType = advProductsList1[i].MatchType;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Orders = Orders;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].Units = Units;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignTypeId = advProductsList1[i].CampaignTypeId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].MarketPlaceId = advProductsList1[i].MarketPlaceId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].CampaignId = advProductsList1[i].CampaignId;
                    summaryAdvProductsList1[summaryAdvProductsList1.Count - 1].ProductId = advProductsList1[i].ProductId;

                    alreadyUsedProductIds.Add(advProductsList1[i].ProductId);
                }
            }
            advProductsList1.Clear();
            foreach (var t in summaryAdvProductsList1)
            {
                advProductsList1.Add(t);
            }
        }

        /* Открываем форму фильтра */
        private void btn_Filter1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                btn_Filter1.Text = "<";
            }
            else if (panel2.Visible == false)
            {
                panel2.Visible = true;
                btn_Filter1.Text = ">";
            }
        }
        
        /* Выделяем/снимаем выделение кампании в clb_Marketplace1 */
        private void clb_Marketplace1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            checkedMarkeplaces1.Clear();
            for (int i = 0; i < clb_Marketplace1.CheckedItems.Count; i++)
            {
                checkedMarkeplaces1.Add(clb_Marketplace1.CheckedItems[i].ToString());
            }

            clb_Product1.Items.Clear();
            checkedProducts1.Clear();

            clb_Campaign1.Items.Clear();
            checkedCampaigns1.Clear();
                       
            clb_AdGroup1.Items.Clear();
            checkedAdGroups1.Clear();

            clb_Targeting1.Items.Clear();
            checkedTargeting1.Clear();

            if (checkedMarkeplaces1.Count > 0)
            {
                int res = 0;

                if (cb_WithInactive1.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames1(checkedMarkeplaces1), 1);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames1(checkedMarkeplaces1), 1);
                }

                if (res == 1)
                {
                    Draw_clb_Products1();
                }
            }
            //else { clb_Product1.Items.Clear(); checkedProducts1.Clear(); }

            disableTbClbFilter1();
        }

        /* Получаем список MarketplaceId по выделенным MarketplaceName1 */
        private List<int> GetMPIdsByNames1(List<string> _checkedMarkeplaces)
        {
            List<int> resultList = new List<int> { };
            for (int i = 0; i < _checkedMarkeplaces.Count; i++)
            {
                for (int j = 0; j < mpList1.Count; j++)
                {
                    if (_checkedMarkeplaces[i].Equals(mpList1[j].MarketPlaceName))
                        resultList.Add(mpList1[j].MarketPlaceId);
                }
            }
            return resultList;
        }

        /* Заносим имена товаров в clb_Products1 */
        private void Draw_clb_Products1()
        {
            List<string> names = new List<string> { };
            List<string> finalNames = new List<string> { };

            if (cb_WithoutAdvertising1.Checked || cb_WithInactive1.Checked)
            {
                for (int i = 0; i < pList1.Count; i++)
                {
                    if (!names.Contains(pList1[i].Name))
                        names.Add(pList1[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < pList1.Count; i++)
                {
                    foreach (var t in AP_campaignIdsListForActiveCheck1)
                    {
                        if (t.Name.Contains(pList1[i].ProdShortName))
                            if (!names.Contains(pList1[i].Name))
                                names.Add(pList1[i].Name);
                    }
                }
            }

            clb_Product1.Items.Clear();
            for (int i = 0; i < names.Count; i++)
            {
                clb_Product1.Items.Add(names[i]);
            }
        }

        /* Отключаем textBox'ы и очищаем их, если clb становятся пустыми */
        private void disableTbClbFilter1()
        {
            if (clb_Targeting1.Items.Count == 0)
            {
                tb_clbTargetingFilter1.Enabled = false;
                tb_clbTargetingFilter1.Text = "";
            }
            if (clb_AdGroup1.Items.Count == 0)
            {
                tb_clbAdGroupFilter1.Enabled = false;
                tb_clbAdGroupFilter1.Text = "";
            }
            if (clb_Campaign1.Items.Count == 0)
            {
                tb_clbCampaignFilter1.Enabled = false;
                tb_clbCampaignFilter1.Text = "";
            }
        }

        /* Отключаем textBox'ы и очищаем их, если clb становятся пустыми при изменении галочек cb_WithoutAdvertising1 или cb_WithInactive1 */
        private void disableTbClbFilter1(bool _copying)
        {
            copying = _copying;
            if (clb_Targeting1.Items.Count == 0)
            {
                tb_clbTargetingFilter1.Enabled = false;
                tb_clbTargetingFilter1.Text = "";
            }
            if (clb_AdGroup1.Items.Count == 0)
            {
                tb_clbAdGroupFilter1.Enabled = false;
                tb_clbAdGroupFilter1.Text = "";
            }
            if (clb_Campaign1.Items.Count == 0)
            {
                tb_clbCampaignFilter1.Enabled = false;
                tb_clbCampaignFilter1.Text = "";
            }
            copying = !_copying;
        }

        /* Очистить список выбранных маркетплейсов в clb_Marketplace1 */
        private void btn_Clear_clb_Marketplace1_Click(object sender, EventArgs e)
        {
            checkedMarkeplaces1.Clear();

            clb_Targeting1.Items.Clear();
            checkedTargeting1.Clear();

            clb_AdGroup1.Items.Clear();
            checkedAdGroups1.Clear();
            
            clb_Campaign1.Items.Clear();
            checkedCampaigns1.Clear();
            
            clb_Product1.Items.Clear();
            checkedProducts1.Clear();

            for (int i = 0; i < clb_Marketplace1.Items.Count; i++)
            {
                clb_Marketplace1.SetItemChecked(i, false);
            }
            clb_Marketplace1.ClearSelected();
        }

        /* Отображаем/скрываем товары, у которых нет рекламных кампаний */
        private void cb_WithoutAdvertising1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces1.Count > 0)
            {
                clb_Product1.ClearSelected();
                checkedProducts1.Clear();

                clb_Targeting1.Items.Clear();
                checkedTargeting1.Clear();

                clb_AdGroup1.Items.Clear();
                checkedAdGroups1.Clear();

                clb_Campaign1.Items.Clear();
                checkedCampaigns1.Clear();

                int res = 0;
                if (cb_WithInactive1.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames1(checkedMarkeplaces1), 1);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames1(checkedMarkeplaces1), 1);
                }

                if (res == 1)
                {
                    Draw_clb_Products1();
                }

                disableTbClbFilter1(true);
            }
        }

        /* Меняем режим отображения с активными/неактивными товарами tab1 */
        private void cb_WithInactive1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces1.Count > 0)
            {
                clb_Product1.ClearSelected();
                checkedProducts1.Clear();

                clb_Targeting1.Items.Clear();
                checkedTargeting1.Clear();

                clb_AdGroup1.Items.Clear();
                checkedAdGroups1.Clear();

                clb_Campaign1.Items.Clear();
                checkedCampaigns1.Clear();

                disableTbClbFilter1();

                int res = 0;

                if (cb_WithInactive1.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames1(checkedMarkeplaces1), 1);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames1(checkedMarkeplaces1), 1);
                }

                if (res == 1)
                {
                    Draw_clb_Products1();
                }

                disableTbClbFilter1(true);
            }
        }

        /* Выделяем/снимаем выделение кампании в clb_Campaign1 */
        private void clb_Campaign1_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_clb_Campaign1_SelectedIndexChanged();
        }

        private void method_clb_Campaign1_SelectedIndexChanged()
        {
            checkedCampaignsTMP1.Clear();
            for (int i = 0; i < clb_Campaign1.CheckedItems.Count; i++)
            {
                checkedCampaignsTMP1.Add(clb_Campaign1.CheckedItems[i].ToString());
            }

            checkedCampaigns1.Clear();

            foreach (var t in checkedCampaignsTMP1)
            {
                checkedCampaigns1.Add(t);
            }

            List<string> finalAdGroupList = new List<string> { };
            int res = 0;
            int prodId = -1;
            if (checkedCampaigns1.Count > 0)
            {
                for (int i = 0; i < checkedProducts1.Count; i++)
                {
                    prodId = GetProductIdByName1(checkedProducts1[i]);
                    for (int j = 0; j < checkedCampaigns1.Count; j++)
                    {
                        res = advertController.GetAdvertisingProductsAdgroups(prodId, checkedCampaigns1[j], 1);
                        if (res == 1)
                        {
                            for (int t = 0; t < AdGroupsList1.Count; t++)
                            {
                                AdGroupsList1[t] = AdGroupsList1[t] + " (" + checkedCampaigns1[j] + ")";
                                finalAdGroupList.Add(AdGroupsList1[t]);
                            }
                        }
                    }
                }

                GetUniqueAdGroups1(finalAdGroupList);

                if (res == 1)
                {
                    Draw_clb_AdGroups1();
                }
            }
            else
            {
                clb_AdGroup1.Items.Clear();
                checkedAdGroups1.Clear();

                clb_Targeting1.Items.Clear();
                checkedTargeting1.Clear();
            }


            if (clb_AdGroup1.Items.Count > 0)
                tb_clbAdGroupFilter1.Enabled = true;
            else
                tb_clbAdGroupFilter1.Enabled = false;

            disableTbClbFilter1();
        }

        /* Заносим имена кампаний в clb_AdGroups1 */
        private void Draw_clb_AdGroups1()
        {
            clb_AdGroup1.Items.Clear();
            for (int i = 0; i < uniqueAdGroups1.Count; i++)
            {
                clb_AdGroup1.Items.Add(uniqueAdGroups1[i]);
                if (checkedAdGroups1.Contains(uniqueAdGroups1[i]))
                {
                    clb_AdGroup1.SetItemChecked(clb_AdGroup1.Items.Count - 1, true);
                    checkedAdGroupsTMP1.Add(uniqueAdGroups1[i]);
                }
            }

            checkedAdGroups1.Clear();

            foreach (var t in checkedAdGroupsTMP1)
            {
                checkedAdGroups1.Add(t);
            }
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueAdGroups1(List<string> _finalAdGroupList)
        {
            tbAdGroupsFilterItemsPrev1.Clear();
            uniqueAdGroups1 = new List<string> { };
            for (int i = 0; i < _finalAdGroupList.Count; i++)
            {
                if (!uniqueAdGroups1.Contains(_finalAdGroupList[i]))
                {
                    uniqueAdGroups1.Add(_finalAdGroupList[i]);
                    tbAdGroupsFilterItemsPrev1.Add(uniqueAdGroups1[uniqueAdGroups1.Count - 1]);
                }
            }
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName1(List<string> _checkedProducts)
        {
            if (checkedProducts1.Count > 0)
                for (int i = 0; i < pList1.Count; i++)
                {
                    if (pList1[i].Name.Equals(checkedProducts1[0]))
                        return pList1[i].ProductId;
                }
            return -1;
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName1(string _checkedProduct)
        {
            if (checkedProducts1.Count > 0)
                for (int i = 0; i < pList1.Count; i++)
                {
                    if (pList1[i].Name.Equals(_checkedProduct))
                        return pList1[i].ProductId;
                }
            return -1;
        }

        /* Очистить список выбранных кампаний в clb_Campaigns1 */
        private void btn_Clear_clb_Campaigns1_Click(object sender, EventArgs e)
        {
            checkedCampaigns1.Clear();

            clb_Targeting1.Items.Clear();
            checkedTargeting1.Clear();
            
            clb_AdGroup1.Items.Clear();
            checkedAdGroups1.Clear();

            for (int i = 0; i < clb_Campaign1.Items.Count; i++)
            {
                clb_Campaign1.SetItemChecked(i, false);
            }
            clb_Campaign1.ClearSelected();

            disableTbClbFilter1();
        }

        /* Выделяем/снимаем выделение кампании в clb_AdGroup1 */
        private void clb_AdGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_clb_AdGroup1_SelectedIndexChanged();
        }

        private void method_clb_AdGroup1_SelectedIndexChanged()
        {
            checkedAdGroupsTMP1.Clear();
            for (int i = 0; i < clb_AdGroup1.CheckedItems.Count; i++)
            {
                checkedAdGroupsTMP1.Add(clb_AdGroup1.CheckedItems[i].ToString());
            }

            checkedAdGroups1.Clear();

            foreach (var t in checkedAdGroupsTMP1)
            {
                checkedAdGroups1.Add(t);
            }

            List<string> finalTargetingList = new List<string> { };
            int res = 0;
            int prodId = -1;

            if (checkedAdGroups1.Count > 0)
            {
                for (int i = 0; i < checkedProducts1.Count; i++)
                {
                    prodId = GetProductIdByName1(checkedProducts1[i]);
                    for (int j = 0; j < checkedCampaigns1.Count; j++)
                    {
                        for (int k = 0; k < checkedAdGroups1.Count; k++)
                        {
                            res = advertController.GetAdvertisingProductsTargeting(prodId, checkedCampaigns1[j], ResetNameInCheckedAdGroups(checkedAdGroups1[k]), 1);
                            if (res == 1)
                            {
                                for (int t = 0; t < targetingList1.Count; t++)
                                {
                                    targetingList1[t] = targetingList1[t] + " (" + checkedAdGroups1[k] + ")";
                                    finalTargetingList.Add(targetingList1[t]);
                                }
                            }
                        }
                    }
                }

                GetUniqueTargeting1(finalTargetingList);

                if (res == 1)
                {
                    Draw_clb_Targeting1();
                }
            }
            else
            {
                clb_Targeting1.Items.Clear();
                checkedTargeting1.Clear();
            }

            if (clb_Targeting1.Items.Count > 0)
                tb_clbTargetingFilter1.Enabled = true;
            else
                tb_clbTargetingFilter1.Enabled = false;

            disableTbClbFilter1();
        }

        /* Заносим имена кампаний в clb_Targeting1 */
        private void Draw_clb_Targeting1()
        {
            clb_Targeting1.Items.Clear();
            for (int i = 0; i < uniqueTargeting1.Count; i++)
            {
                clb_Targeting1.Items.Add(uniqueTargeting1[i]);
                if (checkedTargeting1.Contains(uniqueTargeting1[i]))
                {
                    clb_Targeting1.SetItemChecked(clb_Targeting1.Items.Count - 1, true);
                    checkedTargetingTMP1.Add(uniqueTargeting1[i]);
                }
            }

            checkedTargeting1.Clear();

            foreach (var t in checkedTargetingTMP1)
            {
                checkedTargeting1.Add(t);
            }
        }

        /* Получаем уникальные названия ключей */
        private void GetUniqueTargeting1(List<string> _finalTargetingList)
        {
            tbTargetingFilterItemsPrev1.Clear();
            uniqueTargeting1 = new List<string> { };
            for (int i = 0; i < _finalTargetingList.Count; i++)
            {
                if (!uniqueTargeting1.Contains(_finalTargetingList[i]))
                {
                    uniqueTargeting1.Add(_finalTargetingList[i]);
                    tbTargetingFilterItemsPrev1.Add(uniqueTargeting1[uniqueTargeting1.Count - 1]);
                }
            }
        }

        /* Выделяем/снимаем выделение кампании в clb_Targeting1 */
        private void clb_Targeting1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedTargeting1.Clear();
            for (int i = 0; i < clb_Targeting1.CheckedItems.Count; i++)
            {
                checkedTargeting1.Add(clb_Targeting1.CheckedItems[i].ToString());
            }

            disableTbClbFilter1();
        }
        
        /* Очистить список выбранных кампаний в clb_Targeting1 */
        private void btn_Clear_clb_Targeting1_Click(object sender, EventArgs e)
        {
            checkedTargeting1.Clear();

            for (int i = 0; i < clb_Targeting1.Items.Count; i++)
            {
                clb_Targeting1.SetItemChecked(i, false);
            }
            clb_Targeting1.ClearSelected();

            disableTbClbFilter1();
        }

        /* Очистить список выбранных кампаний в clb_AdGroup1 */
        private void btn_Clear_clb_AdGroups1_Click(object sender, EventArgs e)
        {
            checkedAdGroups1.Clear();

            clb_Targeting1.Items.Clear();
            checkedTargeting1.Clear();
            
            for (int i = 0; i < clb_AdGroup1.Items.Count; i++)
            {
                clb_AdGroup1.SetItemChecked(i, false);
            }
            clb_AdGroup1.ClearSelected();

            disableTbClbFilter1();
        }

        /* Ищем значения в clb_Campaign1 по вхождению текста из tb_clbCampaignFilter1 (ищем Campaigns по вводу пользователем) */
        private void tb_clbCampaignFilter1_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbCampaignsFilterItems1.Clear();
                string text = tb_clbCampaignFilter1.Text.ToLower();

                for (int i = 0; i < tbCampaignsFilterItemsPrev1.Count; i++)
                {
                    if (tbCampaignsFilterItemsPrev1[i].ToLower().Contains(text))
                        tbCampaignsFilterItems1.Add(tbCampaignsFilterItemsPrev1[i]);
                }

                clb_Campaign1.Items.Clear();

                for (int i = 0; i < tbCampaignsFilterItems1.Count; i++)
                {
                    clb_Campaign1.Items.Add(tbCampaignsFilterItems1[i]);
                    if (checkedCampaigns1.Contains(tbCampaignsFilterItems1[i]))
                        clb_Campaign1.SetItemChecked(clb_Campaign1.Items.Count - 1, true);
                }
            }
        }
        
        /* Ищем значения в clb_AdGroup1 по вхождению текста из tb_clbAdGroupFilter1 (ищем AdGroups по вводу пользователем) */
        private void tb_clbAdGroupFilter1_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbAdGroupsFilterItems1.Clear();
                string text = tb_clbAdGroupFilter1.Text.ToLower();

                for (int i = 0; i < tbAdGroupsFilterItemsPrev1.Count; i++)
                {
                    if (tbAdGroupsFilterItemsPrev1[i].ToLower().Contains(text))
                        tbAdGroupsFilterItems1.Add(tbAdGroupsFilterItemsPrev1[i]);
                }

                clb_AdGroup1.Items.Clear();

                for (int i = 0; i < tbAdGroupsFilterItems1.Count; i++)
                {
                    clb_AdGroup1.Items.Add(tbAdGroupsFilterItems1[i]);
                    if (checkedAdGroups1.Contains(tbAdGroupsFilterItems1[i]))
                        clb_AdGroup1.SetItemChecked(clb_AdGroup1.Items.Count - 1, true);
                }
            }
        }

        /* Ищем значения в clb_Targeting1 по вхождению текста из tb_clbTargetingFilter1 (ищем Targetings по вводу пользователем) */
        private void tb_clbTargetingFilter1_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbTargetingFilterItems1.Clear();
                string text = tb_clbTargetingFilter1.Text.ToLower();
                
                for (int i = 0; i < tbTargetingFilterItemsPrev1.Count; i++)
                {
                    if (tbTargetingFilterItemsPrev1[i].ToLower().Contains(text))
                        tbTargetingFilterItems1.Add(tbTargetingFilterItemsPrev1[i]);
                }

                clb_Targeting1.Items.Clear();

                for (int i = 0; i < tbTargetingFilterItems1.Count; i++)
                {
                    clb_Targeting1.Items.Add(tbTargetingFilterItems1[i]);
                    if (checkedTargeting1.Contains(tbTargetingFilterItems1[i]))
                        clb_Targeting1.SetItemChecked(clb_Targeting1.Items.Count - 1, true);
                }
            }
        }

        /* Скрываем форму по нажатию ЛКМ по любому месту на dgv_AdvertisingProducts */
        private void dgv_AdvProducts1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                btn_Filter1.Text = "<";
            }
        }

        /* Скрываем форму по нажатию ЛКМ по любому месту во вкладке */
        private void tabPage1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                btn_Filter1.Text = "<";
            }
        }

        /* Изменяем дату начала в календаре 1 */
        private void mc_StartDate1_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate1 = mc_StartDate1.SelectionStart;
            label3.Text = mc_StartDate1.SelectionStart.ToShortDateString();
        }

        /* Изменяем дату окончания в календаре 1 */
        private void mc_EndDate1_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate1 = mc_EndDate1.SelectionEnd;
            label2.Text = mc_EndDate1.SelectionStart.ToShortDateString();
        }

        /* Выделяем/снимаем выделение товара в clb_Product1 */
        private void clb_Product1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedProductsTMP1.Clear();
            for (int i = 0; i < clb_Product1.CheckedItems.Count; i++)
            {
                checkedProductsTMP1.Add(clb_Product1.CheckedItems[i].ToString());
            }

            checkedProducts1.Clear();

            foreach (var t in checkedProductsTMP1)
            {
                checkedProducts1.Add(t);
            }

            int res = 0;

            if (checkedProducts1.Count > 0)
            {
                res = advertController.GetAdvertisingProductsCampaignAndCampId1(GetProductIdsByNames1(checkedProducts1));
                GetUniqueCampaigns1();
            }
            else
            {
                clb_Campaign1.Items.Clear();
                checkedCampaigns1.Clear();

                clb_AdGroup1.Items.Clear();
                checkedAdGroups1.Clear();

                clb_Targeting1.Items.Clear();
                checkedTargeting1.Clear();
            }


            if (res == 1)
            {
                Draw_clb_Campaigns1();
            }

            if (clb_Campaign1.Items.Count > 0)
                tb_clbCampaignFilter1.Enabled = true;
            else
                tb_clbCampaignFilter1.Enabled = false;

            disableTbClbFilter1();
        }
        
        /* Очистить список выбранных товаров в clb_Products1 */
        private void btn_Clear_clb_Products1_Click(object sender, EventArgs e)
        {
            checkedProducts1.Clear();

            clb_Targeting1.Items.Clear();
            checkedTargeting1.Clear();

            clb_AdGroup1.Items.Clear();
            checkedAdGroups1.Clear();

            clb_Campaign1.Items.Clear();
            checkedCampaigns1.Clear();

            for (int i = 0; i < clb_Product1.Items.Count; i++)
            {
                clb_Product1.SetItemChecked(i, false);
            }
            clb_Product1.ClearSelected();

            disableTbClbFilter1();
        }

        /* Заносим имена кампаний в clb_Campaigns1 */
        private void Draw_clb_Campaigns1()
        {
            clb_Campaign1.Items.Clear();
            checkedCampaignsTMP1.Clear();
            for (int i = 0; i < uniqueCampaigns1.Count; i++)
            {
                clb_Campaign1.Items.Add(uniqueCampaigns1[i]);
                if (checkedCampaigns1.Contains(uniqueCampaigns1[i]))
                {
                    clb_Campaign1.SetItemChecked(clb_Campaign1.Items.Count - 1, true);
                    checkedCampaignsTMP1.Add(uniqueCampaigns1[i]);
                }
            }

            checkedCampaigns1.Clear();

            foreach (var t in checkedCampaignsTMP1)
            {
                checkedCampaigns1.Add(t);
            }

            if (checkedCampaigns1.Count == 0)
            {
                clb_AdGroup1.Items.Clear();
                checkedAdGroups1.Clear();
            }
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueCampaigns1()
        {
            uniqueCampaigns1 = new List<string> { };
            tbCampaignsFilterItemsPrev1 = new List<string> { };

            for (int i = 0; i < campsidsList1.Count; i++)
            {
                if (!uniqueCampaigns1.Contains(campsidsList1[i].Key))
                {
                    uniqueCampaigns1.Add(campsidsList1[i].Key);
                    tbCampaignsFilterItemsPrev1.Add(uniqueCampaigns1[uniqueCampaigns1.Count - 1]);
                }
            }
        }

        /* Получаем список ProductId по выделенным ProductName */
        private List<int> GetProductIdsByNames1(List<string> _checkedProducts)
        {
            bool flag = false;
            List<int> resultList = new List<int> { };
            List<int> resultList1 = new List<int> { };
            for (int i = 0; i < _checkedProducts.Count; i++)
            {
                flag = false;
                for (int j = 0; j < pList1.Count; j++)
                {
                    if (!flag && _checkedProducts[i].Equals(pList1[j].Name))
                    {
                        resultList.Add(pList1[j].ProductId);
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

        /* Быстрое копирование параметров всех фильтров и настроек с Окно 1 в Окно 2 */
        private void copyToTab2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopyMethod1to2();
        }

        /* Быстрое копирование параметров всех фильтров и настроек с Окно 1 в Окно 3 */
        private void copyToTab3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopyMethod1to3();
        }

        /* Метод копирования параметров всех фильтров и настроек с Окно 1 в Окно 2 */
        private void CopyMethod1to2()
        {
            copying = true;
            byProductsToolStripMenuItem2.Checked = byProductsToolStripMenuItem1.Checked;
            byCampaignInProductsToolStripMenuItem2.Checked = byCampaignInProductsToolStripMenuItem1.Checked;
            byAdGroupsInCampaignsToolStripMenuItem2.Checked = byAdGroupsInCampaignsToolStripMenuItem1.Checked;
            byTargetingInAdGroupsToolStripMenuItem2.Checked = byTargetingInAdGroupsToolStripMenuItem1.Checked;

            by_DaysToolStripMenuItem2.Checked = by_DaysToolStripMenuItem1.Checked;
            by_WeeksToolStripMenuItem2.Checked = by_WeeksToolStripMenuItem1.Checked;
            by_MonthsToolStripMenuItem2.Checked = by_MonthsToolStripMenuItem1.Checked;
            by_CustomToolStripMenuItem2.Checked = by_CustomToolStripMenuItem1.Checked;

            cb_WithoutAdvertising2.Checked = cb_WithoutAdvertising1.Checked;
            cb_WithInactive2.Checked = cb_WithInactive1.Checked;

            mc_StartDate2.SelectionStart = mc_StartDate1.SelectionStart;
            mc_EndDate2.SelectionStart = mc_EndDate1.SelectionStart;

            label10.Text = label3.Text;
            label9.Text = label2.Text;

            StartDate2 = StartDate1;
            EndDate2 = EndDate1;


            pList2 = new List<ProductsModel> { };
            foreach (var t in pList1) { pList2.Add(t); }

            campsidsList2 = new List<CmapaignAndIdStruct> { };
            foreach (var t in campsidsList1) { campsidsList2.Add(t); }

            checkedMarkeplaces2.Clear();
            foreach (var t in checkedMarkeplaces1) { checkedMarkeplaces2.Add(t); }

            checkedProducts2.Clear();
            foreach (var t in checkedProducts1) { checkedProducts2.Add(t); }

            checkedCampaigns2.Clear();
            foreach (var t in checkedCampaigns1) { checkedCampaigns2.Add(t); }

            checkedAdGroups2.Clear();
            foreach (var t in checkedAdGroups1) { checkedAdGroups2.Add(t); }

            checkedTargeting2.Clear();
            foreach (var t in checkedTargeting1) { checkedTargeting2.Add(t); }

            clb_Marketplace2.Items.Clear();
            foreach (var t in clb_Marketplace1.Items) { clb_Marketplace2.Items.Add(t); }

            clb_Product2.Items.Clear();
            foreach (var t in clb_Product1.Items) { clb_Product2.Items.Add(t); }

            clb_Campaign2.Items.Clear();
            foreach (var t in clb_Campaign1.Items) { clb_Campaign2.Items.Add(t); }

            clb_AdGroup2.Items.Clear();
            foreach (var t in clb_AdGroup1.Items) { clb_AdGroup2.Items.Add(t); }

            clb_Targeting2.Items.Clear();
            foreach (var t in clb_Targeting1.Items) { clb_Targeting2.Items.Add(t); }


            checkedMarkeplacesTMP2.Clear();
            foreach (var t in checkedMarkeplacesTMP1) { checkedMarkeplacesTMP2.Add(t); }
            checkedProductsTMP2.Clear();
            foreach (var t in checkedProductsTMP1) { checkedProductsTMP2.Add(t); }
            checkedCampaignsTMP2.Clear();
            foreach (var t in checkedCampaignsTMP1) { checkedCampaignsTMP2.Add(t); }
            checkedAdGroupsTMP2.Clear();
            foreach (var t in checkedAdGroupsTMP1) { checkedAdGroupsTMP2.Add(t); }
            checkedTargetingTMP2.Clear();
            foreach (var t in checkedTargetingTMP1) { checkedTargetingTMP2.Add(t); }


            for (int i = 0; i < clb_Marketplace2.Items.Count; i++)
            {
                if (checkedMarkeplaces2.Contains(clb_Marketplace2.Items[i].ToString()))
                    clb_Marketplace2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Product2.Items.Count; i++)
            {
                if (checkedProducts2.Contains(clb_Product2.Items[i].ToString()))
                    clb_Product2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Campaign2.Items.Count; i++)
            {
                if (checkedCampaigns2.Contains(clb_Campaign2.Items[i].ToString()))
                    clb_Campaign2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_AdGroup2.Items.Count; i++)
            {
                if (checkedAdGroups2.Contains(clb_AdGroup2.Items[i].ToString()))
                    clb_AdGroup2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Targeting2.Items.Count; i++)
            {
                if (checkedTargeting2.Contains(clb_Targeting2.Items[i].ToString()))
                    clb_Targeting2.SetItemChecked(i, true);
            }

            tb_clbCampaignFilter2.Text = tb_clbCampaignFilter1.Text;
            tb_clbCampaignFilter2.Enabled = tb_clbCampaignFilter1.Enabled;

            tb_clbAdGroupFilter2.Text = tb_clbAdGroupFilter1.Text;
            tb_clbAdGroupFilter2.Enabled = tb_clbAdGroupFilter1.Enabled;

            tb_clbTargetingFilter2.Text = tb_clbTargetingFilter1.Text;
            tb_clbTargetingFilter2.Enabled = tb_clbTargetingFilter1.Enabled;


            tbCampaignsFilterItems2.Clear();
            foreach (var t in tbCampaignsFilterItems1) { tbCampaignsFilterItems2.Add(t); }
            tbCampaignsFilterItemsPrev2.Clear();
            foreach (var t in tbCampaignsFilterItemsPrev1) { tbCampaignsFilterItemsPrev2.Add(t); }

            tbAdGroupsFilterItems2.Clear();
            foreach (var t in tbAdGroupsFilterItems1) { tbAdGroupsFilterItems2.Add(t); }
            tbAdGroupsFilterItemsPrev2.Clear();
            foreach (var t in tbAdGroupsFilterItemsPrev1) { tbAdGroupsFilterItemsPrev2.Add(t); }

            tbTargetingFilterItems2.Clear();
            foreach (var t in tbTargetingFilterItems1) { tbTargetingFilterItems2.Add(t); }
            tbTargetingFilterItemsPrev2.Clear();
            foreach (var t in tbTargetingFilterItemsPrev1) { tbTargetingFilterItemsPrev2.Add(t); }

            panel4.Visible = true;
            btn_Filter2.Text = ">";
            copying = false;
        }

        /* Метод копирования параметров всех фильтров и настроек с Окно 1 в Окно 3 */
        private void CopyMethod1to3()
        {
            copying = true;
            byProductsToolStripMenuItem3.Checked = byProductsToolStripMenuItem1.Checked;
            byCampaignInProductsToolStripMenuItem3.Checked = byCampaignInProductsToolStripMenuItem1.Checked;
            byAdGroupsInCampaignsToolStripMenuItem3.Checked = byAdGroupsInCampaignsToolStripMenuItem1.Checked;
            byTargetingInAdGroupsToolStripMenuItem3.Checked = byTargetingInAdGroupsToolStripMenuItem1.Checked;

            by_DaysToolStripMenuItem3.Checked = by_DaysToolStripMenuItem1.Checked;
            by_WeeksToolStripMenuItem3.Checked = by_WeeksToolStripMenuItem1.Checked;
            by_MonthsToolStripMenuItem3.Checked = by_MonthsToolStripMenuItem1.Checked;
            by_CustomToolStripMenuItem3.Checked = by_CustomToolStripMenuItem1.Checked;

            cb_WithoutAdvertising3.Checked = cb_WithoutAdvertising1.Checked;
            cb_WithInactive3.Checked = cb_WithInactive1.Checked;

            mc_StartDate3.SelectionStart = mc_StartDate1.SelectionStart;
            mc_EndDate3.SelectionStart = mc_EndDate1.SelectionStart;

            label23.Text = label3.Text;
            label22.Text = label2.Text;

            StartDate3 = StartDate1;
            EndDate3 = EndDate1;


            pList3 = new List<ProductsModel> { };
            foreach (var t in pList1) { pList3.Add(t); }

            campsidsList3 = new List<CmapaignAndIdStruct> { };
            foreach (var t in campsidsList1) { campsidsList3.Add(t); }

            checkedMarkeplaces3.Clear();
            foreach (var t in checkedMarkeplaces1) { checkedMarkeplaces3.Add(t); }

            checkedProducts3.Clear();
            foreach (var t in checkedProducts1) { checkedProducts3.Add(t); }

            checkedCampaigns3.Clear();
            foreach (var t in checkedCampaigns1) { checkedCampaigns3.Add(t); }

            checkedAdGroups3.Clear();
            foreach (var t in checkedAdGroups1) { checkedAdGroups3.Add(t); }

            checkedTargeting3.Clear();
            foreach (var t in checkedTargeting1) { checkedTargeting3.Add(t); }

            clb_Marketplace3.Items.Clear();
            foreach (var t in clb_Marketplace1.Items) { clb_Marketplace3.Items.Add(t); }

            clb_Product3.Items.Clear();
            foreach (var t in clb_Product1.Items) { clb_Product3.Items.Add(t); }

            clb_Campaign3.Items.Clear();
            foreach (var t in clb_Campaign1.Items) { clb_Campaign3.Items.Add(t); }

            clb_AdGroup3.Items.Clear();
            foreach (var t in clb_AdGroup1.Items) { clb_AdGroup3.Items.Add(t); }

            clb_Targeting3.Items.Clear();
            foreach (var t in clb_Targeting1.Items) { clb_Targeting3.Items.Add(t); }


            checkedMarkeplacesTMP3.Clear();
            foreach (var t in checkedMarkeplacesTMP1) { checkedMarkeplacesTMP3.Add(t); }
            checkedProductsTMP3.Clear();
            foreach (var t in checkedProductsTMP1) { checkedProductsTMP3.Add(t); }
            checkedCampaignsTMP3.Clear();
            foreach (var t in checkedCampaignsTMP1) { checkedCampaignsTMP3.Add(t); }
            checkedAdGroupsTMP3.Clear();
            foreach (var t in checkedAdGroupsTMP1) { checkedAdGroupsTMP3.Add(t); }
            checkedTargetingTMP3.Clear();
            foreach (var t in checkedTargetingTMP1) { checkedTargetingTMP3.Add(t); }


            for (int i = 0; i < clb_Marketplace3.Items.Count; i++)
            {
                if (checkedMarkeplaces3.Contains(clb_Marketplace3.Items[i].ToString()))
                    clb_Marketplace3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Product3.Items.Count; i++)
            {
                if (checkedProducts3.Contains(clb_Product3.Items[i].ToString()))
                    clb_Product3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Campaign3.Items.Count; i++)
            {
                if (checkedCampaigns3.Contains(clb_Campaign3.Items[i].ToString()))
                    clb_Campaign3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_AdGroup3.Items.Count; i++)
            {
                if (checkedAdGroups3.Contains(clb_AdGroup3.Items[i].ToString()))
                    clb_AdGroup3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Targeting3.Items.Count; i++)
            {
                if (checkedTargeting3.Contains(clb_Targeting3.Items[i].ToString()))
                    clb_Targeting3.SetItemChecked(i, true);
            }

            tb_clbCampaignFilter3.Text = tb_clbCampaignFilter1.Text;
            tb_clbCampaignFilter3.Enabled = tb_clbCampaignFilter1.Enabled;

            tb_clbAdGroupFilter3.Text = tb_clbAdGroupFilter1.Text;
            tb_clbAdGroupFilter3.Enabled = tb_clbAdGroupFilter1.Enabled;

            tb_clbTargetingFilter3.Text = tb_clbTargetingFilter1.Text;
            tb_clbTargetingFilter3.Enabled = tb_clbTargetingFilter1.Enabled;


            tbCampaignsFilterItems3.Clear();
            foreach (var t in tbCampaignsFilterItems1) { tbCampaignsFilterItems3.Add(t); }
            tbCampaignsFilterItemsPrev3.Clear();
            foreach (var t in tbCampaignsFilterItemsPrev1) { tbCampaignsFilterItemsPrev3.Add(t); }

            tbAdGroupsFilterItems3.Clear();
            foreach (var t in tbAdGroupsFilterItems1) { tbAdGroupsFilterItems3.Add(t); }
            tbAdGroupsFilterItemsPrev3.Clear();
            foreach (var t in tbAdGroupsFilterItemsPrev1) { tbAdGroupsFilterItemsPrev3.Add(t); }

            tbTargetingFilterItems3.Clear();
            foreach (var t in tbTargetingFilterItems1) { tbTargetingFilterItems3.Add(t); }
            tbTargetingFilterItemsPrev3.Clear();
            foreach (var t in tbTargetingFilterItemsPrev1) { tbTargetingFilterItemsPrev3.Add(t); }

            panel7.Visible = true;
            btn_Filter3.Text = ">";

            copying = false;
        }

        /* Применяем фильтры и перерисовываем данные в таблице */
        private void btn_Show1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            if (StartDate1 > EndDate1)
                MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

            int result = 0;
            advProductsList1 = null;

            //result = advertController.GetFinalAdvertisingProductsReport(StartDate1, EndDate1, GetMPIdsByNames1(checkedMarkeplaces1), GetProductIdsByNames1(checkedProducts1), GetCampaignIdsByNames1(campsidsList1), ResetNamesInCheckedAdGroups(checkedAdGroups1), ResetNamesInCheckedTargeting(checkedTargeting1), 1);

            //if (result == 1)
            //{
            //    if (byTargetingInAdGroupsToolStripMenuItem1.Checked)
            //        GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), "", GetProductIdByName1(checkedProducts1));
            //    else if (byAdGroupsInCampaignsToolStripMenuItem1.Checked && !GetFirstAdGroup1().Equals(""))
            //        GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), GetFirstAdGroup1(), GetProductIdByName1(checkedProducts1));
            //    else if (byCampaignInProductsToolStripMenuItem1.Checked && !GetFirstCampaign1().Equals(""))
            //        GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), GetFirstCampaign1(), GetProductIdByName1(checkedProducts1));
            //    else if (byProductsToolStripMenuItem1.Checked && CheckForExistingProducts1())
            //        GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), GetProductsAsins1(), GetProductIdByName1(checkedProducts1));
            //    filterAdvProductsList1 = new List<AdvertisingProductsModel> { };
            //}


            if (byTargetingInAdGroupsToolStripMenuItem1.Checked)
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate1, EndDate1, GetMPIdsByNames1(checkedMarkeplaces1), GetProductIdsByNames1(checkedProducts1), GetCampaignIdsByNames1(campsidsList1), ResetNamesInCheckedAdGroups(checkedAdGroups1), ResetNamesInCheckedTargeting(checkedTargeting1), 1);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), "", GetProductIdByName1(checkedProducts1));
                    filterAdvProductsList1 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem1.Checked && !GetFirstAdGroup1().Equals(""))
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate1, EndDate1, GetMPIdsByNames1(checkedMarkeplaces1), GetProductIdsByNames1(checkedProducts1), GetCampaignIdsByNames1(campsidsList1), ResetNamesInCheckedAdGroups(checkedAdGroups1), new List<string> { }, 1);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), GetFirstAdGroup1(), GetProductIdByName1(checkedProducts1));
                    filterAdvProductsList1 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byCampaignInProductsToolStripMenuItem1.Checked && !GetFirstCampaign1().Equals(""))
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate1, EndDate1, GetMPIdsByNames1(checkedMarkeplaces1), GetProductIdsByNames1(checkedProducts1), GetCampaignIdsByNames1(campsidsList1), new List<string> { }, new List<string> { }, 1);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), GetFirstCampaign1(), GetProductIdByName1(checkedProducts1));
                    filterAdvProductsList1 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byProductsToolStripMenuItem1.Checked && CheckForExistingProducts1())
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate1, EndDate1, GetMPIdsByNames1(checkedMarkeplaces1), GetProductIdsByNames1(checkedProducts1), new List<int> { }, new List<string> { }, new List<string> { }, 1);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow1(advProductsList1, advProductsListOriginal1, GetCompareMode1(), pList1, GetDateMode1(), GetProductsAsins1(), GetProductIdByName1(checkedProducts1));
                    filterAdvProductsList1 = new List<AdvertisingProductsModel> { };
                }
            }


            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }


        private string GetFirstAdGroup1()
        {
            if (checkedAdGroups1.Count > 0)
            {
                return checkedAdGroups1[0];
            }
            else
            {
                if (clb_AdGroup1.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите рекламную кампанию!", "Ошибка");
                else
                {
                    return clb_AdGroup1.Items[0].ToString();
                }
            }
            return "";
        }
        private string GetFirstCampaign1()
        {
            if (checkedCampaigns1.Count > 0)
            {
                return checkedCampaigns1[0];
            }
            else
            {
                if (clb_Campaign1.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите товар!", "Ошибка");
                else
                {
                    return clb_Campaign1.Items[0].ToString();
                }
            }
            return "";
        }

        private bool CheckForExistingProducts1()
        {
            if (clb_Product1.Items.Count == 0)
                MessageBox.Show("Для продолжения выберите маркетплейс!", "Ошибка");
            else if (checkedProducts1.Count > 0 || clb_Product1.Items.Count > 0)
                return true;
            return false;
        }

        private string GetProductsAsins1()
        {
            string result = "";
            string name = "";
            string asin = "";

            if (checkedProducts1.Count > 0)
            {
                name = checkedProducts1[0];
            }
            else
            {
                name = clb_Product1.Items[0].ToString();
            }

            for (int i = 0; i < pList1.Count; i++)
            {
                if (pList1[i].Name.Equals(name))
                    asin = pList1[i].ASIN;
            }
            for (int i = 0; i < pList1.Count; i++)
            {
                if (pList1[i].ASIN.Equals(asin))
                    result = result + pList1[i].ProductId + ", ";
            }

            return result;
        }

        /* Получаем список CampaignId по выделенным Campaign1 */
        private List<int> GetCampaignIdsByNames1(List<CmapaignAndIdStruct> _campsidsList)
        {
            List<int> resultList = new List<int> { };
            List<CmapaignAndIdStruct> test = new List<CmapaignAndIdStruct> { };
            bool flag = false;

            for (int i = 0; i < checkedCampaigns1.Count; i++)
            {
                flag = false;
                for (int j = 0; j < campsidsList1.Count; j++)
                {
                    if (!flag && checkedCampaigns1[i].Equals(campsidsList1[j].Key))
                    {
                        resultList.Add(campsidsList1[j].Val);
                        flag = true;
                    }
                }
            }
            return resultList;
        }
        
        private List<string> ResetNamesInCheckedAdGroups(List<string> _checkedAdGroups)
        {
            List<string> result = new List<string> { };
            string tmp = "";

            for (int i = 0; i < _checkedAdGroups.Count; i++)
            {
                tmp = _checkedAdGroups[i];
                for (int j = tmp.Length - 1; j >= 0; j--)
                {
                    if (tmp[j].Equals('('))
                    {
                        result.Add(tmp.Substring(0, j - 1));
                    }
                }
            }

            return result;
        }

        private string ResetNameInCheckedAdGroups(string _checkedAdGroups)
        {
            for (int j = _checkedAdGroups.Length - 1; j >= 0; j--)
            {
                if (_checkedAdGroups[j].Equals('('))
                {
                    return _checkedAdGroups.Substring(0, j - 1);
                }
            }
            return "";
        }

        private List<string> ResetNamesInCheckedTargeting(List<string> _ckeckedTargeting)
        {
            List<string> result = new List<string> { };
            string tmp = "";
            bool flag = false;

            for (int i = 0; i < _ckeckedTargeting.Count; i++)
            {
                tmp = _ckeckedTargeting[i];
                flag = false;
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    if (tmp[j].Equals('(') && !flag)
                    {
                        result.Add(tmp.Substring(0, j - 1));
                        flag = true;
                    }
                }
            }

            return result;
        }

        private string GetCompareMode1()
        {
            if (byTargetingInAdGroupsToolStripMenuItem1.Checked)
            {
                return "targetinginadgroups";
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem1.Checked)
            {
                return "adgroupsincampaigns";
            }
            else if (byCampaignInProductsToolStripMenuItem1.Checked)
            {
                return "campaigninproducts";
            }
            else if (byProductsToolStripMenuItem1.Checked)
            {
                return "productsinmarketplaces";
            }
            return "";
        }

        private string GetDateMode1()
        {
            if (by_DaysToolStripMenuItem1.Checked)
            {
                return "days";
            }
            else if (by_WeeksToolStripMenuItem1.Checked)
            {
                return "weeks";
            }
            else if (by_MonthsToolStripMenuItem1.Checked)
            {
                return "months";
            }
            else if (by_CustomToolStripMenuItem1.Checked)
            {
                return "custom";
            }
            return "";
        }

        private void byProductsInMarkeplacesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullCompareMode1();
            EnableCustomTimeMode1();
            byProductsToolStripMenuItem1.Checked = true;
        }

        private void byCampaignInProductsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullCompareMode1();
            EnableCustomTimeMode1();
            byCampaignInProductsToolStripMenuItem1.Checked = true;
        }

        private void byAdGroupsInCampaignsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullCompareMode1();
            EnableCustomTimeMode1();
            byAdGroupsInCampaignsToolStripMenuItem1.Checked = true;
        }

        private void byTargetingInAdGroupsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullCompareMode1();
            NullTimeMode1();
            DisableCustomTimeMode1();
            by_CustomToolStripMenuItem1.Checked = true;
            byTargetingInAdGroupsToolStripMenuItem1.Checked = true;
        }
        
        private void by_CustomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullTimeMode1();
            by_CustomToolStripMenuItem1.Checked = true;
        }


        private void by_DaysToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullTimeMode1();
            by_DaysToolStripMenuItem1.Checked = true;
        }

        private void by_WeeksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullTimeMode1();
            by_WeeksToolStripMenuItem1.Checked = true;
        }

        private void by_MonthsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullTimeMode1();
            by_MonthsToolStripMenuItem1.Checked = true;
        }

        private void DisableCustomTimeMode1()
        {
            by_DaysToolStripMenuItem1.Enabled = false;
            by_WeeksToolStripMenuItem1.Enabled = false;
            by_MonthsToolStripMenuItem1.Enabled = false;
        }

        private void EnableCustomTimeMode1()
        {
            by_DaysToolStripMenuItem1.Enabled = true;
            by_WeeksToolStripMenuItem1.Enabled = true;
            by_MonthsToolStripMenuItem1.Enabled = true;
        }

        private void NullTimeMode1()
        {
            by_DaysToolStripMenuItem1.Checked = false;
            by_WeeksToolStripMenuItem1.Checked = false;
            by_MonthsToolStripMenuItem1.Checked = false;
            by_CustomToolStripMenuItem1.Checked = false;
        }

        private void NullCompareMode1()
        {
            byProductsToolStripMenuItem1.Checked = false;
            byCampaignInProductsToolStripMenuItem1.Checked = false;
            byAdGroupsInCampaignsToolStripMenuItem1.Checked = false;
            byTargetingInAdGroupsToolStripMenuItem1.Checked = false;
        }


        private void ResetCompareModes1()
        {
            targetingInAdgroupsMode1 = false;
            adgroupsInCampaignsMode1 = false;
            campaignInProductsMode1 = false;
            productsInMarketplaces1 = false;
        }

        private void ResetDateModes1()
        {
            byDays1 = false;
            byWeeks1 = false;
            byMonths1 = false;
            byCustom1 = false;
        }

        /* Получаем список advProductsList1 и рисуем его в таблице dgv_AdvProducts1 */
        public void GetAdvertisingProductsListToShow1(object _advProductsList, object _advProductsListOriginal, string _compareMode, object _pList, string _dateMode, string _object, int _prodId)
        {
            advProductsList1 = (List<AdvertisingProductsModel>)_advProductsList;
            advProductsListOriginal1 = (List<AdvertisingProductsModel>)_advProductsListOriginal;

            lb_StartDate1.Text = label3.Text;
            lb_EndDate1.Text = label2.Text;

            if (_compareMode.Equals("targetinginadgroups"))
            {
                ResetCompareModes1();
                targetingInAdgroupsMode1 = true;
            }
            else if (_compareMode.Equals("adgroupsincampaigns"))
            {
                ResetCompareModes1();
                adgroupsInCampaignsMode1 = true;
                this.Text = "По группам";
            }
            else if (_compareMode.Equals("campaigninproducts"))
            {
                ResetCompareModes1();
                campaignInProductsMode1 = true;
                this.Text = "По кампаниям";
            }
            else if (_compareMode.Equals("productsinmarketplaces"))
            {
                ResetCompareModes1();
                productsInMarketplaces1 = true;
                this.Text = "По товарам";
            }

            if (_dateMode.Equals("days"))
            {
                ResetDateModes1();
                byDays1 = true;
            }
            else if (_dateMode.Equals("weeks"))
            {
                ResetDateModes1();
                byWeeks1 = true;
            }
            else if (_dateMode.Equals("months"))
            {
                ResetDateModes1();
                byMonths1 = true;
            }
            else if (_dateMode.Equals("custom"))
            {
                ResetDateModes1();
                byCustom1 = true;
            }

            pList1 = (List<ProductsModel>)_pList;

            if (byCustom1)
                DrawTableForSponsoredProducts(advProductsList1, dgv_AdvProducts1, pList1, targetingInAdgroupsMode1, adgroupsInCampaignsMode1, campaignInProductsMode1, productsInMarketplaces1);
            else if (byMonths1)
            {
                int timeSpan = ((EndDate1 - StartDate1).Days + 1) / 31;
                if (adgroupsInCampaignsMode1)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "months", _prodId, dgv_AdvProducts1, EndDate1, advProductsList1);
                }
                else if (campaignInProductsMode1)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "months", _prodId, dgv_AdvProducts1, EndDate1, advProductsList1);
                }
                else if (productsInMarketplaces1)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "months", dgv_AdvProducts1, pList1, EndDate1, advProductsList1);
                }

                DrawLastColumn(dgv_AdvProducts1);
            }
            else if (byWeeks1)
            {
                int timeSpan = ((EndDate1 - StartDate1).Days + 1) / 7;
                if (adgroupsInCampaignsMode1)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "weeks", _prodId, dgv_AdvProducts1, EndDate1, advProductsList1);
                }
                else if (campaignInProductsMode1)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "weeks", _prodId, dgv_AdvProducts1, EndDate1, advProductsList1);
                }
                else if (productsInMarketplaces1)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "weeks", dgv_AdvProducts1, pList1, EndDate1, advProductsList1);
                }

                DrawLastColumn(dgv_AdvProducts1);
            }
            else if (byDays1)
            {
                int timeSpan = (EndDate1 - StartDate1).Days + 1;
                if (adgroupsInCampaignsMode1)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "days", _prodId, dgv_AdvProducts1, EndDate1, advProductsList1);
                }
                else if (campaignInProductsMode1)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "days", _prodId, dgv_AdvProducts1, EndDate1, advProductsList1);
                }
                else if (productsInMarketplaces1)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "days", dgv_AdvProducts1, pList1, EndDate1, advProductsList1);
                }

                DrawLastColumn(dgv_AdvProducts1);
            }
        }
        
        /* Генерируем Alarm отчет */
        private void advertisingAlarmReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Advreport7days advRep = new Advreport7days(StartDate1);
            if (MessageBox.Show("Сгенерировать отчет за период " + StartDate1.ToShortDateString() + "-" + StartDate1.AddDays(6).ToShortDateString() + "?\n\nОтчет будет сохранен в корень диска С.", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (advRep.Generate() == 1)
                    MessageBox.Show("Отчет успешно сохранен в корень диска С.", "Успех");
                else
                    MessageBox.Show("При генерации отчета произошла какая-то ошибка. Попробуйте ещё раз.", "Ошибка");
            }
        }

        /* Ищем значения Targetings в таблице по вхождению текста из tb_TargetingSearch1 (ищем Targetings по вводу пользователем) */
        private void tb_TargetingSearch1_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            SearchTargeting(tb.Text, dgv_AdvProducts1, dgv_AdGroups1, dgv_Targetings1, cb_ExactSearch1.Checked);
        }

        /* Включаем/выключаем Exact поиск и автоматически перебираем уже существующие результаты поиска в нужной таблице */
        private void cb_ExactSearch1_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_AdvProducts1.Visible)
            {
                SearchTargeting(tb_TargetingSearch1.Text, dgv_AdvProducts1, cb_ExactSearch1.Checked);
            }
            else if (dgv_AdGroups1.Visible)
            {
                SearchTargeting(tb_TargetingSearch1.Text, dgv_AdGroups1, cb_ExactSearch1.Checked);
            }
            else if (dgv_Targetings1.Visible)
            {
                SearchTargeting(tb_TargetingSearch1.Text, dgv_Targetings1, cb_ExactSearch1.Checked);
            }
        }

        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список */
        private void dgv_AdvProducts1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)     //AdGroup
            {
                string campaignName = dgv_AdvProducts1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdvProducts1.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                foreach (DataGridViewColumn c in dgv_AdvProducts1.Columns)      //adding columns in new table
                {
                    dgv_AdGroups1.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_AdGroups1.Rows.Add();

                for (int i = 1; i < dgv_AdvProducts1.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdvProducts1.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdvProducts1.Rows[i].Cells[3].Value.ToString().Equals(adGroup))
                    {
                        int index = dgv_AdGroups1.Rows.Add(dgv_AdvProducts1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts1.Rows[i].Cells)
                        {
                            dgv_AdGroups1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_AdGroups1);

                SearchTargeting(tb_TargetingSearch1.Text, dgv_AdGroups1, cb_ExactSearch1.Checked);

                //делаем видомости элементов корректными
                dgv_AdGroups1.Visible = true;
                dgv_AdvProducts1.Visible = false;
                btn_CloseTable1.Visible = true;
            }
            if (e.ColumnIndex == 4)     //Targeting
            {
                string campaignName = dgv_AdvProducts1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdvProducts1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string targeting = dgv_AdvProducts1.Rows[e.RowIndex].Cells[4].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdvProducts1.Columns)      //adding columns in new table
                {
                    dgv_Targetings1.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_Targetings1.Rows.Add();

                for (int i = 1; i < dgv_AdvProducts1.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdvProducts1.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdvProducts1.Rows[i].Cells[3].Value.ToString().Equals(adGroup) && dgv_AdvProducts1.Rows[i].Cells[4].Value.ToString().Equals(targeting))
                    {
                        int index = dgv_Targetings1.Rows.Add(dgv_AdvProducts1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts1.Rows[i].Cells)
                        {
                            dgv_Targetings1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_Targetings1);

                SearchTargeting(tb_TargetingSearch1.Text, dgv_Targetings1, cb_ExactSearch1.Checked);

                //делаем видомости элементов корректными
                dgv_Targetings1.Visible = true;
                dgv_AdvProducts1.Visible = false;
                btn_CloseTable1.Visible = true;
            }
        }


        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список */
        private void dgv_AdGroups1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)     //Targeting
            {
                string campaignName = dgv_AdGroups1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdGroups1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string targeting = dgv_AdGroups1.Rows[e.RowIndex].Cells[4].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdGroups1.Columns)      //adding columns in new table
                {
                    dgv_Targetings1.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_Targetings1.Rows.Add();

                for (int i = 1; i < dgv_AdGroups1.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdGroups1.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdGroups1.Rows[i].Cells[3].Value.ToString().Equals(adGroup) && dgv_AdGroups1.Rows[i].Cells[4].Value.ToString().Equals(targeting))
                    {
                        int index = dgv_Targetings1.Rows.Add(dgv_AdGroups1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups1.Rows[i].Cells)
                        {
                            dgv_Targetings1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_Targetings1);

                SearchTargeting(tb_TargetingSearch1.Text, dgv_Targetings1, cb_ExactSearch1.Checked);

                //делаем видомости элементов корректными
                dgv_Targetings1.Visible = true;
                dgv_AdGroups1.Visible = false;
                btn_CloseTable1.Visible = true;
            }
        }

        /* Прячем вспомогательную таблицу и показываем основную */
        private void btn_CloseTable1_Click(object sender, EventArgs e)
        {
            btn_CloseTable1.Visible = false;

            dgv_AdGroups1.Visible = false;
            dgv_AdGroups1.Rows.Clear();
            dgv_AdGroups1.Columns.Clear();

            dgv_Targetings1.Visible = false;
            dgv_Targetings1.Rows.Clear();
            dgv_Targetings1.Columns.Clear();

            SearchTargeting(tb_TargetingSearch1.Text, dgv_AdvProducts1, cb_ExactSearch1.Checked);

            dgv_AdvProducts1.Visible = true;
        }







        /* Копируем всю таблицу с помощью контекстного меню из окна 1 в окно 2 */
        private void context1CopyToTab2_Click(object sender, EventArgs e)
        {
            if (dgv_AdvProducts1.Visible)
            {
                if (dgv_AdvProducts1.Rows.Count > 0)
                {
                    dgv_AdvProducts2.Rows.Clear();
                    dgv_AdvProducts2.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdvProducts1.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts2.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdvProducts1.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts2.Rows.Add(dgv_AdvProducts1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts1.Rows[i].Cells)
                        {
                            dgv_AdvProducts2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod1to2();
                }
            }
            else if (dgv_AdGroups1.Visible)
            {
                if (dgv_AdGroups1.Rows.Count > 0)
                {
                    dgv_AdvProducts2.Rows.Clear();
                    dgv_AdvProducts2.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdGroups1.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts2.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdGroups1.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts2.Rows.Add(dgv_AdGroups1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups1.Rows[i].Cells)
                        {
                            dgv_AdvProducts2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod1to2();
                    ModifidCopyMethod_AdGroups(dgv_AdGroups1, 2, clb_Campaign2, checkedCampaigns2, clb_AdGroup2, checkedAdGroups2);
                }
            }
            else if (dgv_Targetings1.Visible)
            {
                if (dgv_Targetings1.Rows.Count > 0)
                {
                    dgv_AdvProducts2.Rows.Clear();
                    dgv_AdvProducts2.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_Targetings1.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts2.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_Targetings1.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts2.Rows.Add(dgv_Targetings1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_Targetings1.Rows[i].Cells)
                        {
                            dgv_AdvProducts2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod1to2();
                    ModifidCopyMethod_Targeting(dgv_Targetings1, 2, clb_Campaign2, checkedCampaigns2, clb_AdGroup2, checkedAdGroups2, clb_Targeting2, checkedTargeting2);
                }
            }
        }

        /* Копируем всю таблицу с помощью контекстного меню из окна 1 в окно 3 */
        private void context1CopyToTab3_Click(object sender, EventArgs e)
        {
            if (dgv_AdvProducts1.Visible)
            {
                if (dgv_AdvProducts1.Rows.Count > 0)
                {
                    dgv_AdvProducts3.Rows.Clear();
                    dgv_AdvProducts3.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdvProducts1.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts3.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdvProducts1.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts3.Rows.Add(dgv_AdvProducts1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts1.Rows[i].Cells)
                        {
                            dgv_AdvProducts3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }
            }
            else if (dgv_AdGroups1.Visible)
            {
                if (dgv_AdGroups1.Rows.Count > 0)
                {
                    dgv_AdvProducts3.Rows.Clear();
                    dgv_AdvProducts3.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdGroups1.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts3.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdGroups1.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts3.Rows.Add(dgv_AdGroups1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups1.Rows[i].Cells)
                        {
                            dgv_AdvProducts3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod1to3();
                    ModifidCopyMethod_AdGroups(dgv_AdGroups1, 3, clb_Campaign3, checkedCampaigns3, clb_AdGroup3, checkedAdGroups3);
                }
            }
            else if (dgv_Targetings1.Visible)
            {
                if (dgv_Targetings1.Rows.Count > 0)
                {
                    dgv_AdvProducts3.Rows.Clear();
                    dgv_AdvProducts3.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_Targetings1.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts3.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_Targetings1.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts3.Rows.Add(dgv_Targetings1.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_Targetings1.Rows[i].Cells)
                        {
                            dgv_AdvProducts3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod1to3();
                    ModifidCopyMethod_Targeting(dgv_Targetings1, 3, clb_Campaign3, checkedCampaigns3, clb_AdGroup3, checkedAdGroups3, clb_Targeting3, checkedTargeting3);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------2--------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





        /* Получаем из контроллера данные, полученные с БД 2 */
        public void GetProductsFromDB2(object _pList)
        {
            pList2 = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД 2 */
        public void GetMarketPlacesFromDB2(object _mpList)
        {
            mpList2 = (List<MarketplaceModel>)_mpList;
        }

        /* Получаем список кампания/кампания_ид из БД 2 */
        public void GetCampaignsAndIds2(object _tmp)
        {
            campsidsList2 = (List<CmapaignAndIdStruct>)_tmp;
        }

        /* Получаем список id кампаниий AdvertisingProducts из БД 2 */
        public void GetAP_CampaignIdsFromDB2(object _campTList)
        {
            AP_campaignIdsListForActiveCheck2 = (List<MapNameId>)_campTList;
        }

        /* Получаем список кампания/кампания_ид из БД 2 */
        public void GetAdGroups2(object _tmp)
        {
            AdGroupsList2 = (List<string>)_tmp;
        }

        /* Получаем список ключей для AdGroup из БД 2 */
        public void GetTargeting2(object _tmp)
        {
            targetingList2 = (List<string>)_tmp;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetAdvertisingProductsFromDBOriginalValues2(object _advProductList)
        {
            advProductsListOriginal2 = (List<AdvertisingProductsModel>)_advProductList;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД и суммируем значения */
        public void GetAdvertisingProductsFromDBwithSummary2(object _advProductList)
        {
            advProductsList2 = (List<AdvertisingProductsModel>)_advProductList;
            if (by_CustomToolStripMenuItem2.Checked)
            {
                summaryAdvProductsList2.Clear();
                if (byTargetingInAdGroupsToolStripMenuItem2.Checked)
                {
                    MakeSummaryAdvProductListbyTargetingInAdGroups2();
                }
                else if (byAdGroupsInCampaignsToolStripMenuItem2.Checked)
                {
                    MakeSummaryAdvProductListbyAdGroupsInCampaigns2();
                }
                else if (byCampaignInProductsToolStripMenuItem2.Checked)
                {
                    MakeSummaryAdvProductListbyCampaignInProducts2();
                }
                else if (byProductsToolStripMenuItem2.Checked)
                {
                    MakeSummaryAdvProductListbyProducts2();
                }
            }
        }

        /* Заполняем combobox названиями маркетплейсов 2 */
        private void Fill_CLB_Marketplace2()
        {
            clb_Marketplace2.Items.Clear();

            for (int i = 0; i < mpList2.Count; i++)
            {
                clb_Marketplace2.Items.Add(mpList2[i].MarketPlaceName);
            }
        }

        /* Удаляем все повторы с advProductsList2, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyTargetingInAdGroups2()
        {
            List<int> alreadyUsed = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList2.Count; i++)
            {
                if (i == advProductsList2.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsList2[i].Impressions;
                    Clicks = advProductsList2[i].Clicks;
                    Spend = advProductsList2[i].Spend;
                    Sales = advProductsList2[i].Sales;
                    Orders = advProductsList2[i].Orders;
                    Units = advProductsList2[i].Units;
                    AdvSKUUnits = advProductsList2[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList2[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList2[i].AdvSKUSales;
                    OtherSKUSales = advProductsList2[i].OtherSKUSales;

                    if (i < (advProductsList2.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList2.Count; j++)
                        {
                            if (advProductsList2[i].CampaignName.Equals(advProductsList2[j].CampaignName) && advProductsList2[i].AdGroupName.Equals(advProductsList2[j].AdGroupName) && advProductsList2[i].Targeting.Equals(advProductsList2[j].Targeting) && advProductsList2[i].MatchType.Equals(advProductsList2[j].MatchType))
                            {
                                Impressions += advProductsList2[j].Impressions;
                                Clicks += advProductsList2[j].Clicks;
                                Spend += advProductsList2[j].Spend;
                                Sales += advProductsList2[j].Sales;
                                Orders += advProductsList2[j].Orders;
                                Units += advProductsList2[j].Units;
                                AdvSKUUnits += advProductsList2[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList2[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList2[j].AdvSKUSales;
                                OtherSKUSales += advProductsList2[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList2.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].UpdateDate = advProductsList2[i].UpdateDate;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CurrencyCharCode = advProductsList2[i].CurrencyCharCode;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignName = advProductsList2[i].CampaignName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdGroupName = advProductsList2[i].AdGroupName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Targeting = advProductsList2[i].Targeting;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MatchType = advProductsList2[i].MatchType;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Orders = Orders;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Units = Units;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignTypeId = advProductsList2[i].CampaignTypeId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MarketPlaceId = advProductsList2[i].MarketPlaceId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignId = advProductsList2[i].CampaignId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ProductId = advProductsList2[i].ProductId;
                }
            }
            advProductsList2.Clear();
            foreach (var t in summaryAdvProductsList2)
            {
                advProductsList2.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList2, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyAdGroupsInCampaigns2()
        {
            List<int> alreadyUsed = new List<int> { };
            List<string> alreadyUsedAdGroups = new List<string> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList2.Count; i++)
            {
                if (i == advProductsList2.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedAdGroups.Contains(advProductsList2[i].AdGroupName))
                {
                    Impressions = advProductsList2[i].Impressions;
                    Clicks = advProductsList2[i].Clicks;
                    Spend = advProductsList2[i].Spend;
                    Sales = advProductsList2[i].Sales;
                    Orders = advProductsList2[i].Orders;
                    Units = advProductsList2[i].Units;
                    AdvSKUUnits = advProductsList2[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList2[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList2[i].AdvSKUSales;
                    OtherSKUSales = advProductsList2[i].OtherSKUSales;

                    if (i < (advProductsList2.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList2.Count; j++)
                        {
                            if (advProductsList2[i].CampaignName.Equals(advProductsList2[j].CampaignName) && advProductsList2[i].AdGroupName.Equals(advProductsList2[j].AdGroupName) && advProductsList2[i].MatchType.Equals(advProductsList2[j].MatchType))
                            {
                                Impressions += advProductsList2[j].Impressions;
                                Clicks += advProductsList2[j].Clicks;
                                Spend += advProductsList2[j].Spend;
                                Sales += advProductsList2[j].Sales;
                                Orders += advProductsList2[j].Orders;
                                Units += advProductsList2[j].Units;
                                AdvSKUUnits += advProductsList2[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList2[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList2[j].AdvSKUSales;
                                OtherSKUSales += advProductsList2[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList2.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].UpdateDate = advProductsList2[i].UpdateDate;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CurrencyCharCode = advProductsList2[i].CurrencyCharCode;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignName = advProductsList2[i].CampaignName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdGroupName = advProductsList2[i].AdGroupName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Targeting = advProductsList2[i].Targeting;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MatchType = advProductsList2[i].MatchType;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Orders = Orders;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Units = Units;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignTypeId = advProductsList2[i].CampaignTypeId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MarketPlaceId = advProductsList2[i].MarketPlaceId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignId = advProductsList2[i].CampaignId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ProductId = advProductsList2[i].ProductId;

                    alreadyUsedAdGroups.Add(advProductsList2[i].AdGroupName);
                }
            }
            advProductsList2.Clear();
            foreach (var t in summaryAdvProductsList2)
            {
                advProductsList2.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList2, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyCampaignInProducts2()
        {
            List<int> alreadyUsed = new List<int> { };
            List<string> alreadyUsedCampaigns = new List<string> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList2.Count; i++)
            {
                if (i == advProductsList2.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedCampaigns.Contains(advProductsList2[i].CampaignName))
                {
                    Impressions = advProductsList2[i].Impressions;
                    Clicks = advProductsList2[i].Clicks;
                    Spend = advProductsList2[i].Spend;
                    Sales = advProductsList2[i].Sales;
                    Orders = advProductsList2[i].Orders;
                    Units = advProductsList2[i].Units;
                    AdvSKUUnits = advProductsList2[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList2[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList2[i].AdvSKUSales;
                    OtherSKUSales = advProductsList2[i].OtherSKUSales;

                    if (i < (advProductsList2.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList2.Count; j++)
                        {
                            if (advProductsList2[i].CampaignName.Equals(advProductsList2[j].CampaignName) && advProductsList2[i].MatchType.Equals(advProductsList2[j].MatchType))
                            {
                                Impressions += advProductsList2[j].Impressions;
                                Clicks += advProductsList2[j].Clicks;
                                Spend += advProductsList2[j].Spend;
                                Sales += advProductsList2[j].Sales;
                                Orders += advProductsList2[j].Orders;
                                Units += advProductsList2[j].Units;
                                AdvSKUUnits += advProductsList2[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList2[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList2[j].AdvSKUSales;
                                OtherSKUSales += advProductsList2[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList2.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].UpdateDate = advProductsList2[i].UpdateDate;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CurrencyCharCode = advProductsList2[i].CurrencyCharCode;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignName = advProductsList2[i].CampaignName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdGroupName = advProductsList2[i].AdGroupName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Targeting = advProductsList2[i].Targeting;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MatchType = advProductsList2[i].MatchType;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Orders = Orders;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Units = Units;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignTypeId = advProductsList2[i].CampaignTypeId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MarketPlaceId = advProductsList2[i].MarketPlaceId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignId = advProductsList2[i].CampaignId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ProductId = advProductsList2[i].ProductId;

                    alreadyUsedCampaigns.Add(advProductsList2[i].CampaignName);
                }
            }
            advProductsList2.Clear();
            foreach (var t in summaryAdvProductsList2)
            {
                advProductsList2.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList2, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyProducts2()
        {
            List<int> alreadyUsed = new List<int> { };
            List<int> alreadyUsedProductIds = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList2.Count; i++)
            {
                if (i == advProductsList2.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedProductIds.Contains(advProductsList2[i].ProductId))
                {
                    Impressions = advProductsList2[i].Impressions;
                    Clicks = advProductsList2[i].Clicks;
                    Spend = advProductsList2[i].Spend;
                    Sales = advProductsList2[i].Sales;
                    Orders = advProductsList2[i].Orders;
                    Units = advProductsList2[i].Units;
                    AdvSKUUnits = advProductsList2[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList2[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList2[i].AdvSKUSales;
                    OtherSKUSales = advProductsList2[i].OtherSKUSales;

                    if (i < (advProductsList2.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList2.Count; j++)
                        {
                            if (advProductsList2[i].ProductId == advProductsList2[j].ProductId)
                            {
                                Impressions += advProductsList2[j].Impressions;
                                Clicks += advProductsList2[j].Clicks;
                                Spend += advProductsList2[j].Spend;
                                Sales += advProductsList2[j].Sales;
                                Orders += advProductsList2[j].Orders;
                                Units += advProductsList2[j].Units;
                                AdvSKUUnits += advProductsList2[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList2[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList2[j].AdvSKUSales;
                                OtherSKUSales += advProductsList2[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList2.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].UpdateDate = advProductsList2[i].UpdateDate;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CurrencyCharCode = advProductsList2[i].CurrencyCharCode;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignName = advProductsList2[i].CampaignName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdGroupName = advProductsList2[i].AdGroupName;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Targeting = advProductsList2[i].Targeting;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MatchType = advProductsList2[i].MatchType;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Orders = Orders;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].Units = Units;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignTypeId = advProductsList2[i].CampaignTypeId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].MarketPlaceId = advProductsList2[i].MarketPlaceId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].CampaignId = advProductsList2[i].CampaignId;
                    summaryAdvProductsList2[summaryAdvProductsList2.Count - 1].ProductId = advProductsList2[i].ProductId;

                    alreadyUsedProductIds.Add(advProductsList2[i].ProductId);
                }
            }
            advProductsList2.Clear();
            foreach (var t in summaryAdvProductsList2)
            {
                advProductsList2.Add(t);
            }
        }

        /* Открываем форму фильтра */
        private void btn_Filter2_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
                btn_Filter2.Text = "<";
            }
            else if (panel4.Visible == false)
            {
                panel4.Visible = true;
                btn_Filter2.Text = ">";
            }
        }

        /* Быстрое копирование параметров всех фильтров и настроек с Окно 2 в Окно 1 */
        private void copyToTab1toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CopyMethod2to1();
        }

        /* Быстрое копирование параметров всех фильтров и настроек с Окно 2 в Окно 3 */
        private void copyToTab3toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CopyMethod2to3();
        }

        /* Метод копирования параметров всех фильтров и настроек с Окно 2 в Окно 1 */
        private void CopyMethod2to1()
        {
            copying = true;
            byProductsToolStripMenuItem1.Checked = byProductsToolStripMenuItem2.Checked;
            byCampaignInProductsToolStripMenuItem1.Checked = byCampaignInProductsToolStripMenuItem2.Checked;
            byAdGroupsInCampaignsToolStripMenuItem1.Checked = byAdGroupsInCampaignsToolStripMenuItem2.Checked;
            byTargetingInAdGroupsToolStripMenuItem1.Checked = byTargetingInAdGroupsToolStripMenuItem2.Checked;

            by_DaysToolStripMenuItem1.Checked = by_DaysToolStripMenuItem2.Checked;
            by_WeeksToolStripMenuItem1.Checked = by_WeeksToolStripMenuItem2.Checked;
            by_MonthsToolStripMenuItem1.Checked = by_MonthsToolStripMenuItem2.Checked;
            by_CustomToolStripMenuItem1.Checked = by_CustomToolStripMenuItem2.Checked;

            cb_WithoutAdvertising1.Checked = cb_WithoutAdvertising2.Checked;
            cb_WithInactive1.Checked = cb_WithInactive2.Checked;

            mc_StartDate1.SelectionStart = mc_StartDate2.SelectionStart;
            mc_EndDate1.SelectionStart = mc_EndDate2.SelectionStart;

            label3.Text = label10.Text;
            label2.Text = label9.Text;

            StartDate1 = StartDate2;
            EndDate1 = EndDate2;


            pList1 = new List<ProductsModel> { };
            foreach (var t in pList2) { pList1.Add(t); }

            campsidsList1 = new List<CmapaignAndIdStruct> { };
            foreach (var t in campsidsList2) { campsidsList1.Add(t); }

            checkedMarkeplaces1.Clear();
            foreach (var t in checkedMarkeplaces2) { checkedMarkeplaces1.Add(t); }

            checkedProducts1.Clear();
            foreach (var t in checkedProducts2) { checkedProducts1.Add(t); }

            checkedCampaigns1.Clear();
            foreach (var t in checkedCampaigns2) { checkedCampaigns1.Add(t); }

            checkedAdGroups1.Clear();
            foreach (var t in checkedAdGroups2) { checkedAdGroups1.Add(t); }

            checkedTargeting1.Clear();
            foreach (var t in checkedTargeting2) { checkedTargeting1.Add(t); }

            clb_Marketplace1.Items.Clear();
            foreach (var t in clb_Marketplace2.Items) { clb_Marketplace1.Items.Add(t); }

            clb_Product1.Items.Clear();
            foreach (var t in clb_Product2.Items) { clb_Product1.Items.Add(t); }

            clb_Campaign1.Items.Clear();
            foreach (var t in clb_Campaign2.Items) { clb_Campaign1.Items.Add(t); }

            clb_AdGroup1.Items.Clear();
            foreach (var t in clb_AdGroup2.Items) { clb_AdGroup1.Items.Add(t); }

            clb_Targeting1.Items.Clear();
            foreach (var t in clb_Targeting2.Items) { clb_Targeting1.Items.Add(t); }


            checkedMarkeplacesTMP1.Clear();
            foreach (var t in checkedMarkeplacesTMP2) { checkedMarkeplacesTMP1.Add(t); }
            checkedProductsTMP1.Clear();
            foreach (var t in checkedProductsTMP2) { checkedProductsTMP1.Add(t); }
            checkedCampaignsTMP1.Clear();
            foreach (var t in checkedCampaignsTMP2) { checkedCampaignsTMP1.Add(t); }
            checkedAdGroupsTMP1.Clear();
            foreach (var t in checkedAdGroupsTMP2) { checkedAdGroupsTMP1.Add(t); }
            checkedTargetingTMP1.Clear();
            foreach (var t in checkedTargetingTMP2) { checkedTargetingTMP1.Add(t); }


            for (int i = 0; i < clb_Marketplace1.Items.Count; i++)
            {
                if (checkedMarkeplaces1.Contains(clb_Marketplace1.Items[i].ToString()))
                    clb_Marketplace1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Product1.Items.Count; i++)
            {
                if (checkedProducts1.Contains(clb_Product1.Items[i].ToString()))
                    clb_Product1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Campaign1.Items.Count; i++)
            {
                if (checkedCampaigns1.Contains(clb_Campaign1.Items[i].ToString()))
                    clb_Campaign1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_AdGroup1.Items.Count; i++)
            {
                if (checkedAdGroups1.Contains(clb_AdGroup1.Items[i].ToString()))
                    clb_AdGroup1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Targeting1.Items.Count; i++)
            {
                if (checkedTargeting1.Contains(clb_Targeting1.Items[i].ToString()))
                    clb_Targeting1.SetItemChecked(i, true);
            }

            tb_clbCampaignFilter1.Text = tb_clbCampaignFilter2.Text;
            tb_clbCampaignFilter1.Enabled = tb_clbCampaignFilter2.Enabled;

            tb_clbAdGroupFilter1.Text = tb_clbAdGroupFilter2.Text;
            tb_clbAdGroupFilter1.Enabled = tb_clbAdGroupFilter2.Enabled;

            tb_clbTargetingFilter1.Text = tb_clbTargetingFilter2.Text;
            tb_clbTargetingFilter1.Enabled = tb_clbTargetingFilter2.Enabled;


            tbCampaignsFilterItems1.Clear();
            foreach (var t in tbCampaignsFilterItems2) { tbCampaignsFilterItems1.Add(t); }
            tbCampaignsFilterItemsPrev1.Clear();
            foreach (var t in tbCampaignsFilterItemsPrev2) { tbCampaignsFilterItemsPrev1.Add(t); }

            tbAdGroupsFilterItems1.Clear();
            foreach (var t in tbAdGroupsFilterItems2) { tbAdGroupsFilterItems1.Add(t); }
            tbAdGroupsFilterItemsPrev1.Clear();
            foreach (var t in tbAdGroupsFilterItemsPrev2) { tbAdGroupsFilterItemsPrev1.Add(t); }

            tbTargetingFilterItems1.Clear();
            foreach (var t in tbTargetingFilterItems2) { tbTargetingFilterItems1.Add(t); }
            tbTargetingFilterItemsPrev1.Clear();
            foreach (var t in tbTargetingFilterItemsPrev2) { tbTargetingFilterItemsPrev1.Add(t); }

            panel2.Visible = true;
            btn_Filter1.Text = ">";
            copying = false;
        }

        /* Метод копирования параметров всех фильтров и настроек с Окно 2 в Окно 3 */
        private void CopyMethod2to3()
        {
            copying = true;
            byProductsToolStripMenuItem3.Checked = byProductsToolStripMenuItem2.Checked;
            byCampaignInProductsToolStripMenuItem3.Checked = byCampaignInProductsToolStripMenuItem2.Checked;
            byAdGroupsInCampaignsToolStripMenuItem3.Checked = byAdGroupsInCampaignsToolStripMenuItem2.Checked;
            byTargetingInAdGroupsToolStripMenuItem3.Checked = byTargetingInAdGroupsToolStripMenuItem2.Checked;

            by_DaysToolStripMenuItem3.Checked = by_DaysToolStripMenuItem2.Checked;
            by_WeeksToolStripMenuItem3.Checked = by_WeeksToolStripMenuItem2.Checked;
            by_MonthsToolStripMenuItem3.Checked = by_MonthsToolStripMenuItem2.Checked;
            by_CustomToolStripMenuItem3.Checked = by_CustomToolStripMenuItem2.Checked;

            cb_WithoutAdvertising3.Checked = cb_WithoutAdvertising2.Checked;
            cb_WithInactive3.Checked = cb_WithInactive2.Checked;

            mc_StartDate3.SelectionStart = mc_StartDate2.SelectionStart;
            mc_EndDate3.SelectionStart = mc_EndDate2.SelectionStart;

            label23.Text = label10.Text;
            label22.Text = label9.Text;

            StartDate3 = StartDate2;
            EndDate3 = EndDate2;


            pList3 = new List<ProductsModel> { };
            foreach (var t in pList2) { pList3.Add(t); }

            campsidsList3 = new List<CmapaignAndIdStruct> { };
            foreach (var t in campsidsList2) { campsidsList3.Add(t); }

            checkedMarkeplaces3.Clear();
            foreach (var t in checkedMarkeplaces2) { checkedMarkeplaces3.Add(t); }

            checkedProducts3.Clear();
            foreach (var t in checkedProducts2) { checkedProducts3.Add(t); }

            checkedCampaigns3.Clear();
            foreach (var t in checkedCampaigns2) { checkedCampaigns3.Add(t); }

            checkedAdGroups3.Clear();
            foreach (var t in checkedAdGroups2) { checkedAdGroups3.Add(t); }

            checkedTargeting3.Clear();
            foreach (var t in checkedTargeting2) { checkedTargeting3.Add(t); }

            clb_Marketplace3.Items.Clear();
            foreach (var t in clb_Marketplace2.Items) { clb_Marketplace3.Items.Add(t); }

            clb_Product3.Items.Clear();
            foreach (var t in clb_Product2.Items) { clb_Product3.Items.Add(t); }

            clb_Campaign3.Items.Clear();
            foreach (var t in clb_Campaign2.Items) { clb_Campaign3.Items.Add(t); }

            clb_AdGroup3.Items.Clear();
            foreach (var t in clb_AdGroup2.Items) { clb_AdGroup3.Items.Add(t); }

            clb_Targeting3.Items.Clear();
            foreach (var t in clb_Targeting2.Items) { clb_Targeting3.Items.Add(t); }


            checkedMarkeplacesTMP3.Clear();
            foreach (var t in checkedMarkeplacesTMP2) { checkedMarkeplacesTMP3.Add(t); }
            checkedProductsTMP3.Clear();
            foreach (var t in checkedProductsTMP2) { checkedProductsTMP3.Add(t); }
            checkedCampaignsTMP3.Clear();
            foreach (var t in checkedCampaignsTMP2) { checkedCampaignsTMP3.Add(t); }
            checkedAdGroupsTMP3.Clear();
            foreach (var t in checkedAdGroupsTMP2) { checkedAdGroupsTMP3.Add(t); }
            checkedTargetingTMP3.Clear();
            foreach (var t in checkedTargetingTMP2) { checkedTargetingTMP3.Add(t); }


            for (int i = 0; i < clb_Marketplace3.Items.Count; i++)
            {
                if (checkedMarkeplaces3.Contains(clb_Marketplace3.Items[i].ToString()))
                    clb_Marketplace3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Product3.Items.Count; i++)
            {
                if (checkedProducts3.Contains(clb_Product3.Items[i].ToString()))
                    clb_Product3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Campaign3.Items.Count; i++)
            {
                if (checkedCampaigns3.Contains(clb_Campaign3.Items[i].ToString()))
                    clb_Campaign3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_AdGroup3.Items.Count; i++)
            {
                if (checkedAdGroups3.Contains(clb_AdGroup3.Items[i].ToString()))
                    clb_AdGroup3.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Targeting3.Items.Count; i++)
            {
                if (checkedTargeting3.Contains(clb_Targeting3.Items[i].ToString()))
                    clb_Targeting3.SetItemChecked(i, true);
            }

            tb_clbCampaignFilter3.Text = tb_clbCampaignFilter2.Text;
            tb_clbCampaignFilter3.Enabled = tb_clbCampaignFilter2.Enabled;

            tb_clbAdGroupFilter3.Text = tb_clbAdGroupFilter2.Text;
            tb_clbAdGroupFilter3.Enabled = tb_clbAdGroupFilter2.Enabled;

            tb_clbTargetingFilter3.Text = tb_clbTargetingFilter2.Text;
            tb_clbTargetingFilter3.Enabled = tb_clbTargetingFilter2.Enabled;


            tbCampaignsFilterItems3.Clear();
            foreach (var t in tbCampaignsFilterItems2) { tbCampaignsFilterItems3.Add(t); }
            tbCampaignsFilterItemsPrev3.Clear();
            foreach (var t in tbCampaignsFilterItemsPrev2) { tbCampaignsFilterItemsPrev3.Add(t); }

            tbAdGroupsFilterItems3.Clear();
            foreach (var t in tbAdGroupsFilterItems2) { tbAdGroupsFilterItems3.Add(t); }
            tbAdGroupsFilterItemsPrev3.Clear();
            foreach (var t in tbAdGroupsFilterItemsPrev2) { tbAdGroupsFilterItemsPrev3.Add(t); }

            tbTargetingFilterItems3.Clear();
            foreach (var t in tbTargetingFilterItems2) { tbTargetingFilterItems3.Add(t); }
            tbTargetingFilterItemsPrev3.Clear();
            foreach (var t in tbTargetingFilterItemsPrev2) { tbTargetingFilterItemsPrev3.Add(t); }


            panel7.Visible = true;
            btn_Filter3.Text = ">";
            copying = false;
        }

        private string GetCompareMode2()
        {
            if (byTargetingInAdGroupsToolStripMenuItem2.Checked)
            {
                return "targetinginadgroups";
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem2.Checked)
            {
                return "adgroupsincampaigns";
            }
            else if (byCampaignInProductsToolStripMenuItem2.Checked)
            {
                return "campaigninproducts";
            }
            else if (byProductsToolStripMenuItem2.Checked)
            {
                return "productsinmarketplaces";
            }
            return "";
        }

        private string GetDateMode2()
        {
            if (by_DaysToolStripMenuItem2.Checked)
            {
                return "days";
            }
            else if (by_WeeksToolStripMenuItem2.Checked)
            {
                return "weeks";
            }
            else if (by_MonthsToolStripMenuItem2.Checked)
            {
                return "months";
            }
            else if (by_CustomToolStripMenuItem2.Checked)
            {
                return "custom";
            }
            return "";
        }

        private void byProductsInMarkeplacesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullCompareMode2();
            EnableCustomTimeMode2();
            byProductsToolStripMenuItem2.Checked = true;
        }

        private void byCampaignInProductsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullCompareMode2();
            EnableCustomTimeMode2();
            byCampaignInProductsToolStripMenuItem2.Checked = true;
        }

        private void byAdGroupsInCampaignsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullCompareMode2();
            EnableCustomTimeMode2();
            byAdGroupsInCampaignsToolStripMenuItem2.Checked = true;
        }

        private void byTargetingInAdGroupsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullCompareMode2();
            NullTimeMode2();
            DisableCustomTimeMode2();
            by_CustomToolStripMenuItem2.Checked = true;
            byTargetingInAdGroupsToolStripMenuItem2.Checked = true;
        }

        private void by_CustomToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullTimeMode2();
            by_CustomToolStripMenuItem2.Checked = true;
        }

        private void by_DaysToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullTimeMode2();
            by_DaysToolStripMenuItem2.Checked = true;
        }

        private void by_WeeksToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullTimeMode2();
            by_WeeksToolStripMenuItem2.Checked = true;
        }

        private void by_MonthsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NullTimeMode2();
            by_MonthsToolStripMenuItem2.Checked = true;
        }

        private void DisableCustomTimeMode2()
        {
            by_DaysToolStripMenuItem2.Enabled = false;
            by_WeeksToolStripMenuItem2.Enabled = false;
            by_MonthsToolStripMenuItem2.Enabled = false;
        }

        private void EnableCustomTimeMode2()
        {
            by_DaysToolStripMenuItem2.Enabled = true;
            by_WeeksToolStripMenuItem2.Enabled = true;
            by_MonthsToolStripMenuItem2.Enabled = true;
        }

        private void NullTimeMode2()
        {
            by_DaysToolStripMenuItem2.Checked = false;
            by_WeeksToolStripMenuItem2.Checked = false;
            by_MonthsToolStripMenuItem2.Checked = false;
            by_CustomToolStripMenuItem2.Checked = false;
        }

        private void NullCompareMode2()
        {
            byProductsToolStripMenuItem2.Checked = false;
            byCampaignInProductsToolStripMenuItem2.Checked = false;
            byAdGroupsInCampaignsToolStripMenuItem2.Checked = false;
            byTargetingInAdGroupsToolStripMenuItem2.Checked = false;
        }
        private void ResetCompareModes2()
        {
            targetingInAdgroupsMode2 = false;
            adgroupsInCampaignsMode2 = false;
            campaignInProductsMode2 = false;
            productsInMarketplaces2 = false;
        }

        private void ResetDateModes2()
        {
            byDays2 = false;
            byWeeks2 = false;
            byMonths2 = false;
            byCustom2 = false;
        }

        /* Выделяем/снимаем выделение кампании в clb_Marketplace1 */
        private void clb_Marketplace2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedMarkeplaces2.Clear();
            for (int i = 0; i < clb_Marketplace2.CheckedItems.Count; i++)
            {
                checkedMarkeplaces2.Add(clb_Marketplace2.CheckedItems[i].ToString());
            }

            clb_Product2.Items.Clear();
            checkedProducts2.Clear();

            clb_Campaign2.Items.Clear();
            checkedCampaigns2.Clear();

            clb_AdGroup2.Items.Clear();
            checkedAdGroups2.Clear();

            clb_Targeting2.Items.Clear();
            checkedTargeting2.Clear();

            if (checkedMarkeplaces2.Count > 0)
            {
                int res = 0;

                if (cb_WithInactive1.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames2(checkedMarkeplaces1), 2);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames2(checkedMarkeplaces1), 2);
                }

                if (res == 1)
                {
                    Draw_clb_Products2();
                }
            }
            //else { clb_Product1.Items.Clear(); checkedProducts1.Clear(); }

            disableTbClbFilter2();
        }

        /* Получаем список MarketplaceId по выделенным MarketplaceName1 */
        private List<int> GetMPIdsByNames2(List<string> _checkedMarkeplaces)
        {
            List<int> resultList = new List<int> { };
            for (int i = 0; i < _checkedMarkeplaces.Count; i++)
            {
                for (int j = 0; j < mpList2.Count; j++)
                {
                    if (_checkedMarkeplaces[i].Equals(mpList2[j].MarketPlaceName))
                        resultList.Add(mpList2[j].MarketPlaceId);
                }
            }
            return resultList;
        }

        /* Заносим имена товаров в clb_Products1 */
        private void Draw_clb_Products2()
        {
            List<string> names = new List<string> { };
            List<string> finalNames = new List<string> { };

            if (cb_WithoutAdvertising2.Checked || cb_WithInactive2.Checked)
            {
                for (int i = 0; i < pList2.Count; i++)
                {
                    if (!names.Contains(pList2[i].Name))
                        names.Add(pList2[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < pList2.Count; i++)
                {
                    foreach (var t in AP_campaignIdsListForActiveCheck2)
                    {
                        if (t.Name.Contains(pList2[i].ProdShortName))
                            if (!names.Contains(pList2[i].Name))
                                names.Add(pList2[i].Name);
                    }
                }
            }

            clb_Product2.Items.Clear();
            for (int i = 0; i < names.Count; i++)
            {
                clb_Product2.Items.Add(names[i]);
            }
        }

        private void disableTbClbFilter2()
        {
            if (clb_Targeting2.Items.Count == 0)
            {
                tb_clbTargetingFilter2.Enabled = false;
                tb_clbTargetingFilter2.Text = "";
            }
            if (clb_AdGroup2.Items.Count == 0)
            {
                tb_clbAdGroupFilter2.Enabled = false;
                clb_AdGroup2.Text = "";
            }
            if (clb_Campaign2.Items.Count == 0)
            {
                tb_clbCampaignFilter2.Enabled = false;
                tb_clbCampaignFilter2.Text = "";
            }
        }

        /* Отключаем textBox'ы и очищаем их, если clb2 становятся пустыми при изменении галочек cb_WithoutAdvertising2 или cb_WithInactive2 */
        private void disableTbClbFilter2(bool _copying)
        {
            copying = _copying;
            if (clb_Targeting2.Items.Count == 0)
            {
                tb_clbTargetingFilter2.Enabled = false;
                tb_clbTargetingFilter2.Text = "";
            }
            if (clb_AdGroup2.Items.Count == 0)
            {
                tb_clbAdGroupFilter2.Enabled = false;
                tb_clbAdGroupFilter2.Text = "";
            }
            if (clb_Campaign2.Items.Count == 0)
            {
                tb_clbCampaignFilter2.Enabled = false;
                tb_clbCampaignFilter2.Text = "";
            }
            copying = !_copying;
        }

        /* Очистить список выбранных маркетплейсов в clb_Marketplace1 */
        private void btn_Clear_clb_Marketplace2_Click(object sender, EventArgs e)
        {
            checkedMarkeplaces2.Clear();

            clb_Targeting2.Items.Clear();
            checkedTargeting2.Clear();

            clb_AdGroup2.Items.Clear();
            checkedAdGroups2.Clear();

            clb_Campaign2.Items.Clear();
            checkedCampaigns2.Clear();

            clb_Product2.Items.Clear();
            checkedProducts2.Clear();

            for (int i = 0; i < clb_Marketplace2.Items.Count; i++)
            {
                clb_Marketplace2.SetItemChecked(i, false);
            }
            clb_Marketplace2.ClearSelected();

            disableTbClbFilter2();
        }

        /* Отображаем/скрываем товары, у которых нет рекламных кампаний */
        private void cb_WithoutAdvertising2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces2.Count > 0)
            {
                clb_Product2.ClearSelected();
                checkedProducts2.Clear();

                clb_Targeting2.Items.Clear();
                checkedTargeting2.Clear();

                clb_AdGroup2.Items.Clear();
                checkedAdGroups2.Clear();

                clb_Campaign2.Items.Clear();
                checkedCampaigns2.Clear();

                int res = 0;
                if (cb_WithInactive2.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames2(checkedMarkeplaces2), 2);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames2(checkedMarkeplaces2), 2);
                }

                if (res == 1)
                {
                    Draw_clb_Products2();
                }

                disableTbClbFilter2(true);
            }
        }

        /* Меняем режим отображения с активными/неактивными товарами tab1 */
        private void cb_WithInactive2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces2.Count > 0)
            {
                clb_Product2.ClearSelected();
                checkedProducts2.Clear();

                clb_Targeting2.Items.Clear();
                checkedTargeting2.Clear();

                clb_AdGroup2.Items.Clear();
                checkedAdGroups2.Clear();

                clb_Campaign2.Items.Clear();
                checkedCampaigns2.Clear();

                int res = 0;

                if (cb_WithInactive2.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames2(checkedMarkeplaces2), 2);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames2(checkedMarkeplaces2), 2);
                }

                if (res == 1)
                {
                    Draw_clb_Products2();
                }

                disableTbClbFilter2(true);
            }
        }

        /* Выделяем/снимаем выделение кампании в clb_Campaign1 */
        private void clb_Campaign2_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_clb_Campaign2_SelectedIndexChanged();
        }

        private void method_clb_Campaign2_SelectedIndexChanged()
        {
            checkedCampaignsTMP2.Clear();
            for (int i = 0; i < clb_Campaign2.CheckedItems.Count; i++)
            {
                checkedCampaignsTMP2.Add(clb_Campaign2.CheckedItems[i].ToString());
            }

            checkedCampaigns2.Clear();

            foreach (var t in checkedCampaignsTMP2)
            {
                checkedCampaigns2.Add(t);
            }

            List<string> finalAdGroupList = new List<string> { };
            int res = 0;
            int prodId = -1;
            if (checkedCampaigns2.Count > 0)
            {
                for (int i = 0; i < checkedProducts2.Count; i++)
                {
                    prodId = GetProductIdByName2(checkedProducts2[i]);
                    for (int j = 0; j < checkedCampaigns2.Count; j++)
                    {
                        res = advertController.GetAdvertisingProductsAdgroups(prodId, checkedCampaigns2[j], 2);
                        if (res == 1)
                        {
                            for (int t = 0; t < AdGroupsList2.Count; t++)
                            {
                                AdGroupsList2[t] = AdGroupsList2[t] + " (" + checkedCampaigns2[j] + ")";
                                finalAdGroupList.Add(AdGroupsList2[t]);
                            }
                        }
                    }
                }

                GetUniqueAdGroups2(finalAdGroupList);

                if (res == 1)
                {
                    Draw_clb_AdGroups2();
                }
            }
            else
            {
                clb_AdGroup2.Items.Clear();
                checkedAdGroups2.Clear();

                clb_Targeting2.Items.Clear();
                checkedTargeting2.Clear();
            }


            if (clb_AdGroup2.Items.Count > 0)
                tb_clbAdGroupFilter2.Enabled = true;
            else
                tb_clbAdGroupFilter2.Enabled = false;

            disableTbClbFilter2();
        }

        /* Заносим имена кампаний в clb_AdGroups1 */
        private void Draw_clb_AdGroups2()
        {
            clb_AdGroup2.Items.Clear();
            for (int i = 0; i < uniqueAdGroups2.Count; i++)
            {
                clb_AdGroup2.Items.Add(uniqueAdGroups2[i]);
                if (checkedAdGroups2.Contains(uniqueAdGroups2[i]))
                {
                    clb_AdGroup2.SetItemChecked(clb_AdGroup2.Items.Count - 1, true);
                    checkedAdGroupsTMP2.Add(uniqueAdGroups2[i]);
                }
            }

            checkedAdGroups2.Clear();

            foreach (var t in checkedAdGroupsTMP2)
            {
                checkedAdGroups2.Add(t);
            }
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueAdGroups2(List<string> _finalAdGroupList)
        {
            tbAdGroupsFilterItemsPrev2.Clear();
            uniqueAdGroups2 = new List<string> { };
            for (int i = 0; i < _finalAdGroupList.Count; i++)
            {
                if (!uniqueAdGroups2.Contains(_finalAdGroupList[i]))
                {
                    uniqueAdGroups2.Add(_finalAdGroupList[i]);
                    tbAdGroupsFilterItemsPrev2.Add(uniqueAdGroups2[uniqueAdGroups2.Count - 1]);
                }
            }
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName2(List<string> _checkedProducts)
        {
            if (checkedProducts2.Count > 0)
                for (int i = 0; i < pList2.Count; i++)
                {
                    if (pList2[i].Name.Equals(checkedProducts2[0]))
                        return pList2[i].ProductId;
                }
            return -1;
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName2(string _checkedProduct)
        {
            if (checkedProducts2.Count > 0)
                for (int i = 0; i < pList2.Count; i++)
                {
                    if (pList2[i].Name.Equals(_checkedProduct))
                        return pList2[i].ProductId;
                }
            return -1;
        }

        /* Очистить список выбранных кампаний в clb_Campaigns1 */
        private void btn_Clear_clb_Campaigns2_Click(object sender, EventArgs e)
        {
            checkedCampaigns2.Clear();

            clb_Targeting2.Items.Clear();
            checkedTargeting2.Clear();

            clb_AdGroup2.Items.Clear();
            checkedAdGroups2.Clear();

            for (int i = 0; i < clb_Campaign2.Items.Count; i++)
            {
                clb_Campaign2.SetItemChecked(i, false);
            }
            clb_Campaign2.ClearSelected();

            disableTbClbFilter2();
        }

        /* Выделяем/снимаем выделение кампании в clb_AdGroup2 */
        private void clb_AdGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_clb_AdGroup2_SelectedIndexChanged();
        }

        private void method_clb_AdGroup2_SelectedIndexChanged()
        {
            checkedAdGroupsTMP2.Clear();
            for (int i = 0; i < clb_AdGroup2.CheckedItems.Count; i++)
            {
                checkedAdGroupsTMP2.Add(clb_AdGroup2.CheckedItems[i].ToString());
            }

            checkedAdGroups2.Clear();

            foreach (var t in checkedAdGroupsTMP2)
            {
                checkedAdGroups2.Add(t);
            }

            List<string> finalTargetingList = new List<string> { };
            int res = 0;
            int prodId = -1;

            if (checkedAdGroups2.Count > 0)
            {
                for (int i = 0; i < checkedProducts2.Count; i++)
                {
                    prodId = GetProductIdByName2(checkedProducts2[i]);
                    for (int j = 0; j < checkedCampaigns2.Count; j++)
                    {
                        for (int k = 0; k < checkedAdGroups2.Count; k++)
                        {
                            res = advertController.GetAdvertisingProductsTargeting(prodId, checkedCampaigns2[j], ResetNameInCheckedAdGroups(checkedAdGroups2[k]), 2);
                            if (res == 1)
                            {
                                for (int t = 0; t < targetingList2.Count; t++)
                                {
                                    targetingList2[t] = targetingList2[t] + " (" + checkedAdGroups2[k] + ")";
                                    finalTargetingList.Add(targetingList2[t]);
                                }
                            }
                        }
                    }
                }

                GetUniqueTargeting2(finalTargetingList);

                if (res == 1)
                {
                    Draw_clb_Targeting2();
                }
            }
            else
            {
                clb_Targeting2.Items.Clear();
                checkedTargeting2.Clear();
            }

            if (clb_Targeting2.Items.Count > 0)
                tb_clbTargetingFilter2.Enabled = true;
            else
                tb_clbTargetingFilter2.Enabled = false;

            disableTbClbFilter2();
        }

        /* Заносим имена кампаний в clb_Targeting1 */
        private void Draw_clb_Targeting2()
        {
            clb_Targeting2.Items.Clear();
            for (int i = 0; i < uniqueTargeting2.Count; i++)
            {
                clb_Targeting2.Items.Add(uniqueTargeting2[i]);
                if (checkedTargeting2.Contains(uniqueTargeting2[i]))
                {
                    clb_Targeting2.SetItemChecked(clb_Targeting2.Items.Count - 1, true);
                    checkedTargetingTMP2.Add(uniqueTargeting2[i]);
                }
            }

            checkedTargeting2.Clear();

            foreach (var t in checkedTargetingTMP2)
            {
                checkedTargeting2.Add(t);
            }
        }

        /* Получаем уникальные названия ключей */
        private void GetUniqueTargeting2(List<string> _finalTargetingList)
        {
            tbTargetingFilterItemsPrev2.Clear();
            uniqueTargeting2 = new List<string> { };
            for (int i = 0; i < _finalTargetingList.Count; i++)
            {
                if (!uniqueTargeting2.Contains(_finalTargetingList[i]))
                {
                    uniqueTargeting2.Add(_finalTargetingList[i]);
                    tbTargetingFilterItemsPrev2.Add(uniqueTargeting2[uniqueTargeting2.Count - 1]);
                }
            }
        }

        /* Выделяем/снимаем выделение кампании в clb_Targeting2 */
        private void clb_Targeting2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedTargeting2.Clear();
            for (int i = 0; i < clb_Targeting2.CheckedItems.Count; i++)
            {
                checkedTargeting2.Add(clb_Targeting2.CheckedItems[i].ToString());
            }

            disableTbClbFilter2();
        }

        /* Очистить список выбранных кампаний в clb_Targeting2 */
        private void btn_Clear_clb_Targeting2_Click(object sender, EventArgs e)
        {
            checkedTargeting2.Clear();

            for (int i = 0; i < clb_Targeting2.Items.Count; i++)
            {
                clb_Targeting2.SetItemChecked(i, false);
            }
            clb_Targeting2.ClearSelected();

            disableTbClbFilter2();
        }

        /* Очистить список выбранных кампаний в clb_AdGroup2 */
        private void btn_Clear_clb_AdGroups2_Click(object sender, EventArgs e)
        {
            checkedAdGroups2.Clear();

            clb_Targeting2.Items.Clear();
            checkedTargeting2.Clear();

            for (int i = 0; i < clb_AdGroup2.Items.Count; i++)
            {
                clb_AdGroup2.SetItemChecked(i, false);
            }
            clb_AdGroup2.ClearSelected();

            disableTbClbFilter2();
        }

        /* Ищем значения в clb_Campaign2 по вхождению текста из tb_clbCampaignFilter2 (ищем Campaigns по вводу пользователем) */
        private void tb_clbCampaignFilter2_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbCampaignsFilterItems2.Clear();
                string text = tb_clbCampaignFilter2.Text.ToLower();

                for (int i = 0; i < tbCampaignsFilterItemsPrev2.Count; i++)
                {
                    if (tbCampaignsFilterItemsPrev2[i].ToLower().Contains(text))
                        tbCampaignsFilterItems2.Add(tbCampaignsFilterItemsPrev2[i]);
                }

                clb_Campaign2.Items.Clear();

                for (int i = 0; i < tbCampaignsFilterItems2.Count; i++)
                {
                    clb_Campaign2.Items.Add(tbCampaignsFilterItems2[i]);
                    if (checkedCampaigns2.Contains(tbCampaignsFilterItems2[i]))
                        clb_Campaign2.SetItemChecked(clb_Campaign2.Items.Count - 1, true);
                }
            }
        }

        /* Ищем значения в clb_AdGroup2 по вхождению текста из tb_clbAdGroupFilter2 (ищем AdGroups по вводу пользователем) */
        private void tb_clbAdGroupFilter2_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbAdGroupsFilterItems2.Clear();
                string text = tb_clbAdGroupFilter2.Text.ToLower();

                for (int i = 0; i < tbAdGroupsFilterItemsPrev2.Count; i++)
                {
                    if (tbAdGroupsFilterItemsPrev2[i].ToLower().Contains(text))
                        tbAdGroupsFilterItems2.Add(tbAdGroupsFilterItemsPrev2[i]);
                }

                clb_AdGroup2.Items.Clear();

                for (int i = 0; i < tbAdGroupsFilterItems2.Count; i++)
                {
                    clb_AdGroup2.Items.Add(tbAdGroupsFilterItems2[i]);
                    if (checkedAdGroups2.Contains(tbAdGroupsFilterItems2[i]))
                        clb_AdGroup2.SetItemChecked(clb_AdGroup2.Items.Count - 1, true);
                }
            }
        }

        /* Ищем значения в clb_Targeting2 по вхождению текста из tb_clbTargetingFilter2 (ищем Targetings по вводу пользователем) */
        private void tb_clbTargetingFilter2_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbTargetingFilterItems2.Clear();
                string text = tb_clbTargetingFilter2.Text.ToLower();

                for (int i = 0; i < tbTargetingFilterItemsPrev2.Count; i++)
                {
                    if (tbTargetingFilterItemsPrev2[i].ToLower().Contains(text))
                        tbTargetingFilterItems2.Add(tbTargetingFilterItemsPrev2[i]);
                }

                clb_Targeting2.Items.Clear();

                for (int i = 0; i < tbTargetingFilterItems2.Count; i++)
                {
                    clb_Targeting2.Items.Add(tbTargetingFilterItems2[i]);
                    if (checkedTargeting2.Contains(tbTargetingFilterItems2[i]))
                        clb_Targeting2.SetItemChecked(clb_Targeting2.Items.Count - 1, true);
                }
            }
        }

        /* Скрываем форму по нажатию ЛКМ по любому месту на dgv_AdvertisingProducts */
        private void dgv_AdvProducts2_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
                btn_Filter2.Text = "<";
            }
        }

        /* Скрываем форму по нажатию ЛКМ по любому месту во вкладке */
        private void tabPage2_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
                btn_Filter2.Text = "<";
            }
        }

        /* Изменяем дату начала в календаре 1 */
        private void mc_StartDate2_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate2 = mc_StartDate2.SelectionStart;
            label10.Text = mc_StartDate2.SelectionStart.ToShortDateString();
        }

        /* Изменяем дату окончания в календаре 1 */
        private void mc_EndDate2_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate2 = mc_EndDate2.SelectionEnd;
            label9.Text = mc_EndDate2.SelectionStart.ToShortDateString();
        }

        /* Выделяем/снимаем выделение товара в clb_Product1 */
        private void clb_Product2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedProductsTMP2.Clear();
            for (int i = 0; i < clb_Product2.CheckedItems.Count; i++)
            {
                checkedProductsTMP2.Add(clb_Product2.CheckedItems[i].ToString());
            }

            checkedProducts2.Clear();

            foreach (var t in checkedProductsTMP2)
            {
                checkedProducts2.Add(t);
            }

            int res = 0;

            if (checkedProducts2.Count > 0)
            {
                res = advertController.GetAdvertisingProductsCampaignAndCampId2(GetProductIdsByNames2(checkedProducts2));
                GetUniqueCampaigns2();
            }
            else
            {
                clb_Campaign2.Items.Clear();
                checkedCampaigns2.Clear();

                clb_AdGroup2.Items.Clear();
                checkedAdGroups2.Clear();

                clb_Targeting2.Items.Clear();
                checkedTargeting2.Clear();
            }


            if (res == 1)
            {
                Draw_clb_Campaigns2();
            }

            if (clb_Campaign2.Items.Count > 0)
                tb_clbCampaignFilter2.Enabled = true;
            else
                tb_clbCampaignFilter2.Enabled = false;

            disableTbClbFilter2();
        }

        /* Очистить список выбранных товаров в clb_Products2 */
        private void btn_Clear_clb_Products2_Click(object sender, EventArgs e)
        {
            checkedProducts2.Clear();

            clb_Targeting2.Items.Clear();
            checkedTargeting2.Clear();

            clb_AdGroup2.Items.Clear();
            checkedAdGroups2.Clear();

            clb_Campaign2.Items.Clear();
            checkedCampaigns2.Clear();

            for (int i = 0; i < clb_Product2.Items.Count; i++)
            {
                clb_Product2.SetItemChecked(i, false);
            }
            clb_Product2.ClearSelected();

            disableTbClbFilter2();
        }

        /* Заносим имена кампаний в clb_Campaigns2 */
        private void Draw_clb_Campaigns2()
        {
            clb_Campaign2.Items.Clear();
            checkedCampaignsTMP2.Clear();
            for (int i = 0; i < uniqueCampaigns2.Count; i++)
            {
                clb_Campaign2.Items.Add(uniqueCampaigns2[i]);
                if (checkedCampaigns2.Contains(uniqueCampaigns2[i]))
                {
                    clb_Campaign2.SetItemChecked(clb_Campaign2.Items.Count - 1, true);
                    checkedCampaignsTMP2.Add(uniqueCampaigns2[i]);
                }
            }

            checkedCampaigns2.Clear();

            foreach (var t in checkedCampaignsTMP2)
            {
                checkedCampaigns2.Add(t);
            }

            if (checkedCampaigns2.Count == 0)
            {
                clb_AdGroup2.Items.Clear();
                checkedAdGroups2.Clear();
            }
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueCampaigns2()
        {
            uniqueCampaigns2 = new List<string> { };
            tbCampaignsFilterItemsPrev2 = new List<string> { };

            for (int i = 0; i < campsidsList2.Count; i++)
            {
                if (!uniqueCampaigns2.Contains(campsidsList2[i].Key))
                {
                    uniqueCampaigns2.Add(campsidsList2[i].Key);
                    tbCampaignsFilterItemsPrev2.Add(uniqueCampaigns2[uniqueCampaigns2.Count - 1]);
                }
            }
        }

        /* Получаем список ProductId по выделенным ProductName */
        private List<int> GetProductIdsByNames2(List<string> _checkedProducts)
        {
            bool flag = false;
            List<int> resultList = new List<int> { };
            List<int> resultList1 = new List<int> { };
            for (int i = 0; i < _checkedProducts.Count; i++)
            {
                flag = false;
                for (int j = 0; j < pList2.Count; j++)
                {
                    if (!flag && _checkedProducts[i].Equals(pList2[j].Name))
                    {
                        resultList.Add(pList2[j].ProductId);
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

        private string GetFirstAdGroup2()
        {
            if (checkedAdGroups2.Count > 0)
            {
                return checkedAdGroups2[0];
            }
            else
            {
                if (clb_AdGroup2.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите рекламную кампанию!", "Ошибка");
                else
                {
                    return clb_AdGroup2.Items[0].ToString();
                }
            }
            return "";
        }
        private string GetFirstCampaign2()
        {
            if (checkedCampaigns2.Count > 0)
            {
                return checkedCampaigns2[0];
            }
            else
            {
                if (clb_Campaign2.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите товар!", "Ошибка");
                else
                {
                    return clb_Campaign2.Items[0].ToString();
                }
            }
            return "";
        }

        private bool CheckForExistingProducts2()
        {
            if (clb_Product2.Items.Count == 0)
                MessageBox.Show("Для продолжения выберите маркетплейс!", "Ошибка");
            else if (checkedProducts2.Count > 0 || clb_Product2.Items.Count > 0)
                return true;
            return false;
        }

        private string GetProductsAsins2()
        {
            string result = "";
            string name = "";
            string asin = "";

            if (checkedProducts2.Count > 0)
            {
                name = checkedProducts2[0];
            }
            else
            {
                name = clb_Product2.Items[0].ToString();
            }

            for (int i = 0; i < pList2.Count; i++)
            {
                if (pList2[i].Name.Equals(name))
                    asin = pList2[i].ASIN;
            }
            for (int i = 0; i < pList2.Count; i++)
            {
                if (pList2[i].ASIN.Equals(asin))
                    result = result + pList2[i].ProductId + ", ";
            }

            return result;
        }

        /* Получаем список CampaignId по выделенным Campaign1 */
        private List<int> GetCampaignIdsByNames2(List<CmapaignAndIdStruct> _campsidsList)
        {
            List<int> resultList = new List<int> { };
            List<CmapaignAndIdStruct> test = new List<CmapaignAndIdStruct> { };
            bool flag = false;

            for (int i = 0; i < checkedCampaigns2.Count; i++)
            {
                flag = false;
                for (int j = 0; j < campsidsList2.Count; j++)
                {
                    if (!flag && checkedCampaigns2[i].Equals(campsidsList2[j].Key))
                    {
                        resultList.Add(campsidsList2[j].Val);
                        flag = true;
                    }
                }
            }
            return resultList;
        }

        /* Применяем фильтры и перерисовываем данные в таблице */
        private void btn_Show2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            if (StartDate2 > EndDate2)
                MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

            int result = 0;
            advProductsList2 = null;

            if (byTargetingInAdGroupsToolStripMenuItem2.Checked)
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate2, EndDate2, GetMPIdsByNames2(checkedMarkeplaces2), GetProductIdsByNames2(checkedProducts2), GetCampaignIdsByNames2(campsidsList2), ResetNamesInCheckedAdGroups(checkedAdGroups2), ResetNamesInCheckedTargeting(checkedTargeting2), 2);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow2(advProductsList2, advProductsListOriginal2, GetCompareMode2(), pList2, GetDateMode2(), "", GetProductIdByName2(checkedProducts2));
                    filterAdvProductsList2 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem2.Checked && !GetFirstAdGroup2().Equals(""))
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate2, EndDate2, GetMPIdsByNames2(checkedMarkeplaces2), GetProductIdsByNames2(checkedProducts2), GetCampaignIdsByNames2(campsidsList2), ResetNamesInCheckedAdGroups(checkedAdGroups2), new List<string> { }, 2);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow2(advProductsList2, advProductsListOriginal2, GetCompareMode2(), pList2, GetDateMode2(), GetFirstAdGroup2(), GetProductIdByName2(checkedProducts2));
                    filterAdvProductsList2 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byCampaignInProductsToolStripMenuItem2.Checked && !GetFirstCampaign2().Equals(""))
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate2, EndDate2, GetMPIdsByNames2(checkedMarkeplaces2), GetProductIdsByNames2(checkedProducts2), GetCampaignIdsByNames2(campsidsList2), new List<string> { }, new List<string> { }, 2);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow2(advProductsList2, advProductsListOriginal2, GetCompareMode2(), pList2, GetDateMode2(), GetFirstCampaign2(), GetProductIdByName2(checkedProducts2));
                    filterAdvProductsList2 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byProductsToolStripMenuItem2.Checked && CheckForExistingProducts2())
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate2, EndDate2, GetMPIdsByNames2(checkedMarkeplaces2), GetProductIdsByNames2(checkedProducts2), new List<int> { }, new List<string> { }, new List<string> { }, 2);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow2(advProductsList2, advProductsListOriginal2, GetCompareMode2(), pList2, GetDateMode2(), GetProductsAsins2(), GetProductIdByName2(checkedProducts2));
                    filterAdvProductsList2 = new List<AdvertisingProductsModel> { };
                }
            }

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        /* Получаем список advProductsList1 и рисуем его в таблице dgv_AdvProducts1 */
        public void GetAdvertisingProductsListToShow2(object _advProductsList, object _advProductsListOriginal, string _compareMode, object _pList, string _dateMode, string _object, int _prodId)
        {
            advProductsList2 = (List<AdvertisingProductsModel>)_advProductsList;
            advProductsListOriginal2 = (List<AdvertisingProductsModel>)_advProductsListOriginal;

            lb_StartDate2.Text = label10.Text;
            lb_EndDate2.Text = label9.Text;

            if (_compareMode.Equals("targetinginadgroups"))
            {
                ResetCompareModes2();
                targetingInAdgroupsMode2 = true;
            }
            else if (_compareMode.Equals("adgroupsincampaigns"))
            {
                ResetCompareModes2();
                adgroupsInCampaignsMode2 = true;
                this.Text = "По группам";
            }
            else if (_compareMode.Equals("campaigninproducts"))
            {
                ResetCompareModes2();
                campaignInProductsMode2 = true;
                this.Text = "По кампаниям";
            }
            else if (_compareMode.Equals("productsinmarketplaces"))
            {
                ResetCompareModes2();
                productsInMarketplaces2 = true;
                this.Text = "По товарам";
            }

            if (_dateMode.Equals("days"))
            {
                ResetDateModes2();
                byDays2 = true;
            }
            else if (_dateMode.Equals("weeks"))
            {
                ResetDateModes2();
                byWeeks2 = true;
            }
            else if (_dateMode.Equals("months"))
            {
                ResetDateModes2();
                byMonths2 = true;
            }
            else if (_dateMode.Equals("custom"))
            {
                ResetDateModes2();
                byCustom2 = true;
            }

            pList2 = (List<ProductsModel>)_pList;

            if (byCustom2)
                DrawTableForSponsoredProducts(advProductsList2, dgv_AdvProducts2, pList2, targetingInAdgroupsMode2, adgroupsInCampaignsMode2, campaignInProductsMode2, productsInMarketplaces2);
            else if (byMonths2)
            {
                int timeSpan = ((EndDate2 - StartDate2).Days + 1) / 31;
                if (adgroupsInCampaignsMode2)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "months", _prodId, dgv_AdvProducts2, EndDate2, advProductsList2);
                }
                else if (campaignInProductsMode2)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "months", _prodId, dgv_AdvProducts2, EndDate2, advProductsList2);
                }
                else if (productsInMarketplaces2)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "months", dgv_AdvProducts2, pList2, EndDate2, advProductsList2);
                }

                DrawLastColumn(dgv_AdvProducts2);
            }
            else if (byWeeks2)
            {
                int timeSpan = ((EndDate2 - StartDate2).Days + 1) / 7;
                if (adgroupsInCampaignsMode2)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "weeks", _prodId, dgv_AdvProducts2, EndDate2, advProductsList2);
                }
                else if (campaignInProductsMode2)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "weeks", _prodId, dgv_AdvProducts2, EndDate2, advProductsList2);
                }
                else if (productsInMarketplaces2)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "weeks", dgv_AdvProducts2, pList2, EndDate2, advProductsList2);
                }

                DrawLastColumn(dgv_AdvProducts2);
            }
            else if (byDays2)
            {
                int timeSpan = (EndDate2 - StartDate2).Days + 1;
                if (adgroupsInCampaignsMode2)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "days", _prodId, dgv_AdvProducts2, EndDate2, advProductsList2);
                }
                else if (campaignInProductsMode2)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "days", _prodId, dgv_AdvProducts2, EndDate2, advProductsList2);
                }
                else if (productsInMarketplaces2)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "days", dgv_AdvProducts2, pList2, EndDate2, advProductsList2);
                }

                DrawLastColumn(dgv_AdvProducts2);
            }
        }

        /* Генерируем Alarm отчет 2 */
        private void advertisingAlarmReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Advreport7days advRep = new Advreport7days(StartDate2);
            if (MessageBox.Show("Сгенерировать отчет за период " + StartDate2.ToShortDateString() + "-" + StartDate2.AddDays(6).ToShortDateString() + "?\n\nОтчет будет сохранен в корень диска С.", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (advRep.Generate() == 1)
                    MessageBox.Show("Отчет успешно сохранен в корень диска С.", "Успех");
                else
                    MessageBox.Show("При генерации отчета произошла какая-то ошибка. Попробуйте ещё раз.", "Ошибка");
            }
        }

        /* Ищем значения Targetings в таблице по вхождению текста из tb_TargetingSearch1 (ищем Targetings по вводу пользователем) 2 */
        private void tb_TargetingSearch2_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            SearchTargeting(tb.Text, dgv_AdvProducts2, dgv_AdGroups2, dgv_Targetings2, cb_ExactSearch2.Checked);
        }

        /* Включаем/выключаем Exact поиск и автоматически перебираем уже существующие результаты поиска в нужной таблице 2 */
        private void cb_ExactSearch2_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_AdvProducts2.Visible)
            {
                SearchTargeting(tb_TargetingSearch2.Text, dgv_AdvProducts2, cb_ExactSearch2.Checked);
            }
            else if (dgv_AdGroups2.Visible)
            {
                SearchTargeting(tb_TargetingSearch2.Text, dgv_AdGroups2, cb_ExactSearch2.Checked);
            }
            else if (dgv_Targetings2.Visible)
            {
                SearchTargeting(tb_TargetingSearch2.Text, dgv_Targetings2, cb_ExactSearch2.Checked);
            }
        }

        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список 2 */
        private void dgv_AdvProducts2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)     //AdGroup
            {
                string campaignName = dgv_AdvProducts2.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdvProducts2.Rows[e.RowIndex].Cells[3].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdvProducts2.Columns)      //adding columns in new table
                {
                    dgv_AdGroups2.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_AdGroups2.Rows.Add();

                for (int i = 1; i < dgv_AdvProducts2.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdvProducts2.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdvProducts2.Rows[i].Cells[3].Value.ToString().Equals(adGroup))
                    {
                        int index = dgv_AdGroups2.Rows.Add(dgv_AdvProducts2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts2.Rows[i].Cells)
                        {
                            dgv_AdGroups2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_AdGroups2);

                SearchTargeting(tb_TargetingSearch2.Text, dgv_AdGroups2, cb_ExactSearch2.Checked);

                //делаем видомости элементов корректными
                dgv_AdGroups2.Visible = true;
                dgv_AdvProducts2.Visible = false;
                btn_CloseTable2.Visible = true;
            }
            if (e.ColumnIndex == 4)     //Targeting
            {
                string campaignName = dgv_AdvProducts2.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdvProducts2.Rows[e.RowIndex].Cells[3].Value.ToString();
                string targeting = dgv_AdvProducts2.Rows[e.RowIndex].Cells[4].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdvProducts2.Columns)      //adding columns in new table
                {
                    dgv_Targetings2.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_Targetings2.Rows.Add();

                for (int i = 1; i < dgv_AdvProducts2.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdvProducts2.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdvProducts2.Rows[i].Cells[3].Value.ToString().Equals(adGroup) && dgv_AdvProducts2.Rows[i].Cells[4].Value.ToString().Equals(targeting))
                    {
                        int index = dgv_Targetings2.Rows.Add(dgv_AdvProducts2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts2.Rows[i].Cells)
                        {
                            dgv_Targetings2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_Targetings2);

                SearchTargeting(tb_TargetingSearch2.Text, dgv_Targetings2, cb_ExactSearch2.Checked);

                //делаем видомости элементов корректными
                dgv_Targetings2.Visible = true;
                dgv_AdvProducts2.Visible = false;
                btn_CloseTable2.Visible = true;
            }
        }


        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список 2 */
        private void dgv_AdGroups2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)     //Targeting
            {
                string campaignName = dgv_AdGroups2.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdGroups2.Rows[e.RowIndex].Cells[3].Value.ToString();
                string targeting = dgv_AdGroups2.Rows[e.RowIndex].Cells[4].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdGroups2.Columns)      //adding columns in new table
                {
                    dgv_Targetings2.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_Targetings2.Rows.Add();

                for (int i = 1; i < dgv_AdGroups2.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdGroups2.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdGroups2.Rows[i].Cells[3].Value.ToString().Equals(adGroup) && dgv_AdGroups2.Rows[i].Cells[4].Value.ToString().Equals(targeting))
                    {
                        int index = dgv_Targetings2.Rows.Add(dgv_AdGroups2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups2.Rows[i].Cells)
                        {
                            dgv_Targetings2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_Targetings2);

                SearchTargeting(tb_TargetingSearch2.Text, dgv_Targetings2, cb_ExactSearch2.Checked);

                //делаем видомости элементов корректными
                dgv_Targetings2.Visible = true;
                dgv_AdGroups2.Visible = false;
                btn_CloseTable2.Visible = true;
            }
        }

        /* Прячем вспомогательную таблицу и показываем основную 2 */
        private void btn_CloseTable2_Click(object sender, EventArgs e)
        {
            btn_CloseTable2.Visible = false;

            dgv_AdGroups2.Visible = false;
            dgv_AdGroups2.Rows.Clear();
            dgv_AdGroups2.Columns.Clear();

            dgv_Targetings2.Visible = false;
            dgv_Targetings2.Rows.Clear();
            dgv_Targetings2.Columns.Clear();

            SearchTargeting(tb_TargetingSearch2.Text, dgv_AdvProducts2, cb_ExactSearch2.Checked);

            dgv_AdvProducts2.Visible = true;
        }
        
        /* Копируем всю таблицу с помощью контекстного меню из окна 2 в окно 1 */
        private void context2CopyToTab1_Click(object sender, EventArgs e)
        {
            if (dgv_AdvProducts2.Visible)
            {
                if (dgv_AdvProducts2.Rows.Count > 0)
                {
                    dgv_AdvProducts1.Rows.Clear();
                    dgv_AdvProducts1.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdvProducts2.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts1.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdvProducts2.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts1.Rows.Add(dgv_AdvProducts2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts2.Rows[i].Cells)
                        {
                            dgv_AdvProducts1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod2to1();
                }
            }
            else if (dgv_AdGroups2.Visible)
            {
                if (dgv_AdGroups2.Rows.Count > 0)
                {
                    dgv_AdvProducts1.Rows.Clear();
                    dgv_AdvProducts1.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdGroups2.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts1.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdGroups2.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts1.Rows.Add(dgv_AdGroups2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups2.Rows[i].Cells)
                        {
                            dgv_AdvProducts1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod2to1();
                    ModifidCopyMethod_AdGroups(dgv_AdGroups2, 1, clb_Campaign1, checkedCampaigns1, clb_AdGroup1, checkedAdGroups1);
                }
            }
            else if (dgv_Targetings2.Visible)
            {
                if (dgv_Targetings2.Rows.Count > 0)
                {
                    dgv_AdvProducts1.Rows.Clear();
                    dgv_AdvProducts1.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_Targetings2.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts1.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_Targetings2.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts1.Rows.Add(dgv_Targetings2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_Targetings2.Rows[i].Cells)
                        {
                            dgv_AdvProducts1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod2to1();
                    ModifidCopyMethod_Targeting(dgv_Targetings2, 1, clb_Campaign1, checkedCampaigns1, clb_AdGroup1, checkedAdGroups1, clb_Targeting1, checkedTargeting1);
                }
            }
        }

        /* Копируем всю таблицу с помощью контекстного меню из окна 2 в окно 3 */
        private void context2CopyToTab3_Click(object sender, EventArgs e)
        {
            if (dgv_AdvProducts2.Visible)
            {
                if (dgv_AdvProducts2.Rows.Count > 0)
                {
                    dgv_AdvProducts3.Rows.Clear();
                    dgv_AdvProducts3.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdvProducts2.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts3.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdvProducts2.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts3.Rows.Add(dgv_AdvProducts2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts2.Rows[i].Cells)
                        {
                            dgv_AdvProducts3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod2to3();
                }
            }
            else if (dgv_AdGroups2.Visible)
            {
                if (dgv_AdGroups2.Rows.Count > 0)
                {
                    dgv_AdvProducts3.Rows.Clear();
                    dgv_AdvProducts3.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdGroups2.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts3.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdGroups2.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts3.Rows.Add(dgv_AdGroups2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups2.Rows[i].Cells)
                        {
                            dgv_AdvProducts3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod2to3();
                    ModifidCopyMethod_AdGroups(dgv_AdGroups2, 3, clb_Campaign3, checkedCampaigns3, clb_AdGroup3, checkedAdGroups3);
                }
            }
            else if (dgv_Targetings2.Visible)
            {
                if (dgv_Targetings2.Rows.Count > 0)
                {
                    dgv_AdvProducts3.Rows.Clear();
                    dgv_AdvProducts3.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_Targetings2.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts3.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_Targetings2.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts3.Rows.Add(dgv_Targetings2.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_Targetings2.Rows[i].Cells)
                        {
                            dgv_AdvProducts3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod2to3();
                    ModifidCopyMethod_Targeting(dgv_Targetings2, 3, clb_Campaign3, checkedCampaigns3, clb_AdGroup3, checkedAdGroups3, clb_Targeting3, checkedTargeting3);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------3--------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        /* Получаем из контроллера данные, полученные с БД 3 */
        public void GetProductsFromDB3(object _pList)
        {
            pList3 = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД 3 */
        public void GetMarketPlacesFromDB3(object _mpList)
        {
            mpList3 = (List<MarketplaceModel>)_mpList;
        }

        /* Получаем список кампания/кампания_ид из БД 3 */
        public void GetCampaignsAndIds3(object _tmp)
        {
            campsidsList3 = (List<CmapaignAndIdStruct>)_tmp;
        }

        /* Получаем список id кампаниий AdvertisingProducts из БД 3 */
        public void GetAP_CampaignIdsFromDB3(object _campTList)
        {
            AP_campaignIdsListForActiveCheck3 = (List<MapNameId>)_campTList;
        }

        /* Получаем список кампания/кампания_ид из БД 3 */
        public void GetAdGroups3(object _tmp)
        {
            AdGroupsList3 = (List<string>)_tmp;
        }

        /* Получаем список ключей для AdGroup из БД 3 */
        public void GetTargeting3(object _tmp)
        {
            targetingList3 = (List<string>)_tmp;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetAdvertisingProductsFromDBOriginalValues3(object _advProductList)
        {
            advProductsListOriginal3 = (List<AdvertisingProductsModel>)_advProductList;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД и суммируем значения */
        public void GetAdvertisingProductsFromDBwithSummary3(object _advProductList)
        {
            advProductsList3 = (List<AdvertisingProductsModel>)_advProductList;
            if (by_CustomToolStripMenuItem3.Checked)
            {
                summaryAdvProductsList3.Clear();
                if (byTargetingInAdGroupsToolStripMenuItem3.Checked)
                {
                    MakeSummaryAdvProductListbyTargetingInAdGroups3();
                }
                else if (byAdGroupsInCampaignsToolStripMenuItem3.Checked)
                {
                    MakeSummaryAdvProductListbyAdGroupsInCampaigns3();
                }
                else if (byCampaignInProductsToolStripMenuItem3.Checked)
                {
                    MakeSummaryAdvProductListbyCampaignInProducts3();
                }
                else if (byProductsToolStripMenuItem3.Checked)
                {
                    MakeSummaryAdvProductListbyProducts3();
                }
            }
        }

        /* Заполняем combobox названиями маркетплейсов 3 */
        private void Fill_CLB_Marketplace3()
        {
            clb_Marketplace3.Items.Clear();

            for (int i = 0; i < mpList3.Count; i++)
            {
                clb_Marketplace3.Items.Add(mpList3[i].MarketPlaceName);
            }
        }

        /* Удаляем все повторы с advProductsList3, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyTargetingInAdGroups3()
        {
            List<int> alreadyUsed = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList3.Count; i++)
            {
                if (i == advProductsList3.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsList3[i].Impressions;
                    Clicks = advProductsList3[i].Clicks;
                    Spend = advProductsList3[i].Spend;
                    Sales = advProductsList3[i].Sales;
                    Orders = advProductsList3[i].Orders;
                    Units = advProductsList3[i].Units;
                    AdvSKUUnits = advProductsList3[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList3[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList3[i].AdvSKUSales;
                    OtherSKUSales = advProductsList3[i].OtherSKUSales;

                    if (i < (advProductsList3.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList3.Count; j++)
                        {
                            if (advProductsList3[i].CampaignName.Equals(advProductsList3[j].CampaignName) && advProductsList3[i].AdGroupName.Equals(advProductsList3[j].AdGroupName) && advProductsList3[i].Targeting.Equals(advProductsList3[j].Targeting) && advProductsList3[i].MatchType.Equals(advProductsList3[j].MatchType))
                            {
                                Impressions += advProductsList3[j].Impressions;
                                Clicks += advProductsList3[j].Clicks;
                                Spend += advProductsList3[j].Spend;
                                Sales += advProductsList3[j].Sales;
                                Orders += advProductsList3[j].Orders;
                                Units += advProductsList3[j].Units;
                                AdvSKUUnits += advProductsList3[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList3[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList3[j].AdvSKUSales;
                                OtherSKUSales += advProductsList3[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList3.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].UpdateDate = advProductsList3[i].UpdateDate;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CurrencyCharCode = advProductsList3[i].CurrencyCharCode;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignName = advProductsList3[i].CampaignName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdGroupName = advProductsList3[i].AdGroupName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Targeting = advProductsList3[i].Targeting;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MatchType = advProductsList3[i].MatchType;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Orders = Orders;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Units = Units;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignTypeId = advProductsList3[i].CampaignTypeId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MarketPlaceId = advProductsList3[i].MarketPlaceId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignId = advProductsList3[i].CampaignId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ProductId = advProductsList3[i].ProductId;
                }
            }
            advProductsList3.Clear();
            foreach (var t in summaryAdvProductsList3)
            {
                advProductsList3.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList3, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyAdGroupsInCampaigns3()
        {
            List<int> alreadyUsed = new List<int> { };
            List<string> alreadyUsedAdGroups = new List<string> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList3.Count; i++)
            {
                if (i == advProductsList3.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedAdGroups.Contains(advProductsList3[i].AdGroupName))
                {
                    Impressions = advProductsList3[i].Impressions;
                    Clicks = advProductsList3[i].Clicks;
                    Spend = advProductsList3[i].Spend;
                    Sales = advProductsList3[i].Sales;
                    Orders = advProductsList3[i].Orders;
                    Units = advProductsList3[i].Units;
                    AdvSKUUnits = advProductsList3[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList3[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList3[i].AdvSKUSales;
                    OtherSKUSales = advProductsList3[i].OtherSKUSales;

                    if (i < (advProductsList3.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList3.Count; j++)
                        {
                            if (advProductsList3[i].CampaignName.Equals(advProductsList3[j].CampaignName) && advProductsList3[i].AdGroupName.Equals(advProductsList3[j].AdGroupName) && advProductsList3[i].MatchType.Equals(advProductsList3[j].MatchType))
                            {
                                Impressions += advProductsList3[j].Impressions;
                                Clicks += advProductsList3[j].Clicks;
                                Spend += advProductsList3[j].Spend;
                                Sales += advProductsList3[j].Sales;
                                Orders += advProductsList3[j].Orders;
                                Units += advProductsList3[j].Units;
                                AdvSKUUnits += advProductsList3[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList3[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList3[j].AdvSKUSales;
                                OtherSKUSales += advProductsList3[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList3.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].UpdateDate = advProductsList3[i].UpdateDate;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CurrencyCharCode = advProductsList3[i].CurrencyCharCode;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignName = advProductsList3[i].CampaignName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdGroupName = advProductsList3[i].AdGroupName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Targeting = advProductsList3[i].Targeting;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MatchType = advProductsList3[i].MatchType;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Orders = Orders;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Units = Units;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignTypeId = advProductsList3[i].CampaignTypeId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MarketPlaceId = advProductsList3[i].MarketPlaceId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignId = advProductsList3[i].CampaignId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ProductId = advProductsList3[i].ProductId;

                    alreadyUsedAdGroups.Add(advProductsList3[i].AdGroupName);
                }
            }
            advProductsList3.Clear();
            foreach (var t in summaryAdvProductsList3)
            {
                advProductsList3.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList3, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyCampaignInProducts3()
        {
            List<int> alreadyUsed = new List<int> { };
            List<string> alreadyUsedCampaigns = new List<string> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList3.Count; i++)
            {
                if (i == advProductsList3.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedCampaigns.Contains(advProductsList3[i].CampaignName))
                {
                    Impressions = advProductsList3[i].Impressions;
                    Clicks = advProductsList3[i].Clicks;
                    Spend = advProductsList3[i].Spend;
                    Sales = advProductsList3[i].Sales;
                    Orders = advProductsList3[i].Orders;
                    Units = advProductsList3[i].Units;
                    AdvSKUUnits = advProductsList3[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList3[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList3[i].AdvSKUSales;
                    OtherSKUSales = advProductsList3[i].OtherSKUSales;

                    if (i < (advProductsList3.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList3.Count; j++)
                        {
                            if (advProductsList3[i].CampaignName.Equals(advProductsList3[j].CampaignName) && advProductsList3[i].MatchType.Equals(advProductsList3[j].MatchType))
                            {
                                Impressions += advProductsList3[j].Impressions;
                                Clicks += advProductsList3[j].Clicks;
                                Spend += advProductsList3[j].Spend;
                                Sales += advProductsList3[j].Sales;
                                Orders += advProductsList3[j].Orders;
                                Units += advProductsList3[j].Units;
                                AdvSKUUnits += advProductsList3[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList3[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList3[j].AdvSKUSales;
                                OtherSKUSales += advProductsList3[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList3.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].UpdateDate = advProductsList3[i].UpdateDate;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CurrencyCharCode = advProductsList3[i].CurrencyCharCode;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignName = advProductsList3[i].CampaignName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdGroupName = advProductsList3[i].AdGroupName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Targeting = advProductsList3[i].Targeting;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MatchType = advProductsList3[i].MatchType;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Orders = Orders;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Units = Units;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignTypeId = advProductsList3[i].CampaignTypeId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MarketPlaceId = advProductsList3[i].MarketPlaceId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignId = advProductsList3[i].CampaignId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ProductId = advProductsList3[i].ProductId;

                    alreadyUsedCampaigns.Add(advProductsList3[i].CampaignName);
                }
            }
            advProductsList3.Clear();
            foreach (var t in summaryAdvProductsList3)
            {
                advProductsList3.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList3, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyProducts3()
        {
            List<int> alreadyUsed = new List<int> { };
            List<int> alreadyUsedProductIds = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsList3.Count; i++)
            {
                if (i == advProductsList3.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedProductIds.Contains(advProductsList3[i].ProductId))
                {
                    Impressions = advProductsList3[i].Impressions;
                    Clicks = advProductsList3[i].Clicks;
                    Spend = advProductsList3[i].Spend;
                    Sales = advProductsList3[i].Sales;
                    Orders = advProductsList3[i].Orders;
                    Units = advProductsList3[i].Units;
                    AdvSKUUnits = advProductsList3[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList3[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList3[i].AdvSKUSales;
                    OtherSKUSales = advProductsList3[i].OtherSKUSales;

                    if (i < (advProductsList3.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList3.Count; j++)
                        {
                            if (advProductsList3[i].ProductId == advProductsList3[j].ProductId)
                            {
                                Impressions += advProductsList3[j].Impressions;
                                Clicks += advProductsList3[j].Clicks;
                                Spend += advProductsList3[j].Spend;
                                Sales += advProductsList3[j].Sales;
                                Orders += advProductsList3[j].Orders;
                                Units += advProductsList3[j].Units;
                                AdvSKUUnits += advProductsList3[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList3[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList3[j].AdvSKUSales;
                                OtherSKUSales += advProductsList3[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsList3.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].UpdateDate = advProductsList3[i].UpdateDate;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CurrencyCharCode = advProductsList3[i].CurrencyCharCode;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignName = advProductsList3[i].CampaignName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdGroupName = advProductsList3[i].AdGroupName;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Targeting = advProductsList3[i].Targeting;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MatchType = advProductsList3[i].MatchType;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Orders = Orders;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].Units = Units;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignTypeId = advProductsList3[i].CampaignTypeId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].MarketPlaceId = advProductsList3[i].MarketPlaceId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].CampaignId = advProductsList3[i].CampaignId;
                    summaryAdvProductsList3[summaryAdvProductsList3.Count - 1].ProductId = advProductsList3[i].ProductId;

                    alreadyUsedProductIds.Add(advProductsList3[i].ProductId);
                }
            }
            advProductsList3.Clear();
            foreach (var t in summaryAdvProductsList3)
            {
                advProductsList3.Add(t);
            }
        }

        /* Открываем форму фильтра */
        private void btn_Filter3_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                btn_Filter3.Text = "<";
            }
            else if (panel7.Visible == false)
            {
                panel7.Visible = true;
                btn_Filter3.Text = ">";
            }
        }
        
        private string GetCompareMode3()
        {
            if (byTargetingInAdGroupsToolStripMenuItem3.Checked)
            {
                return "targetinginadgroups";
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem3.Checked)
            {
                return "adgroupsincampaigns";
            }
            else if (byCampaignInProductsToolStripMenuItem3.Checked)
            {
                return "campaigninproducts";
            }
            else if (byProductsToolStripMenuItem3.Checked)
            {
                return "productsinmarketplaces";
            }
            return "";
        }
        
        private string GetDateMode3()
        {
            if (by_DaysToolStripMenuItem3.Checked)
            {
                return "days";
            }
            else if (by_WeeksToolStripMenuItem3.Checked)
            {
                return "weeks";
            }
            else if (by_MonthsToolStripMenuItem3.Checked)
            {
                return "months";
            }
            else if (by_CustomToolStripMenuItem3.Checked)
            {
                return "custom";
            }
            return "";
        }

        private void byProductsInMarkeplacesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullCompareMode3();
            EnableCustomTimeMode3();
            byProductsToolStripMenuItem3.Checked = true;
        }

        private void byCampaignInProductsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullCompareMode3();
            EnableCustomTimeMode3();
            byCampaignInProductsToolStripMenuItem3.Checked = true;
        }

        private void byAdGroupsInCampaignsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullCompareMode3();
            EnableCustomTimeMode3();
            byAdGroupsInCampaignsToolStripMenuItem3.Checked = true;
        }

        private void byTargetingInAdGroupsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullCompareMode3();
            NullTimeMode3();
            DisableCustomTimeMode3();
            by_CustomToolStripMenuItem3.Checked = true;
            byTargetingInAdGroupsToolStripMenuItem3.Checked = true;
        }

        private void by_CustomToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullTimeMode3();
            by_CustomToolStripMenuItem3.Checked = true;
        }

        private void by_DaysToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullTimeMode3();
            by_DaysToolStripMenuItem3.Checked = true;
        }

        private void by_WeeksToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullTimeMode3();
            by_WeeksToolStripMenuItem3.Checked = true;
        }

        private void by_MonthsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NullTimeMode3();
            by_MonthsToolStripMenuItem3.Checked = true;
        }

        private void DisableCustomTimeMode3()
        {
            by_DaysToolStripMenuItem3.Enabled = false;
            by_WeeksToolStripMenuItem3.Enabled = false;
            by_MonthsToolStripMenuItem3.Enabled = false;
        }

        private void EnableCustomTimeMode3()
        {
            by_DaysToolStripMenuItem3.Enabled = true;
            by_WeeksToolStripMenuItem3.Enabled = true;
            by_MonthsToolStripMenuItem3.Enabled = true;
        }

        private void NullTimeMode3()
        {
            by_DaysToolStripMenuItem3.Checked = false;
            by_WeeksToolStripMenuItem3.Checked = false;
            by_MonthsToolStripMenuItem3.Checked = false;
            by_CustomToolStripMenuItem3.Checked = false;
        }

        private void NullCompareMode3()
        {
            byProductsToolStripMenuItem3.Checked = false;
            byCampaignInProductsToolStripMenuItem3.Checked = false;
            byAdGroupsInCampaignsToolStripMenuItem3.Checked = false;
            byTargetingInAdGroupsToolStripMenuItem3.Checked = false;
        }

        private void ResetCompareModes3()
        {
            targetingInAdgroupsMode3 = false;
            adgroupsInCampaignsMode3 = false;
            campaignInProductsMode3 = false;
            productsInMarketplaces3 = false;
        }

        private void ResetDateModes3()
        {
            byDays3 = false;
            byWeeks3 = false;
            byMonths3 = false;
            byCustom3 = false;
        }

        /* Выделяем/снимаем выделение кампании в clb_Marketplace1 */
        private void clb_Marketplace3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedMarkeplaces3.Clear();
            for (int i = 0; i < clb_Marketplace3.CheckedItems.Count; i++)
            {
                checkedMarkeplaces3.Add(clb_Marketplace3.CheckedItems[i].ToString());
            }

            clb_Product3.Items.Clear();
            checkedProducts3.Clear();

            clb_Campaign3.Items.Clear();
            checkedCampaigns3.Clear();

            clb_AdGroup3.Items.Clear();
            checkedAdGroups3.Clear();

            clb_Targeting3.Items.Clear();
            checkedTargeting3.Clear();

            if (checkedMarkeplaces3.Count > 0)
            {
                int res = 0;

                if (cb_WithInactive1.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames3(checkedMarkeplaces1), 3);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames3(checkedMarkeplaces1), 3);
                }

                if (res == 1)
                {
                    Draw_clb_Products3();
                }
            }
            //else { clb_Product1.Items.Clear(); checkedProducts1.Clear(); }

            disableTbClbFilter3();
        }

        /* Получаем список MarketplaceId по выделенным MarketplaceName1 */
        private List<int> GetMPIdsByNames3(List<string> _checkedMarkeplaces)
        {
            List<int> resultList = new List<int> { };
            for (int i = 0; i < _checkedMarkeplaces.Count; i++)
            {
                for (int j = 0; j < mpList3.Count; j++)
                {
                    if (_checkedMarkeplaces[i].Equals(mpList3[j].MarketPlaceName))
                        resultList.Add(mpList3[j].MarketPlaceId);
                }
            }
            return resultList;
        }

        /* Заносим имена товаров в clb_Products1 */
        private void Draw_clb_Products3()
        {
            List<string> names = new List<string> { };
            List<string> finalNames = new List<string> { };

            if (cb_WithoutAdvertising3.Checked || cb_WithInactive3.Checked)
            {
                for (int i = 0; i < pList3.Count; i++)
                {
                    if (!names.Contains(pList3[i].Name))
                        names.Add(pList3[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < pList3.Count; i++)
                {
                    foreach (var t in AP_campaignIdsListForActiveCheck3)
                    {
                        if (t.Name.Contains(pList3[i].ProdShortName))
                            if (!names.Contains(pList3[i].Name))
                                names.Add(pList3[i].Name);
                    }
                }
            }

            clb_Product3.Items.Clear();
            for (int i = 0; i < names.Count; i++)
            {
                clb_Product3.Items.Add(names[i]);
            }
        }

        private void disableTbClbFilter3()
        {
            if (clb_Targeting3.Items.Count == 0)
            {
                tb_clbTargetingFilter3.Enabled = false;
                tb_clbTargetingFilter3.Text = "";
            }
            if (clb_AdGroup3.Items.Count == 0)
            {
                tb_clbAdGroupFilter3.Enabled = false;
                tb_clbAdGroupFilter3.Text = "";
            }
            if (clb_Campaign3.Items.Count == 0)
            {
                tb_clbCampaignFilter3.Enabled = false;
                tb_clbCampaignFilter3.Text = "";
            }
        }

        /* Отключаем textBox'ы и очищаем их, если clb3 становятся пустыми при изменении галочек cb_WithoutAdvertising3 или cb_WithInactive3 */
        private void disableTbClbFilter3(bool _copying)
        {
            copying = _copying;
            if (clb_Targeting3.Items.Count == 0)
            {
                tb_clbTargetingFilter3.Enabled = false;
                tb_clbTargetingFilter3.Text = "";
            }
            if (clb_AdGroup3.Items.Count == 0)
            {
                tb_clbAdGroupFilter3.Enabled = false;
                tb_clbAdGroupFilter3.Text = "";
            }
            if (clb_Campaign3.Items.Count == 0)
            {
                tb_clbCampaignFilter3.Enabled = false;
                tb_clbCampaignFilter3.Text = "";
            }
            copying = !_copying;
        }

        /* Очистить список выбранных маркетплейсов в clb_Marketplace1 */
        private void btn_Clear_clb_Marketplace3_Click(object sender, EventArgs e)
        {
            checkedMarkeplaces3.Clear();

            clb_Targeting3.Items.Clear();
            checkedTargeting3.Clear();

            clb_AdGroup3.Items.Clear();
            checkedAdGroups3.Clear();

            clb_Campaign3.Items.Clear();
            checkedCampaigns3.Clear();

            clb_Product3.Items.Clear();
            checkedProducts3.Clear();

            for (int i = 0; i < clb_Marketplace3.Items.Count; i++)
            {
                clb_Marketplace3.SetItemChecked(i, false);
            }
            clb_Marketplace3.ClearSelected();

            disableTbClbFilter3();
        }

        /* Отображаем/скрываем товары, у которых нет рекламных кампаний */
        private void cb_WithoutAdvertising3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces3.Count > 0)
            {
                clb_Product3.ClearSelected();
                checkedProducts3.Clear();

                clb_Targeting3.Items.Clear();
                checkedTargeting3.Clear();

                clb_AdGroup3.Items.Clear();
                checkedAdGroups3.Clear();

                clb_Campaign3.Items.Clear();
                checkedCampaigns3.Clear();

                int res = 0;
                if (cb_WithInactive3.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames3(checkedMarkeplaces3), 3);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames3(checkedMarkeplaces3), 3);
                }

                if (res == 1)
                {
                    Draw_clb_Products3();
                }
                
                disableTbClbFilter3(true);
            }
        }

        /* Меняем режим отображения с активными/неактивными товарами tab1 */
        private void cb_WithInactive3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces3.Count > 0)
            {
                clb_Product3.ClearSelected();
                checkedProducts3.Clear();

                clb_Targeting3.Items.Clear();
                checkedTargeting3.Clear();

                clb_AdGroup3.Items.Clear();
                checkedAdGroups3.Clear();

                clb_Campaign3.Items.Clear();
                checkedCampaigns3.Clear();

                int res = 0;

                if (cb_WithInactive3.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames3(checkedMarkeplaces3), 3);
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames3(checkedMarkeplaces3), 3);
                }

                if (res == 1)
                {
                    Draw_clb_Products3();
                }

                disableTbClbFilter3(true);
            }
        }

        /* Заносим имена кампаний в clb_AdGroups1 */
        private void Draw_clb_AdGroups3()
        {
            clb_AdGroup3.Items.Clear();
            for (int i = 0; i < uniqueAdGroups3.Count; i++)
            {
                clb_AdGroup3.Items.Add(uniqueAdGroups3[i]);
                if (checkedAdGroups3.Contains(uniqueAdGroups3[i]))
                {
                    clb_AdGroup3.SetItemChecked(clb_AdGroup3.Items.Count - 1, true);
                    checkedAdGroupsTMP3.Add(uniqueAdGroups3[i]);
                }
            }

            checkedAdGroups3.Clear();

            foreach (var t in checkedAdGroupsTMP3)
            {
                checkedAdGroups3.Add(t);
            }
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueAdGroups3(List<string> _finalAdGroupList)
        {
            tbAdGroupsFilterItemsPrev3.Clear();
            uniqueAdGroups3 = new List<string> { };
            for (int i = 0; i < _finalAdGroupList.Count; i++)
            {
                if (!uniqueAdGroups3.Contains(_finalAdGroupList[i]))
                {
                    uniqueAdGroups3.Add(_finalAdGroupList[i]);
                    tbAdGroupsFilterItemsPrev3.Add(uniqueAdGroups3[uniqueAdGroups3.Count - 1]);
                }
            }
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName3(List<string> _checkedProducts)
        {
            if (checkedProducts3.Count > 0)
                for (int i = 0; i < pList3.Count; i++)
                {
                    if (pList3[i].Name.Equals(checkedProducts3[0]))
                        return pList3[i].ProductId;
                }
            return -1;
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName3(string _checkedProduct)
        {
            if (checkedProducts3.Count > 0)
                for (int i = 0; i < pList3.Count; i++)
                {
                    if (pList3[i].Name.Equals(_checkedProduct))
                        return pList3[i].ProductId;
                }
            return -1;
        }

        /* Выделяем/снимаем выделение кампании в clb_Campaign1 */
        private void clb_Campaign3_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_clb_Campaign3_SelectedIndexChanged();
        }

        private void method_clb_Campaign3_SelectedIndexChanged()
        {
            checkedCampaignsTMP3.Clear();
            for (int i = 0; i < clb_Campaign3.CheckedItems.Count; i++)
            {
                checkedCampaignsTMP3.Add(clb_Campaign3.CheckedItems[i].ToString());
            }

            checkedCampaigns3.Clear();

            foreach (var t in checkedCampaignsTMP3)
            {
                checkedCampaigns3.Add(t);
            }

            List<string> finalAdGroupList = new List<string> { };
            int res = 0;
            int prodId = -1;
            if (checkedCampaigns3.Count > 0)
            {
                for (int i = 0; i < checkedProducts3.Count; i++)
                {
                    prodId = GetProductIdByName3(checkedProducts3[i]);
                    for (int j = 0; j < checkedCampaigns3.Count; j++)
                    {
                        res = advertController.GetAdvertisingProductsAdgroups(prodId, checkedCampaigns3[j], 3);
                        if (res == 1)
                        {
                            for (int t = 0; t < AdGroupsList3.Count; t++)
                            {
                                AdGroupsList3[t] = AdGroupsList3[t] + " (" + checkedCampaigns3[j] + ")";
                                finalAdGroupList.Add(AdGroupsList3[t]);
                            }
                        }
                    }
                }

                GetUniqueAdGroups3(finalAdGroupList);

                if (res == 1)
                {
                    Draw_clb_AdGroups3();
                }
            }
            else
            {
                clb_AdGroup3.Items.Clear();
                checkedAdGroups3.Clear();

                clb_Targeting3.Items.Clear();
                checkedTargeting3.Clear();
            }


            if (clb_AdGroup3.Items.Count > 0)
                tb_clbAdGroupFilter3.Enabled = true;
            else
                tb_clbAdGroupFilter3.Enabled = false;

            disableTbClbFilter3();
        }

        /* Очистить список выбранных кампаний в clb_Campaigns1 */
        private void btn_Clear_clb_Campaigns3_Click(object sender, EventArgs e)
        {
            checkedCampaigns3.Clear();

            clb_Targeting3.Items.Clear();
            checkedTargeting3.Clear();

            clb_AdGroup3.Items.Clear();
            checkedAdGroups3.Clear();

            for (int i = 0; i < clb_Campaign3.Items.Count; i++)
            {
                clb_Campaign3.SetItemChecked(i, false);
            }
            clb_Campaign3.ClearSelected();

            disableTbClbFilter3();
        }

        /* Выделяем/снимаем выделение кампании в clb_AdGroup1 */
        private void clb_AdGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_clb_AdGroup3_SelectedIndexChanged();
        }

        private void method_clb_AdGroup3_SelectedIndexChanged()
        {
            checkedAdGroupsTMP3.Clear();
            for (int i = 0; i < clb_AdGroup3.CheckedItems.Count; i++)
            {
                checkedAdGroupsTMP3.Add(clb_AdGroup3.CheckedItems[i].ToString());
            }

            checkedAdGroups3.Clear();

            foreach (var t in checkedAdGroupsTMP3)
            {
                checkedAdGroups3.Add(t);
            }

            List<string> finalTargetingList = new List<string> { };
            int res = 0;
            int prodId = -1;

            if (checkedAdGroups3.Count > 0)
            {
                for (int i = 0; i < checkedProducts3.Count; i++)
                {
                    prodId = GetProductIdByName3(checkedProducts3[i]);
                    for (int j = 0; j < checkedCampaigns3.Count; j++)
                    {
                        for (int k = 0; k < checkedAdGroups3.Count; k++)
                        {
                            res = advertController.GetAdvertisingProductsTargeting(prodId, checkedCampaigns3[j], ResetNameInCheckedAdGroups(checkedAdGroups3[k]), 3);
                            if (res == 1)
                            {
                                for (int t = 0; t < targetingList3.Count; t++)
                                {
                                    targetingList3[t] = targetingList3[t] + " (" + checkedAdGroups3[k] + ")";
                                    finalTargetingList.Add(targetingList3[t]);
                                }
                            }
                        }
                    }
                }

                GetUniqueTargeting3(finalTargetingList);

                if (res == 1)
                {
                    Draw_clb_Targeting3();
                }
            }
            else
            {
                clb_Targeting3.Items.Clear();
                checkedTargeting3.Clear();
            }

            if (clb_Targeting3.Items.Count > 0)
                tb_clbTargetingFilter3.Enabled = true;
            else
                tb_clbTargetingFilter3.Enabled = false;

            disableTbClbFilter3();
        }
        /* Заносим имена кампаний в clb_Targeting1 */
        private void Draw_clb_Targeting3()
        {
            clb_Targeting3.Items.Clear();
            for (int i = 0; i < uniqueTargeting3.Count; i++)
            {
                clb_Targeting3.Items.Add(uniqueTargeting3[i]);
                if (checkedTargeting3.Contains(uniqueTargeting3[i]))
                {
                    clb_Targeting3.SetItemChecked(clb_Targeting3.Items.Count - 1, true);
                    checkedTargetingTMP3.Add(uniqueTargeting3[i]);
                }
            }

            checkedTargeting3.Clear();

            foreach (var t in checkedTargetingTMP3)
            {
                checkedTargeting3.Add(t);
            }
        }

        /* Получаем уникальные названия ключей */
        private void GetUniqueTargeting3(List<string> _finalTargetingList)
        {
            tbTargetingFilterItemsPrev3.Clear();
            uniqueTargeting3 = new List<string> { };
            for (int i = 0; i < _finalTargetingList.Count; i++)
            {
                if (!uniqueTargeting3.Contains(_finalTargetingList[i]))
                {
                    uniqueTargeting3.Add(_finalTargetingList[i]);
                    tbTargetingFilterItemsPrev3.Add(uniqueTargeting3[uniqueTargeting3.Count - 1]);
                }
            }
        }

        /* Выделяем/снимаем выделение кампании в clb_Targeting3 */
        private void clb_Targeting3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedTargeting3.Clear();
            for (int i = 0; i < clb_Targeting3.CheckedItems.Count; i++)
            {
                checkedTargeting3.Add(clb_Targeting3.CheckedItems[i].ToString());
            }

            disableTbClbFilter3();
        }

        /* Очистить список выбранных кампаний в clb_Targeting3 */
        private void btn_Clear_clb_Targeting3_Click(object sender, EventArgs e)
        {
            checkedTargeting3.Clear();

            for (int i = 0; i < clb_Targeting3.Items.Count; i++)
            {
                clb_Targeting3.SetItemChecked(i, false);
            }
            clb_Targeting3.ClearSelected();

            disableTbClbFilter3();
        }

        /* Очистить список выбранных кампаний в clb_AdGroup3 */
        private void btn_Clear_clb_AdGroups3_Click(object sender, EventArgs e)
        {
            checkedAdGroups3.Clear();

            clb_Targeting3.Items.Clear();
            checkedTargeting3.Clear();

            for (int i = 0; i < clb_AdGroup3.Items.Count; i++)
            {
                clb_AdGroup3.SetItemChecked(i, false);
            }
            clb_AdGroup3.ClearSelected();

            disableTbClbFilter3();
        }

        /* Ищем значения в clb_Campaign3 по вхождению текста из tb_clbCampaignFilter3 (ищем Campaigns по вводу пользователем) */
        private void tb_clbCampaignFilter3_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbCampaignsFilterItems3.Clear();
                string text = tb_clbCampaignFilter3.Text.ToLower();

                for (int i = 0; i < tbCampaignsFilterItemsPrev3.Count; i++)
                {
                    if (tbCampaignsFilterItemsPrev3[i].ToLower().Contains(text))
                        tbCampaignsFilterItems3.Add(tbCampaignsFilterItemsPrev3[i]);
                }

                clb_Campaign3.Items.Clear();

                for (int i = 0; i < tbCampaignsFilterItems3.Count; i++)
                {
                    clb_Campaign3.Items.Add(tbCampaignsFilterItems3[i]);
                    if (checkedCampaigns3.Contains(tbCampaignsFilterItems3[i]))
                        clb_Campaign3.SetItemChecked(clb_Campaign3.Items.Count - 1, true);
                }
            }
        }

        /* Ищем значения в clb_AdGroup3 по вхождению текста из tb_clbAdGroupFilter3 (ищем AdGroups по вводу пользователем) */
        private void tb_clbAdGroupFilter3_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbAdGroupsFilterItems3.Clear();
                string text = tb_clbAdGroupFilter3.Text.ToLower();

                for (int i = 0; i < tbAdGroupsFilterItemsPrev3.Count; i++)
                {
                    if (tbAdGroupsFilterItemsPrev3[i].ToLower().Contains(text))
                        tbAdGroupsFilterItems3.Add(tbAdGroupsFilterItemsPrev3[i]);
                }

                clb_AdGroup3.Items.Clear();

                for (int i = 0; i < tbAdGroupsFilterItems3.Count; i++)
                {
                    clb_AdGroup3.Items.Add(tbAdGroupsFilterItems3[i]);
                    if (checkedAdGroups3.Contains(tbAdGroupsFilterItems3[i]))
                        clb_AdGroup3.SetItemChecked(clb_AdGroup3.Items.Count - 1, true);
                }
            }
        }

        /* Ищем значения в clb_Targeting3 по вхождению текста из tb_clbTargetingFilter3 (ищем Targetings по вводу пользователем) */
        private void tb_clbTargetingFilter3_TextChanged(object sender, EventArgs e)
        {
            if (!copying)
            {
                tbTargetingFilterItems3.Clear();
                string text = tb_clbTargetingFilter3.Text.ToLower();

                for (int i = 0; i < tbTargetingFilterItemsPrev3.Count; i++)
                {
                    if (tbTargetingFilterItemsPrev3[i].ToLower().Contains(text))
                        tbTargetingFilterItems3.Add(tbTargetingFilterItemsPrev3[i]);
                }

                clb_Targeting3.Items.Clear();

                for (int i = 0; i < tbTargetingFilterItems3.Count; i++)
                {
                    clb_Targeting3.Items.Add(tbTargetingFilterItems3[i]);
                    if (checkedTargeting3.Contains(tbTargetingFilterItems3[i]))
                        clb_Targeting3.SetItemChecked(clb_Targeting3.Items.Count - 1, true);
                }
            }
        }

        /* Скрываем форму по нажатию ЛКМ по любому месту на dgv_AdvertisingProducts */
        private void dgv_AdvProducts3_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                btn_Filter3.Text = "<";
            }
        }

        /* Скрываем форму по нажатию ЛКМ по любому месту во вкладке */
        private void tabPage3_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                btn_Filter3.Text = "<";
            }
        }

        /* Изменяем дату начала в календаре 3 */
        private void mc_StartDate3_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate3 = mc_StartDate3.SelectionStart;
            label23.Text = mc_StartDate3.SelectionStart.ToShortDateString();
        }

        /* Изменяем дату окончания в календаре 3 */
        private void mc_EndDate3_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate3 = mc_EndDate3.SelectionEnd;
            label22.Text = mc_EndDate3.SelectionStart.ToShortDateString();
        }

        /* Выделяем/снимаем выделение товара в clb_Product3 */
        private void clb_Product3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedProductsTMP3.Clear();
            for (int i = 0; i < clb_Product3.CheckedItems.Count; i++)
            {
                checkedProductsTMP3.Add(clb_Product3.CheckedItems[i].ToString());
            }

            checkedProducts3.Clear();

            foreach (var t in checkedProductsTMP3)
            {
                checkedProducts3.Add(t);
            }

            int res = 0;

            if (checkedProducts3.Count > 0)
            {
                res = advertController.GetAdvertisingProductsCampaignAndCampId3(GetProductIdsByNames3(checkedProducts3));
                GetUniqueCampaigns3();
            }
            else
            {
                clb_Campaign3.Items.Clear();
                checkedCampaigns3.Clear();

                clb_AdGroup3.Items.Clear();
                checkedAdGroups3.Clear();

                clb_Targeting3.Items.Clear();
                checkedTargeting3.Clear();
            }


            if (res == 1)
            {
                Draw_clb_Campaigns3();
            }

            if (clb_Campaign3.Items.Count > 0)
                tb_clbCampaignFilter3.Enabled = true;
            else
                tb_clbCampaignFilter3.Enabled = false;

            disableTbClbFilter3();
        }

        /* Очистить список выбранных товаров в clb_Products3 */
        private void btn_Clear_clb_Products3_Click(object sender, EventArgs e)
        {
            checkedProducts3.Clear();

            clb_Targeting3.Items.Clear();
            checkedTargeting3.Clear();

            clb_AdGroup3.Items.Clear();
            checkedAdGroups3.Clear();

            clb_Campaign3.Items.Clear();
            checkedCampaigns3.Clear();

            for (int i = 0; i < clb_Product3.Items.Count; i++)
            {
                clb_Product3.SetItemChecked(i, false);
            }
            clb_Product3.ClearSelected();

            disableTbClbFilter3();
        }

        /* Заносим имена кампаний в clb_Campaigns3 */
        private void Draw_clb_Campaigns3()
        {
            clb_Campaign3.Items.Clear();
            checkedCampaignsTMP3.Clear();
            for (int i = 0; i < uniqueCampaigns3.Count; i++)
            {
                clb_Campaign3.Items.Add(uniqueCampaigns3[i]);
                if (checkedCampaigns3.Contains(uniqueCampaigns3[i]))
                {
                    clb_Campaign3.SetItemChecked(clb_Campaign3.Items.Count - 1, true);
                    checkedCampaignsTMP3.Add(uniqueCampaigns3[i]);
                }
            }

            checkedCampaigns3.Clear();

            foreach (var t in checkedCampaignsTMP3)
            {
                checkedCampaigns3.Add(t);
            }

            if (checkedCampaigns3.Count == 0)
            {
                clb_AdGroup3.Items.Clear();
                checkedAdGroups3.Clear();
            }
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueCampaigns3()
        {
            uniqueCampaigns3 = new List<string> { };
            tbCampaignsFilterItemsPrev3 = new List<string> { };

            for (int i = 0; i < campsidsList3.Count; i++)
            {
                if (!uniqueCampaigns3.Contains(campsidsList3[i].Key))
                {
                    uniqueCampaigns3.Add(campsidsList3[i].Key);
                    tbCampaignsFilterItemsPrev3.Add(uniqueCampaigns3[uniqueCampaigns3.Count - 1]);
                }
            }
        }

        /* Получаем список ProductId по выделенным ProductName */
        private List<int> GetProductIdsByNames3(List<string> _checkedProducts)
        {
            bool flag = false;
            List<int> resultList = new List<int> { };
            List<int> resultList1 = new List<int> { };
            for (int i = 0; i < _checkedProducts.Count; i++)
            {
                flag = false;
                for (int j = 0; j < pList3.Count; j++)
                {
                    if (!flag && _checkedProducts[i].Equals(pList3[j].Name))
                    {
                        resultList.Add(pList3[j].ProductId);
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

        private string GetFirstAdGroup3()
        {
            if (checkedAdGroups3.Count > 0)
            {
                return checkedAdGroups3[0];
            }
            else
            {
                if (clb_AdGroup3.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите рекламную кампанию!", "Ошибка");
                else
                {
                    return clb_AdGroup3.Items[0].ToString();
                }
            }
            return "";
        }
        private string GetFirstCampaign3()
        {
            if (checkedCampaigns3.Count > 0)
            {
                return checkedCampaigns3[0];
            }
            else
            {
                if (clb_Campaign3.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите товар!", "Ошибка");
                else
                {
                    return clb_Campaign3.Items[0].ToString();
                }
            }
            return "";
        }

        private bool CheckForExistingProducts3()
        {
            if (clb_Product3.Items.Count == 0)
                MessageBox.Show("Для продолжения выберите маркетплейс!", "Ошибка");
            else if (checkedProducts3.Count > 0 || clb_Product3.Items.Count > 0)
                return true;
            return false;
        }

        private string GetProductsAsins3()
        {
            string result = "";
            string name = "";
            string asin = "";

            if (checkedProducts3.Count > 0)
            {
                name = checkedProducts3[0];
            }
            else
            {
                name = clb_Product3.Items[0].ToString();
            }

            for (int i = 0; i < pList3.Count; i++)
            {
                if (pList3[i].Name.Equals(name))
                    asin = pList3[i].ASIN;
            }
            for (int i = 0; i < pList3.Count; i++)
            {
                if (pList3[i].ASIN.Equals(asin))
                    result = result + pList3[i].ProductId + ", ";
            }

            return result;
        }

        /* Получаем список CampaignId по выделенным Campaign1 */
        private List<int> GetCampaignIdsByNames3(List<CmapaignAndIdStruct> _campsidsList)
        {
            List<int> resultList = new List<int> { };
            List<CmapaignAndIdStruct> test = new List<CmapaignAndIdStruct> { };
            bool flag = false;

            for (int i = 0; i < checkedCampaigns3.Count; i++)
            {
                flag = false;
                for (int j = 0; j < campsidsList3.Count; j++)
                {
                    if (!flag && checkedCampaigns3[i].Equals(campsidsList3[j].Key))
                    {
                        resultList.Add(campsidsList3[j].Val);
                        flag = true;
                    }
                }
            }
            return resultList;
        }

        /* Применяем фильтры и перерисовываем данные в таблице */
        private void btn_Show3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            if (StartDate3 > EndDate3)
                MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

            int result = 0;
            advProductsList3 = null;


            if (byTargetingInAdGroupsToolStripMenuItem3.Checked)
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate3, EndDate3, GetMPIdsByNames3(checkedMarkeplaces3), GetProductIdsByNames3(checkedProducts3), GetCampaignIdsByNames3(campsidsList3), ResetNamesInCheckedAdGroups(checkedAdGroups3), ResetNamesInCheckedTargeting(checkedTargeting3), 3);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow3(advProductsList3, advProductsListOriginal3, GetCompareMode3(), pList3, GetDateMode3(), "", GetProductIdByName3(checkedProducts3));
                    filterAdvProductsList3 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem3.Checked && !GetFirstAdGroup3().Equals(""))
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate3, EndDate3, GetMPIdsByNames3(checkedMarkeplaces3), GetProductIdsByNames3(checkedProducts3), GetCampaignIdsByNames3(campsidsList3), ResetNamesInCheckedAdGroups(checkedAdGroups3), new List<string> { }, 3);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow3(advProductsList3, advProductsListOriginal3, GetCompareMode3(), pList3, GetDateMode3(), GetFirstAdGroup3(), GetProductIdByName3(checkedProducts3));
                    filterAdvProductsList3 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byCampaignInProductsToolStripMenuItem3.Checked && !GetFirstCampaign3().Equals(""))
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate3, EndDate3, GetMPIdsByNames3(checkedMarkeplaces3), GetProductIdsByNames3(checkedProducts3), GetCampaignIdsByNames3(campsidsList3), new List<string> { }, new List<string> { }, 3);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow3(advProductsList3, advProductsListOriginal3, GetCompareMode3(), pList3, GetDateMode3(), GetFirstCampaign3(), GetProductIdByName3(checkedProducts3));
                    filterAdvProductsList3 = new List<AdvertisingProductsModel> { };
                }
            }
            else if (byProductsToolStripMenuItem3.Checked && CheckForExistingProducts3())
            {
                result = advertController.GetFinalAdvertisingProductsReport(StartDate3, EndDate3, GetMPIdsByNames3(checkedMarkeplaces3), GetProductIdsByNames3(checkedProducts3), new List<int> { }, new List<string> { }, new List<string> { }, 3);

                if (result == 1)
                {
                    GetAdvertisingProductsListToShow3(advProductsList3, advProductsListOriginal3, GetCompareMode3(), pList3, GetDateMode3(), GetProductsAsins3(), GetProductIdByName3(checkedProducts3));
                    filterAdvProductsList3 = new List<AdvertisingProductsModel> { };
                }
            }

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        /* Получаем список advProductsList1 и рисуем его в таблице dgv_AdvProducts3 */
        public void GetAdvertisingProductsListToShow3(object _advProductsList, object _advProductsListOriginal, string _compareMode, object _pList, string _dateMode, string _object, int _prodId)
        {
            advProductsList3 = (List<AdvertisingProductsModel>)_advProductsList;
            advProductsListOriginal3 = (List<AdvertisingProductsModel>)_advProductsListOriginal;

            lb_StartDate3.Text = label23.Text;
            lb_EndDate3.Text = label22.Text;

            if (_compareMode.Equals("targetinginadgroups"))
            {
                ResetCompareModes3();
                targetingInAdgroupsMode3 = true;
            }
            else if (_compareMode.Equals("adgroupsincampaigns"))
            {
                ResetCompareModes3();
                adgroupsInCampaignsMode3 = true;
                this.Text = "По группам";
            }
            else if (_compareMode.Equals("campaigninproducts"))
            {
                ResetCompareModes3();
                campaignInProductsMode3 = true;
                this.Text = "По кампаниям";
            }
            else if (_compareMode.Equals("productsinmarketplaces"))
            {
                ResetCompareModes3();
                productsInMarketplaces3 = true;
                this.Text = "По товарам";
            }

            if (_dateMode.Equals("days"))
            {
                ResetDateModes3();
                byDays3 = true;
            }
            else if (_dateMode.Equals("weeks"))
            {
                ResetDateModes3();
                byWeeks3 = true;
            }
            else if (_dateMode.Equals("months"))
            {
                ResetDateModes3();
                byMonths3 = true;
            }
            else if (_dateMode.Equals("custom"))
            {
                ResetDateModes3();
                byCustom3 = true;
            }

            pList3 = (List<ProductsModel>)_pList;

            if (byCustom3)
                DrawTableForSponsoredProducts(advProductsList3, dgv_AdvProducts3, pList3, targetingInAdgroupsMode3, adgroupsInCampaignsMode3, campaignInProductsMode3, productsInMarketplaces3);
            else if (byMonths3)
            {
                int timeSpan = ((EndDate3 - StartDate3).Days + 1) / 31;
                if (adgroupsInCampaignsMode3)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "months", _prodId, dgv_AdvProducts3, EndDate3, advProductsList3);
                }
                else if (campaignInProductsMode3)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "months", _prodId, dgv_AdvProducts3, EndDate3, advProductsList3);
                }
                else if (productsInMarketplaces3)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "months", dgv_AdvProducts3, pList3, EndDate3, advProductsList3);
                }

                DrawLastColumn(dgv_AdvProducts3);
            }
            else if (byWeeks3)
            {
                int timeSpan = ((EndDate3 - StartDate3).Days + 1) / 7;
                if (adgroupsInCampaignsMode3)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "weeks", _prodId, dgv_AdvProducts3, EndDate3, advProductsList3);
                }
                else if (campaignInProductsMode3)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "weeks", _prodId, dgv_AdvProducts3, EndDate3, advProductsList3);
                }
                else if (productsInMarketplaces3)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "weeks", dgv_AdvProducts3, pList3, EndDate3, advProductsList3);
                }

                DrawLastColumn(dgv_AdvProducts3);
            }
            else if (byDays3)
            {
                int timeSpan = (EndDate3 - StartDate3).Days + 1;
                if (adgroupsInCampaignsMode3)
                {
                    DrawTableForAdGroupsInCampaignsMode(_object, timeSpan, "days", _prodId, dgv_AdvProducts3, EndDate3, advProductsList3);
                }
                else if (campaignInProductsMode3)
                {
                    DrawTableForCampaignInProductsMode(_object, timeSpan, "days", _prodId, dgv_AdvProducts3, EndDate3, advProductsList3);
                }
                else if (productsInMarketplaces3)
                {
                    DrawTableForProductsInMarketplacesMode(_object, timeSpan, "days", dgv_AdvProducts3, pList3, EndDate3, advProductsList3);
                }

                DrawLastColumn(dgv_AdvProducts3);
            }
        }

        /* Быстрое копирование параметров всех фильтров и настроек с Окно 3 в Окно 1 */
        private void copyToTab1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CopyMethod3to1();
        }

        /* Быстрое копирование параметров всех фильтров и настроек с Окно 3 в Окно 2 */
        private void copyToTab2ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CopyMethod3to2();
        }

        /* Метод копирования параметров всех фильтров и настроек с Окно 3 в Окно 1 */
        private void CopyMethod3to1()
        {
            copying = true;
            byProductsToolStripMenuItem1.Checked = byProductsToolStripMenuItem3.Checked;
            byCampaignInProductsToolStripMenuItem1.Checked = byCampaignInProductsToolStripMenuItem3.Checked;
            byAdGroupsInCampaignsToolStripMenuItem1.Checked = byAdGroupsInCampaignsToolStripMenuItem3.Checked;
            byTargetingInAdGroupsToolStripMenuItem1.Checked = byTargetingInAdGroupsToolStripMenuItem3.Checked;

            by_DaysToolStripMenuItem1.Checked = by_DaysToolStripMenuItem3.Checked;
            by_WeeksToolStripMenuItem1.Checked = by_WeeksToolStripMenuItem3.Checked;
            by_MonthsToolStripMenuItem1.Checked = by_MonthsToolStripMenuItem3.Checked;
            by_CustomToolStripMenuItem1.Checked = by_CustomToolStripMenuItem3.Checked;

            cb_WithoutAdvertising1.Checked = cb_WithoutAdvertising3.Checked;
            cb_WithInactive1.Checked = cb_WithInactive3.Checked;

            mc_StartDate1.SelectionStart = mc_StartDate3.SelectionStart;
            mc_EndDate1.SelectionStart = mc_EndDate3.SelectionStart;

            label3.Text = label23.Text;
            label2.Text = label22.Text;

            StartDate1 = StartDate3;
            EndDate1 = EndDate3;


            pList1 = new List<ProductsModel> { };
            foreach (var t in pList3) { pList1.Add(t); }

            campsidsList1 = new List<CmapaignAndIdStruct> { };
            foreach (var t in campsidsList3) { campsidsList1.Add(t); }

            checkedMarkeplaces1.Clear();
            foreach (var t in checkedMarkeplaces3) { checkedMarkeplaces1.Add(t); }

            checkedProducts1.Clear();
            foreach (var t in checkedProducts3) { checkedProducts1.Add(t); }

            checkedCampaigns1.Clear();
            foreach (var t in checkedCampaigns3) { checkedCampaigns1.Add(t); }

            checkedAdGroups1.Clear();
            foreach (var t in checkedAdGroups3) { checkedAdGroups1.Add(t); }

            checkedTargeting1.Clear();
            foreach (var t in checkedTargeting3) { checkedTargeting1.Add(t); }

            clb_Marketplace1.Items.Clear();
            foreach (var t in clb_Marketplace3.Items) { clb_Marketplace1.Items.Add(t); }

            clb_Product1.Items.Clear();
            foreach (var t in clb_Product3.Items) { clb_Product1.Items.Add(t); }

            clb_Campaign1.Items.Clear();
            foreach (var t in clb_Campaign3.Items) { clb_Campaign1.Items.Add(t); }

            clb_AdGroup1.Items.Clear();
            foreach (var t in clb_AdGroup3.Items) { clb_AdGroup1.Items.Add(t); }

            clb_Targeting1.Items.Clear();
            foreach (var t in clb_Targeting3.Items) { clb_Targeting1.Items.Add(t); }


            checkedMarkeplacesTMP1.Clear();
            foreach (var t in checkedMarkeplacesTMP3) { checkedMarkeplacesTMP1.Add(t); }
            checkedProductsTMP1.Clear();
            foreach (var t in checkedProductsTMP3) { checkedProductsTMP1.Add(t); }
            checkedCampaignsTMP1.Clear();
            foreach (var t in checkedCampaignsTMP3) { checkedCampaignsTMP1.Add(t); }
            checkedAdGroupsTMP1.Clear();
            foreach (var t in checkedAdGroupsTMP3) { checkedAdGroupsTMP1.Add(t); }
            checkedTargetingTMP1.Clear();
            foreach (var t in checkedTargetingTMP3) { checkedTargetingTMP1.Add(t); }


            for (int i = 0; i < clb_Marketplace1.Items.Count; i++)
            {
                if (checkedMarkeplaces1.Contains(clb_Marketplace1.Items[i].ToString()))
                    clb_Marketplace1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Product1.Items.Count; i++)
            {
                if (checkedProducts1.Contains(clb_Product1.Items[i].ToString()))
                    clb_Product1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Campaign1.Items.Count; i++)
            {
                if (checkedCampaigns1.Contains(clb_Campaign1.Items[i].ToString()))
                    clb_Campaign1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_AdGroup1.Items.Count; i++)
            {
                if (checkedAdGroups1.Contains(clb_AdGroup1.Items[i].ToString()))
                    clb_AdGroup1.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Targeting1.Items.Count; i++)
            {
                if (checkedTargeting1.Contains(clb_Targeting1.Items[i].ToString()))
                    clb_Targeting1.SetItemChecked(i, true);
            }

            tb_clbCampaignFilter1.Text = tb_clbCampaignFilter3.Text;
            tb_clbCampaignFilter1.Enabled = tb_clbCampaignFilter3.Enabled;

            tb_clbAdGroupFilter1.Text = tb_clbAdGroupFilter3.Text;
            tb_clbAdGroupFilter1.Enabled = tb_clbAdGroupFilter3.Enabled;

            tb_clbTargetingFilter1.Text = tb_clbTargetingFilter3.Text;
            tb_clbTargetingFilter1.Enabled = tb_clbTargetingFilter3.Enabled;


            tbCampaignsFilterItems1.Clear();
            foreach (var t in tbCampaignsFilterItems3) { tbCampaignsFilterItems1.Add(t); }
            tbCampaignsFilterItemsPrev1.Clear();
            foreach (var t in tbCampaignsFilterItemsPrev3) { tbCampaignsFilterItemsPrev1.Add(t); }

            tbAdGroupsFilterItems1.Clear();
            foreach (var t in tbAdGroupsFilterItems3) { tbAdGroupsFilterItems1.Add(t); }
            tbAdGroupsFilterItemsPrev1.Clear();
            foreach (var t in tbAdGroupsFilterItemsPrev3) { tbAdGroupsFilterItemsPrev1.Add(t); }

            tbTargetingFilterItems1.Clear();
            foreach (var t in tbTargetingFilterItems3) { tbTargetingFilterItems1.Add(t); }
            tbTargetingFilterItemsPrev1.Clear();
            foreach (var t in tbTargetingFilterItemsPrev3) { tbTargetingFilterItemsPrev1.Add(t); }


            panel2.Visible = true;
            btn_Filter1.Text = ">";
            copying = false;
        }

        /* Метод копирования параметров всех фильтров и настроек с Окно 3 в Окно 2 */
        private void CopyMethod3to2()
        {
            copying = true;
            byProductsToolStripMenuItem2.Checked = byProductsToolStripMenuItem3.Checked;
            byCampaignInProductsToolStripMenuItem2.Checked = byCampaignInProductsToolStripMenuItem3.Checked;
            byAdGroupsInCampaignsToolStripMenuItem2.Checked = byAdGroupsInCampaignsToolStripMenuItem3.Checked;
            byTargetingInAdGroupsToolStripMenuItem2.Checked = byTargetingInAdGroupsToolStripMenuItem3.Checked;

            by_DaysToolStripMenuItem2.Checked = by_DaysToolStripMenuItem3.Checked;
            by_WeeksToolStripMenuItem2.Checked = by_WeeksToolStripMenuItem3.Checked;
            by_MonthsToolStripMenuItem2.Checked = by_MonthsToolStripMenuItem3.Checked;
            by_CustomToolStripMenuItem2.Checked = by_CustomToolStripMenuItem3.Checked;

            cb_WithoutAdvertising2.Checked = cb_WithoutAdvertising3.Checked;
            cb_WithInactive2.Checked = cb_WithInactive3.Checked;

            mc_StartDate2.SelectionStart = mc_StartDate3.SelectionStart;
            mc_EndDate2.SelectionStart = mc_EndDate3.SelectionStart;

            label10.Text = label23.Text;
            label9.Text = label22.Text;

            StartDate2 = StartDate3;
            EndDate2 = EndDate3;


            pList2 = new List<ProductsModel> { };
            foreach (var t in pList3) { pList2.Add(t); }

            campsidsList2 = new List<CmapaignAndIdStruct> { };
            foreach (var t in campsidsList3) { campsidsList2.Add(t); }

            checkedMarkeplaces2.Clear();
            foreach (var t in checkedMarkeplaces3) { checkedMarkeplaces2.Add(t); }

            checkedProducts2.Clear();
            foreach (var t in checkedProducts3) { checkedProducts2.Add(t); }

            checkedCampaigns2.Clear();
            foreach (var t in checkedCampaigns3) { checkedCampaigns2.Add(t); }

            checkedAdGroups2.Clear();
            foreach (var t in checkedAdGroups3) { checkedAdGroups2.Add(t); }

            checkedTargeting2.Clear();
            foreach (var t in checkedTargeting3) { checkedTargeting2.Add(t); }

            clb_Marketplace2.Items.Clear();
            foreach (var t in clb_Marketplace3.Items) { clb_Marketplace2.Items.Add(t); }

            clb_Product2.Items.Clear();
            foreach (var t in clb_Product3.Items) { clb_Product2.Items.Add(t); }

            clb_Campaign2.Items.Clear();
            foreach (var t in clb_Campaign3.Items) { clb_Campaign2.Items.Add(t); }

            clb_AdGroup2.Items.Clear();
            foreach (var t in clb_AdGroup3.Items) { clb_AdGroup2.Items.Add(t); }

            clb_Targeting2.Items.Clear();
            foreach (var t in clb_Targeting3.Items) { clb_Targeting2.Items.Add(t); }


            checkedMarkeplacesTMP2.Clear();
            foreach (var t in checkedMarkeplacesTMP3) { checkedMarkeplacesTMP2.Add(t); }
            checkedProductsTMP2.Clear();
            foreach (var t in checkedProductsTMP3) { checkedProductsTMP2.Add(t); }
            checkedCampaignsTMP2.Clear();
            foreach (var t in checkedCampaignsTMP3) { checkedCampaignsTMP2.Add(t); }
            checkedAdGroupsTMP2.Clear();
            foreach (var t in checkedAdGroupsTMP3) { checkedAdGroupsTMP2.Add(t); }
            checkedTargetingTMP2.Clear();
            foreach (var t in checkedTargetingTMP3) { checkedTargetingTMP2.Add(t); }


            for (int i = 0; i < clb_Marketplace2.Items.Count; i++)
            {
                if (checkedMarkeplaces2.Contains(clb_Marketplace2.Items[i].ToString()))
                    clb_Marketplace2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Product2.Items.Count; i++)
            {
                if (checkedProducts2.Contains(clb_Product2.Items[i].ToString()))
                    clb_Product2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Campaign2.Items.Count; i++)
            {
                if (checkedCampaigns2.Contains(clb_Campaign2.Items[i].ToString()))
                    clb_Campaign2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_AdGroup2.Items.Count; i++)
            {
                if (checkedAdGroups2.Contains(clb_AdGroup2.Items[i].ToString()))
                    clb_AdGroup2.SetItemChecked(i, true);
            }

            for (int i = 0; i < clb_Targeting2.Items.Count; i++)
            {
                if (checkedTargeting2.Contains(clb_Targeting2.Items[i].ToString()))
                    clb_Targeting2.SetItemChecked(i, true);
            }

            tb_clbCampaignFilter2.Text = tb_clbCampaignFilter3.Text;
            tb_clbCampaignFilter2.Enabled = tb_clbCampaignFilter3.Enabled;

            tb_clbAdGroupFilter2.Text = tb_clbAdGroupFilter3.Text;
            tb_clbAdGroupFilter2.Enabled = tb_clbAdGroupFilter3.Enabled;

            tb_clbTargetingFilter2.Text = tb_clbTargetingFilter3.Text;
            tb_clbTargetingFilter2.Enabled = tb_clbTargetingFilter3.Enabled;


            tbCampaignsFilterItems2.Clear();
            foreach (var t in tbCampaignsFilterItems3) { tbCampaignsFilterItems2.Add(t); }
            tbCampaignsFilterItemsPrev2.Clear();
            foreach (var t in tbCampaignsFilterItemsPrev3) { tbCampaignsFilterItemsPrev2.Add(t); }

            tbAdGroupsFilterItems2.Clear();
            foreach (var t in tbAdGroupsFilterItems3) { tbAdGroupsFilterItems2.Add(t); }
            tbAdGroupsFilterItemsPrev2.Clear();
            foreach (var t in tbAdGroupsFilterItemsPrev3) { tbAdGroupsFilterItemsPrev2.Add(t); }

            tbTargetingFilterItems2.Clear();
            foreach (var t in tbTargetingFilterItems3) { tbTargetingFilterItems2.Add(t); }
            tbTargetingFilterItemsPrev2.Clear();
            foreach (var t in tbTargetingFilterItemsPrev3) { tbTargetingFilterItemsPrev2.Add(t); }


            panel4.Visible = true;
            btn_Filter2.Text = ">";
            copying = false;
        }

        /* Генерируем Alarm отчет */
        private void advertisingAlarmReportToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Advreport7days advRep = new Advreport7days(StartDate3);
            if (MessageBox.Show("Сгенерировать отчет за период " + StartDate3.ToShortDateString() + "-" + StartDate3.AddDays(6).ToShortDateString() + "?\n\nОтчет будет сохранен в корень диска С.", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (advRep.Generate() == 1)
                    MessageBox.Show("Отчет успешно сохранен в корень диска С.", "Успех");
                else
                    MessageBox.Show("При генерации отчета произошла какая-то ошибка. Попробуйте ещё раз.", "Ошибка");
            }
        }

        /* Ищем значения Targetings в таблице по вхождению текста из tb_TargetingSearch1 (ищем Targetings по вводу пользователем) */
        private void tb_TargetingSearch3_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            SearchTargeting(tb.Text, dgv_AdvProducts3, dgv_AdGroups3, dgv_Targetings3, cb_ExactSearch3.Checked);
        }

        /* Включаем/выключаем Exact поиск и автоматически перебираем уже существующие результаты поиска в нужной таблице */
        private void cb_ExactSearch3_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_AdvProducts3.Visible)
            {
                SearchTargeting(tb_TargetingSearch3.Text, dgv_AdvProducts3, cb_ExactSearch3.Checked);
            }
            else if (dgv_AdGroups3.Visible)
            {
                SearchTargeting(tb_TargetingSearch3.Text, dgv_AdGroups3, cb_ExactSearch3.Checked);
            }
            else if (dgv_Targetings3.Visible)
            {
                SearchTargeting(tb_TargetingSearch3.Text, dgv_Targetings3, cb_ExactSearch3.Checked);
            }
        }

        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список */
        private void dgv_AdvProducts3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)     //AdGroup
            {
                string campaignName = dgv_AdvProducts3.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdvProducts3.Rows[e.RowIndex].Cells[3].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdvProducts3.Columns)      //adding columns in new table
                {
                    dgv_AdGroups3.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_AdGroups3.Rows.Add();

                for (int i = 1; i < dgv_AdvProducts3.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdvProducts3.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdvProducts3.Rows[i].Cells[3].Value.ToString().Equals(adGroup))
                    {
                        int index = dgv_AdGroups3.Rows.Add(dgv_AdvProducts3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts3.Rows[i].Cells)
                        {
                            dgv_AdGroups3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_AdGroups3);

                SearchTargeting(tb_TargetingSearch3.Text, dgv_AdGroups3, cb_ExactSearch3.Checked);

                //делаем видомости элементов корректными
                dgv_AdGroups3.Visible = true;
                dgv_AdvProducts3.Visible = false;
                btn_CloseTable3.Visible = true;
            }
            if (e.ColumnIndex == 4)     //Targeting
            {
                string campaignName = dgv_AdvProducts3.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdvProducts3.Rows[e.RowIndex].Cells[3].Value.ToString();
                string targeting = dgv_AdvProducts3.Rows[e.RowIndex].Cells[4].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdvProducts3.Columns)      //adding columns in new table
                {
                    dgv_Targetings3.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_Targetings3.Rows.Add();

                for (int i = 1; i < dgv_AdvProducts3.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdvProducts3.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdvProducts3.Rows[i].Cells[3].Value.ToString().Equals(adGroup) && dgv_AdvProducts3.Rows[i].Cells[4].Value.ToString().Equals(targeting))
                    {
                        int index = dgv_Targetings3.Rows.Add(dgv_AdvProducts3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts3.Rows[i].Cells)
                        {
                            dgv_Targetings3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_Targetings3);

                SearchTargeting(tb_TargetingSearch3.Text, dgv_Targetings3, cb_ExactSearch3.Checked);

                //делаем видомости элементов корректными
                dgv_Targetings3.Visible = true;
                dgv_AdvProducts3.Visible = false;
                btn_CloseTable3.Visible = true;
            }
        }


        /* Фильтруем записи по выбранной AdGroup и получаем обновленный список */
        private void dgv_AdGroups3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)     //Targeting
            {
                string campaignName = dgv_AdGroups3.Rows[e.RowIndex].Cells[2].Value.ToString();
                string adGroup = dgv_AdGroups3.Rows[e.RowIndex].Cells[3].Value.ToString();
                string targeting = dgv_AdGroups3.Rows[e.RowIndex].Cells[4].Value.ToString();

                foreach (DataGridViewColumn c in dgv_AdGroups3.Columns)      //adding columns in new table
                {
                    dgv_Targetings3.Columns.Add(c.Clone() as DataGridViewColumn);
                }

                dgv_Targetings3.Rows.Add();

                for (int i = 1; i < dgv_AdGroups3.Rows.Count; i++)           //checking and adding rows in new table
                {
                    if (dgv_AdGroups3.Rows[i].Cells[2].Value.ToString().Equals(campaignName) && dgv_AdGroups3.Rows[i].Cells[3].Value.ToString().Equals(adGroup) && dgv_AdGroups3.Rows[i].Cells[4].Value.ToString().Equals(targeting))
                    {
                        int index = dgv_Targetings3.Rows.Add(dgv_AdGroups3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups3.Rows[i].Cells)
                        {
                            dgv_Targetings3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                MakeSummaryForFilteredTable(dgv_Targetings3);

                SearchTargeting(tb_TargetingSearch3.Text, dgv_Targetings3, cb_ExactSearch3.Checked);

                //делаем видомости элементов корректными
                dgv_Targetings3.Visible = true;
                dgv_AdGroups3.Visible = false;
                btn_CloseTable3.Visible = true;
            }
        }

        /* Прячем вспомогательную таблицу и показываем основную */
        private void btn_CloseTable3_Click(object sender, EventArgs e)
        {
            btn_CloseTable3.Visible = false;

            dgv_AdGroups3.Visible = false;
            dgv_AdGroups3.Rows.Clear();
            dgv_AdGroups3.Columns.Clear();

            dgv_Targetings3.Visible = false;
            dgv_Targetings3.Rows.Clear();
            dgv_Targetings3.Columns.Clear();

            SearchTargeting(tb_TargetingSearch3.Text, dgv_AdvProducts3, cb_ExactSearch3.Checked);

            dgv_AdvProducts3.Visible = true;
        }


        /* Копируем всю таблицу с помощью контекстного меню из окна 3 в окно 1 */
        private void context3CopyToTab1_Click(object sender, EventArgs e)
        {
            if (dgv_AdvProducts3.Visible)
            {
                if (dgv_AdvProducts3.Rows.Count > 0)
                {
                    dgv_AdvProducts1.Rows.Clear();
                    dgv_AdvProducts1.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdvProducts3.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts1.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdvProducts3.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts1.Rows.Add(dgv_AdvProducts3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts3.Rows[i].Cells)
                        {
                            dgv_AdvProducts1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod3to1();
                }
            }
            else if (dgv_AdGroups3.Visible)
            {
                if (dgv_AdGroups3.Rows.Count > 0)
                {
                    dgv_AdvProducts1.Rows.Clear();
                    dgv_AdvProducts1.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdGroups3.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts1.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdGroups3.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts1.Rows.Add(dgv_AdGroups3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups3.Rows[i].Cells)
                        {
                            dgv_AdvProducts1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod3to1();
                    ModifidCopyMethod_AdGroups(dgv_AdGroups3, 1, clb_Campaign1, checkedCampaigns1, clb_AdGroup1, checkedAdGroups1);
                }
            }
            else if (dgv_Targetings3.Visible)
            {
                if (dgv_Targetings3.Rows.Count > 0)
                {
                    dgv_AdvProducts1.Rows.Clear();
                    dgv_AdvProducts1.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_Targetings3.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts1.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_Targetings3.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts1.Rows.Add(dgv_Targetings3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_Targetings3.Rows[i].Cells)
                        {
                            dgv_AdvProducts1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod3to1();
                    ModifidCopyMethod_Targeting(dgv_Targetings3, 1, clb_Campaign1, checkedCampaigns1, clb_AdGroup1, checkedAdGroups1, clb_Targeting1, checkedTargeting1);
                }
            }
        }

        /* Копируем всю таблицу с помощью контекстного меню из окна 3 в окно 2 */
        private void context3CopyToTab2_Click(object sender, EventArgs e)
        {
            if (dgv_AdvProducts3.Visible)
            {
                if (dgv_AdvProducts3.Rows.Count > 0)
                {
                    dgv_AdvProducts2.Rows.Clear();
                    dgv_AdvProducts2.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdvProducts3.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts2.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdvProducts3.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts2.Rows.Add(dgv_AdvProducts3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdvProducts3.Rows[i].Cells)
                        {
                            dgv_AdvProducts2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod3to2();
                }
            }
            else if (dgv_AdGroups3.Visible)
            {
                if (dgv_AdGroups3.Rows.Count > 0)
                {
                    dgv_AdvProducts2.Rows.Clear();
                    dgv_AdvProducts2.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_AdGroups3.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts2.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_AdGroups3.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts2.Rows.Add(dgv_AdGroups3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_AdGroups3.Rows[i].Cells)
                        {
                            dgv_AdvProducts2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod3to2();
                    ModifidCopyMethod_AdGroups(dgv_AdGroups3, 2, clb_Campaign2, checkedCampaigns2, clb_AdGroup2, checkedAdGroups2);
                }
            }
            else if (dgv_Targetings3.Visible)
            {
                if (dgv_Targetings3.Rows.Count > 0)
                {
                    dgv_AdvProducts2.Rows.Clear();
                    dgv_AdvProducts2.Columns.Clear();

                    foreach (DataGridViewColumn c in dgv_Targetings3.Columns)      //adding columns in new table
                    {
                        dgv_AdvProducts2.Columns.Add(c.Clone() as DataGridViewColumn);
                    }

                    for (int i = 0; i < dgv_Targetings3.Rows.Count; i++)           //checking and adding rows in new table
                    {
                        int index = dgv_AdvProducts2.Rows.Add(dgv_Targetings3.Rows[i].Clone() as DataGridViewRow);

                        foreach (DataGridViewCell o in dgv_Targetings3.Rows[i].Cells)
                        {
                            dgv_AdvProducts2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }

                    CopyMethod3to2();
                    ModifidCopyMethod_Targeting(dgv_Targetings3, 2, clb_Campaign2, checkedCampaigns2, clb_AdGroup2, checkedAdGroups2, clb_Targeting2, checkedTargeting2);
                }
            }
        }




























        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------UNIVERSAL AND TABLE DRAWING METHODS-----------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





        /* UNIVERSAL_METHOD Рисуем таблицу dgv_AdvProducts и заполняем её данными (при Custom Mode) */
        private void DrawTableForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList, DataGridView _dgv_AdvProducts, List<ProductsModel> _pList, bool _targetingInAdgroupsMode, bool _adgroupsInCampaignsMode, bool _campaignInProductsMode, bool _productsInMarketplaces)
        {
            this.Text = "Данные рекламы";
            _dgv_AdvProducts.Visible = true;

            _dgv_AdvProducts.Rows.Clear();
            _dgv_AdvProducts.Columns.Clear();

            if (_advProductsList.Count > 0)
            {
                DrawCorrectColumnsForSponsoredProducts(_advProductsList, _dgv_AdvProducts);

                DrawFirstRowForSponsoredProducts(_advProductsList, _dgv_AdvProducts);

                for (int i = 0; i < _advProductsList.Count; i++)
                {
                    var index = _dgv_AdvProducts.Rows.Add();
                    for (int j = 1; j < _advProductsList[0].ColumnCount; j++)
                    {
                        _dgv_AdvProducts.Rows[index].Cells[j].Value = _advProductsList[i].ReadData(j);
                    }
                }

                if (_productsInMarketplaces)
                    for (int i = 0; i < _advProductsList.Count; i++)
                    {
                        _dgv_AdvProducts.Rows[i + 1].Cells[5].Value = GetProductNameById(_advProductsList[i].ProductId, _pList);
                    }

                if (_targetingInAdgroupsMode)
                { }
                else if (_adgroupsInCampaignsMode)
                {
                    _dgv_AdvProducts.Columns[4].Visible = false;
                }
                else if (_campaignInProductsMode)
                {
                    _dgv_AdvProducts.Columns[4].Visible = false;
                    _dgv_AdvProducts.Columns[3].Visible = false;
                }
                else if (_productsInMarketplaces)
                {
                    _dgv_AdvProducts.Columns[4].Visible = false;
                    _dgv_AdvProducts.Columns[3].Visible = false;
                    _dgv_AdvProducts.Columns[2].Visible = false;
                }
            }
            //btn_Export1.Text = "Экспорт в файл (" + (_dgv_AdvProducts.RowCount - 1) + ")";
        }

        /* UNIVERSAL_METHOD Рисуем "правильную" таблицу с заголовками и шириной столбцов для Sponsored Products (при Custom Mode) */
        private void DrawCorrectColumnsForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList, DataGridView _dgv_AdvProducts)
        {
            _dgv_AdvProducts.Columns.Add("UpdateDate", "Date");
            _dgv_AdvProducts.Columns.Add("CurrencyCharCode", "Currency");
            _dgv_AdvProducts.Columns.Add("CampaignName", "Campaign");
            _dgv_AdvProducts.Columns.Add("AdGroupName", "AdGroup");
            _dgv_AdvProducts.Columns.Add("Targeting", "Targeting");
            if (productsInMarketplaces1)
                _dgv_AdvProducts.Columns.Add("ProductName", "Product");
            else
                _dgv_AdvProducts.Columns.Add("MatchType", "Match Type");
            _dgv_AdvProducts.Columns.Add("Impressions", "Impressions");
            _dgv_AdvProducts.Columns.Add("Clicks", "Clicks");
            _dgv_AdvProducts.Columns.Add("CTR", "CTR");
            _dgv_AdvProducts.Columns.Add("CPC", "CPC");
            _dgv_AdvProducts.Columns.Add("Spend", "Spend");
            _dgv_AdvProducts.Columns.Add("Sales", "Sales");
            _dgv_AdvProducts.Columns.Add("ACoS", "ACoS");
            _dgv_AdvProducts.Columns.Add("RoAS", "RoAS");
            _dgv_AdvProducts.Columns.Add("Orders", "Orders");
            _dgv_AdvProducts.Columns.Add("Units", "Units");
            _dgv_AdvProducts.Columns.Add("ConversionRate", "Conversion");
            _dgv_AdvProducts.Columns.Add("AdvSKUUnits", "Adv SKU Units");
            _dgv_AdvProducts.Columns.Add("OtherSKUUnits", "Other SKU Units");
            _dgv_AdvProducts.Columns.Add("AdvSKUSales", "Adv SKU Sales");
            _dgv_AdvProducts.Columns.Add("OtherSKUSales", "Other SKU Sales");
            _dgv_AdvProducts.Columns.Add("CampaignTypeId", "text");
            _dgv_AdvProducts.Columns.Add("MarketPlaceId", "text");
            _dgv_AdvProducts.Columns.Add("CampaignId", "text");
            _dgv_AdvProducts.Columns.Add("ProductId", "text");

            _dgv_AdvProducts.Columns[0].Visible = false;
            _dgv_AdvProducts.Columns[1].Visible = false;
            _dgv_AdvProducts.Columns[21].Visible = false;
            _dgv_AdvProducts.Columns[22].Visible = false;
            _dgv_AdvProducts.Columns[23].Visible = false;
            _dgv_AdvProducts.Columns[24].Visible = false;

            //_dgv_AdvProducts.Columns[0].Frozen = true;
            //_dgv_AdvProducts.Columns[1].Frozen = true;
            //_dgv_AdvProducts.Columns[2].Frozen = true;
            //_dgv_AdvProducts.Columns[3].Frozen = true;
            //_dgv_AdvProducts.Columns[4].Frozen = true;
            //_dgv_AdvProducts.Columns[5].Frozen = true;

            _dgv_AdvProducts.Columns[0].Width = 70;
            _dgv_AdvProducts.Columns[1].Width = 60;
            _dgv_AdvProducts.Columns[2].Width = 200;
            _dgv_AdvProducts.Columns[3].Width = 200;
            _dgv_AdvProducts.Columns[4].Width = 200;

            for (int i = 0; i < _advProductsList[0].ColumnCount; i++)
            {
                _dgv_AdvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 6)
                    _dgv_AdvProducts.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /* UNIVERSAL_METHOD Рисуем суммирующиую 1ю строку в dgv_AdvProducts (при Custom Mode) */
        private void DrawFirstRowForSponsoredProducts(List<AdvertisingProductsModel> _advProductsList, DataGridView _dgv_AdvProducts)
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

            var index = _dgv_AdvProducts.Rows.Add();

            _dgv_AdvProducts.Rows[index].Cells[6].Value = impr;
            _dgv_AdvProducts.Rows[index].Cells[7].Value = clicks;
            _dgv_AdvProducts.Rows[index].Cells[8].Value = ctr;
            _dgv_AdvProducts.Rows[index].Cells[9].Value = cpc;
            _dgv_AdvProducts.Rows[index].Cells[10].Value = Math.Round(spend, 2);
            _dgv_AdvProducts.Rows[index].Cells[11].Value = Math.Round(sales, 2);
            _dgv_AdvProducts.Rows[index].Cells[12].Value = acos;
            _dgv_AdvProducts.Rows[index].Cells[13].Value = roas;
            _dgv_AdvProducts.Rows[index].Cells[14].Value = orders;
            _dgv_AdvProducts.Rows[index].Cells[15].Value = units;
            _dgv_AdvProducts.Rows[index].Cells[16].Value = convers;
            _dgv_AdvProducts.Rows[index].Cells[17].Value = advskuunt;
            _dgv_AdvProducts.Rows[index].Cells[18].Value = otherskuunt;
            _dgv_AdvProducts.Rows[index].Cells[19].Value = Math.Round(advskusales, 2);
            _dgv_AdvProducts.Rows[index].Cells[20].Value = Math.Round(otherskusales, 2);
        }

        /* UNIVERSAL_METHOD Рисуем таблицу dgv_AdvProducts и заполняем её данными (при Products Mode) */
        private void DrawTableForProductsInMarketplacesMode(string asins, int _timeSpan, string _mode, DataGridView _dgv_AdvProducts, List<ProductsModel> _pList, DateTime _EndDate, List<AdvertisingProductsModel> _advProductsList)
        {
            DrawFirstColumn(_dgv_AdvProducts);
            this.Text += " - " + GetProductNameFromAsins(asins, _pList);

            DateTime workingEndDate = _EndDate;
            DateTime workingStartDate = workingEndDate.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

            if (_mode.Equals("months"))
            {
                workingStartDate = workingStartDate.AddDays(-30);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnProduct(workingStartDate, workingEndDate, asins, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-31);
                    workingStartDate = workingStartDate.AddDays(-31);
                }
            }
            else if (_mode.Equals("weeks"))
            {
                workingStartDate = workingStartDate.AddDays(-6);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnProduct(workingStartDate, workingEndDate, asins, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-7);
                    workingStartDate = workingStartDate.AddDays(-7);
                }
            }
            else if (_mode.Equals("days"))
            {
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnProduct(workingStartDate, workingEndDate, asins, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-1);
                    workingStartDate = workingStartDate.AddDays(-1);
                }
            }
        }

        /* UNIVERSAL_METHOD Непосредственно заполняем таблицу данными (при Products Mode) */
        private void DrawColumnProduct(DateTime _startDate, DateTime _endDate, string _asins, List<AdvertisingProductsModel> _advProductsList, DataGridView _dgv_AdvProducts)
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


            for (int i = 0; i < _advProductsList.Count; i++)
            {
                if (_advProductsList[i].UpdateDate >= _startDate && _advProductsList[i].UpdateDate <= _endDate && _asins.Contains(_advProductsList[i].ProductId.ToString()))
                {
                    Impressions += _advProductsList[i].Impressions;
                    Clicks += _advProductsList[i].Clicks;
                    Spend += _advProductsList[i].Spend;
                    Sales += _advProductsList[i].Sales;
                    Orders += _advProductsList[i].Orders;
                    Units += _advProductsList[i].Units;
                    AdvSKUUnits += _advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits += _advProductsList[i].OtherSKUUnits;
                    AdvSKUSales += _advProductsList[i].AdvSKUSales;
                    OtherSKUSales += _advProductsList[i].OtherSKUSales;
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


            _dgv_AdvProducts.Columns.Add(_startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5), _startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5) + "\n" + GetMonth(_startDate.Month));
            _dgv_AdvProducts.Rows[0].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            _dgv_AdvProducts.Rows[1].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            _dgv_AdvProducts.Rows[2].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            _dgv_AdvProducts.Rows[3].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            _dgv_AdvProducts.Rows[4].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            _dgv_AdvProducts.Rows[5].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            _dgv_AdvProducts.Rows[6].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            _dgv_AdvProducts.Rows[7].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            _dgv_AdvProducts.Rows[8].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            _dgv_AdvProducts.Rows[9].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Units;
            _dgv_AdvProducts.Rows[10].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            _dgv_AdvProducts.Rows[11].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            _dgv_AdvProducts.Rows[12].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            _dgv_AdvProducts.Rows[13].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            _dgv_AdvProducts.Rows[14].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            _dgv_AdvProducts.Columns[_dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /* UNIVERSAL_METHOD Рисуем таблицу dgv_AdvProducts и заполняем её данными (при Campaigns Mode) */
        private void DrawTableForCampaignInProductsMode(string _campaign, int _timeSpan, string _mode, int _prodId, DataGridView _dgv_AdvProducts, DateTime _EndDate, List<AdvertisingProductsModel> _advProductsList)
        {
            DrawFirstColumn(_dgv_AdvProducts);
            this.Text += " - " + _campaign;

            DateTime workingEndDate = _EndDate;
            DateTime workingStartDate = workingEndDate.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

            if (_mode.Equals("months"))
            {
                workingStartDate = workingStartDate.AddDays(-30);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnCampaign(workingStartDate, workingEndDate, _campaign, _prodId, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-31);
                    workingStartDate = workingStartDate.AddDays(-31);
                }
            }
            else if (_mode.Equals("weeks"))
            {
                workingStartDate = workingStartDate.AddDays(-6);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnCampaign(workingStartDate, workingEndDate, _campaign, _prodId, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-7);
                    workingStartDate = workingStartDate.AddDays(-7);
                }
            }
            else if (_mode.Equals("days"))
            {
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnCampaign(workingStartDate, workingEndDate, _campaign, _prodId, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-1);
                    workingStartDate = workingStartDate.AddDays(-1);
                }
            }
        }

        /* UNIVERSAL_METHOD Непосредственно заполняем таблицу данными (при Campaigns Mode) */
        private void DrawColumnCampaign(DateTime _startDate, DateTime _endDate, string _campaign, int _prodId, List<AdvertisingProductsModel> _advProductsList, DataGridView _dgv_AdvProducts)
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

            for (int i = 0; i < _advProductsList.Count; i++)
            {
                if (_advProductsList[i].UpdateDate >= _startDate && _advProductsList[i].UpdateDate <= _endDate && _advProductsList[i].ProductId == _prodId && _campaign.Contains(_advProductsList[i].CampaignName))
                {
                    Impressions += _advProductsList[i].Impressions;
                    Clicks += _advProductsList[i].Clicks;
                    Spend += _advProductsList[i].Spend;
                    Sales += _advProductsList[i].Sales;
                    Orders += _advProductsList[i].Orders;
                    Units += _advProductsList[i].Units;
                    AdvSKUUnits += _advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits += _advProductsList[i].OtherSKUUnits;
                    AdvSKUSales += _advProductsList[i].AdvSKUSales;
                    OtherSKUSales += _advProductsList[i].OtherSKUSales;
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


            _dgv_AdvProducts.Columns.Add(_startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5), _startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5) + "\n" + GetMonth(_startDate.Month));
            _dgv_AdvProducts.Rows[0].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            _dgv_AdvProducts.Rows[1].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            _dgv_AdvProducts.Rows[2].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            _dgv_AdvProducts.Rows[3].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            _dgv_AdvProducts.Rows[4].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            _dgv_AdvProducts.Rows[5].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            _dgv_AdvProducts.Rows[6].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            _dgv_AdvProducts.Rows[7].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            _dgv_AdvProducts.Rows[8].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            _dgv_AdvProducts.Rows[9].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Units;
            _dgv_AdvProducts.Rows[10].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            _dgv_AdvProducts.Rows[11].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            _dgv_AdvProducts.Rows[12].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            _dgv_AdvProducts.Rows[13].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            _dgv_AdvProducts.Rows[14].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            _dgv_AdvProducts.Columns[_dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /* UNIVERSAL_METHOD Рисуем таблицу dgv_AdvProducts и заполняем её данными (при AdGroups Mode) */
        private void DrawTableForAdGroupsInCampaignsMode(string _adGroup, int _timeSpan, string _mode, int _prodId, DataGridView _dgv_AdvProducts, DateTime _EndDate, List<AdvertisingProductsModel> _advProductsList)
        {
            DrawFirstColumn(_dgv_AdvProducts);
            this.Text += " - " + _adGroup;

            DateTime workingEndDate = _EndDate;
            DateTime workingStartDate = workingEndDate.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

            if (_mode.Equals("months"))
            {
                workingStartDate = workingStartDate.AddDays(-30);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnAdGroup(workingStartDate, workingEndDate, _adGroup, _prodId, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-31);
                    workingStartDate = workingStartDate.AddDays(-31);
                }
            }
            else if (_mode.Equals("weeks"))
            {
                workingStartDate = workingStartDate.AddDays(-6);
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnAdGroup(workingStartDate, workingEndDate, _adGroup, _prodId, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-7);
                    workingStartDate = workingStartDate.AddDays(-7);
                }
            }
            else if (_mode.Equals("days"))
            {
                for (int i = 0; i < _timeSpan; i++)
                {
                    DrawColumnAdGroup(workingStartDate, workingEndDate, _adGroup, _prodId, _advProductsList, _dgv_AdvProducts);

                    workingEndDate = workingEndDate.AddDays(-1);
                    workingStartDate = workingStartDate.AddDays(-1);
                }
            }
        }

        /* UNIVERSAL_METHOD Непосредственно заполняем таблицу данными (при AdGroups Mode) */
        private void DrawColumnAdGroup(DateTime _startDate, DateTime _endDate, string _adGroup, int _prodId, List<AdvertisingProductsModel> _advProductsList, DataGridView _dgv_AdvProducts)
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

            for (int i = 0; i < _advProductsList.Count; i++)
            {
                if (_advProductsList[i].UpdateDate >= _startDate && _advProductsList[i].UpdateDate <= _endDate && _adGroup.Contains(_advProductsList[i].AdGroupName) && _advProductsList[i].ProductId == _prodId)
                {
                    Impressions += _advProductsList[i].Impressions;
                    Clicks += _advProductsList[i].Clicks;
                    Spend += _advProductsList[i].Spend;
                    Sales += _advProductsList[i].Sales;
                    Orders += _advProductsList[i].Orders;
                    Units += _advProductsList[i].Units;
                    AdvSKUUnits += _advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits += _advProductsList[i].OtherSKUUnits;
                    AdvSKUSales += _advProductsList[i].AdvSKUSales;
                    OtherSKUSales += _advProductsList[i].OtherSKUSales;
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


            _dgv_AdvProducts.Columns.Add(_startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5), _startDate.ToString().Substring(0, 5) + "-" + _endDate.ToString().Substring(0, 5) + "\n" + GetMonth(_startDate.Month));
            _dgv_AdvProducts.Rows[0].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            _dgv_AdvProducts.Rows[1].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            _dgv_AdvProducts.Rows[2].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            _dgv_AdvProducts.Rows[3].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            _dgv_AdvProducts.Rows[4].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            _dgv_AdvProducts.Rows[5].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            _dgv_AdvProducts.Rows[6].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            _dgv_AdvProducts.Rows[7].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            _dgv_AdvProducts.Rows[8].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            _dgv_AdvProducts.Rows[9].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Units;
            _dgv_AdvProducts.Rows[10].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            _dgv_AdvProducts.Rows[11].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            _dgv_AdvProducts.Rows[12].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            _dgv_AdvProducts.Rows[13].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            _dgv_AdvProducts.Rows[14].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            _dgv_AdvProducts.Columns[_dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /* UNIVERSAL_METHOD Рисуем первый столбец в таблице */
        private void DrawFirstColumn(DataGridView _dgv_AdvProducts)
        {
            _dgv_AdvProducts.Rows.Clear();
            _dgv_AdvProducts.Columns.Clear();
            _dgv_AdvProducts.Columns.Add("", "");
            var index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Impressions";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Clicks";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "CTR";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "CPC";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Spend";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Sales";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "ACoS";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "RoAS";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Orders";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Units";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Conversion";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Adv SKU Units";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Other SKU Units";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Adv SKU Sales";
            index = _dgv_AdvProducts.Rows.Add();
            _dgv_AdvProducts.Rows[index].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = "Other SKU Sales";

            _dgv_AdvProducts.Columns[0].Width = 125;
            _dgv_AdvProducts.Columns[0].Frozen = true;
            _dgv_AdvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /* UNIVERSAL_METHOD Рисуем последний столбец в таблице с суммами */
        private void DrawLastColumn(DataGridView _dgv_AdvProducts)
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

            for (int i = 1; i < _dgv_AdvProducts.Columns.Count; i++)
            {
                Impressions += int.Parse(_dgv_AdvProducts.Rows[0].Cells[i].Value.ToString());
                Clicks += int.Parse(_dgv_AdvProducts.Rows[1].Cells[i].Value.ToString());
                Spend += double.Parse(_dgv_AdvProducts.Rows[4].Cells[i].Value.ToString());
                Sales += double.Parse(_dgv_AdvProducts.Rows[5].Cells[i].Value.ToString());
                Orders += int.Parse(_dgv_AdvProducts.Rows[8].Cells[i].Value.ToString());
                Units += int.Parse(_dgv_AdvProducts.Rows[9].Cells[i].Value.ToString());
                AdvSKUUnits += int.Parse(_dgv_AdvProducts.Rows[11].Cells[i].Value.ToString());
                OtherSKUUnits += int.Parse(_dgv_AdvProducts.Rows[12].Cells[i].Value.ToString());
                AdvSKUSales += double.Parse(_dgv_AdvProducts.Rows[13].Cells[i].Value.ToString());
                OtherSKUSales += double.Parse(_dgv_AdvProducts.Rows[14].Cells[i].Value.ToString());
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


            _dgv_AdvProducts.Columns.Add("summ", "Всего");
            _dgv_AdvProducts.Rows[0].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Impressions;
            _dgv_AdvProducts.Rows[1].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Clicks;
            _dgv_AdvProducts.Rows[2].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CTR;
            _dgv_AdvProducts.Rows[3].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = CPC;
            _dgv_AdvProducts.Rows[4].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Spend;
            _dgv_AdvProducts.Rows[5].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Sales;
            _dgv_AdvProducts.Rows[6].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = ACoS;
            _dgv_AdvProducts.Rows[7].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = RoAS;
            _dgv_AdvProducts.Rows[8].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Orders;
            _dgv_AdvProducts.Rows[9].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Units;
            _dgv_AdvProducts.Rows[10].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = Conversion;
            _dgv_AdvProducts.Rows[11].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUUnits;
            _dgv_AdvProducts.Rows[12].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUUnits;
            _dgv_AdvProducts.Rows[13].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = AdvSKUSales;
            _dgv_AdvProducts.Rows[14].Cells[_dgv_AdvProducts.ColumnCount - 1].Value = OtherSKUSales;

            _dgv_AdvProducts.Columns[_dgv_AdvProducts.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /* UNIVERSAL_METHOD Получаем название месяца */
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

        /* UNIVERSAL_METHOD Получаем имя товара по заданному productId */
        private string GetProductNameById(int _productId, List<ProductsModel> _pList)
        {
            for (int i = 0; i < _pList.Count; i++)
            {
                if (_pList[i].ProductId == _productId)
                    return _pList[i].Name;
            }
            return "";
        }

        /* UNIVERSAL_METHOD Получаем имя товара по заданному ASIN */
        private string GetProductNameFromAsins(string _asins, List<ProductsModel> _pList)
        {
            string idStr = "";
            int idInt = 0;
            bool flag = false;
            for (int i = 0; i < _asins.Length; i++)
            {
                if (_asins[i].Equals(',') && !flag)
                {
                    idStr = _asins.Substring(0, i);
                    flag = true;
                }
            }
            idInt = int.Parse(idStr);
            for (int i = 0; i < _pList.Count; i++)
            {
                if (idInt == _pList[i].ProductId)
                    return _pList[i].Name;
            }
            return "";
        }
        
        /* UNIVERSAL_METHOD суммируем данные в новой таблице в 1ю строку */
        private void MakeSummaryForFilteredTable(DataGridView _dgv)
        {
            int Impressions = 0;
            int Clicks = 0;
            double Spend = 0;
            double Sales = 0;
            int Orders = 0;
            int Units = 0;
            int AdvSKUUnits = 0;
            int OtherSKUUnits = 0;
            double AdvSKUSales = 0;
            double OtherSKUSales = 0;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 1; i < _dgv.Rows.Count; i++)
            {
                Impressions += int.Parse(_dgv.Rows[i].Cells[6].Value.ToString());
                Clicks += int.Parse(_dgv.Rows[i].Cells[7].Value.ToString());
                Spend += double.Parse(_dgv.Rows[i].Cells[10].Value.ToString());
                Sales += double.Parse(_dgv.Rows[i].Cells[11].Value.ToString());
                Orders += int.Parse(_dgv.Rows[i].Cells[14].Value.ToString());
                Units += int.Parse(_dgv.Rows[i].Cells[15].Value.ToString());
                AdvSKUUnits += int.Parse(_dgv.Rows[i].Cells[17].Value.ToString());
                OtherSKUUnits += int.Parse(_dgv.Rows[i].Cells[18].Value.ToString());
                AdvSKUSales += double.Parse(_dgv.Rows[i].Cells[19].Value.ToString());
                OtherSKUSales += double.Parse(_dgv.Rows[i].Cells[20].Value.ToString());

            }

            if (Impressions != 0)
                CTR = (double)Clicks / Impressions * 100;
            else CTR = 0;

            if (Clicks != 0)
                CPC = Spend / Clicks;
            else CPC = 0;

            if (Sales != 0)
                ACoS = (Spend / Sales) * 100;
            else ACoS = 0;

            if (Spend != 0)
                RoAS = (Sales / Spend);
            else RoAS = 0;

            if (Clicks != 0)
                ConversionRate = ((double)Orders / Clicks) * 100;
            else ConversionRate = 0;

            _dgv.Rows[0].Cells[6].Value = Impressions;
            _dgv.Rows[0].Cells[7].Value = Clicks;
            _dgv.Rows[0].Cells[8].Value = Math.Round(CTR, 2);
            _dgv.Rows[0].Cells[9].Value = Math.Round(CPC, 2);
            _dgv.Rows[0].Cells[10].Value = Math.Round(Spend, 2);
            _dgv.Rows[0].Cells[11].Value = Math.Round(Sales, 2);
            _dgv.Rows[0].Cells[12].Value = Math.Round(ACoS, 2);
            _dgv.Rows[0].Cells[13].Value = Math.Round(RoAS, 2);
            _dgv.Rows[0].Cells[14].Value = Orders;
            _dgv.Rows[0].Cells[15].Value = Units;
            _dgv.Rows[0].Cells[16].Value = Math.Round(ConversionRate, 2);
            _dgv.Rows[0].Cells[17].Value = AdvSKUUnits;
            _dgv.Rows[0].Cells[18].Value = OtherSKUUnits;
            _dgv.Rows[0].Cells[19].Value = AdvSKUSales;
            _dgv.Rows[0].Cells[20].Value = OtherSKUSales;
        }

        /* UNIVERSAL_METHOD метод поиска ключа в таблицАХ по вхождению введенного пользователем текста */
        private void SearchTargeting(string _text, DataGridView _dgv_AdvProducts, DataGridView _dgv_AdGroups, DataGridView _dgv_Targetings, bool _ExactSearch)
        {
            if (_ExactSearch)
            {
                if (_dgv_AdvProducts.Visible)
                {
                    for (int i = 1; i < _dgv_AdvProducts.RowCount; i++)
                    {
                        if (_dgv_AdvProducts.Rows[i].Cells[4].Value.ToString().ToLower().Equals(_text) && _text != "")
                            _dgv_AdvProducts.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                        else
                            _dgv_AdvProducts.Rows[i].Cells[4].Style.BackColor = Color.White;
                    }
                }
                else if (_dgv_AdGroups.Visible)
                {
                    for (int i = 1; i < _dgv_AdGroups.RowCount; i++)
                    {
                        if (_dgv_AdGroups.Rows[i].Cells[4].Value.ToString().ToLower().Equals(_text) && _text != "")
                            _dgv_AdGroups.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                        else
                            _dgv_AdGroups.Rows[i].Cells[4].Style.BackColor = Color.White;
                    }
                }
                else if (_dgv_Targetings.Visible)
                {
                    for (int i = 1; i < _dgv_Targetings.RowCount; i++)
                    {
                        if (_dgv_Targetings.Rows[i].Cells[4].Value.ToString().ToLower().Equals(_text) && _text != "")
                            _dgv_Targetings.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                        else
                            _dgv_Targetings.Rows[i].Cells[4].Style.BackColor = Color.White;
                    }
                }
            }
            else
            {
                if (_dgv_AdvProducts.Visible)
                {
                    for (int i = 1; i < _dgv_AdvProducts.RowCount; i++)
                    {
                        if (_dgv_AdvProducts.Rows[i].Cells[4].Value.ToString().ToLower().Contains(_text) && _text != "")
                            _dgv_AdvProducts.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                        else
                            _dgv_AdvProducts.Rows[i].Cells[4].Style.BackColor = Color.White;
                    }
                }
                else if (_dgv_AdGroups.Visible)
                {
                    for (int i = 1; i < _dgv_AdGroups.RowCount; i++)
                    {
                        if (_dgv_AdGroups.Rows[i].Cells[4].Value.ToString().ToLower().Contains(_text) && _text != "")
                            _dgv_AdGroups.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                        else
                            _dgv_AdGroups.Rows[i].Cells[4].Style.BackColor = Color.White;
                    }
                }
                else if (_dgv_Targetings.Visible)
                {
                    for (int i = 1; i < _dgv_Targetings.RowCount; i++)
                    {
                        if (_dgv_Targetings.Rows[i].Cells[4].Value.ToString().ToLower().Contains(_text) && _text != "")
                            _dgv_Targetings.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                        else
                            _dgv_Targetings.Rows[i].Cells[4].Style.BackColor = Color.White;
                    }
                }
            }
        }

        /* UNIVERSAL_METHOD метод поиска ключа в таблицЕ по вхождению введенного пользователем текста */
        private void SearchTargeting(string _text, DataGridView _dgv, bool _ExactSearch)
        {
            if (_ExactSearch)
                for (int i = 1; i < _dgv.RowCount; i++)
                {
                    if (_dgv.Rows[i].Cells[4].Value.ToString().ToLower().Equals(_text) && _text != "")
                        //_dgv.Rows[i].Cells[4].Style.BackColor = Color.DeepSkyBlue;
                        _dgv.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                    else
                        _dgv.Rows[i].Cells[4].Style.BackColor = Color.White;
                }
            else
                for (int i = 1; i < _dgv.RowCount; i++)
                {
                    if (_dgv.Rows[i].Cells[4].Value.ToString().ToLower().Contains(_text) && _text != "")
                        _dgv.Rows[i].Cells[4].Style.BackColor = btn_ColorChoose.BackColor;
                    else
                        _dgv.Rows[i].Cells[4].Style.BackColor = Color.White;
                }
        }
        
        /* UNIVERSAL_METHOD метод выбора цвета, которым будут помечаться ключи при поиске через textBox */
        private void btn_ColorChoose_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                btn_ColorChoose.BackColor = colorDialog1.Color;
        }

        /* UNIVERSAL METHOD Перерисовка формы при изменении размера */
        private void AdvertisingReportView_SizeChanged(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 20;
            tabControl1.Height = this.Height - 30;

            btn_ColorChoose.Location = new System.Drawing.Point(tabControl1.Width - btn_ColorChoose.Size.Width - 10, btn_ColorChoose.Location.Y);

            dgv_AdvProducts1.Width = tabControl1.Width - 20 - btn_Filter1.Width;
            dgv_AdvProducts1.Height = tabControl1.Height - 100;

            btn_Filter1.Location = new System.Drawing.Point(tabControl1.Width - btn_Filter1.Size.Width - 10, btn_Filter1.Location.Y);
            btn_Filter1.Height = tabControl1.Height - 100;
            panel1.Location = new System.Drawing.Point((dgv_AdvProducts1.Width - panel1.Size.Width) / 2, panel1.Location.Y);
            panel2.Location = new System.Drawing.Point(tabControl1.Width - panel2.Size.Width - 18 - btn_Filter1.Size.Width, btn_Filter1.Location.Y);


            dgv_AdvProducts2.Width = tabControl1.Width - 20 - btn_Filter2.Width;
            dgv_AdvProducts2.Height = tabControl1.Height - 100;

            btn_Filter2.Location = new System.Drawing.Point(tabControl1.Width - btn_Filter2.Size.Width - 10, btn_Filter2.Location.Y);
            btn_Filter2.Height = tabControl1.Height - 100;
            panel6.Location = new System.Drawing.Point((dgv_AdvProducts2.Width - panel6.Size.Width) / 2, panel6.Location.Y);
            panel4.Location = new System.Drawing.Point(tabControl1.Width - panel4.Size.Width - 18 - btn_Filter2.Size.Width, btn_Filter2.Location.Y);


            dgv_AdvProducts3.Width = tabControl1.Width - 20 - btn_Filter3.Width;
            dgv_AdvProducts3.Height = tabControl1.Height - 100;

            btn_Filter3.Location = new System.Drawing.Point(tabControl1.Width - btn_Filter3.Size.Width - 10, btn_Filter3.Location.Y);
            btn_Filter3.Height = tabControl1.Height - 100;
            panel9.Location = new System.Drawing.Point((dgv_AdvProducts3.Width - panel9.Size.Width) / 2, panel9.Location.Y);
            panel7.Location = new System.Drawing.Point(tabControl1.Width - panel7.Size.Width - 18 - btn_Filter3.Size.Width, btn_Filter3.Location.Y);
        }

        /* UNIVERSAL METHOD Обрабатываем закрытие формы */
        private void AdvertisingReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }
        
        /* UNIVERSAL METHOD Переносим не только настройки основго фильтра, но и помечаем в clb группу, по которой в таблице отфильтровали результаты */
        private void ModifidCopyMethod_AdGroups(DataGridView _dgvFrom, int _toIndex, CheckedListBox _clbCampaignsTo, List<string> checkedCampaignsTo, CheckedListBox _clbAdGroupsTo, List<string> checkedAdGroupsTo)
        {
            string productName = _dgvFrom.Rows[1].Cells[2].Value.ToString();
            string campaign = _dgvFrom.Rows[1].Cells[2].Value.ToString();
            string adGroup = _dgvFrom.Rows[1].Cells[3].Value.ToString();
            string resultString = adGroup + " (" + campaign + ")";

            for (int i = 0; i < _clbCampaignsTo.Items.Count; i++)
            {
                if (_clbCampaignsTo.Items[i].ToString().Equals(productName))
                {
                    _clbCampaignsTo.SetItemChecked(i, true);
                    if (!checkedCampaignsTo.Contains(productName))
                        checkedCampaignsTo.Add(productName);
                }
            }

            if (_toIndex == 1)
                method_clb_Campaign1_SelectedIndexChanged();
            else if (_toIndex == 2)
                method_clb_Campaign2_SelectedIndexChanged();
            else if (_toIndex == 3)
                method_clb_Campaign3_SelectedIndexChanged();

            for (int i = 0; i < _clbAdGroupsTo.Items.Count; i++)
            {
                if (_clbAdGroupsTo.Items[i].ToString().Equals(resultString))
                {
                    _clbAdGroupsTo.SetItemChecked(i, true);
                    if (!checkedAdGroupsTo.Contains(resultString))
                        checkedAdGroupsTo.Add(resultString);
                }
            }
        }

        /* UNIVERSAL METHOD Переносим не только настройки основго фильтра, но и помечаем в clb ключ, по которому в таблице отфильтровали результаты */
        private void ModifidCopyMethod_Targeting(DataGridView _dgvFrom, int _toIndex, CheckedListBox _clbCampaignsTo, List<string> checkedCampaignsTo, CheckedListBox _clbAdGroupsTo, List<string> checkedAdGroupsTo, CheckedListBox _clbTargetingTo, List<string> checkedTargetingsTo)
        {
            string productName = _dgvFrom.Rows[1].Cells[2].Value.ToString();
            string campaign = _dgvFrom.Rows[1].Cells[2].Value.ToString();
            string adGroup = _dgvFrom.Rows[1].Cells[3].Value.ToString();
            string targeting = _dgvFrom.Rows[1].Cells[4].Value.ToString();
            string resultString1 = adGroup + " (" + campaign + ")";
            string resultString2 = targeting + " (" + adGroup + " (" + campaign + "))";

            for (int i = 0; i < _clbCampaignsTo.Items.Count; i++)
            {
                if (_clbCampaignsTo.Items[i].ToString().Equals(productName))
                {
                    _clbCampaignsTo.SetItemChecked(i, true);
                    if (!checkedCampaignsTo.Contains(productName))
                        checkedCampaignsTo.Add(productName);
                }
            }

            if (_toIndex == 1)
                method_clb_Campaign1_SelectedIndexChanged();
            else if (_toIndex == 2)
                method_clb_Campaign2_SelectedIndexChanged();
            else if (_toIndex == 3)
                method_clb_Campaign3_SelectedIndexChanged();

            for (int i = 0; i < _clbAdGroupsTo.Items.Count; i++)
            {
                if (_clbAdGroupsTo.Items[i].ToString().Equals(resultString1))
                {
                    _clbAdGroupsTo.SetItemChecked(i, true);
                    if (!checkedAdGroupsTo.Contains(resultString1))
                        checkedAdGroupsTo.Add(resultString1);
                }
            }

            if (_toIndex == 1)
                method_clb_AdGroup1_SelectedIndexChanged();
            else if (_toIndex == 2)
                method_clb_AdGroup2_SelectedIndexChanged();
            else if (_toIndex == 3)
                method_clb_AdGroup3_SelectedIndexChanged();


            for (int i = 0; i < _clbTargetingTo.Items.Count; i++)
            {
                if (_clbTargetingTo.Items[i].ToString().Equals(resultString2))
                {
                    _clbTargetingTo.SetItemChecked(i, true);
                    if (!checkedTargetingsTo.Contains(resultString2))
                        checkedTargetingsTo.Add(resultString2);
                }
            }
        }

    }
}
