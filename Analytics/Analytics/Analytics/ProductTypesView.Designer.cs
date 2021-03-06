﻿namespace Excel_Parse
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
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lb_ProductType = new System.Windows.Forms.Label();
            this.tb_ProductType = new System.Windows.Forms.TextBox();
            this.btn_RefreshDGV = new System.Windows.Forms.Button();
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
            this.dgv_ProductTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ProductTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductTypeId,
            this.TypeName});
            this.dgv_ProductTypes.Location = new System.Drawing.Point(6, 5);
            this.dgv_ProductTypes.MultiSelect = false;
            this.dgv_ProductTypes.Name = "dgv_ProductTypes";
            this.dgv_ProductTypes.ReadOnly = true;
            this.dgv_ProductTypes.Size = new System.Drawing.Size(293, 324);
            this.dgv_ProductTypes.TabIndex = 0;
            this.dgv_ProductTypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ProductTypes_CellDoubleClick);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_RefreshDGV);
            this.groupBox1.Controls.Add(this.btn_Clear);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.lb_ProductType);
            this.groupBox1.Controls.Add(this.tb_ProductType);
            this.groupBox1.Location = new System.Drawing.Point(6, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 152);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление новой категории продуктов";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(158, 106);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(129, 30);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "Закрыть";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
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
            this.lb_ProductType.Location = new System.Drawing.Point(86, 33);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(112, 13);
            this.lb_ProductType.TabIndex = 1;
            this.lb_ProductType.Text = "Название категории";
            // 
            // tb_ProductType
            // 
            this.tb_ProductType.Location = new System.Drawing.Point(45, 60);
            this.tb_ProductType.Name = "tb_ProductType";
            this.tb_ProductType.Size = new System.Drawing.Size(193, 20);
            this.tb_ProductType.TabIndex = 0;
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
            // ProductTypesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_ProductTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductTypesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Категории продуктов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductTypes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProductTypes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ProductTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.TextBox tb_ProductType;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.Button btn_RefreshDGV;
    }
}