namespace Excel_Parse
{
    partial class SemCoreView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SemCoreView));
            this.dgv_Source = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Target = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_ProductType = new System.Windows.Forms.Label();
            this.cb_ProductType = new System.Windows.Forms.ComboBox();
            this.cb_KeywordCategory = new System.Windows.Forms.ComboBox();
            this.lb_KeywordCategory = new System.Windows.Forms.Label();
            this.lb_CoreName = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgv_Categories = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_ProductTypes = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_CoreName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_AddCategory = new System.Windows.Forms.TextBox();
            this.rb_ExistingCategory = new System.Windows.Forms.RadioButton();
            this.rb_NewCategory = new System.Windows.Forms.RadioButton();
            this.btn_UploadAnotherFile = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Categories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Source
            // 
            this.dgv_Source.AllowUserToAddRows = false;
            this.dgv_Source.AllowUserToDeleteRows = false;
            this.dgv_Source.AllowUserToResizeRows = false;
            this.dgv_Source.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Source.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Source.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_Source.Location = new System.Drawing.Point(1, 1);
            this.dgv_Source.MultiSelect = false;
            this.dgv_Source.Name = "dgv_Source";
            this.dgv_Source.ReadOnly = true;
            this.dgv_Source.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Source.Size = new System.Drawing.Size(410, 832);
            this.dgv_Source.TabIndex = 0;
            this.dgv_Source.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Source_CellDoubleClick);
            this.dgv_Source.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Source_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Keyword";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dgv_Target
            // 
            this.dgv_Target.AllowUserToAddRows = false;
            this.dgv_Target.AllowUserToDeleteRows = false;
            this.dgv_Target.AllowUserToResizeRows = false;
            this.dgv_Target.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Target.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Target.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_Target.Location = new System.Drawing.Point(489, 1);
            this.dgv_Target.MultiSelect = false;
            this.dgv_Target.Name = "dgv_Target";
            this.dgv_Target.ReadOnly = true;
            this.dgv_Target.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Target.Size = new System.Drawing.Size(410, 832);
            this.dgv_Target.TabIndex = 2;
            this.dgv_Target.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Target_CellDoubleClick);
            this.dgv_Target.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Target_RowsAdded);
            this.dgv_Target.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_Target_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Keyword";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.Location = new System.Drawing.Point(942, 47);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(100, 23);
            this.lb_ProductType.TabIndex = 3;
            this.lb_ProductType.Text = "Тип продукта: ";
            this.lb_ProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Location = new System.Drawing.Point(1028, 49);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(216, 21);
            this.cb_ProductType.TabIndex = 4;
            // 
            // cb_KeywordCategory
            // 
            this.cb_KeywordCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory.FormattingEnabled = true;
            this.cb_KeywordCategory.Location = new System.Drawing.Point(1028, 142);
            this.cb_KeywordCategory.Name = "cb_KeywordCategory";
            this.cb_KeywordCategory.Size = new System.Drawing.Size(216, 21);
            this.cb_KeywordCategory.TabIndex = 6;
            // 
            // lb_KeywordCategory
            // 
            this.lb_KeywordCategory.Location = new System.Drawing.Point(918, 140);
            this.lb_KeywordCategory.Name = "lb_KeywordCategory";
            this.lb_KeywordCategory.Size = new System.Drawing.Size(124, 23);
            this.lb_KeywordCategory.TabIndex = 5;
            this.lb_KeywordCategory.Text = "Категория ключей: ";
            this.lb_KeywordCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CoreName
            // 
            this.lb_CoreName.Location = new System.Drawing.Point(939, 264);
            this.lb_CoreName.Name = "lb_CoreName";
            this.lb_CoreName.Size = new System.Drawing.Size(100, 23);
            this.lb_CoreName.TabIndex = 7;
            this.lb_CoreName.Text = "Название ядра: ";
            this.lb_CoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(955, 348);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 34);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(1109, 348);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(135, 34);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Закрыть";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgv_Categories
            // 
            this.dgv_Categories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Categories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dgv_Categories.Location = new System.Drawing.Point(954, 511);
            this.dgv_Categories.Name = "dgv_Categories";
            this.dgv_Categories.Size = new System.Drawing.Size(240, 150);
            this.dgv_Categories.TabIndex = 11;
            this.dgv_Categories.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // dgv_ProductTypes
            // 
            this.dgv_ProductTypes.AllowUserToDeleteRows = false;
            this.dgv_ProductTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProductTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dgv_ProductTypes.Location = new System.Drawing.Point(1028, 533);
            this.dgv_ProductTypes.Name = "dgv_ProductTypes";
            this.dgv_ProductTypes.Size = new System.Drawing.Size(240, 150);
            this.dgv_ProductTypes.TabIndex = 12;
            this.dgv_ProductTypes.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // tb_CoreName
            // 
            this.tb_CoreName.Location = new System.Drawing.Point(1028, 266);
            this.tb_CoreName.Name = "tb_CoreName";
            this.tb_CoreName.Size = new System.Drawing.Size(216, 20);
            this.tb_CoreName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(911, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Добавить категорию: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_AddCategory
            // 
            this.tb_AddCategory.Enabled = false;
            this.tb_AddCategory.Location = new System.Drawing.Point(1028, 177);
            this.tb_AddCategory.Name = "tb_AddCategory";
            this.tb_AddCategory.Size = new System.Drawing.Size(216, 20);
            this.tb_AddCategory.TabIndex = 15;
            // 
            // rb_ExistingCategory
            // 
            this.rb_ExistingCategory.AutoSize = true;
            this.rb_ExistingCategory.Checked = true;
            this.rb_ExistingCategory.Location = new System.Drawing.Point(1251, 147);
            this.rb_ExistingCategory.Name = "rb_ExistingCategory";
            this.rb_ExistingCategory.Size = new System.Drawing.Size(14, 13);
            this.rb_ExistingCategory.TabIndex = 16;
            this.rb_ExistingCategory.TabStop = true;
            this.rb_ExistingCategory.UseVisualStyleBackColor = true;
            this.rb_ExistingCategory.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_NewCategory
            // 
            this.rb_NewCategory.AutoSize = true;
            this.rb_NewCategory.Location = new System.Drawing.Point(1251, 181);
            this.rb_NewCategory.Name = "rb_NewCategory";
            this.rb_NewCategory.Size = new System.Drawing.Size(14, 13);
            this.rb_NewCategory.TabIndex = 17;
            this.rb_NewCategory.UseVisualStyleBackColor = true;
            this.rb_NewCategory.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // btn_UploadAnotherFile
            // 
            this.btn_UploadAnotherFile.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_UploadAnotherFile.FlatAppearance.BorderSize = 0;
            this.btn_UploadAnotherFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_UploadAnotherFile.Location = new System.Drawing.Point(955, 479);
            this.btn_UploadAnotherFile.Name = "btn_UploadAnotherFile";
            this.btn_UploadAnotherFile.Size = new System.Drawing.Size(289, 74);
            this.btn_UploadAnotherFile.TabIndex = 18;
            this.btn_UploadAnotherFile.Text = "Загрузить другой файл";
            this.btn_UploadAnotherFile.UseVisualStyleBackColor = false;
            this.btn_UploadAnotherFile.Click += new System.EventHandler(this.btn_UploadAnotherFile_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.Location = new System.Drawing.Point(1045, 792);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(109, 29);
            this.btn_Help.TabIndex = 19;
            this.btn_Help.Text = "Помощь";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // tb_Link
            // 
            this.tb_Link.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Link.Enabled = false;
            this.tb_Link.Location = new System.Drawing.Point(946, 766);
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(305, 20);
            this.tb_Link.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(926, 769);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SemCore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 826);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tb_Link);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.btn_UploadAnotherFile);
            this.Controls.Add(this.rb_NewCategory);
            this.Controls.Add(this.rb_ExistingCategory);
            this.Controls.Add(this.tb_AddCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_CoreName);
            this.Controls.Add(this.dgv_ProductTypes);
            this.Controls.Add(this.dgv_Categories);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lb_CoreName);
            this.Controls.Add(this.cb_KeywordCategory);
            this.Controls.Add(this.lb_KeywordCategory);
            this.Controls.Add(this.cb_ProductType);
            this.Controls.Add(this.lb_ProductType);
            this.Controls.Add(this.dgv_Target);
            this.Controls.Add(this.dgv_Source);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SemCore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сбор семантического ядра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemCore_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Categories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dgv_Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.ComboBox cb_KeywordCategory;
        private System.Windows.Forms.Label lb_KeywordCategory;
        private System.Windows.Forms.Label lb_CoreName;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgv_Categories;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridView dgv_ProductTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox tb_CoreName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_AddCategory;
        private System.Windows.Forms.RadioButton rb_ExistingCategory;
        private System.Windows.Forms.RadioButton rb_NewCategory;
        private System.Windows.Forms.Button btn_UploadAnotherFile;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.TextBox tb_Link;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

