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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_7daysPeriod = new System.Windows.Forms.Button();
            this.btn_30daysPeriod = new System.Windows.Forms.Button();
            this.btn_6monthsPeriod = new System.Windows.Forms.Button();
            this.btn_1yearPeriod = new System.Windows.Forms.Button();
            this.btn_Today = new System.Windows.Forms.Button();
            this.btn_ShowPnL = new System.Windows.Forms.Button();
            this.btn_ShowByDays = new System.Windows.Forms.Button();
            this.btn_ShowByWeeks = new System.Windows.Forms.Button();
            this.btn_ShowByMonths = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Yesterday = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_DateEnd);
            this.panel1.Controls.Add(this.tb_DateStart);
            this.panel1.Controls.Add(this.monthCalendarEnd);
            this.panel1.Controls.Add(this.monthCalendarStart);
            this.panel1.Location = new System.Drawing.Point(1021, 64);
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
            this.btn_ChooseDate.Location = new System.Drawing.Point(1146, 34);
            this.btn_ChooseDate.Name = "btn_ChooseDate";
            this.btn_ChooseDate.Size = new System.Drawing.Size(242, 22);
            this.btn_ChooseDate.TabIndex = 10;
            this.btn_ChooseDate.Text = "Выбор даты";
            this.btn_ChooseDate.UseVisualStyleBackColor = true;
            this.btn_ChooseDate.Click += new System.EventHandler(this.btn_ChooseDate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1385, 574);
            this.dataGridView1.TabIndex = 13;
            // 
            // btn_7daysPeriod
            // 
            this.btn_7daysPeriod.BackColor = System.Drawing.Color.LightGray;
            this.btn_7daysPeriod.FlatAppearance.BorderSize = 0;
            this.btn_7daysPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_7daysPeriod.Location = new System.Drawing.Point(520, 70);
            this.btn_7daysPeriod.Name = "btn_7daysPeriod";
            this.btn_7daysPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_7daysPeriod.TabIndex = 14;
            this.btn_7daysPeriod.Text = "7 дней";
            this.btn_7daysPeriod.UseVisualStyleBackColor = false;
            this.btn_7daysPeriod.Click += new System.EventHandler(this.btn_7daysPeriod_Click);
            // 
            // btn_30daysPeriod
            // 
            this.btn_30daysPeriod.BackColor = System.Drawing.Color.LightGray;
            this.btn_30daysPeriod.FlatAppearance.BorderSize = 0;
            this.btn_30daysPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_30daysPeriod.Location = new System.Drawing.Point(626, 70);
            this.btn_30daysPeriod.Name = "btn_30daysPeriod";
            this.btn_30daysPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_30daysPeriod.TabIndex = 15;
            this.btn_30daysPeriod.Text = "30 дней";
            this.btn_30daysPeriod.UseVisualStyleBackColor = false;
            this.btn_30daysPeriod.Click += new System.EventHandler(this.btn_30daysPeriod_Click);
            // 
            // btn_6monthsPeriod
            // 
            this.btn_6monthsPeriod.BackColor = System.Drawing.Color.LightGray;
            this.btn_6monthsPeriod.FlatAppearance.BorderSize = 0;
            this.btn_6monthsPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_6monthsPeriod.Location = new System.Drawing.Point(732, 70);
            this.btn_6monthsPeriod.Name = "btn_6monthsPeriod";
            this.btn_6monthsPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_6monthsPeriod.TabIndex = 16;
            this.btn_6monthsPeriod.Text = "6 месяцев";
            this.btn_6monthsPeriod.UseVisualStyleBackColor = false;
            this.btn_6monthsPeriod.Click += new System.EventHandler(this.btn_6monthsPeriod_Click);
            // 
            // btn_1yearPeriod
            // 
            this.btn_1yearPeriod.BackColor = System.Drawing.Color.LightGray;
            this.btn_1yearPeriod.FlatAppearance.BorderSize = 0;
            this.btn_1yearPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1yearPeriod.Location = new System.Drawing.Point(838, 70);
            this.btn_1yearPeriod.Name = "btn_1yearPeriod";
            this.btn_1yearPeriod.Size = new System.Drawing.Size(100, 30);
            this.btn_1yearPeriod.TabIndex = 17;
            this.btn_1yearPeriod.Text = "Год";
            this.btn_1yearPeriod.UseVisualStyleBackColor = false;
            this.btn_1yearPeriod.Click += new System.EventHandler(this.btn_1yearPeriod_Click);
            // 
            // btn_Today
            // 
            this.btn_Today.BackColor = System.Drawing.Color.LightGray;
            this.btn_Today.FlatAppearance.BorderSize = 0;
            this.btn_Today.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Today.Location = new System.Drawing.Point(308, 69);
            this.btn_Today.Name = "btn_Today";
            this.btn_Today.Size = new System.Drawing.Size(100, 30);
            this.btn_Today.TabIndex = 18;
            this.btn_Today.Text = "Сегодня";
            this.btn_Today.UseVisualStyleBackColor = false;
            this.btn_Today.Click += new System.EventHandler(this.btn_Today_Click);
            // 
            // btn_ShowPnL
            // 
            this.btn_ShowPnL.BackColor = System.Drawing.Color.LightGray;
            this.btn_ShowPnL.FlatAppearance.BorderSize = 0;
            this.btn_ShowPnL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowPnL.Location = new System.Drawing.Point(939, 30);
            this.btn_ShowPnL.Name = "btn_ShowPnL";
            this.btn_ShowPnL.Size = new System.Drawing.Size(186, 33);
            this.btn_ShowPnL.TabIndex = 19;
            this.btn_ShowPnL.Text = "Показать";
            this.btn_ShowPnL.UseVisualStyleBackColor = false;
            this.btn_ShowPnL.Click += new System.EventHandler(this.btn_ShowPnL_Click);
            // 
            // btn_ShowByDays
            // 
            this.btn_ShowByDays.BackColor = System.Drawing.Color.LightGray;
            this.btn_ShowByDays.FlatAppearance.BorderSize = 0;
            this.btn_ShowByDays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowByDays.Location = new System.Drawing.Point(456, 30);
            this.btn_ShowByDays.Name = "btn_ShowByDays";
            this.btn_ShowByDays.Size = new System.Drawing.Size(101, 33);
            this.btn_ShowByDays.TabIndex = 21;
            this.btn_ShowByDays.Text = "По дням";
            this.btn_ShowByDays.UseVisualStyleBackColor = false;
            this.btn_ShowByDays.Click += new System.EventHandler(this.btn_ShowByDays_Click);
            // 
            // btn_ShowByWeeks
            // 
            this.btn_ShowByWeeks.BackColor = System.Drawing.Color.LightGray;
            this.btn_ShowByWeeks.FlatAppearance.BorderSize = 0;
            this.btn_ShowByWeeks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowByWeeks.Location = new System.Drawing.Point(568, 30);
            this.btn_ShowByWeeks.Name = "btn_ShowByWeeks";
            this.btn_ShowByWeeks.Size = new System.Drawing.Size(110, 33);
            this.btn_ShowByWeeks.TabIndex = 22;
            this.btn_ShowByWeeks.Text = "По неделям";
            this.btn_ShowByWeeks.UseVisualStyleBackColor = false;
            this.btn_ShowByWeeks.Click += new System.EventHandler(this.btn_ShowByWeeks_Click);
            // 
            // btn_ShowByMonths
            // 
            this.btn_ShowByMonths.BackColor = System.Drawing.Color.LightGray;
            this.btn_ShowByMonths.FlatAppearance.BorderSize = 0;
            this.btn_ShowByMonths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowByMonths.Location = new System.Drawing.Point(689, 30);
            this.btn_ShowByMonths.Name = "btn_ShowByMonths";
            this.btn_ShowByMonths.Size = new System.Drawing.Size(110, 33);
            this.btn_ShowByMonths.TabIndex = 23;
            this.btn_ShowByMonths.Text = "По месяцам";
            this.btn_ShowByMonths.UseVisualStyleBackColor = false;
            this.btn_ShowByMonths.Click += new System.EventHandler(this.btn_ShowByMonths_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1409, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Тип";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Описание";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 500;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Количество";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Всего";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btn_Yesterday
            // 
            this.btn_Yesterday.BackColor = System.Drawing.Color.LightGray;
            this.btn_Yesterday.FlatAppearance.BorderSize = 0;
            this.btn_Yesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Yesterday.Location = new System.Drawing.Point(414, 69);
            this.btn_Yesterday.Name = "btn_Yesterday";
            this.btn_Yesterday.Size = new System.Drawing.Size(100, 30);
            this.btn_Yesterday.TabIndex = 25;
            this.btn_Yesterday.Text = "Вчера";
            this.btn_Yesterday.UseVisualStyleBackColor = false;
            this.btn_Yesterday.Click += new System.EventHandler(this.btn_Yesterday_Click);
            // 
            // PnL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 703);
            this.Controls.Add(this.btn_Yesterday);
            this.Controls.Add(this.btn_ShowByMonths);
            this.Controls.Add(this.btn_ShowByWeeks);
            this.Controls.Add(this.btn_ShowByDays);
            this.Controls.Add(this.btn_ShowPnL);
            this.Controls.Add(this.btn_Today);
            this.Controls.Add(this.btn_1yearPeriod);
            this.Controls.Add(this.btn_6monthsPeriod);
            this.Controls.Add(this.btn_30daysPeriod);
            this.Controls.Add(this.btn_7daysPeriod);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ChooseDate);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PnL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PnL_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_DateEnd;
        private System.Windows.Forms.TextBox tb_DateStart;
        private System.Windows.Forms.MonthCalendar monthCalendarEnd;
        private System.Windows.Forms.MonthCalendar monthCalendarStart;
        private System.Windows.Forms.Button btn_ChooseDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_7daysPeriod;
        private System.Windows.Forms.Button btn_30daysPeriod;
        private System.Windows.Forms.Button btn_6monthsPeriod;
        private System.Windows.Forms.Button btn_1yearPeriod;
        private System.Windows.Forms.Button btn_Today;
        private System.Windows.Forms.Button btn_ShowPnL;
        private System.Windows.Forms.Button btn_ShowByDays;
        private System.Windows.Forms.Button btn_ShowByWeeks;
        private System.Windows.Forms.Button btn_ShowByMonths;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btn_Yesterday;
    }
}