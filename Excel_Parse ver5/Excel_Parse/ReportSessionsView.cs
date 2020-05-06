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

        List<string> checkedMarkeplaces;
        List<ProductsModel> checkedProducts, searchresultsCheckedProducts;

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

            dailyMode = true;
            weeklyMode = false;
            monthlyMode = false;
            //customMode = true;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

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

        /* Получаем из контроллера Advertising Products, полученные с БД */
        public void GetBusinessReportFromDB(object _businessList)
        {
            businessList = (List<ReportBusinessModel>)_businessList;

            summaryBusinessList.Clear();
            MakeSummaryBusinessReportList();
        }

        private bool CheckEntry(List<ReportBusinessModel> usedASINS, ReportBusinessModel objectToCheck)
        {
            for (int i = 0; i < usedASINS.Count; i++)
            {
                if (usedASINS[i].MarketPlaceId == objectToCheck.MarketPlaceId && GetProductASINBySkuAndMarketplaceId(usedASINS[i].SKU, usedASINS[i].MarketPlaceId).Equals(GetProductASINBySkuAndMarketplaceId(objectToCheck.SKU, objectToCheck.MarketPlaceId)) && usedASINS[i].UpdateDate == objectToCheck.UpdateDate)
                    return true;
            }
            return false;
        }

        /* Удаляем все повторы с businessList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryBusinessReportList()
        {
            List<ReportBusinessModel> usedASINS = new List<ReportBusinessModel> { };

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

            if (businessList.Count > 0)
            {
                Sessions = businessList[0].Sessions;
                PageViews = businessList[0].PageViews;
                UnitsOrdered = businessList[0].UnitsOrdered;
                UnitsOrderedB2B = businessList[0].UnitsOrderedB2B;
                OrderedProductSales = businessList[0].OrderedProductSales;
                OrderedProductSalesB2B = businessList[0].OrderedProductSalesB2B;
                TotalOrderItems = businessList[0].TotalOrderItems;
                TotalOrderItemsB2B = businessList[0].TotalOrderItemsB2B;

                usedASINS.Add(businessList[0]);

                for (int i = 1; i < businessList.Count; i++)
                {
                    if (!CheckEntry(usedASINS, businessList[i]))
                    {
                        Sessions += businessList[i].Sessions;
                        PageViews += businessList[i].PageViews;
                        UnitsOrdered += businessList[i].UnitsOrdered;
                        UnitsOrderedB2B += businessList[i].UnitsOrderedB2B;
                        OrderedProductSales += businessList[i].OrderedProductSales;
                        OrderedProductSalesB2B += businessList[i].OrderedProductSalesB2B;
                        TotalOrderItems += businessList[i].TotalOrderItems;
                        TotalOrderItemsB2B += businessList[i].TotalOrderItemsB2B;

                        usedASINS.Add(businessList[i]);
                    }
                    else
                    {
                        PageViews += businessList[i].PageViews;
                        UnitsOrdered += businessList[i].UnitsOrdered;
                        UnitsOrderedB2B += businessList[i].UnitsOrderedB2B;
                        OrderedProductSales += businessList[i].OrderedProductSales;
                        OrderedProductSalesB2B += businessList[i].OrderedProductSalesB2B;
                        TotalOrderItems += businessList[i].TotalOrderItems;
                        TotalOrderItemsB2B += businessList[i].TotalOrderItemsB2B;
                    }

                }

                
                if (Sessions != 0)
                    SessionPercentage = Math.Round((double)Sessions / Sessions * 100, 2);
                else
                    SessionPercentage = 0;

                if (PageViews != 0)
                    PageViewPercentage = Math.Round((double)PageViews / PageViews * 100, 2);
                else
                    PageViewPercentage = 0;

                if (Sessions != 0)
                    UnitSessionPercentage = Math.Round((double)UnitsOrdered / Sessions * 100, 2);
                else
                    UnitSessionPercentage = 0;

                if (Sessions != 0)
                    UnitSessionPercentageB2B = Math.Round((double)UnitsOrderedB2B / Sessions * 100, 2);
                else
                    UnitSessionPercentageB2B = 0;


                summaryBusinessList.Add(new ReportBusinessModel());
                
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


                businessList.Clear();
                foreach (var t in summaryBusinessList)
                {
                    businessList.Add(t);
                }
            }















            //List<int> alreadyUsed = new List<int> { };
            
            //for (int i = 0; i < businessList.Count; i++)
            //{
            //    if (!alreadyUsed.Contains(i))
            //    {
            //        if (!customMode || businessList.Count > 1)
            //        {
            //            Sessions = businessList[i].Sessions;
            //            PageViews = businessList[i].PageViews;
            //            UnitsOrdered = businessList[i].UnitsOrdered;
            //            UnitsOrderedB2B = businessList[i].UnitsOrderedB2B;
            //            OrderedProductSales = businessList[i].OrderedProductSales;
            //            OrderedProductSalesB2B = businessList[i].OrderedProductSalesB2B;
            //            TotalOrderItems = businessList[i].TotalOrderItems;
            //            TotalOrderItemsB2B = businessList[i].TotalOrderItemsB2B;
            //        }
            //        if (i < (businessList.Count - 1))
            //        {
            //            for (int j = i + 1; j < businessList.Count; j++)
            //            {
            //                if (businessList[i].MarketPlaceId == businessList[j].MarketPlaceId && businessList[i].SKU.Equals(businessList[j].SKU) && businessList[i].ProductId == businessList[j].ProductId)
            //                {
            //                    Sessions += businessList[j].Sessions;
            //                    PageViews += businessList[j].PageViews;
            //                    UnitsOrdered += businessList[j].UnitsOrdered;
            //                    UnitsOrderedB2B += businessList[j].UnitsOrderedB2B;
            //                    OrderedProductSales += businessList[j].OrderedProductSales;
            //                    OrderedProductSalesB2B += businessList[j].OrderedProductSalesB2B;
            //                    TotalOrderItems += businessList[j].TotalOrderItems;
            //                    TotalOrderItemsB2B += businessList[j].TotalOrderItemsB2B;
            //                    alreadyUsed.Add(j);
            //                }
            //                else if ((currentProductIds.Contains(businessList[i].ProductId) || currentProductIds.Contains(businessList[j].ProductId)) && customMode)
            //                {
            //                    Sessions += businessList[j].Sessions;
            //                    PageViews += businessList[j].PageViews;
            //                    UnitsOrdered += businessList[j].UnitsOrdered;
            //                    UnitsOrderedB2B += businessList[j].UnitsOrderedB2B;
            //                    OrderedProductSales += businessList[j].OrderedProductSales;
            //                    OrderedProductSalesB2B += businessList[j].OrderedProductSalesB2B;
            //                    TotalOrderItems += businessList[j].TotalOrderItems;
            //                    TotalOrderItemsB2B += businessList[j].TotalOrderItemsB2B;
            //                    alreadyUsed.Add(j);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            Sessions += businessList[i].Sessions;
            //            PageViews += businessList[i].PageViews;
            //            UnitsOrdered += businessList[i].UnitsOrdered;
            //            UnitsOrderedB2B += businessList[i].UnitsOrderedB2B;
            //            OrderedProductSales += businessList[i].OrderedProductSales;
            //            OrderedProductSalesB2B += businessList[i].OrderedProductSalesB2B;
            //            TotalOrderItems += businessList[i].TotalOrderItems;
            //            TotalOrderItemsB2B += businessList[i].TotalOrderItemsB2B;
            //            alreadyUsed.Add(i);
            //        }
            //        //summaryAdvProductsList.Add(ТО, ШО ПОЛУЧИЛОСЬ ОТ СУММИРОВАНИЯ + ДОПОЛНИТЕЛЬНО СЧИТАЕМ ТО, ЧТО НАДО ПОСЧИТАТЬ);

            //        if (Sessions != 0)
            //            businessList[i].SessionPercentage = Math.Round((double)businessList[i].Sessions / Sessions * 100, 2);
            //        else
            //            businessList[i].SessionPercentage = 0;

            //        if (PageViews != 0)
            //            businessList[i].PageViewsPercentage = Math.Round((double)businessList[i].PageViews / PageViews * 100, 2);
            //        else
            //            businessList[i].PageViewsPercentage = 0;

            //        if (businessList[i].Sessions != 0)
            //            businessList[i].UnitSessionPercentage = Math.Round((double)businessList[i].UnitsOrdered / businessList[i].Sessions * 100, 2);
            //        else
            //            businessList[i].UnitSessionPercentage = 0;

            //        if (businessList[i].Sessions != 0)
            //            businessList[i].UnitSessionPercentageB2B = Math.Round((double)businessList[i].UnitsOrderedB2B / businessList[i].Sessions * 100, 2);
            //        else
            //            businessList[i].UnitSessionPercentageB2B = 0;


            //        summaryBusinessList.Add(new ReportBusinessModel());

            //        summaryBusinessList[summaryBusinessList.Count - 1].UpdateDate = businessList[i].UpdateDate;
            //        summaryBusinessList[summaryBusinessList.Count - 1].MarketPlaceId = businessList[i].MarketPlaceId;
            //        summaryBusinessList[summaryBusinessList.Count - 1].SKU = businessList[i].SKU;
            //        summaryBusinessList[summaryBusinessList.Count - 1].Sessions = Sessions;
            //        summaryBusinessList[summaryBusinessList.Count - 1].UnitSessionPercentage = SessionPercentage;
            //        summaryBusinessList[summaryBusinessList.Count - 1].PageViews = PageViews;
            //        summaryBusinessList[summaryBusinessList.Count - 1].PageViewsPercentage = PageViewPercentage;
            //        summaryBusinessList[summaryBusinessList.Count - 1].UnitsOrdered = UnitsOrdered;
            //        summaryBusinessList[summaryBusinessList.Count - 1].UnitsOrderedB2B = UnitsOrderedB2B;
            //        summaryBusinessList[summaryBusinessList.Count - 1].UnitSessionPercentage = UnitSessionPercentage;
            //        summaryBusinessList[summaryBusinessList.Count - 1].UnitSessionPercentageB2B = UnitSessionPercentageB2B;
            //        summaryBusinessList[summaryBusinessList.Count - 1].OrderedProductSales = OrderedProductSales;
            //        summaryBusinessList[summaryBusinessList.Count - 1].OrderedProductSalesB2B = OrderedProductSalesB2B;
            //        summaryBusinessList[summaryBusinessList.Count - 1].TotalOrderItems = TotalOrderItems;
            //        summaryBusinessList[summaryBusinessList.Count - 1].TotalOrderItemsB2B = TotalOrderItemsB2B;
            //        summaryBusinessList[summaryBusinessList.Count - 1].ProductId = businessList[i].ProductId;
            //    }
            //}
            //businessList.Clear();
            //foreach (var t in summaryBusinessList)
            //{
            //    businessList.Add(t);
            //}
        }

        private string GetProductASINBySkuAndMarketplaceId(string _sku, int _marketplaceid)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].SKU.Equals(_sku) && pList[i].MarketPlaceId == _marketplaceid)
                    return pList[i].ASIN;
            }
            return "NOT_FOUND";
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
            
            lb_StartDate.Text = mc_StartDate.SelectionStart.ToShortDateString();
        }

        /* Изменяем дату окончания в календаре */
        private void mc_EndDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate = mc_EndDate.SelectionEnd;
            
            lb_EndDate.Text = mc_EndDate.SelectionStart.ToShortDateString();
        }

        /* Отобразить данные по дням за месяц */
        private void btn_Daily_Click(object sender, EventArgs e)
        {
            dailyMode = true;
            weeklyMode = false;
            monthlyMode = false;
            customMode = false;

            //mc_StartDate.Enabled = false;
            //mc_EndDate.Enabled = false;

            //dtStartList.Clear();
            //dtEndList.Clear();

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);

            //DateTime dd = DateTime.Today;
            //dd = dd.Subtract(new TimeSpan(30, 0, 0, 0, 0));

            //StartDate = dd;
            //EndDate = dd.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные по неделям за год */
        private void btn_Weekly_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = true;
            monthlyMode = false;
            customMode = false;

            //mc_StartDate.Enabled = false;
            //mc_EndDate.Enabled = false;

            //dtStartList.Clear();
            //dtEndList.Clear();

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);


            //DateTime dd = DateTime.Today;
            //dd = dd.Subtract(new TimeSpan(365, 0, 0, 0, 0));

            //StartDate = dd;
            //EndDate = dd.AddHours(23).AddMinutes(59);
        }

        /* Отобразить данные по месяцам за год */
        private void btn_Monthly_Click(object sender, EventArgs e)
        {
            dailyMode = false;
            weeklyMode = false;
            monthlyMode = true;
            customMode = false;

            //mc_StartDate.Enabled = false;
            //mc_EndDate.Enabled = false;

            //dtStartList.Clear();
            //dtEndList.Clear();

            btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);

            //DateTime dd = DateTime.Today;
            //dd = dd.Subtract(new TimeSpan(365, 0, 0, 0, 0));

            //StartDate = dd;
            //EndDate = dd.AddHours(23).AddMinutes(59);
        }

        private void btn_Customly_Click(object sender, EventArgs e)
        {
            //dailyMode = false;
            //weeklyMode = false;
            //monthlyMode = false;
            //customMode = true;

            //btn_Daily.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            //btn_Weekly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            //btn_Monthly.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            //btn_Customly.BackColor = Color.FromKnownColor(KnownColor.LightSeaGreen);

            //mc_StartDate.Enabled = true;
            //mc_EndDate.Enabled = true;

            //StartDate = mc_StartDate.SelectionStart;
            //EndDate = mc_EndDate.SelectionEnd;

            //lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            //lb_EndDate.Text = EndDate.ToString().Substring(0, 10);
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
                
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

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
                        //получаем данные продаж
                        businessList.Clear();
                        businessResult = businessController.GetFinalABusinessReport(start_date, end_date, marketplaces, productIds);

                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(start_date, end_date, marketplaces, productIds, new List<int> { }, new List<string> { });

                        if (businessResult == 1 && advProductsResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts
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
                        //получаем данные продаж
                        businessList.Clear();
                        businessResult = businessController.GetFinalABusinessReport(start_date, end_date, marketplaces, productIds);

                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(start_date, end_date, marketplaces, productIds, new List<int> { }, new List<string> { });

                        if (businessResult == 1 && advProductsResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts
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
                else if (monthlyMode)
                {
                    DateTime start_date, end_date;
                    end_date = EndDate;
                    start_date = end_date.AddDays(-30).AddHours(-23).AddMinutes(-59).AddSeconds(-59);
                    int diff = ((EndDate - StartDate).Days + 1) / 30;

                    List<int> marketplaces, productIds;
                    marketplaces = GetMPIdsByNames(checkedMarkeplaces);
                    productIds = GetProductIds();

                    for (int i = 0; i < diff; i++)
                    {
                        //получаем данные продаж
                        businessList.Clear();
                        businessResult = businessController.GetFinalABusinessReport(start_date, end_date, marketplaces, productIds);

                        //получаем данные рекламы
                        advProductsList.Clear();
                        advProductsResult = advertController.GetFinalAdvertisingProductsReport(start_date, end_date, marketplaces, productIds, new List<int> { }, new List<string> { });

                        if (businessResult == 1 && advProductsResult == 1)
                        {
                            if (firstRun)
                            {
                                //считаем окончательный список из businessReport и sponsoredProducts
                                DrawTable(start_date, end_date, true);
                                firstRun = false;
                            }
                            else
                                DrawTable(start_date, end_date, false);
                        }
                        else
                            MessageBox.Show("При обработке запроса произошла ошибка.", "Ошибка");

                        start_date = start_date.AddDays(-30);
                        end_date = end_date.AddDays(-30);
                    }                    
                }

                if (dataGridView1.ColumnCount > 0)
                {
                    DrawTableLastColumn();
                }
                this.Cursor = Cursors.Default;
                this.Enabled = true;
            }
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

            for (int i = 0; i < businessList.Count; i++)
            {
                sessionsOrganic += businessList[i].Sessions;
                oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;

            }

            for (int i = 0; i < advProductsList.Count; i++)
            {
                sessionsAdv += advProductsList[i].Clicks;
                ordersAdv += advProductsList[i].Orders;

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
            
            for (int i = 0; i < businessList.Count; i++)
            {
                sessionsOrganic += businessList[i].Sessions;
                oredersGeneral += businessList[i].TotalOrderItems + businessList[i].TotalOrderItemsB2B;
            }

            for (int i = 0; i < advProductsList.Count; i++)
            {
                sessionsAdv += advProductsList[i].Clicks;
                ordersAdv += advProductsList[i].Orders;
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

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
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
