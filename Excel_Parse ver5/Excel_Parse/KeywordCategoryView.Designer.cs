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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeywordCategoryView));
            this.lb_ProductName = new System.Windows.Forms.GroupBox();
            this.tb_ProductTypeId = new System.Windows.Forms.TextBox();
            this.cb_ProductType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RefreshDGV = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lb_CategoryName = new System.Windows.Forms.Label();
            this.tb_CategoryName = new System.Windows.Forms.TextBox();
            this.dgv_KeywordCategory = new System.Windows.Forms.DataGridView();
            this.ProductTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ShownProductType = new System.Windows.Forms.ComboBox();
            this.tb_ShownProductTypes = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Help = new System.Windows.Forms.Button();
            this.lb_ProductName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeywordCategory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_ProductName
            // 
            this.lb_ProductName.Controls.Add(this.btn_Help);
            this.lb_ProductName.Controls.Add(this.tb_ProductTypeId);
            this.lb_ProductName.Controls.Add(this.cb_ProductType);
            this.lb_ProductName.Controls.Add(this.label1);
            this.lb_ProductName.Controls.Add(this.btn_RefreshDGV);
            this.lb_ProductName.Controls.Add(this.btn_Close);
            this.lb_ProductName.Controls.Add(this.btn_Save);
            this.lb_ProductName.Controls.Add(this.lb_CategoryName);
            this.lb_ProductName.Controls.Add(this.tb_CategoryName);
            this.lb_ProductName.Location = new System.Drawing.Point(5, 341);
            this.lb_ProductName.Name = "lb_ProductName";
            this.lb_ProductName.Size = new System.Drawing.Size(603, 152);
            this.lb_ProductName.TabIndex = 3;
            this.lb_ProductName.TabStop = false;
            this.lb_ProductName.Text = "Добавление новой категории ключей";
            // 
            // tb_ProductTypeId
            // 
            this.tb_ProductTypeId.Location = new System.Drawing.Point(434, 86);
            this.tb_ProductTypeId.Name = "tb_ProductTypeId";
            this.tb_ProductTypeId.Size = new System.Drawing.Size(100, 20);
            this.tb_ProductTypeId.TabIndex = 8;
            this.tb_ProductTypeId.Visible = false;
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Location = new System.Drawing.Point(325, 59);
            this.cb_ProductType.MaxDropDownItems = 25;
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(193, 21);
            this.cb_ProductType.TabIndex = 7;
            this.cb_ProductType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Вид товара";
            // 
            // btn_RefreshDGV
            // 
            this.btn_RefreshDGV.Location = new System.Drawing.Point(269, 9);
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
            this.btn_Close.Location = new System.Drawing.Point(312, 106);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(129, 30);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(160, 106);
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
            this.lb_CategoryName.Location = new System.Drawing.Point(129, 37);
            this.lb_CategoryName.Name = "lb_CategoryName";
            this.lb_CategoryName.Size = new System.Drawing.Size(112, 13);
            this.lb_CategoryName.TabIndex = 1;
            this.lb_CategoryName.Text = "Название категории";
            // 
            // tb_CategoryName
            // 
            this.tb_CategoryName.Location = new System.Drawing.Point(87, 60);
            this.tb_CategoryName.Name = "tb_CategoryName";
            this.tb_CategoryName.Size = new System.Drawing.Size(193, 20);
            this.tb_CategoryName.TabIndex = 0;
            this.tb_CategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_CategoryName_KeyDown);
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
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv_KeywordCategory.Location = new System.Drawing.Point(6, 30);
            this.dgv_KeywordCategory.MultiSelect = false;
            this.dgv_KeywordCategory.Name = "dgv_KeywordCategory";
            this.dgv_KeywordCategory.ReadOnly = true;
            this.dgv_KeywordCategory.Size = new System.Drawing.Size(602, 299);
            this.dgv_KeywordCategory.TabIndex = 2;
            this.dgv_KeywordCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KeywordCategory_CellDoubleClick);
            this.dgv_KeywordCategory.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_KeywordCategory_CellMouseClick);
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
            this.TypeName.Width = 300;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Вид товара";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Показывать категории для";
            // 
            // cb_ShownProductType
            // 
            this.cb_ShownProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ShownProductType.FormattingEnabled = true;
            this.cb_ShownProductType.Location = new System.Drawing.Point(283, 4);
            this.cb_ShownProductType.MaxDropDownItems = 25;
            this.cb_ShownProductType.Name = "cb_ShownProductType";
            this.cb_ShownProductType.Size = new System.Drawing.Size(193, 21);
            this.cb_ShownProductType.TabIndex = 5;
            this.cb_ShownProductType.SelectedIndexChanged += new System.EventHandler(this.cb_ShownProductType_SelectedIndexChanged);
            // 
            // tb_ShownProductTypes
            // 
            this.tb_ShownProductTypes.Location = new System.Drawing.Point(482, 1);
            this.tb_ShownProductTypes.Name = "tb_ShownProductTypes";
            this.tb_ShownProductTypes.Size = new System.Drawing.Size(100, 20);
            this.tb_ShownProductTypes.TabIndex = 6;
            this.tb_ShownProductTypes.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 26);
            this.contextMenuStrip1.Text = "Переименовать";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem1.Text = "Переименовать";
            // 
            // btn_Help
            // 
            this.btn_Help.Location = new System.Drawing.Point(578, 127);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(24, 24);
            this.btn_Help.TabIndex = 9;
            this.btn_Help.Text = "?";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // KeywordCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 494);
            this.Controls.Add(this.tb_ShownProductTypes);
            this.Controls.Add(this.cb_ShownProductType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_ProductName);
            this.Controls.Add(this.dgv_KeywordCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeywordCategoryView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Категории ключей - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeywordCategory_FormClosing);
            this.lb_ProductName.ResumeLayout(false);
            this.lb_ProductName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeywordCategory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox lb_ProductName;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lb_CategoryName;
        private System.Windows.Forms.TextBox tb_CategoryName;
        private System.Windows.Forms.DataGridView dgv_KeywordCategory;
        private System.Windows.Forms.Button btn_RefreshDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ProductTypeId;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ShownProductType;
        private System.Windows.Forms.TextBox tb_ShownProductTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btn_Help;
    }
}