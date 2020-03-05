namespace Excel_Parse
{
    partial class ReportStockUploadView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportStockUploadView));
            this.btn_UploadFromFile = new System.Windows.Forms.Button();
            this.lb_Path = new System.Windows.Forms.Label();
            this.cb_MarketPlace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.mc_StartDate = new System.Windows.Forms.MonthCalendar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_UploadFromFile
            // 
            this.btn_UploadFromFile.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_UploadFromFile.Location = new System.Drawing.Point(85, 260);
            this.btn_UploadFromFile.Name = "btn_UploadFromFile";
            this.btn_UploadFromFile.Size = new System.Drawing.Size(167, 53);
            this.btn_UploadFromFile.TabIndex = 9;
            this.btn_UploadFromFile.Text = "Выбрать файл";
            this.btn_UploadFromFile.UseVisualStyleBackColor = true;
            this.btn_UploadFromFile.Click += new System.EventHandler(this.btn_UploadFromFile_Click);
            // 
            // lb_Path
            // 
            this.lb_Path.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lb_Path.Location = new System.Drawing.Point(19, 320);
            this.lb_Path.Name = "lb_Path";
            this.lb_Path.Size = new System.Drawing.Size(293, 43);
            this.lb_Path.TabIndex = 10;
            this.lb_Path.Text = "Путь к файлу...";
            this.lb_Path.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_MarketPlace
            // 
            this.cb_MarketPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MarketPlace.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_MarketPlace.FormattingEnabled = true;
            this.cb_MarketPlace.Location = new System.Drawing.Point(35, 49);
            this.cb_MarketPlace.Name = "cb_MarketPlace";
            this.cb_MarketPlace.Size = new System.Drawing.Size(251, 25);
            this.cb_MarketPlace.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Маркетплейс";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Save.Location = new System.Drawing.Point(19, 377);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 53);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Close.Location = new System.Drawing.Point(185, 377);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 53);
            this.btn_Close.TabIndex = 14;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // mc_StartDate
            // 
            this.mc_StartDate.Location = new System.Drawing.Point(81, 86);
            this.mc_StartDate.MaxSelectionCount = 1;
            this.mc_StartDate.Name = "mc_StartDate";
            this.mc_StartDate.ShowToday = false;
            this.mc_StartDate.TabIndex = 15;
            this.mc_StartDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ReportStockUploadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 451);
            this.Controls.Add(this.mc_StartDate);
            this.Controls.Add(this.btn_UploadFromFile);
            this.Controls.Add(this.lb_Path);
            this.Controls.Add(this.cb_MarketPlace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportStockUploadView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузить Stock report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportStockView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_UploadFromFile;
        private System.Windows.Forms.Label lb_Path;
        private System.Windows.Forms.ComboBox cb_MarketPlace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.MonthCalendar mc_StartDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}