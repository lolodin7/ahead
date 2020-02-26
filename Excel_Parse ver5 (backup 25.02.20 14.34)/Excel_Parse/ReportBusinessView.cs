using Microsoft.Office.Interop.Excel;
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
    public partial class ReportBusinessView : Form
    {
        private ReportBusinessFilterView reportFilter;
        private MainFormView mf;

        private List<ReportBusinessModel> businessList;

        private List<MarketplaceModel> mpList;
        private List<ProductsModel> pList;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public ReportBusinessView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            lb_StartDate.Text = DateTime.Today.ToString().Substring(0, 10);
            lb_EndDate.Text = DateTime.Today.ToString().Substring(0, 10);

            businessList = new List<ReportBusinessModel> { };
            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };
        }

        /* Показать окно фильтра */
        private void btn_ShowFilter_Click(object sender, EventArgs e)
        {
            if (reportFilter == null)
            {
                reportFilter = new ReportBusinessFilterView(this);
                reportFilter.Show();
            }
            else
            {
                reportFilter.Focus();
                reportFilter.WindowState = FormWindowState.Normal;
            }
        }

        /* Жкспорт данных из таблицы в файл */
        private void btn_Export_Click(object sender, EventArgs e)
        {
            bool okData = false;

            this.Cursor = Cursors.WaitCursor;

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.ColumnCount - 4; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount - 4; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                saveFileDialog1.FileName = lb_StartDate.Text + "-" + lb_EndDate.Text + " Business Report";

                okData = true;
            }
            else
                MessageBox.Show("Нет данных для экспорта!", "Ошибка");


            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            this.Cursor = Cursors.Default;

            if (okData)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    ExcelWorkBook.Close(false);
                }
                else
                {
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    ExcelWorkBook.SaveAs(filename);
                    ExcelWorkBook.Close(false);
                    MessageBox.Show("Успешно сохранено!", "Успех");
                }
            }
        }

        private void ReportBusinessView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }

        private void ReportBusinessView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (reportFilter != null)
                reportFilter.Close();
        }

        /* Получаем готовый businessList и заносим его в таблицу */
        public void GetBusinessList(object _businessList)
        {
            businessList = (List<ReportBusinessModel>)_businessList;
            DrawTable();
            DrawTableForBusinessReports();
        }

        public void GetMarketplaceList(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        public void GetProductList(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        private void DrawTable()
        {
            dataGridView1.Columns.Add("UpdateDate", "Date");
            dataGridView1.Columns.Add("MarketplaceId", "Marketplace");
            dataGridView1.Columns.Add("SKU", "SKU");
            dataGridView1.Columns.Add("Sessions", "Sessions");
            dataGridView1.Columns.Add("SessionPercentage", "Session %");
            dataGridView1.Columns.Add("PageViews", "Page Views");
            dataGridView1.Columns.Add("PageViewsPercentage", "Page Views %");
            dataGridView1.Columns.Add("UnitsOrdered", "Units Ordered");
            dataGridView1.Columns.Add("UnitsOrderedB2B", "Units Ordered - B2B");
            dataGridView1.Columns.Add("UnitSessionPercentage", "Unit Session %");
            dataGridView1.Columns.Add("UnitSessionPercentageB2B", "Unit Session % - B2B");
            dataGridView1.Columns.Add("OrderedProductSales", "Ordered Product Sales");
            dataGridView1.Columns.Add("OrderedProductSalesB2B", "Ordered Product Sales - B2B");
            dataGridView1.Columns.Add("TotalOrderItems", "Total Order Items");
            dataGridView1.Columns.Add("TotalOrderItemsB2B", "Total Order Items - B2B");
            dataGridView1.Columns.Add("ProductId", "ProductId");

            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 125;

            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Columns[1].Frozen = true;
            dataGridView1.Columns[2].Frozen = true;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[15].Visible = false;

            for (int i = 0; i < businessList[0].ColumnCount; i++)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 3)
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private string GetMarketPlaceName(object _var)
        {
            int marketplaceId = (int)_var;

            foreach (var t in mpList)
            {
                if (t.MarketPlaceId == marketplaceId)
                    return t.MarketPlaceName;
            }
            return "NOT_FOUND";
        }

        public void GetBusinessListToShow(object _businessList)
        {

            lb_StartDate.Text = StartDate.ToString().Substring(0, 10);
            lb_EndDate.Text = EndDate.ToString().Substring(0, 10);

            businessList = (List<ReportBusinessModel>)_businessList;
            DrawTableForBusinessReports();
        }

        private void DrawTableForBusinessReports()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (businessList.Count > 0)
            {
                DrawTable();

                DrawFirstRow(businessList);

                for (int i = 0; i < businessList.Count; i++)
                {
                    var index = dataGridView1.Rows.Add();

                    for (int j = 0; j < businessList[i].ColumnCount; j++)
                    {
                        if (j == 1)
                            dataGridView1.Rows[index].Cells[j].Value = GetMarketPlaceName(businessList[i].ReadData(j));
                        else if (j == 0)
                            dataGridView1.Rows[index].Cells[j].Value = businessList[i].ReadData(j).ToString().Substring(0, 10);
                        else
                            dataGridView1.Rows[index].Cells[j].Value = businessList[i].ReadData(j);
                    }
                }
            }

            btn_Export.Text = "Экспорт в файл (" + dataGridView1.RowCount + ")";
        }

        private void DrawFirstRow(List<ReportBusinessModel> _businessList)
        {
            int Sessions = 0;
            double SessionPercentage = 0;
            int PageViews = 0;
            double PageViewsPercentage = 0;
            int UnitsOrdered = 0;
            int UnitsOrderedB2B = 0;
            double UnitSessionPercentage = 0;
            double UnitSessionPercentageB2B = 0;
            double OrderedProductSales = 0;
            double OrderedProductSalesB2B = 0;
            int TotalOrderItems = 0;
            int TotalOrderItemsB2B = 0;


            for (int i = 0; i < _businessList.Count; i++)
            {
                Sessions += _businessList[i].Sessions;
                PageViews += _businessList[i].PageViews;
                UnitsOrdered += _businessList[i].UnitsOrdered;
                UnitsOrderedB2B += _businessList[i].UnitsOrderedB2B;
                OrderedProductSales += _businessList[i].OrderedProductSales;
                OrderedProductSalesB2B += _businessList[i].OrderedProductSalesB2B;
                TotalOrderItems += _businessList[i].TotalOrderItems;
                TotalOrderItemsB2B += _businessList[i].TotalOrderItemsB2B;
            }

            //if (Sessions != 0)
            //    SessionPercentage = Math.Round(((double)clicks / impr) * 100, 2);
            //else
            //    ctr = 0;

            //if (clicks != 0)
            //    cpc = Math.Round(spend / clicks, 2);
            //else
            //    cpc = 0;

            //if (sales != 0)
            //    acos = Math.Round((spend / sales) * 100, 2);
            //else
            //    acos = 0;

            //if (spend != 0)
            //    roas = Math.Round(sales / spend, 2);
            //else
            //    roas = 0;

            //if (clicks != 0)
            //    convers = Math.Round(((double)orders / clicks) * 100, 2);
            //else
            //    convers = 0;

            var index = dataGridView1.Rows.Add();

            dataGridView1.Rows[index].Cells[3].Value = Sessions;
            dataGridView1.Rows[index].Cells[5].Value = PageViews;
            dataGridView1.Rows[index].Cells[7].Value = UnitsOrdered;
            dataGridView1.Rows[index].Cells[8].Value = UnitsOrderedB2B;
            dataGridView1.Rows[index].Cells[11].Value = OrderedProductSales;
            dataGridView1.Rows[index].Cells[12].Value = OrderedProductSalesB2B;
            dataGridView1.Rows[index].Cells[13].Value = TotalOrderItems;
            dataGridView1.Rows[index].Cells[14].Value = TotalOrderItemsB2B;
        }

        private void ReportBusinessView_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 30;
            dataGridView1.Height = this.Height - 80;

            btn_ShowFilter.Location = new System.Drawing.Point(this.Width - btn_ShowFilter.Size.Width - 20, btn_ShowFilter.Location.Y);
        }
    }
}
