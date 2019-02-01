namespace Excel_Parse
{
    partial class SemCoreRebuildView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SemCoreRebuildView));
            this.cb_KeywordCategory = new System.Windows.Forms.ComboBox();
            this.lb_KeywordCategory = new System.Windows.Forms.Label();
            this.cb_ProductType = new System.Windows.Forms.ComboBox();
            this.lb_ProductType = new System.Windows.Forms.Label();
            this.btn_UploadFile = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.dgv_Source = new System.Windows.Forms.DataGridView();
            this.dgv_Target = new System.Windows.Forms.DataGridView();
            this.lb_UploadedKeys = new System.Windows.Forms.Label();
            this.lb_UpdatedKeys = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.tb_OwnDelimiter = new System.Windows.Forms.TextBox();
            this.btn_Help = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.btn_AddCategory = new System.Windows.Forms.Button();
            this.btn_KeysAreDone = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.btn_DeselectAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_KeywordCategory
            // 
            this.cb_KeywordCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory.FormattingEnabled = true;
            this.cb_KeywordCategory.Location = new System.Drawing.Point(6, 449);
            this.cb_KeywordCategory.Name = "cb_KeywordCategory";
            this.cb_KeywordCategory.Size = new System.Drawing.Size(216, 21);
            this.cb_KeywordCategory.TabIndex = 10;
            // 
            // lb_KeywordCategory
            // 
            this.lb_KeywordCategory.Location = new System.Drawing.Point(52, 423);
            this.lb_KeywordCategory.Name = "lb_KeywordCategory";
            this.lb_KeywordCategory.Size = new System.Drawing.Size(109, 23);
            this.lb_KeywordCategory.TabIndex = 9;
            this.lb_KeywordCategory.Text = "Категория ключей: ";
            this.lb_KeywordCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Location = new System.Drawing.Point(6, 389);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(216, 21);
            this.cb_ProductType.TabIndex = 8;
            this.cb_ProductType.SelectedIndexChanged += new System.EventHandler(this.cb_ProductType_SelectedIndexChanged);
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.Location = new System.Drawing.Point(61, 363);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(87, 23);
            this.lb_ProductType.TabIndex = 7;
            this.lb_ProductType.Text = "Тип продукта: ";
            this.lb_ProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_UploadFile
            // 
            this.btn_UploadFile.BackColor = System.Drawing.Color.LightGray;
            this.btn_UploadFile.FlatAppearance.BorderSize = 0;
            this.btn_UploadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UploadFile.Location = new System.Drawing.Point(6, 43);
            this.btn_UploadFile.Name = "btn_UploadFile";
            this.btn_UploadFile.Size = new System.Drawing.Size(260, 76);
            this.btn_UploadFile.TabIndex = 11;
            this.btn_UploadFile.Text = "Загрузить файл";
            this.btn_UploadFile.UseVisualStyleBackColor = false;
            this.btn_UploadFile.Click += new System.EventHandler(this.btn_UploadFile_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.BackColor = System.Drawing.Color.LightGray;
            this.btn_Clean.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.Location = new System.Drawing.Point(155, 248);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(106, 89);
            this.btn_Clean.TabIndex = 13;
            this.btn_Clean.Text = "Очистить всё";
            this.btn_Clean.UseVisualStyleBackColor = false;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // btn_Begin
            // 
            this.btn_Begin.BackColor = System.Drawing.Color.Silver;
            this.btn_Begin.Enabled = false;
            this.btn_Begin.FlatAppearance.BorderSize = 0;
            this.btn_Begin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Begin.Location = new System.Drawing.Point(6, 543);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(260, 76);
            this.btn_Begin.TabIndex = 14;
            this.btn_Begin.Text = "Запуск";
            this.btn_Begin.UseVisualStyleBackColor = false;
            this.btn_Begin.EnabledChanged += new System.EventHandler(this.btn_Begin_EnabledChanged);
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // dgv_Source
            // 
            this.dgv_Source.AllowUserToAddRows = false;
            this.dgv_Source.AllowUserToDeleteRows = false;
            this.dgv_Source.AllowUserToResizeColumns = false;
            this.dgv_Source.AllowUserToResizeRows = false;
            this.dgv_Source.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Source.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Source.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_Source.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Source.Location = new System.Drawing.Point(2, 26);
            this.dgv_Source.MultiSelect = false;
            this.dgv_Source.Name = "dgv_Source";
            this.dgv_Source.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_Source.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Source.Size = new System.Drawing.Size(410, 807);
            this.dgv_Source.TabIndex = 15;
            this.dgv_Source.Visible = false;
            this.dgv_Source.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Source_CellDoubleClick);
            this.dgv_Source.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Source_RowsAdded);
            this.dgv_Source.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_Source_RowsRemoved);
            this.dgv_Source.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Source_KeyDown);
            // 
            // dgv_Target
            // 
            this.dgv_Target.AllowUserToAddRows = false;
            this.dgv_Target.AllowUserToDeleteRows = false;
            this.dgv_Target.AllowUserToResizeColumns = false;
            this.dgv_Target.AllowUserToResizeRows = false;
            this.dgv_Target.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Target.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Target.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_Target.Location = new System.Drawing.Point(495, 26);
            this.dgv_Target.MultiSelect = false;
            this.dgv_Target.Name = "dgv_Target";
            this.dgv_Target.ReadOnly = true;
            this.dgv_Target.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_Target.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Target.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Target.Size = new System.Drawing.Size(410, 807);
            this.dgv_Target.TabIndex = 16;
            this.dgv_Target.Visible = false;
            this.dgv_Target.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Target_CellDoubleClick);
            this.dgv_Target.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Target_RowsAdded);
            this.dgv_Target.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_Target_RowsRemoved);
            // 
            // lb_UploadedKeys
            // 
            this.lb_UploadedKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_UploadedKeys.Location = new System.Drawing.Point(12, 1);
            this.lb_UploadedKeys.Name = "lb_UploadedKeys";
            this.lb_UploadedKeys.Size = new System.Drawing.Size(388, 23);
            this.lb_UploadedKeys.TabIndex = 17;
            this.lb_UploadedKeys.Text = "Новые ключи";
            this.lb_UploadedKeys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_UploadedKeys.Visible = false;
            // 
            // lb_UpdatedKeys
            // 
            this.lb_UpdatedKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_UpdatedKeys.Location = new System.Drawing.Point(507, 1);
            this.lb_UpdatedKeys.Name = "lb_UpdatedKeys";
            this.lb_UpdatedKeys.Size = new System.Drawing.Size(385, 23);
            this.lb_UpdatedKeys.TabIndex = 18;
            this.lb_UpdatedKeys.Text = "Обновленные ключи";
            this.lb_UpdatedKeys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_UpdatedKeys.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_Help);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.tb_Link);
            this.groupBox1.Controls.Add(this.btn_AddCategory);
            this.groupBox1.Controls.Add(this.btn_KeysAreDone);
            this.groupBox1.Controls.Add(this.lb_ProductType);
            this.groupBox1.Controls.Add(this.cb_ProductType);
            this.groupBox1.Controls.Add(this.lb_KeywordCategory);
            this.groupBox1.Controls.Add(this.cb_KeywordCategory);
            this.groupBox1.Controls.Add(this.btn_UploadFile);
            this.groupBox1.Controls.Add(this.btn_Begin);
            this.groupBox1.Controls.Add(this.btn_Clean);
            this.groupBox1.Location = new System.Drawing.Point(911, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 830);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.tb_OwnDelimiter);
            this.groupBox2.Location = new System.Drawing.Point(91, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(93, 67);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Разделитель";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(6, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(31, 24);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = ",";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(54, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(31, 24);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = ";";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // tb_OwnDelimiter
            // 
            this.tb_OwnDelimiter.Location = new System.Drawing.Point(6, 41);
            this.tb_OwnDelimiter.Name = "tb_OwnDelimiter";
            this.tb_OwnDelimiter.Size = new System.Drawing.Size(79, 20);
            this.tb_OwnDelimiter.TabIndex = 19;
            this.tb_OwnDelimiter.TextChanged += new System.EventHandler(this.tb_OwnDelimiter_TextChanged);
            // 
            // btn_Help
            // 
            this.btn_Help.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Help.FlatAppearance.BorderSize = 0;
            this.btn_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Help.Location = new System.Drawing.Point(245, 9);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(24, 24);
            this.btn_Help.TabIndex = 28;
            this.btn_Help.Text = "?";
            this.btn_Help.UseVisualStyleBackColor = false;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 807);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tb_Link
            // 
            this.tb_Link.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Link.Enabled = false;
            this.tb_Link.Location = new System.Drawing.Point(23, 804);
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(243, 20);
            this.tb_Link.TabIndex = 26;
            this.tb_Link.Text = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=";
            // 
            // btn_AddCategory
            // 
            this.btn_AddCategory.FlatAppearance.BorderSize = 0;
            this.btn_AddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddCategory.Location = new System.Drawing.Point(228, 448);
            this.btn_AddCategory.Name = "btn_AddCategory";
            this.btn_AddCategory.Size = new System.Drawing.Size(21, 21);
            this.btn_AddCategory.TabIndex = 16;
            this.btn_AddCategory.Text = "+";
            this.btn_AddCategory.UseVisualStyleBackColor = true;
            this.btn_AddCategory.Click += new System.EventHandler(this.btn_AddCategory_Click);
            // 
            // btn_KeysAreDone
            // 
            this.btn_KeysAreDone.BackColor = System.Drawing.Color.LightGray;
            this.btn_KeysAreDone.Enabled = false;
            this.btn_KeysAreDone.FlatAppearance.BorderSize = 0;
            this.btn_KeysAreDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_KeysAreDone.Location = new System.Drawing.Point(23, 248);
            this.btn_KeysAreDone.Name = "btn_KeysAreDone";
            this.btn_KeysAreDone.Size = new System.Drawing.Size(106, 89);
            this.btn_KeysAreDone.TabIndex = 15;
            this.btn_KeysAreDone.Text = "Отметить ключи";
            this.btn_KeysAreDone.UseVisualStyleBackColor = false;
            this.btn_KeysAreDone.EnabledChanged += new System.EventHandler(this.btn_KeysAreDone_EnabledChanged);
            this.btn_KeysAreDone.Click += new System.EventHandler(this.btn_KeysAreDone_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Location = new System.Drawing.Point(414, 172);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(79, 56);
            this.btn_SelectAll.TabIndex = 21;
            this.btn_SelectAll.Text = "Выделить всё";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Visible = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_CheckAll_Click);
            // 
            // btn_DeselectAll
            // 
            this.btn_DeselectAll.Location = new System.Drawing.Point(414, 234);
            this.btn_DeselectAll.Name = "btn_DeselectAll";
            this.btn_DeselectAll.Size = new System.Drawing.Size(79, 56);
            this.btn_DeselectAll.TabIndex = 22;
            this.btn_DeselectAll.Text = "Очистить";
            this.btn_DeselectAll.UseVisualStyleBackColor = true;
            this.btn_DeselectAll.Visible = false;
            this.btn_DeselectAll.Click += new System.EventHandler(this.btn_UnChekAll_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(71, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(759, 163);
            this.label1.TabIndex = 23;
            this.label1.Text = "Чтобы начать, нажмите \"Загрузить файл\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 136.2398F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ключ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 270;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 63.76023F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Частота";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 117;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 136.2398F;
            this.Column1.HeaderText = "Ключ";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 270;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 63.76023F;
            this.Column2.HeaderText = "Частота";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 117;
            // 
            // SemCoreRebuildView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 839);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SelectAll);
            this.Controls.Add(this.btn_DeselectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_UpdatedKeys);
            this.Controls.Add(this.lb_UploadedKeys);
            this.Controls.Add(this.dgv_Target);
            this.Controls.Add(this.dgv_Source);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SemCoreRebuildView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение семантического ядра - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemCoreRebuild_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.SemCoreRebuild_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_KeywordCategory;
        private System.Windows.Forms.Label lb_KeywordCategory;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.Button btn_UploadFile;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Button btn_Begin;
        private System.Windows.Forms.DataGridView dgv_Source;
        private System.Windows.Forms.DataGridView dgv_Target;
        private System.Windows.Forms.Label lb_UploadedKeys;
        private System.Windows.Forms.Label lb_UpdatedKeys;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_KeysAreDone;
        private System.Windows.Forms.Button btn_AddCategory;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tb_Link;
        private System.Windows.Forms.TextBox tb_OwnDelimiter;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button btn_DeselectAll;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}