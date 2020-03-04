namespace Excel_Parse
{
    partial class ReportStockView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportStockView));
            this.cb_MarketPlace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Stock = new System.Windows.Forms.DataGridView();
            this.cb_FilterParameter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_FilterParameterValue = new System.Windows.Forms.RichTextBox();
            this.btn_GoFilter = new System.Windows.Forms.Button();
            this.lb_Info = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_MarketPlace
            // 
            this.cb_MarketPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MarketPlace.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_MarketPlace.FormattingEnabled = true;
            this.cb_MarketPlace.Location = new System.Drawing.Point(5, 36);
            this.cb_MarketPlace.Name = "cb_MarketPlace";
            this.cb_MarketPlace.Size = new System.Drawing.Size(251, 25);
            this.cb_MarketPlace.TabIndex = 13;
            this.cb_MarketPlace.SelectedIndexChanged += new System.EventHandler(this.cb_MarketPlace_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Маркетплейс";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Stock
            // 
            this.dgv_Stock.AllowUserToAddRows = false;
            this.dgv_Stock.AllowUserToDeleteRows = false;
            this.dgv_Stock.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stock.Location = new System.Drawing.Point(5, 71);
            this.dgv_Stock.Name = "dgv_Stock";
            this.dgv_Stock.ReadOnly = true;
            this.dgv_Stock.RowTemplate.Height = 24;
            this.dgv_Stock.Size = new System.Drawing.Size(1270, 528);
            this.dgv_Stock.TabIndex = 15;
            // 
            // cb_FilterParameter
            // 
            this.cb_FilterParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FilterParameter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_FilterParameter.FormattingEnabled = true;
            this.cb_FilterParameter.Items.AddRange(new object[] {
            "Name",
            "ASIN",
            "SKU",
            "FNSKU"});
            this.cb_FilterParameter.Location = new System.Drawing.Point(410, 36);
            this.cb_FilterParameter.Name = "cb_FilterParameter";
            this.cb_FilterParameter.Size = new System.Drawing.Size(187, 25);
            this.cb_FilterParameter.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(410, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Параметр поиска";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtb_FilterParameterValue
            // 
            this.rtb_FilterParameterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_FilterParameterValue.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_FilterParameterValue.Location = new System.Drawing.Point(617, 36);
            this.rtb_FilterParameterValue.Multiline = false;
            this.rtb_FilterParameterValue.Name = "rtb_FilterParameterValue";
            this.rtb_FilterParameterValue.Size = new System.Drawing.Size(221, 26);
            this.rtb_FilterParameterValue.TabIndex = 19;
            this.rtb_FilterParameterValue.Text = "";
            this.rtb_FilterParameterValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_FilterParameterValue_KeyDown);
            // 
            // btn_GoFilter
            // 
            this.btn_GoFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_GoFilter.Location = new System.Drawing.Point(845, 35);
            this.btn_GoFilter.Name = "btn_GoFilter";
            this.btn_GoFilter.Size = new System.Drawing.Size(82, 27);
            this.btn_GoFilter.TabIndex = 20;
            this.btn_GoFilter.Text = "Поиск";
            this.btn_GoFilter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_GoFilter.UseVisualStyleBackColor = true;
            this.btn_GoFilter.Click += new System.EventHandler(this.btn_GoFilter_Click);
            // 
            // lb_Info
            // 
            this.lb_Info.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Info.Location = new System.Drawing.Point(1054, 19);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(221, 42);
            this.lb_Info.TabIndex = 21;
            this.lb_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(398, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(500, 190);
            this.label3.TabIndex = 22;
            this.label3.Text = "Данные о складе за последнее время отсутствуют";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // ReportStockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 604);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_Info);
            this.Controls.Add(this.btn_GoFilter);
            this.Controls.Add(this.rtb_FilterParameterValue);
            this.Controls.Add(this.cb_FilterParameter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Stock);
            this.Controls.Add(this.cb_MarketPlace);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportStockView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные склада";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportStockView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_MarketPlace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Stock;
        private System.Windows.Forms.ComboBox cb_FilterParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_FilterParameterValue;
        private System.Windows.Forms.Button btn_GoFilter;
        private System.Windows.Forms.Label lb_Info;
        private System.Windows.Forms.Label label3;
    }
}