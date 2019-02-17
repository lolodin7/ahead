namespace Excel_Parse
{
    partial class IndexingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexingView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markAsClosedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSemanticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_URL = new System.Windows.Forms.TextBox();
            this.btn_SaveUrl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1255, 635);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseMove);
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
            this.Column2.HeaderText = "Название товара";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ASIN";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "SKU";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsClosedToolStripMenuItem,
            this.showHistoryToolStripMenuItem,
            this.showSemanticsToolStripMenuItem,
            this.checkAddressToolStripMenuItem,
            this.changeURLToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // markAsClosedToolStripMenuItem
            // 
            this.markAsClosedToolStripMenuItem.Name = "markAsClosedToolStripMenuItem";
            this.markAsClosedToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.markAsClosedToolStripMenuItem.Text = "Отметить как Closed";
            this.markAsClosedToolStripMenuItem.Click += new System.EventHandler(this.markAsClosedToolStripMenuItem_Click);
            // 
            // showHistoryToolStripMenuItem
            // 
            this.showHistoryToolStripMenuItem.Name = "showHistoryToolStripMenuItem";
            this.showHistoryToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showHistoryToolStripMenuItem.Text = "Просмотреть";
            this.showHistoryToolStripMenuItem.Click += new System.EventHandler(this.showHistoryToolStripMenuItem_Click);
            // 
            // showSemanticsToolStripMenuItem
            // 
            this.showSemanticsToolStripMenuItem.Name = "showSemanticsToolStripMenuItem";
            this.showSemanticsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showSemanticsToolStripMenuItem.Text = "Семантика";
            this.showSemanticsToolStripMenuItem.Click += new System.EventHandler(this.showSemanticsToolStripMenuItem_Click);
            // 
            // checkAddressToolStripMenuItem
            // 
            this.checkAddressToolStripMenuItem.Name = "checkAddressToolStripMenuItem";
            this.checkAddressToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.checkAddressToolStripMenuItem.Text = "Проверка геопозиции";
            this.checkAddressToolStripMenuItem.Click += new System.EventHandler(this.checkAddressToolStripMenuItem_Click);
            // 
            // changeURLToolStripMenuItem
            // 
            this.changeURLToolStripMenuItem.Name = "changeURLToolStripMenuItem";
            this.changeURLToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.changeURLToolStripMenuItem.Text = "Изменить URL";
            this.changeURLToolStripMenuItem.Click += new System.EventHandler(this.changeURLToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.helpToolStripMenuItem1.Text = "Помощь";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // tb_URL
            // 
            this.tb_URL.Location = new System.Drawing.Point(13, 3);
            this.tb_URL.Name = "tb_URL";
            this.tb_URL.Size = new System.Drawing.Size(661, 20);
            this.tb_URL.TabIndex = 1;
            this.tb_URL.Visible = false;
            // 
            // btn_SaveUrl
            // 
            this.btn_SaveUrl.BackColor = System.Drawing.Color.LightGray;
            this.btn_SaveUrl.FlatAppearance.BorderSize = 0;
            this.btn_SaveUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveUrl.Location = new System.Drawing.Point(702, 3);
            this.btn_SaveUrl.Name = "btn_SaveUrl";
            this.btn_SaveUrl.Size = new System.Drawing.Size(75, 20);
            this.btn_SaveUrl.TabIndex = 2;
            this.btn_SaveUrl.Text = "Применить";
            this.btn_SaveUrl.UseVisualStyleBackColor = false;
            this.btn_SaveUrl.Visible = false;
            this.btn_SaveUrl.Click += new System.EventHandler(this.btn_SaveUrl_Click);
            // 
            // IndexingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 650);
            this.Controls.Add(this.btn_SaveUrl);
            this.Controls.Add(this.tb_URL);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndexingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Индексация товаров - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndexingView_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.IndexingView_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem markAsClosedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSemanticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeURLToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_URL;
        private System.Windows.Forms.Button btn_SaveUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    }
}