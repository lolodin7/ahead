using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class EveryDayReportsUpdate : Form
    {
        private MainFormView mf;
        private string path;
        private string adv_path, bus_path, inventory_path, orders_path;
        private string[] FileNamesAdv;
        private string[] FileNamesBus;
        private string[] FileNamesOrders;
        private string[] FileNamesInventory;
        private string mpPDWUSA = "pdw usa";
        private string mpPDWCA = "pdw ca";
        private string mpPDWMX = "pdw mx";
        private string mpLTBUSA = "letit beer usa";

        private List<AdvObject> advNewerObjectList;         //insert - 4
        private List<AdvObject> advOlderObjectList;         //update - 4

        private List<BusObject> busNewerObjectList;         //insert - 4
        private List<BusObject> busOlderObjectList;         //update - 4

        private List<OrdersObject> ordersNewerObjectList;   //insert - 2
        private List<OrdersObject> ordersOlderObjectList;   //update - 2

        private InventoryObject inventoryObject;            //insert - 1


        /* Advertising reports */
        private List<AdvertisingProductsModel> advProductsList;
        private List<AdvertisingBrandsModel> advBrandsList;

        private List<AdvertisingProductsModel> advProductsListOfErrors;
        private List<AdvertisingBrandsModel> advBrandsListOfErrors;
        

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private CampaignTypesController campTController;
        private List<CampaignTypesModel> campTList;

        private AdvertisingController advertController;

        private List<MapNameId> AP_campaignIdsList;
        private List<MapNameId> AB_campaignIdsList;
        private int updatedRowsCount;

        private DateTime UpdateDate;
        private DateTime StartDate, EndDate;

        private List<Marketplace> mpList;

        private ReportDataAnalyzer reportDataAnalyzer;
        private BusinessController businessController;
        private List<ReportBusinessModel> businessList;

        private List<ReportBusinessModel> businessListOfErrors;
        private List<int> missedColumns;



        public EveryDayReportsUpdate(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            //path = @ConfigurationManager.AppSettings.Get("reportsPath");
            path = "D:\\BonaFides - отчеты\\!test_tmp\\everyday";
            adv_path = path + "\\Advertising";
            bus_path = path + "\\Business-Reports";
            inventory_path = path + "\\Amazon-check-stock";
            orders_path = path + "\\All-orders";



            updatedRowsCount = 0;

            advProductsList = new List<AdvertisingProductsModel> { };
            advBrandsList = new List<AdvertisingBrandsModel> { };
            campTList = new List<CampaignTypesModel> { };
            pList = new List<ProductsModel> { };
            businessList = new List<ReportBusinessModel> { };
            missedColumns = new List<int> { };

            businessController = new BusinessController(this);
            campTController = new CampaignTypesController(this);
            advertController = new AdvertisingController(this);
            prodController = new ProductsController(this);
            reportDataAnalyzer = new ReportDataAnalyzer(this);

            AP_campaignIdsList = new List<MapNameId> { };
            AB_campaignIdsList = new List<MapNameId> { };

            advProductsListOfErrors = new List<AdvertisingProductsModel> { };
            advBrandsListOfErrors = new List<AdvertisingBrandsModel> { };

            UpdateDate = DateTime.Today;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59);

            mpList = new List<Marketplace> { new Marketplace(1, "PowerDeWise (USA)", "pdw usa"), new Marketplace(2, "PowerDeWise (CA)", "pdw ca"), new Marketplace(3, "PowerDeWise (AU)", "pdw au"), new Marketplace(4, "PowerDeWise (MX)", "pdw mx"), new Marketplace(5, "LetIt.Beer (USA)", "letit beer usa"), new Marketplace(6, "LetIt.Beer (CA)", "letit beer ca"), new Marketplace(7, "PowerDeWise (JP)", "pdw jp"), new Marketplace(8, "Others", "others") };

            prodController.GetProductsAllJOIN();
        }

        private void EveryDayReportsUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }

        #region Reports Uploading and MarkUp
        private void btn_uploadReports_Click(object sender, EventArgs e)
        {
            FileNamesAdv = Directory.GetFiles(adv_path);
            FileNamesBus = Directory.GetFiles(bus_path);
            FileNamesOrders = Directory.GetFiles(orders_path);
            FileNamesInventory = Directory.GetFiles(inventory_path);
            int result = 0;
            
            result = processAdvReports();
            result = processBusReports();
            result = processOrdersReports();
            result = processInventoryReport();
        }

        private int processAdvReports()
        {
            try
            {
                AdvObject advObject;
                advNewerObjectList = new List<AdvObject> { };
                advOlderObjectList = new List<AdvObject> { };

                string fileName;

                for (int i = 0; i < FileNamesAdv.Length; i++)
                {
                    fileName = FileNamesAdv[i].Substring(adv_path.Length + 1, FileNamesAdv[i].Length - adv_path.Length - 1);
                    fileName = fileName.Substring(12, fileName.Length - 5 - 12);        //12 - это advertising! в начале имени файла, сразу отсекаем его

                    advObject = GetAdvInfoFromFileName(fileName, FileNamesAdv[i]);
                    if (advObject.updateDate == DateTime.Today.AddDays(-1))
                        advNewerObjectList.Add(advObject);
                    else
                        advOlderObjectList.Add(advObject);
                }

                for (int i = 0; i < advNewerObjectList.Count; i++)
                {
                    if (advNewerObjectList[i].marketplace.ToLower().Equals(mpPDWUSA))
                        tb_advrepPDWUSA.Text = advNewerObjectList[i].fullFileName;
                    else if (advNewerObjectList[i].marketplace.ToLower().Equals(mpPDWCA))
                        tb_advrepPDWCA.Text = advNewerObjectList[i].fullFileName;
                    else if (advNewerObjectList[i].marketplace.ToLower().Equals(mpPDWMX))
                        tb_advrepPDWMX.Text = advNewerObjectList[i].fullFileName;
                    else if (advNewerObjectList[i].marketplace.ToLower().Equals(mpLTBUSA))
                        tb_advrepLTBUSA.Text = advNewerObjectList[i].fullFileName;
                }

                for (int i = 0; i < advOlderObjectList.Count; i++)
                {
                    if (advOlderObjectList[i].marketplace.ToLower().Equals(mpPDWUSA))
                        tb_advrep30PDWUSA.Text = advOlderObjectList[i].fullFileName;
                    else if (advOlderObjectList[i].marketplace.ToLower().Equals(mpPDWCA))
                        tb_advrep30PDWCA.Text = advOlderObjectList[i].fullFileName;
                    else if (advOlderObjectList[i].marketplace.ToLower().Equals(mpPDWMX))
                        tb_advrep30PDWMX.Text = advOlderObjectList[i].fullFileName;
                    else if (advOlderObjectList[i].marketplace.ToLower().Equals(mpLTBUSA))
                        tb_advrep30LTBUSA.Text = advOlderObjectList[i].fullFileName;
                }

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private AdvObject GetAdvInfoFromFileName(string _fileName, string _fullFileName)
        {
            try
            {
                int year = int.Parse(_fileName.Substring(_fileName.Length - 10, 4));
                int month = int.Parse(_fileName.Substring(_fileName.Length - 5, 2));
                int day = int.Parse(_fileName.Substring(_fileName.Length - 2, 2));

                DateTime resultDate = new DateTime(year, month, day);
                string marketplace = _fileName.Substring(0, _fileName.Length - 11);

                AdvObject obj = new AdvObject(marketplace, resultDate, _fullFileName);
                return obj;
            }
            catch (Exception ex)
            {
                return new AdvObject("", new DateTime(1000, 1, 1), "");
            }
        }




        private int processBusReports()
        {
            try
            {
                BusObject busObject;
                busNewerObjectList = new List<BusObject> { };
                busOlderObjectList = new List<BusObject> { };

                string fileName;

                for (int i = 0; i < FileNamesBus.Length; i++)
                {
                    fileName = FileNamesBus[i].Substring(bus_path.Length + 1, FileNamesBus[i].Length - bus_path.Length - 1);
                    fileName = fileName.Substring(9, fileName.Length - 4 - 9);        //9 - это business! в начале имени файла, сразу отсекаем его

                    busObject = GetBusInfoFromFileName(fileName, FileNamesBus[i]);
                    if (busObject.updateDate == DateTime.Today.AddDays(-2))
                        busNewerObjectList.Add(busObject);
                    else
                        busOlderObjectList.Add(busObject);
                }

                for (int i = 0; i < busNewerObjectList.Count; i++)
                {
                    if (busNewerObjectList[i].marketplace.ToLower().Equals(mpPDWUSA))
                        tb_busrepPDWUSA.Text = busNewerObjectList[i].fullFileName;
                    else if (busNewerObjectList[i].marketplace.ToLower().Equals(mpPDWCA))
                        tb_busrepPDWCA.Text = busNewerObjectList[i].fullFileName;
                    else if (busNewerObjectList[i].marketplace.ToLower().Equals(mpPDWMX))
                        tb_busrepPDWMX.Text = busNewerObjectList[i].fullFileName;
                    else if (busNewerObjectList[i].marketplace.ToLower().Equals(mpLTBUSA))
                        tb_busrepLTBUSA.Text = busNewerObjectList[i].fullFileName;
                }

                for (int i = 0; i < busOlderObjectList.Count; i++)
                {
                    if (busOlderObjectList[i].marketplace.ToLower().Equals(mpPDWUSA))
                        tb_busrep30PDWUSA.Text = busOlderObjectList[i].fullFileName;
                    else if (busOlderObjectList[i].marketplace.ToLower().Equals(mpPDWCA))
                        tb_busrep30PDWCA.Text = busOlderObjectList[i].fullFileName;
                    else if (busOlderObjectList[i].marketplace.ToLower().Equals(mpPDWMX))
                        tb_busrep30PDWMX.Text = busOlderObjectList[i].fullFileName;
                    else if (busOlderObjectList[i].marketplace.ToLower().Equals(mpLTBUSA))
                        tb_busrep30LTBUSA.Text = busOlderObjectList[i].fullFileName;
                }

                return 1;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        private BusObject GetBusInfoFromFileName(string _fileName, string _fullFileName)
        {
            try
            {
                int year = int.Parse(_fileName.Substring(_fileName.Length - 10, 4));
                int month = int.Parse(_fileName.Substring(_fileName.Length - 5, 2));
                int day = int.Parse(_fileName.Substring(_fileName.Length - 2, 2));

                DateTime resultDate = new DateTime(year, month, day);
                string marketplace = _fileName.Substring(0, _fileName.Length - 11);

                BusObject obj = new BusObject(marketplace, resultDate, _fullFileName);
                return obj;
            }
            catch (Exception ex)
            {
                return new BusObject("", new DateTime(1000, 1, 1), "");
            }
        }





        private int processOrdersReports()
        {
            try
            {
                OrdersObject ordersObject;
                ordersNewerObjectList = new List<OrdersObject> { };
                ordersOlderObjectList = new List<OrdersObject> { };

                string fileName;

                for (int i = 0; i < FileNamesOrders.Length; i++)
                {
                    fileName = FileNamesOrders[i].Substring(orders_path.Length + 1, FileNamesOrders[i].Length - orders_path.Length - 1);
                    fileName = fileName.Substring(7, fileName.Length - 4 - 7);        //7 - это orders! в начале имени файла, сразу отсекаем его

                    ordersObject = GetOrdersInfoFromFileName(fileName, FileNamesOrders[i]);
                    if (ordersObject.updateDate == DateTime.Today.AddDays(-1))
                        ordersNewerObjectList.Add(ordersObject);
                    else
                        ordersOlderObjectList.Add(ordersObject);
                }

                for (int i = 0; i < ordersNewerObjectList.Count; i++)
                {
                    if (ordersNewerObjectList[i].marketplace.ToLower().Equals(mpPDWUSA))
                        tb_allordersPDW.Text = ordersNewerObjectList[i].fullFileName;
                    else if (ordersNewerObjectList[i].marketplace.ToLower().Equals(mpLTBUSA))
                        tb_allordersLTB.Text = ordersNewerObjectList[i].fullFileName;
                }

                for (int i = 0; i < ordersOlderObjectList.Count; i++)
                {
                    if (ordersNewerObjectList[i].marketplace.ToLower().Equals(mpPDWUSA))
                        tb_allorders30PDW.Text = ordersNewerObjectList[i].fullFileName;
                    else if (ordersNewerObjectList[i].marketplace.ToLower().Equals(mpLTBUSA))
                        tb_allorders30LTB.Text = ordersNewerObjectList[i].fullFileName;
                }

                return 1;
            }
            catch (Exception ex)
            {
                return -3;
            }
        }

        private OrdersObject GetOrdersInfoFromFileName(string _fileName, string _fullFileName)
        {
            try
            {
                int year = int.Parse(_fileName.Substring(_fileName.Length - 10, 4));
                int month = int.Parse(_fileName.Substring(_fileName.Length - 5, 2));
                int day = int.Parse(_fileName.Substring(_fileName.Length - 2, 2));

                DateTime resultDate = new DateTime(year, month, day);
                string marketplace = _fileName.Substring(0, _fileName.Length - 11);

                OrdersObject obj = new OrdersObject(marketplace, resultDate, _fullFileName);
                return obj;
            }
            catch (Exception ex)
            {
                return new OrdersObject("", new DateTime(1000, 1, 1), "");
            }
        }

        private int processInventoryReport()
        {
            try
            {
                string fileName;

                for (int i = 0; i < FileNamesInventory.Length; i++)
                {
                    fileName = FileNamesInventory[i].Substring(inventory_path.Length + 1, FileNamesInventory[i].Length - inventory_path.Length - 1);
                    fileName = fileName.Substring(6, fileName.Length - 5 - 6);        //6 - это stock! в начале имени файла, сразу отсекаем его

                    inventoryObject = GetInventoryInfoFromFileName(fileName, FileNamesInventory[i]);
                }

                tb_inventoryrep.Text = inventoryObject.fullFileName;

                return 1;
            }
            catch (Exception ex)
            {
                return -4;
            }
        }

        private InventoryObject GetInventoryInfoFromFileName(string _fileName, string _fullFileName)
        {
            try
            {
                int year = int.Parse(_fileName.Substring(_fileName.Length - 10, 4));
                int month = int.Parse(_fileName.Substring(_fileName.Length - 5, 2));
                int day = int.Parse(_fileName.Substring(_fileName.Length - 2, 2));

                DateTime resultDate = new DateTime(year, month, day);

                InventoryObject obj = new InventoryObject(resultDate, _fullFileName);
                return obj;
            }
            catch (Exception ex)
            {
                return new InventoryObject(new DateTime(1000, 1, 1), "");
            }
        }
        #endregion //-----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------


        #region Inserting And Updating Reports to DB



        private void btn_saveInDB_Click(object sender, EventArgs e)
        {
            //uploadAdvertisingReports("insert");
            //uploadAdvertisingReports("update");

            //uploadBusinessReports("insert");
            //uploadBusinessReports("update");
        }

        #region Advertising
        /* Иницируем сохранение отчета в БД для множества файлов */
        private void uploadAdvertisingReports(string _mode)
        {
            if (_mode.Equals("insert"))
            {
                bool errors = false;
                updatedRowsCount = 0;

                if (advNewerObjectList.Count > 0)
                {
                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    foreach (var t in advNewerObjectList)
                    {
                        LoadManyFilesStepByStep_AP(t.fullFileName);

                        if (advProductsList.Count > 0)
                        {
                            SetCampaignAndMarketplaceToAllRows_Many_AP(t.marketplace);

                            if (advertController.InsertAdvertising_Product_Report(advProductsList) == 0)
                                errors = true;
                            else
                                updatedRowsCount += advProductsList.Count;

                            if (advProductsListOfErrors.Count > 0)
                            {
                                string errorsMsg = "Данные по следующим кампаниям не были добавлены. Вороятно, имя товара в названии кампании задано не согласно шаблону.\n";
                                string errorsstr = "";
                                foreach (var k in advProductsListOfErrors)
                                {
                                    errorsstr += "Date: " + UpdateDate.ToString() + " Campaign: " + k.CampaignName + " AdGroup " + k.AdGroupName + " Targeting " + k.Targeting + "\n";
                                }
                                Console.WriteLine(errorsstr);
                            }
                        }
                        else
                        {
                            errors = true;
                            Console.WriteLine("Файл отчета \"" + t + "\" не был загружен. Нет данных для сохранения.");
                        }

                        UpdateDate = UpdateDate.AddDays(1);
                    }
                }
                else
                    Console.WriteLine("Выберите файлы для загрузки");
            }
            else if (_mode.Equals("update"))
            {
                bool errors = false;
                updatedRowsCount = 0;

                if (advOlderObjectList.Count > 0)
                {
                    foreach (var t in advOlderObjectList)
                    {
                        LoadManyFilesStepByStep_AP(t.fullFileName);

                        if (advProductsList.Count > 0)
                        {
                            SetCampaignAndMarketplaceToAllRows_Many_AP(t.marketplace);

                            if (advertController.UpdateAdvertising_Product_Report(advProductsList) == -1)
                                errors = true;
                            else
                                updatedRowsCount += advProductsList.Count;

                            if (advProductsListOfErrors.Count > 0)
                            {
                                string errorsMsg = "Данные по следующим кампаниям не были добавлены. Вороятно, имя товара в названии кампании задано не согласно шаблону.\n";
                                string errorsstr = "";
                                foreach (var k in advProductsListOfErrors)
                                {
                                    errorsstr += "Date: " + UpdateDate.ToString() + " Campaign: " + k.CampaignName + " AdGroup " + k.AdGroupName + " Targeting " + k.Targeting + "\n";
                                }
                                Console.WriteLine(errorsstr);
                            }
                        }
                        else
                        {
                            errors = true;
                            Console.WriteLine("Файл отчета \"" + t + "\" не был загружен. Нет данных для сохранения.");
                        }

                        UpdateDate = UpdateDate.AddDays(1);
                    }
                }
                else
                    Console.WriteLine("Выберите файлы для загрузки");
            }
        }

        private void LoadManyFilesStepByStep_AP(string _filename)
        {
            advProductsList.Clear();

            try
            {
                FileInfo existingFile = new FileInfo(@_filename);
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

                        advProductsList[advProductsList.Count - 1].WriteData(0, worksheet.Cells[row, 1].GetValue<DateTime>());

                        advProductsList[advProductsList.Count - 1].WriteData(1, ChechForNull(worksheet, row, 4));              //[CurrencyCharCode] 
                        advProductsList[advProductsList.Count - 1].WriteData(2, ChechForNull(worksheet, row, 5));              //[CampaignName] 
                        advProductsList[advProductsList.Count - 1].WriteData(3, ChechForNull(worksheet, row, 6));              //[AdGroupName]
                        advProductsList[advProductsList.Count - 1].WriteData(4, ChechForNull(worksheet, row, 7));              //[Targeting] 
                        advProductsList[advProductsList.Count - 1].WriteData(5, ChechForNull(worksheet, row, 8));              //[MatchType] 
                        advProductsList[advProductsList.Count - 1].WriteData(6, ChechForNull(worksheet, row, 9));              //[Impressions] 
                        advProductsList[advProductsList.Count - 1].WriteData(7, ChechForNull(worksheet, row, 10));             //[Clicks] 
                        advProductsList[advProductsList.Count - 1].WriteData(8, ChechForNull(worksheet, row, 11));             //[CTR] 
                        advProductsList[advProductsList.Count - 1].WriteData(9, ChechForNull(worksheet, row, 12));             //[CPC] 
                        advProductsList[advProductsList.Count - 1].WriteData(10, ChechForNull(worksheet, row, 13));            //[Spend]  
                        advProductsList[advProductsList.Count - 1].WriteData(11, ChechForNull(worksheet, row, 16));            //[Sales]
                        advProductsList[advProductsList.Count - 1].WriteData(12, ChechForNull(worksheet, row, 14));            //[ACoS] 
                        advProductsList[advProductsList.Count - 1].WriteData(13, ChechForNull(worksheet, row, 15));            //[RoAS]
                        advProductsList[advProductsList.Count - 1].WriteData(14, ChechForNull(worksheet, row, 17));            //[Orders] 
                        advProductsList[advProductsList.Count - 1].WriteData(15, ChechForNull(worksheet, row, 18));            //[Units] 
                        advProductsList[advProductsList.Count - 1].WriteData(16, ChechForNull(worksheet, row, 19));            //[ConversionRate]
                        advProductsList[advProductsList.Count - 1].WriteData(17, ChechForNull(worksheet, row, 20));            //[AdvSKUUnits]
                        advProductsList[advProductsList.Count - 1].WriteData(18, ChechForNull(worksheet, row, 21));            //[OtherSKUUnits]
                        advProductsList[advProductsList.Count - 1].WriteData(19, ChechForNull(worksheet, row, 22));            //[AdvSKUSales]
                        advProductsList[advProductsList.Count - 1].WriteData(20, ChechForNull(worksheet, row, 23));            //[OtherSKUSales] 
                                                                                                                               //}
                    }
                }
            }
            catch (Exception ex) { }
        }

        private string ChechForNull(ExcelWorksheet worksheet, int row, int col)
        {
            if (worksheet.Cells[row, col].Value == null)
                return "0";
            else
                return worksheet.Cells[row, col].Value.ToString().Trim();
        }

        /* Заносим данные об кампании и маркетплейсу для каждой строки загруженного отчета */
        private void SetCampaignAndMarketplaceToAllRows_Many_AP(string _marketplace)
        {
            int campaignTypeId = 0;     //Sponsored Products = 0, Sponsored Brands = 1
            int marketplaceId = GetMarketPlaceIdByName_Many(_marketplace);

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

        /* Получаем id маркетплейса по выбранному имени в combobox */
        private int GetMarketPlaceIdByName_Many(string _name)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (mpList[i].mpNameShort.Equals(_name))
                    return mpList[i].mpId;
            }
            return 1;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }
        #endregion
        //----------------------------------------------------------------------------------

        #region Business
        /* Сохранить в БД много файлов */
        private void uploadBusinessReports(string _mode)
        {
            bool errors = false;
            updatedRowsCount = 0;
            List<string> badFileNames = new List<string> { };

            if (_mode.Equals("insert"))
            {
                if (busNewerObjectList.Count > 0)
                {
                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    string error_skus = "";
                    for (int i = 0; i < busNewerObjectList.Count; i++)
                    {
                        int marketplaceid = GetMarketPlaceIdByName_Many(busNewerObjectList[i].marketplace);
                        int productId;
                        LoadManyFilesStepByStep(busNewerObjectList[i].fullFileName);
                        if (businessList.Count > 0)
                        {
                            productId = -2;
                            for (int j = 0; j < businessList.Count; j++)
                            {
                                productId = GetProductIdBySKU(businessList[j].SKU, marketplaceid);
                                if (productId == -1)
                                    if (!error_skus.Contains(businessList[j].SKU))
                                        error_skus += businessList[j].SKU + "\n";
                            }
                        }
                    }
                    if (error_skus.Length > 0)
                    {
                        //MessageBox.Show("Товаров ниже нет в системе. Для продолжения сначала добавьте эти товары.\n" + error_skus, "Ошибка");
                        //richTextBox1.Text = error_skus;
                        //richTextBox1.Enabled = true;
                    }
                    else
                    {
                        for (int i = 0; i < busNewerObjectList.Count; i++)
                        {
                            LoadManyFilesStepByStep(busNewerObjectList[i].fullFileName);

                            if (businessList.Count > 0)
                            {
                                UpdateDate = busNewerObjectList[i].updateDate;
                                PrepareReportForSaving_Many(busNewerObjectList[i].marketplace);

                                if (businessController.InsertBusinessReport(businessList) == 0)
                                    errors = true;
                                else
                                    updatedRowsCount += businessList.Count;

                                //if (businessListOfErrors.Count > 0)
                                //{
                                //    string errorsMsg = "Данные по следующим товарам не были добавлены. Вороятно, этот товар не занесен в программу.\n";
                                //    string errorsstr = "";
                                //    foreach (var k in businessListOfErrors)
                                //    {
                                //        errorsstr += "Данные товара SKU: " + k.SKU + " Название товара: " + GetProductNameById(k.ProductId) + "\nне были добавлены. Вороятно, этот товар не занесен в программу";
                                //    }
                                //    MessageBox.Show(errorsMsg, "Ошибка");
                                //    richTextBox1.Text = errorsstr;
                                //}
                            }
                            else
                            {
                                //MessageBox.Show("Файл отчета \"" + FileNames[i] + "\" не был загружен. Нет данных для сохранения.", "Ошибка");
                                //badFileNames.Add(FileNames[i]);
                                errors = true;
                            }
                            UpdateDate = UpdateDate.AddDays(1);
                        }

                        if (!errors)
                            Console.WriteLine("Сохранение успешно. Всего сохранено строк - " + updatedRowsCount);
                        else
                        {
                            Console.WriteLine("Сохранение прошло с ошибками.");
                            //richTextBox1.Text += "Ниже представлены названия файлов, которые не получилось загрузить. Данные из них не были загружены на сервер.\n";
                            foreach (var t in badFileNames)
                            {
                                //richTextBox1.Text += t + "\n";
                            }
                        }
                    }

                    this.Cursor = Cursors.Default;
                    this.Enabled = true;
                }
                else
                    Console.WriteLine("Файлы отчетов не были загружены. Для продолжения загрузите один или более файл отчета.", "Ошибка");
            }
            if (_mode.Equals("update"))
            {
                if (busOlderObjectList.Count > 0)
                {
                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    string error_skus = "";
                    for (int i = 0; i < busOlderObjectList.Count; i++)
                    {
                        int marketplaceid = GetMarketPlaceIdByName_Many(busOlderObjectList[i].marketplace);
                        int productId;
                        LoadManyFilesStepByStep(busOlderObjectList[i].fullFileName);
                        if (businessList.Count > 0)
                        {
                            productId = -2;
                            for (int j = 0; j < businessList.Count; j++)
                            {
                                productId = GetProductIdBySKU(businessList[j].SKU, marketplaceid);
                                if (productId == -1)
                                    if (!error_skus.Contains(businessList[j].SKU))
                                        error_skus += businessList[j].SKU + "\n";
                            }
                        }
                    }
                    if (error_skus.Length > 0) { }
                    else
                    {
                        for (int i = 0; i < busOlderObjectList.Count; i++)
                        {
                            LoadManyFilesStepByStep(busOlderObjectList[i].fullFileName);

                            if (businessList.Count > 0)
                            {
                                UpdateDate = busOlderObjectList[i].updateDate;
                                PrepareReportForSaving_Many(busOlderObjectList[i].marketplace);

                                if (businessController.UpdateBusinessReport(businessList) == 0)
                                    errors = true;
                                else
                                    updatedRowsCount += businessList.Count;
                            }
                            else
                            {
                                errors = true;
                            }
                            UpdateDate = UpdateDate.AddDays(1);
                        }

                        if (!errors)
                            Console.WriteLine("Сохранение успешно. Всего сохранено строк - " + updatedRowsCount);
                        else
                        {
                            Console.WriteLine("Сохранение прошло с ошибками.");
                        }
                    }

                    this.Cursor = Cursors.Default;
                    this.Enabled = true;
                }
                else
                    Console.WriteLine("Файлы отчетов не были загружены. Для продолжения загрузите один или более файл отчета.", "Ошибка");
            }
        }

        /* Получаем id товара по выбранному имени в combobox */
        private int GetProductIdBySKU(string _sku, int _marketplaceId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].SKU.Equals(_sku) && pList[i].MarketPlaceId == _marketplaceId)
                    return pList[i].ProductId;
            }
            return -1;
        }

        /* Загружаем файл по одному при загрузке большого количества файлов */
        private void LoadManyFilesStepByStep(string _filename)
        {
            businessList = new List<ReportBusinessModel> { };

            bool firstRow = true;
            bool theSame = false;

            try
            {
                using (TextFieldParser parser = new TextFieldParser(@_filename))
                {
                    missedColumns.Clear();
                    parser.TextFieldType = FieldType.Delimited;

                    parser.SetDelimiters(",");

                    string[] fields;

                    while (!parser.EndOfData)
                    {
                        int usedMissedIndexes = 0;

                        //Process row
                        fields = parser.ReadFields();

                        if (!firstRow)      //проверяем, если это первая строка с заголовками  (НЕТ)
                        {
                            businessList.Add(new ReportBusinessModel());

                            if (theSame)        //если количество стоблцов одинаковое (значит, в фактическом отчете нет пропущеных столбцов)
                            {
                                for (int i = 0; i + 3 < fields.Length; i++)
                                {
                                    if (!missedColumns.Contains(i + 3))         //проверяем, является ли номер колонки пропущенным в факт. отчете
                                        businessList[businessList.Count - 1].WriteData(i + 2, fields[i + 3 - usedMissedIndexes]);
                                    else
                                    {
                                        businessList[businessList.Count - 1].WriteData(i + 2, 0);
                                        usedMissedIndexes++;
                                    }
                                }
                            }
                            else            //если количество стоблцов разное (значит, в фактическом отчете пропущены столбцы)
                            {
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    if (!missedColumns.Contains(i + 3))         //проверяем, является ли номер колонки пропущенным в факт. отчете
                                        businessList[businessList.Count - 1].WriteData(i + 2, fields[i + 3 - usedMissedIndexes]);
                                    else
                                    {
                                        businessList[businessList.Count - 1].WriteData(i + 2, 0);
                                        usedMissedIndexes++;
                                    }
                                }
                            }
                        }
                        else        //(ДА)
                        {
                            List<string> reportColumns = new List<string> { };
                            foreach (var t in fields)
                            {
                                reportColumns.Add(t);
                            }

                            string[] reportColumnsFinish = new string[reportColumns.Count];     //не помню почему, но метод получает именно массив, а не список

                            for (int j = 0; j < reportColumns.Count; j++)
                            {
                                reportColumnsFinish[j] = reportColumns[j];
                            }

                            theSame = reportDataAnalyzer.BusinessReport(reportColumnsFinish);   //сравниваем названия и количество столбцов. theSame показывает, одинаковое ли количество столбцов между фактическим отчетом и заданным. от этого зависит длительность цикла в ветке (НЕТ)

                            firstRow = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
            }
        }

        /* Считаем и заполняем все пустые поля в businessList, которые остались после загрузки файла */
        private void PrepareReportForSaving_Many(string _marketplace)
        {
            int marketplaceid = GetMarketPlaceIdByName_Many(_marketplace);
            int productid; //GetProductIdBySKU()
            int sumSessions = 0;
            int sumPageViews = 0;

            foreach (var t in businessList)
            {
                sumSessions += t.Sessions;
                sumPageViews += t.PageViews;
            }

            for (int i = 0; i < businessList.Count; i++)
            {
                if (sumSessions != 0)
                    businessList[i].SessionPercentage = Math.Round((double)businessList[i].Sessions / sumSessions * 100, 2);
                else
                    businessList[i].SessionPercentage = 0;

                if (sumPageViews != 0)
                    businessList[i].PageViewsPercentage = Math.Round((double)businessList[i].PageViews / sumPageViews * 100, 2);
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

                businessList[i].MarketPlaceId = marketplaceid;
                businessList[i].ProductId = GetProductIdBySKU(businessList[i].SKU, businessList[i].MarketPlaceId);
                businessList[i].UpdateDate = UpdateDate;
            }

            businessListOfErrors = new List<ReportBusinessModel> { };
            bool skuExists = false;

            for (int i = 0; i < businessList.Count; i++)
            {
                foreach (var s in pList)
                {
                    if (s.SKU.Equals(businessList[i].SKU) && s.MarketPlaceId == businessList[i].MarketPlaceId)
                        skuExists = true;
                }

                if (!skuExists)
                {
                    businessListOfErrors.Add(businessList[i]);
                    businessList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void GetMissedReportColumns(object _missedColumns)
        {
            missedColumns = (List<int>)_missedColumns;
        }

        #endregion
        //----------------------------------------------------------------------------------

        #region All Orders

        #endregion
        //----------------------------------------------------------------------------------

        #region Stock

        #endregion
        //----------------------------------------------------------------------------------

        

        #endregion
        //----------------------------------------------------------------------------------

    }















    class AdvObject
    {
        public string marketplace { get; set; }
        public DateTime updateDate { get; set; }
        public string fullFileName { get; set; }

        public AdvObject(string _marketplace, DateTime _updateDate, string _fullFileName)
        {
            marketplace = _marketplace;
            updateDate = _updateDate;
            fullFileName = _fullFileName;
        }
    }

    class BusObject
    {
        public string marketplace { get; set; }
        public DateTime updateDate { get; set; }
        public string fullFileName { get; set; }

        public BusObject(string _marketplace, DateTime _updateDate, string _fullFileName)
        {
            marketplace = _marketplace;
            updateDate = _updateDate;
            fullFileName = _fullFileName;
        }
    }

    class OrdersObject
    {
        public string marketplace { get; set; }
        public DateTime updateDate { get; set; }
        public string fullFileName { get; set; }

        public OrdersObject(string _marketplace, DateTime _updateDate, string _fullFileName)
        {
            marketplace = _marketplace;
            updateDate = _updateDate;
            fullFileName = _fullFileName;
        }
    }

    class InventoryObject
    {
        public DateTime updateDate { get; set; }
        public string fullFileName { get; set; }

        public InventoryObject(DateTime _updateDate, string _fullFileName)
        {
            updateDate = _updateDate;
            fullFileName = _fullFileName;
        }
    }

    class Marketplace
    {
        public int mpId { get; set; }
        public string mpNameGeneral { get; set; }
        public string mpNameShort { get; set; }
        public Marketplace(int _mpId, string _nameGeneral, string _nammeShort)
        {
            mpId = _mpId;
            mpNameGeneral = _nameGeneral;
            mpNameShort = _nammeShort;
        }

        public Marketplace()
        {

        }
    }
}
