namespace Excel_Parse
{
    partial class ReportAdvertisingUploadView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAdvertisingUploadView));
            this.btn_UploadFromFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_MarketPlace = new System.Windows.Forms.ComboBox();
            this.cb_CampaignType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_UploadFromFile
            // 
            this.btn_UploadFromFile.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_UploadFromFile.Location = new System.Drawing.Point(77, 97);
            this.btn_UploadFromFile.Name = "btn_UploadFromFile";
            this.btn_UploadFromFile.Size = new System.Drawing.Size(167, 53);
            this.btn_UploadFromFile.TabIndex = 0;
            this.btn_UploadFromFile.Text = "Выбрать файл";
            this.btn_UploadFromFile.UseVisualStyleBackColor = true;
            this.btn_UploadFromFile.Click += new System.EventHandler(this.Btn_UploadFromFile_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Путь к файлу...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_MarketPlace
            // 
            this.cb_MarketPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MarketPlace.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_MarketPlace.FormattingEnabled = true;
            this.cb_MarketPlace.Location = new System.Drawing.Point(34, 28);
            this.cb_MarketPlace.Name = "cb_MarketPlace";
            this.cb_MarketPlace.Size = new System.Drawing.Size(251, 25);
            this.cb_MarketPlace.TabIndex = 3;
            this.cb_MarketPlace.SelectedIndexChanged += new System.EventHandler(this.Cb_MarketPlace_SelectedIndexChanged);
            // 
            // cb_CampaignType
            // 
            this.cb_CampaignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CampaignType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_CampaignType.FormattingEnabled = true;
            this.cb_CampaignType.Location = new System.Drawing.Point(83, 51);
            this.cb_CampaignType.Name = "cb_CampaignType";
            this.cb_CampaignType.Size = new System.Drawing.Size(251, 25);
            this.cb_CampaignType.TabIndex = 4;
            this.cb_CampaignType.SelectedIndexChanged += new System.EventHandler(this.Cb_CampaignType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(34, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Маркетплейс";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(83, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Campaign Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Save.Location = new System.Drawing.Point(9, 448);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 53);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Close.Location = new System.Drawing.Point(261, 448);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 53);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_Progress);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.btn_UploadFromFile);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cb_MarketPlace);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(49, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 362);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.richTextBox2.Location = new System.Drawing.Point(11, 198);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(296, 155);
            this.richTextBox2.TabIndex = 13;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(73, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 23);
            this.label7.TabIndex = 12;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(52, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 114);
            this.label6.TabIndex = 12;
            this.label6.Text = "Для начала выберите Campaign Type из списка выше ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Multiselect = true;
            // 
            // lb_Progress
            // 
            this.lb_Progress.Location = new System.Drawing.Point(34, 168);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(251, 21);
            this.lb_Progress.TabIndex = 14;
            this.lb_Progress.Text = "label4";
            this.lb_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Progress.Visible = false;
            // 
            // ReportAdvertisingUploadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 521);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.cb_CampaignType);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportAdvertisingUploadView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузить отчет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvertisingUploadReport_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_UploadFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_MarketPlace;
        private System.Windows.Forms.ComboBox cb_CampaignType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label lb_Progress;
    }
}