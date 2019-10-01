using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Excel_Parse
{
    public partial class LoggerView : Form
    {
        private MainFormView mf;
        public UserModel userModel;

        private SqlConnection connection;

        private ProductsController pController;
        private List<ProductsModel> pList;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private LoggerController logController;
        private List<LoggerModel> logList;

        private LoginFormController lfController;
        private List<UserModel> uList;

        private List<string> uniqueProductNames;
        private List<string> uniqueASINs;

        private int previousCountOfLogs;

        private bool firstRun;
        private DateTime startDate, endDate;
        private int productIdForFilter, creationUserIdForFilter;
        private string asinForFilter, skuForFilter;

        private bool asinFilter;
        private bool skuFilter;
        private bool productNameFilter;
        private bool creationUserNameFilter;

        /* Конструктор */
        public LoggerView(MainFormView _mf, UserModel _um)
        {
            InitializeComponent();


            firstRun = true;
            startDate = DateTime.Today;
            //endDate = DateTime.Now;
            endDate = DateTime.Today.AddHours(23).AddMinutes(59);

            asinFilter = false;
            skuFilter = false;
            productNameFilter = false;
            creationUserNameFilter = false;

            productIdForFilter = creationUserIdForFilter = -1;
            asinForFilter = skuForFilter = "Все";

            previousCountOfLogs = 0;
            connection = DBData.GetDBConnection();
            mf = _mf;
            userModel = _um;

            notifyIcon1.Visible = true;

            pList = new List<ProductsModel> { };
            mpList = new List<MarketplaceModel> { };
            logList = new List<LoggerModel> { };
            uList = new List<UserModel> { };

            uniqueProductNames = new List<string> { };
            uniqueASINs = new List<string> { };

            pController = new ProductsController(this);
            mpController = new MarketplaceController(this);
            logController = new LoggerController(this);
            lfController = new LoginFormController(this);

            lb_StartDate.Text = startDate.ToString().Substring(0, 10);
            lb_EndDate.Text = endDate.ToString().Substring(0, 10);
            label4.Text = "С " + startDate.ToString().Substring(0, 10);
            label5.Text = "По " + endDate.ToString().Substring(0, 10);


            mpController.GetMarketplaces();

            pController.GetProductsAllJOIN();
            Fill_CB_ByProducts();

            lfController.GetAllUsers();
            Fill_CB_ByUsers();

            logController.GetAllRecordsByDate(startDate, endDate);
            if (logList.Count > 0)
            {
                label6.Visible = false;
                dgv_Log.Visible = true;
                previousCountOfLogs = logList.Count;
                Draw_dgv_Logs();
            }

            timer1.Enabled = true;
            timer1.Start();
        }


        /* Перерисовываем таблицу новыми данными из Logger */
        private void Draw_dgv_Logs()
        {
            dgv_Log.Rows.Clear();
            /*
             * 0 - recordId
             * 1 - cdate
             * 2 - cuser
             * 3 - productId
             * 4 - productName
             * 5 - asin
             * 6 - sku
             * 7 - text
             * 8 - marketplaceName
             */

            //заполняем таблицу даннымт с uList, logList, pList, mpList

            for (int i = 0; i < logList.Count; i++)
            {
                var index = dgv_Log.Rows.Add();

                dgv_Log.Rows[index].Cells[0].Value = logList[i].RecordId;
                dgv_Log.Rows[index].Cells[1].Value = logList[i].CreationDate.ToString().Substring(0, 10);
                dgv_Log.Rows[index].Cells[2].Value = GetUserNameByUserId(logList[i].CreationUserId);
                dgv_Log.Rows[index].Cells[3].Value = logList[i].ProductId;
                dgv_Log.Rows[index].Cells[4].Value = GetProductNameById(logList[i].ProductId);
                dgv_Log.Rows[index].Cells[5].Value = GetProductAsinById(logList[i].ProductId);
                dgv_Log.Rows[index].Cells[6].Value = logList[i].SKU;
                dgv_Log.Rows[index].Cells[7].Value = logList[i].Text;
                dgv_Log.Rows[index].Cells[8].Value = GetProductMarketPlaceNameBySKU(logList[i].SKU);
            }
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

        private int GetUserIdByUserName(string _creationUserName)
        {
            for (int i = 0; i < uList.Count; i++)
            {
                if (uList[i].Name.Equals(_creationUserName))
                    return uList[i].UserId;
            }
            return -1;
        }

        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
        }

        private int GetProductIdByName(string _productName)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].Name.Equals(_productName))
                    return pList[i].ProductId;
            }
            return -1;
        }

        private int GetProductIdByASIN(string _asin)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ASIN.Equals(_asin))
                    return pList[i].ProductId;
            }
            return -1;
        }

        private int GetProductIdBySKU(string _sku)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].SKU.Equals(_sku))
                    return pList[i].ProductId;
            }
            return -1;
        }

        private string GetProductAsinById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].ASIN;
            }
            return "";
        }

        private string GetProductSkuById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].SKU;
            }
            return "";
        }

        private string GetProductMarketPlaceNameBySKU(string _sku)
        {
            int marketPlaceId = -1;
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].SKU.Equals(_sku))
                    marketPlaceId = pList[i].MarketPlaceId;
            }
            if (marketPlaceId != -1)
            {
                for (int i = 0; i < mpList.Count; i++)
                {
                    if (mpList[i].MarketPlaceId == marketPlaceId)
                        return mpList[i].MarketPlaceName;
                }
            }
            return "";
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

        /* Получаем из контроллера Users, полученные с БД */
        public void GetUserDataFromDB(List<UserModel> _um)
        {
            uList = _um;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetRecordsFromDB(object _logList)
        {
            logList = (List<LoggerModel>)_logList;
        }


        /* Закрываем форму */
        private void LoggerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Show();
        }






        /* Инициируем выбор даты */
        private void Btn_ChooseDate_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                //закончили с выбором даты
                panel1.Visible = false;
                lb_StartDate.Visible = true;
                lb_EndDate.Visible = true;
                label8.Visible = true;

            }
            else
            {
                //начали выбор даты
                panel1.Visible = true;
                lb_StartDate.Visible = false;
                lb_EndDate.Visible = false;
                label8.Visible = false;
            }
        }

        /* Делает активной ячейку под курсором */
        private void Dgv_Log_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgv_Log.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }






        /* Заполняем cb_Products данными с pList */
        private void Fill_CB_ByProducts()
        {
            if (pList.Count > 0)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (!uniqueProductNames.Contains(pList[i].Name))
                        uniqueProductNames.Add(pList[i].Name);
                    if (!uniqueASINs.Contains(pList[i].ASIN))
                        uniqueASINs.Add(pList[i].ASIN);
                }

                cb_Products.Items.Clear();
                cb_ASIN.Items.Clear();
                cb_SKU.Items.Clear();

                cb_Products.Items.Add("Все");
                cb_ASIN.Items.Add("Все");
                cb_SKU.Items.Add("Все");

                for (int i = 0; i < uniqueProductNames.Count; i++)
                {
                    cb_Products.Items.Add(uniqueProductNames[i]);
                }

                for (int i = 0; i < uniqueASINs.Count; i++)
                {
                    cb_ASIN.Items.Add(uniqueASINs[i]);
                }

                for (int i = 0; i < pList.Count; i++)
                {
                    cb_SKU.Items.Add(pList[i].SKU);
                }

                cb_Products.SelectedItem = cb_Products.Items[0];
                cb_ASIN.SelectedItem = cb_ASIN.Items[0];
                cb_SKU.SelectedItem = cb_SKU.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одного товара. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы один товар.", "Ошибка");
            }
        }

        /* Заполняем cb_Users данными с uList */
        private void Fill_CB_ByUsers()
        {
            if (uList.Count > 0)
            {
                cb_Users.Items.Clear();
                cb_Users.Items.Add("Все");
                for (int i = 0; i < uList.Count; i++)
                {
                    cb_Users.Items.Add(uList[i].Name);
                }
                cb_Users.SelectedItem = cb_Users.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одного пользоватле. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы одного пользователя.", "Ошибка");
            }
        }

        /* После смены даты пользователем, автоматически меняем её в Mc_StartDate */
        private void Mc_StartDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            startDate = mc_StartDate.SelectionStart;
            lb_StartDate.Text = startDate.ToString().Substring(0, 10);
            label4.Text = "С " + startDate.ToString().Substring(0, 10);
        }

        /* После смены даты пользователем, автоматически меняем её в Mc_EndDate */
        private void Mc_EndDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            endDate = mc_EndDate.SelectionEnd;
            lb_EndDate.Text = endDate.ToString().Substring(0, 10);
            label5.Text = "По " + endDate.ToString().Substring(0, 10);
        }


        /* Обновляем таблицу каждую 1 секунду */
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (startDate < endDate)        //да "С" должна быть раньше даты "ПО"
            {
                try
                {
                    logController.GetRecordsByFilters(ChooseFilter());

                    if (logList.Count != previousCountOfLogs && logList.Count != 0) //если после запроса к БД количество строк изменилось, то перерисовываем таблицу
                    {
                        dgv_Log.Visible = true;
                        label6.Visible = false;
                        previousCountOfLogs = logList.Count;
                        Draw_dgv_Logs();

                        if (WindowState == FormWindowState.Minimized)
                        {
                            string prodName = GetProductNameById(logList[logList.Count - 1].ProductId);
                            string userName = GetUserNameByUserId(logList[logList.Count - 1].CreationUserId);
                            string text = logList[logList.Count - 1].Text;
                            LoggerModel lm = new LoggerModel();
                            lm = logList[logList.Count - 1];

                            LoggerNotification logNotific = new LoggerNotification(this, lm, userName, prodName, logList[logList.Count - 1].SKU, GetProductSkuById(logList[logList.Count - 1].ProductId), GetProductMarketPlaceNameBySKU(logList[logList.Count - 1].SKU), GetUserNameByUserId(logList[logList.Count - 1].EditUserId), text, userModel.UserId);

                            logNotific.Show();
                        }
                    }
                    else if (logList.Count == 0)        //если по фильтрам поиска ничего не нашли
                    {
                        label6.Visible = true;
                        dgv_Log.Visible = false;
                        previousCountOfLogs = logList.Count;
                    }
                }
                catch (Exception ex) { MessageBox.Show("При установке соединения с БД произошел сбой. Logger будет закрыт", "Ошибка"); this.Close(); }
            }
        }

        /* Формируем запрос для фильтра */
        private string ChooseFilter()
        {
            string sqlStatement = "SELECT * FROM [Logger] Where [CreationDate] between '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            bool asinFlag, skuFlag, productFlag;
            asinFlag = skuFlag = productFlag =false;


            if (creationUserNameFilter)
            {
                string addUserName = " and [CreationUserId] = " + creationUserIdForFilter;
                sqlStatement = sqlStatement + addUserName;
            }

            if (asinFilter)
            {
                string addASIN = " and ([ProductId] = " + GetProductIdByASIN(asinForFilter);
                sqlStatement = sqlStatement + addASIN;
                asinFlag = true;
            }
            if (productNameFilter)
            {
                if (asinFlag)
                {
                    string addProdName = " or [ProductId] = " + productIdForFilter;
                    sqlStatement = sqlStatement + addProdName;
                }
                else
                {
                    string addProdName = " and ([ProductId] = " + productIdForFilter;
                    sqlStatement = sqlStatement + addProdName;
                }
                productFlag = true;
            }

            if (asinFlag || productFlag)
            {
                sqlStatement = sqlStatement + ")";
            }

            if (skuFilter)
            {
                string addSKU = " and [SKU] = '" + skuForFilter + "'";
                sqlStatement = sqlStatement + addSKU;
            }

            asinFlag = skuFlag = productFlag = false;

            return sqlStatement;
        }

        /* Открываем запись на редактирование */
        private void Dgv_Log_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoggerModel lm = new LoggerModel();
            if (dgv_Log.RowCount > 0 && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                for (int i = 0; i < logList.Count; i++)
                {
                    if (logList[i].RecordId == int.Parse(dgv_Log.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        lm = logList[i];
                    }
                }

                string eUserName = "";
                int euserId = -1;

                for (int i = 0; i < logList.Count; i++)
                {
                    if (logList[i].RecordId == int.Parse(dgv_Log.Rows[e.RowIndex].Cells[0].Value.ToString()))
                        euserId = logList[i].EditUserId;
                }
                if (euserId != -1)
                {
                    for (int i = 0; i < uList.Count; i++)
                    {
                        if (uList[i].UserId == euserId)
                            eUserName = uList[i].Name;
                    }
                }

                LoggerShow ls = new LoggerShow(this, lm, dgv_Log.Rows[e.RowIndex].Cells[2].Value.ToString(), dgv_Log.Rows[e.RowIndex].Cells[4].Value.ToString(), dgv_Log.Rows[e.RowIndex].Cells[5].Value.ToString(), dgv_Log.Rows[e.RowIndex].Cells[6].Value.ToString(), dgv_Log.Rows[e.RowIndex].Cells[8].Value.ToString(), eUserName);

                timer1.Stop();
                ls.Show();
                this.Visible = false;
            }
        }

        /* Добавляем новую запись */
        private void Btn_AddRecord_Click(object sender, EventArgs e)
        {
            LoggerAdd lv = new LoggerAdd(this, userModel);
            timer1.Stop();
            lv.Show();
            this.Visible = false;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {    
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void Cb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstRun)
            {
                if (cb_Products.SelectedIndex != 0)
                {
                    productIdForFilter = GetProductIdByName(cb_Products.Items[cb_Products.SelectedIndex].ToString());
                    if (productIdForFilter != -1)
                        productNameFilter = true;
                }
                else
                    productNameFilter = false;
            }
        }

        private void Cb_ASIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstRun)
            {
                if (cb_ASIN.SelectedIndex != 0)
                {
                    asinForFilter = cb_ASIN.Items[cb_ASIN.SelectedIndex].ToString();
                    asinFilter = true;
                }
                else
                    asinFilter = false;
            }
        }
        
        private void Cb_SKU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstRun)
            {
                if (cb_SKU.SelectedIndex != 0)
                {
                    skuForFilter = cb_SKU.Items[cb_SKU.SelectedIndex].ToString();
                    skuFilter = true;
                }
                else
                    skuFilter = false;
            }
        }
        
        private void Cb_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstRun)
            {
                if (cb_Users.SelectedIndex != 0)
                {
                    creationUserIdForFilter = GetUserIdByUserName(cb_Users.Items[cb_Users.SelectedIndex].ToString());
                    if (creationUserIdForFilter != -1)
                        creationUserNameFilter = true;
                }
                else
                    creationUserNameFilter = false;
            }
        }

        /* Когда отредактировали запись и возвращаемся на эту форму, принудительно перерисовываем таблицу обновленными данными */
        private void LoggerView_VisibleChanged(object sender, EventArgs e)
        {
            //тут главной идее было реализовать момент, когда мы после редактирования (добавления) 
            //записи возвращаемся в это окно, чтобы в таблице данные обновлялись автоматически
            if (this.Visible == true && firstRun == true)
                firstRun = false;
            else if (this.Visible == true && firstRun == false)
            {
                logController.GetAllRecords();
                if (logList.Count > 0)
                {
                    previousCountOfLogs = logList.Count;
                    Draw_dgv_Logs();
                }

                timer1.Start();
            }
        }
    }
}
