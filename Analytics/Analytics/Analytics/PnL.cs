using Excel_Parse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytics
{
    public partial class PnL : Form
    {
        private DateTime start;
        private DateTime end;
        private string SKU;
        private string ASIN;
        private string Marketplace;
        ChooseProduct cp;

        private bool bySKU;
        private bool byASIN;
        private bool byMarketplace;

        public PnL(ChooseProduct _cp, string _sku)
        {
            InitializeComponent();
            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            bySKU = true;
            SKU = _sku;
            cp = _cp;
            this.Text = this.Text + " - SKU: " + SKU;
        }

        public PnL(string _asin, ChooseProduct _cp)
        {
            InitializeComponent();
            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            byASIN = true;
            ASIN = _asin;
            cp = _cp;
            this.Text = this.Text + " - ASIN: " + ASIN;
        }

        public PnL(ChooseProduct _cp, string _marketplace, int _marketplaceId)
        {
            InitializeComponent();
            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            byMarketplace = true;
            Marketplace = _marketplace;
            cp = _cp;
            this.Text = this.Text + " - Marketplace: " + Marketplace;
        }

        private void fillDGVHeaders()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            CustomerReturnsModel crm = new CustomerReturnsModel();
            for (int i = 0; i < crm.dgvColumnsHeadersText.Length; i++)
            {
                dataGridView1.Columns.Add(crm.dgvColumnsHeadersText[i], crm.dgvColumnsHeadersText[i]);
            }
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PnL_FormClosing(object sender, FormClosingEventArgs e)
        {
            cp.Close();
        }

        /* Выбираем период за 7 дней */
        private void btn_7daysPeriod_Click(object sender, EventArgs e)
        {
            int dayCnt = 7;
            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - dayCnt);
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
                            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1) + DateTime.Now.Day) - dayCnt);
                            start = dt;
                            monthCalendarStart.SelectionStart = start;
                            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                        }
                        catch (Exception exx)
                        {
                            if (ex.HResult == -2146233086)
                            {
                                DateTime dt = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month + 12 - 1, (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 12 - 1) + DateTime.Now.Day) - dayCnt);
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
            int dayCnt = 30;
            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - dayCnt);
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
                            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1) + DateTime.Now.Day) - dayCnt);
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
            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 6, DateTime.Now.Day);
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
                            DateTime dt = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month + 12 - 6, DateTime.Now.Day);
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
            if ((start.Year - 1) > 2000)
            {
                try
                {
                    DateTime dt = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
                    start = dt;
                    monthCalendarStart.SelectionStart = start;
                    btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
                }
                catch (Exception ex) { }
            }
        }

        private void btn_Today_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            start = dt;
            monthCalendarStart.SelectionStart = start;
            btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
        }
        #endregion
        //------------------------------------------------DatePicker REGION END-----------------------------------------------------------------

        private void btn_ShowPnL_Click(object sender, EventArgs e)
        {
            //основной метод отображения PnL
        }

        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
