namespace Excel_Parse
{
    partial class ReportBusinessUploadView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBusinessUploadView));
            this.btn_Save = new System.Windows.Forms.Button();
            this.cb_MarketPlace1 = new System.Windows.Forms.ComboBox();
            this.btn_UploadFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_mcDate = new System.Windows.Forms.Label();
            this.lb_Path1 = new System.Windows.Forms.Label();
            this.lb_marketplacelbl1 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb_DaysDiff = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lb_startDateText = new System.Windows.Forms.Label();
            this.lb_endDateText = new System.Windows.Forms.Label();
            this.mc_EndDate = new System.Windows.Forms.MonthCalendar();
            this.lb_Path2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_CloseMany = new System.Windows.Forms.Button();
            this.mc_startDate = new System.Windows.Forms.MonthCalendar();
            this.btn_SaveMany = new System.Windows.Forms.Button();
            this.cb_MarketPlace2 = new System.Windows.Forms.ComboBox();
            this.btn_UploadFileMany = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Save.Location = new System.Drawing.Point(9, 412);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 53);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cb_MarketPlace1
            // 
            this.cb_MarketPlace1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MarketPlace1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_MarketPlace1.FormattingEnabled = true;
            this.cb_MarketPlace1.Location = new System.Drawing.Point(93, 51);
            this.cb_MarketPlace1.Name = "cb_MarketPlace1";
            this.cb_MarketPlace1.Size = new System.Drawing.Size(219, 25);
            this.cb_MarketPlace1.TabIndex = 1;
            this.cb_MarketPlace1.SelectedIndexChanged += new System.EventHandler(this.cb_MarketPlace1_SelectedIndexChanged);
            // 
            // btn_UploadFile
            // 
            this.btn_UploadFile.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_UploadFile.Location = new System.Drawing.Point(138, 108);
            this.btn_UploadFile.Name = "btn_UploadFile";
            this.btn_UploadFile.Size = new System.Drawing.Size(135, 53);
            this.btn_UploadFile.TabIndex = 2;
            this.btn_UploadFile.Text = "Выбрать файл";
            this.btn_UploadFile.UseVisualStyleBackColor = true;
            this.btn_UploadFile.Click += new System.EventHandler(this.btn_UploadFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(421, 509);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.lb_mcDate);
            this.tabPage1.Controls.Add(this.lb_Path1);
            this.tabPage1.Controls.Add(this.lb_marketplacelbl1);
            this.tabPage1.Controls.Add(this.btn_Close);
            this.tabPage1.Controls.Add(this.monthCalendar1);
            this.tabPage1.Controls.Add(this.btn_Save);
            this.tabPage1.Controls.Add(this.cb_MarketPlace1);
            this.tabPage1.Controls.Add(this.btn_UploadFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(413, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Один";
            // 
            // lb_mcDate
            // 
            this.lb_mcDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_mcDate.Location = new System.Drawing.Point(119, 378);
            this.lb_mcDate.Name = "lb_mcDate";
            this.lb_mcDate.Size = new System.Drawing.Size(167, 31);
            this.lb_mcDate.TabIndex = 7;
            this.lb_mcDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Path1
            // 
            this.lb_Path1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Path1.Location = new System.Drawing.Point(22, 164);
            this.lb_Path1.Name = "lb_Path1";
            this.lb_Path1.Size = new System.Drawing.Size(372, 44);
            this.lb_Path1.TabIndex = 6;
            // 
            // lb_marketplacelbl1
            // 
            this.lb_marketplacelbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_marketplacelbl1.Location = new System.Drawing.Point(93, 27);
            this.lb_marketplacelbl1.Name = "lb_marketplacelbl1";
            this.lb_marketplacelbl1.Size = new System.Drawing.Size(219, 23);
            this.lb_marketplacelbl1.TabIndex = 5;
            this.lb_marketplacelbl1.Text = "Маркетплейс";
            this.lb_marketplacelbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Close.Location = new System.Drawing.Point(267, 412);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 53);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(122, 217);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lb_DaysDiff);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.lb_startDateText);
            this.tabPage2.Controls.Add(this.lb_endDateText);
            this.tabPage2.Controls.Add(this.mc_EndDate);
            this.tabPage2.Controls.Add(this.lb_Path2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btn_CloseMany);
            this.tabPage2.Controls.Add(this.mc_startDate);
            this.tabPage2.Controls.Add(this.btn_SaveMany);
            this.tabPage2.Controls.Add(this.cb_MarketPlace2);
            this.tabPage2.Controls.Add(this.btn_UploadFileMany);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(413, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Несколько";
            // 
            // lb_DaysDiff
            // 
            this.lb_DaysDiff.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_DaysDiff.Location = new System.Drawing.Point(239, 395);
            this.lb_DaysDiff.Name = "lb_DaysDiff";
            this.lb_DaysDiff.Size = new System.Drawing.Size(168, 26);
            this.lb_DaysDiff.TabIndex = 19;
            this.lb_DaysDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(9, 163);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(219, 227);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // lb_startDateText
            // 
            this.lb_startDateText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_startDateText.Location = new System.Drawing.Point(236, 9);
            this.lb_startDateText.Name = "lb_startDateText";
            this.lb_startDateText.Size = new System.Drawing.Size(168, 26);
            this.lb_startDateText.TabIndex = 17;
            this.lb_startDateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_endDateText
            // 
            this.lb_endDateText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_endDateText.Location = new System.Drawing.Point(236, 204);
            this.lb_endDateText.Name = "lb_endDateText";
            this.lb_endDateText.Size = new System.Drawing.Size(168, 26);
            this.lb_endDateText.TabIndex = 16;
            this.lb_endDateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mc_EndDate
            // 
            this.mc_EndDate.Location = new System.Drawing.Point(240, 228);
            this.mc_EndDate.MaxSelectionCount = 1;
            this.mc_EndDate.Name = "mc_EndDate";
            this.mc_EndDate.ShowToday = false;
            this.mc_EndDate.TabIndex = 15;
            this.mc_EndDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_EndDate_DateChanged);
            // 
            // lb_Path2
            // 
            this.lb_Path2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Path2.Location = new System.Drawing.Point(9, 151);
            this.lb_Path2.Name = "lb_Path2";
            this.lb_Path2.Size = new System.Drawing.Size(219, 44);
            this.lb_Path2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Маркетплейс";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_CloseMany
            // 
            this.btn_CloseMany.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CloseMany.Location = new System.Drawing.Point(269, 423);
            this.btn_CloseMany.Name = "btn_CloseMany";
            this.btn_CloseMany.Size = new System.Drawing.Size(135, 53);
            this.btn_CloseMany.TabIndex = 12;
            this.btn_CloseMany.Text = "Закрыть";
            this.btn_CloseMany.UseVisualStyleBackColor = true;
            this.btn_CloseMany.Click += new System.EventHandler(this.btn_CloseMany_Click);
            // 
            // mc_startDate
            // 
            this.mc_startDate.Location = new System.Drawing.Point(240, 38);
            this.mc_startDate.MaxSelectionCount = 1;
            this.mc_startDate.Name = "mc_startDate";
            this.mc_startDate.ShowToday = false;
            this.mc_startDate.TabIndex = 11;
            this.mc_startDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_startDate_DateChanged);
            // 
            // btn_SaveMany
            // 
            this.btn_SaveMany.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_SaveMany.Location = new System.Drawing.Point(9, 423);
            this.btn_SaveMany.Name = "btn_SaveMany";
            this.btn_SaveMany.Size = new System.Drawing.Size(135, 53);
            this.btn_SaveMany.TabIndex = 8;
            this.btn_SaveMany.Text = "Сохранить";
            this.btn_SaveMany.UseVisualStyleBackColor = true;
            this.btn_SaveMany.Click += new System.EventHandler(this.btn_SaveMany_Click);
            // 
            // cb_MarketPlace2
            // 
            this.cb_MarketPlace2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MarketPlace2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_MarketPlace2.FormattingEnabled = true;
            this.cb_MarketPlace2.Location = new System.Drawing.Point(9, 33);
            this.cb_MarketPlace2.Name = "cb_MarketPlace2";
            this.cb_MarketPlace2.Size = new System.Drawing.Size(219, 25);
            this.cb_MarketPlace2.TabIndex = 9;
            this.cb_MarketPlace2.SelectedIndexChanged += new System.EventHandler(this.cb_MarketPlace2_SelectedIndexChanged);
            // 
            // btn_UploadFileMany
            // 
            this.btn_UploadFileMany.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_UploadFileMany.Location = new System.Drawing.Point(57, 95);
            this.btn_UploadFileMany.Name = "btn_UploadFileMany";
            this.btn_UploadFileMany.Size = new System.Drawing.Size(135, 53);
            this.btn_UploadFileMany.TabIndex = 10;
            this.btn_UploadFileMany.Text = "Выбрать файл";
            this.btn_UploadFileMany.UseVisualStyleBackColor = true;
            this.btn_UploadFileMany.Click += new System.EventHandler(this.btn_UploadFileMany_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Multiselect = true;
            // 
            // ReportBusinessUploadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 516);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportBusinessUploadView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportBusinessUploadView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportBusinessUploadView_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ComboBox cb_MarketPlace1;
        private System.Windows.Forms.Button btn_UploadFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lb_Path1;
        private System.Windows.Forms.Label lb_marketplacelbl1;
        private System.Windows.Forms.Label lb_mcDate;
        private System.Windows.Forms.Label lb_Path2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CloseMany;
        private System.Windows.Forms.MonthCalendar mc_startDate;
        private System.Windows.Forms.Button btn_SaveMany;
        private System.Windows.Forms.ComboBox cb_MarketPlace2;
        private System.Windows.Forms.Button btn_UploadFileMany;
        private System.Windows.Forms.Label lb_startDateText;
        private System.Windows.Forms.Label lb_endDateText;
        private System.Windows.Forms.MonthCalendar mc_EndDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label lb_DaysDiff;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}