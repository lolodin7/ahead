namespace Excel_Parse
{
    partial class ProductsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsView));
            this.dgv_Products = new System.Windows.Forms.DataGridView();
            this.dgv_ProductTypes = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_editing_ProductName = new System.Windows.Forms.TextBox();
            this.tb_editing_ASIN = new System.Windows.Forms.TextBox();
            this.tb_editing_SKU = new System.Windows.Forms.TextBox();
            this.cb_editing_ProductTypes = new System.Windows.Forms.ComboBox();
            this.lb_ProductName = new System.Windows.Forms.Label();
            this.lb_SKU = new System.Windows.Forms.Label();
            this.lb_ASIN = new System.Windows.Forms.Label();
            this.lb_ProductTypes = new System.Windows.Forms.Label();
            this.btn_Help = new System.Windows.Forms.Button();
            this.tb_editing_ProductTypeId = new System.Windows.Forms.TextBox();
            this.tb_editing_ProductId = new System.Windows.Forms.TextBox();
            this.btn_SaveEditing = new System.Windows.Forms.Button();
            this.btn_CancelEditing = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_ProductName2 = new System.Windows.Forms.Label();
            this.btn_SaveAdding = new System.Windows.Forms.Button();
            this.tb_adding_ProductName = new System.Windows.Forms.TextBox();
            this.lb_ProductTypes2 = new System.Windows.Forms.Label();
            this.btn_ClearAdding = new System.Windows.Forms.Button();
            this.lb_ASIN2 = new System.Windows.Forms.Label();
            this.tb_adding_ASIN = new System.Windows.Forms.TextBox();
            this.lb_SKU2 = new System.Windows.Forms.Label();
            this.tb_adding_ProductTypeId = new System.Windows.Forms.TextBox();
            this.tb_adding_SKU = new System.Windows.Forms.TextBox();
            this.cb_adding_ProductTypes = new System.Windows.Forms.ComboBox();
            this.ProductIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductASIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTypeId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTypeNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Products
            // 
            this.dgv_Products.AllowUserToAddRows = false;
            this.dgv_Products.AllowUserToDeleteRows = false;
            this.dgv_Products.AllowUserToResizeColumns = false;
            this.dgv_Products.AllowUserToResizeRows = false;
            this.dgv_Products.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductIdColumn,
            this.ProductName,
            this.ProductASIN,
            this.ProductSKU,
            this.ProductTypeId,
            this.ProductTypeId2,
            this.ProductTypeNameColumn});
            this.dgv_Products.Location = new System.Drawing.Point(12, 12);
            this.dgv_Products.MultiSelect = false;
            this.dgv_Products.Name = "dgv_Products";
            this.dgv_Products.ReadOnly = true;
            this.dgv_Products.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Products.Size = new System.Drawing.Size(863, 314);
            this.dgv_Products.TabIndex = 0;
            this.dgv_Products.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Products_CellDoubleClick);
            this.dgv_Products.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Products_CellMouseClick);
            this.dgv_Products.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Products_CellMouseMove);
            // 
            // dgv_ProductTypes
            // 
            this.dgv_ProductTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProductTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.dgv_ProductTypes.Location = new System.Drawing.Point(465, 650);
            this.dgv_ProductTypes.Name = "dgv_ProductTypes";
            this.dgv_ProductTypes.Size = new System.Drawing.Size(240, 150);
            this.dgv_ProductTypes.TabIndex = 1;
            this.dgv_ProductTypes.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // tb_editing_ProductName
            // 
            this.tb_editing_ProductName.Enabled = false;
            this.tb_editing_ProductName.Location = new System.Drawing.Point(8, 43);
            this.tb_editing_ProductName.Name = "tb_editing_ProductName";
            this.tb_editing_ProductName.Size = new System.Drawing.Size(261, 20);
            this.tb_editing_ProductName.TabIndex = 2;
            // 
            // tb_editing_ASIN
            // 
            this.tb_editing_ASIN.Enabled = false;
            this.tb_editing_ASIN.Location = new System.Drawing.Point(317, 43);
            this.tb_editing_ASIN.Name = "tb_editing_ASIN";
            this.tb_editing_ASIN.Size = new System.Drawing.Size(112, 20);
            this.tb_editing_ASIN.TabIndex = 3;
            // 
            // tb_editing_SKU
            // 
            this.tb_editing_SKU.Enabled = false;
            this.tb_editing_SKU.Location = new System.Drawing.Point(483, 43);
            this.tb_editing_SKU.Name = "tb_editing_SKU";
            this.tb_editing_SKU.Size = new System.Drawing.Size(112, 20);
            this.tb_editing_SKU.TabIndex = 4;
            // 
            // cb_editing_ProductTypes
            // 
            this.cb_editing_ProductTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_editing_ProductTypes.Enabled = false;
            this.cb_editing_ProductTypes.FormattingEnabled = true;
            this.cb_editing_ProductTypes.Location = new System.Drawing.Point(638, 42);
            this.cb_editing_ProductTypes.Name = "cb_editing_ProductTypes";
            this.cb_editing_ProductTypes.Size = new System.Drawing.Size(151, 21);
            this.cb_editing_ProductTypes.TabIndex = 5;
            this.cb_editing_ProductTypes.SelectedIndexChanged += new System.EventHandler(this.cb_editing_ProductTypes_SelectedIndexChanged);
            // 
            // lb_ProductName
            // 
            this.lb_ProductName.AutoSize = true;
            this.lb_ProductName.Location = new System.Drawing.Point(91, 23);
            this.lb_ProductName.Name = "lb_ProductName";
            this.lb_ProductName.Size = new System.Drawing.Size(95, 13);
            this.lb_ProductName.TabIndex = 6;
            this.lb_ProductName.Text = "Название товара";
            // 
            // lb_SKU
            // 
            this.lb_SKU.AutoSize = true;
            this.lb_SKU.Location = new System.Drawing.Point(526, 23);
            this.lb_SKU.Name = "lb_SKU";
            this.lb_SKU.Size = new System.Drawing.Size(29, 13);
            this.lb_SKU.TabIndex = 7;
            this.lb_SKU.Text = "SKU";
            // 
            // lb_ASIN
            // 
            this.lb_ASIN.AutoSize = true;
            this.lb_ASIN.Location = new System.Drawing.Point(359, 23);
            this.lb_ASIN.Name = "lb_ASIN";
            this.lb_ASIN.Size = new System.Drawing.Size(32, 13);
            this.lb_ASIN.TabIndex = 7;
            this.lb_ASIN.Text = "ASIN";
            // 
            // lb_ProductTypes
            // 
            this.lb_ProductTypes.AutoSize = true;
            this.lb_ProductTypes.Location = new System.Drawing.Point(684, 23);
            this.lb_ProductTypes.Name = "lb_ProductTypes";
            this.lb_ProductTypes.Size = new System.Drawing.Size(64, 13);
            this.lb_ProductTypes.TabIndex = 8;
            this.lb_ProductTypes.Text = "Тип товара";
            // 
            // btn_Help
            // 
            this.btn_Help.Location = new System.Drawing.Point(5, 626);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(66, 30);
            this.btn_Help.TabIndex = 9;
            this.btn_Help.Text = "Помощь";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // tb_editing_ProductTypeId
            // 
            this.tb_editing_ProductTypeId.Location = new System.Drawing.Point(795, 42);
            this.tb_editing_ProductTypeId.Name = "tb_editing_ProductTypeId";
            this.tb_editing_ProductTypeId.Size = new System.Drawing.Size(61, 20);
            this.tb_editing_ProductTypeId.TabIndex = 10;
            this.tb_editing_ProductTypeId.Text = "typeId";
            this.tb_editing_ProductTypeId.Visible = false;
            // 
            // tb_editing_ProductId
            // 
            this.tb_editing_ProductId.Location = new System.Drawing.Point(570, 43);
            this.tb_editing_ProductId.Name = "tb_editing_ProductId";
            this.tb_editing_ProductId.Size = new System.Drawing.Size(56, 20);
            this.tb_editing_ProductId.TabIndex = 11;
            this.tb_editing_ProductId.Text = "productId";
            this.tb_editing_ProductId.Visible = false;
            // 
            // btn_SaveEditing
            // 
            this.btn_SaveEditing.Enabled = false;
            this.btn_SaveEditing.Location = new System.Drawing.Point(208, 72);
            this.btn_SaveEditing.Name = "btn_SaveEditing";
            this.btn_SaveEditing.Size = new System.Drawing.Size(163, 31);
            this.btn_SaveEditing.TabIndex = 12;
            this.btn_SaveEditing.Text = "Применить";
            this.btn_SaveEditing.UseVisualStyleBackColor = true;
            this.btn_SaveEditing.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_CancelEditing
            // 
            this.btn_CancelEditing.Enabled = false;
            this.btn_CancelEditing.Location = new System.Drawing.Point(463, 72);
            this.btn_CancelEditing.Name = "btn_CancelEditing";
            this.btn_CancelEditing.Size = new System.Drawing.Size(163, 31);
            this.btn_CancelEditing.TabIndex = 13;
            this.btn_CancelEditing.Text = "Отменить";
            this.btn_CancelEditing.UseVisualStyleBackColor = true;
            this.btn_CancelEditing.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_ProductName);
            this.groupBox1.Controls.Add(this.tb_editing_ProductName);
            this.groupBox1.Controls.Add(this.btn_CancelEditing);
            this.groupBox1.Controls.Add(this.tb_editing_ASIN);
            this.groupBox1.Controls.Add(this.btn_SaveEditing);
            this.groupBox1.Controls.Add(this.tb_editing_SKU);
            this.groupBox1.Controls.Add(this.tb_editing_ProductId);
            this.groupBox1.Controls.Add(this.cb_editing_ProductTypes);
            this.groupBox1.Controls.Add(this.tb_editing_ProductTypeId);
            this.groupBox1.Controls.Add(this.lb_SKU);
            this.groupBox1.Controls.Add(this.lb_ASIN);
            this.groupBox1.Controls.Add(this.lb_ProductTypes);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(863, 111);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование товара";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_ProductName2);
            this.groupBox2.Controls.Add(this.btn_SaveAdding);
            this.groupBox2.Controls.Add(this.tb_adding_ProductName);
            this.groupBox2.Controls.Add(this.lb_ProductTypes2);
            this.groupBox2.Controls.Add(this.btn_ClearAdding);
            this.groupBox2.Controls.Add(this.lb_ASIN2);
            this.groupBox2.Controls.Add(this.tb_adding_ASIN);
            this.groupBox2.Controls.Add(this.lb_SKU2);
            this.groupBox2.Controls.Add(this.tb_adding_ProductTypeId);
            this.groupBox2.Controls.Add(this.tb_adding_SKU);
            this.groupBox2.Controls.Add(this.cb_adding_ProductTypes);
            this.groupBox2.Location = new System.Drawing.Point(12, 487);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 129);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавление нового товара";
            // 
            // lb_ProductName2
            // 
            this.lb_ProductName2.AutoSize = true;
            this.lb_ProductName2.Location = new System.Drawing.Point(91, 33);
            this.lb_ProductName2.Name = "lb_ProductName2";
            this.lb_ProductName2.Size = new System.Drawing.Size(95, 13);
            this.lb_ProductName2.TabIndex = 18;
            this.lb_ProductName2.Text = "Название товара";
            // 
            // btn_SaveAdding
            // 
            this.btn_SaveAdding.Location = new System.Drawing.Point(208, 82);
            this.btn_SaveAdding.Name = "btn_SaveAdding";
            this.btn_SaveAdding.Size = new System.Drawing.Size(163, 31);
            this.btn_SaveAdding.TabIndex = 24;
            this.btn_SaveAdding.Text = "Применить";
            this.btn_SaveAdding.UseVisualStyleBackColor = true;
            this.btn_SaveAdding.Click += new System.EventHandler(this.btn_SaveAdding_Click);
            // 
            // tb_adding_ProductName
            // 
            this.tb_adding_ProductName.Location = new System.Drawing.Point(8, 53);
            this.tb_adding_ProductName.Name = "tb_adding_ProductName";
            this.tb_adding_ProductName.Size = new System.Drawing.Size(261, 20);
            this.tb_adding_ProductName.TabIndex = 14;
            // 
            // lb_ProductTypes2
            // 
            this.lb_ProductTypes2.AutoSize = true;
            this.lb_ProductTypes2.Location = new System.Drawing.Point(684, 33);
            this.lb_ProductTypes2.Name = "lb_ProductTypes2";
            this.lb_ProductTypes2.Size = new System.Drawing.Size(64, 13);
            this.lb_ProductTypes2.TabIndex = 21;
            this.lb_ProductTypes2.Text = "Тип товара";
            // 
            // btn_ClearAdding
            // 
            this.btn_ClearAdding.Location = new System.Drawing.Point(463, 82);
            this.btn_ClearAdding.Name = "btn_ClearAdding";
            this.btn_ClearAdding.Size = new System.Drawing.Size(163, 31);
            this.btn_ClearAdding.TabIndex = 25;
            this.btn_ClearAdding.Text = "Очистить";
            this.btn_ClearAdding.UseVisualStyleBackColor = true;
            this.btn_ClearAdding.Click += new System.EventHandler(this.btn_ClearAdding_Click);
            // 
            // lb_ASIN2
            // 
            this.lb_ASIN2.AutoSize = true;
            this.lb_ASIN2.Location = new System.Drawing.Point(359, 33);
            this.lb_ASIN2.Name = "lb_ASIN2";
            this.lb_ASIN2.Size = new System.Drawing.Size(32, 13);
            this.lb_ASIN2.TabIndex = 20;
            this.lb_ASIN2.Text = "ASIN";
            // 
            // tb_adding_ASIN
            // 
            this.tb_adding_ASIN.Location = new System.Drawing.Point(317, 53);
            this.tb_adding_ASIN.Name = "tb_adding_ASIN";
            this.tb_adding_ASIN.Size = new System.Drawing.Size(112, 20);
            this.tb_adding_ASIN.TabIndex = 15;
            // 
            // lb_SKU2
            // 
            this.lb_SKU2.AutoSize = true;
            this.lb_SKU2.Location = new System.Drawing.Point(526, 33);
            this.lb_SKU2.Name = "lb_SKU2";
            this.lb_SKU2.Size = new System.Drawing.Size(29, 13);
            this.lb_SKU2.TabIndex = 19;
            this.lb_SKU2.Text = "SKU";
            // 
            // tb_adding_ProductTypeId
            // 
            this.tb_adding_ProductTypeId.Location = new System.Drawing.Point(795, 52);
            this.tb_adding_ProductTypeId.Name = "tb_adding_ProductTypeId";
            this.tb_adding_ProductTypeId.Size = new System.Drawing.Size(61, 20);
            this.tb_adding_ProductTypeId.TabIndex = 22;
            this.tb_adding_ProductTypeId.Text = "typeId";
            this.tb_adding_ProductTypeId.Visible = false;
            // 
            // tb_adding_SKU
            // 
            this.tb_adding_SKU.Location = new System.Drawing.Point(483, 53);
            this.tb_adding_SKU.Name = "tb_adding_SKU";
            this.tb_adding_SKU.Size = new System.Drawing.Size(112, 20);
            this.tb_adding_SKU.TabIndex = 16;
            // 
            // cb_adding_ProductTypes
            // 
            this.cb_adding_ProductTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_adding_ProductTypes.FormattingEnabled = true;
            this.cb_adding_ProductTypes.Location = new System.Drawing.Point(638, 52);
            this.cb_adding_ProductTypes.Name = "cb_adding_ProductTypes";
            this.cb_adding_ProductTypes.Size = new System.Drawing.Size(151, 21);
            this.cb_adding_ProductTypes.TabIndex = 17;
            this.cb_adding_ProductTypes.SelectedIndexChanged += new System.EventHandler(this.cb_adding_ProductTypes_SelectedIndexChanged);
            // 
            // ProductIdColumn
            // 
            this.ProductIdColumn.HeaderText = "ProductIdColumn";
            this.ProductIdColumn.Name = "ProductIdColumn";
            this.ProductIdColumn.ReadOnly = true;
            this.ProductIdColumn.Visible = false;
            this.ProductIdColumn.Width = 50;
            // 
            // ProductName
            // 
            this.ProductName.FillWeight = 369.5432F;
            this.ProductName.HeaderText = "Название товара";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 380;
            // 
            // ProductASIN
            // 
            this.ProductASIN.FillWeight = 10.15228F;
            this.ProductASIN.HeaderText = "ASIN";
            this.ProductASIN.Name = "ProductASIN";
            this.ProductASIN.ReadOnly = true;
            this.ProductASIN.Width = 105;
            // 
            // ProductSKU
            // 
            this.ProductSKU.FillWeight = 10.15228F;
            this.ProductSKU.HeaderText = "SKU";
            this.ProductSKU.Name = "ProductSKU";
            this.ProductSKU.ReadOnly = true;
            this.ProductSKU.Width = 105;
            // 
            // ProductTypeId
            // 
            this.ProductTypeId.HeaderText = "ProductTypeId";
            this.ProductTypeId.Name = "ProductTypeId";
            this.ProductTypeId.ReadOnly = true;
            this.ProductTypeId.Visible = false;
            this.ProductTypeId.Width = 50;
            // 
            // ProductTypeId2
            // 
            this.ProductTypeId2.HeaderText = "ProductTypeId2";
            this.ProductTypeId2.Name = "ProductTypeId2";
            this.ProductTypeId2.ReadOnly = true;
            this.ProductTypeId2.Visible = false;
            // 
            // ProductTypeNameColumn
            // 
            this.ProductTypeNameColumn.FillWeight = 10.15228F;
            this.ProductTypeNameColumn.HeaderText = "Тип товара";
            this.ProductTypeNameColumn.Name = "ProductTypeNameColumn";
            this.ProductTypeNameColumn.ReadOnly = true;
            this.ProductTypeNameColumn.Width = 230;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.dgv_ProductTypes);
            this.Controls.Add(this.dgv_Products);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление товарами";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Products_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Products;
        private System.Windows.Forms.DataGridView dgv_ProductTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox tb_editing_ProductName;
        private System.Windows.Forms.TextBox tb_editing_ASIN;
        private System.Windows.Forms.TextBox tb_editing_SKU;
        private System.Windows.Forms.ComboBox cb_editing_ProductTypes;
        private System.Windows.Forms.Label lb_ProductName;
        private System.Windows.Forms.Label lb_SKU;
        private System.Windows.Forms.Label lb_ASIN;
        private System.Windows.Forms.Label lb_ProductTypes;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.TextBox tb_editing_ProductTypeId;
        private System.Windows.Forms.TextBox tb_editing_ProductId;
        private System.Windows.Forms.Button btn_SaveEditing;
        private System.Windows.Forms.Button btn_CancelEditing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_ProductName2;
        private System.Windows.Forms.Button btn_SaveAdding;
        private System.Windows.Forms.TextBox tb_adding_ProductName;
        private System.Windows.Forms.Label lb_ProductTypes2;
        private System.Windows.Forms.Button btn_ClearAdding;
        private System.Windows.Forms.Label lb_ASIN2;
        private System.Windows.Forms.TextBox tb_adding_ASIN;
        private System.Windows.Forms.Label lb_SKU2;
        private System.Windows.Forms.TextBox tb_adding_ProductTypeId;
        private System.Windows.Forms.TextBox tb_adding_SKU;
        private System.Windows.Forms.ComboBox cb_adding_ProductTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductASIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeNameColumn;
    }
}