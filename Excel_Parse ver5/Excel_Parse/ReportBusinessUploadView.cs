using Microsoft.VisualBasic.FileIO;
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
    public partial class ReportBusinessUploadView : Form
    {
        private MainFormView mf;

        private bool FirstLoad;

        private DateTime StartDate, EndDate;
        private int DaysDiff;
        private int updatedRowsCount;

        private string path = "";
        private List<string> FileNames;
        private DateTime UpdateDate;
        
        private BusinessController businessController;
        private List<ReportBusinessModel> businessList;
        private List<ReportBusinessModel> summaryBusinessList;
        private List<ReportBusinessModel> businessListForUpdate;

        private List<ReportBusinessModel> businessListOfErrors;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private ReportDataAnalyzer reportDataAnalyzer;
        private List<int> missedColumns;

        private int insertedCount, updatedCount;
        private int generalInsertedCount, generalUpdatedCount, generalCount;

        public ReportBusinessUploadView(MainFormView _mf, string _mode)
        {
            InitializeComponent();
            mf = _mf;
            FirstLoad = true;

            UpdateDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            DaysDiff = (EndDate - StartDate).Days + 1;
            lb_DaysDiff.Text = "Разница дат - " + DaysDiff;

            lb_startDateText.Text = StartDate.ToString().Substring(0, 10);
            lb_endDateText.Text = EndDate.ToString().Substring(0, 10);
            

            businessList = new List<ReportBusinessModel> { };
            summaryBusinessList = new List<ReportBusinessModel> { };
            businessListForUpdate = new List<ReportBusinessModel> { };

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
            FileNames = new List<string> { };
            missedColumns = new List<int> { };

            businessController = new BusinessController(this);
            mpController = new MarketplaceController(this);
            prodController = new ProductsController(this);
            reportDataAnalyzer = new ReportDataAnalyzer(this);
            

            if (mpController.GetMarketplaces() == 1)
                Fill_CB_Marketplace();

            prodController.GetProductsAllJOIN();


            FirstLoad = false;
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

        /* Заполняем combobox названиями маркетплейсов */
        private void Fill_CB_Marketplace()
        {
            cb_MarketPlace2.Items.Clear();

            for (int i = 0; i < mpList.Count; i++)
            {
                cb_MarketPlace2.Items.Add(mpList[i].MarketPlaceName);
            }
            
            cb_MarketPlace2.SelectedIndex = 0;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Public метод для занесения товаров, которые потом нужно будет обновить, из AdvertisingController */
        public void AddProductForUpdate(ReportBusinessModel _apm)
        {
            businessListForUpdate.Add(_apm);

        }
        /* Получаем id маркетплейса по выбранному имени в combobox */
        private int GetMarketPlaceIdByName_Many(string _name)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (cb_MarketPlace2.SelectedItem.ToString().Equals(mpList[i].MarketPlaceName))
                    return mpList[i].MarketPlaceId;
            }
            return 1;
        }

        /* Получаем id товара по выбранному имени в combobox */
        private int GetProductIdByName(string _name)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (_name.Contains(pList[i].ProdShortName))
                    return pList[i].ProductId;
            }
            return -1;
        }

        /* Получаем имя товара по заданному productId */
        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
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
        
        public void GetMissedReportColumns(object _missedColumns)
        {
            missedColumns = (List<int>)_missedColumns;
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



        //---------------------------------------------------------------------------------------------------------------

        /* Инициируем загрузку файлов отчетов в программу */
        private void btn_UploadFileMany_Click(object sender, EventArgs e)
        {
            OpenManyFiles();
        }

        private void OpenManyFiles()
        {
            //businessList = new List<ReportBusinessModel> { };

            openFileDialog1.Filter = "Неразмеченные файлы|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                int index = -1;

                richTextBox1.Text = "";
                FileNames.Clear();

                foreach (var t in openFileDialog2.FileNames)
                {
                    FileNames.Add(t);

                    index = FileNames[FileNames.Count - 1].LastIndexOf('\\');
                    richTextBox1.Text += FileNames[FileNames.Count - 1].Substring(index, FileNames[FileNames.Count - 1].Length - index) + "\n";
                }

                generalInsertedCount = 0;
                generalUpdatedCount = 0;
                generalCount = 0;
            }
        }

        /* Обработчик кнопки закрытия формы */
        private void btn_CloseMany_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Сохранить в БД много файлов */
        private void btn_SaveMany_Click(object sender, EventArgs e)
        {
            if (EndDate > StartDate)
            {
                if (FileNames.Count > 0)
                {
                    if (FileNames.Count == DaysDiff)
                    {
                        if (MessageBox.Show("Маркетплейс: " + cb_MarketPlace2.SelectedItem.ToString() + "\n\nЗагрузить отчеты с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Enabled = false;
                            this.Cursor = Cursors.WaitCursor;
                            updatedRowsCount = 0;
                            List<string> badFileNames = new List<string> { };
                            richTextBox1.Text = "";
                            richTextBox1.Refresh();
                            UpdateDate = StartDate;
                            string error_skus = "";
                            generalInsertedCount = 0;
                            generalUpdatedCount = 0;
                            generalCount = 0;

                            for (int i = 0; i < FileNames.Count; i++)       //обрабатываем файлы и смотрим, есть ли неизвестные товары
                            {
                                richTextBox1.Text = "Загрузка и обработка файлов с отчетами...";
                                richTextBox1.Refresh();

                                int marketplaceid = GetMarketPlaceIdByName_Many(cb_MarketPlace2.SelectedItem.ToString());
                                int productId;
                                LoadManyFilesStepByStep(FileNames[i]);
                                if (businessList.Count > 0)
                                {
                                    productId = -2;
                                    for (int j = 0; j < businessList.Count; j++)
                                    {
                                        productId = GetProductIdBySKU(businessList[j].SKU, marketplaceid);
                                        if (productId == -1)
                                            if (!error_skus.Contains(businessList[j].SKU))
                                                error_skus += "Date: " + businessList[j].UpdateDate + " SKU: " + businessList[j].SKU + " Marketplace: " + GetMarketPlaceNameById(businessList[j].MarketPlaceId) + "\n";
                                    }
                                }
                                else
                                    richTextBox1.Text += "Файл отчета \"" + FileNames[i] + "\" не был загружен. Нет данных для сохранения.\n";
                            }
                            if (error_skus.Length > 0)          //ещё одна проверка на то, есть ли неизвестные товары
                            {
                                richTextBox1.Text += error_skus;
                                richTextBox1.Refresh();
                            }
                            else
                            {
                                PrepareReportForSaving_Many(true);

                                if (businessListOfErrors.Count > 0)         //и ещё одна проверка на то, есть ли неизвестные товары
                                {
                                    string errorsMsg = "\nДанные по следующим товарам не были лены. Вороятно, этот товар не занесен в программу.\n";
                                    string errorsstr = "";
                                    foreach (var k in businessListOfErrors)
                                    {
                                        errorsstr += "Date: " + k.UpdateDate + " SKU: " + k.SKU + " Marketplace: " + GetMarketPlaceNameById(k.MarketPlaceId) + "\n";
                                    }
                                    richTextBox1.Text += errorsstr;
                                    richTextBox1.Refresh();
                                }
                                else
                                {
                                    richTextBox1.Text = "";
                                    richTextBox1.Refresh();

                                    for (int i = 0; i < FileNames.Count; i++)
                                    {
                                        businessListForUpdate.Clear();

                                        LoadManyFilesStepByStep(FileNames[i]);
                                        PrepareReportForSaving_Many(false);

                                        if (businessList.Count > 0)
                                        {
                                            updatedCount = 0;
                                            insertedCount = 0;
                                            MakeSummaryBusinessList();

                                            businessController.InsertBusinessReportBeforeUpdating(businessList, lb_Progress);

                                            if (businessListForUpdate.Count > 0)
                                                businessController.UpdateBusinessReport(businessListForUpdate, lb_Progress);

                                            richTextBox1.Text += FileNames[i] + "\n" + "Загружено: " + insertedCount + "\nОбновлено: " + updatedCount + "\nВсего: " + (insertedCount + updatedCount).ToString() + " из " + businessList.Count + "\n\n";
                                            richTextBox1.Refresh();
                                            generalCount += businessList.Count;
                                            generalInsertedCount += insertedCount;
                                            generalUpdatedCount += updatedCount;
                                        }
                                        else
                                        {
                                            richTextBox1.Text += "Файл отчета \"" + FileNames[i] + "\" не был загружен. Нет данных для сохранения.\n";
                                            richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                            richTextBox1.ScrollToCaret();
                                            richTextBox1.Refresh();
                                        }
                                        UpdateDate = UpdateDate.AddDays(1);
                                    }
                                    richTextBox1.Text += "\n\nЗагрузка завершена.\nВсего обработано записей: " + generalCount + "\nВсего загружено: " + generalInsertedCount + "\nВсего обновлено: " + generalUpdatedCount;
                                    richTextBox1.Refresh();
                                    lb_Progress.Text = "";
                                }

                            }
                            this.Cursor = Cursors.Default;
                            this.Enabled = true;
                        }
                    }
                    else
                        MessageBox.Show("Количество загружаемых файлов отличается от количества выбранных дней.", "Ошибка");
                }
                else
                    MessageBox.Show("Файлы отчетов не были загружены. Для продолжения загрузите один или более файл отчета.", "Ошибка");
            }
            else
                MessageBox.Show("Дата начала больше даты окончания.", "Ошибка");
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
        private void PrepareReportForSaving_Many(bool _checkFalg)
        {
            int marketplaceid = GetMarketPlaceIdByName_Many(cb_MarketPlace2.SelectedItem.ToString());
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

            if (_checkFalg)     //если первый раз проходим, то выполняем инструкции ниже; если 2й - пропускаем, всё ок
            {
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
        }

        /* Удаляем все повторы с advProductsList, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryBusinessList()
        {
            summaryBusinessList = new List<ReportBusinessModel> { };
            List<int> alreadyUsed = new List<int> { };
            int sessions;
            int pageviews;
            int unitsOrdered;
            int unitsOrderedB2B;
            double orderedProdSales;
            double orderedProdSalesB2B;
            int totalOrderedItems;
            int totalOrderedItemsB2B;

            for (int i = 0; i < businessList.Count; i++)
            {
                if (i == businessList.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    sessions = businessList[i].Sessions;
                    pageviews = businessList[i].PageViews;
                    unitsOrdered = businessList[i].UnitsOrdered;
                    unitsOrderedB2B = businessList[i].UnitsOrderedB2B;
                    orderedProdSales = businessList[i].OrderedProductSales;
                    orderedProdSalesB2B = businessList[i].OrderedProductSalesB2B;
                    totalOrderedItems = businessList[i].TotalOrderItems;
                    totalOrderedItemsB2B = businessList[i].TotalOrderItemsB2B;

                    if (i < (businessList.Count - 1))
                    {
                        for (int j = i + 1; j < businessList.Count; j++)
                        {
                            if (businessList[i].SKU.Equals(businessList[j].SKU) && businessList[i].UpdateDate == businessList[j].UpdateDate && businessList[i].MarketPlaceId == businessList[j].MarketPlaceId)
                            {
                                sessions = businessList[j].Sessions;
                                pageviews = businessList[j].PageViews;
                                unitsOrdered = businessList[j].UnitsOrdered;
                                unitsOrderedB2B = businessList[j].UnitsOrderedB2B;
                                orderedProdSales = businessList[j].OrderedProductSales;
                                orderedProdSalesB2B = businessList[j].OrderedProductSalesB2B;
                                totalOrderedItems = businessList[j].TotalOrderItems;
                                totalOrderedItemsB2B = businessList[j].TotalOrderItemsB2B;
                                alreadyUsed.Add(j);
                            }
                        }
                    }
                    summaryBusinessList.Add(new ReportBusinessModel());

                    summaryBusinessList[summaryBusinessList.Count - 1].UpdateDate = businessList[i].UpdateDate;
                    summaryBusinessList[summaryBusinessList.Count - 1].Sessions = sessions;
                    summaryBusinessList[summaryBusinessList.Count - 1].PageViews = pageviews;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitsOrdered = unitsOrdered;
                    summaryBusinessList[summaryBusinessList.Count - 1].UnitsOrderedB2B = unitsOrderedB2B;
                    summaryBusinessList[summaryBusinessList.Count - 1].OrderedProductSales = Math.Round(orderedProdSales, 2);
                    summaryBusinessList[summaryBusinessList.Count - 1].OrderedProductSalesB2B = Math.Round(orderedProdSalesB2B, 2);
                    summaryBusinessList[summaryBusinessList.Count - 1].TotalOrderItems = totalOrderedItems;
                    summaryBusinessList[summaryBusinessList.Count - 1].TotalOrderItemsB2B = totalOrderedItemsB2B;
                    summaryBusinessList[summaryBusinessList.Count - 1].MarketPlaceId = businessList[i].MarketPlaceId;
                    summaryBusinessList[summaryBusinessList.Count - 1].ProductId = businessList[i].ProductId;
                    summaryBusinessList[summaryBusinessList.Count - 1].SKU = businessList[i].SKU;
                }

                lb_Progress.Text = "Обработка отчета.\nОбработано: " + i + " из " + businessList.Count;
                lb_Progress.Refresh();
            }

            businessList.Clear();
            foreach (var t in summaryBusinessList)
            {
                businessList.Add(t);
            }
        }

        /* дата начала была изменена */
        private void mc_startDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate = mc_startDate.SelectionStart;
            lb_startDateText.Text = "C " + StartDate.ToString().Substring(0, 10);
            DaysDiff = (EndDate - StartDate).Days + 1;
            lb_DaysDiff.Text = "Разница дат - " + DaysDiff;
        }

        /* Дата окончания была изменена */
        private void mc_EndDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate = mc_startDate.SelectionStart;
            EndDate = mc_EndDate.SelectionEnd;
            lb_endDateText.Text = "По " + EndDate.ToString().Substring(0, 10);
            DaysDiff = (EndDate - StartDate).Days + 1;
            lb_DaysDiff.Text = "Разница дат - " + DaysDiff;
        }
        
        
        private void ReportBusinessUploadView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }
    }
}
