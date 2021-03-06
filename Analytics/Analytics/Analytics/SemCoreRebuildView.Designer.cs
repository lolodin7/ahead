﻿namespace Excel_Parse
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
            this.dgv_NewKeys = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_CheckAll = new System.Windows.Forms.Button();
            this.btn_UnChekAll = new System.Windows.Forms.Button();
            this.btn_AddCategory = new System.Windows.Forms.Button();
            this.btn_KeysAreDone = new System.Windows.Forms.Button();
            this.lb_NewKeys = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_KeywordsInCategory = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTypeIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemCoreIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keywordclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastupdatedclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NewKeys)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeywordsInCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_KeywordCategory
            // 
            this.cb_KeywordCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory.FormattingEnabled = true;
            this.cb_KeywordCategory.Location = new System.Drawing.Point(120, 75);
            this.cb_KeywordCategory.Name = "cb_KeywordCategory";
            this.cb_KeywordCategory.Size = new System.Drawing.Size(187, 21);
            this.cb_KeywordCategory.TabIndex = 10;
            this.cb_KeywordCategory.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lb_KeywordCategory
            // 
            this.lb_KeywordCategory.Location = new System.Drawing.Point(5, 73);
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
            this.cb_ProductType.Location = new System.Drawing.Point(120, 22);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(187, 21);
            this.cb_ProductType.TabIndex = 8;
            this.cb_ProductType.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.Location = new System.Drawing.Point(27, 20);
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
            this.btn_UploadFile.Location = new System.Drawing.Point(345, 11);
            this.btn_UploadFile.Name = "btn_UploadFile";
            this.btn_UploadFile.Size = new System.Drawing.Size(160, 41);
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
            this.btn_Clean.Location = new System.Drawing.Point(606, 64);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(113, 41);
            this.btn_Clean.TabIndex = 13;
            this.btn_Clean.Text = "Очистить всё";
            this.btn_Clean.UseVisualStyleBackColor = false;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // btn_Begin
            // 
            this.btn_Begin.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Begin.Enabled = false;
            this.btn_Begin.FlatAppearance.BorderSize = 0;
            this.btn_Begin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Begin.Location = new System.Drawing.Point(584, 11);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(160, 41);
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
            this.dgv_Source.Location = new System.Drawing.Point(12, 152);
            this.dgv_Source.MultiSelect = false;
            this.dgv_Source.Name = "dgv_Source";
            this.dgv_Source.ReadOnly = true;
            this.dgv_Source.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Source.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_Source.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Source.Size = new System.Drawing.Size(388, 662);
            this.dgv_Source.TabIndex = 15;
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
            this.ProductTypeIdCol,
            this.CategoryIdCol,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.LastUpdated,
            this.SemCoreIdCol});
            this.dgv_Target.Location = new System.Drawing.Point(410, 152);
            this.dgv_Target.MultiSelect = false;
            this.dgv_Target.Name = "dgv_Target";
            this.dgv_Target.ReadOnly = true;
            this.dgv_Target.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Target.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_Target.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Target.Size = new System.Drawing.Size(389, 662);
            this.dgv_Target.TabIndex = 16;
            this.dgv_Target.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Target_RowsAdded);
            this.dgv_Target.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_Target_RowsRemoved);
            // 
            // lb_UploadedKeys
            // 
            this.lb_UploadedKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_UploadedKeys.Location = new System.Drawing.Point(12, 126);
            this.lb_UploadedKeys.Name = "lb_UploadedKeys";
            this.lb_UploadedKeys.Size = new System.Drawing.Size(388, 23);
            this.lb_UploadedKeys.TabIndex = 17;
            this.lb_UploadedKeys.Text = "Загруженные ключи";
            this.lb_UploadedKeys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_UpdatedKeys
            // 
            this.lb_UpdatedKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_UpdatedKeys.Location = new System.Drawing.Point(414, 126);
            this.lb_UpdatedKeys.Name = "lb_UpdatedKeys";
            this.lb_UpdatedKeys.Size = new System.Drawing.Size(385, 23);
            this.lb_UpdatedKeys.TabIndex = 18;
            this.lb_UpdatedKeys.Text = "Обновленные ключи";
            this.lb_UpdatedKeys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgv_NewKeys
            // 
            this.dgv_NewKeys.AllowUserToAddRows = false;
            this.dgv_NewKeys.AllowUserToDeleteRows = false;
            this.dgv_NewKeys.AllowUserToResizeColumns = false;
            this.dgv_NewKeys.AllowUserToResizeRows = false;
            this.dgv_NewKeys.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_NewKeys.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_NewKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NewKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column17,
            this.Column18});
            this.dgv_NewKeys.Location = new System.Drawing.Point(809, 37);
            this.dgv_NewKeys.MultiSelect = false;
            this.dgv_NewKeys.Name = "dgv_NewKeys";
            this.dgv_NewKeys.ReadOnly = true;
            this.dgv_NewKeys.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_NewKeys.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_NewKeys.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NewKeys.Size = new System.Drawing.Size(419, 391);
            this.dgv_NewKeys.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AddCategory);
            this.groupBox1.Controls.Add(this.btn_KeysAreDone);
            this.groupBox1.Controls.Add(this.lb_ProductType);
            this.groupBox1.Controls.Add(this.cb_ProductType);
            this.groupBox1.Controls.Add(this.lb_KeywordCategory);
            this.groupBox1.Controls.Add(this.cb_KeywordCategory);
            this.groupBox1.Controls.Add(this.btn_UploadFile);
            this.groupBox1.Controls.Add(this.btn_Begin);
            this.groupBox1.Controls.Add(this.btn_Clean);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 114);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // btn_CheckAll
            // 
            this.btn_CheckAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CheckAll.BackgroundImage")));
            this.btn_CheckAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CheckAll.FlatAppearance.BorderSize = 0;
            this.btn_CheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CheckAll.Location = new System.Drawing.Point(12, 132);
            this.btn_CheckAll.Name = "btn_CheckAll";
            this.btn_CheckAll.Size = new System.Drawing.Size(18, 18);
            this.btn_CheckAll.TabIndex = 17;
            this.btn_CheckAll.UseVisualStyleBackColor = true;
            this.btn_CheckAll.Click += new System.EventHandler(this.btn_CheckAll_Click);
            // 
            // btn_UnChekAll
            // 
            this.btn_UnChekAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_UnChekAll.BackgroundImage")));
            this.btn_UnChekAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_UnChekAll.FlatAppearance.BorderSize = 0;
            this.btn_UnChekAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_UnChekAll.Location = new System.Drawing.Point(42, 132);
            this.btn_UnChekAll.Name = "btn_UnChekAll";
            this.btn_UnChekAll.Size = new System.Drawing.Size(18, 18);
            this.btn_UnChekAll.TabIndex = 18;
            this.btn_UnChekAll.UseVisualStyleBackColor = true;
            this.btn_UnChekAll.Click += new System.EventHandler(this.btn_UnChekAll_Click);
            // 
            // btn_AddCategory
            // 
            this.btn_AddCategory.FlatAppearance.BorderSize = 0;
            this.btn_AddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddCategory.Location = new System.Drawing.Point(310, 75);
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
            this.btn_KeysAreDone.Location = new System.Drawing.Point(345, 64);
            this.btn_KeysAreDone.Name = "btn_KeysAreDone";
            this.btn_KeysAreDone.Size = new System.Drawing.Size(160, 41);
            this.btn_KeysAreDone.TabIndex = 15;
            this.btn_KeysAreDone.Text = "Отметить ключи";
            this.btn_KeysAreDone.UseVisualStyleBackColor = false;
            this.btn_KeysAreDone.EnabledChanged += new System.EventHandler(this.btn_KeysAreDone_EnabledChanged);
            this.btn_KeysAreDone.Click += new System.EventHandler(this.btn_KeysAreDone_Click);
            // 
            // lb_NewKeys
            // 
            this.lb_NewKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_NewKeys.Location = new System.Drawing.Point(809, 9);
            this.lb_NewKeys.Name = "lb_NewKeys";
            this.lb_NewKeys.Size = new System.Drawing.Size(419, 23);
            this.lb_NewKeys.TabIndex = 21;
            this.lb_NewKeys.Text = "Новые добавленные ключи";
            this.lb_NewKeys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(809, 441);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(419, 19);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(368, 132);
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
            this.tb_Link.Location = new System.Drawing.Point(385, 129);
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(132, 20);
            this.tb_Link.TabIndex = 26;
            this.tb_Link.Text = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(809, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Все ключи в категории";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_KeywordsInCategory
            // 
            this.dgv_KeywordsInCategory.AllowUserToAddRows = false;
            this.dgv_KeywordsInCategory.AllowUserToDeleteRows = false;
            this.dgv_KeywordsInCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KeywordsInCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Keywordclmn,
            this.valueclmn,
            this.lastupdatedclmn});
            this.dgv_KeywordsInCategory.Enabled = false;
            this.dgv_KeywordsInCategory.Location = new System.Drawing.Point(809, 493);
            this.dgv_KeywordsInCategory.Name = "dgv_KeywordsInCategory";
            this.dgv_KeywordsInCategory.ReadOnly = true;
            this.dgv_KeywordsInCategory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_KeywordsInCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_KeywordsInCategory.Size = new System.Drawing.Size(419, 321);
            this.dgv_KeywordsInCategory.TabIndex = 29;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Column15";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Column16";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 136.2398F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ключ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 280;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 63.76023F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Частота";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 117;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Column17";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Visible = false;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Column18";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // ProductTypeIdCol
            // 
            this.ProductTypeIdCol.HeaderText = "ProductTypeIdCol";
            this.ProductTypeIdCol.Name = "ProductTypeIdCol";
            this.ProductTypeIdCol.ReadOnly = true;
            this.ProductTypeIdCol.Visible = false;
            // 
            // CategoryIdCol
            // 
            this.CategoryIdCol.HeaderText = "CategoryIdCol";
            this.CategoryIdCol.Name = "CategoryIdCol";
            this.CategoryIdCol.ReadOnly = true;
            this.CategoryIdCol.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 136.2398F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ключ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 250;
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
            // LastUpdated
            // 
            this.LastUpdated.HeaderText = "LastUpdated";
            this.LastUpdated.Name = "LastUpdated";
            this.LastUpdated.ReadOnly = true;
            this.LastUpdated.Visible = false;
            // 
            // SemCoreIdCol
            // 
            this.SemCoreIdCol.HeaderText = "SemCoreId";
            this.SemCoreIdCol.Name = "SemCoreIdCol";
            this.SemCoreIdCol.ReadOnly = true;
            this.SemCoreIdCol.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 136.2398F;
            this.Column1.HeaderText = "Ключ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 63.76023F;
            this.Column2.HeaderText = "Частота";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 117;
            // 
            // Keywordclmn
            // 
            this.Keywordclmn.HeaderText = "Ключ";
            this.Keywordclmn.Name = "Keywordclmn";
            this.Keywordclmn.ReadOnly = true;
            this.Keywordclmn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Keywordclmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Keywordclmn.Width = 190;
            // 
            // valueclmn
            // 
            this.valueclmn.HeaderText = "Частота";
            this.valueclmn.Name = "valueclmn";
            this.valueclmn.ReadOnly = true;
            this.valueclmn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.valueclmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.valueclmn.Width = 75;
            // 
            // lastupdatedclmn
            // 
            this.lastupdatedclmn.HeaderText = "Последнее обновление";
            this.lastupdatedclmn.Name = "lastupdatedclmn";
            this.lastupdatedclmn.ReadOnly = true;
            this.lastupdatedclmn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lastupdatedclmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lastupdatedclmn.Width = 130;
            // 
            // SemCoreRebuildView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 826);
            this.Controls.Add(this.btn_UnChekAll);
            this.Controls.Add(this.btn_CheckAll);
            this.Controls.Add(this.dgv_KeywordsInCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tb_Link);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_NewKeys);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_NewKeys);
            this.Controls.Add(this.lb_UpdatedKeys);
            this.Controls.Add(this.lb_UploadedKeys);
            this.Controls.Add(this.dgv_Target);
            this.Controls.Add(this.dgv_Source);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SemCoreRebuildView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение семантического ядра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemCoreRebuild_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.SemCoreRebuild_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NewKeys)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeywordsInCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridView dgv_NewKeys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_NewKeys;
        private System.Windows.Forms.Button btn_KeysAreDone;
        private System.Windows.Forms.Button btn_AddCategory;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_UnChekAll;
        private System.Windows.Forms.Button btn_CheckAll;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tb_Link;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_KeywordsInCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemCoreIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keywordclmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueclmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastupdatedclmn;
    }
}