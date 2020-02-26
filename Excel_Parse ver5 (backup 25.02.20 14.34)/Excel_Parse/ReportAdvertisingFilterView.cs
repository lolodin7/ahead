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
    public partial class ReportAdvertisingFilterView : Form
    {
        private ReportAdvertisingView mf;
        private DateTime StartDate, EndDate;
        private bool MonthlyMode, WeeklyMode;

        List<string> checkedMarkeplaces, checkedProducts, checkedCampaigns, checkedAdGroups, adGroupsList;
        List<string> checkedMarkeplacesTMP, checkedProductsTMP, checkedCampaignsTMP, checkedAdGroupsTMP;
        List<string> tbProductsFilterItems, tbCampaignsFilterItems, tbAdGroupsFilterItems;
        List<string> tbProductsFilterItemsPrev, tbCampaignsFilterItemsPrev, tbAdGroupsFilterItemsPrev;

        private List<string> uniqueCampaigns;
        private List<string> uniqueAdGroups;
        private List<CmapaignAndIdStruct> campsidsList;



        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingProductsModel> summaryAdvProductsList;
        private List<AdvertisingProductsModel> advProductsListOriginal;

        private List<AdvertisingBrandsModel> advBrandsList;
        private List<AdvertisingBrandsModel> summaryAdvBrandsList;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private CampaignTypesController campTController;
        private List<CampaignTypesModel> campTList;

        private AdvertisingController advertController;     

        private List<MapNameId> AP_campaignIdsList;
        private List<MapNameId> AB_campaignIdsList;

        private List<MapNameId> AP_campaignIdsListForActiveCheck;

        private List<AdvertisingProductsModel> filterAdvProductsList;       //список Sponsored Products с применением фильтра по таблице
        private List<AdvertisingBrandsModel> filterAdvBrandsList;           //список Sponsored Brands с применением фильтра по таблице

        private string equalSign;       //знак равенства из textBox
        private bool NoErrors;          //ошибка ввода в textBox пользователем при фильтре по таблице

        /* Главный конструктор */
        public ReportAdvertisingFilterView(ReportAdvertisingView _mf)
        {
            InitializeComponent();

            mf = _mf;
            MonthlyMode = false;
            WeeklyMode = false;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59);
            
            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = StartDate.ToString().Substring(0, 10);


            advProductsList = new List<AdvertisingProductsModel> { };
            advProductsListOriginal = new List<AdvertisingProductsModel> { };
            summaryAdvProductsList = new List<AdvertisingProductsModel> { };
            advBrandsList = new List<AdvertisingBrandsModel> { };
            summaryAdvBrandsList = new List<AdvertisingBrandsModel> { };
            mpList = new List<MarketplaceModel> { };
            campTList = new List<CampaignTypesModel> { };
            pList = new List<ProductsModel> { };

            mpController = new MarketplaceController(this);
            campTController = new CampaignTypesController(this);
            advertController = new AdvertisingController(this);
            prodController = new ProductsController(this);


            AP_campaignIdsList = new List<MapNameId> { };
            AB_campaignIdsList = new List<MapNameId> { };

            filterAdvProductsList = new List<AdvertisingProductsModel> { };
            filterAdvBrandsList = new List<AdvertisingBrandsModel> { };

            if (campTController.GetCampaignTypes() == 1)
                Fill_CB_CampaignTypes();


            if (mpController.GetMarketplaces() == 1)
                Fill_CLB_Marketplace();

            advertController.GetAP_CampaignIds();
            advertController.GetAB_CampaignIds();

            checkedMarkeplaces = new List<string> { };
            checkedProducts = new List<string> { };
            checkedCampaigns = new List <string> { };
            checkedAdGroups = new List<string> { };
            adGroupsList = new List<string> { };

            checkedMarkeplacesTMP = new List<string> { };
            checkedProductsTMP = new List<string> { };
            checkedCampaignsTMP = new List<string> { };
            checkedAdGroupsTMP = new List<string> { };

            tbProductsFilterItems = new List<string> { };
            tbCampaignsFilterItems = new List<string> { };
            tbAdGroupsFilterItems = new List<string> { };

            tbProductsFilterItemsPrev = new List<string> { };
            tbCampaignsFilterItemsPrev = new List<string> { };
            tbAdGroupsFilterItemsPrev = new List<string> { };

            cb_MatchType.SelectedIndex = 0;

            byTargetingInAdGroupsToolStripMenuItem.Checked = true;
            by_CustomToolStripMenuItem.Checked = true;
            DisableCustomTimeMode();
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

        /* Заполняем combobox названиями кампаний */
        private void Fill_CB_CampaignTypes()
        {
            cb_CampaignType.Items.Clear();

            for (int i = 0; i < campTList.Count; i++)
            {
                cb_CampaignType.Items.Add(campTList[i].CampaignName);
            }
            
            cb_CampaignType.SelectedIndex = 0;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Campaign Types, полученные с БД */
        public void GetCampaignTypesFromDB(object _campTList)
        {
            campTList = (List<CampaignTypesModel>)_campTList;
        }
        
        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД и суммируем значения */
        public void GetAdvertisingProductsFromDBwithSummary(object _advProductList)
        {
            advProductsList = (List<AdvertisingProductsModel>)_advProductList;
            if (by_CustomToolStripMenuItem.Checked)
            {
                summaryAdvProductsList.Clear();
                if (byTargetingInAdGroupsToolStripMenuItem.Checked)
                {
                    MakeSummaryAdvProductListbyTargetingInAdGroups();
                }
                else if (byAdGroupsInCampaignsToolStripMenuItem.Checked)
                {
                    MakeSummaryAdvProductListbyAdGroupsInCampaigns();
                }
                else if (byCampaignInProductsToolStripMenuItem.Checked)
                {
                    MakeSummaryAdvProductListbyCampaignInProducts();
                }
                else if (byProductsToolStripMenuItem.Checked)
                {
                    MakeSummaryAdvProductListbyProducts();
                }
            }
            /*else
            {
                summaryAdvProductsList.Clear();
                if (byTargetingInAdGroupsToolStripMenuItem.Checked)
                {
                    //MakeSummaryAdvProductListbyTargetingInAdGroups();
                }
                else if (byAdGroupsInCampaignsToolStripMenuItem.Checked)
                {
                    MakeAdvProductListbyAdGroupsInCampaignsForDifferentTimeMode();
                }
                else if (byCampaignInProductsToolStripMenuItem.Checked)
                {
                    MakeSummaryAdvProductListbyCampaignInProducts();
                }
                else if (byProductsToolStripMenuItem.Checked)
                {
                    MakeSummaryAdvProductListbyProducts();
                }
            }*/
        }

        private void MakeAdvProductListbyAdGroupsInCampaignsForDifferentTimeMode()
        {

        }

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetAdvertisingProductsFromDBOriginalValues(object _advProductList)
        {
            advProductsListOriginal = (List<AdvertisingProductsModel>)_advProductList;
        }

        /* Получаем из контроллера Advertising Brands, полученные с БД */
        public void GetAdvertisingBrandsFromDB(object _advBrandList)
        {
            //advBrandsList = (List<AdvertisingBrandsModel>)_advBrandList;

            //summaryAdvBrandsList.Clear();
            //MakeSummaryAdvBrandList();
        }


        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyProducts()
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

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (i == advProductsList.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedProductIds.Contains(advProductsList[i].ProductId))
                {
                    Impressions = advProductsList[i].Impressions;
                    Clicks = advProductsList[i].Clicks;
                    Spend = advProductsList[i].Spend;
                    Sales = advProductsList[i].Sales;
                    Orders = advProductsList[i].Orders;
                    Units = advProductsList[i].Units;
                    AdvSKUUnits = advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList[i].AdvSKUSales;
                    OtherSKUSales = advProductsList[i].OtherSKUSales;

                    if (i < (advProductsList.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList.Count; j++)
                        {
                            if (advProductsList[i].ProductId == advProductsList[j].ProductId)
                            {
                                Impressions += advProductsList[j].Impressions;
                                Clicks += advProductsList[j].Clicks;
                                Spend += advProductsList[j].Spend;
                                Sales += advProductsList[j].Sales;
                                Orders += advProductsList[j].Orders;
                                Units += advProductsList[j].Units;
                                AdvSKUUnits += advProductsList[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList[j].AdvSKUSales;
                                OtherSKUSales += advProductsList[j].OtherSKUSales;
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


                    summaryAdvProductsList.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].UpdateDate = advProductsList[i].UpdateDate;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CurrencyCharCode = advProductsList[i].CurrencyCharCode;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignName = advProductsList[i].CampaignName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdGroupName = advProductsList[i].AdGroupName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Targeting = advProductsList[i].Targeting;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MatchType = advProductsList[i].MatchType;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Orders = Orders;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Units = Units;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignTypeId = advProductsList[i].CampaignTypeId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MarketPlaceId = advProductsList[i].MarketPlaceId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignId = advProductsList[i].CampaignId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ProductId = advProductsList[i].ProductId;

                    alreadyUsedProductIds.Add(advProductsList[i].ProductId);
                }
            }
            advProductsList.Clear();
            foreach (var t in summaryAdvProductsList)
            {
                advProductsList.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyCampaignInProducts()
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

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (i == advProductsList.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedCampaigns.Contains(advProductsList[i].CampaignName))
                {
                    Impressions = advProductsList[i].Impressions;
                    Clicks = advProductsList[i].Clicks;
                    Spend = advProductsList[i].Spend;
                    Sales = advProductsList[i].Sales;
                    Orders = advProductsList[i].Orders;
                    Units = advProductsList[i].Units;
                    AdvSKUUnits = advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList[i].AdvSKUSales;
                    OtherSKUSales = advProductsList[i].OtherSKUSales;

                    if (i < (advProductsList.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList.Count; j++)
                        {
                            if (advProductsList[i].CampaignName.Equals(advProductsList[j].CampaignName) && advProductsList[i].MatchType.Equals(advProductsList[j].MatchType))
                            {
                                Impressions += advProductsList[j].Impressions;
                                Clicks += advProductsList[j].Clicks;
                                Spend += advProductsList[j].Spend;
                                Sales += advProductsList[j].Sales;
                                Orders += advProductsList[j].Orders;
                                Units += advProductsList[j].Units;
                                AdvSKUUnits += advProductsList[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList[j].AdvSKUSales;
                                OtherSKUSales += advProductsList[j].OtherSKUSales;
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


                    summaryAdvProductsList.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].UpdateDate = advProductsList[i].UpdateDate;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CurrencyCharCode = advProductsList[i].CurrencyCharCode;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignName = advProductsList[i].CampaignName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdGroupName = advProductsList[i].AdGroupName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Targeting = advProductsList[i].Targeting;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MatchType = advProductsList[i].MatchType;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Orders = Orders;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Units = Units;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignTypeId = advProductsList[i].CampaignTypeId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MarketPlaceId = advProductsList[i].MarketPlaceId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignId = advProductsList[i].CampaignId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ProductId = advProductsList[i].ProductId;

                    alreadyUsedCampaigns.Add(advProductsList[i].CampaignName);
                }
            }
            advProductsList.Clear();
            foreach (var t in summaryAdvProductsList)
            {
                advProductsList.Add(t);
            }
        }
            

        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyAdGroupsInCampaigns()
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

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (i == advProductsList.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i) && !alreadyUsedAdGroups.Contains(advProductsList[i].AdGroupName))
                {
                    Impressions = advProductsList[i].Impressions;
                    Clicks = advProductsList[i].Clicks;
                    Spend = advProductsList[i].Spend;
                    Sales = advProductsList[i].Sales;
                    Orders = advProductsList[i].Orders;
                    Units = advProductsList[i].Units;
                    AdvSKUUnits = advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList[i].AdvSKUSales;
                    OtherSKUSales = advProductsList[i].OtherSKUSales;

                    if (i < (advProductsList.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList.Count; j++)
                        {
                            if (advProductsList[i].CampaignName.Equals(advProductsList[j].CampaignName) && advProductsList[i].AdGroupName.Equals(advProductsList[j].AdGroupName) && advProductsList[i].MatchType.Equals(advProductsList[j].MatchType))
                            {
                                Impressions += advProductsList[j].Impressions;
                                Clicks += advProductsList[j].Clicks;
                                Spend += advProductsList[j].Spend;
                                Sales += advProductsList[j].Sales;
                                Orders += advProductsList[j].Orders;
                                Units += advProductsList[j].Units;
                                AdvSKUUnits += advProductsList[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList[j].AdvSKUSales;
                                OtherSKUSales += advProductsList[j].OtherSKUSales;
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


                    summaryAdvProductsList.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].UpdateDate = advProductsList[i].UpdateDate;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CurrencyCharCode = advProductsList[i].CurrencyCharCode;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignName = advProductsList[i].CampaignName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdGroupName = advProductsList[i].AdGroupName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Targeting = advProductsList[i].Targeting;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MatchType = advProductsList[i].MatchType;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Orders = Orders;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Units = Units;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignTypeId = advProductsList[i].CampaignTypeId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MarketPlaceId = advProductsList[i].MarketPlaceId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignId = advProductsList[i].CampaignId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ProductId = advProductsList[i].ProductId;

                    alreadyUsedAdGroups.Add(advProductsList[i].AdGroupName);
                }
            }
            advProductsList.Clear();
            foreach (var t in summaryAdvProductsList)
            {
                advProductsList.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyTargetingInAdGroups()
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

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (i == advProductsList.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsList[i].Impressions;
                    Clicks = advProductsList[i].Clicks;
                    Spend = advProductsList[i].Spend;
                    Sales = advProductsList[i].Sales;
                    Orders = advProductsList[i].Orders;
                    Units = advProductsList[i].Units;
                    AdvSKUUnits = advProductsList[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsList[i].OtherSKUUnits;
                    AdvSKUSales = advProductsList[i].AdvSKUSales;
                    OtherSKUSales = advProductsList[i].OtherSKUSales;

                    if (i < (advProductsList.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsList.Count; j++)
                        {
                            //if (SummaryAdvProdListComparing(advProductsList[i].CampaignName, advProductsList[j].CampaignName,  advProductsList[i].AdGroupName, advProductsList[j].AdGroupName, advProductsList[i].Targeting, advProductsList[j].Targeting, advProductsList[i].MatchType, advProductsList[j].MatchType, advProductsList[i].ProductId, advProductsList[j].ProductId))
                            if (advProductsList[i].CampaignName.Equals(advProductsList[j].CampaignName) && advProductsList[i].AdGroupName.Equals(advProductsList[j].AdGroupName) && advProductsList[i].Targeting.Equals(advProductsList[j].Targeting) && advProductsList[i].MatchType.Equals(advProductsList[j].MatchType))
                            {
                                Impressions += advProductsList[j].Impressions;
                                Clicks += advProductsList[j].Clicks;
                                Spend += advProductsList[j].Spend;
                                Sales += advProductsList[j].Sales;
                                Orders += advProductsList[j].Orders;
                                Units += advProductsList[j].Units;
                                AdvSKUUnits += advProductsList[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsList[j].OtherSKUUnits;
                                AdvSKUSales += advProductsList[j].AdvSKUSales;
                                OtherSKUSales += advProductsList[j].OtherSKUSales;
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


                    summaryAdvProductsList.Add(new AdvertisingProductsModel());

                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].UpdateDate = advProductsList[i].UpdateDate;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CurrencyCharCode = advProductsList[i].CurrencyCharCode;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignName = advProductsList[i].CampaignName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdGroupName = advProductsList[i].AdGroupName;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Targeting = advProductsList[i].Targeting;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MatchType = advProductsList[i].MatchType;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Impressions = Impressions;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Clicks = Clicks;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Orders = Orders;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Units = Units;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignTypeId = advProductsList[i].CampaignTypeId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].MarketPlaceId = advProductsList[i].MarketPlaceId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].CampaignId = advProductsList[i].CampaignId;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].ProductId = advProductsList[i].ProductId;
                }
            }
            advProductsList.Clear();
            foreach (var t in summaryAdvProductsList)
            {
                advProductsList.Add(t);
            }
        }

        /* Получаем id кампании по выбранному имени в combobox */
        private int GetCampaignTypeIdByName(string _name)
        {
            for (int i = 0; i < campTList.Count; i++)
            {
                if (cb_CampaignType.SelectedItem.ToString().Equals(campTList[i].CampaignName))
                    return campTList[i].CampaignId;
            }
            return -1;
        }

        /* Получаем id маркетплейса по выбранному имени в combobox */
        private int GetMarketPlaceIdByName(string _name)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                //if (clb_MarketPlace.SelectedItem.ToString().Equals(mpList[i].MarketPlaceName))
                  //  return mpList[i].MarketPlaceId;
            }
            return 1;
        }











        /* Включаем режим отображения по неделям */
        private void btn_Weekly_Click(object sender, EventArgs e)
        {
            WeeklyMode = true;
            MonthlyMode = false;
        }

        /* Включаем режим отображения по месяцам */
        private void btn_Montly_Click(object sender, EventArgs e)
        {
            WeeklyMode = false;
            MonthlyMode = true;
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

        /* Закрываем окно, разрешаем создавать новое */
        private void AdvertisingReportFilterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mf.Enabled)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {

            }
            //mf.ClosingFilter();
        }
        
        private List<string> CleanCheckedAdGroups(List<string> checkedAdGroups)
        {
            List<string> result = new List<string> { };
            string tmp = "";

            for (int i = 0; i < checkedAdGroups.Count; i++)
            {
                tmp = checkedAdGroups[i];
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

        /* Применяем фильтры и перерисовываем данные в форме AdvertisingReportView */
        private void btn_Show_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            if (StartDate > EndDate)
                MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

            mf.AdvertisingProductsShowMode = true;
            mf.AdGroupShowMode = false;
            mf.TargetingShowMode = false;

            mf.StartDate = StartDate;
            mf.EndDate = EndDate;


            if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Products"))
            {
                mf.SponsoredProductMode = true;
                mf.SponsoredBrandMode = false;

                int result = 0;
                advProductsList = null;

                result = advertController.GetFinalAdvertisingProductsReport(StartDate, EndDate, GetMPIdsByNames(checkedMarkeplaces), GetProductIdsByNames(checkedProducts), GetCampaignIdsByNames(campsidsList), CleanCheckedAdGroups(checkedAdGroups));

                if (result == 1)
                {
                    if (byTargetingInAdGroupsToolStripMenuItem.Checked)
                        mf.GetAdvertisingProductsListToShow(advProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), "", GetProductIdByName(checkedProducts));
                    else if (byAdGroupsInCampaignsToolStripMenuItem.Checked && !GetFirstAdGroup().Equals(""))
                        mf.GetAdvertisingProductsListToShow(advProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), GetFirstAdGroup(), GetProductIdByName(checkedProducts));
                    else if (byCampaignInProductsToolStripMenuItem.Checked && !GetFirstCampaign().Equals(""))
                        mf.GetAdvertisingProductsListToShow(advProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), GetFirstCampaign(), GetProductIdByName(checkedProducts));
                    else if (byProductsToolStripMenuItem.Checked && CheckForExistingProducts())
                        mf.GetAdvertisingProductsListToShow(advProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), GetProductsAsins(), GetProductIdByName(checkedProducts));
                    filterAdvProductsList = new List<AdvertisingProductsModel> { };
                }
                
                if (mf.dgv_AdvProducts.RowCount > 0)
                    groupBox1.Enabled = true;
                else
                    groupBox1.Enabled = false;
            }
            /*else if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Brands"))
            {
                mf.SponsoredProductMode = false;
                mf.SponsoredBrandMode = true;

                int result = 0;
                advBrandsList = null;

                result = advertController.GetFinalAdvertisingBrandsReport(StartDate, EndDate, GetMPIdsByNames(checkedMarkeplaces), GetProductIdsByNames(checkedProducts), GetCampaignIdsByNames(campsidsList));

                if (result == 1)
                {
                    mf.GetAdvertisingBrandsListToShow(advBrandsList);
                    filterAdvBrandsList = new List<AdvertisingBrandsModel> { };
                }

                if (mf.dgv_AdvBrands.RowCount > 0)
                    groupBox1.Enabled = true;
                else
                    groupBox1.Enabled = false;
            }*/
            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private string GetFirstAdGroup()
        {
            if (checkedAdGroups.Count > 0)
            {
                return checkedAdGroups[0];
            }
            else
            {
                if (clb_AdGroup.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите рекламную кампанию!", "Ошибка");
                else
                {
                    return clb_AdGroup.Items[0].ToString();
                }
            }
            return "";
        }

        private string GetFirstCampaign()
        {
            if (checkedCampaigns.Count > 0)
            {
                return checkedCampaigns[0];
            }
            else
            {
                if (clb_Campaign.Items.Count == 0)
                    MessageBox.Show("Для продолжения выберите товар!", "Ошибка");
                else
                {
                    return clb_Campaign.Items[0].ToString();
                }
            }
            return "";
        }

        private bool CheckForExistingProducts()
        {
            if (clb_Product.Items.Count == 0)
                MessageBox.Show("Для продолжения выберите маркетплейс!", "Ошибка");
            else if (checkedProducts.Count > 0 || clb_Product.Items.Count > 0)
                return true;
            return false;
        }

        private string GetProductsAsins()
        {
            string result = "";
            string name = "";
            string asin = "";

            if (checkedProducts.Count > 0)
            {
                name = checkedProducts[0];                
            }
            else
            {
                name = clb_Product.Items[0].ToString();
            }

            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].Name.Equals(name))
                    asin = pList[i].ASIN;
            }
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ASIN.Equals(asin))
                    result = result + pList[i].ProductId + ", ";
            }

            return result;
        }

        public string GetProductNameFromAsins(string _asins)
        {
            string idStr = "";
            int idInt = 0;
            bool flag = false;
            for (int i = 0; i < _asins.Length; i++)
            {
                if (_asins[i].Equals(',') &&!flag)
                {
                    idStr = _asins.Substring(0, i);
                    flag = true;
                }
            }
            idInt = int.Parse(idStr);
            for (int i = 0; i < pList.Count; i++)
            {
                if (idInt == pList[i].ProductId)
                    return pList[i].Name;
            }
            return "";
        }

        private string GetCompareMode()
        {
            if (byTargetingInAdGroupsToolStripMenuItem.Checked)
            {
                return "targetinginadgroups";
            }
            else if (byAdGroupsInCampaignsToolStripMenuItem.Checked)
            {
                return "adgroupsincampaigns";
            }
            else if (byCampaignInProductsToolStripMenuItem.Checked)
            {
                return "campaigninproducts";
            }
            else if (byProductsToolStripMenuItem.Checked)
            {
                return "productsinmarketplaces";
            }
            return "";
        }

        private string GetDateMode()
        {
            if (by_DaysToolStripMenuItem.Checked)
            {
                return "days";
            }
            else if (by_WeeksToolStripMenuItem.Checked)
            {
                return "weeks";
            }
            else if (by_MonthsToolStripMenuItem.Checked)
            {
                return "months";
            }
            else if (by_CustomToolStripMenuItem.Checked)
            {
                return "custom";
            }
            return "";
        }


        /* Изменение отмеченных элементов в cb_CampaignType */
        private void cb_CampaignType_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedMarkeplaces = new List<string> { };
            checkedProducts = new List<string> { };
            checkedCampaigns = new List<string> { };
            
            clb_Campaign.ClearSelected();
            clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();
            clb_Product.ClearSelected();
            clb_Product.Items.Clear();
            checkedProducts.Clear();
            checkedMarkeplaces.Clear();
            clb_Marketplace.ClearSelected();


            for (int i = 0; i < clb_Marketplace.Items.Count; i++)
            {
                clb_Marketplace.SetItemChecked(i, false);
            }
            clb_Campaign.Items.Clear();
            clb_Product.Items.Clear();

            tb_Impressions.Text = "";
            tb_Clicks.Text = "";
            tb_CTR.Text = "";
            tb_CPC.Text = "";
            tb_Spend.Text = "";
            tb_ACoS.Text = "";
            tb_Sales.Text = "";
            tb_Orders.Text = "";
            tb_Units.Text = "";

            groupBox1.Enabled = false;

            if (cb_CampaignType.SelectedIndex == 0)
                tb_SearchByAdGroup.Enabled = true;
            else
                tb_SearchByAdGroup.Enabled = false;
        }



        //----------------------------------------------------------------------------------------------------------------------

        /* Выделяем/снимаем выделение маркетплейса в clb_Marketplace */
        private void clb_Marketplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            clb_Campaign.ClearSelected();
            clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();

            checkedMarkeplaces.Clear();
            for (int i = 0; i < clb_Marketplace.CheckedItems.Count; i++)
            {
                checkedMarkeplaces.Add(clb_Marketplace.CheckedItems[i].ToString());
            }

            checkedCampaigns.Clear();
            for (int i = 0; i < clb_Campaign.Items.Count; i++)
            {
                clb_Campaign.SetItemChecked(i, false);
            }
            clb_Campaign.Items.Clear();

            clb_AdGroup.ClearSelected();
            clb_AdGroup.Items.Clear();
            checkedAdGroups.Clear();

            if (checkedMarkeplaces.Count > 0)
            {
                int res = 0;

                if (cb_WithInactive.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames(checkedMarkeplaces));
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames(checkedMarkeplaces));
                }

                if (res == 1)
                {
                    Draw_clb_Products();
                }
            }
            else { clb_Product.Items.Clear(); }

            disableTbClbFilter();
        }
        

        /* Меняем режим отображения с активными/неактивными товарами */
        private void cb_WithInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces.Count > 0)
            {
                clb_Product.ClearSelected();
                checkedProducts.Clear();

                clb_AdGroup.Items.Clear();
                checkedAdGroups.Clear();

                clb_Campaign.Items.Clear();
                checkedCampaigns.Clear();

                int res = 0;

                if (cb_WithInactive.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames(checkedMarkeplaces));
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames(checkedMarkeplaces));
                }

                if (res == 1)
                {
                    Draw_clb_Products();
                }
            }
        }


        private void cb_WithoutAdvertising_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedMarkeplaces.Count > 0)
            {
                clb_Product.ClearSelected();
                checkedProducts.Clear();

                clb_AdGroup.Items.Clear();
                checkedAdGroups.Clear();

                clb_Campaign.Items.Clear();
                checkedCampaigns.Clear();

                int res = 0;
                if (cb_WithInactive.Checked)
                {
                    res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames(checkedMarkeplaces));
                }
                else
                {
                    res = prodController.GetProductsByFewMarketplaceIdActive(GetMPIdsByNames(checkedMarkeplaces));
                }

                if (res == 1)
                {
                    Draw_clb_Products();
                }
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
            List<string> names = new List<string> { };
            List<string> finalNames = new List<string> { };
            
            if (cb_WithoutAdvertising.Checked || cb_WithInactive.Checked)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (!names.Contains(pList[i].Name))
                        names.Add(pList[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    foreach (var t in AP_campaignIdsListForActiveCheck)
                    {
                        if (t.Name.Contains(pList[i].ProdShortName))
                            if (!names.Contains(pList[i].Name))
                                names.Add(pList[i].Name);
                    }
                }
            }

            clb_Product.Items.Clear();
            for (int i = 0; i < names.Count; i++)
            {
                clb_Product.Items.Add(names[i]);
            }
        }

        /* Очистить список выбранных маркетплейсов в clb_Marketplace */
        private void btn_Clear_clb_Marketplace_Click(object sender, EventArgs e)
        {
            clb_Marketplace.ClearSelected();
            checkedMarkeplaces.Clear();

            clb_AdGroup.ClearSelected();
            clb_AdGroup.Items.Clear();
            checkedAdGroups.Clear();

            clb_Campaign.ClearSelected();
            clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();

            clb_Product.ClearSelected();
            clb_Product.Items.Clear();
            checkedProducts.Clear();

            
            for (int i = 0; i < clb_Marketplace.Items.Count; i++)
            {
                clb_Marketplace.SetItemChecked(i, false);
            }
            clb_Campaign.Items.Clear();
            clb_Product.Items.Clear();

            disableTbClbFilter();
        }
        //----------------------------------------------------------------------------------------------------------------------


        /* Выделяем/снимаем выделение товара в clb_Product */
        private void clb_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
            clb_AdGroup.ClearSelected();
            clb_AdGroup.Items.Clear();
            checkedAdGroups.Clear();

            //clb_Campaign.ClearSelected();
            //clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();

            for (int i = 0; i < clb_Campaign.Items.Count; i++)
            {
                clb_Campaign.SetItemChecked(i, false);
            }       
            */
            //clb_Campaign.ClearSelected();
            //clb_Campaign.Items.Clear();
            checkedProductsTMP.Clear();
            for (int i = 0; i < clb_Product.CheckedItems.Count; i++)
            {
                checkedProductsTMP.Add(clb_Product.CheckedItems[i].ToString());
            }

            checkedProducts.Clear();

            foreach (var t in checkedProductsTMP)
            {
                checkedProducts.Add(t);
            }

            //checkedProducts.Clear();
            //for (int i = 0; i < clb_Product.CheckedItems.Count; i++)
            //{
            //    checkedProducts.Add(clb_Product.CheckedItems[i].ToString());
            //}

            //checkedCampaigns.Clear();
            //for (int i = 0; i < clb_Campaign.Items.Count; i++)
            //{
            //    clb_Campaign.SetItemChecked(i, false);
            //}
            //clb_Campaign.Items.Clear();

            //clb_AdGroup.ClearSelected();
            //clb_AdGroup.Items.Clear();
            //checkedAdGroups.Clear();

            int res = 0;
            if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Products"))
            {
                if (checkedProducts.Count > 0)
                {
                    res = advertController.GetAdvertisingProductsCampaignAndCampId(GetProductIdsByNames(checkedProducts));
                    GetUniqueCampaigns();
                }
                else
                {
                    clb_Campaign.Items.Clear();
                    checkedCampaigns.Clear();

                    clb_AdGroup.Items.Clear();
                    checkedAdGroups.Clear();
                }
            }
            //else if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Brands"))
            //{
            //    res = advertController.GetAdvertisingBrandsCampaignAndCampId(GetProductIdsByNames(checkedProducts));
            //    GetUniqueCampaigns();
            //}
            if (res == 1)
            {
                Draw_clb_Campaigns();
            }

            if (clb_Campaign.Items.Count > 0)
                tb_clbCampaignFilter.Enabled = true;
            else
                tb_clbCampaignFilter.Enabled = false;

            disableTbClbFilter();
        }
        /* Выделяем/снимаем выделение товара в clb_AdGroups */

        private void clb_AdGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedAdGroups.Clear();
            for (int i = 0; i < clb_AdGroup.CheckedItems.Count; i++)
            {
                checkedAdGroups.Add(clb_AdGroup.CheckedItems[i].ToString());
            }

            disableTbClbFilter();
        }

        public void GetAP_CampaignIdsFromDB(object _campTList)
        {
            AP_campaignIdsListForActiveCheck = (List<MapNameId>)_campTList;
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

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName(List<string> _checkedProducts)
        {
            if (checkedProducts.Count > 0)
                for (int i = 0; i < pList.Count; i++)
                {
                    if (pList[i].Name.Equals(checkedProducts[0]))
                        return pList[i].ProductId;
                }
            return -1;
        }

        /* Получаем список ProductId по выделенным ProductName */
        private int GetProductIdByName(string _checkedProduct)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].Name.Equals(_checkedProduct))
                    return pList[i].ProductId;
            }
            return -1;
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueCampaigns()
        {
            uniqueCampaigns = new List<string> { };
            tbCampaignsFilterItemsPrev = new List<string> { };

            for (int i = 0; i < campsidsList.Count; i++)
            {
                if (!uniqueCampaigns.Contains(campsidsList[i].Key))
                {
                    uniqueCampaigns.Add(campsidsList[i].Key);
                    tbCampaignsFilterItemsPrev.Add(uniqueCampaigns[uniqueCampaigns.Count - 1]);
                }
            }
        }

        /* Получаем список кампания/кампания_ид из БД */
        public void GetCampaignsAndIds(object _tmp)
        {
            campsidsList = (List<CmapaignAndIdStruct>)_tmp;
        }

        /* Получаем список кампания/кампания_ид из БД */
        public void GetAdGroups(object _tmp)
        {
            adGroupsList = (List<string>)_tmp;
        }

        /* Заносим имена кампаний в clb_Campaigns */
        private void Draw_clb_Campaigns()
        {
            clb_Campaign.Items.Clear();
            checkedCampaignsTMP.Clear();
            for (int i = 0; i < uniqueCampaigns.Count; i++)
            {
                clb_Campaign.Items.Add(uniqueCampaigns[i]);
                if (checkedCampaigns.Contains(uniqueCampaigns[i]))
                {
                    clb_Campaign.SetItemChecked(clb_Campaign.Items.Count - 1, true);
                    checkedCampaignsTMP.Add(uniqueCampaigns[i]);
                }
            }
            
            checkedCampaigns.Clear();

            foreach (var t in checkedCampaignsTMP)
            {
                checkedCampaigns.Add(t);
            }

            if (checkedCampaigns.Count == 0)
            {
                clb_AdGroup.Items.Clear();
                checkedAdGroups.Clear();
            }
        }

        /* Очистить список выбранных товаров в clb_Products */
        private void btn_Clear_clb_Products_Click(object sender, EventArgs e)
        {
            clb_Product.ClearSelected();
            checkedProducts.Clear();
            
            clb_AdGroup.Items.Clear();
            checkedAdGroups.Clear();
            
            clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();


            for (int i = 0; i < clb_Product.Items.Count; i++)
            {
                clb_Product.SetItemChecked(i, false);
            }
            clb_Campaign.Items.Clear();

            disableTbClbFilter();
        }

        //----------------------------------------------------------------------------------------------------------------------

        /* Выделяем/снимаем выделение кампании в clb_Campaign */
        private void clb_Campaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tb_clbCampaignFilter.Text.Equals(""))
            //{           
            checkedCampaignsTMP.Clear();
            for (int i = 0; i < clb_Campaign.CheckedItems.Count; i++)
            {
                checkedCampaignsTMP.Add(clb_Campaign.CheckedItems[i].ToString());
            }

            checkedCampaigns.Clear();

            foreach (var t in checkedCampaignsTMP)
            {
                checkedCampaigns.Add(t);
            }

            List<string> finalAdGroupList = new List<string> { };
            int res = 0;
            int prodId = -1;
            if (checkedCampaigns.Count > 0)
            {
                for (int i = 0; i < checkedProducts.Count; i++)
                {
                    prodId = GetProductIdByName(checkedProducts[i]);
                    for (int j = 0; j < checkedCampaigns.Count; j++)
                    {
                        res = advertController.GetAdvertisingProductsAdgroups(prodId, checkedCampaigns[j]);
                        if (res == 1)
                        {
                            for (int t = 0; t < adGroupsList.Count; t++)
                            {
                                adGroupsList[t] = adGroupsList[t] + " (" + checkedCampaigns[j] + ")";
                                finalAdGroupList.Add(adGroupsList[t]);
                            }
                        }
                    }
                }

                GetUniqueAdGroups(finalAdGroupList);

                if (res == 1)
                {
                    Draw_clb_AdGroups();
                }
            }
            else
            {
                clb_AdGroup.Items.Clear();
                checkedAdGroups.Clear();
            }


            if (clb_AdGroup.Items.Count > 0)
                tb_clbAdGroupFilter.Enabled = true;
            else
                tb_clbAdGroupFilter.Enabled = false;

            disableTbClbFilter();
            //}
        }

        /* Получаем уникальные названия товаров */
        private void GetUniqueAdGroups(List<string> _finalAdGroupList)
        {
            tbAdGroupsFilterItemsPrev.Clear();
            uniqueAdGroups = new List<string> { };
            for (int i = 0; i < _finalAdGroupList.Count; i++)
            {
                if (!uniqueAdGroups.Contains(_finalAdGroupList[i]))
                {
                    uniqueAdGroups.Add(_finalAdGroupList[i]);
                    tbAdGroupsFilterItemsPrev.Add(uniqueAdGroups[uniqueAdGroups.Count - 1]);
                }
            }
        }

        /* Заносим имена кампаний в clb_AdGroups */
        private void Draw_clb_AdGroups()
        {
            clb_AdGroup.Items.Clear();
            for (int i = 0; i < uniqueAdGroups.Count; i++)
            {
                clb_AdGroup.Items.Add(uniqueAdGroups[i]);
                if (checkedAdGroups.Contains(uniqueAdGroups[i]))
                {
                    clb_AdGroup.SetItemChecked(clb_AdGroup.Items.Count - 1, true);
                    checkedAdGroupsTMP.Add(uniqueAdGroups[i]);
                }
            }

            checkedAdGroups.Clear();

            foreach(var t in checkedAdGroupsTMP)
            {
                checkedAdGroups.Add(t);
            }
        }

        /* Получаем список CampaignId по выделенным Campaign */
        private List<int> GetCampaignIdsByNames(List<CmapaignAndIdStruct> _campsidsList)
        {
            List<int> resultList = new List<int> { };
            List<CmapaignAndIdStruct> test = new List<CmapaignAndIdStruct> { };
            bool flag = false;

            for (int i = 0; i < checkedCampaigns.Count; i++)
            {
                flag = false;
                for (int j = 0; j < campsidsList.Count; j++)
                {
                    if (!flag && checkedCampaigns[i].Equals(campsidsList[j].Key))
                    {
                        resultList.Add(campsidsList[j].Val);
                        flag = true;
                    }
                }
            }            
            return resultList;
        }

        /* Очистить список выбранных кампаний в clb_Campaigns */
        private void btn_Clear_clb_Campaigns_Click(object sender, EventArgs e)
        {
            clb_AdGroup.ClearSelected();
            clb_AdGroup.Items.Clear();
            checkedAdGroups.Clear();

            //clb_Campaign.ClearSelected();
            //clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();

            for (int i = 0; i < clb_Campaign.Items.Count; i++)
            {
                clb_Campaign.SetItemChecked(i, false);
            }

            disableTbClbFilter();
        }

        /* Отправляем список товаров по adGroups после двойного ЛКМ в dgv */
        public void ShowDetailedByAdGroup(string _adGroupName, int _marketpLaceId, int _campaignId, int _productId, object _advProductsList)
        {
            List<AdvertisingProductsModel> newAdvProductsList = new List<AdvertisingProductsModel> { };
            List<AdvertisingProductsModel> _newAdvProductsList = (List<AdvertisingProductsModel>)_advProductsList;
            
            for (int i = 0; i < _newAdvProductsList.Count; i++)
            {
                if (_newAdvProductsList[i].MarketPlaceId == _marketpLaceId && _newAdvProductsList[i].ProductId == _productId && _newAdvProductsList[i].CampaignId == _campaignId && _newAdvProductsList[i].AdGroupName.Equals(_adGroupName))
                {
                    newAdvProductsList.Add(new AdvertisingProductsModel());
                    newAdvProductsList[newAdvProductsList.Count - 1] = _newAdvProductsList[i];
                }
            }

            mf.GetAdGroupsListToShow(newAdvProductsList);
        }

        /* Отправляем список товаров по Targeting после двойного ЛКМ в dgv */
        public void ShowDetailedByTargeting(string _Targeting, string _adGroupName, int _marketpLaceId, int _campaignId, int _productId, object _advProductsList)
        {
            List<AdvertisingProductsModel> newAdvProductsList = new List<AdvertisingProductsModel> { };
            List<AdvertisingProductsModel> _newAdvProductsList = (List<AdvertisingProductsModel>)_advProductsList;

            for (int i = 0; i < _newAdvProductsList.Count; i++)
            {
                if (_newAdvProductsList[i].MarketPlaceId == _marketpLaceId && _newAdvProductsList[i].ProductId == _productId && _newAdvProductsList[i].CampaignId == _campaignId && _newAdvProductsList[i].AdGroupName.Equals(_adGroupName) && _newAdvProductsList[i].Targeting.Equals(_Targeting))
                {
                    newAdvProductsList.Add(new AdvertisingProductsModel());
                    newAdvProductsList[newAdvProductsList.Count - 1] = _newAdvProductsList[i];
                }
            }

            mf.GetTargetingListToShow(newAdvProductsList);
        }
        
        /* По таймеру подсвечиваем textBox с ошибкой ввода */
        private void timer1_Tick(object sender, EventArgs e)
        {
            tb_Impressions.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Clicks.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_CTR.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_CPC.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Spend.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_ACoS.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Sales.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Orders.BackColor = Color.FromKnownColor(KnownColor.Window);
            tb_Units.BackColor = Color.FromKnownColor(KnownColor.Window);

            timer1.Stop();
        }

        /* Применить поиск по слову в таблице */
        private void btn_SearchBy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            NoErrors = true;

            if (mf.SponsoredProductMode)                //если имеем дело с Sponsored Products
            {
                filterAdvProductsList = new List<AdvertisingProductsModel> { };
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    if (SearchByCampaign(advProductsList[i].CampaignName.ToLower(), tb_SearchByCampaign.Text.ToLower()) && SearchByAdGroup(advProductsList[i].AdGroupName.ToLower(), tb_SearchByAdGroup.Text.ToLower()) && SearchByTargeting(advProductsList[i].Targeting.ToLower(), tb_SearchByTargeting.Text.ToLower()))
                    {
                        filterAdvProductsList.Add(advProductsList[i]);
                    }
                }

                if (NoErrors)
                    mf.GetAdvertisingProductsListToShow(filterAdvProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), "", GetProductIdByName(checkedProducts));
            }
            //else if (mf.SponsoredBrandMode)             //если имеем дело с Sponsored Brands
            //{
            //    filterAdvBrandsList = new List<AdvertisingBrandsModel> { };
            //    for (int i = 0; i < advBrandsList.Count; i++)
            //    {
            //        if (SearchByCampaign(advBrandsList[i].CampaignName.ToLower(), tb_SearchByCampaign.Text.ToLower()) && SearchByTargeting(advBrandsList[i].Targeting.ToLower(), tb_SearchByTargeting.Text.ToLower()))
            //        {
            //            filterAdvBrandsList.Add(advBrandsList[i]);
            //        }
            //    }

            //    //if (NoErrors)
            //    //    mf.GetAdvertisingBrandsListToShow(filterAdvBrandsList);
            //}

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        /* Выбираем, каким образом ищем текст CAMPAIGN в фильтре: вхождение или строгое соответствие */
        private bool SearchByCampaign(string _campaignName, string tb_campaignName)
        {
            if (cb_Strong_SearchByCampaign.Checked)
                return _campaignName.Equals(tb_campaignName);
            else
                return _campaignName.Contains(tb_campaignName);
        }

        /* Выбираем, каким образом ищем текст ADGROUP в фильтре: вхождение или строгое соответствие */
        private bool SearchByAdGroup(string _adGroupName, string tb_adGroupName)
        {
            if (cb_Strong_SearchByAdGroup.Checked)
                return _adGroupName.Equals(tb_adGroupName);
            else
                return _adGroupName.Contains(tb_adGroupName);
        }

        /* Выбираем, каким образом ищем текст TARGETING в фильтре: вхождение или строгое соответствие */
        private bool SearchByTargeting(string _targetingName, string tb_targetingName)
        {
            if (cb_Strong_SearchByTargeting.Checked)
                return _targetingName.Equals(tb_targetingName);
            else
                return _targetingName.Contains(tb_targetingName);
        }
        

        private void byProductsInMarkeplacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullCompareMode();
            EnableCustomTimeMode();
            byProductsToolStripMenuItem.Checked = true;
        }

        private void byCampaignInProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullCompareMode();
            EnableCustomTimeMode();
            byCampaignInProductsToolStripMenuItem.Checked = true;
        }

        private void byAdGroupsInCampaignsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullCompareMode();
            EnableCustomTimeMode();
            byAdGroupsInCampaignsToolStripMenuItem.Checked = true;
        }

        private void byTargetingInAdGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullCompareMode();
            NullTimeMode();
            DisableCustomTimeMode();
            by_CustomToolStripMenuItem.Checked = true;
            byTargetingInAdGroupsToolStripMenuItem.Checked = true;
        }
        //----------------
        private void by_CustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullTimeMode();
            by_CustomToolStripMenuItem.Checked = true;
        }


        private void by_DaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullTimeMode();
            by_DaysToolStripMenuItem.Checked = true;
        }

        private void by_WeeksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullTimeMode();
            by_WeeksToolStripMenuItem.Checked = true;
        }

        private void by_MonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NullTimeMode();
            by_MonthsToolStripMenuItem.Checked = true;
        }

        private void DisableCustomTimeMode()
        {
            by_DaysToolStripMenuItem.Enabled = false;
            by_WeeksToolStripMenuItem.Enabled = false;
            by_MonthsToolStripMenuItem.Enabled = false;
        }

        private void EnableCustomTimeMode()
        {
            by_DaysToolStripMenuItem.Enabled = true;
            by_WeeksToolStripMenuItem.Enabled = true;
            by_MonthsToolStripMenuItem.Enabled = true;
        }

        private void NullTimeMode()
        {
            by_DaysToolStripMenuItem.Checked = false;
            by_WeeksToolStripMenuItem.Checked = false;
            by_MonthsToolStripMenuItem.Checked = false;
            by_CustomToolStripMenuItem.Checked = false;
        }

        /* Ищем значения в clb_AdGroup по вхождению текста из tb_clbAdGroupFilter (ищем AdGroups по вводу пользователем) */
        private void tb_clbAdGroupFilter_TextChanged(object sender, EventArgs e)
        {
            tbAdGroupsFilterItems.Clear();
            string text = tb_clbAdGroupFilter.Text.ToLower();

            for (int i = 0; i < tbAdGroupsFilterItemsPrev.Count; i++)
            {
                if (tbAdGroupsFilterItemsPrev[i].ToLower().Contains(text))
                    tbAdGroupsFilterItems.Add(tbAdGroupsFilterItemsPrev[i]);
            }

            clb_AdGroup.Items.Clear();

            for (int i = 0; i < tbAdGroupsFilterItems.Count; i++)
            {
                clb_AdGroup.Items.Add(tbAdGroupsFilterItems[i]);
                if (checkedAdGroups.Contains(tbAdGroupsFilterItems[i]))
                    clb_AdGroup.SetItemChecked(clb_AdGroup.Items.Count - 1, true);
            }
        }

        /* Ищем значения в clb_Campaign по вхождению текста из tb_clbCampaignFilter (ищем Campaigns по вводу пользователем) */
        private void tb_clbCampaignFilter_TextChanged(object sender, EventArgs e)
        {
            tbCampaignsFilterItems.Clear();
            string text = tb_clbCampaignFilter.Text.ToLower();

            for (int i = 0; i < tbCampaignsFilterItemsPrev.Count; i++)
            {
                if (tbCampaignsFilterItemsPrev[i].ToLower().Contains(text))
                    tbCampaignsFilterItems.Add(tbCampaignsFilterItemsPrev[i]);
            }

            clb_Campaign.Items.Clear();

            for (int i = 0; i < tbCampaignsFilterItems.Count; i++)
            {
                clb_Campaign.Items.Add(tbCampaignsFilterItems[i]);
                if (checkedCampaigns.Contains(tbCampaignsFilterItems[i]))
                    clb_Campaign.SetItemChecked(clb_Campaign.Items.Count - 1, true);
            }
        }

        private void NullCompareMode()
        {
            byProductsToolStripMenuItem.Checked = false;
            byCampaignInProductsToolStripMenuItem.Checked = false;
            byAdGroupsInCampaignsToolStripMenuItem.Checked = false;
            byTargetingInAdGroupsToolStripMenuItem.Checked = false;
        }

        private void btn_Clear_clb_AdGroups_Click(object sender, EventArgs e)
        {
            clb_AdGroup.ClearSelected();
            checkedAdGroups.Clear();

            for (int i = 0; i < clb_AdGroup.Items.Count; i++)
            {
                clb_AdGroup.SetItemChecked(i, false);
            }

            disableTbClbFilter();
        }

        private void disableTbClbFilter()
        {
            if (clb_AdGroup.Items.Count == 0)
                tb_clbAdGroupFilter.Enabled = false;
            if (clb_Campaign.Items.Count == 0)
                tb_clbCampaignFilter.Enabled = false;
        }

        private void advertisingAlarmReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Создать отчет за период " + mc_StartDate.SelectionStart.ToString().Substring(0, 10) + " - " + mc_StartDate.SelectionStart.AddDays(6).ToString().Substring(0, 10) + "?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Advreport7days advrep7 = new Advreport7days(mc_StartDate.SelectionStart);
                int result = advrep7.Generate();
                if (result == 1)
                    MessageBox.Show("Отчет успешно сгенерирован и отправлен.", "Успех");
                else
                    MessageBox.Show("При генерации и отправке отчета произошла какая-то ошибка. Пожалуйста, попробуйте позже.", "Ошибка");
            }
        }
        

        /* Фильтруем данные в таблице по MatchType */
        private void btn_FilterByMatchType_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            NoErrors = true;

            if (mf.SponsoredProductMode)                //если имеем дело с Sponsored Products
            {
                filterAdvProductsList = new List<AdvertisingProductsModel> { };
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    if (cb_MatchType.SelectedItem.Equals("EXACT") || cb_MatchType.SelectedItem.Equals("BROAD") || cb_MatchType.SelectedItem.Equals("PHRASE"))
                    {
                        if (advProductsList[i].MatchType.Equals(cb_MatchType.SelectedItem))
                            filterAdvProductsList.Add(advProductsList[i]); 

                    } 
                    else if (cb_MatchType.SelectedItem.Equals("AUTO"))
                    {
                        if (advProductsList[i].CampaignName.ToLower().Contains("auto"))
                            filterAdvProductsList.Add(advProductsList[i]);
                    }
                }

                timer1.Start();
                if (NoErrors)
                    mf.GetAdvertisingProductsListToShow(filterAdvProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), "", GetProductIdByName(checkedProducts));
            }
            else if (mf.SponsoredBrandMode)             //если имеем дело с Sponsored Brands
            {
                filterAdvBrandsList = new List<AdvertisingBrandsModel> { };

                for (int i = 0; i < advBrandsList.Count; i++)
                {
                    if (cb_MatchType.SelectedItem.Equals("EXACT") || cb_MatchType.SelectedItem.Equals("BROAD") || cb_MatchType.SelectedItem.Equals("PHRASE"))
                    {
                        if (advBrandsList[i].MatchType.Equals(cb_MatchType.SelectedItem))
                            filterAdvBrandsList.Add(advBrandsList[i]);

                    }
                    else if (cb_MatchType.SelectedItem.Equals("AUTO"))
                    {
                        if (advBrandsList[i].CampaignName.ToLower().Contains("auto"))
                            filterAdvBrandsList.Add(advBrandsList[i]);
                    }
                }
                
                //if (NoErrors)
                //    mf.GetAdvertisingBrandsListToShow(filterAdvBrandsList);
            }

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        /* Применить числовой фильтр по таблице */
        private void btn_Go_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            NoErrors = true;

            if (mf.SponsoredProductMode)                //если имеем дело с Sponsored Products
            {
                filterAdvProductsList = new List<AdvertisingProductsModel> { };
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    if (CheckDoubleValues(CheckInput(tb_Impressions), advProductsList[i].Impressions) && CheckDoubleValues(CheckInput(tb_Clicks), advProductsList[i].Clicks) && CheckDoubleValues(CheckInput(tb_CTR), advProductsList[i].CTR) && CheckDoubleValues(CheckInput(tb_CPC), advProductsList[i].CPC) && CheckDoubleValues(CheckInput(tb_Spend), advProductsList[i].Spend) && CheckDoubleValues(CheckInput(tb_ACoS), advProductsList[i].ACoS) && CheckDoubleValues(CheckInput(tb_Sales), advProductsList[i].Sales) && CheckDoubleValues(CheckInput(tb_Orders), advProductsList[i].Orders) && CheckDoubleValues(CheckInput(tb_Units), advProductsList[i].Units))
                    {
                        filterAdvProductsList.Add(advProductsList[i]);
                    }
                }

                timer1.Start();
                if (NoErrors)
                    mf.GetAdvertisingProductsListToShow(filterAdvProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), "", GetProductIdByName(checkedProducts));
            }
            else if (mf.SponsoredBrandMode)             //если имеем дело с Sponsored Brands
            {
                filterAdvBrandsList = new List<AdvertisingBrandsModel> { };

                for (int i = 0; i < advBrandsList.Count; i++)
                {
                    if (CheckDoubleValues(CheckInput(tb_Impressions), advBrandsList[i].Impressions) && CheckDoubleValues(CheckInput(tb_Clicks), advBrandsList[i].Clicks) && CheckDoubleValues(CheckInput(tb_CTR), advBrandsList[i].CTR) && CheckDoubleValues(CheckInput(tb_CPC), advBrandsList[i].CPC) && CheckDoubleValues(CheckInput(tb_Spend), advBrandsList[i].Spend) && CheckDoubleValues(CheckInput(tb_ACoS), advBrandsList[i].ACoS) && CheckDoubleValues(CheckInput(tb_Sales), advBrandsList[i].Sales) && CheckDoubleValues(CheckInput(tb_Orders), advBrandsList[i].Orders) && CheckDoubleValues(CheckInput(tb_Units), advBrandsList[i].Units))
                    {
                        filterAdvBrandsList.Add(advBrandsList[i]);
                    }                    
                }

                timer1.Start();
                //if (NoErrors)
                //    mf.GetAdvertisingBrandsListToShow(filterAdvBrandsList);
            }

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

            if (mf.SponsoredProductMode)
            {
                tb_Impressions.Text = "";
                tb_Clicks.Text = "";
                tb_CTR.Text = "";
                tb_CPC.Text = "";
                tb_Spend.Text = "";
                tb_ACoS.Text = "";
                tb_Sales.Text = "";
                tb_Orders.Text = "";
                tb_Units.Text = "";

                mf.GetAdvertisingProductsListToShow(advProductsList, advProductsListOriginal, GetCompareMode(), pList, GetDateMode(), "", GetProductIdByName(checkedProducts));
            }
            else if (mf.SponsoredBrandMode)
            {
                tb_Impressions.Text = "";
                tb_Clicks.Text = "";
                tb_CTR.Text = "";
                tb_CPC.Text = "";
                tb_Spend.Text = "";
                tb_ACoS.Text = "";
                tb_Sales.Text = "";
                tb_Orders.Text = "";
                tb_Units.Text = "";

                //mf.GetAdvertisingBrandsListToShow(advBrandsList);
            }
        }
    }
}