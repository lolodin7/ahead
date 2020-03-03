using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class ReportStockUploadView : Form
    {
        private MainFormView mf;
        private DateTime UpdateDate;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private ProductsController prodController;
        private List<ProductsModel> pList;

        private ReportStockController stockController;

        private List<StockModel> stockList;

        private string path = "";


        public ReportStockUploadView(MainFormView _mf)
        { 
            InitializeComponent();
            mf = _mf;

            UpdateDate = DateTime.Today;

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };

            stockList = new List<StockModel> { };

            mpController = new MarketplaceController(this);
            prodController = new ProductsController(this);
            stockController = new ReportStockController(this);

            if (mpController.GetMarketplaces() == 1)
                Fill_CB_Marketplace();


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

        /* Смена даты в mc_UpdateDate */
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateDate = mc_StartDate.SelectionStart;
        }

        /* Обработка закрытия формы */
        private void ReportStockView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }

        /* Кнопка закрытия формы */
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private int GetProductIdBySku(string _sku, int _mpId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (_sku.ToLower().Equals(pList[i].SKU.ToLower()) && _mpId == pList[i].MarketPlaceId)
                    return pList[i].ProductId;
            }
            return -1;
        }

        /* Загрузка файла, его обработка и преобразование в List */
        private void btn_UploadFromFile_Click(object sender, EventArgs e)
        {
            prodController.GetProductsAllJOIN();

            openFileDialog1.Filter = "Неразмеченные файлы|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            bool firstRow = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                stockList.Clear();
                path = openFileDialog1.FileName;

                try
                {
                    using (TextFieldParser parser = new TextFieldParser(@path))
                    {
                        parser.TextFieldType = FieldType.Delimited;

                        parser.SetDelimiters(",");

                        string[] fields;

                        while (!parser.EndOfData)
                        {
                            //Process row
                            fields = parser.ReadFields();

                            if (!firstRow)
                            {
                                StockModel tmpObj = new StockModel();

                                tmpObj.UpdateDate = UpdateDate;
                                tmpObj.ASIN = fields[2];
                                tmpObj.SKU = fields[0];
                                tmpObj.FNSKU = fields[1];
                                tmpObj.Name = fields[3];
                                tmpObj.FulfillableItems = int.Parse(fields[10]);
                                tmpObj.ReservedItems = int.Parse(fields[12]);
                                tmpObj.InboundShipped = int.Parse(fields[16]);
                                tmpObj.InboundWorking = int.Parse(fields[15]);

                                tmpObj.MarketPlaceId = GetMarketPlaceIdByName(cb_MarketPlace.SelectedItem.ToString());
                                tmpObj.ProductId = GetProductIdBySku(tmpObj.SKU, tmpObj.MarketPlaceId);

                                stockList.Add(tmpObj);
                            }
                            else
                                firstRow = false;

                        }
                        lb_Path.Text = path;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                    stockList.Clear();
                }
            }
        }

        /* Загрузка отчета в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (stockList.Count > 0)
            {
                if (MessageBox.Show("Маркетплейс: " + cb_MarketPlace.SelectedItem.ToString() + "\n\nДата отчета: " + UpdateDate.ToString().Substring(0, 10) + "\n\nЗагрузить отчет с этими параметрами?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Enabled = false;
                    if (stockController.UploadStockReport(stockList) != 1)
                        MessageBox.Show("Во время сохранения произошла ошибка. Работа была прервана.", "Ошибка");
                    else
                        MessageBox.Show("Сохранение успешно. Всего сохранено строк - " + stockList.Count, "Успех");
                    this.Enabled = true;
                }
            }
            else
                MessageBox.Show("Нечего сохранять. Сначала загрузите отчет.", "Ошибка");
        }
    }
}
