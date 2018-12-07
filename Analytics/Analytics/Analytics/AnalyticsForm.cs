using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using Excel_Parse;

namespace Analytics
{
    public partial class AnalyticsForm : Form
    {
        private PaymentsController paymentsController;
        private OrdersController ordersController;
        private ShipmentsController shipmentsController;
        private CustomerReturnsController customerReturnsController;

        private DateTime start;         
        private DateTime end;

        public AnalyticsForm()
        {
            InitializeComponent();
            paymentsController = new PaymentsController(this);
            ordersController = new OrdersController(this);
            shipmentsController = new ShipmentsController(this);
            customerReturnsController = new CustomerReturnsController(this);

            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);
        }


        //-------ORDERS---------
        private void GetNewReportsFromFileOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordersController.GetOrdersFromExcel(false);
        }

        private void UpdateReportsInDBOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordersController.UpdateOrdersInDB();
        }

        //-------SHIPMENTS--------
        private void GetNewReportsFromFileShipmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            shipmentsController.GetShipmentsFromExcel();
        }

        private void UpdateReportsInDBShipmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            shipmentsController.UpdateShipmentsInDB();
        }

        //-------PAYMENTS--------
        private void GetNewReportsFromFilePaymentsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            paymentsController.GetPaymentsFromExcel();
        }

        private void UpdateReportsInDBPaymentsToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        //-------REFUNDS--------


        private void GetNewReportsFromFileRefundsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            customerReturnsController.GetCustomerReturnsFromExcel(false);
        }

        private void UpdateReportsInDBRefundsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            customerReturnsController.UpdateCustomerReturnsInDB();
        }

        private void GetCustomerReturnsByDateRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerReturnsController.GetCustomerReturnsByDateRange(start, end);
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
                    } catch (Exception ex) { MessageBox.Show("При вводе данных была допущена ошибка!", "Ошибка"); }
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
        #endregion
        //------------------------------------------------DatePicker REGION END-----------------------------------------------------------------


        /* Закрываем приложение, убивая процесс */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void bySKUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseProduct cp = new ChooseProduct(this, "sku");
            cp.Show();
            this.Visible = false;
        }

        private void byASINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseProduct cp = new ChooseProduct(this, "asin");
            cp.Show();
            this.Visible = false;
        }

        private void byMarketplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseMP cp = new ChooseMP(this);
            cp.Show();
            this.Visible = false;
        }
    }
}