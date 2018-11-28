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
        ChooseProduct cp;

        public PnL(ChooseProduct _cp, string _sku)
        {
            InitializeComponent();
            start = DateTime.Today;
            end = DateTime.Today;
            tb_DateStart.Text = start.ToString().Substring(0, 10);
            tb_DateEnd.Text = end.ToString().Substring(0, 10);
            btn_ChooseDate.Text = btn_ChooseDate.Text = start.ToString().Substring(0, 10) + " - " + end.ToString().Substring(0, 10);

            SKU = _sku;
            cp = _cp;
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
        #endregion
        //------------------------------------------------DatePicker REGION END-----------------------------------------------------------------

    }
}
