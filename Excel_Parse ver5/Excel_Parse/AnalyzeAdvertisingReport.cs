using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    class AnalyzeAdvertisingReport
    {
        private List<AdvertisingProductsModel> advProductsListNew;
        private List<AdvertisingProductsModel> summaryAdvProductsListNew;

        private List<AdvertisingProductsModel> advProductsListOld;
        private List<AdvertisingProductsModel> summaryAdvProductsListOld;

        private ProductsController prodControl;
        private MarketplaceController marketplaceControl;
        
        private List<ReportObject> resultList;
        
        private List<MarketplaceModel> mpList;
        private List<ProductsModel> pList;

        private SqlConnection connection;
        private SqlCommand command;

        bool byImpressions, bySales, bySpend, byACoS, byOrders, byUnits, byConversion;
        private DateTime startNew, endNew, startOld, endOld;


        public AnalyzeAdvertisingReport()
        {
            connection = DBData.GetDBConnection();            
        }

        public void AnalyzeKeywords(DataGridView _dgv, string _mode, DateTime _startDate, DateTime _endDate, List<AdvertisingProductsModel> _advProductsList)
        {
            prodControl = new ProductsController(this);
            marketplaceControl = new MarketplaceController(this);

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };

            advProductsListNew = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListNew = new List<AdvertisingProductsModel> { };

            advProductsListOld = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListOld = new List<AdvertisingProductsModel> { };

            resultList = new List<ReportObject> { };

            prodControl.GetProductsAllJOIN();
            marketplaceControl.GetMarketplaces();

            PrepareDatesList(_startDate, _endDate);     //вычисляем даты 1го и 2го периодов
            
            foreach (var t in _advProductsList)         //сохраняем данные периода New
            {
                advProductsListNew.Add(t);
            }
            MakeSummaryAdvProductListNewTargeting();

            DrawTableTargetings(_dgv);                      //рисуем таблицу

            GetAdvertisingDataTargeting();              //получаем данные периода Old из БД            
            MakeSummaryAdvProductListOldTargeting();

            if (_mode.Equals("impressions"))
            {
                byImpressions = true;
                GetDiffValues_Impressions_Targeting();              //считаем разницу    
            }
            else if (_mode.Equals("sales"))
            {
                bySales = true;
                GetDiffValues_Sales_Targeting();
            }
            else if (_mode.Equals("spend"))
            {
                bySpend = true;
                GetDiffValues_Spend_Targeting();
            }
            else if (_mode.Equals("orders"))
            {
                byOrders = true;
                GetDiffValues_Orders_Targeting();
            }
            else if (_mode.Equals("units"))
            {
                byUnits = true;
                GetDiffValues_Units_Targeting();
            }
            else if (_mode.Equals("conversion"))
            {
                byConversion = true;
                GetDiffValues_Conversion_Targeting();
                _dgv.Columns[9].Visible = false;
            }
            
            GetUniqueValuesTargeting();                              //удаляем дубли, получаем список с уникальными значениями
            SortResultListByDiff();                         //сортируем
            FillTheTable(_dgv);                             //заносим данные в таблицу
        }

        public void AnalyzeAdGroups(DataGridView _dgv, string _mode, DateTime _startDate, DateTime _endDate, List<AdvertisingProductsModel> _advProductsList)
        {
            prodControl = new ProductsController(this);
            marketplaceControl = new MarketplaceController(this);

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };

            advProductsListNew = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListNew = new List<AdvertisingProductsModel> { };

            advProductsListOld = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListOld = new List<AdvertisingProductsModel> { };

            resultList = new List<ReportObject> { };

            prodControl.GetProductsAllJOIN();
            marketplaceControl.GetMarketplaces();

            PrepareDatesList(_startDate, _endDate);     //вычисляем даты 1го и 2го периодов

            foreach (var t in _advProductsList)         //сохраняем данные периода New
            {
                advProductsListNew.Add(t);
            }
            MakeSummaryAdvProductListNewAdGroups();

            DrawTableAdGroups(_dgv);                      //рисуем таблицу

            GetAdvertisingDataAdGroups();              //получаем данные периода Old из БД            
            MakeSummaryAdvProductListOldAdGroups();

            if (_mode.Equals("impressions"))
            {
                byImpressions = true;
                GetDiffValues_Impressions_AdGroups();              //считаем разницу    
            }
            else if (_mode.Equals("sales"))
            {
                bySales = true;
                GetDiffValues_Sales_AdGroups();
            }
            else if (_mode.Equals("spend"))
            {
                bySpend = true;
                GetDiffValues_Spend_AdGroups();
            }
            else if (_mode.Equals("orders"))
            {
                byOrders = true;
                GetDiffValues_Orders_AdGroups();
            }
            else if (_mode.Equals("units"))
            {
                byUnits = true;
                GetDiffValues_Units_AdGroups();
            }
            else if (_mode.Equals("conversion"))
            {
                byConversion = true;
                GetDiffValues_Conversion_AdGroups();
                _dgv.Columns[9].Visible = false;
            }

            GetUniqueValuesAdGroups();                              //удаляем дубли, получаем список с уникальными значениями
            SortResultListByDiff();                         //сортируем
            FillTheTable(_dgv);                             //заносим данные в таблицу

        }

        public void AnalyzeCampaigns(DataGridView _dgv, string _mode, DateTime _startDate, DateTime _endDate, List<AdvertisingProductsModel> _advProductsList)
        {
            prodControl = new ProductsController(this);
            marketplaceControl = new MarketplaceController(this);

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };

            advProductsListNew = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListNew = new List<AdvertisingProductsModel> { };

            advProductsListOld = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListOld = new List<AdvertisingProductsModel> { };

            resultList = new List<ReportObject> { };

            prodControl.GetProductsAllJOIN();
            marketplaceControl.GetMarketplaces();

            PrepareDatesList(_startDate, _endDate);     //вычисляем даты 1го и 2го периодов

            foreach (var t in _advProductsList)         //сохраняем данные периода New
            {
                advProductsListNew.Add(t);
            }
            MakeSummaryAdvProductListNewCampaigns();

            DrawTableCampaigns(_dgv);                      //рисуем таблицу

            GetAdvertisingDataCampaigns();              //получаем данные периода Old из БД            
            MakeSummaryAdvProductListOldCampaigns();

            if (_mode.Equals("impressions"))
            {
                byImpressions = true;
                GetDiffValues_Impressions_Campaigns();              //считаем разницу    
            }
            else if (_mode.Equals("sales"))
            {
                bySales = true;
                GetDiffValues_Sales_Campaigns();
            }
            else if (_mode.Equals("spend"))
            {
                bySpend = true;
                GetDiffValues_Spend_Campaigns();
            }
            else if (_mode.Equals("orders"))
            {
                byOrders = true;
                GetDiffValues_Orders_Campaigns();
            }
            else if (_mode.Equals("units"))
            {
                byUnits = true;
                GetDiffValues_Units_Campaigns();
            }
            else if (_mode.Equals("conversion"))
            {
                byConversion = true;
                GetDiffValues_Conversion_Campaigns();
                _dgv.Columns[9].Visible = false;
            }

            GetUniqueValuesCampaigns();                              //удаляем дубли, получаем список с уникальными значениями
            SortResultListByDiff();                         //сортируем
            FillTheTable(_dgv);                             //заносим данные в таблицу
        }

        public void AnalyzeFull()
        {

        }






        
        /* Получаем данные за период 1 из БД для Targeting */
        private int GetAdvertisingDataTargeting()
        {
            string sqlStatement = "";
            int result = 1;
            
            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                sqlStatement = "SELECT * FROM [AdvertisingProducts] WHERE [UpdateDate] between '" + startOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and [ProductId] = " + advProductsListNew[i].ProductId + " and [CampaignId] = " + advProductsListNew[i].CampaignId + " and [AdGroupName] = '" + advProductsListNew[i].AdGroupName + "' and Targeting = '" + advProductsListNew[i].Targeting + "'";
                command = new SqlCommand(sqlStatement, connection);
                if (result != 0)
                    result = Execute_SELECT_Command_ProductsBrands(command);
                else
                    Execute_SELECT_Command_ProductsBrands(command);
            }  

            return result;
        }

        /* Получаем данные за период 1 из БД для AdGroups */
        private int GetAdvertisingDataAdGroups()
        {
            string sqlStatement = "";
            int result = 1;

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                sqlStatement = "SELECT * FROM [AdvertisingProducts] WHERE [UpdateDate] between '" + startOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and [ProductId] = " + advProductsListNew[i].ProductId + " and [CampaignId] = " + advProductsListNew[i].CampaignId + " and [AdGroupName] = '" + advProductsListNew[i].AdGroupName + "'";
                command = new SqlCommand(sqlStatement, connection);
                if (result != 0)
                    result = Execute_SELECT_Command_ProductsBrands(command);
                else
                    Execute_SELECT_Command_ProductsBrands(command);
            }

            return result;
        }

        /* Получаем данные за период 1 из БД для Campaigns */
        private int GetAdvertisingDataCampaigns()
        {
            string sqlStatement = "";
            int result = 1;

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                sqlStatement = "SELECT * FROM [AdvertisingProducts] WHERE [UpdateDate] between '" + startOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and [ProductId] = " + advProductsListNew[i].ProductId + " and [CampaignId] = " + advProductsListNew[i].CampaignId;
                command = new SqlCommand(sqlStatement, connection);
                if (result != 0)
                    result = Execute_SELECT_Command_ProductsBrands(command);
                else
                    Execute_SELECT_Command_ProductsBrands(command);
            }

            return result;
        }



        /* Удаляем все повторы с advProductsListOld, при этом создавая новый список с суммарными значениями Targeting */
        private void MakeSummaryAdvProductListOldTargeting()
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

            for (int i = 0; i < advProductsListOld.Count; i++)
            {
                if (i == advProductsListOld.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListOld[i].Impressions;
                    Clicks = advProductsListOld[i].Clicks;
                    Spend = advProductsListOld[i].Spend;
                    Sales = advProductsListOld[i].Sales;
                    Orders = advProductsListOld[i].Orders;
                    Units = advProductsListOld[i].Units;
                    AdvSKUUnits = advProductsListOld[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListOld[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListOld[i].AdvSKUSales;
                    OtherSKUSales = advProductsListOld[i].OtherSKUSales;

                    if (i < (advProductsListOld.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListOld.Count; j++)
                        {
                            if (advProductsListOld[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                            {
                                Impressions += advProductsListOld[j].Impressions;
                                Clicks += advProductsListOld[j].Clicks;
                                Spend += advProductsListOld[j].Spend;
                                Sales += advProductsListOld[j].Sales;
                                Orders += advProductsListOld[j].Orders;
                                Units += advProductsListOld[j].Units;
                                AdvSKUUnits += advProductsListOld[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListOld[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListOld[j].AdvSKUSales;
                                OtherSKUSales += advProductsListOld[j].OtherSKUSales;
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


                    summaryAdvProductsListOld.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].UpdateDate = advProductsListOld[i].UpdateDate;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CurrencyCharCode = advProductsListOld[i].CurrencyCharCode;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignName = advProductsListOld[i].CampaignName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdGroupName = advProductsListOld[i].AdGroupName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Targeting = advProductsListOld[i].Targeting;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MatchType = advProductsListOld[i].MatchType;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Orders = Orders;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Units = Units;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignTypeId = advProductsListOld[i].CampaignTypeId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MarketPlaceId = advProductsListOld[i].MarketPlaceId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignId = advProductsListOld[i].CampaignId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ProductId = advProductsListOld[i].ProductId;
                }
            }
            advProductsListOld.Clear();
            foreach (var t in summaryAdvProductsListOld)
            {
                advProductsListOld.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsListOld, при этом создавая новый список с суммарными значениями AdGroups */
        private void MakeSummaryAdvProductListOldAdGroups()
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

            for (int i = 0; i < advProductsListOld.Count; i++)
            {
                if (i == advProductsListOld.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListOld[i].Impressions;
                    Clicks = advProductsListOld[i].Clicks;
                    Spend = advProductsListOld[i].Spend;
                    Sales = advProductsListOld[i].Sales;
                    Orders = advProductsListOld[i].Orders;
                    Units = advProductsListOld[i].Units;
                    AdvSKUUnits = advProductsListOld[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListOld[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListOld[i].AdvSKUSales;
                    OtherSKUSales = advProductsListOld[i].OtherSKUSales;

                    if (i < (advProductsListOld.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListOld.Count; j++)
                        {
                            if (advProductsListOld[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                            {
                                Impressions += advProductsListOld[j].Impressions;
                                Clicks += advProductsListOld[j].Clicks;
                                Spend += advProductsListOld[j].Spend;
                                Sales += advProductsListOld[j].Sales;
                                Orders += advProductsListOld[j].Orders;
                                Units += advProductsListOld[j].Units;
                                AdvSKUUnits += advProductsListOld[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListOld[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListOld[j].AdvSKUSales;
                                OtherSKUSales += advProductsListOld[j].OtherSKUSales;
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


                    summaryAdvProductsListOld.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].UpdateDate = advProductsListOld[i].UpdateDate;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CurrencyCharCode = advProductsListOld[i].CurrencyCharCode;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignName = advProductsListOld[i].CampaignName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdGroupName = advProductsListOld[i].AdGroupName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Targeting = advProductsListOld[i].Targeting;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MatchType = advProductsListOld[i].MatchType;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Orders = Orders;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Units = Units;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignTypeId = advProductsListOld[i].CampaignTypeId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MarketPlaceId = advProductsListOld[i].MarketPlaceId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignId = advProductsListOld[i].CampaignId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ProductId = advProductsListOld[i].ProductId;
                }
            }
            advProductsListOld.Clear();
            foreach (var t in summaryAdvProductsListOld)
            {
                advProductsListOld.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsListOld, при этом создавая новый список с суммарными значениями Campaigns */
        private void MakeSummaryAdvProductListOldCampaigns()
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

            for (int i = 0; i < advProductsListOld.Count; i++)
            {
                if (i == advProductsListOld.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListOld[i].Impressions;
                    Clicks = advProductsListOld[i].Clicks;
                    Spend = advProductsListOld[i].Spend;
                    Sales = advProductsListOld[i].Sales;
                    Orders = advProductsListOld[i].Orders;
                    Units = advProductsListOld[i].Units;
                    AdvSKUUnits = advProductsListOld[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListOld[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListOld[i].AdvSKUSales;
                    OtherSKUSales = advProductsListOld[i].OtherSKUSales;

                    if (i < (advProductsListOld.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListOld.Count; j++)
                        {
                            if (advProductsListOld[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                            {
                                Impressions += advProductsListOld[j].Impressions;
                                Clicks += advProductsListOld[j].Clicks;
                                Spend += advProductsListOld[j].Spend;
                                Sales += advProductsListOld[j].Sales;
                                Orders += advProductsListOld[j].Orders;
                                Units += advProductsListOld[j].Units;
                                AdvSKUUnits += advProductsListOld[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListOld[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListOld[j].AdvSKUSales;
                                OtherSKUSales += advProductsListOld[j].OtherSKUSales;
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


                    summaryAdvProductsListOld.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].UpdateDate = advProductsListOld[i].UpdateDate;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CurrencyCharCode = advProductsListOld[i].CurrencyCharCode;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignName = advProductsListOld[i].CampaignName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdGroupName = advProductsListOld[i].AdGroupName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Targeting = advProductsListOld[i].Targeting;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MatchType = advProductsListOld[i].MatchType;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Orders = Orders;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Units = Units;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignTypeId = advProductsListOld[i].CampaignTypeId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MarketPlaceId = advProductsListOld[i].MarketPlaceId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignId = advProductsListOld[i].CampaignId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ProductId = advProductsListOld[i].ProductId;
                }
            }
            advProductsListOld.Clear();
            foreach (var t in summaryAdvProductsListOld)
            {
                advProductsListOld.Add(t);
            }
        }



        /* Удаляем все повторы с advProductsListNew, при этом создавая новый список с суммарными значениями Targeting */
        private void MakeSummaryAdvProductListNewTargeting()
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

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                if (i == advProductsListNew.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListNew[i].Impressions;
                    Clicks = advProductsListNew[i].Clicks;
                    Spend = advProductsListNew[i].Spend;
                    Sales = advProductsListNew[i].Sales;
                    Orders = advProductsListNew[i].Orders;
                    Units = advProductsListNew[i].Units;
                    AdvSKUUnits = advProductsListNew[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListNew[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListNew[i].AdvSKUSales;
                    OtherSKUSales = advProductsListNew[i].OtherSKUSales;

                    if (i < (advProductsListNew.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListNew.Count; j++)
                        {
                            if (advProductsListNew[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                            {
                                Impressions += advProductsListNew[j].Impressions;
                                Clicks += advProductsListNew[j].Clicks;
                                Spend += advProductsListNew[j].Spend;
                                Sales += advProductsListNew[j].Sales;
                                Orders += advProductsListNew[j].Orders;
                                Units += advProductsListNew[j].Units;
                                AdvSKUUnits += advProductsListNew[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListNew[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListNew[j].AdvSKUSales;
                                OtherSKUSales += advProductsListNew[j].OtherSKUSales;
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


                    summaryAdvProductsListNew.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].UpdateDate = advProductsListNew[i].UpdateDate;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CurrencyCharCode = advProductsListNew[i].CurrencyCharCode;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignName = advProductsListNew[i].CampaignName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdGroupName = advProductsListNew[i].AdGroupName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Targeting = advProductsListNew[i].Targeting;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MatchType = advProductsListNew[i].MatchType;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Orders = Orders;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Units = Units;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignTypeId = advProductsListNew[i].CampaignTypeId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MarketPlaceId = advProductsListNew[i].MarketPlaceId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignId = advProductsListNew[i].CampaignId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ProductId = advProductsListNew[i].ProductId;
                }
            }
            advProductsListNew.Clear();
            foreach (var t in summaryAdvProductsListNew)
            {
                advProductsListNew.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsListNew, при этом создавая новый список с суммарными значениями AdGroups */
        private void MakeSummaryAdvProductListNewAdGroups()
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

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                if (i == advProductsListNew.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListNew[i].Impressions;
                    Clicks = advProductsListNew[i].Clicks;
                    Spend = advProductsListNew[i].Spend;
                    Sales = advProductsListNew[i].Sales;
                    Orders = advProductsListNew[i].Orders;
                    Units = advProductsListNew[i].Units;
                    AdvSKUUnits = advProductsListNew[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListNew[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListNew[i].AdvSKUSales;
                    OtherSKUSales = advProductsListNew[i].OtherSKUSales;

                    if (i < (advProductsListNew.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListNew.Count; j++)
                        {
                            if (advProductsListNew[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                            {
                                Impressions += advProductsListNew[j].Impressions;
                                Clicks += advProductsListNew[j].Clicks;
                                Spend += advProductsListNew[j].Spend;
                                Sales += advProductsListNew[j].Sales;
                                Orders += advProductsListNew[j].Orders;
                                Units += advProductsListNew[j].Units;
                                AdvSKUUnits += advProductsListNew[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListNew[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListNew[j].AdvSKUSales;
                                OtherSKUSales += advProductsListNew[j].OtherSKUSales;
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


                    summaryAdvProductsListNew.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].UpdateDate = advProductsListNew[i].UpdateDate;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CurrencyCharCode = advProductsListNew[i].CurrencyCharCode;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignName = advProductsListNew[i].CampaignName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdGroupName = advProductsListNew[i].AdGroupName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Targeting = advProductsListNew[i].Targeting;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MatchType = advProductsListNew[i].MatchType;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Orders = Orders;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Units = Units;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignTypeId = advProductsListNew[i].CampaignTypeId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MarketPlaceId = advProductsListNew[i].MarketPlaceId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignId = advProductsListNew[i].CampaignId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ProductId = advProductsListNew[i].ProductId;
                }
            }
            advProductsListNew.Clear();
            foreach (var t in summaryAdvProductsListNew)
            {
                advProductsListNew.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsListNewA, при этом создавая новый список с суммарными значениями Campaigns */
        private void MakeSummaryAdvProductListNewCampaigns()
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

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                if (i == advProductsListNew.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListNew[i].Impressions;
                    Clicks = advProductsListNew[i].Clicks;
                    Spend = advProductsListNew[i].Spend;
                    Sales = advProductsListNew[i].Sales;
                    Orders = advProductsListNew[i].Orders;
                    Units = advProductsListNew[i].Units;
                    AdvSKUUnits = advProductsListNew[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListNew[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListNew[i].AdvSKUSales;
                    OtherSKUSales = advProductsListNew[i].OtherSKUSales;

                    if (i < (advProductsListNew.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListNew.Count; j++)
                        {
                            if (advProductsListNew[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                            {
                                Impressions += advProductsListNew[j].Impressions;
                                Clicks += advProductsListNew[j].Clicks;
                                Spend += advProductsListNew[j].Spend;
                                Sales += advProductsListNew[j].Sales;
                                Orders += advProductsListNew[j].Orders;
                                Units += advProductsListNew[j].Units;
                                AdvSKUUnits += advProductsListNew[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListNew[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListNew[j].AdvSKUSales;
                                OtherSKUSales += advProductsListNew[j].OtherSKUSales;
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


                    summaryAdvProductsListNew.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].UpdateDate = advProductsListNew[i].UpdateDate;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CurrencyCharCode = advProductsListNew[i].CurrencyCharCode;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignName = advProductsListNew[i].CampaignName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdGroupName = advProductsListNew[i].AdGroupName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Targeting = advProductsListNew[i].Targeting;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MatchType = advProductsListNew[i].MatchType;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Orders = Orders;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Units = Units;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignTypeId = advProductsListNew[i].CampaignTypeId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MarketPlaceId = advProductsListNew[i].MarketPlaceId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignId = advProductsListNew[i].CampaignId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ProductId = advProductsListNew[i].ProductId;
                }
            }
            advProductsListNew.Clear();
            foreach (var t in summaryAdvProductsListNew)
            {
                advProductsListNew.Add(t);
            }
        }



        /* Создаем столбцы таблицы Targeting */
        private void DrawTableTargetings(DataGridView _dgv_Analyzed)
        {
            _dgv_Analyzed.Rows.Clear();
            _dgv_Analyzed.Columns.Clear();

            _dgv_Analyzed.Columns.Add("product", "Товар");
            _dgv_Analyzed.Columns.Add("marketplace", "Маркетплейс");
            _dgv_Analyzed.Columns.Add("campaign", "Campaign");
            _dgv_Analyzed.Columns.Add("AdGroupName", "AdGroup");
            _dgv_Analyzed.Columns.Add("Targeting", "Targeting");
            _dgv_Analyzed.Columns.Add("MatchType", "Match Type");
            _dgv_Analyzed.Columns.Add("preperiod", "Позапрошлый период");
            _dgv_Analyzed.Columns.Add("nowperiod", "Прошлый период");
            _dgv_Analyzed.Columns.Add("diff", "Разница");
            _dgv_Analyzed.Columns.Add("diffperc", "Разница %");

            _dgv_Analyzed.Columns[5].Visible = false;
            //_dgv_AdvProducts.Columns[0].Width = 70;
            _dgv_Analyzed.Columns[0].Width = 200;
            _dgv_Analyzed.Columns[1].Width = 150;
            _dgv_Analyzed.Columns[2].Width = 180;
            _dgv_Analyzed.Columns[3].Width = 180;
            _dgv_Analyzed.Columns[4].Width = 200;

            for (int i = 0; i < 10; i++)
            {
                _dgv_Analyzed.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 6)
                    _dgv_Analyzed.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /* Создаем столбцы таблицы AdGroups */
        private void DrawTableAdGroups(DataGridView _dgv_Analyzed)
        {
            _dgv_Analyzed.Rows.Clear();
            _dgv_Analyzed.Columns.Clear();

            _dgv_Analyzed.Columns.Add("product", "Товар");
            _dgv_Analyzed.Columns.Add("marketplace", "Маркетплейс");
            _dgv_Analyzed.Columns.Add("campaign", "Campaign");
            _dgv_Analyzed.Columns.Add("AdGroupName", "AdGroup");
            _dgv_Analyzed.Columns.Add("Targeting", "Targeting");
            _dgv_Analyzed.Columns.Add("MatchType", "Match Type");
            _dgv_Analyzed.Columns.Add("preperiod", "Позапрошлый период");
            _dgv_Analyzed.Columns.Add("nowperiod", "Прошлый период");
            _dgv_Analyzed.Columns.Add("diff", "Разница");
            _dgv_Analyzed.Columns.Add("diffperc", "Разница %");

            _dgv_Analyzed.Columns[5].Visible = false;
            //_dgv_AdvProducts.Columns[0].Width = 70;

            _dgv_Analyzed.Columns[0].Width = 200;
            _dgv_Analyzed.Columns[1].Width = 150;
            _dgv_Analyzed.Columns[2].Width = 180;
            _dgv_Analyzed.Columns[3].Width = 180;
            _dgv_Analyzed.Columns[4].Width = 200;

            for (int i = 0; i < 10; i++)
            {
                _dgv_Analyzed.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 6)
                    _dgv_Analyzed.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /* Создаем столбцы таблицы Campaigns */
        private void DrawTableCampaigns(DataGridView _dgv_Analyzed)
        {
            _dgv_Analyzed.Rows.Clear();
            _dgv_Analyzed.Columns.Clear();

            _dgv_Analyzed.Columns.Add("product", "Товар");
            _dgv_Analyzed.Columns.Add("marketplace", "Маркетплейс");
            _dgv_Analyzed.Columns.Add("campaign", "Campaign");
            _dgv_Analyzed.Columns.Add("AdGroupName", "AdGroup");
            _dgv_Analyzed.Columns.Add("Targeting", "Targeting");
            _dgv_Analyzed.Columns.Add("MatchType", "Match Type");
            _dgv_Analyzed.Columns.Add("preperiod", "Позапрошлый период");
            _dgv_Analyzed.Columns.Add("nowperiod", "Прошлый период");
            _dgv_Analyzed.Columns.Add("diff", "Разница");
            _dgv_Analyzed.Columns.Add("diffperc", "Разница %");

            _dgv_Analyzed.Columns[5].Visible = false;
            //_dgv_AdvProducts.Columns[0].Width = 70;
            _dgv_Analyzed.Columns[3].Visible = false;
            _dgv_Analyzed.Columns[4].Visible = false;

            _dgv_Analyzed.Columns[0].Width = 200;
            _dgv_Analyzed.Columns[1].Width = 150;
            _dgv_Analyzed.Columns[2].Width = 180;
            _dgv_Analyzed.Columns[3].Width = 180;
            _dgv_Analyzed.Columns[4].Width = 200;

            for (int i = 0; i < 10; i++)
            {
                _dgv_Analyzed.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 6)
                    _dgv_Analyzed.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        

        /* Считаем разницу по Impressions в Targeting */
        private int GetDiffValues_Impressions_Targeting()
        {
            int imprNew = 0;
            int imprOld = 0;
            int imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Impressions;
                            imprOld = advProductsListOld[j].Impressions;
                            imprDiff = advProductsListNew[i].Impressions - advProductsListOld[j].Impressions;
                            if (advProductsListOld[j].Impressions != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Impressions) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Impressions;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Impressions;
                                tmp.valNew = advProductsListNew[i].Impressions;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Impressions;
                            imprOld = advProductsListOld[i].Impressions;
                            imprDiff = advProductsListNew[j].Impressions - advProductsListOld[i].Impressions;
                            if (advProductsListOld[i].Impressions != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Impressions) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Impressions;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Impressions;
                                tmp.valNew = advProductsListNew[j].Impressions;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Sales в Targeting */
        private int GetDiffValues_Sales_Targeting()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Sales;
                            imprOld = advProductsListOld[j].Sales;
                            imprDiff = advProductsListNew[i].Sales - advProductsListOld[j].Sales;
                            if (advProductsListOld[j].Sales != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Sales) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Sales;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Sales;
                                tmp.valNew = advProductsListNew[i].Sales;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Sales;
                            imprOld = advProductsListOld[i].Sales;
                            imprDiff = advProductsListNew[j].Sales - advProductsListOld[i].Sales;
                            if (advProductsListOld[i].Sales != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Sales) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Sales;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Sales;
                                tmp.valNew = advProductsListNew[j].Sales;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Spend в Targeting */
        private int GetDiffValues_Spend_Targeting()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Spend;
                            imprOld = advProductsListOld[j].Spend;
                            imprDiff = advProductsListNew[i].Spend - advProductsListOld[j].Spend;
                            if (advProductsListOld[j].Spend != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Spend) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Spend;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Spend;
                                tmp.valNew = advProductsListNew[i].Spend;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Spend;
                            imprOld = advProductsListOld[i].Spend;
                            imprDiff = advProductsListNew[j].Spend - advProductsListOld[i].Spend;
                            if (advProductsListOld[i].Spend != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Spend) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Spend;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Spend;
                                tmp.valNew = advProductsListNew[j].Spend;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Orders в Targeting */
        private int GetDiffValues_Orders_Targeting()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Orders;
                            imprOld = advProductsListOld[j].Orders;
                            imprDiff = advProductsListNew[i].Orders - advProductsListOld[j].Orders;
                            if (advProductsListOld[j].Orders != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Orders) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Orders;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Orders;
                                tmp.valNew = advProductsListNew[i].Orders;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Orders;
                            imprOld = advProductsListOld[i].Orders;
                            imprDiff = advProductsListNew[j].Orders - advProductsListOld[i].Orders;
                            if (advProductsListOld[i].Orders != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Orders) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Orders;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Orders;
                                tmp.valNew = advProductsListNew[j].Orders;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Units в Targeting */
        private int GetDiffValues_Units_Targeting()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Units;
                            imprOld = advProductsListOld[j].Units;
                            imprDiff = advProductsListNew[i].Units - advProductsListOld[j].Units;
                            if (advProductsListOld[j].Units != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Units) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Units;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Units;
                                tmp.valNew = advProductsListNew[i].Units;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Units;
                            imprOld = advProductsListOld[i].Units;
                            imprDiff = advProductsListNew[j].Units - advProductsListOld[i].Units;
                            if (advProductsListOld[i].Units != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Units) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Units;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Units;
                                tmp.valNew = advProductsListNew[j].Units;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Conversion в Targeting */
        private int GetDiffValues_Conversion_Targeting()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].ConversionRate;
                            imprOld = advProductsListOld[j].ConversionRate;
                            imprDiff = advProductsListNew[i].ConversionRate - advProductsListOld[j].ConversionRate;
                            if (advProductsListOld[j].ConversionRate != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].ConversionRate) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].ConversionRate;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].ConversionRate;
                                tmp.valNew = advProductsListNew[i].ConversionRate;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].ConversionRate;
                            imprOld = advProductsListOld[i].ConversionRate;
                            imprDiff = advProductsListNew[j].ConversionRate - advProductsListOld[i].ConversionRate;
                            if (advProductsListOld[i].ConversionRate != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].ConversionRate) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].ConversionRate;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].ConversionRate;
                                tmp.valNew = advProductsListNew[j].ConversionRate;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }



        /* Считаем разницу по Impressions в AdGroups */
        private int GetDiffValues_Impressions_AdGroups()
        {
            int imprNew = 0;
            int imprOld = 0;
            int imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Impressions;
                            imprOld = advProductsListOld[j].Impressions;
                            imprDiff = advProductsListNew[i].Impressions - advProductsListOld[j].Impressions;
                            if (advProductsListOld[j].Impressions != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Impressions) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Impressions;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Impressions;
                                tmp.valNew = advProductsListNew[i].Impressions;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Impressions;
                            imprOld = advProductsListOld[i].Impressions;
                            imprDiff = advProductsListNew[j].Impressions - advProductsListOld[i].Impressions;
                            if (advProductsListOld[i].Impressions != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Impressions) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Impressions;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Impressions;
                                tmp.valNew = advProductsListNew[j].Impressions;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Sales в AdGroups */
        private int GetDiffValues_Sales_AdGroups()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Sales;
                            imprOld = advProductsListOld[j].Sales;
                            imprDiff = advProductsListNew[i].Sales - advProductsListOld[j].Sales;
                            if (advProductsListOld[j].Sales != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Sales) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Sales;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Sales;
                                tmp.valNew = advProductsListNew[i].Sales;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Sales;
                            imprOld = advProductsListOld[i].Sales;
                            imprDiff = advProductsListNew[j].Sales - advProductsListOld[i].Sales;
                            if (advProductsListOld[i].Sales != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Sales) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Sales;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Sales;
                                tmp.valNew = advProductsListNew[j].Sales;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Spend в AdGroups */
        private int GetDiffValues_Spend_AdGroups()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Spend;
                            imprOld = advProductsListOld[j].Spend;
                            imprDiff = advProductsListNew[i].Spend - advProductsListOld[j].Spend;
                            if (advProductsListOld[j].Spend != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Spend) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Spend;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Spend;
                                tmp.valNew = advProductsListNew[i].Spend;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Spend;
                            imprOld = advProductsListOld[i].Spend;
                            imprDiff = advProductsListNew[j].Spend - advProductsListOld[i].Spend;
                            if (advProductsListOld[i].Spend != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Spend) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Spend;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Spend;
                                tmp.valNew = advProductsListNew[j].Spend;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Orders в AdGroups */
        private int GetDiffValues_Orders_AdGroups()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Orders;
                            imprOld = advProductsListOld[j].Orders;
                            imprDiff = advProductsListNew[i].Orders - advProductsListOld[j].Orders;
                            if (advProductsListOld[j].Orders != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Orders) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Orders;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Orders;
                                tmp.valNew = advProductsListNew[i].Orders;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Orders;
                            imprOld = advProductsListOld[i].Orders;
                            imprDiff = advProductsListNew[j].Orders - advProductsListOld[i].Orders;
                            if (advProductsListOld[i].Orders != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Orders) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Orders;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Orders;
                                tmp.valNew = advProductsListNew[j].Orders;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Units в AdGroups */
        private int GetDiffValues_Units_AdGroups()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Units;
                            imprOld = advProductsListOld[j].Units;
                            imprDiff = advProductsListNew[i].Units - advProductsListOld[j].Units;
                            if (advProductsListOld[j].Units != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Units) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Units;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Units;
                                tmp.valNew = advProductsListNew[i].Units;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Units;
                            imprOld = advProductsListOld[i].Units;
                            imprDiff = advProductsListNew[j].Units - advProductsListOld[i].Units;
                            if (advProductsListOld[i].Units != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Units) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Units;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Units;
                                tmp.valNew = advProductsListNew[j].Units;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Conversion в AdGroups */
        private int GetDiffValues_Conversion_AdGroups()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].ConversionRate;
                            imprOld = advProductsListOld[j].ConversionRate;
                            imprDiff = advProductsListNew[i].ConversionRate - advProductsListOld[j].ConversionRate;
                            if (advProductsListOld[j].ConversionRate != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].ConversionRate) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].ConversionRate;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].ConversionRate;
                                tmp.valNew = advProductsListNew[i].ConversionRate;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].ConversionRate;
                            imprOld = advProductsListOld[i].ConversionRate;
                            imprDiff = advProductsListNew[j].ConversionRate - advProductsListOld[i].ConversionRate;
                            if (advProductsListOld[i].ConversionRate != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].ConversionRate) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].ConversionRate;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].ConversionRate;
                                tmp.valNew = advProductsListNew[j].ConversionRate;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }



        /* Считаем разницу по Impressions в Campaigns */
        private int GetDiffValues_Impressions_Campaigns()
        {
            int imprNew = 0;
            int imprOld = 0;
            int imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Impressions;
                            imprOld = advProductsListOld[j].Impressions;
                            imprDiff = advProductsListNew[i].Impressions - advProductsListOld[j].Impressions;
                            if (advProductsListOld[j].Impressions != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Impressions) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Impressions;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Impressions;
                                tmp.valNew = advProductsListNew[i].Impressions;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Impressions;
                            imprOld = advProductsListOld[i].Impressions;
                            imprDiff = advProductsListNew[j].Impressions - advProductsListOld[i].Impressions;
                            if (advProductsListOld[i].Impressions != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Impressions) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Impressions;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Impressions;
                                tmp.valNew = advProductsListNew[j].Impressions;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Sales в Campaigns */
        private int GetDiffValues_Sales_Campaigns()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Sales;
                            imprOld = advProductsListOld[j].Sales;
                            imprDiff = advProductsListNew[i].Sales - advProductsListOld[j].Sales;
                            if (advProductsListOld[j].Sales != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Sales) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Sales;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Sales;
                                tmp.valNew = advProductsListNew[i].Sales;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Sales;
                            imprOld = advProductsListOld[i].Sales;
                            imprDiff = advProductsListNew[j].Sales - advProductsListOld[i].Sales;
                            if (advProductsListOld[i].Sales != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Sales) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Sales;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Sales;
                                tmp.valNew = advProductsListNew[j].Sales;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Spend в Campaigns */
        private int GetDiffValues_Spend_Campaigns()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Spend;
                            imprOld = advProductsListOld[j].Spend;
                            imprDiff = advProductsListNew[i].Spend - advProductsListOld[j].Spend;
                            if (advProductsListOld[j].Spend != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Spend) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Spend;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Spend;
                                tmp.valNew = advProductsListNew[i].Spend;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Spend;
                            imprOld = advProductsListOld[i].Spend;
                            imprDiff = advProductsListNew[j].Spend - advProductsListOld[i].Spend;
                            if (advProductsListOld[i].Spend != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Spend) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Spend;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Spend;
                                tmp.valNew = advProductsListNew[j].Spend;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Orders в Campaigns */
        private int GetDiffValues_Orders_Campaigns()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Orders;
                            imprOld = advProductsListOld[j].Orders;
                            imprDiff = advProductsListNew[i].Orders - advProductsListOld[j].Orders;
                            if (advProductsListOld[j].Orders != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Orders) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Orders;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Orders;
                                tmp.valNew = advProductsListNew[i].Orders;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Orders;
                            imprOld = advProductsListOld[i].Orders;
                            imprDiff = advProductsListNew[j].Orders - advProductsListOld[i].Orders;
                            if (advProductsListOld[i].Orders != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Orders) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Orders;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Orders;
                                tmp.valNew = advProductsListNew[j].Orders;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Units в Campaigns */
        private int GetDiffValues_Units_Campaigns()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].Units;
                            imprOld = advProductsListOld[j].Units;
                            imprDiff = advProductsListNew[i].Units - advProductsListOld[j].Units;
                            if (advProductsListOld[j].Units != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].Units) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].Units;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].Units;
                                tmp.valNew = advProductsListNew[i].Units;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].Units;
                            imprOld = advProductsListOld[i].Units;
                            imprDiff = advProductsListNew[j].Units - advProductsListOld[i].Units;
                            if (advProductsListOld[i].Units != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].Units) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].Units;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].Units;
                                tmp.valNew = advProductsListNew[j].Units;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /* Считаем разницу по Conversion в Campaigns */
        private int GetDiffValues_Conversion_Campaigns()
        {
            double imprNew = 0;
            double imprOld = 0;
            double imprDiff = 0;
            double percDiff = 0;

            try
            {
                for (int i = 0; i < advProductsListNew.Count; i++)
                {
                    for (int j = 0; j < advProductsListOld.Count; j++)
                    {
                        if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].MarketPlaceId == advProductsListOld[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[i].ConversionRate;
                            imprOld = advProductsListOld[j].ConversionRate;
                            imprDiff = advProductsListNew[i].ConversionRate - advProductsListOld[j].ConversionRate;
                            if (advProductsListOld[j].ConversionRate != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[j].ConversionRate) * 100;
                            else
                                percDiff = (double)advProductsListNew[i].ConversionRate;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                                tmp.campName = advProductsListNew[i].CampaignName;
                                tmp.adGroup = advProductsListNew[i].AdGroupName;
                                tmp.targeting = advProductsListNew[i].Targeting;
                                tmp.matchType = advProductsListNew[i].MatchType;
                                tmp.valOld = advProductsListOld[j].ConversionRate;
                                tmp.valNew = advProductsListNew[i].ConversionRate;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                for (int i = 0; i < advProductsListOld.Count; i++)
                {
                    for (int j = 0; j < advProductsListNew.Count; j++)
                    {
                        if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].MarketPlaceId == advProductsListNew[j].MarketPlaceId)
                        {
                            imprNew = advProductsListNew[j].ConversionRate;
                            imprOld = advProductsListOld[i].ConversionRate;
                            imprDiff = advProductsListNew[j].ConversionRate - advProductsListOld[i].ConversionRate;
                            if (advProductsListOld[i].ConversionRate != 0)
                                percDiff = ((double)imprDiff / advProductsListOld[i].ConversionRate) * 100;
                            else
                                percDiff = (double)advProductsListNew[j].ConversionRate;
                            if (percDiff >= 20 || percDiff <= -20)
                            {
                                ReportObject tmp = new ReportObject();
                                tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                                tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                                tmp.campName = advProductsListNew[j].CampaignName;
                                tmp.adGroup = advProductsListNew[j].AdGroupName;
                                tmp.targeting = advProductsListNew[j].Targeting;
                                tmp.matchType = advProductsListNew[j].MatchType;
                                tmp.valOld = advProductsListOld[i].ConversionRate;
                                tmp.valNew = advProductsListNew[j].ConversionRate;
                                tmp.diff = imprDiff;
                                tmp.diffPerc = Math.Round(percDiff, 2);

                                resultList.Add(tmp);
                            }
                            imprNew = 0;
                            imprOld = 0;
                            imprDiff = 0;
                            percDiff = 0;
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }




        /* Уникальные значения в окончательном списке после калькуляции разниц */
        private void GetUniqueValuesTargeting()
        {
            for (int i = 0; i < resultList.Count - 1; i++)
            {
                for (int j = 1; j < resultList.Count; j++)
                {
                    if (resultList[i].campName.Equals(resultList[j].campName) && resultList[i].adGroup.Equals(resultList[j].adGroup) && resultList[i].targeting.Equals(resultList[j].targeting) && resultList[i].matchType.Equals(resultList[j].matchType) && resultList[i].marketplace.Equals(resultList[j].marketplace) && resultList[i].valOld == resultList[j].valOld && resultList[i].valNew == resultList[j].valNew && resultList[i].diff == resultList[j].diff)
                    {
                        resultList.RemoveAt(j);
                    }
                }
            }
        }

        /* Уникальные значения в окончательном списке после калькуляции разниц */
        private void GetUniqueValuesAdGroups()
        {
            for (int i = 0; i < resultList.Count - 1; i++)
            {
                for (int j = 1; j < resultList.Count; j++)
                {
                    if (resultList[i].campName.Equals(resultList[j].campName) && resultList[i].adGroup.Equals(resultList[j].adGroup) && resultList[i].marketplace.Equals(resultList[j].marketplace) && resultList[i].valOld == resultList[j].valOld && resultList[i].valNew == resultList[j].valNew && resultList[i].diff == resultList[j].diff)
                    {
                        resultList.RemoveAt(j);
                    }
                }
            }
        }

        /* Уникальные значения в окончательном списке после калькуляции разниц */
        private void GetUniqueValuesCampaigns()
        {
            for (int i = 0; i < resultList.Count - 1; i++)
            {
                for (int j = 1; j < resultList.Count; j++)
                {
                    if (resultList[i].campName.Equals(resultList[j].campName) && resultList[i].marketplace.Equals(resultList[j].marketplace) && resultList[i].valOld == resultList[j].valOld && resultList[i].valNew == resultList[j].valNew && resultList[i].diff == resultList[j].diff)
                    {
                        resultList.RemoveAt(j);
                    }
                }
            }
        }




        /* UNIVERSAL METHOD Подготавливаем даты начала и окончания для 2х периодов */
        private void PrepareDatesList(DateTime _startDate, DateTime _endDate)
        {
            startNew = new DateTime(_startDate.Year, _startDate.Month, _startDate.Day, 0, 0, 0);
            endNew = _endDate.AddHours(23).AddMinutes(59).AddSeconds(59);
            int span = (startNew - endNew).Days - 1;

            startOld = startNew.AddDays(span);
            endOld = endNew.AddDays(span);
        }

        /* UNIVERSAL METHOD Выполняем запрос к БД и заносим полученные данные в advProductsListOld */
        private int Execute_SELECT_Command_ProductsBrands(SqlCommand _command)
        {
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetSponsoredProductsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* UNIVERSAL METHOD Заносим данные в List<AdvertisingProductsModel> */
        private void SetSponsoredProductsToList(IDataRecord record)
        {
            AdvertisingProductsModel adprModel = new AdvertisingProductsModel();
            advProductsListOld.Add(adprModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                advProductsListOld[advProductsListOld.Count - 1].WriteData(i, record[i]);
            }
        }

        /* UNIVERSAL METHOD Сортируем разницу по Impressions */
        private void SortResultListByDiff()
        {
            ReportObject tmpObj;
            for (int i = 1; i < resultList.Count; i++)
            {
                for (int j = 0; j < resultList.Count - i; j++)
                {
                    if (resultList[j].diff > resultList[j + 1].diff)
                    {
                        tmpObj = resultList[j];
                        resultList[j] = resultList[j + 1];
                        resultList[j + 1] = tmpObj;
                    }
                }
            }

            foreach (var t in resultList)
            {
                Console.WriteLine(t.diff);
            }
        }

        /* UNIVERSAL METHOD */
        private string GetMarketplaceNameByMarketplaceId(int _mpId)
        {
            int marketplaceId = (int)_mpId;

            foreach (var t in mpList)
            {
                if (t.MarketPlaceId == marketplaceId)
                    return t.MarketPlaceName;
            }
            return "NOT_FOUND";
        }

        /* UNIVERSAL METHOD */
        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
        }

        /* UNIVERSAL METHOD Заполняем таблицу данными */
        private void FillTheTable(DataGridView _dgv)
        {
            int index;
            for (int i = 0; i < resultList.Count; i++)
            {
                index = _dgv.Rows.Add();

                for (int j = 0; j < resultList[i].ColumnCount; j++)
                {
                    if (j == resultList[i].ColumnCount - 1)
                        _dgv.Rows[index].Cells[j].Value = resultList[i].GetVal(j).ToString() + "%";
                    else
                        _dgv.Rows[index].Cells[j].Value = resultList[i].GetVal(j).ToString();
                }
            }
        }
        
        /* UNIVERSAL METHOD Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* UNIVERSAL METHOD Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

    }
}
