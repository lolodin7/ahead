using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Excel_Parse
{
    public partial class MainFormView : Form
    {
        private SqlConnection connection;
        private SqlCommand command;

        private List<DateTime> advertisingDates;
        private List<DateTime> stockDates;
        private List<DateTime> ordersDates;
        private List<DateTime> businessDates;

        private bool Permissions = true;   //false - обычный пользователь, true - admin

        /* Главный коструктор */
        public MainFormView()
        {
            InitializeComponent();

            if (!Permissions)
            {
                //показывает картинку при запуске программы
                StartImage startImg = new StartImage();
                startImg.Show();
                this.Refresh();
                startImg.Refresh();
                System.Threading.Thread.Sleep(2000);
                startImg.Close();
                //перестали показывать картинку при запуске программы
            }

            if (!Permissions)
            {
                int prC = 0;
                foreach (Process pr in Process.GetProcesses())
                    if (pr.ProcessName == "Bona Fides") prC++;
                if (prC > 1)
                {
                    MessageBox.Show("Приложение уже запущено!", "Ошибка");
                    Process.GetCurrentProcess().Kill();
                }
            }

            connection = DBData.GetDBConnection();
            if (connection.ConnectionString.Equals(""))
            {
                MessageBox.Show("Проблема при подключении к серверу. Перезапустите приложение или попробуйте позже.", "Ошибка");
                menuStrip1.Enabled = false;
                statusStrip1.Visible = false;
            }
            else
            {
                GetStatus();
            }

            addSectionToolStripMenuItem1.Visible = Permissions;
        }

        private void MainFormView_Load(object sender, EventArgs e)
        {

        }

        /* Обновляем инфу о Last Update во время работы программы */
        private void MainFormView_VisibleChanged(object sender, EventArgs e)
        {
            GetStatus();
        }

        private void GetStatus()
        {
            DateTime startDate, endDate;
            endDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            startDate = DateTime.Today.AddDays(-31);

            string sqlStatement = "";

            sqlStatement = "SELECT DISTINCT [UpdateDate] from [AdvertisingProducts] WHERE [UpdateDate] between '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            advertisingDates = new List<DateTime> { };
            GetDatesFromDB(advertisingDates);

            sqlStatement = "SELECT DISTINCT [PurchaseDate] from [Orders] WHERE [PurchaseDate] between '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            ordersDates = new List<DateTime> { };
            GetDatesFromDB(ordersDates);

            sqlStatement = "SELECT DISTINCT [UpdateDate] from [BusinessReport] WHERE [UpdateDate] between '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            businessDates = new List<DateTime> { };
            GetDatesFromDB(businessDates);

            sqlStatement = "SELECT DISTINCT [UpdateDate] from [Stock] WHERE [UpdateDate] between '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            stockDates = new List<DateTime> { };
            GetDatesFromDB(stockDates);
            
            toolStripStatusLabel2.Text = "Реклама - " + GetMaxDate(advertisingDates) + "   ";
            toolStripStatusLabel4.Text = "Продажи - " + GetMaxDate(ordersDates) + "   ";
            toolStripStatusLabel6.Text = "Склад - " + GetMaxDate(stockDates) + "   ";
            toolStripStatusLabel8.Text = "Сессии - " + GetMaxDate(businessDates) + "   ";
        }

        private void GetDatesFromDB(List<DateTime> _datesList)
        {
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;
                        _datesList.Add(getDate(record[0]));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }

        private DateTime getDate(object record)
        {
            return (DateTime)record;
        }

        private string GetMaxDate(List<DateTime> _workingList)
        {
            if (_workingList.Count > 0)
            {
                DateTime result = _workingList[0];

                foreach (var t in _workingList)
                {
                    if (t > result)
                        result = t;
                }

                return result.ToShortDateString();
            }
            else return "(пусто)";
        }
        
        private void btn_DoProductType_Click(object sender, EventArgs e)
        {
            ProductTypesView productTypes = new ProductTypesView(this);
            productTypes.Show();
            this.Visible = false;
        }

        private void btn_DoMarketplaces_Click(object sender, EventArgs e)
        {
            MarketplaceView mp = new MarketplaceView(this);
            mp.Show();
            this.Visible = false;
        }
        
        private void btn_DoProducts_Click(object sender, EventArgs e)
        {
            ProductsView products = new ProductsView(this, Permissions);              
            products.Show();
            this.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About(this);
            ab.Show();
            this.Visible = false;
        }

        private void showAdvDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAdvertisingView advRep = new ReportAdvertisingView(this);
            advRep.Show();
            this.Visible = false;
        }

        private void addAdvReportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAdvertisingUploadView advUpRep = new ReportAdvertisingUploadView(this);
            advUpRep.Show();
            this.Visible = false;
        }

        private void addBusinessReportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportBusinessUploadView busUpRep = new ReportBusinessUploadView(this, "upload");
            busUpRep.Show();
            this.Visible = false;
        }
        
        private void showSalesDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportSalesView repSales = new ReportSalesView(this);
            repSales.Show();
            this.Visible = false;
        }

        private void showSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSessionsView repSes = new ReportSessionsView(this);
            repSes.Show();
            this.Visible = false;
        }

        private void showGeneralSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addReturnsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllOrdersView allov = new AllOrdersView(this);
            allov.Show();
            this.Visible = false;
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportStockUploadView repstock = new ReportStockUploadView(this);
            repstock.Show();
            this.Visible = false;
        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportStockView repstock = new ReportStockView(this);
            repstock.Show();
            this.Visible = false;
        }

        private void showReturnsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        
        /* Выход из приложения по кнопке "Выход" */
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


























        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private DateTime currencyLastUpdate;
        //private static readonly ImageConverter _imageConverter = new ImageConverter();

        /* Главный конструктор, после формы логина */
        public MainFormView(string _something)
        {
            InitializeComponent();

            //блок, где проверяем, нужно ли обновить данные курса валют. обновляем раз в сутки
            string tmp = ConfigurationManager.AppSettings.Get("currencyCheck");
            currencyLastUpdate = new DateTime(int.Parse(tmp.Substring(6, 4)), int.Parse(tmp.Substring(3, 2)), int.Parse(tmp.Substring(0, 2)));
            if (currencyLastUpdate != DateTime.Today)
            {
                int result = 0;

                CurrencyController curController = new CurrencyController();

                result = curController.UpdateCurrencies();
                if (result == 1)
                    UpdateConfig(DateTime.Today.ToString().Substring(0, 10));
            }
        }
        
        private void btn_DoSemCore_Click(object sender, EventArgs e)
        {
            SemCoreView semcore = new SemCoreView(this);
            if (!semcore.NoProdType && !semcore.NoKeyCat)
            {
                semcore.Show();
                this.Visible = false;
            }
        }

        private void btn_DoRewriteSemCore_Click(object sender, EventArgs e)
        {
            SemCoreRebuildView scr = new SemCoreRebuildView(this);
            if (!scr.NoKeyCat && !scr.NoProdType)
            {
                scr.Show();
                this.Visible = false;
            }
        }

        private void btn_DoKeywordCategory_Click(object sender, EventArgs e)
        {
            KeywordCategoryView keycat = new KeywordCategoryView(this);
            if (!keycat.HardClose)
            {
                keycat.Show();
                this.Visible = false;
            }
        }

        /* Обновляем значение касательно КУРСА ВАЛЮТ в конфиге */
        public void UpdateConfig(string val)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals("currencyCheck"))
                        {
                            node.Attributes[1].Value = val;
                        }
                    }
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
        }
           
        private void btn_ShowAllKeywords_Click(object sender, EventArgs e)
        {
            FullSemCoreView fsc = new FullSemCoreView(this);
            if (!fsc.NoProdType && !fsc.NoKeyCat)
            {
                fsc.Show();
                this.Visible = false;
            }
        }
        
        private void SemCoreArchive_Click(object sender, EventArgs e)
        {
            SemCoreArchiveView sca = new SemCoreArchiveView(this);
            sca.Show();
            this.Visible = false;
        }
    }
}




































/* 
        public void SetImages(int _ID)
        {
            Bitmap newBitmap = GetImageFromByteArray(File.ReadAllBytes("C:\\wow.jpg"));
            ImageConverter converter = new ImageConverter();
            byte[] imageData = (byte[])converter.ConvertTo(newBitmap, typeof(byte[]));

            connection = DBData.GetDBConnection();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO Images VALUES (@ImageId, @FileName, @Title, @ImageData)";
            command.Parameters.Add("@ImageId", SqlDbType.Int);
            command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);

            // путь к файлу для загрузки
            string filename = @"C:\wow.jpg";
            // заголовок файла
            string title = "WoW";
            // получаем короткое имя файла для сохранения в бд
            string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                                                                                       // массив для хранения бинарных данных файла

            // передаем данные в команду через параметры
            command.Parameters["@ImageId"].Value = _ID;
            command.Parameters["@FileName"].Value = shortFileName;
            command.Parameters["@Title"].Value = title;
            command.Parameters["@ImageData"].Value = imageData;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }
 
     
     
     */
