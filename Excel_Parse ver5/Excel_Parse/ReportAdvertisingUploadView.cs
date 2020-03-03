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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class ReportAdvertisingUploadView : Form 
    {
        private MainFormView mf;

        private bool FirstLoad;

        private bool UploadMode;
        private bool UpdateMode;

        private string path = "";
        private List<string> FileNames;
        private DateTime UpdateDate;
        private DateTime StartDate, EndDate;
        private List<DateTime> datesList;

        private bool SponsoredProducts, SponsoredBrands;

        //private int daysDiff;
        private int updatedRowsCount;

        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingBrandsModel> advBrandsList;

        private List<AdvertisingProductsModel> advProductsListOfErrors;
        private List<AdvertisingBrandsModel> advBrandsListOfErrors;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private CampaignTypesController campTController;
        private List<CampaignTypesModel> campTList;

        private AdvertisingController advertController;

        private List<MapNameId> AP_campaignIdsList;
        private List<MapNameId> AB_campaignIdsList;

        /* Главный конструктор */
        public ReportAdvertisingUploadView(MainFormView _mf, string _mode)
        {
            InitializeComponent();
            mf = _mf;
            FirstLoad = true;

            UpdateDate = DateTime.Today;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59);

            //daysDiff = 1;
            updatedRowsCount = 0;

            advProductsList = new List<AdvertisingProductsModel> { };
            advBrandsList = new List<AdvertisingBrandsModel> { };
            mpList = new List<MarketplaceModel> { };
            campTList = new List<CampaignTypesModel> { };
            pList = new List<ProductsModel> { };
            FileNames = new List<string> { };
            datesList = new List<DateTime> { };

            mpController = new MarketplaceController(this);
            campTController = new CampaignTypesController(this);
            advertController = new AdvertisingController(this);
            prodController = new ProductsController(this);

            AP_campaignIdsList = new List<MapNameId> { };
            AB_campaignIdsList = new List<MapNameId> { };

            advProductsListOfErrors = new List<AdvertisingProductsModel> { };
            advBrandsListOfErrors = new List<AdvertisingBrandsModel> { };

            SponsoredProducts = false;
            SponsoredBrands = false;

            if (_mode.Equals("upload"))
            {
                UploadMode = true;
                UpdateMode = false;
                this.Text = "Загрузить данные";
                btn_Save.Text = "Сохранить";
            }
            else if (_mode.Equals("update"))
            {
                UploadMode = false;
                UpdateMode = true;
                this.Text = "Обновить данные";
                btn_Save.Text = "Обновить";
            }

            if (mpController.GetMarketplaces() == 1)
                Fill_CB_Marketplace();

            if (campTController.GetCampaignTypes() == 1)
                Fill_CB_CampaignTypes();

            advertController.GetAP_CampaignIds();
            advertController.GetAB_CampaignIds();

            FirstLoad = false;
        }

        /* Заполняем combobox названиями маркетплейсов */
        private void Fill_CB_Marketplace()
        {
            cb_MarketPlace.Items.Clear();

            for (int i = 0; i < mpList.Count; i++)
            {
                cb_MarketPlace.Items.Add(mpList[i].MarketPlaceName);
            }

            cb_MarketPlace.SelectedIndex = 0;
        }

        /* Заполняем combobox названиями кампаний */
        private void Fill_CB_CampaignTypes()
        {
            cb_CampaignType.Items.Clear();

            for (int i = 0; i < campTList.Count; i++)
            {
                cb_CampaignType.Items.Add(campTList[i].CampaignName);
            }

            //cb_CampaignType.SelectedIndex = 0;
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


        /* Инициируем загрузку файла отчета в программу */
        private void Btn_UploadFromFile_Click(object sender, EventArgs e)
        {
            OpenNewFileForSponsoredProducts();
        }

        /* Загружаем новые ключи из файла для Sponsored Products */
        public void OpenNewFileForSponsoredProducts()
        {
            openFileDialog1.Filter = "Excel файлы (*.xlsx)|*.xlsx";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                advProductsList.Clear();

                try
                {
                    FileInfo existingFile = new FileInfo(@path);
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

                            //advProductsList[advProductsList.Count - 1].WriteData(1, ChechForNull(worksheet, row, 4));              //[CurrencyCharCode] 
                            //advProductsList[advProductsList.Count - 1].WriteData(2, ChechForNull(worksheet, row, 5));              //[CampaignName] 
                            //advProductsList[advProductsList.Count - 1].WriteData(3, ChechForNull(worksheet, row, 6));              //[AdGroupName]
                            //advProductsList[advProductsList.Count - 1].WriteData(4, ChechForNull(worksheet, row, 7));              //[Targeting] 
                            //advProductsList[advProductsList.Count - 1].WriteData(5, ChechForNull(worksheet, row, 8));              //[MatchType] 
                            //advProductsList[advProductsList.Count - 1].WriteData(6, ChechForNull(worksheet, row, 9));              //[Impressions] 
                            //advProductsList[advProductsList.Count - 1].WriteData(7, ChechForNull(worksheet, row, 10));             //[Clicks] 
                            //advProductsList[advProductsList.Count - 1].WriteData(8, ChechForNull(worksheet, row, 11));             //[CTR] 
                            //advProductsList[advProductsList.Count - 1].WriteData(9, ChechForNull(worksheet, row, 12));             //[CPC] 
                            //advProductsList[advProductsList.Count - 1].WriteData(10, ChechForNull(worksheet, row, 13));            //[Spend]  
                            //advProductsList[advProductsList.Count - 1].WriteData(11, ChechForNull(worksheet, row, 16));            //[Sales]
                            //advProductsList[advProductsList.Count - 1].WriteData(12, ChechForNull(worksheet, row, 14));            //[ACoS] 
                            //advProductsList[advProductsList.Count - 1].WriteData(13, ChechForNull(worksheet, row, 15));            //[RoAS]
                            //advProductsList[advProductsList.Count - 1].WriteData(14, ChechForNull(worksheet, row, 17));            //[Orders] 
                            //advProductsList[advProductsList.Count - 1].WriteData(15, ChechForNull(worksheet, row, 18));            //[Units] 
                            //advProductsList[advProductsList.Count - 1].WriteData(16, ChechForNull(worksheet, row, 19));            //[ConversionRate]
                            //advProductsList[advProductsList.Count - 1].WriteData(17, ChechForNull(worksheet, row, 20));            //[AdvSKUUnits]
                            //advProductsList[advProductsList.Count - 1].WriteData(18, ChechForNull(worksheet, row, 21));            //[OtherSKUUnits]
                            //advProductsList[advProductsList.Count - 1].WriteData(19, ChechForNull(worksheet, row, 22));            //[AdvSKUSales]
                            //advProductsList[advProductsList.Count - 1].WriteData(20, ChechForNull(worksheet, row, 23));            //[OtherSKUSales] 

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
                    label7.Text = "Дата - " + UpdateDate.ToString().Substring(0, 10);
                    label1.Text = path;
                    
                    StartDate = datesList.Min();
                    EndDate = datesList.Max().AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                    advProductsList.Clear();
                }
            }
        }

        private string ChechForNull(ExcelWorksheet worksheet, int row, int col)
        {
            if (worksheet.Cells[row, col].Value == null)
                return "0";
            else
                return worksheet.Cells[row, col].Value.ToString().Trim();
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
                if (cb_MarketPlace.SelectedItem.ToString().Equals(mpList[i].MarketPlaceName))
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
            if (UploadMode)     //загружаем новые данные
            {
                if (advProductsList.Count > 0)
                {
                    if (MessageBox.Show("Кампания: " + cb_CampaignType.SelectedItem.ToString() + "\n\nМаркетплейс: " + cb_MarketPlace.SelectedItem.ToString() + "\n\n" + StartDate.ToString().Substring(0, 10) + " - " + EndDate.ToString().Substring(0, 10) + "\n\nЗагрузить отчет с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SetCampaignAndMarketplaceToAllRows_AP();
                        UploadReportToDB_AP();
                    }
                    if (advProductsListOfErrors.Count > 0)
                    {
                        string errorsMsg = "Данные по следующим кампаниям не были добавлены. Вороятно, имя товара в названии кампании задано не согласно шаблону.\n";
                        string errors = "";
                        foreach (var t in advProductsListOfErrors)
                        {
                            errors += "Date: " + UpdateDate.ToString() + " Campaign: " + t.CampaignName + " AdGroup " + t.AdGroupName + " Targeting " + t.Targeting + "\n";
                        }
                        MessageBox.Show(errorsMsg, "Ошибка");
                        richTextBox2.Text = errors;
                    }
                }
                else
                    MessageBox.Show("Файл отчета не был загружен. Нет данных для сохранения.", "Ошибка");
            }
            else if (UpdateMode)        //обновляем старые данные
            {
                if (advProductsList.Count > 0)
                {
                    if (MessageBox.Show("Кампания: " + cb_CampaignType.SelectedItem.ToString() + "\n\nМаркетплейс: " + cb_MarketPlace.SelectedItem.ToString() + "\n\n" + StartDate.ToString().Substring(0, 10) + " - " + EndDate.ToString().Substring(0, 10) + "\n\nЗагрузить отчет с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SetCampaignAndMarketplaceToAllRows_AP();
                        UpdateDataInDB_AP();
                    }
                    if (advProductsListOfErrors.Count > 0)
                    {
                        string errorsMsg = "Данные по следующим кампаниям не были обновлены. Вороятно, имя товара в названии кампании задано не согласно шаблону.\n";
                        string errors = "";
                        foreach (var t in advProductsListOfErrors)
                        {
                            errors += "Date: " + UpdateDate.ToString() + " Campaign: " + t.CampaignName + " AdGroup " + t.AdGroupName + " Targeting " + t.Targeting + "\n";
                        }
                        MessageBox.Show(errorsMsg, "Ошибка");
                        richTextBox2.Text = errors;
                    }
                }
                else
                    MessageBox.Show("Файл отчета не был загружен. Нет данных для сохранения.", "Ошибка");
            }
        }

        /* Метод обновления отчета в БД для Spondored Products */
        private void UpdateDataInDB_AP()
        {
            lb_Progress.Visible = true;
            this.Enabled = false;
            int cnt = 0;
            cnt = advertController.UpdateAdvertising_Product_Report(advProductsList, lb_Progress);

            if (cnt == -1)
                MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
            else
                MessageBox.Show("Данные обновлены успешно.", "Успех");

            this.Enabled = true;
            lb_Progress.Visible = false;
            lb_Progress.Text = "";
        }

        /* Метод обновления отчета в БД для Spondored Brands */
        private void UpdateDataInDB_AB()
        {
            this.Enabled = false;
            int cnt = 0;

            cnt = advertController.UpdateAdvertising_Brands_Report(advBrandsList);

            if (cnt == -1)
                MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
            else
                MessageBox.Show("Данные обновлены успешно.", "Успех");

            this.Enabled = true;
        }

        /* Метод загрузки отчета в БД для Spondored Products */
        private void UploadReportToDB_AP()
        {
            this.Enabled = false;
            if (advertController.InsertAdvertising_Product_Report(advProductsList) != 1)
                MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
            else
                MessageBox.Show("Сохранение успешно. Всего сохранено строк - " + advProductsList.Count, "Успех");
            this.Enabled = true;
        }

        /* Метод загрузки отчета в БД для Spondored Brands */
        private void UploadReportToDB_AB()
        {
            this.Enabled = false;
            if (advertController.InsertAdvertising_Brand_Report(advBrandsList) != 1)
                MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
            else
                MessageBox.Show("Сохранение успешно. Всего сохранено строк - " + advBrandsList.Count, "Успех");
            this.Enabled = true;
        }

        /* Заносим данные об кампании и маркетплейсу для каждой строки загруженного отчета */
        private void SetCampaignAndMarketplaceToAllRows_AP()
        {
            int campaignTypeId = GetCampaignTypeIdByName(cb_CampaignType.SelectedItem.ToString());
            int marketplaceId = GetMarketPlaceIdByName(cb_MarketPlace.SelectedItem.ToString());

            foreach (var t in advProductsList)
            {
                //t.WriteData(0, UpdateDate);
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

        /* Заносим данные об кампании и маркетплейсу для каждой строки загруженного отчета */
        private void SetCampaignAndMarketplaceToAllRows_AB()
        {
            int campaignTypeId = GetCampaignTypeIdByName(cb_CampaignType.SelectedItem.ToString());
            int marketplaceId = GetMarketPlaceIdByName(cb_MarketPlace.SelectedItem.ToString());

            foreach (var t in advBrandsList)
            {
                //t.WriteData(0, UpdateDate);
                t.WriteData(20, campaignTypeId);
                t.WriteData(21, marketplaceId);
                t.WriteData(22, Check_CampaignForExisting_AB(t.CampaignName));
                t.WriteData(23, GetProductIdByName(t));
                t.WriteData(24, GetProductIdByName(t));
                t.WriteData(25, GetProductIdByName(t));
            }

            advBrandsListOfErrors = new List<AdvertisingBrandsModel> { };

            for (int i = 0; i < advBrandsList.Count; i++)
            {
                if (advBrandsList[i].ProductId1 == -1 || advBrandsList[i].ProductId2 == -1 || advBrandsList[i].ProductId3 == -1)
                {
                    advBrandsListOfErrors.Add(advBrandsList[i]);
                    advBrandsList.RemoveAt(i);
                    i--;
                }
            }
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

        private void Cb_MarketPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodController.GetProductsByMarketplaceId(GetMarketPlaceIdByName(cb_MarketPlace.SelectedItem.ToString()));
        }

        private void Cb_CampaignType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CampaignType.SelectedIndex >= 0)
            {
                panel1.Visible = true;
                label6.Visible = false;

                label1.Text = "";
                path = "";
                advProductsList.Clear();
                advBrandsList.Clear();

                if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Products"))
                {
                    SponsoredProducts = true;
                    SponsoredBrands = false;
                }
                else if (cb_CampaignType.SelectedItem.ToString().Equals("Sponsored Brands"))
                {
                    SponsoredProducts = false;
                    SponsoredBrands = true;
                }
            }
        }
    }
}
