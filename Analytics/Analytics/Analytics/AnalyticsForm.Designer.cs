﻿namespace Analytics
{
    partial class AnalyticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyticsForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetNewReportsFromFileOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateReportsInDBOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetNewReportsFromFileShipmentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateReportsInDBShipmentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetNewReportsFromFilePaymentsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateReportsInDBPaymentsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.refundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetNewReportsFromFileRefundsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateReportsInDBRefundsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.GetCustomerReturnsByDateRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bySKUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byASINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byMarketplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ChooseDate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_DateEnd = new System.Windows.Forms.TextBox();
            this.tb_DateStart = new System.Windows.Forms.TextBox();
            this.monthCalendarEnd = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarStart = new System.Windows.Forms.MonthCalendar();
            this.lb_StatusText = new System.Windows.Forms.Label();
            this.btn_GetDates = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(139, 154);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(351, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.shipmentsToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.refundsToolStripMenuItem,
            this.serviceToolStripMenuItem,
            this.pnLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetNewReportsFromFileOrdersToolStripMenuItem,
            this.UpdateReportsInDBOrdersToolStripMenuItem});
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ordersToolStripMenuItem.Text = "Orders";
            // 
            // GetNewReportsFromFileOrdersToolStripMenuItem
            // 
            this.GetNewReportsFromFileOrdersToolStripMenuItem.Name = "GetNewReportsFromFileOrdersToolStripMenuItem";
            this.GetNewReportsFromFileOrdersToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.GetNewReportsFromFileOrdersToolStripMenuItem.Text = "Загрузить первичные данные из файла";
            this.GetNewReportsFromFileOrdersToolStripMenuItem.Click += new System.EventHandler(this.GetNewReportsFromFileOrdersToolStripMenuItem_Click);
            // 
            // UpdateReportsInDBOrdersToolStripMenuItem
            // 
            this.UpdateReportsInDBOrdersToolStripMenuItem.Name = "UpdateReportsInDBOrdersToolStripMenuItem";
            this.UpdateReportsInDBOrdersToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.UpdateReportsInDBOrdersToolStripMenuItem.Text = "Обновить данные из файла";
            this.UpdateReportsInDBOrdersToolStripMenuItem.Click += new System.EventHandler(this.UpdateReportsInDBOrdersToolStripMenuItem_Click);
            // 
            // shipmentsToolStripMenuItem
            // 
            this.shipmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetNewReportsFromFileShipmentsToolStripMenuItem1,
            this.UpdateReportsInDBShipmentsToolStripMenuItem1});
            this.shipmentsToolStripMenuItem.Name = "shipmentsToolStripMenuItem";
            this.shipmentsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.shipmentsToolStripMenuItem.Text = "Shipments";
            // 
            // GetNewReportsFromFileShipmentsToolStripMenuItem1
            // 
            this.GetNewReportsFromFileShipmentsToolStripMenuItem1.Name = "GetNewReportsFromFileShipmentsToolStripMenuItem1";
            this.GetNewReportsFromFileShipmentsToolStripMenuItem1.Size = new System.Drawing.Size(290, 22);
            this.GetNewReportsFromFileShipmentsToolStripMenuItem1.Text = "Загрузить первичные данные из файла";
            this.GetNewReportsFromFileShipmentsToolStripMenuItem1.Click += new System.EventHandler(this.GetNewReportsFromFileShipmentsToolStripMenuItem1_Click);
            // 
            // UpdateReportsInDBShipmentsToolStripMenuItem1
            // 
            this.UpdateReportsInDBShipmentsToolStripMenuItem1.Name = "UpdateReportsInDBShipmentsToolStripMenuItem1";
            this.UpdateReportsInDBShipmentsToolStripMenuItem1.Size = new System.Drawing.Size(290, 22);
            this.UpdateReportsInDBShipmentsToolStripMenuItem1.Text = "Обновить данные из файла";
            this.UpdateReportsInDBShipmentsToolStripMenuItem1.Click += new System.EventHandler(this.UpdateReportsInDBShipmentsToolStripMenuItem1_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetNewReportsFromFilePaymentsToolStripMenuItem2,
            this.UpdateReportsInDBPaymentsToolStripMenuItem2});
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // GetNewReportsFromFilePaymentsToolStripMenuItem2
            // 
            this.GetNewReportsFromFilePaymentsToolStripMenuItem2.Name = "GetNewReportsFromFilePaymentsToolStripMenuItem2";
            this.GetNewReportsFromFilePaymentsToolStripMenuItem2.Size = new System.Drawing.Size(290, 22);
            this.GetNewReportsFromFilePaymentsToolStripMenuItem2.Text = "Загрузить первичные данные из файла";
            this.GetNewReportsFromFilePaymentsToolStripMenuItem2.Click += new System.EventHandler(this.GetNewReportsFromFilePaymentsToolStripMenuItem2_Click);
            // 
            // UpdateReportsInDBPaymentsToolStripMenuItem2
            // 
            this.UpdateReportsInDBPaymentsToolStripMenuItem2.Name = "UpdateReportsInDBPaymentsToolStripMenuItem2";
            this.UpdateReportsInDBPaymentsToolStripMenuItem2.Size = new System.Drawing.Size(290, 22);
            this.UpdateReportsInDBPaymentsToolStripMenuItem2.Text = "Обновить данные из файла";
            this.UpdateReportsInDBPaymentsToolStripMenuItem2.Click += new System.EventHandler(this.UpdateReportsInDBPaymentsToolStripMenuItem2_Click);
            // 
            // refundsToolStripMenuItem
            // 
            this.refundsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetNewReportsFromFileRefundsToolStripMenuItem3,
            this.UpdateReportsInDBRefundsToolStripMenuItem3,
            this.GetCustomerReturnsByDateRangeToolStripMenuItem});
            this.refundsToolStripMenuItem.Name = "refundsToolStripMenuItem";
            this.refundsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.refundsToolStripMenuItem.Text = "Returns";
            // 
            // GetNewReportsFromFileRefundsToolStripMenuItem3
            // 
            this.GetNewReportsFromFileRefundsToolStripMenuItem3.Name = "GetNewReportsFromFileRefundsToolStripMenuItem3";
            this.GetNewReportsFromFileRefundsToolStripMenuItem3.Size = new System.Drawing.Size(290, 22);
            this.GetNewReportsFromFileRefundsToolStripMenuItem3.Text = "Загрузить первичные данные из файла";
            this.GetNewReportsFromFileRefundsToolStripMenuItem3.Click += new System.EventHandler(this.GetNewReportsFromFileRefundsToolStripMenuItem3_Click);
            // 
            // UpdateReportsInDBRefundsToolStripMenuItem3
            // 
            this.UpdateReportsInDBRefundsToolStripMenuItem3.Name = "UpdateReportsInDBRefundsToolStripMenuItem3";
            this.UpdateReportsInDBRefundsToolStripMenuItem3.Size = new System.Drawing.Size(290, 22);
            this.UpdateReportsInDBRefundsToolStripMenuItem3.Text = "Обновить данные из файла";
            this.UpdateReportsInDBRefundsToolStripMenuItem3.Click += new System.EventHandler(this.UpdateReportsInDBRefundsToolStripMenuItem3_Click);
            // 
            // GetCustomerReturnsByDateRangeToolStripMenuItem
            // 
            this.GetCustomerReturnsByDateRangeToolStripMenuItem.Name = "GetCustomerReturnsByDateRangeToolStripMenuItem";
            this.GetCustomerReturnsByDateRangeToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.GetCustomerReturnsByDateRangeToolStripMenuItem.Text = "Показать запросы по дате";
            this.GetCustomerReturnsByDateRangeToolStripMenuItem.Click += new System.EventHandler(this.GetCustomerReturnsByDateRangeToolStripMenuItem_Click);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.serviceToolStripMenuItem.Text = "Сервис";
            // 
            // pnLToolStripMenuItem
            // 
            this.pnLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bySKUToolStripMenuItem,
            this.byASINToolStripMenuItem,
            this.byMarketplaceToolStripMenuItem});
            this.pnLToolStripMenuItem.Name = "pnLToolStripMenuItem";
            this.pnLToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.pnLToolStripMenuItem.Text = "PnL";
            // 
            // bySKUToolStripMenuItem
            // 
            this.bySKUToolStripMenuItem.Name = "bySKUToolStripMenuItem";
            this.bySKUToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.bySKUToolStripMenuItem.Text = "По SKU";
            this.bySKUToolStripMenuItem.Click += new System.EventHandler(this.bySKUToolStripMenuItem_Click);
            // 
            // byASINToolStripMenuItem
            // 
            this.byASINToolStripMenuItem.Name = "byASINToolStripMenuItem";
            this.byASINToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.byASINToolStripMenuItem.Text = "По ASIN";
            this.byASINToolStripMenuItem.Visible = false;
            this.byASINToolStripMenuItem.Click += new System.EventHandler(this.byASINToolStripMenuItem_Click);
            // 
            // byMarketplaceToolStripMenuItem
            // 
            this.byMarketplaceToolStripMenuItem.Name = "byMarketplaceToolStripMenuItem";
            this.byMarketplaceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.byMarketplaceToolStripMenuItem.Text = "По Marketplace";
            this.byMarketplaceToolStripMenuItem.Click += new System.EventHandler(this.byMarketplaceToolStripMenuItem_Click);
            // 
            // btn_ChooseDate
            // 
            this.btn_ChooseDate.Location = new System.Drawing.Point(13, 28);
            this.btn_ChooseDate.Name = "btn_ChooseDate";
            this.btn_ChooseDate.Size = new System.Drawing.Size(367, 22);
            this.btn_ChooseDate.TabIndex = 8;
            this.btn_ChooseDate.Text = "Выбор даты";
            this.btn_ChooseDate.UseVisualStyleBackColor = true;
            this.btn_ChooseDate.Click += new System.EventHandler(this.btn_ChooseDate_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_DateEnd);
            this.panel1.Controls.Add(this.tb_DateStart);
            this.panel1.Controls.Add(this.monthCalendarEnd);
            this.panel1.Controls.Add(this.monthCalendarStart);
            this.panel1.Location = new System.Drawing.Point(15, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 199);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // tb_DateEnd
            // 
            this.tb_DateEnd.Location = new System.Drawing.Point(194, 4);
            this.tb_DateEnd.Name = "tb_DateEnd";
            this.tb_DateEnd.Size = new System.Drawing.Size(165, 20);
            this.tb_DateEnd.TabIndex = 4;
            this.tb_DateEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_DateEnd_KeyPress);
            // 
            // tb_DateStart
            // 
            this.tb_DateStart.Location = new System.Drawing.Point(4, 4);
            this.tb_DateStart.Name = "tb_DateStart";
            this.tb_DateStart.Size = new System.Drawing.Size(165, 20);
            this.tb_DateStart.TabIndex = 3;
            this.tb_DateStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_DateStart_KeyPress);
            // 
            // monthCalendarEnd
            // 
            this.monthCalendarEnd.Location = new System.Drawing.Point(195, 31);
            this.monthCalendarEnd.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.monthCalendarEnd.MaxSelectionCount = 1;
            this.monthCalendarEnd.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.monthCalendarEnd.Name = "monthCalendarEnd";
            this.monthCalendarEnd.ShowToday = false;
            this.monthCalendarEnd.TabIndex = 1;
            this.monthCalendarEnd.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarEnd_DateChanged);
            // 
            // monthCalendarStart
            // 
            this.monthCalendarStart.Location = new System.Drawing.Point(4, 31);
            this.monthCalendarStart.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.monthCalendarStart.MaxSelectionCount = 1;
            this.monthCalendarStart.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.monthCalendarStart.Name = "monthCalendarStart";
            this.monthCalendarStart.ShowToday = false;
            this.monthCalendarStart.TabIndex = 0;
            this.monthCalendarStart.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStart_DateChanged);
            // 
            // lb_StatusText
            // 
            this.lb_StatusText.Location = new System.Drawing.Point(12, 154);
            this.lb_StatusText.Name = "lb_StatusText";
            this.lb_StatusText.Size = new System.Drawing.Size(121, 23);
            this.lb_StatusText.TabIndex = 10;
            this.lb_StatusText.Text = "label1";
            this.lb_StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_StatusText.Visible = false;
            // 
            // btn_GetDates
            // 
            this.btn_GetDates.Location = new System.Drawing.Point(653, 88);
            this.btn_GetDates.Name = "btn_GetDates";
            this.btn_GetDates.Size = new System.Drawing.Size(225, 89);
            this.btn_GetDates.TabIndex = 11;
            this.btn_GetDates.Text = "Сверить даты ордеров и возвратов";
            this.btn_GetDates.UseVisualStyleBackColor = true;
            this.btn_GetDates.Click += new System.EventHandler(this.btn_GetDates_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 63);
            this.button1.TabIndex = 12;
            this.button1.Text = "Сопоставить ордера с остальной инфой";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AnalyticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_GetDates);
            this.Controls.Add(this.lb_StatusText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ChooseDate);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnalyticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитика";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetNewReportsFromFileOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateReportsInDBOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetNewReportsFromFileShipmentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem UpdateReportsInDBShipmentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem GetNewReportsFromFilePaymentsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem UpdateReportsInDBPaymentsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem GetNewReportsFromFileRefundsToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem UpdateReportsInDBRefundsToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btn_ChooseDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar monthCalendarEnd;
        private System.Windows.Forms.MonthCalendar monthCalendarStart;
        private System.Windows.Forms.TextBox tb_DateEnd;
        private System.Windows.Forms.TextBox tb_DateStart;
        private System.Windows.Forms.ToolStripMenuItem GetCustomerReturnsByDateRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pnLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bySKUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byASINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byMarketplaceToolStripMenuItem;
        public System.Windows.Forms.Label lb_StatusText;
        private System.Windows.Forms.Button btn_GetDates;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

