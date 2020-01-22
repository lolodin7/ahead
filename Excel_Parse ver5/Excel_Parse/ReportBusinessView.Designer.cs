namespace Excel_Parse
{
    partial class ReportBusinessView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBusinessView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_ShowFilter = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1312, 596);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_ShowFilter
            // 
            this.btn_ShowFilter.BackColor = System.Drawing.Color.Tan;
            this.btn_ShowFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ShowFilter.Location = new System.Drawing.Point(892, 3);
            this.btn_ShowFilter.Name = "btn_ShowFilter";
            this.btn_ShowFilter.Size = new System.Drawing.Size(424, 27);
            this.btn_ShowFilter.TabIndex = 1;
            this.btn_ShowFilter.Text = "Фильтр";
            this.btn_ShowFilter.UseVisualStyleBackColor = false;
            this.btn_ShowFilter.Click += new System.EventHandler(this.btn_ShowFilter_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Export.Location = new System.Drawing.Point(4, 3);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(221, 27);
            this.btn_Export.TabIndex = 2;
            this.btn_Export.Text = "Экспорт в файл";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(517, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_EndDate.Location = new System.Drawing.Point(553, 5);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(100, 23);
            this.lb_EndDate.TabIndex = 26;
            this.lb_EndDate.Text = "label1";
            this.lb_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_StartDate.Location = new System.Drawing.Point(407, 5);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(100, 23);
            this.lb_StartDate.TabIndex = 25;
            this.lb_StartDate.Text = "label1";
            this.lb_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReportBusinessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_EndDate);
            this.Controls.Add(this.lb_StartDate);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_ShowFilter);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportBusinessView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные продаж";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportBusinessView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportBusinessView_FormClosed);
            this.SizeChanged += new System.EventHandler(this.ReportBusinessView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_ShowFilter;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label lb_StartDate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}