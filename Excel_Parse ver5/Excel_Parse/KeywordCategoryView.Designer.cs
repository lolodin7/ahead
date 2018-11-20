namespace Excel_Parse
{
    partial class KeywordCategoryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeywordCategoryView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_RefreshDGV = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lb_CategoryName = new System.Windows.Forms.Label();
            this.tb_CategoryName = new System.Windows.Forms.TextBox();
            this.dgv_KeywordCategory = new System.Windows.Forms.DataGridView();
            this.ProductTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeywordCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_RefreshDGV);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.lb_CategoryName);
            this.groupBox1.Controls.Add(this.tb_CategoryName);
            this.groupBox1.Location = new System.Drawing.Point(6, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 152);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление новой категории ключей";
            // 
            // btn_RefreshDGV
            // 
            this.btn_RefreshDGV.Location = new System.Drawing.Point(227, 9);
            this.btn_RefreshDGV.Name = "btn_RefreshDGV";
            this.btn_RefreshDGV.Size = new System.Drawing.Size(64, 26);
            this.btn_RefreshDGV.TabIndex = 4;
            this.btn_RefreshDGV.Text = "Обновить";
            this.btn_RefreshDGV.UseVisualStyleBackColor = true;
            this.btn_RefreshDGV.Click += new System.EventHandler(this.btn_RefreshDGV_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Location = new System.Drawing.Point(158, 106);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(129, 30);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
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
            // lb_CategoryName
            // 
            this.lb_CategoryName.AutoSize = true;
            this.lb_CategoryName.Location = new System.Drawing.Point(86, 33);
            this.lb_CategoryName.Name = "lb_CategoryName";
            this.lb_CategoryName.Size = new System.Drawing.Size(112, 13);
            this.lb_CategoryName.TabIndex = 1;
            this.lb_CategoryName.Text = "Название категории";
            // 
            // tb_CategoryName
            // 
            this.tb_CategoryName.Location = new System.Drawing.Point(45, 60);
            this.tb_CategoryName.Name = "tb_CategoryName";
            this.tb_CategoryName.Size = new System.Drawing.Size(193, 20);
            this.tb_CategoryName.TabIndex = 0;
            // 
            // dgv_KeywordCategory
            // 
            this.dgv_KeywordCategory.AllowUserToAddRows = false;
            this.dgv_KeywordCategory.AllowUserToDeleteRows = false;
            this.dgv_KeywordCategory.AllowUserToResizeColumns = false;
            this.dgv_KeywordCategory.AllowUserToResizeRows = false;
            this.dgv_KeywordCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_KeywordCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductTypeId,
            this.TypeName,
            this.Column1});
            this.dgv_KeywordCategory.Location = new System.Drawing.Point(6, 5);
            this.dgv_KeywordCategory.MultiSelect = false;
            this.dgv_KeywordCategory.Name = "dgv_KeywordCategory";
            this.dgv_KeywordCategory.ReadOnly = true;
            this.dgv_KeywordCategory.Size = new System.Drawing.Size(293, 324);
            this.dgv_KeywordCategory.TabIndex = 2;
            this.dgv_KeywordCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KeywordCategory_CellDoubleClick);
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
            this.TypeName.HeaderText = "Название категории";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TypeName.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // KeywordCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_KeywordCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeywordCategoryView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Категории ключей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeywordCategory_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeywordCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lb_CategoryName;
        private System.Windows.Forms.TextBox tb_CategoryName;
        private System.Windows.Forms.DataGridView dgv_KeywordCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btn_RefreshDGV;
    }
}