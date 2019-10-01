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
    public partial class AdvertisingReportFilterView : Form
    {
        private AdvertisingReportView mf;
        private DateTime StartDate, EndDate;
        private bool MonthlyMode, WeeklyMode;

        List<string> checkedMarkeplaces, checkedProducts, checkedCampaigns;     

        private List<string> uniqueCampaigns;
        private List<CmapaignAndIdStruct> campsidsList;



        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingProductsModel> summaryAdvProductsList;

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


        private List<AdvertisingProductsModel> filterAdvProductsList;       //список Sponsored Products с применением фильтра по таблице
        private List<AdvertisingBrandsModel> filterAdvBrandsList;           //список Sponsored Brands с применением фильтра по таблице

        private string equalSign;       //знак равенства из textBox
        private bool NoErrors;          //ошибка ввода в textBox пользователем при фильтре по таблице

        /* Главный конструктор */
        public AdvertisingReportFilterView(AdvertisingReportView _mf)
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
        
        /* Применяем фильтры и перерисовываем данные в форме AdvertisingReportView */
        private void btn_Show_Click(object sender, EventArgs e)
        {
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

                result = advertController.GetFinalAdvertisingProductsReport(StartDate, EndDate, GetMPIdsByNames(checkedMarkeplaces), GetProductIdsByNames(checkedProducts), GetCampaignIdsByNames(campsidsList));

                if (result == 1)
                {
                    mf.GetAdvertisingProductsListToShow(advProductsList);
                    filterAdvProductsList = new List<AdvertisingProductsModel> { };
                }

                if (mf.dgv_AdvProducts.RowCount > 0)
                    groupBox1.Enabled = true;
                else
                    groupBox1.Enabled = false;
            }
            else if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Brands"))
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
            }
            
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

        /* Очистить список выбранных маркетплейсов в clb_Marketplace */
        private void btn_Clear_clb_Marketplace_Click(object sender, EventArgs e)
        {
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
        }
        //----------------------------------------------------------------------------------------------------------------------


        /* Выделяем/снимаем выделение товара в clb_Product */
        private void clb_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            clb_Campaign.ClearSelected();
            clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();

            checkedProducts.Clear();
            for (int i = 0; i < clb_Product.CheckedItems.Count; i++)
            {
                checkedProducts.Add(clb_Product.CheckedItems[i].ToString());
            }

            int res = 0;
            if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Products"))
            {       
                res = advertController.GetAdvertisingProductsCampaignAndCampId(GetProductIdsByNames(checkedProducts));
                GetUniqueCampaigns();
            }
            else if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Brands"))
            {
                res = advertController.GetAdvertisingBrandsCampaignAndCampId(GetProductIdsByNames(checkedProducts));
                GetUniqueCampaigns();
            }
            if (res == 1)
            {
                Draw_clb_Campaigns();
            }
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
               

        /* Получаем уникальные названия товаров */
        private void GetUniqueCampaigns()
        {
            uniqueCampaigns = new List<string> { };
            for (int i = 0; i < campsidsList.Count; i++)
            {
                if (!uniqueCampaigns.Contains(campsidsList[i].Key))
                    uniqueCampaigns.Add(campsidsList[i].Key);
            }
        }

        /* Получаем список кампания/кампания_ид из БД */
        public void GetCampaignsAndIds(object _tmp)
        {
            campsidsList = (List<CmapaignAndIdStruct>)_tmp;
        }

        /* Заносим имена кампаний в clb_Campaigns */
        private void Draw_clb_Campaigns()
        {
            clb_Campaign.Items.Clear();
            for (int i = 0; i < uniqueCampaigns.Count; i++)
            {
                clb_Campaign.Items.Add(uniqueCampaigns[i]);
            }
        }

        /* Очистить список выбранных товаров в clb_Products */
        private void btn_Clear_clb_Products_Click(object sender, EventArgs e)
        {
            clb_Campaign.ClearSelected();
            clb_Campaign.Items.Clear();
            checkedCampaigns.Clear();
            clb_Product.ClearSelected();
            checkedProducts.Clear();
            for (int i = 0; i < clb_Product.Items.Count; i++)
            {
                clb_Product.SetItemChecked(i, false);
            }
            clb_Campaign.Items.Clear();
            //clb_Product.ClearSelected();
        }

        //----------------------------------------------------------------------------------------------------------------------


        /* Выделяем/снимаем выделение кампании в clb_Campaign */
        private void clb_Campaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedCampaigns.Clear();
            for (int i = 0; i < clb_Campaign.CheckedItems.Count; i++)
            {
                checkedCampaigns.Add(clb_Campaign.CheckedItems[i].ToString());
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
            clb_Campaign.ClearSelected();
            checkedCampaigns.Clear();

            for (int i = 0; i < clb_Campaign.Items.Count; i++)
            {
                clb_Campaign.SetItemChecked(i, false);
            }
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
            NoErrors = true;

            //if (mf.SponsoredProductMode)                //если имеем дело с Sponsored Products
            //{
            //    for (int i = 0; i < advProductsList.Count; i++)
            //    {
                    
            //    }
            //}
            //else if (mf.SponsoredBrandMode)             //если имеем дело с Sponsored Brands
            //{
            //    for (int i = 0; i < advBrandsList.Count; i++)
            //    {
                    
            //    }
            //}

            this.Cursor = Cursors.Default;
        }

        /* Применить числовой фильтр по таблице */
        private void btn_Go_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            NoErrors = true;

            if (mf.SponsoredProductMode)                //если имеем дело с Sponsored Products
            {
                filterAdvProductsList = new List<AdvertisingProductsModel> { };
                for (int i = 0; i < advProductsList.Count; i++)
                {
                    //bool f1 = CheckDoubleValues(CheckInput(tb_Impressions), advProductsList[i].Impressions);
                    //bool f2 = CheckDoubleValues(CheckInput(tb_Clicks), advProductsList[i].Clicks);
                    //bool f3 = CheckDoubleValues(CheckInput(tb_CTR), advProductsList[i].CTR);
                    //bool f4 = CheckDoubleValues(CheckInput(tb_CPC), advProductsList[i].CPC);
                    //bool f5 = CheckDoubleValues(CheckInput(tb_Spend), advProductsList[i].Spend);
                    //bool f6 = CheckDoubleValues(CheckInput(tb_ACoS), advProductsList[i].ACoS);
                    //bool f7 = CheckDoubleValues(CheckInput(tb_Sales), advProductsList[i].Sales);
                    //bool f8 = CheckDoubleValues(CheckInput(tb_Orders), advProductsList[i].Orders);
                    //bool f9 = CheckDoubleValues(CheckInput(tb_Units), advProductsList[i].Units);
                    if (CheckDoubleValues(CheckInput(tb_Impressions), advProductsList[i].Impressions) && CheckDoubleValues(CheckInput(tb_Clicks), advProductsList[i].Clicks) && CheckDoubleValues(CheckInput(tb_CTR), advProductsList[i].CTR) && CheckDoubleValues(CheckInput(tb_CPC), advProductsList[i].CPC) && CheckDoubleValues(CheckInput(tb_Spend), advProductsList[i].Spend) && CheckDoubleValues(CheckInput(tb_ACoS), advProductsList[i].ACoS) && CheckDoubleValues(CheckInput(tb_Sales), advProductsList[i].Sales) && CheckDoubleValues(CheckInput(tb_Orders), advProductsList[i].Orders) && CheckDoubleValues(CheckInput(tb_Units), advProductsList[i].Units))
                    {
                        filterAdvProductsList.Add(advProductsList[i]);
                    }
                }

                timer1.Start();
                if (NoErrors)
                    mf.GetAdvertisingProductsListToShow(filterAdvProductsList);
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
                if (NoErrors)
                    mf.GetAdvertisingBrandsListToShow(filterAdvBrandsList);
            }

            this.Cursor = Cursors.Default;
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

                mf.GetAdvertisingProductsListToShow(advProductsList);
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

                mf.GetAdvertisingBrandsListToShow(advBrandsList);
            }
        }
    }
}