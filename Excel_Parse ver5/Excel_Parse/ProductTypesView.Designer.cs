namespace Excel_Parse
{
    partial class ProductTypesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductTypesView));
            this.dgv_ProductTypes = new System.Windows.Forms.DataGridView();
            this.ProductTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_ProductType = new System.Windows.Forms.RichTextBox();
            this.btn_RefreshDGV = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lb_ProductType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ProductTypes
            // 
            this.dgv_ProductTypes.AllowUserToAddRows = false;
            this.dgv_ProductTypes.AllowUserToDeleteRows = false;
            this.dgv_ProductTypes.AllowUserToResizeColumns = false;
            this.dgv_ProductTypes.AllowUserToResizeRows = false;
            this.dgv_ProductTypes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ProductTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ProductTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductTypeId,
            this.TypeName});
            this.dgv_ProductTypes.Location = new System.Drawing.Point(6, 5);
            this.dgv_ProductTypes.MultiSelect = false;
            this.dgv_ProductTypes.Name = "dgv_ProductTypes";
            this.dgv_ProductTypes.ReadOnly = true;
            this.dgv_ProductTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_ProductTypes.Size = new System.Drawing.Size(293, 324);
            this.dgv_ProductTypes.TabIndex = 0;
            this.dgv_ProductTypes.Visible = false;
            this.dgv_ProductTypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ProductTypes_CellDoubleClick);
            this.dgv_ProductTypes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ProductTypes_CellMouseClick);
            // 
            // ProductTypeId
            // 
            this.ProductTypeId.HeaderText = "ProductTypeId";
            this.ProductTypeId.Name = "ProductTypeId";
            this.ProductTypeId.ReadOnly = true;
            this.ProductTypeId.Visible = false;
            // 
            // TypeName
            // 
            this.TypeName.HeaderText = "Название вида";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TypeName.Width = 250;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_ProductType);
            this.groupBox1.Controls.Add(this.btn_RefreshDGV);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.lb_ProductType);
            this.groupBox1.Location = new System.Drawing.Point(6, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 152);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление нового вида товара";
            // 
            // rtb_ProductType
            // 
            this.rtb_ProductType.Location = new System.Drawing.Point(50, 60);
            this.rtb_ProductType.Multiline = false;
            this.rtb_ProductType.Name = "rtb_ProductType";
            this.rtb_ProductType.Size = new System.Drawing.Size(193, 20);
            this.rtb_ProductType.TabIndex = 6;
            this.rtb_ProductType.Text = "";
            this.rtb_ProductType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ProductType_KeyDown);
            // 
            // btn_RefreshDGV
            // 
            this.btn_RefreshDGV.Location = new System.Drawing.Point(227, 9);
            this.btn_RefreshDGV.Name = "btn_RefreshDGV";
            this.btn_RefreshDGV.Size = new System.Drawing.Size(64, 26);
            this.btn_RefreshDGV.TabIndex = 5;
            this.btn_RefreshDGV.Text = "Обновить";
            this.btn_RefreshDGV.UseVisualStyleBackColor = true;
            this.btn_RefreshDGV.Click += new System.EventHandler(this.btn_RefreshDGV_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(158, 106);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(129, 30);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(6, 106);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(129, 30);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Применить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.AutoSize = true;
            this.lb_ProductType.Location = new System.Drawing.Point(106, 33);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(84, 13);
            this.lb_ProductType.TabIndex = 1;
            this.lb_ProductType.Text = "Название вида";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Виды отсутствуют";
            // 
            // ProductTypesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_ProductTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProductTypesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Виды товаров - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductTypes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ProductTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_RefreshDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_ProductType;
    }
}