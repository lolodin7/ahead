namespace Excel_Parse
{
    partial class FullSemCoreView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullSemCoreView));
            this.dgv_Keywords = new System.Windows.Forms.DataGridView();
            this.ProdTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemCoreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_ProductType = new System.Windows.Forms.ComboBox();
            this.cb_KeywordCategory = new System.Windows.Forms.ComboBox();
            this.lb_ProductType = new System.Windows.Forms.Label();
            this.lb_KeywordCategory = new System.Windows.Forms.Label();
            this.btn_GetKeywords = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Keywords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Keywords
            // 
            this.dgv_Keywords.AllowUserToAddRows = false;
            this.dgv_Keywords.AllowUserToDeleteRows = false;
            this.dgv_Keywords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Keywords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Keywords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdTypeId,
            this.CategoryId,
            this.Keyword,
            this.Value,
            this.Name1,
            this.SemCoreId,
            this.Column1,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column4});
            this.dgv_Keywords.Location = new System.Drawing.Point(12, 12);
            this.dgv_Keywords.Name = "dgv_Keywords";
            this.dgv_Keywords.ReadOnly = true;
            this.dgv_Keywords.Size = new System.Drawing.Size(1010, 737);
            this.dgv_Keywords.TabIndex = 2;
            // 
            // ProdTypeId
            // 
            this.ProdTypeId.HeaderText = "ProdTypeId";
            this.ProdTypeId.Name = "ProdTypeId";
            this.ProdTypeId.ReadOnly = true;
            this.ProdTypeId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProdTypeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProdTypeId.Visible = false;
            // 
            // CategoryId
            // 
            this.CategoryId.HeaderText = "CategoryId";
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.ReadOnly = true;
            this.CategoryId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CategoryId.Visible = false;
            // 
            // Keyword
            // 
            this.Keyword.HeaderText = "Ключ";
            this.Keyword.Name = "Keyword";
            this.Keyword.ReadOnly = true;
            this.Keyword.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Keyword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Keyword.Width = 250;
            // 
            // Value
            // 
            this.Value.HeaderText = "Частота";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Name1
            // 
            this.Name1.HeaderText = "Дата обновления";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            this.Name1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Name1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Name1.Width = 200;
            // 
            // SemCoreId
            // 
            this.SemCoreId.HeaderText = "SemCoreId";
            this.SemCoreId.Name = "SemCoreId";
            this.SemCoreId.ReadOnly = true;
            this.SemCoreId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SemCoreId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SemCoreId.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "categId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название категории";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 200;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "prdotypeID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "prodTypeId";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Название группы товаров";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 200;
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Location = new System.Drawing.Point(1056, 52);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(196, 21);
            this.cb_ProductType.TabIndex = 3;
            // 
            // cb_KeywordCategory
            // 
            this.cb_KeywordCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory.FormattingEnabled = true;
            this.cb_KeywordCategory.Location = new System.Drawing.Point(1056, 131);
            this.cb_KeywordCategory.Name = "cb_KeywordCategory";
            this.cb_KeywordCategory.Size = new System.Drawing.Size(196, 21);
            this.cb_KeywordCategory.TabIndex = 4;
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.Location = new System.Drawing.Point(1102, 26);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(100, 23);
            this.lb_ProductType.TabIndex = 8;
            this.lb_ProductType.Text = "Тип продукта";
            this.lb_ProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_KeywordCategory
            // 
            this.lb_KeywordCategory.Location = new System.Drawing.Point(1091, 105);
            this.lb_KeywordCategory.Name = "lb_KeywordCategory";
            this.lb_KeywordCategory.Size = new System.Drawing.Size(124, 23);
            this.lb_KeywordCategory.TabIndex = 10;
            this.lb_KeywordCategory.Text = "Категория ключей";
            this.lb_KeywordCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GetKeywords
            // 
            this.btn_GetKeywords.Location = new System.Drawing.Point(1084, 193);
            this.btn_GetKeywords.Name = "btn_GetKeywords";
            this.btn_GetKeywords.Size = new System.Drawing.Size(149, 42);
            this.btn_GetKeywords.TabIndex = 26;
            this.btn_GetKeywords.Text = "Показать ключи";
            this.btn_GetKeywords.UseVisualStyleBackColor = true;
            this.btn_GetKeywords.Click += new System.EventHandler(this.btn_GetKeywords_Click);
            // 
            // FullSemCoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.btn_GetKeywords);
            this.Controls.Add(this.lb_KeywordCategory);
            this.Controls.Add(this.lb_ProductType);
            this.Controls.Add(this.cb_KeywordCategory);
            this.Controls.Add(this.cb_ProductType);
            this.Controls.Add(this.dgv_Keywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullSemCoreView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Семантическая база";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullSemCore_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Keywords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Keywords;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.ComboBox cb_KeywordCategory;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.Label lb_KeywordCategory;
        private System.Windows.Forms.Button btn_GetKeywords;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemCoreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}