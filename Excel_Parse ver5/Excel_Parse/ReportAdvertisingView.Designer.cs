namespace Excel_Parse
{
    partial class ReportAdvertisingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAdvertisingView));
            this.dgv_AdvProducts = new System.Windows.Forms.DataGridView();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Filter = new System.Windows.Forms.Button();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AdvProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_AdvProducts
            // 
            this.dgv_AdvProducts.AllowUserToAddRows = false;
            this.dgv_AdvProducts.AllowUserToDeleteRows = false;
            this.dgv_AdvProducts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_AdvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AdvProducts.Location = new System.Drawing.Point(3, 47);
            this.dgv_AdvProducts.Name = "dgv_AdvProducts";
            this.dgv_AdvProducts.ReadOnly = true;
            this.dgv_AdvProducts.RowTemplate.Height = 24;
            this.dgv_AdvProducts.Size = new System.Drawing.Size(1369, 702);
            this.dgv_AdvProducts.TabIndex = 17;
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Export.Location = new System.Drawing.Point(3, 4);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(221, 39);
            this.btn_Export.TabIndex = 18;
            this.btn_Export.Text = "Экспорт в файл";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Filter
            // 
            this.btn_Filter.BackColor = System.Drawing.Color.Tan;
            this.btn_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Filter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Filter.Location = new System.Drawing.Point(948, 4);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(424, 39);
            this.btn_Filter.TabIndex = 19;
            this.btn_Filter.Text = "Фильтр";
            this.btn_Filter.UseVisualStyleBackColor = false;
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_StartDate.Location = new System.Drawing.Point(11, 7);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(100, 23);
            this.lb_StartDate.TabIndex = 22;
            this.lb_StartDate.Text = "label1";
            this.lb_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_EndDate.Location = new System.Drawing.Point(157, 7);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(100, 23);
            this.lb_EndDate.TabIndex = 23;
            this.lb_EndDate.Text = "label1";
            this.lb_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(121, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.NavajoWhite;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(686, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 39);
            this.button1.TabIndex = 26;
            this.button1.Text = "Зафиксировать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_StartDate);
            this.panel1.Controls.Add(this.lb_EndDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(318, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 39);
            this.panel1.TabIndex = 27;
            // 
            // ReportAdvertisingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 752);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Filter);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.dgv_AdvProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 200);
            this.Name = "ReportAdvertisingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные рекламы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvertisingReportView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdvertisingReportView_FormClosed);
            this.SizeChanged += new System.EventHandler(this.AdvertisingReportView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AdvProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Filter;
        private System.Windows.Forms.Label lb_StartDate;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.DataGridView dgv_AdvProducts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}