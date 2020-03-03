using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        public string AmazonLink { get; set; }
        public UserModel um;
        private LoginFormView lf;
        private DateTime currencyLastUpdate;

        private bool JustExit;      //для выхода из приложения при нажатии "Х" в правом верхнем углу

        private int LogsCount;
        private LoggerController logController;
        private List<LoggerModel> logList;


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






        private static readonly ImageConverter _imageConverter = new ImageConverter();
        private SqlConnection connection;


        /* Главный конструктор, после формы логина */
        public MainFormView(UserModel _um, LoginFormView _lf)
        {
            InitializeComponent();
            um = _um;
            lf = _lf;
            AmazonLink = ConfigurationManager.AppSettings.Get("amzLink");
            JustExit = true;
            logController = new LoggerController(this);
            logList = new List<LoggerModel> { };

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

            GetStartLogsCount();
            //timer1.Start();
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetRecordsFromDB(object _logList)
        {
            logList = (List<LoggerModel>)_logList;
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





        /* Закрытие формы */
        private void MainFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (JustExit)
            {
                lf.SignInWithSaveMe = false;
                lf.ReSignIn = false;
                lf.Visible = true;
            }
            else
            {
                JustExit = true;
                lf.SignInWithSaveMe = false;
                lf.Visible = true;
            }
        }

        /* Завершение сеанса */
        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lf.ReSignIn = true;
            JustExit = false;
            lf.UpdateConfig("false");
            this.Close();
        }

        /* Выход из приложения по кнопке "Выход" */
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            JustExit = false;
            lf.ReSignIn = false;
            this.Close();
        }

        /* Если вдруг имя было изменено, переписываем его на фомре при каждом появлении формы */
        private void MainFormView_VisibleChanged(object sender, EventArgs e)
        {
            label1.Text = "Привет, " + um.Name;
        }

        private void MainFormView_Load(object sender, EventArgs e)
        {
            switch (um.UserRoleId)
            {
                case 0:     //admin

                    break;
                case 1:     //boss

                    break;
                case 2:     //user
                    registerNewEmployeeToolStripMenuItem.Visible = false;
                    DoMarketpalcesToolStripMenuItem.Visible = false;
                    DoKeywordCategoryToolStripMenuItem.Visible = false;
                    DoProductTypesToolStripMenuItem.Visible = false;
                    employeesToolStripMenuItem.Visible = false;
                    addSectionToolStripMenuItem1.Enabled = false;
                    updateSectionToolStripMenuItem.Enabled = false;
                    семантическиеЯдраToolStripMenuItem.Enabled = false;
                    everyDayToolStripMenuItem.Enabled = false;
                    break;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------





























        private void btn_DoSemantics_Click(object sender, EventArgs e)
        {
            ChooseProduct cp = new ChooseProduct(this);
            cp.Show();
            this.Visible = false;
        }

        private void btn_DoProducts_Click(object sender, EventArgs e)
        {
            ProductsView products = new ProductsView(this);
            products.Show();
            this.Visible = false;
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

        private void btn_ShowIndexing_Click(object sender, EventArgs e)
        {
            IndexingView iv = new IndexingView(this);
            iv.Show();
            this.Visible = false;
        }

        private void ChooseProduct_Click(object sender, EventArgs e)
        {
            ChooseProduct cp = new ChooseProduct(this, true);
            cp.Show();
            this.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About(this);
            ab.Show();
            this.Visible = false;
        }


        private void SemCoreArchive_Click(object sender, EventArgs e)
        {
            SemCoreArchiveView sca = new SemCoreArchiveView(this);
            sca.Show();
            this.Visible = false;
        }

        private void ShowPersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPanelView cp = new ControlPanelView(um, this);
            cp.Show();
            this.Visible = false;
        }

        private void registerNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterAnEmployeeView re = new RegisterAnEmployeeView(this);
            re.Show();
            this.Visible = false;
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUsersView su = new ShowUsersView(this);
            su.Show();
            this.Visible = false;
        }

        private void LoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggerView lv = new LoggerView(this, um);
            lv.Show();
            this.Visible = false;
        }



        private void GetStartLogsCount()
        {
            logController.GetAllRecords();
            LogsCount = logList.Count;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            logController.GetAllRecords();
            if (LogsCount != logList.Count)
            {

                string prodName = "ПРодуктище";// GetProductNameById(logList[logList.Count - 1].ProductId);
                string userName = "Васяныч";// GetUserNameByUserId(logList[logList.Count - 1].CreationUserId);
                string text = logList[logList.Count - 1].Text;
                LoggerModel lm = new LoggerModel();
                lm = logList[logList.Count - 1];

                LoggerNotification logNotific = new LoggerNotification(this, lm, userName, prodName, text);

                logNotific.Show();


                LogsCount = logList.Count;
            }
        }
        

        private void showAdvDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAdvertisingView advRep = new ReportAdvertisingView(this);
            advRep.Show();
            this.Visible = false;
        }

        private void addAdvReportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAdvertisingUploadView advUpRep = new ReportAdvertisingUploadView(this, "upload");
            advUpRep.Show();
            this.Visible = false;
        }

        private void updateAdvertisingReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportAdvertisingUploadView advUpRep = new ReportAdvertisingUploadView(this, "update");
            advUpRep.Show();
            this.Visible = false;
        }

        private void addBusinessReportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportBusinessUploadView busUpRep = new ReportBusinessUploadView(this, "upload");
            busUpRep.Show();
            this.Visible = false;
        }

        private void updateBusinessReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportBusinessUploadView busUpRep = new ReportBusinessUploadView(this, "update");
            busUpRep.Show();
            this.Visible = false;
        }

        private void showSalesDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportBusinessView repBus = new ReportBusinessView(this);
            repBus.Show();
            this.Visible = false;
        }

        private void showSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSessionsView repSes = new ReportSessionsView(this);
            repSes.Show();
            this.Visible = false;
        }

        private void showSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void everyDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EveryDayReportsUpdate evr = new EveryDayReportsUpdate(this);
            evr.Show();
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

        /* 
         
          
        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
        }
        
        private string GetUserNameByUserId(int _creationUserId)
        {
            for (int i = 0; i < uList.Count; i++)
            {
                if (uList[i].UserId == _creationUserId)
                    return uList[i].Name;
            }
            return "";
        }
         
         
         */
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
