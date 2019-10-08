﻿namespace Excel_Parse
{
    partial class ReportSessionsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSessionsView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Daily = new System.Windows.Forms.Button();
            this.btn_Monthly = new System.Windows.Forms.Button();
            this.btn_Weekly = new System.Windows.Forms.Button();
            this.btn_Clear_clb_Marketplace = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Show = new System.Windows.Forms.Button();
            this.clb_Marketplace = new System.Windows.Forms.CheckedListBox();
            this.mc_EndDate = new System.Windows.Forms.MonthCalendar();
            this.mc_StartDate = new System.Windows.Forms.MonthCalendar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_Customly = new System.Windows.Forms.Button();
            this.cb_Products = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_SKUText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lb_SKUText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_Products);
            this.groupBox1.Controls.Add(this.btn_Customly);
            this.groupBox1.Controls.Add(this.btn_Export);
            this.groupBox1.Controls.Add(this.btn_Daily);
            this.groupBox1.Controls.Add(this.btn_Monthly);
            this.groupBox1.Controls.Add(this.btn_Weekly);
            this.groupBox1.Controls.Add(this.btn_Clear_clb_Marketplace);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lb_StartDate);
            this.groupBox1.Controls.Add(this.lb_EndDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Show);
            this.groupBox1.Controls.Add(this.clb_Marketplace);
            this.groupBox1.Controls.Add(this.mc_EndDate);
            this.groupBox1.Controls.Add(this.mc_StartDate);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1306, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Export.Location = new System.Drawing.Point(1106, 19);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(194, 27);
            this.btn_Export.TabIndex = 94;
            this.btn_Export.Text = "Экспорт";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Daily
            // 
            this.btn_Daily.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Daily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Daily.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Daily.Location = new System.Drawing.Point(412, 42);
            this.btn_Daily.Name = "btn_Daily";
            this.btn_Daily.Size = new System.Drawing.Size(119, 27);
            this.btn_Daily.TabIndex = 93;
            this.btn_Daily.Text = "По дням";
            this.btn_Daily.UseVisualStyleBackColor = false;
            this.btn_Daily.Click += new System.EventHandler(this.btn_Daily_Click);
            // 
            // btn_Monthly
            // 
            this.btn_Monthly.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Monthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Monthly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Monthly.Location = new System.Drawing.Point(412, 135);
            this.btn_Monthly.Name = "btn_Monthly";
            this.btn_Monthly.Size = new System.Drawing.Size(119, 27);
            this.btn_Monthly.TabIndex = 91;
            this.btn_Monthly.Text = "По месяцам";
            this.btn_Monthly.UseVisualStyleBackColor = false;
            this.btn_Monthly.Click += new System.EventHandler(this.btn_Monthly_Click);
            // 
            // btn_Weekly
            // 
            this.btn_Weekly.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Weekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Weekly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Weekly.Location = new System.Drawing.Point(412, 88);
            this.btn_Weekly.Name = "btn_Weekly";
            this.btn_Weekly.Size = new System.Drawing.Size(119, 27);
            this.btn_Weekly.TabIndex = 90;
            this.btn_Weekly.Text = "По неделям";
            this.btn_Weekly.UseVisualStyleBackColor = false;
            this.btn_Weekly.Click += new System.EventHandler(this.btn_Weekly_Click);
            // 
            // btn_Clear_clb_Marketplace
            // 
            this.btn_Clear_clb_Marketplace.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold);
            this.btn_Clear_clb_Marketplace.Location = new System.Drawing.Point(761, 19);
            this.btn_Clear_clb_Marketplace.Name = "btn_Clear_clb_Marketplace";
            this.btn_Clear_clb_Marketplace.Size = new System.Drawing.Size(27, 21);
            this.btn_Clear_clb_Marketplace.TabIndex = 89;
            this.btn_Clear_clb_Marketplace.Text = "-";
            this.btn_Clear_clb_Marketplace.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Clear_clb_Marketplace.UseVisualStyleBackColor = true;
            this.btn_Clear_clb_Marketplace.Click += new System.EventHandler(this.btn_Clear_clb_Marketplace_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(197, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 29);
            this.label5.TabIndex = 88;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_StartDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_StartDate.Location = new System.Drawing.Point(75, 12);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(120, 29);
            this.lb_StartDate.TabIndex = 87;
            this.lb_StartDate.Text = "lb_StartDate";
            this.lb_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_EndDate.Location = new System.Drawing.Point(212, 12);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(119, 29);
            this.lb_EndDate.TabIndex = 86;
            this.lb_EndDate.Text = "lb_EndDate";
            this.lb_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(594, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 23);
            this.label3.TabIndex = 85;
            this.label3.Text = "Маркетплейсы";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Show
            // 
            this.btn_Show.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_Show.FlatAppearance.BorderSize = 0;
            this.btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Show.Location = new System.Drawing.Point(1106, 119);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(194, 92);
            this.btn_Show.TabIndex = 84;
            this.btn_Show.Text = "Применить фильтр";
            this.btn_Show.UseVisualStyleBackColor = false;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // clb_Marketplace
            // 
            this.clb_Marketplace.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Marketplace.CheckOnClick = true;
            this.clb_Marketplace.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.clb_Marketplace.FormattingEnabled = true;
            this.clb_Marketplace.Location = new System.Drawing.Point(594, 45);
            this.clb_Marketplace.Name = "clb_Marketplace";
            this.clb_Marketplace.Size = new System.Drawing.Size(194, 166);
            this.clb_Marketplace.TabIndex = 81;
            this.clb_Marketplace.SelectedIndexChanged += new System.EventHandler(this.clb_Marketplace_SelectedIndexChanged);
            // 
            // mc_EndDate
            // 
            this.mc_EndDate.BackColor = System.Drawing.SystemColors.Control;
            this.mc_EndDate.Location = new System.Drawing.Point(212, 42);
            this.mc_EndDate.MaxSelectionCount = 1;
            this.mc_EndDate.Name = "mc_EndDate";
            this.mc_EndDate.ShowToday = false;
            this.mc_EndDate.ShowWeekNumbers = true;
            this.mc_EndDate.TabIndex = 82;
            this.mc_EndDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_EndDate_DateChanged);
            // 
            // mc_StartDate
            // 
            this.mc_StartDate.BackColor = System.Drawing.SystemColors.Control;
            this.mc_StartDate.Location = new System.Drawing.Point(7, 42);
            this.mc_StartDate.MaxSelectionCount = 1;
            this.mc_StartDate.Name = "mc_StartDate";
            this.mc_StartDate.ShowToday = false;
            this.mc_StartDate.ShowWeekNumbers = true;
            this.mc_StartDate.TabIndex = 83;
            this.mc_StartDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_StartDate_DateChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1306, 422);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_Customly
            // 
            this.btn_Customly.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Customly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Customly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Customly.Location = new System.Drawing.Point(412, 184);
            this.btn_Customly.Name = "btn_Customly";
            this.btn_Customly.Size = new System.Drawing.Size(119, 27);
            this.btn_Customly.TabIndex = 95;
            this.btn_Customly.Text = "Выбрать даты";
            this.btn_Customly.UseVisualStyleBackColor = false;
            this.btn_Customly.Click += new System.EventHandler(this.btn_Customly_Click);
            // 
            // cb_Products
            // 
            this.cb_Products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Products.FormattingEnabled = true;
            this.cb_Products.Location = new System.Drawing.Point(827, 45);
            this.cb_Products.Name = "cb_Products";
            this.cb_Products.Size = new System.Drawing.Size(218, 25);
            this.cb_Products.TabIndex = 96;
            this.cb_Products.SelectedIndexChanged += new System.EventHandler(this.cb_Products_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(827, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 97;
            this.label1.Text = "Товар";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_SKUText
            // 
            this.lb_SKUText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_SKUText.Location = new System.Drawing.Point(827, 73);
            this.lb_SKUText.Name = "lb_SKUText";
            this.lb_SKUText.Size = new System.Drawing.Size(218, 23);
            this.lb_SKUText.TabIndex = 98;
            this.lb_SKUText.Text = "SKU: ";
            this.lb_SKUText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReportSessionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 641);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportSessionsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные сессий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportSessionsView_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Daily;
        private System.Windows.Forms.Button btn_Monthly;
        private System.Windows.Forms.Button btn_Weekly;
        private System.Windows.Forms.Button btn_Clear_clb_Marketplace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_StartDate;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.CheckedListBox clb_Marketplace;
        private System.Windows.Forms.MonthCalendar mc_EndDate;
        private System.Windows.Forms.MonthCalendar mc_StartDate;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_Customly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Products;
        private System.Windows.Forms.Label lb_SKUText;
    }
}