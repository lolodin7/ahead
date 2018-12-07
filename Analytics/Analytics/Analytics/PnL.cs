using Excel_Parse;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytics
{
    public partial class PnL : Form
    {
        private DateTime start;         //храним начальную дату
        private DateTime end;           //храним конечную дату
        private string SKU;
        private string ASIN;
        private string Marketplace;
        private int MarketplaceId;
        private ChooseProduct cp;       
        private ChooseMP cMP;           
        private SqlConnection connection;

        private bool bySKU;             //если вызывали по SKU
        private bool byASIN;            //если вызывали по ASIN 
        private bool byMarketplace;     //если вызывали по Marketplace

        private bool showByDays = true;         //отображение по дням
        private bool showByWeeks = false;       //отображение по неделям
        private bool showByMonths = false;      //отображение по месяцам

        /* Конструктор для работы с SKU */
        public PnL(ChooseProduct _cp, string _sku)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();

            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            bySKU = true;
            SKU = _sku;
            cp = _cp;
            this.Text = this.Text + " - SKU: " + SKU;
            DrawTableColumns();
        }

        /* Конструктор для работы с ASIN */
        public PnL(string _asin, ChooseProduct _cp)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();

            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            byASIN = true;
            ASIN = _asin;
            cp = _cp;
            this.Text = this.Text + " - ASIN: " + ASIN;
            DrawTableColumns();
        }

        /* Конструктор для работы с Marketplace */
        public PnL(ChooseMP _cp, string _marketplace, int _marketplaceId)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();

            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            byMarketplace = true;
            Marketplace = _marketplace;
            MarketplaceId = _marketplaceId;
            cMP = _cp;
            this.Text = this.Text + " - Marketplace: " + Marketplace;
            DrawTableColumns();
        }


        //------------------------------------------------DatePicker REGION START---------------------------------------------------------------
        #region DatePicker  
        /* Показываем/скрываем панель выбора диапазона дат */
        private void btn_ChooseDate_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                panel1.BringToFront();
            }
            else
            {
                if (end < start)
                    MessageBox.Show("Неккоректный диапазон дат!", "Ошибка");
                else
                {
                    btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                    panel1.Visible = false;
                }
            }
        }

        /* Изменение даты в monthCalendarStart */
        private void monthCalendarStart_DateChanged(object sender, DateRangeEventArgs e)
        {
            tb_DateStart.Text = monthCalendarStart.SelectionRange.Start.ToString().Substring(0, 10);
            start = monthCalendarStart.SelectionRange.Start;
        }

        /* Изменение даты в monthCalendarEnd */
        private void monthCalendarEnd_DateChanged(object sender, DateRangeEventArgs e)
        {
            tb_DateEnd.Text = monthCalendarEnd.SelectionRange.Start.ToString().Substring(0, 10);
            end = monthCalendarEnd.SelectionRange.Start;
        }

        /* Вводим дату вручную */
        private void tb_DateStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 13)
                e.Handled = true;
            if (e.KeyChar == 13)
                getDateByEnter("Start");
        }

        /* Вводыим дату вручную */
        private void tb_DateEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 13)
                e.Handled = true;
            if (e.KeyChar == 13)
                getDateByEnter("End");
        }

        /* Проверяем корректность введеной вручную даты */
        private void getDateByEnter(string btn)
        {
            switch (btn)
            {
                case "Start":
                    try
                    {
                        DateTime dt = new DateTime(int.Parse(tb_DateStart.Text.Substring(6, 4)), int.Parse(tb_DateStart.Text.Substring(3, 2)), int.Parse(tb_DateStart.Text.Substring(0, 2)));
                        if (end < dt)
                            MessageBox.Show("Неккоректный диапазон дат!", "Ошибка");
                        else
                        {
                            start = dt;
                            monthCalendarStart.SelectionStart = dt;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("При вводе данных была допущена ошибка!", "Ошибка"); }
                    break;
                case "End":
                    try
                    {
                        DateTime dt = new DateTime(int.Parse(tb_DateEnd.Text.Substring(6, 4)), int.Parse(tb_DateEnd.Text.Substring(3, 2)), int.Parse(tb_DateEnd.Text.Substring(0, 2)));
                        if (dt < start)
                            MessageBox.Show("Неккоректный диапазон дат!", "Ошибка");
                        else
                        {
                            end = dt;
                            monthCalendarEnd.SelectionStart = dt;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("При вводе данных была допущена ошибка!", "Ошибка"); }
                    break;
            }
        }

        /* Выбираем период за 7 дней */
        private void btn_7daysPeriod_Click(object sender, EventArgs e)
        {
            int dayCnt = 6;

            oneDayRollback();

            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(end.Year, end.Month, end.Day - dayCnt);
                    start = dt;
                    monthCalendarStart.SelectionStart = start;
                    btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233086)
                    {
                        try
                        {
                            DateTime dt = new DateTime(end.Year, end.Month - 1, (DateTime.DaysInMonth(end.Year, end.Month - 1) + end.Day) - dayCnt);
                            start = dt;
                            monthCalendarStart.SelectionStart = start;
                            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                        }
                        catch (Exception exx)
                        {
                            if (ex.HResult == -2146233086)
                            {
                                DateTime dt = new DateTime(end.Year - 1, end.Month + 12 - 1, (DateTime.DaysInMonth(DateTime.Now.Year, end.Month + 12 - 1) + end.Day) - dayCnt);
                                start = dt;
                                monthCalendarStart.SelectionStart = start;
                                btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                            }
                        }
                    }
                }
            }
        }

        /* Выбираем период за 30 дней */
        private void btn_30daysPeriod_Click(object sender, EventArgs e)
        {
            oneDayRollback();

            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(end.Year, end.Month - 1, end.Day);
                    start = dt;
                    monthCalendarStart.SelectionStart = start;
                    btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233086)
                    {
                        try
                        {
                            DateTime dt = new DateTime(end.Year - 1, 12 + end.Month - 1, end.Day);
                            start = dt;
                            monthCalendarStart.SelectionStart = start;
                            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                        }
                        catch (Exception exx) { }
                    }
                }
            }
        }

        /* Выбираем период за 6 месяцев */
        private void btn_6monthsPeriod_Click(object sender, EventArgs e)
        {
            oneDayRollback();

            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(end.Year, end.Month - 6, end.Day);
                    start = dt;
                    monthCalendarStart.SelectionStart = start;
                    btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233086)
                    {
                        try
                        {
                            DateTime dt = new DateTime(end.Year - 1, end.Month + 12 - 6, end.Day);
                            start = dt;
                            monthCalendarStart.SelectionStart = start;
                            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                        }
                        catch (Exception exx) { }
                    }
                }
            }
        }

        /* Выбираем период за 1 год */
        private void btn_1yearPeriod_Click(object sender, EventArgs e)
        {
            oneDayRollback();

            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(end.Year - 1, end.Month, end.Day);
                    start = dt;
                    monthCalendarStart.SelectionStart = start;
                    btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                }
                catch (Exception ex) { }
            }
        }

        /* Для отображения, устанавливаем вчерашний день */
        private void oneDayRollback()
        {
            end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (end.Day - 1 <= 0)
            {
                if (end.Month - 1 <= 0)
                {
                    //tb_DateEnd.Text = ((DateTime.DaysInMonth(end.Year - 1, end.Month + 12 - 1) + end.Day - 1) - 1).ToString() + "." + (end.Year - 1).ToString() + "." + (end.Month + 12 - 1).ToString();
                    monthCalendarEnd.SetDate(new DateTime(end.Year - 1, end.Month + 12 - 1, (DateTime.DaysInMonth(end.Year - 1, end.Month + 12 - 1) + end.Day - 1) - 1));
                    tb_DateEnd.Text = monthCalendarEnd.SelectionRange.Start.ToString().Substring(0, 10);
                    end = monthCalendarEnd.SelectionRange.Start;
                }
                else
                {
                    //tb_DateEnd.Text = (end.Month - 1).ToString() + "." + ((DateTime.DaysInMonth(end.Year, end.Month - 1) + end.Day) - 1).ToString() + "." + (end.Year).ToString();
                    monthCalendarEnd.SetDate(new DateTime(end.Year, end.Month - 1, (DateTime.DaysInMonth(end.Year, end.Month - 1) + end.Day) - 1));
                    tb_DateEnd.Text = monthCalendarEnd.SelectionRange.Start.ToString().Substring(0, 10);
                    end = monthCalendarEnd.SelectionRange.Start;
                }
            }
            else
            {
                //tb_DateEnd.Text = (end.Day - 1) + "." + end.Month + "." + end.Year;
                monthCalendarEnd.SetDate(new DateTime(end.Year, end.Month, end.Day - 1));
                tb_DateEnd.Text = monthCalendarEnd.SelectionRange.Start.ToString().Substring(0, 10);
                end = monthCalendarEnd.SelectionRange.Start;
            }
        }

        /* Переходим на сегодня */
        private void btn_Today_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            start = dt;
            end = dt;
            monthCalendarStart.SelectionStart = start;
            monthCalendarEnd.SelectionStart = end;
            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
        }

        /* Переходим на вчера */
        private void btn_Yesterday_Click(object sender, EventArgs e)
        {
            oneDayRollback();
            start = end;
            monthCalendarStart.SelectionStart = start;
            monthCalendarEnd.SelectionStart = end;
            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
        }

        #endregion
        //------------------------------------------------DatePicker REGION END-----------------------------------------------------------------


        /* Создаем главные колонки в dataGridView1 */
        private void DrawTableColumns()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("typeCol", "Тип");
            dataGridView1.Columns.Add("descrCol", "Описание");
        }

        private int getDayCount()
        {
            TimeSpan newdt = end - start;
            return newdt.Days + 1;
        }

        /* Получаем с БД инфу по SKU и записываем её в dataGridView */
        private void showSKUPnL()
        {
            getDayCount();
            string sqlSemanticsIds;
            SqlCommand command;
            DateTime workDate = start;
            int daysCount = getDayCount();

            if (showByDays)
            {
                for (int i = 0; i < daysCount; i++)
                {
                    dataGridView1.Columns.Add(workDate.ToString(), workDate.ToShortDateString());
                    workDate = workDate.AddDays(1);
                }

                workDate = start;
                int startPos = 1;

                for (int i = 0; i < daysCount; i++)
                {
                    startPos = 1;
                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'adjustment' and sku = '" + SKU + "' and [Description] = 'FBA Inventory Reimbursement - Customer Return' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Корректирование", "FBA Inventory Reimbursement - Customer Return", i + 2, startPos);
                    startPos += 3;

                    //----------------------------------------  TYPE: adjustment---------------------------------
                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'adjustment' and sku = '" + SKU + "' and [Description] = 'FBA Inventory Reimbursement - Customer Return' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Корректирование", "FBA Inventory Reimbursement - Customer Return", i + 2, startPos);
                    startPos += 3;


                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'adjustment' and sku = '" + SKU + "' and [Description] = 'FBA Inventory Reimbursement - Damaged:Warehouse' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Корректирование", "FBA Inventory Reimbursement - Damaged:Warehouse", i + 2, startPos);
                    startPos += 3;


                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'adjustment' and sku = '" + SKU + "' and [Description] = 'FBA Inventory Reimbursement - General Adjustment' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Корректирование", "FBA Inventory Reimbursement - General Adjustment", i + 2, startPos);
                    startPos += 3;

                    //----------------------------------------  TYPE: chargeback refund---------------------------------
                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'chargeback refund' and sku = '" + SKU + "' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Возврат платежа", "", i + 2, startPos);
                    startPos += 3;

                    //----------------------------------------  TYPE: order---------------------------------
                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'order' and sku = '" + SKU + "' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Продажи", "", i + 2, startPos);
                    startPos += 3;

                    //----------------------------------------  TYPE: refund---------------------------------
                    sqlSemanticsIds = "select sum(quantity), sum(total) from payments where [type] = 'refund' and sku = '" + SKU + "' and [date] = '" + workDate.ToString("yyyy-MM-dd") + "'";
                    command = new SqlCommand(sqlSemanticsIds, connection);
                    GetInfoBySKUFromDB(command, "Возвраты", "", i + 2, startPos);


                    workDate = workDate.AddDays(1);
                }

                workDate = start;
                dataGridView1.Columns.Add("TotalColumn", "Всего");

                int sumQuantity = 0;
                double sumTotal = 0;
                for (int j = 1; j < dataGridView1.RowCount - 1; j = j + 3)
                {
                    sumQuantity = 0;
                    sumTotal = 0;
                    for (int i = 2; i < dataGridView1.ColumnCount - 1; i++)
                    {
                        sumQuantity += int.Parse(dataGridView1.Rows[j].Cells[i].Value.ToString());        //quantity
                        sumTotal += double.Parse(dataGridView1.Rows[j + 1].Cells[i].Value.ToString());        //total
                    }
                    dataGridView1.Rows[j].Cells[dataGridView1.ColumnCount - 1].Value = sumQuantity;
                    dataGridView1.Rows[j + 1].Cells[dataGridView1.ColumnCount - 1].Value = sumTotal;
                }
            }
            
            //int sumQuantity = 0;
            //double sumTotal = 0;
            //for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            //{
            //    sumQuantity += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            //}
            //for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            //{
            //    sumTotal += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            //}
            //var index = dataGridView1.Rows.Add();
            //dataGridView1.Rows[index].Cells[0].Value = "Всего";
            //dataGridView1.Rows[index].Cells[2].Value = sumQuantity;
            //dataGridView1.Rows[index].Cells[3].Value = sumTotal;
            //dataGridView1.Rows.Add();
        }


        /* Выполняем запрос и пишем в dataGridView по SKU */
        private void GetInfoBySKUFromDB(SqlCommand command, string _type, string _desc, int _startCol, int _startRow)
        {
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetInfoBySKUToDataGrid((IDataRecord)reader, _type, _desc, _startCol, _startRow);
                    }
                }
                else
                {
                    //если строка з БД пустая, а нам всё равно нужно создать все строки при первом проходе
                    SetInfoBySKUToDataGrid(_type, _desc, _startCol, _startRow);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Пишем в dataGridView по SKU */
        private void SetInfoBySKUToDataGrid(IDataRecord record, string _type, string _desc, int _startCol, int _startRow)
        {
            if (_startCol - 2 == 0)        //при первом проходе создаем строки
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Rows[index].Cells[0].Value = _type;
                dataGridView1.Rows[index].Cells[1].Value = _desc;

                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Количество";                
                dataGridView1.Rows[index].Cells[_startCol].Value = record[0];

                if (dataGridView1.Rows[index].Cells[_startCol].Value.ToString().Equals(""))
                {
                    dataGridView1.Rows[index].Cells[_startCol].Value = 0;
                }

                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Всего";
                dataGridView1.Rows[index].Cells[_startCol].Value = record[1];

                if (dataGridView1.Rows[index].Cells[_startCol].Value.ToString().Equals(""))
                {
                    dataGridView1.Rows[index].Cells[_startCol].Value = 0;
                }

                if (!dataGridView1.Rows[index].Cells[_startCol].Value.ToString().Equals(""))
                {
                    try
                    {
                        dataGridView1.Rows[index].Cells[_startCol].Value = Math.Round(double.Parse(dataGridView1.Rows[index].Cells[_startCol].Value.ToString()), 2);
                    }
                    catch (Exception ex) { }
                }
            }
            else        //дальше идем уже без создания новых строк
            {
                dataGridView1.Rows[_startRow].Cells[_startCol].Value = record[0];

                if (dataGridView1.Rows[_startRow].Cells[_startCol].Value.ToString().Equals(""))
                {
                    dataGridView1.Rows[_startRow].Cells[_startCol].Value = 0;
                }

                dataGridView1.Rows[_startRow + 1].Cells[_startCol].Value = record[1];

                if (dataGridView1.Rows[_startRow + 1].Cells[_startCol].Value.ToString().Equals(""))
                {
                    dataGridView1.Rows[_startRow + 1].Cells[_startCol].Value = 0;
                }

                if (!dataGridView1.Rows[_startRow + 1].Cells[_startCol].Value.ToString().Equals(""))
                {
                    try
                    {
                        dataGridView1.Rows[_startRow + 1].Cells[_startCol].Value = Math.Round(double.Parse(dataGridView1.Rows[_startRow + 1].Cells[_startCol].Value.ToString()), 2);
                    }
                    catch (Exception ex) { }
                }
            }
        }

        /* Если строка из БД пустая. А нам нужно создать строки при первом проходе в dataGridView1 */
        private void SetInfoBySKUToDataGrid(string _type, string _desc, int _startCol, int _startRow)
        {
            if (_startCol - 2 == 0)        //при первом проходе создаем строки
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Rows[index].Cells[0].Value = _type;
                dataGridView1.Rows[index].Cells[1].Value = _desc;

                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Количество";

                if (dataGridView1.Rows[index].Cells[_startCol].Value == null)
                {
                    dataGridView1.Rows[index].Cells[_startCol].Value = 0;
                }

                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Всего";

                if (dataGridView1.Rows[index].Cells[_startCol].Value == null)
                {
                    dataGridView1.Rows[index].Cells[_startCol].Value = 0;
                }
            }
        }
        /* Получаем с БД инфу по Мarketplace и записываем её в dataGridView */
        private void showMarketPlacePnL()
        {
            string sqlSemanticsIds;
            SqlCommand command;
            dataGridView1.Rows.Clear();

            //----------------------------------------  TYPE: fba inventory fee---------------------------------
            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'fba inventory fee' and [Description] = 'FBA Inventory Storage Fee' and [date] between'" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "FBA inventory fee", "FBA Inventory Storage Fee");

            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'fba inventory fee' and [Description] = 'FBA Long-Term Storage Fee' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "FBA inventory fee", "FBA Long-Term Storage Fee");

            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'fba inventory fee' and [Description] = 'FBA Removal Order: Disposal Fee' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "FBA inventory fee", "FBA Removal Order: Disposal Fee");

            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'fba inventory fee' and [Description] = 'FBA Removal Order: Return Fee' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "FBA inventory fee", "FBA Removal Order: Return Fee");
            //----------------------------------------  TYPE: Lightning Deal Fee---------------------------------
            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'Lightning Deal Fee' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "Lightning Deal Fee", "");
            //----------------------------------------  TYPE: Service Fee---------------------------------
            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'Service Fee' and [Description] = 'Cost of Advertising' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "Service Fee", "Cost of Advertising");

            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'Service Fee' and [Description] = 'SellerPayments_Report_Fee_Subscription' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "Service Fee", "Seller Payments Report Fee Subscription");
            //----------------------------------------  TYPE: transfer---------------------------------
            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'transfer' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "Выплата", "");
            //----------------------------------------  TYPE: order retrocharge---------------------------------
            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'order retrocharge' and [Description] = 'Base Tax' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "Order retrocharge", "Base Tax");

            sqlSemanticsIds = "select sum(quantity), sum (total) from payments where [type] = 'order retrocharge' and [Description] = 'Shipping Tax' and [date] between '" + start.ToString("yyyy-MM-dd") + "' and '" + end.ToString("yyyy-MM-dd") + "'";
            command = new SqlCommand(sqlSemanticsIds, connection);
            //GetInfoBySKUFromDB(command, "Order retrocharge", "Shipping Tax");

            int sumQuantity = 0;
            double sumTotal = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                sumQuantity += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                sumTotal += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = "Всего";
            dataGridView1.Rows[index].Cells[2].Value = sumQuantity;
            dataGridView1.Rows[index].Cells[3].Value = sumTotal;
            dataGridView1.Rows.Add();
        }

        /* Закрытие формы */
        private void PnL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cp != null)
                cp.Close();
            else if (cMP != null)
                cMP.Close();
        }

        /* Запускаем отображение PnL */
        private void btn_ShowPnL_Click(object sender, EventArgs e)
        {
            //основной метод отображения PnL
            if (byASIN)
            {

            }
            else if (bySKU)
            {
                DrawTableColumns();
                showSKUPnL();
            }
            else if (byMarketplace)
            {
                showMarketPlacePnL();
            }
        }

        /* Показываем по дням */
        private void btn_ShowByDays_Click(object sender, EventArgs e)
        {
            showByDays = true;
            hideDaysButtons(true);
            showByWeeks = false;
            showByMonths = false;
        }

        /* Показываем по неделям */
        private void btn_ShowByWeeks_Click(object sender, EventArgs e)
        {
            showByDays = false;
            hideDaysButtons(false);
            showByWeeks = true;
            showByMonths = false;
        }

        /* Показываем по месяцам */
        private void btn_ShowByMonths_Click(object sender, EventArgs e)
        {
            showByDays = false;
            hideDaysButtons(false);
            showByWeeks = false;
            showByMonths = true;
        }

        /* Прячем/показываем кнопки по дням при смене типа отображения (по дням/неделям/годам) */
        private void hideDaysButtons(bool _value)
        {
            btn_Today.Visible = _value;
            btn_Yesterday.Visible = _value;
            btn_7daysPeriod.Visible = _value;
            btn_30daysPeriod.Visible = _value;
            btn_6monthsPeriod.Visible = _value;
            btn_1yearPeriod.Visible = _value;
        }

        /* Закрыть формы из меню */
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Экспорт PnL в Excel */
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            ExcelApp.Cells[1, 1] = "Тип";
            ExcelApp.Cells[1, 2] = "Описание";
            for (int i = 2; i < dataGridView1.ColumnCount; i++)
            {
                ExcelApp.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {

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
}
