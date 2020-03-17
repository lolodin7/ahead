namespace Excel_Parse
{
    partial class MainFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormView));
            this.btn_Exit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.семантическиеЯдраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoSemCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoRewriteSemCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoKeywordCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAllKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSemCoreArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.товарыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoProductTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoMarketpalcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рекламаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAdvDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSalesDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showReturnsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showGeneralSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addAdvReportReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBusinessReportReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReturnsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.Location = new System.Drawing.Point(781, 428);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(195, 81);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.семантическиеЯдраToolStripMenuItem,
            this.товарыToolStripMenuItem,
            this.рекламаToolStripMenuItem,
            this.serviceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // семантическиеЯдраToolStripMenuItem
            // 
            this.семантическиеЯдраToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoSemCoreToolStripMenuItem,
            this.DoRewriteSemCoreToolStripMenuItem,
            this.DoKeywordCategoryToolStripMenuItem,
            this.ShowAllKeywordsToolStripMenuItem,
            this.ShowSemCoreArchiveToolStripMenuItem});
            this.семантическиеЯдраToolStripMenuItem.Name = "семантическиеЯдраToolStripMenuItem";
            this.семантическиеЯдраToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.семантическиеЯдраToolStripMenuItem.Text = "Семантическое ядро";
            this.семантическиеЯдраToolStripMenuItem.Visible = false;
            // 
            // DoSemCoreToolStripMenuItem
            // 
            this.DoSemCoreToolStripMenuItem.Name = "DoSemCoreToolStripMenuItem";
            this.DoSemCoreToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.DoSemCoreToolStripMenuItem.Text = "Собрать сем. ядро";
            this.DoSemCoreToolStripMenuItem.Click += new System.EventHandler(this.btn_DoSemCore_Click);
            // 
            // DoRewriteSemCoreToolStripMenuItem
            // 
            this.DoRewriteSemCoreToolStripMenuItem.Name = "DoRewriteSemCoreToolStripMenuItem";
            this.DoRewriteSemCoreToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.DoRewriteSemCoreToolStripMenuItem.Text = "Пересобрать сем. ядро";
            this.DoRewriteSemCoreToolStripMenuItem.Click += new System.EventHandler(this.btn_DoRewriteSemCore_Click);
            // 
            // DoKeywordCategoryToolStripMenuItem
            // 
            this.DoKeywordCategoryToolStripMenuItem.Name = "DoKeywordCategoryToolStripMenuItem";
            this.DoKeywordCategoryToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.DoKeywordCategoryToolStripMenuItem.Text = "Категории ключей";
            this.DoKeywordCategoryToolStripMenuItem.Click += new System.EventHandler(this.btn_DoKeywordCategory_Click);
            // 
            // ShowAllKeywordsToolStripMenuItem
            // 
            this.ShowAllKeywordsToolStripMenuItem.Name = "ShowAllKeywordsToolStripMenuItem";
            this.ShowAllKeywordsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.ShowAllKeywordsToolStripMenuItem.Text = "Существующие ключи";
            this.ShowAllKeywordsToolStripMenuItem.Click += new System.EventHandler(this.btn_ShowAllKeywords_Click);
            // 
            // ShowSemCoreArchiveToolStripMenuItem
            // 
            this.ShowSemCoreArchiveToolStripMenuItem.Name = "ShowSemCoreArchiveToolStripMenuItem";
            this.ShowSemCoreArchiveToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.ShowSemCoreArchiveToolStripMenuItem.Text = "История ключей";
            this.ShowSemCoreArchiveToolStripMenuItem.Click += new System.EventHandler(this.SemCoreArchive_Click);
            // 
            // товарыToolStripMenuItem
            // 
            this.товарыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoProductsToolStripMenuItem,
            this.DoProductTypesToolStripMenuItem,
            this.DoMarketpalcesToolStripMenuItem});
            this.товарыToolStripMenuItem.Name = "товарыToolStripMenuItem";
            this.товарыToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.товарыToolStripMenuItem.Text = "Товары";
            // 
            // DoProductsToolStripMenuItem
            // 
            this.DoProductsToolStripMenuItem.Name = "DoProductsToolStripMenuItem";
            this.DoProductsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.DoProductsToolStripMenuItem.Text = "Товары";
            this.DoProductsToolStripMenuItem.Click += new System.EventHandler(this.btn_DoProducts_Click);
            // 
            // DoProductTypesToolStripMenuItem
            // 
            this.DoProductTypesToolStripMenuItem.Name = "DoProductTypesToolStripMenuItem";
            this.DoProductTypesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.DoProductTypesToolStripMenuItem.Text = "Виды товаров";
            this.DoProductTypesToolStripMenuItem.Click += new System.EventHandler(this.btn_DoProductType_Click);
            // 
            // DoMarketpalcesToolStripMenuItem
            // 
            this.DoMarketpalcesToolStripMenuItem.Name = "DoMarketpalcesToolStripMenuItem";
            this.DoMarketpalcesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.DoMarketpalcesToolStripMenuItem.Text = "Маркетплейсы";
            this.DoMarketpalcesToolStripMenuItem.Click += new System.EventHandler(this.btn_DoMarketplaces_Click);
            // 
            // рекламаToolStripMenuItem
            // 
            this.рекламаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSectionToolStripMenuItem,
            this.addSectionToolStripMenuItem1});
            this.рекламаToolStripMenuItem.Name = "рекламаToolStripMenuItem";
            this.рекламаToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.рекламаToolStripMenuItem.Text = "Отчетность";
            // 
            // showSectionToolStripMenuItem
            // 
            this.showSectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAdvDataToolStripMenuItem,
            this.showSalesDataToolStripMenuItem1,
            this.showReturnsToolStripMenuItem1,
            this.showGeneralSalesToolStripMenuItem,
            this.showSessionsToolStripMenuItem,
            this.складToolStripMenuItem});
            this.showSectionToolStripMenuItem.Name = "showSectionToolStripMenuItem";
            this.showSectionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showSectionToolStripMenuItem.Text = "Посмотреть";
            // 
            // showAdvDataToolStripMenuItem
            // 
            this.showAdvDataToolStripMenuItem.Name = "showAdvDataToolStripMenuItem";
            this.showAdvDataToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showAdvDataToolStripMenuItem.Text = "Реклама";
            this.showAdvDataToolStripMenuItem.Click += new System.EventHandler(this.showAdvDataToolStripMenuItem_Click);
            // 
            // showSalesDataToolStripMenuItem1
            // 
            this.showSalesDataToolStripMenuItem1.Enabled = false;
            this.showSalesDataToolStripMenuItem1.Name = "showSalesDataToolStripMenuItem1";
            this.showSalesDataToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.showSalesDataToolStripMenuItem1.Text = "Продажи";
            this.showSalesDataToolStripMenuItem1.Click += new System.EventHandler(this.showSalesDataToolStripMenuItem1_Click);
            // 
            // showReturnsToolStripMenuItem1
            // 
            this.showReturnsToolStripMenuItem1.Name = "showReturnsToolStripMenuItem1";
            this.showReturnsToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.showReturnsToolStripMenuItem1.Text = "Возвраты";
            this.showReturnsToolStripMenuItem1.Visible = false;
            this.showReturnsToolStripMenuItem1.Click += new System.EventHandler(this.showReturnsToolStripMenuItem1_Click);
            // 
            // showGeneralSalesToolStripMenuItem
            // 
            this.showGeneralSalesToolStripMenuItem.Name = "showGeneralSalesToolStripMenuItem";
            this.showGeneralSalesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showGeneralSalesToolStripMenuItem.Text = "Общий оборот";
            this.showGeneralSalesToolStripMenuItem.Visible = false;
            this.showGeneralSalesToolStripMenuItem.Click += new System.EventHandler(this.showGeneralSalesToolStripMenuItem_Click);
            // 
            // showSessionsToolStripMenuItem
            // 
            this.showSessionsToolStripMenuItem.Name = "showSessionsToolStripMenuItem";
            this.showSessionsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showSessionsToolStripMenuItem.Text = "Сессии";
            this.showSessionsToolStripMenuItem.Click += new System.EventHandler(this.showSessionsToolStripMenuItem_Click);
            // 
            // складToolStripMenuItem
            // 
            this.складToolStripMenuItem.Name = "складToolStripMenuItem";
            this.складToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.складToolStripMenuItem.Text = "Склад";
            this.складToolStripMenuItem.Click += new System.EventHandler(this.складToolStripMenuItem_Click);
            // 
            // addSectionToolStripMenuItem1
            // 
            this.addSectionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAdvReportReportToolStripMenuItem,
            this.addBusinessReportReportToolStripMenuItem,
            this.allOrdersToolStripMenuItem,
            this.stockReportToolStripMenuItem,
            this.addReturnsReportToolStripMenuItem});
            this.addSectionToolStripMenuItem1.Name = "addSectionToolStripMenuItem1";
            this.addSectionToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.addSectionToolStripMenuItem1.Text = "Добавить";
            // 
            // addAdvReportReportToolStripMenuItem
            // 
            this.addAdvReportReportToolStripMenuItem.Name = "addAdvReportReportToolStripMenuItem";
            this.addAdvReportReportToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addAdvReportReportToolStripMenuItem.Text = "Advertising report";
            this.addAdvReportReportToolStripMenuItem.Click += new System.EventHandler(this.addAdvReportReportToolStripMenuItem_Click);
            // 
            // addBusinessReportReportToolStripMenuItem
            // 
            this.addBusinessReportReportToolStripMenuItem.Name = "addBusinessReportReportToolStripMenuItem";
            this.addBusinessReportReportToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addBusinessReportReportToolStripMenuItem.Text = "Business report";
            this.addBusinessReportReportToolStripMenuItem.Click += new System.EventHandler(this.addBusinessReportReportToolStripMenuItem_Click);
            // 
            // allOrdersToolStripMenuItem
            // 
            this.allOrdersToolStripMenuItem.Name = "allOrdersToolStripMenuItem";
            this.allOrdersToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.allOrdersToolStripMenuItem.Text = "All orders";
            this.allOrdersToolStripMenuItem.Click += new System.EventHandler(this.allOrdersToolStripMenuItem_Click);
            // 
            // stockReportToolStripMenuItem
            // 
            this.stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            this.stockReportToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.stockReportToolStripMenuItem.Text = "Stock report";
            this.stockReportToolStripMenuItem.Click += new System.EventHandler(this.stockReportToolStripMenuItem_Click);
            // 
            // addReturnsReportToolStripMenuItem
            // 
            this.addReturnsReportToolStripMenuItem.Name = "addReturnsReportToolStripMenuItem";
            this.addReturnsReportToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addReturnsReportToolStripMenuItem.Text = "Returns report";
            this.addReturnsReportToolStripMenuItem.Visible = false;
            this.addReturnsReportToolStripMenuItem.Click += new System.EventHandler(this.addReturnsReportToolStripMenuItem_Click);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.serviceToolStripMenuItem.Text = "Сервис";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.aboutToolStripMenuItem.Text = "Справка";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Enabled = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel8});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 20);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(31, 15);
            this.toolStripStatusLabel2.Text = "дата";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(31, 15);
            this.toolStripStatusLabel4.Text = "дата";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(31, 15);
            this.toolStripStatusLabel6.Text = "дата";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(31, 15);
            this.toolStripStatusLabel8.Text = "дата";
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 536);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная - Bona Fides";
            this.Load += new System.EventHandler(this.MainFormView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem семантическиеЯдраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoSemCoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoRewriteSemCoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowAllKeywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowSemCoreArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoKeywordCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem товарыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoProductTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoMarketpalcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рекламаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addAdvReportReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBusinessReportReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAdvDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSalesDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showGeneralSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReturnsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addReturnsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
    }
}