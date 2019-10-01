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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_UploadAnotherFile = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_MarketPlaceId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Marketplace = new System.Windows.Forms.ComboBox();
            this.gp_Delimiters = new System.Windows.Forms.GroupBox();
            this.tb_OwnDelimiter = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddCustomKeyword = new System.Windows.Forms.Button();
            this.tb_CustomValue = new System.Windows.Forms.TextBox();
            this.tb_CustomKey = new System.Windows.Forms.TextBox();
            this.btn_addKeywordCategory = new System.Windows.Forms.Button();
            this.tb_ProductTypeId = new System.Windows.Forms.TextBox();
            this.btn_DeselectAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gp_Delimiters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Source
            // 
            this.dgv_Source.AllowUserToAddRows = false;
            this.dgv_Source.AllowUserToDeleteRows = false;
            this.dgv_Source.AllowUserToResizeRows = false;
            this.dgv_Source.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Source.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Source.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Source.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_Source.Location = new System.Drawing.Point(1, 6);
            this.dgv_Source.MultiSelect = false;
            this.dgv_Source.Name = "dgv_Source";
            this.dgv_Source.ReadOnly = true;
            this.dgv_Source.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Source.Size = new System.Drawing.Size(410, 827);
            this.dgv_Source.TabIndex = 0;
            this.dgv_Source.Visible = false;
            this.dgv_Source.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Source_CellDoubleClick);
            this.dgv_Source.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Source_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Keyword";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 270;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_Target
            // 
            this.dgv_Target.AllowUserToAddRows = false;
            this.dgv_Target.AllowUserToDeleteRows = false;
            this.dgv_Target.AllowUserToResizeRows = false;
            this.dgv_Target.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Target.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Target.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Target.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_Target.Location = new System.Drawing.Point(494, 6);
            this.dgv_Target.MultiSelect = false;
            this.dgv_Target.Name = "dgv_Target";
            this.dgv_Target.ReadOnly = true;
            this.dgv_Target.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Target.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Target.Size = new System.Drawing.Size(410, 827);
            this.dgv_Target.TabIndex = 2;
            this.dgv_Target.Visible = false;
            this.dgv_Target.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Target_CellDoubleClick);
            this.dgv_Target.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Target_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Keyword";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 270;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.Location = new System.Drawing.Point(67, 163);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(107, 23);
            this.lb_ProductType.TabIndex = 3;
            this.lb_ProductType.Text = "Тип продукта: ";
            this.lb_ProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Location = new System.Drawing.Point(9, 189);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(216, 21);
            this.cb_ProductType.TabIndex = 4;
            this.cb_ProductType.SelectedIndexChanged += new System.EventHandler(this.cb_ProductType_SelectedIndexChanged);
            // 
            // cb_KeywordCategory
            // 
            this.cb_KeywordCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory.FormattingEnabled = true;
            this.cb_KeywordCategory.Location = new System.Drawing.Point(9, 267);
            this.cb_KeywordCategory.Name = "cb_KeywordCategory";
            this.cb_KeywordCategory.Size = new System.Drawing.Size(216, 21);
            this.cb_KeywordCategory.TabIndex = 6;
            // 
            // lb_KeywordCategory
            // 
            this.lb_KeywordCategory.Location = new System.Drawing.Point(53, 241);
            this.lb_KeywordCategory.Name = "lb_KeywordCategory";
            this.lb_KeywordCategory.Size = new System.Drawing.Size(133, 23);
            this.lb_KeywordCategory.TabIndex = 5;
            this.lb_KeywordCategory.Text = "Категория ключей:";
            this.lb_KeywordCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.LightGray;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(9, 433);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(248, 65);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(417, 374);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 44);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Закрыть";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_UploadAnotherFile
            // 
            this.btn_UploadAnotherFile.BackColor = System.Drawing.Color.LightGray;
            this.btn_UploadAnotherFile.FlatAppearance.BorderSize = 0;
            this.btn_UploadAnotherFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UploadAnotherFile.Location = new System.Drawing.Point(6, 64);
            this.btn_UploadAnotherFile.Name = "btn_UploadAnotherFile";
            this.btn_UploadAnotherFile.Size = new System.Drawing.Size(137, 71);
            this.btn_UploadAnotherFile.TabIndex = 18;
            this.btn_UploadAnotherFile.Text = "Загрузить файл";
            this.btn_UploadAnotherFile.UseVisualStyleBackColor = false;
            this.btn_UploadAnotherFile.Click += new System.EventHandler(this.btn_UploadAnotherFile_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Help.FlatAppearance.BorderSize = 0;
            this.btn_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Help.Location = new System.Drawing.Point(234, 9);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(24, 24);
            this.btn_Help.TabIndex = 19;
            this.btn_Help.Text = "?";
            this.btn_Help.UseVisualStyleBackColor = false;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // tb_Link
            // 
            this.tb_Link.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Link.Enabled = false;
            this.tb_Link.Location = new System.Drawing.Point(35, 804);
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(219, 22);
            this.tb_Link.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 807);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_MarketPlaceId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_Marketplace);
            this.groupBox1.Controls.Add(this.gp_Delimiters);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tb_Link);
            this.groupBox1.Controls.Add(this.btn_addKeywordCategory);
            this.groupBox1.Controls.Add(this.btn_UploadAnotherFile);
            this.groupBox1.Controls.Add(this.btn_Help);
            this.groupBox1.Controls.Add(this.tb_ProductTypeId);
            this.groupBox1.Controls.Add(this.lb_ProductType);
            this.groupBox1.Controls.Add(this.cb_ProductType);
            this.groupBox1.Controls.Add(this.lb_KeywordCategory);
            this.groupBox1.Controls.Add(this.cb_KeywordCategory);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Location = new System.Drawing.Point(918, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 832);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // tb_MarketPlaceId
            // 
            this.tb_MarketPlaceId.Location = new System.Drawing.Point(327, 216);
            this.tb_MarketPlaceId.Name = "tb_MarketPlaceId";
            this.tb_MarketPlaceId.Size = new System.Drawing.Size(100, 22);
            this.tb_MarketPlaceId.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(67, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Маркетплейс";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Marketplace
            // 
            this.cb_Marketplace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Marketplace.FormattingEnabled = true;
            this.cb_Marketplace.Location = new System.Drawing.Point(9, 341);
            this.cb_Marketplace.Name = "cb_Marketplace";
            this.cb_Marketplace.Size = new System.Drawing.Size(216, 21);
            this.cb_Marketplace.TabIndex = 28;
            this.cb_Marketplace.SelectedIndexChanged += new System.EventHandler(this.Cb_Marketplace_SelectedIndexChanged);
            // 
            // gp_Delimiters
            // 
            this.gp_Delimiters.Controls.Add(this.tb_OwnDelimiter);
            this.gp_Delimiters.Controls.Add(this.radioButton2);
            this.gp_Delimiters.Controls.Add(this.radioButton1);
            this.gp_Delimiters.Location = new System.Drawing.Point(149, 64);
            this.gp_Delimiters.Name = "gp_Delimiters";
            this.gp_Delimiters.Size = new System.Drawing.Size(93, 71);
            this.gp_Delimiters.TabIndex = 26;
            this.gp_Delimiters.TabStop = false;
            this.gp_Delimiters.Text = "Разделитель";
            // 
            // tb_OwnDelimiter
            // 
            this.tb_OwnDelimiter.Location = new System.Drawing.Point(6, 46);
            this.tb_OwnDelimiter.Name = "tb_OwnDelimiter";
            this.tb_OwnDelimiter.Size = new System.Drawing.Size(81, 22);
            this.tb_OwnDelimiter.TabIndex = 2;
            this.tb_OwnDelimiter.TextChanged += new System.EventHandler(this.tb_OwnDelimiter_TextChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(56, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(31, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = ";";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(31, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = ",";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_AddCustomKeyword);
            this.groupBox2.Controls.Add(this.tb_CustomValue);
            this.groupBox2.Controls.Add(this.tb_CustomKey);
            this.groupBox2.Location = new System.Drawing.Point(9, 565);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 188);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавить ключ вручную";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Частота";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Название ключа";
            // 
            // btn_AddCustomKeyword
            // 
            this.btn_AddCustomKeyword.Location = new System.Drawing.Point(35, 132);
            this.btn_AddCustomKeyword.Name = "btn_AddCustomKeyword";
            this.btn_AddCustomKeyword.Size = new System.Drawing.Size(176, 42);
            this.btn_AddCustomKeyword.TabIndex = 25;
            this.btn_AddCustomKeyword.Text = "Добавить";
            this.btn_AddCustomKeyword.UseVisualStyleBackColor = true;
            this.btn_AddCustomKeyword.Click += new System.EventHandler(this.btn_AddCustomKeyword_Click);
            // 
            // tb_CustomValue
            // 
            this.tb_CustomValue.Location = new System.Drawing.Point(87, 94);
            this.tb_CustomValue.Name = "tb_CustomValue";
            this.tb_CustomValue.Size = new System.Drawing.Size(73, 22);
            this.tb_CustomValue.TabIndex = 24;
            this.tb_CustomValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_CustomValue_KeyPress);
            // 
            // tb_CustomKey
            // 
            this.tb_CustomKey.Location = new System.Drawing.Point(15, 50);
            this.tb_CustomKey.Name = "tb_CustomKey";
            this.tb_CustomKey.Size = new System.Drawing.Size(213, 22);
            this.tb_CustomKey.TabIndex = 23;
            // 
            // btn_addKeywordCategory
            // 
            this.btn_addKeywordCategory.Location = new System.Drawing.Point(231, 267);
            this.btn_addKeywordCategory.Name = "btn_addKeywordCategory";
            this.btn_addKeywordCategory.Size = new System.Drawing.Size(23, 22);
            this.btn_addKeywordCategory.TabIndex = 22;
            this.btn_addKeywordCategory.Text = "+";
            this.btn_addKeywordCategory.UseVisualStyleBackColor = true;
            this.btn_addKeywordCategory.Click += new System.EventHandler(this.btn_addKeywordCategory_Click);
            // 
            // tb_ProductTypeId
            // 
            this.tb_ProductTypeId.Location = new System.Drawing.Point(380, 164);
            this.tb_ProductTypeId.Name = "tb_ProductTypeId";
            this.tb_ProductTypeId.Size = new System.Drawing.Size(74, 22);
            this.tb_ProductTypeId.TabIndex = 21;
            this.tb_ProductTypeId.Visible = false;
            // 
            // btn_DeselectAll
            // 
            this.btn_DeselectAll.Location = new System.Drawing.Point(413, 233);
            this.btn_DeselectAll.Name = "btn_DeselectAll";
            this.btn_DeselectAll.Size = new System.Drawing.Size(79, 56);
            this.btn_DeselectAll.TabIndex = 20;
            this.btn_DeselectAll.Text = "Снять выделение";
            this.btn_DeselectAll.UseVisualStyleBackColor = true;
            this.btn_DeselectAll.Visible = false;
            this.btn_DeselectAll.Click += new System.EventHandler(this.btn_DeselectAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Location = new System.Drawing.Point(413, 171);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(79, 56);
            this.btn_SelectAll.TabIndex = 19;
            this.btn_SelectAll.Text = "Выделить всё";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Visible = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(152, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(623, 145);
            this.label3.TabIndex = 23;
            this.label3.Text = "Чтобы начать, нажмите \"Загрузить файл\"";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.Location = new System.Drawing.Point(413, 296);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(79, 56);
            this.btn_ClearAll.TabIndex = 24;
            this.btn_ClearAll.Text = "Очистить всё";
            this.btn_ClearAll.UseVisualStyleBackColor = true;
            this.btn_ClearAll.Visible = false;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // SemCoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 839);
            this.Controls.Add(this.btn_ClearAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_SelectAll);
            this.Controls.Add(this.btn_DeselectAll);
            this.Controls.Add(this.dgv_Target);
            this.Controls.Add(this.dgv_Source);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SemCoreView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сбор семантического ядра - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemCore_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gp_Delimiters.ResumeLayout(false);
            this.gp_Delimiters.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Source;
        private System.Windows.Forms.DataGridView dgv_Target;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.ComboBox cb_KeywordCategory;
        private System.Windows.Forms.Label lb_KeywordCategory;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_UploadAnotherFile;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.TextBox tb_Link;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_DeselectAll;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.TextBox tb_ProductTypeId;
        private System.Windows.Forms.Button btn_addKeywordCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_AddCustomKeyword;
        private System.Windows.Forms.TextBox tb_CustomValue;
        private System.Windows.Forms.TextBox tb_CustomKey;
        private System.Windows.Forms.GroupBox gp_Delimiters;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox tb_OwnDelimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btn_ClearAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_Marketplace;
        private System.Windows.Forms.TextBox tb_MarketPlaceId;
    }
}

