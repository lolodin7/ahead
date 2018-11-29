namespace Analytics
{
    partial class PnL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnL));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_DateEnd = new System.Windows.Forms.TextBox();
            this.tb_DateStart = new System.Windows.Forms.TextBox();
            this.monthCalendarEnd = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarStart = new System.Windows.Forms.MonthCalendar();
            this.btn_ChooseDate = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_7daysPeriod = new System.Windows.Forms.Button();
            this.btn_30daysPeriod = new System.Windows.Forms.Button();
            this.btn_6monthsPeriod = new System.Windows.Forms.Button();
            this.btn_1yearPeriod = new System.Windows.Forms.Button();
            this.btn_Today = new System.Windows.Forms.Button();
            this.btn_ShowPnL = new System.Windows.Forms.Button();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.btn_ShowByDays = new System.Windows.Forms.Button();
            this.btn_ShowByWeeks = new System.Windows.Forms.Button();
            this.btn_ShowByMonths = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_DateEnd);
            this.panel1.Controls.Add(this.tb_DateStart);
            this.panel1.Controls.Add(this.monthCalendarEnd);
            this.panel1.Controls.Add(this.monthCalendarStart);
            this.panel1.Location = new System.Drawing.Point(1021, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 199);
            this.panel1.TabIndex = 11;
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
            this.monthCalendarEnd.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
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
            this.monthCalendarStart.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.monthCalendarStart.Name = "monthCalendarStart";
            this.monthCalendarStart.ShowToday = false;
            this.monthCalendarStart.TabIndex = 0;
            this.monthCalendarStart.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStart_DateChanged);
            // 
            // btn_ChooseDate
            // 
            this.btn_ChooseDate.Location = new System.Drawing.Point(1146, 5);
            this.btn_ChooseDate.Name = "btn_ChooseDate";
            this.btn_ChooseDate.Size = new System.Drawing.Size(242, 22);
            this.btn_ChooseDate.TabIndex = 10;
            this.btn_ChooseDate.Text = "Выбор даты";
            this.btn_ChooseDate.UseVisualStyleBackColor = true;
            this.btn_ChooseDate.Click += new System.EventHandler(this.btn_ChooseDate_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(12, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(49, 29);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1385, 639);
            this.dataGridView1.TabIndex = 13;
            // 
            // btn_7daysPeriod
            // 
            this.btn_7daysPeriod.Location = new System.Drawing.Point(722, 5);
            this.btn_7daysPeriod.Name = "btn_7daysPeriod";
            this.btn_7daysPeriod.Size = new System.Drawing.Size(100, 29);
            this.btn_7daysPeriod.TabIndex = 14;
            this.btn_7daysPeriod.Text = "7 дней";
            this.btn_7daysPeriod.UseVisualStyleBackColor = true;
            this.btn_7daysPeriod.Click += new System.EventHandler(this.btn_7daysPeriod_Click);
            // 
            // btn_30daysPeriod
            // 
            this.btn_30daysPeriod.Location = new System.Drawing.Point(828, 4);
            this.btn_30daysPeriod.Name = "btn_30daysPeriod";
            this.btn_30daysPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_30daysPeriod.TabIndex = 15;
            this.btn_30daysPeriod.Text = "30 дней";
            this.btn_30daysPeriod.UseVisualStyleBackColor = true;
            this.btn_30daysPeriod.Click += new System.EventHandler(this.btn_30daysPeriod_Click);
            // 
            // btn_6monthsPeriod
            // 
            this.btn_6monthsPeriod.Location = new System.Drawing.Point(934, 4);
            this.btn_6monthsPeriod.Name = "btn_6monthsPeriod";
            this.btn_6monthsPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_6monthsPeriod.TabIndex = 16;
            this.btn_6monthsPeriod.Text = "6 месяцев";
            this.btn_6monthsPeriod.UseVisualStyleBackColor = true;
            this.btn_6monthsPeriod.Click += new System.EventHandler(this.btn_6monthsPeriod_Click);
            // 
            // btn_1yearPeriod
            // 
            this.btn_1yearPeriod.Location = new System.Drawing.Point(1040, 4);
            this.btn_1yearPeriod.Name = "btn_1yearPeriod";
            this.btn_1yearPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_1yearPeriod.TabIndex = 17;
            this.btn_1yearPeriod.Text = "Год";
            this.btn_1yearPeriod.UseVisualStyleBackColor = true;
            this.btn_1yearPeriod.Click += new System.EventHandler(this.btn_1yearPeriod_Click);
            // 
            // btn_Today
            // 
            this.btn_Today.Location = new System.Drawing.Point(616, 5);
            this.btn_Today.Name = "btn_Today";
            this.btn_Today.Size = new System.Drawing.Size(100, 30);
            this.btn_Today.TabIndex = 18;
            this.btn_Today.Text = "Сегодня";
            this.btn_Today.UseVisualStyleBackColor = true;
            this.btn_Today.Click += new System.EventHandler(this.btn_Today_Click);
            // 
            // btn_ShowPnL
            // 
            this.btn_ShowPnL.Location = new System.Drawing.Point(170, 5);
            this.btn_ShowPnL.Name = "btn_ShowPnL";
            this.btn_ShowPnL.Size = new System.Drawing.Size(105, 29);
            this.btn_ShowPnL.TabIndex = 19;
            this.btn_ShowPnL.Text = "Показать";
            this.btn_ShowPnL.UseVisualStyleBackColor = true;
            this.btn_ShowPnL.Click += new System.EventHandler(this.btn_ShowPnL_Click);
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.Location = new System.Drawing.Point(67, 5);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(97, 28);
            this.btn_ExportToExcel.TabIndex = 20;
            this.btn_ExportToExcel.Text = "Экспорт в Excel";
            this.btn_ExportToExcel.UseVisualStyleBackColor = true;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // btn_ShowByDays
            // 
            this.btn_ShowByDays.Location = new System.Drawing.Point(299, 4);
            this.btn_ShowByDays.Name = "btn_ShowByDays";
            this.btn_ShowByDays.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowByDays.TabIndex = 21;
            this.btn_ShowByDays.Text = "По дням";
            this.btn_ShowByDays.UseVisualStyleBackColor = true;
            // 
            // btn_ShowByWeeks
            // 
            this.btn_ShowByWeeks.Location = new System.Drawing.Point(380, 4);
            this.btn_ShowByWeeks.Name = "btn_ShowByWeeks";
            this.btn_ShowByWeeks.Size = new System.Drawing.Size(84, 23);
            this.btn_ShowByWeeks.TabIndex = 22;
            this.btn_ShowByWeeks.Text = "По неделям";
            this.btn_ShowByWeeks.UseVisualStyleBackColor = true;
            // 
            // btn_ShowByMonths
            // 
            this.btn_ShowByMonths.Location = new System.Drawing.Point(470, 4);
            this.btn_ShowByMonths.Name = "btn_ShowByMonths";
            this.btn_ShowByMonths.Size = new System.Drawing.Size(84, 23);
            this.btn_ShowByMonths.TabIndex = 23;
            this.btn_ShowByMonths.Text = "По месяцам";
            this.btn_ShowByMonths.UseVisualStyleBackColor = true;
            // 
            // PnL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 703);
            this.Controls.Add(this.btn_ShowByMonths);
            this.Controls.Add(this.btn_ShowByWeeks);
            this.Controls.Add(this.btn_ShowByDays);
            this.Controls.Add(this.btn_ExportToExcel);
            this.Controls.Add(this.btn_ShowPnL);
            this.Controls.Add(this.btn_Today);
            this.Controls.Add(this.btn_1yearPeriod);
            this.Controls.Add(this.btn_6monthsPeriod);
            this.Controls.Add(this.btn_30daysPeriod);
            this.Controls.Add(this.btn_7daysPeriod);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ChooseDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PnL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PnL_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_DateEnd;
        private System.Windows.Forms.TextBox tb_DateStart;
        private System.Windows.Forms.MonthCalendar monthCalendarEnd;
        private System.Windows.Forms.MonthCalendar monthCalendarStart;
        private System.Windows.Forms.Button btn_ChooseDate;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_7daysPeriod;
        private System.Windows.Forms.Button btn_30daysPeriod;
        private System.Windows.Forms.Button btn_6monthsPeriod;
        private System.Windows.Forms.Button btn_1yearPeriod;
        private System.Windows.Forms.Button btn_Today;
        private System.Windows.Forms.Button btn_ShowPnL;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.Button btn_ShowByDays;
        private System.Windows.Forms.Button btn_ShowByWeeks;
        private System.Windows.Forms.Button btn_ShowByMonths;
    }
}