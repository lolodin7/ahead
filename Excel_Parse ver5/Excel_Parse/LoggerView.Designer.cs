namespace Excel_Parse
{
    partial class LoggerView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggerView));
            this.dgv_Log = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AddRecord = new System.Windows.Forms.Button();
            this.cb_Users = new System.Windows.Forms.ComboBox();
            this.cb_Products = new System.Windows.Forms.ComboBox();
            this.mc_StartDate = new System.Windows.Forms.MonthCalendar();
            this.mc_EndDate = new System.Windows.Forms.MonthCalendar();
            this.btn_ChooseDate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_SKU = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_ASIN = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Log
            // 
            this.dgv_Log.AllowUserToAddRows = false;
            this.dgv_Log.AllowUserToDeleteRows = false;
            this.dgv_Log.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Log.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column9,
            this.Column7,
            this.Column10,
            this.Column11,
            this.Column2,
            this.Column3,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Log.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Log.Location = new System.Drawing.Point(5, 10);
            this.dgv_Log.MultiSelect = false;
            this.dgv_Log.Name = "dgv_Log";
            this.dgv_Log.ReadOnly = true;
            this.dgv_Log.RowTemplate.Height = 24;
            this.dgv_Log.Size = new System.Drawing.Size(1088, 692);
            this.dgv_Log.TabIndex = 0;
            this.dgv_Log.Visible = false;
            this.dgv_Log.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Log_CellDoubleClick);
            this.dgv_Log.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_Log_CellMouseMove);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "recordId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Дата";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 90;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Автор";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "productId";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Товар";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 230;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ASIN";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SKU";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Описание";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 405;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Маркетплейс";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 175;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(56, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "По";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(61, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "С";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(61, 622);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пользователь";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(83, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Товар";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_AddRecord
            // 
            this.btn_AddRecord.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_AddRecord.FlatAppearance.BorderSize = 0;
            this.btn_AddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddRecord.Location = new System.Drawing.Point(41, 45);
            this.btn_AddRecord.Name = "btn_AddRecord";
            this.btn_AddRecord.Size = new System.Drawing.Size(181, 86);
            this.btn_AddRecord.TabIndex = 4;
            this.btn_AddRecord.Text = "Добавить";
            this.btn_AddRecord.UseVisualStyleBackColor = false;
            this.btn_AddRecord.Click += new System.EventHandler(this.Btn_AddRecord_Click);
            // 
            // cb_Users
            // 
            this.cb_Users.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Users.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_Users.FormattingEnabled = true;
            this.cb_Users.Location = new System.Drawing.Point(19, 652);
            this.cb_Users.Name = "cb_Users";
            this.cb_Users.Size = new System.Drawing.Size(213, 25);
            this.cb_Users.TabIndex = 3;
            this.cb_Users.SelectedIndexChanged += new System.EventHandler(this.Cb_Users_SelectedIndexChanged);
            // 
            // cb_Products
            // 
            this.cb_Products.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_Products.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Products.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_Products.FormattingEnabled = true;
            this.cb_Products.Location = new System.Drawing.Point(19, 362);
            this.cb_Products.Name = "cb_Products";
            this.cb_Products.Size = new System.Drawing.Size(213, 25);
            this.cb_Products.TabIndex = 2;
            this.cb_Products.SelectedIndexChanged += new System.EventHandler(this.Cb_Products_SelectedIndexChanged);
            // 
            // mc_StartDate
            // 
            this.mc_StartDate.Location = new System.Drawing.Point(21, 36);
            this.mc_StartDate.MaxSelectionCount = 1;
            this.mc_StartDate.Name = "mc_StartDate";
            this.mc_StartDate.TabIndex = 10;
            this.mc_StartDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Mc_StartDate_DateChanged);
            // 
            // mc_EndDate
            // 
            this.mc_EndDate.Location = new System.Drawing.Point(21, 229);
            this.mc_EndDate.MaxSelectionCount = 1;
            this.mc_EndDate.Name = "mc_EndDate";
            this.mc_EndDate.TabIndex = 11;
            this.mc_EndDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Mc_EndDate_DateChanged);
            // 
            // btn_ChooseDate
            // 
            this.btn_ChooseDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ChooseDate.Location = new System.Drawing.Point(55, 203);
            this.btn_ChooseDate.Name = "btn_ChooseDate";
            this.btn_ChooseDate.Size = new System.Drawing.Size(150, 31);
            this.btn_ChooseDate.TabIndex = 8;
            this.btn_ChooseDate.Text = "Выбрать дату";
            this.btn_ChooseDate.UseVisualStyleBackColor = true;
            this.btn_ChooseDate.Click += new System.EventHandler(this.Btn_ChooseDate_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cb_SKU);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cb_ASIN);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lb_EndDate);
            this.panel2.Controls.Add(this.lb_StartDate);
            this.panel2.Controls.Add(this.cb_Products);
            this.panel2.Controls.Add(this.btn_ChooseDate);
            this.panel2.Controls.Add(this.btn_AddRecord);
            this.panel2.Controls.Add(this.cb_Users);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1123, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 695);
            this.panel2.TabIndex = 10;
            // 
            // cb_SKU
            // 
            this.cb_SKU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_SKU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_SKU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SKU.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_SKU.FormattingEnabled = true;
            this.cb_SKU.Location = new System.Drawing.Point(19, 558);
            this.cb_SKU.Name = "cb_SKU";
            this.cb_SKU.Size = new System.Drawing.Size(213, 25);
            this.cb_SKU.TabIndex = 17;
            this.cb_SKU.SelectedIndexChanged += new System.EventHandler(this.Cb_SKU_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(87, 529);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 31);
            this.label10.TabIndex = 18;
            this.label10.Text = "SKU";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_ASIN
            // 
            this.cb_ASIN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_ASIN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ASIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ASIN.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_ASIN.FormattingEnabled = true;
            this.cb_ASIN.Location = new System.Drawing.Point(19, 463);
            this.cb_ASIN.Name = "cb_ASIN";
            this.cb_ASIN.Size = new System.Drawing.Size(213, 25);
            this.cb_ASIN.TabIndex = 15;
            this.cb_ASIN.SelectedIndexChanged += new System.EventHandler(this.Cb_ASIN_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(86, 434);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 31);
            this.label9.TabIndex = 16;
            this.label9.Text = "ASIN";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(117, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "-";
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_EndDate.Location = new System.Drawing.Point(143, 256);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(76, 23);
            this.lb_EndDate.TabIndex = 10;
            this.lb_EndDate.Text = "05.05.2019";
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_StartDate.Location = new System.Drawing.Point(29, 256);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(87, 23);
            this.lb_StartDate.TabIndex = 9;
            this.lb_StartDate.Text = "05.05.2019";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mc_StartDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.mc_EndDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1143, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 421);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Logger";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(127, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(829, 211);
            this.label6.TabIndex = 13;
            this.label6.Text = "По выбранным данным записей не найдено";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 711);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_Log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoggerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logger - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoggerView_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.LoggerView_VisibleChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Log;
        private System.Windows.Forms.MonthCalendar mc_EndDate;
        private System.Windows.Forms.MonthCalendar mc_StartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddRecord;
        private System.Windows.Forms.ComboBox cb_Users;
        private System.Windows.Forms.ComboBox cb_Products;
        private System.Windows.Forms.Button btn_ChooseDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label lb_StartDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_SKU;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_ASIN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}