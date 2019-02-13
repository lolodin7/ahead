namespace Excel_Parse
{
    partial class MarketplaceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketplaceView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_RefreshDGV = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lb_Marketplace = new System.Windows.Forms.Label();
            this.tb_MarketplaceName = new System.Windows.Forms.TextBox();
            this.dgv_Marketplaces = new System.Windows.Forms.DataGridView();
            this.MarketplaceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketplaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Marketplaces)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_RefreshDGV);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.lb_Marketplace);
            this.groupBox1.Controls.Add(this.tb_MarketplaceName);
            this.groupBox1.Location = new System.Drawing.Point(6, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 152);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление нового Marketplace";
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
            // lb_Marketplace
            // 
            this.lb_Marketplace.AutoSize = true;
            this.lb_Marketplace.Location = new System.Drawing.Point(86, 33);
            this.lb_Marketplace.Name = "lb_Marketplace";
            this.lb_Marketplace.Size = new System.Drawing.Size(119, 13);
            this.lb_Marketplace.TabIndex = 1;
            this.lb_Marketplace.Text = "Название Marketplace";
            // 
            // tb_MarketplaceName
            // 
            this.tb_MarketplaceName.Location = new System.Drawing.Point(45, 60);
            this.tb_MarketplaceName.Name = "tb_MarketplaceName";
            this.tb_MarketplaceName.Size = new System.Drawing.Size(193, 20);
            this.tb_MarketplaceName.TabIndex = 0;
            this.tb_MarketplaceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_MarketplaceName_KeyDown);
            // 
            // dgv_Marketplaces
            // 
            this.dgv_Marketplaces.AllowUserToAddRows = false;
            this.dgv_Marketplaces.AllowUserToDeleteRows = false;
            this.dgv_Marketplaces.AllowUserToResizeColumns = false;
            this.dgv_Marketplaces.AllowUserToResizeRows = false;
            this.dgv_Marketplaces.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Marketplaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Marketplaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarketplaceId,
            this.MarketplaceName});
            this.dgv_Marketplaces.Location = new System.Drawing.Point(6, 3);
            this.dgv_Marketplaces.MultiSelect = false;
            this.dgv_Marketplaces.Name = "dgv_Marketplaces";
            this.dgv_Marketplaces.ReadOnly = true;
            this.dgv_Marketplaces.Size = new System.Drawing.Size(293, 324);
            this.dgv_Marketplaces.TabIndex = 2;
            this.dgv_Marketplaces.Visible = false;
            this.dgv_Marketplaces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Marketplaces_CellDoubleClick);
            this.dgv_Marketplaces.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Marketplaces_CellMouseClick);
            // 
            // MarketplaceId
            // 
            this.MarketplaceId.HeaderText = "ProductTypeId";
            this.MarketplaceId.Name = "MarketplaceId";
            this.MarketplaceId.ReadOnly = true;
            this.MarketplaceId.Visible = false;
            // 
            // MarketplaceName
            // 
            this.MarketplaceName.HeaderText = "Название Marketplace";
            this.MarketplaceName.Name = "MarketplaceName";
            this.MarketplaceName.ReadOnly = true;
            this.MarketplaceName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MarketplaceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MarketplaceName.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(63, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Marketplace отсутствуют";
            // 
            // MarketplaceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Marketplaces);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MarketplaceView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление Marketplace - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MarketplaceView_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Marketplaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_RefreshDGV;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lb_Marketplace;
        private System.Windows.Forms.TextBox tb_MarketplaceName;
        private System.Windows.Forms.DataGridView dgv_Marketplaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketplaceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketplaceName;
        private System.Windows.Forms.Label label1;
    }
}