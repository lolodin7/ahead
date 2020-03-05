using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class ReportAdvertisingUploadView : Form
    {
        private MainFormView mf;

        private List<string> fileNames;

        private DateTime UpdateDate;
        private DateTime StartDate, EndDate;
        private List<DateTime> datesList;
                
        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingProductsModel> summaryAdvProductsList;
        private List<AdvertisingProductsModel> advProductsListForUpdate;
        private List<AdvertisingProductsModel> advProductsListOfErrors;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private AdvertisingController advertController;

        private List<MapNameId> AP_campaignIdsList;
        private List<MapNameId> AB_campaignIdsList;

        int insertedCount, updatedCount;


        /* Главный конструктор */
        public ReportAdvertisingUploadView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            UpdateDate = DateTime.Today;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59);
            
            advProductsList = new List<AdvertisingProductsModel> { };
            advProductsListForUpdate = new List<AdvertisingProductsModel> { };
            summaryAdvProductsList = new List<AdvertisingProductsModel> { };
            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
            datesList = new List<DateTime> { };

            mpController = new MarketplaceController(this);
            advertController = new AdvertisingController(this);
            prodController = new ProductsController(this);

            AP_campaignIdsList = new List<MapNameId> { };
            AB_campaignIdsList = new List<MapNameId> { };

            advProductsListOfErrors = new List<AdvertisingProductsModel> { };

            mpController.GetMarketplaces();
                        
            advertController.GetAP_CampaignIds();
            advertController.GetAB_CampaignIds();
        }
        
        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
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

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Public метод для занесения товаров, которые потом нужно будет обновить, из AdvertisingController */
        public void AddProductForUpdate(AdvertisingProductsModel _apm)
        {
            advProductsListForUpdate.Add(_apm);
        }

        /* Получаем количество добавленных записей */
        public void GetInsertedCount(int _cnt)
        {
            insertedCount = _cnt;
        }

        /* Получаем количество обновленных записей */
        public void GetUpdatedCount(int _cnt)
        {
            updatedCount = _cnt;
        }

        /* Инициируем загрузку файла отчета в программу */
        private void Btn_UploadFromFile_Click(object sender, EventArgs e)
        {
            OpenManyFiles();
        }

        private void OpenManyFiles()
        {
            openFileDialog1.Filter = "Excel файлы (*.xlsx)|*.xlsx";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.Text = "";
                fileNames = new List<string> { };

                foreach (var t in openFileDialog1.FileNames)
                {
                    fileNames.Add(t);
                    richTextBox2.Text += t + "\n";
                }
            }
        }

        /* Загружаем новые ключи из файла для Sponsored Products */
        public void OpenNewFileForSponsoredProducts(string _fileName)
        {
            advProductsList.Clear();

            try
            {
                FileInfo existingFile = new FileInfo(@_fileName);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    //get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count

                    for (int row = 2; row <= rowCount; row++)
                    {
                        AdvertisingProductsModel prModel = new AdvertisingProductsModel();
                        advProductsList.Add(prModel);

                        UpdateDate = worksheet.Cells[row, 1].GetValue<DateTime>();
                        datesList.Add(worksheet.Cells[row, 1].GetValue<DateTime>());
                        advProductsList[advProductsList.Count - 1].WriteData(0, UpdateDate);

                        advProductsList[advProductsList.Count - 1].WriteData(1, ChechForNull(worksheet, row, 3));              //[CurrencyCharCode] 
                        advProductsList[advProductsList.Count - 1].WriteData(2, ChechForNull(worksheet, row, 4));              //[CampaignName] 
                        advProductsList[advProductsList.Count - 1].WriteData(3, ChechForNull(worksheet, row, 5));              //[AdGroupName]
                        advProductsList[advProductsList.Count - 1].WriteData(4, ChechForNull(worksheet, row, 6));              //[Targeting] 
                        advProductsList[advProductsList.Count - 1].WriteData(5, ChechForNull(worksheet, row, 7));              //[MatchType] 
                        advProductsList[advProductsList.Count - 1].WriteData(6, ChechForNull(worksheet, row, 8));              //[Impressions] 
                        advProductsList[advProductsList.Count - 1].WriteData(7, ChechForNull(worksheet, row, 9));             //[Clicks] 
                        advProductsList[advProductsList.Count - 1].WriteData(8, ChechForNull(worksheet, row, 10));             //[CTR] 
                        advProductsList[advProductsList.Count - 1].WriteData(9, ChechForNull(worksheet, row, 11));             //[CPC] 
                        advProductsList[advProductsList.Count - 1].WriteData(10, ChechForNull(worksheet, row, 12));            //[Spend]  
                        advProductsList[advProductsList.Count - 1].WriteData(11, ChechForNull(worksheet, row, 15));            //[Sales]
                        advProductsList[advProductsList.Count - 1].WriteData(12, ChechForNull(worksheet, row, 13));            //[ACoS] 
                        advProductsList[advProductsList.Count - 1].WriteData(13, ChechForNull(worksheet, row, 14));            //[RoAS]
                        advProductsList[advProductsList.Count - 1].WriteData(14, ChechForNull(worksheet, row, 16));            //[Orders] 
                        advProductsList[advProductsList.Count - 1].WriteData(15, ChechForNull(worksheet, row, 17));            //[Units] 
                        advProductsList[advProductsList.Count - 1].WriteData(16, ChechForNull(worksheet, row, 18));            //[ConversionRate]
                        advProductsList[advProductsList.Count - 1].WriteData(17, ChechForNull(worksheet, row, 19));            //[AdvSKUUnits]
                        advProductsList[advProductsList.Count - 1].WriteData(18, ChechForNull(worksheet, row, 20));            //[OtherSKUUnits]
                        advProductsList[advProductsList.Count - 1].WriteData(19, ChechForNull(worksheet, row, 21));            //[AdvSKUSales]
                        advProductsList[advProductsList.Count - 1].WriteData(20, ChechForNull(worksheet, row, 22));            //[OtherSKUSales] 
                    }
                }

                StartDate = datesList.Min();
                EndDate = datesList.Max().AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                advProductsList.Clear();
            }
        }

        private string ChechForNull(ExcelWorksheet worksheet, int row, int col)
        {
            if (worksheet.Cells[row, col].Value == null)
                return "0";
            else
                return worksheet.Cells[row, col].Value.ToString().Trim();
        }

        /* Получаем id маркетплейса по выбранному имени в combobox */
        private string GetMarketPlaceNameById(int _id)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (mpList[i].MarketPlaceId == _id)
                    return mpList[i].MarketPlaceName;
            }
            return "NOT_FOUND";
        }

        /* Получаем id маркетплейса по выбранному имени в combobox */
        private int GetMarketPlaceIdByName(string _name)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (_name.Contains(mpList[i].MarketPlaceName))
                    return mpList[i].MarketPlaceId;
            }
            return 1;
        }

        /* Получаем id товара по выбранному имени в combobox */
        private int GetProductIdByName(string _name)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (_name.ToLower().Contains(pList[i].ProdShortName.ToLower()))
                    return pList[i].ProductId;
            }
            return -1;
        }

        /* Получаем id товара по выбранному имени в combobox */
        private int GetProductIdByName(AdvertisingBrandsModel _abm)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (_abm.CampaignName.ToLower().Contains(pList[i].ProdShortName.ToLower()) && _abm.ProductId1 != pList[i].ProductId && _abm.ProductId2 != pList[i].ProductId && _abm.ProductId3 != pList[i].ProductId)
                    return pList[i].ProductId;
            }
            return 1;
        }

        /* Закрываем окно по нажатию на кнопку */
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Иницируем сохранение отчета в БД для одиночного файла */
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (fileNames.Count > 0)
            {
                if (MessageBox.Show("Загрузить отчеты?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lb_Progress.Visible = true;
                    this.Enabled = false;

                    richTextBox2.Text = "";
                    string errors = "";

                    foreach (var _fileName in fileNames)
                    {
                        insertedCount = 0;
                        updatedCount = 0;

                        advProductsList.Clear();
                        advProductsListForUpdate.Clear();
                        advProductsListOfErrors.Clear();

                        OpenNewFileForSponsoredProducts(_fileName);

                        if (advProductsList.Count > 0)
                        {
                            SetCampaignAndMarketplaceToAllRows_AP(_fileName);
                            MakeSummaryAdvProductListbyTargetingInAdGroups();

                            advertController.InsertAdvertising_Product_Report(advProductsList, lb_Progress);

                            if (advProductsListForUpdate.Count > 0)
                                advertController.UpdateAdvertising_Product_Report(advProductsListForUpdate, lb_Progress);
                            
                            if (advProductsListOfErrors.Count > 0)
                            {
                                foreach (var t in advProductsListOfErrors)
                                {
                                    errors += "Date: " + UpdateDate.ToString() + " Campaign: " + t.CampaignName + " AdGroup " + t.AdGroupName + " Targeting " + t.Targeting + " Marketplace" + GetMarketPlaceNameById(t.MarketPlaceId) + "\n";
                                }
                                richTextBox2.Text += errors;
                            }
                            
                            richTextBox2.Text += _fileName + "\n" + "Загружено: " + insertedCount + "\nОбновлено: " + updatedCount + "\nВсего: " + (insertedCount + updatedCount).ToString() + " из " + advProductsList.Count + "\n\n";
                        }
                        else
                            richTextBox2.Text += "Пустой файл: " + _fileName + "\n";
                    }

                    this.Enabled = true;
                    lb_Progress.Visible = false;
                    lb_Progress.Text = "";
                }
            }
            else
                MessageBox.Show("Не выбраны файлы для загрузки.", "Ошибка");            
        }
        
        /* Заносим данные об кампании и маркетплейсу для каждой строки загруженного отчета */
        private void SetCampaignAndMarketplaceToAllRows_AP(string _fileName)
        {
            int campaignTypeId = 0;          //Sponsored Products
            int marketplaceId = GetMarketPlaceIdByName(_fileName);

            prodController.GetProductsByMarketplaceId(marketplaceId);

            foreach (var t in advProductsList)
            {
                t.WriteData(21, campaignTypeId);
                t.WriteData(22, marketplaceId);
                t.WriteData(23, Check_CampaignForExisting_AP(t.CampaignName));
                t.WriteData(24, GetProductIdByName(t.CampaignName));
            }

            advProductsListOfErrors = new List<AdvertisingProductsModel> { };

            for (int i = 0; i < advProductsList.Count; i++)
            {
                if (advProductsList[i].ProductId == -1)
                {
                    advProductsListOfErrors.Add(advProductsList[i]);
                    advProductsList.RemoveAt(i);
                    i--;
                }
            }
        }

        /* Проверяем, есть ли такая кампания в БД. Если да, берем её id, если нет - создаем id, заносим в БД и возвращаем */
        private int Check_CampaignForExisting_AP(string _campName)
        {
            for (int i = 0; i < AP_campaignIdsList.Count; i++)
            {
                if (_campName.Equals(AP_campaignIdsList[i].Name))
                    return AP_campaignIdsList[i].ID;
            }
            int camp_id;

            camp_id = advertController.GetIdFromString(_campName);

            advertController.InsertAP_CampaignId(camp_id, _campName);
            advertController.GetAP_CampaignIds();

            return camp_id;
        }
        
        /* Проверяем, есть ли такая кампания в БД. Если да, берем её id, если нет - создаем id, заносим в БД и возвращаем */
        private int Check_CampaignForExisting_AB(string _campName)
        {
            for (int i = 0; i < AB_campaignIdsList.Count; i++)
            {
                if (_campName.Equals(AB_campaignIdsList[i].Name))
                    return AB_campaignIdsList[i].ID;
            }
            int camp_id;

            camp_id = advertController.GetIdFromString(_campName);

            advertController.InsertAB_CampaignId(camp_id, _campName);
            advertController.GetAB_CampaignIds();

            return camp_id;
        }

        private void AdvertisingUploadReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Show();
        }
        
        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListbyTargetingInAdGroups()
        {
            summaryAdvProductsList = new List<AdvertisingProductsModel> { };
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
                            if (advProductsList[i].CampaignName.Equals(advProductsList[j].CampaignName) && advProductsList[i].AdGroupName.Equals(advProductsList[j].AdGroupName) && advProductsList[i].Targeting.Equals(advProductsList[j].Targeting) && advProductsList[i].MatchType.Equals(advProductsList[j].MatchType) && advProductsList[i].UpdateDate == advProductsList[j].UpdateDate && advProductsList[i].ProductId == advProductsList[j].ProductId)
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

                lb_Progress.Text = "Обработка отчета.\nОбработано: " + i + " из " + advProductsList.Count;
                lb_Progress.Refresh();
            }

            advProductsList.Clear();
            foreach (var t in summaryAdvProductsList)
            {
                advProductsList.Add(t);
            }
        }
    }
}