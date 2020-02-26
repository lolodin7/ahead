namespace Excel_Parse
{
    partial class ReportAdvertisingViewFixed
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAdvertisingViewFixed));
            this.label1 = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.dgv_AdvProducts = new System.Windows.Forms.DataGridView();
            this.btn_DrawChart = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_ChartSource = new System.Windows.Forms.ComboBox();
            this.cb_dgvRows = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AdvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(121, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_EndDate.Location = new System.Drawing.Point(157, 4);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(100, 23);
            this.lb_EndDate.TabIndex = 26;
            this.lb_EndDate.Text = "label1";
            this.lb_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_StartDate.Location = new System.Drawing.Point(11, 4);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(100, 23);
            this.lb_StartDate.TabIndex = 25;
            this.lb_StartDate.Text = "label1";
            this.lb_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv_AdvProducts
            // 
            this.dgv_AdvProducts.AllowUserToAddRows = false;
            this.dgv_AdvProducts.AllowUserToDeleteRows = false;
            this.dgv_AdvProducts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_AdvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AdvProducts.Location = new System.Drawing.Point(4, 47);
            this.dgv_AdvProducts.Name = "dgv_AdvProducts";
            this.dgv_AdvProducts.ReadOnly = true;
            this.dgv_AdvProducts.RowTemplate.Height = 24;
            this.dgv_AdvProducts.Size = new System.Drawing.Size(1240, 590);
            this.dgv_AdvProducts.TabIndex = 28;
            // 
            // btn_DrawChart
            // 
            this.btn_DrawChart.BackColor = System.Drawing.Color.Tan;
            this.btn_DrawChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DrawChart.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DrawChart.Location = new System.Drawing.Point(1107, 8);
            this.btn_DrawChart.Name = "btn_DrawChart";
            this.btn_DrawChart.Size = new System.Drawing.Size(137, 32);
            this.btn_DrawChart.TabIndex = 29;
            this.btn_DrawChart.Text = "Нарисовать";
            this.btn_DrawChart.UseVisualStyleBackColor = false;
            this.btn_DrawChart.Visible = false;
            this.btn_DrawChart.Click += new System.EventHandler(this.btn_DrawChart_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 641);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1240, 700);
            this.chart1.TabIndex = 30;
            this.chart1.Text = "chart1";
            // 
            // cb_ChartSource
            // 
            this.cb_ChartSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ChartSource.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_ChartSource.FormattingEnabled = true;
            this.cb_ChartSource.Items.AddRange(new object[] {
            "Impressions",
            "Clicks",
            "CTR",
            "CPC",
            "Spend",
            "Sales",
            "ACoS",
            "Orders",
            "Units"});
            this.cb_ChartSource.Location = new System.Drawing.Point(862, 13);
            this.cb_ChartSource.MaxDropDownItems = 10;
            this.cb_ChartSource.Name = "cb_ChartSource";
            this.cb_ChartSource.Size = new System.Drawing.Size(199, 25);
            this.cb_ChartSource.TabIndex = 31;
            this.cb_ChartSource.Visible = false;
            // 
            // cb_dgvRows
            // 
            this.cb_dgvRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dgvRows.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_dgvRows.FormattingEnabled = true;
            this.cb_dgvRows.Location = new System.Drawing.Point(397, 13);
            this.cb_dgvRows.MaxDropDownItems = 10;
            this.cb_dgvRows.Name = "cb_dgvRows";
            this.cb_dgvRows.Size = new System.Drawing.Size(433, 25);
            this.cb_dgvRows.TabIndex = 32;
            this.cb_dgvRows.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_EndDate);
            this.panel1.Controls.Add(this.lb_StartDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 33);
            this.panel1.TabIndex = 85;
            // 
            // ReportAdvertisingViewFixed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1281, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cb_dgvRows);
            this.Controls.Add(this.cb_ChartSource);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btn_DrawChart);
            this.Controls.Add(this.dgv_AdvProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportAdvertisingViewFixed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportAdvertisingViewFixed";
            this.SizeChanged += new System.EventHandler(this.ReportAdvertisingViewFixed_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AdvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label lb_StartDate;
        public System.Windows.Forms.DataGridView dgv_AdvProducts;
        private System.Windows.Forms.Button btn_DrawChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cb_ChartSource;
        private System.Windows.Forms.ComboBox cb_dgvRows;
        private System.Windows.Forms.Panel panel1;
    }
}