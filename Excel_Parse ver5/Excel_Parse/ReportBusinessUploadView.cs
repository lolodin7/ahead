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

        private bool UploadMode;
        private bool UpdateMode;

        private DateTime StartDate, EndDate;
        private int DaysDiff;
        private int updatedRowsCount;

        private string path = "";
        private List<string> FileNames;
        private DateTime UpdateDate;
        
        private BusinessController businessController;
        private List<ReportBusinessModel> businessList;

        private List<ReportBusinessModel> businessListOfErrors;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

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

            lb_mcDate.Text = UpdateDate.ToString().Substring(0, 10);

            businessList = new List<ReportBusinessModel> { };

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
            FileNames = new List<string> { };

            businessController = new BusinessController(this);
            mpController = new MarketplaceController(this);
            prodController = new ProductsController(this);

            if (_mode.Equals("upload"))
            {
                UploadMode = true;
                UpdateMode = false;
                this.Text = "Загрузить Business Report";
                btn_Save.Text = "Сохранить";
            }
            else if (_mode.Equals("update"))
            {
                UploadMode = false;
                UpdateMode = true;
                this.Text = "Обновить Business Report";
                btn_Save.Text = "Обновить";
            }

            if (mpController.GetMarketplaces() == 1)
                Fill_CB_Marketplace();

            prodController.GetProductsAllJOIN();


            FirstLoad = false;
        }

        /* Заполняем combobox названиями маркетплейсов */
        private void Fill_CB_Marketplace()
        {
            cb_MarketPlace1.Items.Clear();
            cb_MarketPlace2.Items.Clear();

            for (int i = 0; i < mpList.Count; i++)
            {
                cb_MarketPlace1.Items.Add(mpList[i].MarketPlaceName);
                cb_MarketPlace2.Items.Add(mpList[i].MarketPlaceName);
            }

            cb_MarketPlace1.SelectedIndex = 0;
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

        /* Получаем id маркетплейса по выбранному имени в combobox */
        private int GetMarketPlaceIdByName(string _name)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (cb_MarketPlace1.SelectedItem.ToString().Equals(mpList[i].MarketPlaceName))
                    return mpList[i].MarketPlaceId;
            }
            return 1;
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
        private int GetProductIdBySKU(string _sku)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].SKU.Equals(_sku))
                    return pList[i].ProductId;
            }
            return -1;
        }

        /* Загрузить файл отчета в программу */
        private void btn_UploadFile_Click(object sender, EventArgs e)
        {
            businessList = new List<ReportBusinessModel> { };

            bool firstRow = true;
            openFileDialog1.Filter = "Неразмеченные файлы|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                try
                {
                    using (TextFieldParser parser = new TextFieldParser(@path))
                    {
                        parser.TextFieldType = FieldType.Delimited;

                        parser.SetDelimiters(",");


                        while (!parser.EndOfData)
                        {
                            //Process row
                            string[] fields = parser.ReadFields();
                            if (!firstRow)
                            {
                                businessList.Add(new ReportBusinessModel());

                                businessList[businessList.Count - 1].WriteData(1, fields[3]);
                                businessList[businessList.Count - 1].WriteData(2, fields[4]);
                                businessList[businessList.Count - 1].WriteData(4, fields[6]);
                                businessList[businessList.Count - 1].WriteData(6, fields[9]);
                                businessList[businessList.Count - 1].WriteData(7, fields[10]);
                                businessList[businessList.Count - 1].WriteData(10, fields[13]);
                                businessList[businessList.Count - 1].WriteData(11, fields[14]);
                                businessList[businessList.Count - 1].WriteData(12, fields[15]);
                                businessList[businessList.Count - 1].WriteData(13, fields[16]);
                            }
                            else
                                firstRow = false;
                        }
                        lb_Path1.Text = path;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                }
            }
        }

        private void cb_MarketPlace1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_Path1.Text = "";
        }

        /* Начать сохранение отчета в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (UploadMode)     //если загружаем новый отчет(-ы)
            {
                if (businessList.Count > 0)
                {
                    if (MessageBox.Show("Маркетплейс: " + cb_MarketPlace1.SelectedItem.ToString() + "\n\nДата отчета: " + UpdateDate.ToString().Substring(0, 10) + "\n\nЗагрузить отчет с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrepareSingleReportForSaving();
                        UploadSingleReportToDB();
                    }
                }
                else
                    MessageBox.Show("Нечего сохранять. Сначала загрузите отчет.", "Ошибка");
            }
            else if (UpdateMode)    //если обновляем отчет(-ы)
            {
                if (businessList.Count > 0)
                {
                    if (MessageBox.Show("Маркетплейс: " + cb_MarketPlace1.SelectedItem.ToString() + "\n\nДата отчета: " + UpdateDate.ToString().Substring(0, 10) + "\n\nОбновить отчет с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrepareSingleReportForSaving();
                        UpdateSingleReportInDB();
                    }
                }
                else
                    MessageBox.Show("Нечего обновлять. Сначала загрузите отчет.", "Ошибка");
            }
        }

        /* загрузить отчет в БД */
        private void UploadSingleReportToDB()
        {
            this.Enabled = false;
            if (businessController.InsertBusinessReport(businessList) != 1)
                MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
            else
                MessageBox.Show("Сохранение успешно. Всего сохранено строк - " + businessList.Count, "Успех");
            this.Enabled = true;
        }

        /* Обновить записи в БД */
        private void UpdateSingleReportInDB()
        {

            this.Enabled = false;
            int cnt = 0;
            cnt = businessController.UpdateBusinessReport(businessList);

            if (cnt == -1)
                MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
            else
                MessageBox.Show("Данные обновлены успешно.", "Успех");

            this.Enabled = true;
        }

        /* Изменена дата в календаре */
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateDate = monthCalendar1.SelectionEnd;
            lb_mcDate.Text = UpdateDate.ToString().Substring(0, 10);
        }

        /* Считаем и заполняем все пустые поля в businessList, которые остались после загрузки файла */
        private void PrepareSingleReportForSaving()
        {
            int marketplaceid = GetMarketPlaceIdByName(cb_MarketPlace1.SelectedItem.ToString());
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
                businessList[i].SessionPercentage = Math.Round((double)businessList[i].Sessions / sumSessions * 100, 2);
                businessList[i].PageViewsPercentage = Math.Round((double)businessList[i].PageViews / sumPageViews * 100, 2);
                businessList[i].UnitSessionPercentage = Math.Round((double)businessList[i].UnitsOrdered / businessList[i].Sessions * 100, 2);
                businessList[i].UnitSessionPercentageB2B = Math.Round((double)businessList[i].UnitsOrderedB2B / businessList[i].Sessions * 100, 2);
                businessList[i].MarketPlaceId = marketplaceid;
                businessList[i].ProductId = GetProductIdBySKU(businessList[i].SKU);
                businessList[i].UpdateDate = UpdateDate;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportBusinessUploadView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }






        //---------------------------------------------------------------------------------------------------------------

        /* Загруить файлы отчетов в программу */
        private void btn_UploadFileMany_Click(object sender, EventArgs e)
        {
            businessList = new List<ReportBusinessModel> { };

            bool firstRow = true;
            openFileDialog1.Filter = "Неразмеченные файлы|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            int index = -1;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                FileNames.Clear();
                foreach (var t in openFileDialog2.FileNames)
                {
                    FileNames.Add(t);

                    index = FileNames[FileNames.Count - 1].LastIndexOf('\\');
                    richTextBox1.Text += FileNames[FileNames.Count - 1].Substring(index, FileNames[FileNames.Count - 1].Length - index) + "\n";
                }
            }
        }

        private void btn_CloseMany_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Сохранить в БД много файлов */
        private void btn_SaveMany_Click(object sender, EventArgs e)
        {
            bool errors = false;
            updatedRowsCount = 0;

            if (EndDate > StartDate)
            {
                if (FileNames.Count > 0)
                {
                    if (FileNames.Count == DaysDiff)
                    {
                        if (MessageBox.Show("Маркетплейс: " + cb_MarketPlace1.SelectedItem.ToString() + "\n\nЗагрузить отчет с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Enabled = false;
                            this.Cursor = Cursors.WaitCursor;

                            foreach (var t in FileNames)
                            {
                                LoadManyFilesStepByStep(t);

                                if (businessList.Count > 0)
                                {
                                    PrepareReportForSaving_Many();

                                    if (UploadMode)                 //если добавляем отчеты
                                    {
                                        if (businessController.InsertBusinessReport(businessList) == 0)
                                            errors = true;
                                        else
                                            updatedRowsCount += businessList.Count;
                                    }
                                    else if (UpdateMode)            //если обновляем отчеты
                                    {
                                        if (businessController.UpdateBusinessReport(businessList) == 0)
                                            errors = true;
                                        else
                                            updatedRowsCount += businessList.Count;
                                    }

                                    if (businessListOfErrors.Count > 0)
                                    {
                                        string errorsMsg = "Данные по следующим товарам не были добавлены. Вороятно, этот товар не занесен в программу.\n";
                                        string errorsstr = "";
                                        foreach (var k in businessListOfErrors)
                                        {
                                            errorsstr += "SKU: " + k.SKU + " Название товара: " + GetProductNameById(k.ProductId) + "\n";
                                        }
                                        MessageBox.Show(errorsMsg, "Ошибка");
                                        richTextBox1.Text = errorsstr;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Файл отчета \"" + t + "\" не был загружен. Нет данных для сохранения.", "Ошибка");
                                    errors = true;
                                }
                            }

                            if (!errors)
                                MessageBox.Show("Сохранение успешно. Всего сохранено строк - " + updatedRowsCount, "Успех");
                            else
                                MessageBox.Show("Сохранение прошло с ошибками. Всего сохранено строк - " + updatedRowsCount, "Сомнительный успех");

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

            try
            {
                using (TextFieldParser parser = new TextFieldParser(@_filename))
                {
                    parser.TextFieldType = FieldType.Delimited;

                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        //Process row
                        string[] fields = parser.ReadFields();
                        if (!firstRow)
                        {
                            businessList.Add(new ReportBusinessModel());

                            businessList[businessList.Count - 1].WriteData(1, fields[3]);
                            businessList[businessList.Count - 1].WriteData(2, fields[4]);
                            businessList[businessList.Count - 1].WriteData(4, fields[6]);
                            businessList[businessList.Count - 1].WriteData(6, fields[9]);
                            businessList[businessList.Count - 1].WriteData(7, fields[10]);
                            businessList[businessList.Count - 1].WriteData(10, fields[13]);
                            businessList[businessList.Count - 1].WriteData(11, fields[14]);
                            businessList[businessList.Count - 1].WriteData(12, fields[15]);
                            businessList[businessList.Count - 1].WriteData(13, fields[16]);
                        }
                        else
                            firstRow = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                businessList = new List<ReportBusinessModel> { };
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
            StartDate = mc_startDate.SelectionStart;EndDate = mc_EndDate.SelectionEnd;
            lb_endDateText.Text = "По " + EndDate.ToString().Substring(0, 10);
            DaysDiff = (EndDate - StartDate).Days + 1;
            lb_DaysDiff.Text = "Разница дат - " + DaysDiff;
        }

        private void cb_MarketPlace2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /* Считаем и заполняем все пустые поля в businessList, которые остались после загрузки файла */
        private void PrepareReportForSaving_Many()
        {
            int marketplaceid = GetMarketPlaceIdByName(cb_MarketPlace2.SelectedItem.ToString());
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
                businessList[i].SessionPercentage = Math.Round((double)businessList[i].Sessions / sumSessions * 100, 2);
                businessList[i].PageViewsPercentage = Math.Round((double)businessList[i].PageViews / sumPageViews * 100, 2);
                businessList[i].UnitSessionPercentage = Math.Round((double)businessList[i].UnitsOrdered / businessList[i].Sessions * 100, 2);
                businessList[i].UnitSessionPercentageB2B = Math.Round((double)businessList[i].UnitsOrderedB2B / businessList[i].Sessions * 100, 2);
                businessList[i].MarketPlaceId = marketplaceid;
                businessList[i].ProductId = GetProductIdBySKU(businessList[i].SKU);
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
    }
}
