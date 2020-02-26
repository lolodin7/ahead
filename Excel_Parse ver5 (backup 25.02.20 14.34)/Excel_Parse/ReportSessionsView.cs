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
    public partial class ReportSessionsView : Form
    {
        private MainFormView mf;

        private bool dailyMode, weeklyMode, monthlyMode, customMode;

        private DateTime StartDate, EndDate;
        private DateTime innerStartDate, innerEndDate;
        private int weekNumber;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private List<ReportBusinessModel> businessList;
        private List<ReportBusinessModel> summaryBusinessList;

        private BusinessController businessController;


        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingProductsModel> summaryAdvProductsList;

        private List<AdvertisingBrandsModel> advBrandsList;
        private List<AdvertisingBrandsModel> summaryAdvBrandsList;

        private List<CmapaignAndIdStruct> campsidsList;

        private AdvertisingController advertController;

        List<string> checkedMarkeplaces, checkedProducts;

        private List<DateTime> dtStartList;
        private List<DateTime> dtEndList;

        private int[,] weeksStartDatesList;

        private int currentProductId;
        private List<int> currentProductIds;
        private string currentASIN;

        private string equalSign;       //знак равенства из textBox
        private bool NoErrors;          //ошибка ввода в textBox пользователем при фильтре по таблице

        private List<MapNameId> AP_campaignIdsList;
        private List<MapNameId> AB_campaignIdsList;

        public ReportSessionsView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            dailyMode = false;
            weeklyMode = false;
            monthlyMode = false;
            customMode = true;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59);

            dtStartList = new List<DateTime> { StartDate };
            dtEndList = new List<DateTime> { EndDate };

            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = StartDate.ToString().Substring(0, 10);


            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
            businessList = new List<ReportBusinessModel> { };
            summaryBusinessList = new List<ReportBusinessModel> { };
            advProductsList = new List<AdvertisingProductsModel> { };
            summaryAdvProductsList = new List<AdvertisingProductsModel> { };
            advBrandsList = new List<AdvertisingBrandsModel> { };
            summaryAdvBrandsList = new List<AdvertisingBrandsModel> { };
            currentProductIds = new List<int> { };

            mpController = new MarketplaceController(this);
            businessController = new BusinessController(this);
            prodController = new ProductsController(this);
            advertController = new AdvertisingController(this);

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

            int Sessions = 0;
            double SessionPercentage = 0;
            int PageViews = 0;
            double PageViewPercentage = 0;
            int UnitsOrdered = 0;
            int UnitsOrderedB2B = 0;
            double UnitSessionPercentage = 0;
            double UnitSessionPercentageB2B = 0;
            double OrderedProductSales = 0;
            double OrderedProductSalesB2B = 0;
            int TotalOrderItems = 0;
            int TotalOrderItemsB2B = 0;


            for (int i = 0; i < businessList.Count; i++)
            {
                if (!alreadyUsed.Contains(i))
                {
                    if (!customMode || businessList.Count > 1)
                    {
                        Sessions = businessList[i].Sessions;
                        PageViews = businessList[i].PageViews;
                        UnitsOrdered = businessList[i].UnitsOrdered;
                        UnitsOrderedB2B = businessList[i].UnitsOrderedB2B;
                        OrderedProductSales = businessList[i].OrderedProductSales;
                        OrderedProductSalesB2B = businessList[i].OrderedProductSalesB2B;
                        TotalOrderItems = businessList[i].TotalOrderItems;
                        TotalOrderItemsB2B = businessList[i].TotalOrderItemsB2B;
                    }
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
                            else if ((currentProductIds.Contains(businessList[i].ProductId) || currentProductIds.Contains(businessList[j].ProductId)) && customMode)
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
                    summaryBusinessList[summaryBusinessList.Count - 1].TotalOrderItems = TotalOrderItems;
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

        /* Получаем список кампания/кампания_ид из БД */
        public void GetCampaignsAndIds(object _tmp)
        {
            campsidsList = (List<CmapaignAndIdStruct>)_tmp;
        }

        /*  */
        public void GetAP_CampaignIdsFromDB(object _campTList)
        {
            AP_campaignIdsList = (List<MapNameId>)_campTList;
        }

        /*  */
        public void GetAB_CampaignIdsFromDB(object _campTList)
        {
            AB_campaignIdsList = (List<MapNameId>)_campTList;
        }

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetAdvertisingProductsFromDB(object _advProductList)
        {
            advProductsList = (List<AdvertisingProductsModel>)_advProductList;

            summaryAdvProductsList.Clear();
            MakeSummaryAdvProductList();
        }

        /* Получаем из контроллера Advertising Brands, полученные с БД */
        public void GetAdvertisingBrandsFromDB(object _advBrandList)
        {
            advBrandsList = (List<AdvertisingBrandsModel>)_advBrandList;

            summaryAdvBrandsList.Clear();
            MakeSummaryAdvBrandList();
        }

        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductList()
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
                    else
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
                        alreadyUsed.Add(i);
                    }
                    //summaryAdvProductsList.Add(ТО, ШО ПОЛУЧИЛОСЬ ОТ СУММИРОВАНИЯ + ДОПОЛНИТЕЛЬНО СЧИТАЕМ ТО, ЧТО НАДО ПОСЧИТАТЬ);

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
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Spend = Spend;
                    summaryAdvProductsList[summaryAdvProductsList.Count - 1].Sales = Sales;
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

        /* Удаляем все повторы с advBrandsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvBrandList()
        {
            List<int> alreadyUsed = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int NewToBrandOrders;
            int NewToBrandUnits;
            double NewToBrandSales;
            double NewToBrandOrderRate;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advBrandsList.Count; i++)
            {
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advBrandsList[i].Impressions;
                    Clicks = advBrandsList[i].Clicks;
                    Spend = advBrandsList[i].Spend;
                    Sales = advBrandsList[i].Sales;
                    Orders = advBrandsList[i].Orders;
                    Units = advBrandsList[i].Units;
                    NewToBrandOrders = advBrandsList[i].NewToBrandOrders;
                    NewToBrandSales = advBrandsList[i].NewToBrandSales;
                    NewToBrandUnits = advBrandsList[i].NewToBrandUnits;

                    if (i < (advBrandsList.Count - 1))
                    {
                        for (int j = i + 1; j < advBrandsList.Count; j++)
                        {
                            if (advBrandsList[i].CampaignName.Equals(advBrandsList[j].CampaignName) && advBrandsList[i].Targeting.Equals(advBrandsList[j].Targeting) && advBrandsList[i].MatchType.Equals(advBrandsList[j].MatchType))
                            {
                                Impressions += advBrandsList[j].Impressions;
                                Clicks += advBrandsList[j].Clicks;
                                Spend += advBrandsList[j].Spend;
                                Sales += advBrandsList[j].Sales;
                                Orders += advBrandsList[j].Orders;
                                Units += advBrandsList[j].Units;
                                NewToBrandOrders += advBrandsList[j].NewToBrandOrders;
                                NewToBrandSales += advBrandsList[j].NewToBrandSales;
                                NewToBrandUnits += advBrandsList[j].NewToBrandUnits;
                                alreadyUsed.Add(j);
                            }
                        }
                    }
                    else
                    {
                        Impressions += advBrandsList[i].Impressions;
                        Clicks += advBrandsList[i].Clicks;
                        Spend += advBrandsList[i].Spend;
                        Sales += advBrandsList[i].Sales;
                        Orders += advBrandsList[i].Orders;
                        Units += advBrandsList[i].Units;
                        NewToBrandOrders += advBrandsList[i].NewToBrandOrders;
                        NewToBrandSales += advBrandsList[i].NewToBrandSales;
                        NewToBrandUnits += advBrandsList[i].NewToBrandUnits;
                        alreadyUsed.Add(i);
                    }
                    //summaryAdvBrandsList.Add(ТО, ШО ПОЛУЧИЛОСЬ ОТ СУММИРОВАНИЯ + ДОПОЛНИТЕЛЬНО СЧИТАЕМ ТО, ЧТО НАДО ПОСЧИТАТЬ);

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

                    if (Clicks != 0)
                        NewToBrandOrderRate = ((double)NewToBrandOrders / Clicks) * 100;
                    else NewToBrandOrderRate = 0;


                    summaryAdvBrandsList.Add(new AdvertisingBrandsModel());

                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].UpdateDate = advBrandsList[i].UpdateDate;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].CurrencyCharCode = advBrandsList[i].CurrencyCharCode;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].CampaignName = advBrandsList[i].CampaignName;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Targeting = advBrandsList[i].Targeting;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].MatchType = advBrandsList[i].MatchType;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Impressions = Impressions;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Clicks = Clicks;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Spend = Spend;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Sales = Sales;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Orders = Orders;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].Units = Units;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].NewToBrandUnits = NewToBrandUnits;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].NewToBrandOrders = NewToBrandOrders;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].NewToBrandSales = NewToBrandSales;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].NewToBrandOrderRate = NewToBrandOrderRate;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].CampaignTypeId = advBrandsList[i].CampaignTypeId;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].MarketPlaceId = advBrandsList[i].MarketPlaceId;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].CampaignId = advBrandsList[i].CampaignId;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].ProductId1 = advBrandsList[i].ProductId1;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].ProductId2 = advBrandsList[i].ProductId2;
                    summaryAdvBrandsList[summaryAdvBrandsList.Count - 1].ProductId3 = advBrandsList[i].ProductId3;
                }
            }
            advBrandsList.Clear();
            foreach (var t in summaryAdvBrandsList)
            {
                advBrandsList.Add(t);
            }
        }


        /* Изменяем дату начала в календаре */
        private void mc_StartDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate = mc_StartDate.SelectionStart;

            //dtStartList.Clear();
            //dtStartList.Add(StartDate);

            lb_StartDate.Text = mc_StartDate.SelectionStart.ToShortDateString();
        }

        /* Изменяем дату окончания в календаре */
        private void mc_EndDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate = mc_EndDate.SelectionEnd;

            //dtEndList.Clear();
            //dtEndList.Add(EndDate);

            lb_EndDate.Text = mc_EndDate.SelectionStart.ToShortDateString();
        }

        /* Отобразить данные по дням за месяц */
        private void btn_Daily_Click(object sender, EventArgs e)
        {
            dailyMode = true;
            weeklyMode = false;
            monthlyMode = false;
            customMode = false;

            mc_StartDate.Enabled = false;
            mc_EndDate.Enabled = false;

            dtStartList.Clear();
            dtEndList.Clear();

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Customly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);

            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(30, 0, 0, 0, 0));

            StartDate = dd;
            EndDate = dd.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные по неделям за год */
        private void btn_Weekly_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = true;
            monthlyMode = false;
            customMode = false;

            mc_StartDate.Enabled = false;
            mc_EndDate.Enabled = false;

            dtStartList.Clear();
            dtEndList.Clear();

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Customly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);


            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(365, 0, 0, 0, 0));

            StartDate = dd;
            EndDate = dd.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные по месяцам за год */
        private void btn_Monthly_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = false;
            monthlyMode = true;
            customMode = false;

            mc_StartDate.Enabled = false;
            mc_EndDate.Enabled = false;

            dtStartList.Clear();
            dtEndList.Clear();

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Customly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);


            DateTime dd = DateTime.Today;
            dd = dd.Subtract(new TimeSpan(365, 0, 0, 0, 0));

            StartDate = dd;
            EndDate = dd.AddHours(23).AddMinutes(59);
        }

        private void btn_Customly_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = false;
            monthlyMode = false;
            customMode = true;

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Customly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);

            mc_StartDate.Enabled = true;
            mc_EndDate.Enabled = true;

            StartDate = mc_StartDate.SelectionStart;
            EndDate = mc_EndDate.SelectionEnd;

            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);
        }

        /* Выделяем/снимаем выделение маркетплейса в clb_Marketplace */
        private void clb_Marketplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedMarkeplaces.Clear();
            cb_ProductNames.Items.Clear();

            for (int i = 0; i < clb_Marketplace.CheckedItems.Count; i++)
            {
                checkedMarkeplaces.Add(clb_Marketplace.CheckedItems[i].ToString());
            }

            int res = 0;
            res = prodController.GetProductsByFewMarketplaceIdInactive(GetMPIdsByNames(checkedMarkeplaces));

            if (res == 1 && checkedMarkeplaces.Count > 0)
            {
                Fill_CB_ProductNames();
                Fill_CB_ProductASINs();
                panel1.Enabled = true;
            }
            else
                panel1.Enabled = false;
        }

        private void Fill_CB_ProductNames()
        {
            for (int i = 0; i < pList.Count; i++)
            {
                cb_ProductNames.Items.Add(pList[i].Name);
            }
            if (cb_ProductNames.Items.Count > 0)
                cb_ProductNames.SelectedIndex = 0;
        }

        private void Fill_CB_ProductASINs()
        {
            for (int i = 0; i < pList.Count; i++)
            {
                cb_ProductASINs.Items.Add(pList[i].ASIN);
            }
            if (cb_ProductASINs.Items.Count > 0)
                cb_ProductASINs.SelectedIndex = 0;
        }

        private void cb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            //currentProductId
            //for (int i = 0; i < pList.Count; i++)
            //{
            //if (pList[i].Name.Equals(cb_Products.SelectedItem.ToString()))
            //{
            int i = cb_ProductNames.SelectedIndex;
            currentProductId = pList[i].ProductId;
            lb_SKUText.Text = "SKU: " + pList[i].SKU;
            return;
            //}
            //}
        }

        private void btn_Clear_clb_Marketplace_Click(object sender, EventArgs e)
        {
            checkedMarkeplaces.Clear();
            clb_Marketplace.ClearSelected();

            for (int i = 0; i < clb_Marketplace.Items.Count; i++)
            {
                clb_Marketplace.SetItemChecked(i, false);
            }

            pList.Clear();
            cb_ProductNames.Items.Clear();
            lb_SKUText.Text = "";
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            if (checkedMarkeplaces.Count == 0)
            {
                MessageBox.Show("Для начала выберите маркетплейс!", "Ошибка");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            currentProductIds.Clear();

            if (!rb_ByAll.Checked)
                foreach (var t in pList)
                {
                    if (t.ASIN.Equals(currentASIN))
                    {
                        currentProductIds.Add(t.ProductId);
                    }
                }

            if (StartDate > EndDate)
                MessageBox.Show("Ошибка! Дата начала больше даты окончания!", "Ошибка");

            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            int businessResult = 0;
            int advProductsResult = 0;
            int advBrandResult = 0;

            int divider = 0;

            if (dailyMode)
                divider = 30;
            else if (weeklyMode)
                divider = 52;
            else if (monthlyMode)
                divider = 12;
            else if (customMode)
                divider = 1;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DateTime dstart;
            DateTime dend;
            bool firstRun = true;

            if (dailyMode)
            {
                dstart = DateTime.Today.AddDays(-1);
                dend = dstart.AddHours(23).AddMinutes(59).AddSeconds(59);

                int prevmonth = DateTime.Today.AddMonths(-1).Month;     //номер предыдущего месяца
                int prevdays = DateTime.DaysInMonth(DateTime.Today.Year, prevmonth);   //дней в предыдущем месяце

                for (int i = 0; i < (prevdays - 1); i++)
                {
                    //получаем данные продаж
                    businessList.Clear();
                    businessResult = businessController.GetFinalABusinessReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces));

                    if (rb_ByProductName.Checked)
                    {
                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }
                    else if (rb_ByASIN.Checked || rb_ByAll.Checked)
                    {
                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, true, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, false, true);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }

                    dstart = dstart.AddDays(-1);
                    dend = dstart.AddHours(23).AddMinutes(59).AddSeconds(59);
                }
            }
            else if (weeklyMode)
            {
                GetWeek();
                dstart = innerStartDate;
                dend = innerEndDate;

                int prevmonth = DateTime.Today.AddMonths(-1).Month;     //номер предыдущего месяца
                int prevdays = DateTime.DaysInMonth(DateTime.Today.Year, prevmonth);   //дней в предыдущем месяце

                for (int i = 0; i < 52; i++)
                {
                    //получаем данные продаж
                    businessList.Clear();
                    businessResult = businessController.GetFinalABusinessReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces));

                    if (rb_ByProductName.Checked)
                    {
                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, dend, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, dend, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }
                    else if (rb_ByASIN.Checked || rb_ByAll.Checked)
                    {
                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, dend, true, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, dend, false, true);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }

                    dstart = dstart.AddDays(-7);
                    dend = dstart.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
                    if (weekNumber - 1 == 0)
                        weekNumber = 52;
                    else
                        weekNumber--;
                }
            }
            else if (monthlyMode)
            {
                dstart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dend = dstart.AddDays(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - 1).AddHours(23).AddMinutes(59).AddSeconds(59);

                int prevmonth = DateTime.Today.AddMonths(-1).Month;     //номер предыдущего месяца
                int prevdays = DateTime.DaysInMonth(DateTime.Today.Year, prevmonth);   //дней в предыдущем месяце

                for (int i = 0; i < 12; i++)
                {
                    //получаем данные продаж
                    businessList.Clear();
                    businessResult = businessController.GetFinalABusinessReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces));

                    if (rb_ByProductName.Checked)
                    {
                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, dend, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, dend, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }
                    else if (rb_ByASIN.Checked || rb_ByAll.Checked)
                    {
                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dstart, dend, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, dend, true, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, dend, false, true);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }



                    if (dstart.Month - 1 == 0)
                    {
                        dstart = dstart.AddMonths(-1);
                        dend = dstart.AddDays(DateTime.DaysInMonth(dstart.Year, dstart.Month) - 1).AddHours(23).AddMinutes(59).AddSeconds(59);
                    }
                    else
                    {
                        dstart = dstart.AddDays(-DateTime.DaysInMonth(dstart.Year, dstart.Month - 1));
                        dend = dstart.AddDays(DateTime.DaysInMonth(dstart.Year, dstart.Month) - 1).AddHours(23).AddMinutes(59).AddSeconds(59);
                    }
                }

            }
            else if (customMode)
            {
                int diff = (EndDate - StartDate).Days + 1;

                dstart = EndDate;
                dend = dstart.AddHours(-23).AddMinutes(-59).AddSeconds(-59);

                for (int i = 0; i < diff; i++)
                {
                    if (rb_ByProductName.Checked)
                    {
                        //получаем данные продаж
                        businessList.Clear();
                        businessResult = businessController.GetFinalABusinessReport(dend, dstart, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId });

                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dend, dstart, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dend, dstart, GetMPIdsByNames(checkedMarkeplaces), new List<int> { currentProductId }, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }
                    else if (rb_ByASIN.Checked || rb_ByAll.Checked)
                    {
                        //получаем данные продаж
                        businessList.Clear();
                        businessResult = businessController.GetFinalABusinessReport(dend, dstart, GetMPIdsByNames(checkedMarkeplaces), currentProductIds);

                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(dend, dstart, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { }, new List<string> { });

                        advBrandsList.Clear();
                        advBrandResult = advertController.GetFinalAdvertisingBrandsReport(dend, dstart, GetMPIdsByNames(checkedMarkeplaces), currentProductIds, new List<int> { });

                        if (businessResult == 1 && advProductsResult == 1 && advBrandResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts + sponsoredBrands
                                DrawTable(dstart, true, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(dstart, false, true);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");
                    }
                    dstart = dstart.AddDays(-1);
                    dend = dend.AddDays(-1);
                }
            }

            DrawTableLastColumn();
            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private string GetProductSkuByID(int _productId)
        {
            foreach (var t in pList)
            {
                if (t.ProductId == _productId)
                    return t.SKU;
            }
            return "";
        }

        private void DrawTableColumns()
        {
            dataGridView1.Columns.Add("", "");
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Сессии органика";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Сессии реклама";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Orders органика";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Orders реклама";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Orders всего";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Конверсия органики";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Конверсия рекламы";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Конверсия общая";
            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[dataGridView1.ColumnCount - 1].Value = "Доля органики";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                SessionsOrganic += int.Parse(dataGridView1.Rows[0].Cells[i].Value.ToString());
                SessionsAdv += int.Parse(dataGridView1.Rows[1].Cells[i].Value.ToString());

                SalesOrganic += int.Parse(dataGridView1.Rows[2].Cells[i].Value.ToString());
                SalesAdv += int.Parse(dataGridView1.Rows[3].Cells[i].Value.ToString());
                SalesGeneral += int.Parse(dataGridView1.Rows[4].Cells[i].Value.ToString());
            }

            //for (int i = 0; i < businessList.Count; i++)
            //{
            //    SessionsOrganic += businessList[i].Sessions;
            //    SalesGeneral += businessList[i].TotalOrderItems;
            //    SalesGeneral += businessList[i].TotalOrderItemsB2B;
            //}

            //for (int i = 0; i < advProductsList.Count; i++)
            //{
            //    SessionsAdv += advProductsList[i].Clicks;
            //    SalesAdv += advProductsList[i].Orders;
            //}

            //for (int i = 0; i < advBrandsList.Count; i++)
            //{
            //    SessionsAdv += advBrandsList[i].Clicks;
            //    SalesAdv += advBrandsList[i].Orders;
            //}

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
            
            dataGridView1.Columns.Add("summ", "");
            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value = SessionsOrganic;
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Value = SessionsAdv;
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 1].Value = SalesOrganic;
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = SalesAdv;
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 1].Value = SalesGeneral;
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = ConversionOrganic;
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 1].Value = ConversionAdv;
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 1].Value = ConversionGeneral;
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = OragnicShare;
        }    
        
        private void GetWeek()
        {
            DateTime todayDay = DateTime.Today;

            int dayOfYear = todayDay.DayOfYear;
            int tmp = (int)Math.Truncate((double)dayOfYear / 7);
            if (tmp == 0)       //если это 1я неделя
            {
                tmp = 1;

                string dayName = todayDay.DayOfWeek.ToString();
                if (dayName.Equals("Monday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 1).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (dayName.Equals("Tuesday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 2).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (dayName.Equals("Wednesday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 3).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (dayName.Equals("Thursday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 4).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (dayName.Equals("Friday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 5).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (dayName.Equals("Saturday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 6).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (dayName.Equals("Sunday"))
                {
                    innerEndDate = todayDay.AddDays(7 - 7).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                weekNumber = 1;
                innerStartDate = innerEndDate.AddDays(-6);
            }
            else
            {
                int closest1stDayOfWeek = tmp * 7;
                int diffFromStartWeek = closest1stDayOfWeek - dayOfYear;
                innerStartDate = todayDay.AddDays(diffFromStartWeek);
                innerEndDate = todayDay.AddDays(6 + diffFromStartWeek).AddHours(23).AddMinutes(59).AddSeconds(59);
                weekNumber = (int)Math.Truncate((double)dayOfYear / 7) + 1;
                if (weekNumber == 53)
                    weekNumber = 1;


            }
        }

        private void cb_ProductASINs_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentASIN = cb_ProductASINs.SelectedItem.ToString();
        }

        private void rb_ByProductName_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ByProductName.Checked)
            {
                lb_SKUText.Visible = true;
                cb_ProductNames.Enabled = true;
                cb_ProductASINs.Enabled = false;
            }
            else if (rb_ByASIN.Checked)
            {
                lb_SKUText.Visible = false;
                cb_ProductNames.Enabled = false;
                cb_ProductASINs.Enabled = true;

                currentASIN = cb_ProductASINs.SelectedItem.ToString();
            }
            else if (rb_ByAll.Checked)
            {
                lb_SKUText.Visible = false;
                cb_ProductNames.Enabled = false;
                cb_ProductASINs.Enabled = false;
                currentASIN = "-1";
            }
        }

        private void rb_ByASIN_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ByASIN.Checked)
            {
                lb_SKUText.Visible = false;
                cb_ProductNames.Enabled = false;
                cb_ProductASINs.Enabled = true;

                currentASIN = cb_ProductASINs.SelectedItem.ToString();
            }
            else if (rb_ByProductName.Checked)
            {
                lb_SKUText.Visible = true;
                cb_ProductNames.Enabled = true;
                cb_ProductASINs.Enabled = false;
            }
            else if (rb_ByAll.Checked)
            {
                lb_SKUText.Visible = false;
                cb_ProductNames.Enabled = false;
                cb_ProductASINs.Enabled = false;
                currentASIN = "-1";
            }
        }

        private void rb_ByAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ByAll.Checked)
            {
                lb_SKUText.Visible = false;
                cb_ProductNames.Enabled = false;
                cb_ProductASINs.Enabled = false;
                currentASIN = "-1";
                //currentPr
            }
            else if (rb_ByASIN.Checked)
            {
                lb_SKUText.Visible = false;
                cb_ProductNames.Enabled = false;
                cb_ProductASINs.Enabled = true;

                currentASIN = cb_ProductASINs.SelectedItem.ToString();
            }
            else if (rb_ByProductName.Checked)
            {
                lb_SKUText.Visible = true;
                cb_ProductNames.Enabled = true;
                cb_ProductASINs.Enabled = false;
            }
        }


        
        //currentProductIds 
        private void DrawTable(DateTime _dstart, bool _firstRun, bool _asins)
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


            string productSku = GetProductSkuByID(currentProductId);

            if (!rb_ByAll.Checked)
            {
                for (int i = 0; i < businessList.Count; i++)
                {
                    foreach (var t in currentProductIds)
                    {
                        if (businessList[i].ProductId == t)
                        {
                            sessionsOrganic += businessList[i].Sessions;
                            oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < businessList.Count; i++)
                {
                    sessionsOrganic += businessList[i].Sessions;
                    oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
                }
            }

            if (!rb_ByAll.Checked)
            {
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    foreach (var t in currentProductIds)
                    {
                        if (advProductsList[i].ProductId == t)
                        {
                            sessionsAdv += advProductsList[i].Clicks;
                            ordersAdv += advProductsList[i].Orders;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    sessionsAdv += advProductsList[i].Clicks;
                    ordersAdv += advProductsList[i].Orders;
                }
            }

            if (!rb_ByAll.Checked)
            {
                for (int i = 0; i < advBrandsList.Count; i++)
                {
                    foreach (var t in currentProductIds)
                    {
                        if (advBrandsList[i].ProductId1 == t || advBrandsList[i].ProductId2 == t || advBrandsList[i].ProductId3 == t)
                        {
                            sessionsAdv += advBrandsList[i].Clicks;
                            ordersAdv += advBrandsList[i].Orders;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < advBrandsList.Count; i++)
                {
                    sessionsAdv += advBrandsList[i].Clicks;
                    ordersAdv += advBrandsList[i].Orders;
                }
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

            dataGridView1.Columns.Add(_dstart.ToString().Substring(0, 10), _dstart.ToString().Substring(0, 10));
            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value = sessionsOrganic;
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Value = sessionsAdv;
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 1].Value = ordersOrganic;
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = ordersAdv;
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 1].Value = oredersGeneral;
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = conversionOrganic;
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 1].Value = conversionAdv;
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 1].Value = conversionGeneral;
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = share;

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            btn_Export.Text = "Экспорт в файл (" + dataGridView1.ColumnCount + ")";
        }

        //currentProductIds
        private void DrawTable(DateTime _dstart, DateTime _dend, bool _firstRun, bool _asins)
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

            string productSku = GetProductSkuByID(currentProductId);

            //for (int i = 0; i < businessList.Count; i++)
            //{
            //    if (!rb_ByAll.Checked)
            //        foreach (var t in currentProductIds)
            //        {
            //            if (businessList[i].ProductId == t)
            //            {
            //                sessionsOrganic += businessList[i].Sessions;
            //                oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
            //            }
            //        }
            //    else
            //    {
            //        sessionsOrganic += businessList[i].Sessions;
            //        oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
            //    }
            //}

            if (!rb_ByAll.Checked)
            {
                for (int i = 0; i < businessList.Count; i++)
                {
                    foreach (var t in currentProductIds)
                    {
                        if (businessList[i].ProductId == t)
                        {
                            sessionsOrganic += businessList[i].Sessions;
                            oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < businessList.Count; i++)
                {
                    sessionsOrganic += businessList[i].Sessions;
                    oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
                }
            }


            if (!rb_ByAll.Checked)
            {
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    foreach (var t in currentProductIds)
                    {
                        if (advProductsList[i].ProductId == t)
                        {
                            sessionsAdv += advProductsList[i].Clicks;
                            ordersAdv += advProductsList[i].Orders;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    sessionsAdv += advProductsList[i].Clicks;
                    ordersAdv += advProductsList[i].Orders;
                }
            }

            if (!rb_ByAll.Checked)
            {
                for (int i = 0; i < advBrandsList.Count; i++)
                {
                    foreach (var t in currentProductIds)
                    {
                        if (advBrandsList[i].ProductId1 == t || advBrandsList[i].ProductId2 == t || advBrandsList[i].ProductId3 == t)
                        {
                            sessionsAdv += advBrandsList[i].Clicks;
                            ordersAdv += advBrandsList[i].Orders;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < advBrandsList.Count; i++)
                {
                    sessionsAdv += advBrandsList[i].Clicks;
                    ordersAdv += advBrandsList[i].Orders;
                }
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

            dataGridView1.Columns.Add(_dstart.ToString().Substring(0, 5) + "-" + _dend.ToString().Substring(0, 5), _dstart.ToString().Substring(0, 5) + "-" + _dend.ToString().Substring(0, 5) + "\n" + GetMonth(_dstart.Month));
            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value = sessionsOrganic;
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Value = sessionsAdv;
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 1].Value = ordersOrganic;
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = ordersAdv;
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 1].Value = oredersGeneral;
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = conversionOrganic;
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 1].Value = conversionAdv;
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 1].Value = conversionGeneral;
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = share;

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            btn_Export.Text = "Экспорт в файл (" + dataGridView1.ColumnCount + ")";
        }

        //currentProductId method
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

            string productSku = GetProductSkuByID(currentProductId);

            for (int i = 0; i < businessList.Count; i++)
            {
                if (businessList[i].ProductId == currentProductId)
                {
                    sessionsOrganic += businessList[i].Sessions;
                    oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
                }
            }

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (advProductsList[i].ProductId == currentProductId)
                {
                    sessionsAdv += advProductsList[i].Clicks;
                    ordersAdv += advProductsList[i].Orders;
                }
            }

            for (int i = 0; i < advBrandsList.Count; i++)
            {
                if (advBrandsList[i].ProductId1 == currentProductId || advBrandsList[i].ProductId2 == currentProductId || advBrandsList[i].ProductId3 == currentProductId)
                {
                    sessionsAdv += advBrandsList[i].Clicks;
                    ordersAdv += advBrandsList[i].Orders;
                }
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

            dataGridView1.Columns.Add(_dstart.ToString().Substring(0, 5) + "-" + _dend.ToString().Substring(0, 5), _dstart.ToString().Substring(0, 5) + "-" + _dend.ToString().Substring(0, 5) + "\n" + GetMonth(_dstart.Month));
            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value = sessionsOrganic;
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Value = sessionsAdv;
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 1].Value = ordersOrganic;
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = ordersAdv;
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 1].Value = oredersGeneral;
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = conversionOrganic;
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 1].Value = conversionAdv;
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 1].Value = conversionGeneral;
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = share;

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            btn_Export.Text = "Экспорт в файл (" + dataGridView1.ColumnCount + ")";
        }

        //currentProductId method
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


            string productSku = GetProductSkuByID(currentProductId);

            for (int i = 0; i < businessList.Count; i++)
            {
                if (businessList[i].ProductId == currentProductId)
                {
                    sessionsOrganic += businessList[i].Sessions;
                    oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
                }
            }

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (advProductsList[i].ProductId == currentProductId)
                {
                    sessionsAdv += advProductsList[i].Clicks;
                    ordersAdv += advProductsList[i].Orders;
                }
            }

            for (int i = 0; i < advBrandsList.Count; i++)
            {
                if (advBrandsList[i].ProductId1 == currentProductId || advBrandsList[i].ProductId2 == currentProductId || advBrandsList[i].ProductId3 == currentProductId)
                {
                    sessionsAdv += advBrandsList[i].Clicks;
                    ordersAdv += advBrandsList[i].Orders;
                }
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

            dataGridView1.Columns.Add(_dstart.ToString().Substring(0, 10), _dstart.ToString().Substring(0, 10));
            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value = sessionsOrganic;
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Value = sessionsAdv;
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 1].Value = ordersOrganic;
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = ordersAdv;
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 1].Value = oredersGeneral;
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = conversionOrganic;
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 1].Value = conversionAdv;
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 1].Value = conversionGeneral;
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = share;

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            btn_Export.Text = "Экспорт в файл (" + dataGridView1.ColumnCount + ")";
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

        private string GetMarketPlaceName(object _var)
        {
            int marketplaceId = (int)_var;

            foreach (var t in mpList)
            {
                if (t.MarketPlaceId == marketplaceId)
                    return t.MarketPlaceName;
            }
            return "NOT_FOUND";
        }

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

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.ColumnCount - 4; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount - 4; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
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

        private void ReportSessionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }
    }
}
