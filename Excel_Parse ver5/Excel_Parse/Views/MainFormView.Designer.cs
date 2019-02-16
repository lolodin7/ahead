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
            this.btn_DoSemCore = new System.Windows.Forms.Button();
            this.btn_DoSemantics = new System.Windows.Forms.Button();
            this.btn_DoRewriteSemCore = new System.Windows.Forms.Button();
            this.btn_DoProductType = new System.Windows.Forms.Button();
            this.btn_DoKeywordCategory = new System.Windows.Forms.Button();
            this.btn_DoProducts = new System.Windows.Forms.Button();
            this.btn_ShowAllKeywords = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_ShowIndexing = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_DoMarketplaces = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.семантическиеЯдраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.семантикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.товарыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoProductTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoMarketpalcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateSemanticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSemanticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowIndexingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoSemCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoRewriteSemCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAllKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSemCoreArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoKeywordCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonalInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_DoSemCore
            // 
            this.btn_DoSemCore.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoSemCore.FlatAppearance.BorderSize = 0;
            this.btn_DoSemCore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoSemCore.Location = new System.Drawing.Point(12, 32);
            this.btn_DoSemCore.Name = "btn_DoSemCore";
            this.btn_DoSemCore.Size = new System.Drawing.Size(195, 81);
            this.btn_DoSemCore.TabIndex = 0;
            this.btn_DoSemCore.Text = "Собрать семантическое ядро";
            this.btn_DoSemCore.UseVisualStyleBackColor = false;
            this.btn_DoSemCore.Click += new System.EventHandler(this.btn_DoSemCore_Click);
            // 
            // btn_DoSemantics
            // 
            this.btn_DoSemantics.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoSemantics.FlatAppearance.BorderSize = 0;
            this.btn_DoSemantics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoSemantics.Location = new System.Drawing.Point(313, 137);
            this.btn_DoSemantics.Name = "btn_DoSemantics";
            this.btn_DoSemantics.Size = new System.Drawing.Size(195, 81);
            this.btn_DoSemantics.TabIndex = 1;
            this.btn_DoSemantics.Text = "Редактирование семантики";
            this.btn_DoSemantics.UseVisualStyleBackColor = false;
            this.btn_DoSemantics.Click += new System.EventHandler(this.btn_DoSemantics_Click);
            // 
            // btn_DoRewriteSemCore
            // 
            this.btn_DoRewriteSemCore.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoRewriteSemCore.FlatAppearance.BorderSize = 0;
            this.btn_DoRewriteSemCore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoRewriteSemCore.Location = new System.Drawing.Point(12, 137);
            this.btn_DoRewriteSemCore.Name = "btn_DoRewriteSemCore";
            this.btn_DoRewriteSemCore.Size = new System.Drawing.Size(195, 81);
            this.btn_DoRewriteSemCore.TabIndex = 2;
            this.btn_DoRewriteSemCore.Text = "Пересобрать семантическое ядро";
            this.btn_DoRewriteSemCore.UseVisualStyleBackColor = false;
            this.btn_DoRewriteSemCore.Click += new System.EventHandler(this.btn_DoRewriteSemCore_Click);
            // 
            // btn_DoProductType
            // 
            this.btn_DoProductType.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoProductType.FlatAppearance.BorderSize = 0;
            this.btn_DoProductType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoProductType.Location = new System.Drawing.Point(611, 137);
            this.btn_DoProductType.Name = "btn_DoProductType";
            this.btn_DoProductType.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProductType.TabIndex = 3;
            this.btn_DoProductType.Text = "Управление видами товаров";
            this.btn_DoProductType.UseVisualStyleBackColor = false;
            this.btn_DoProductType.Click += new System.EventHandler(this.btn_DoProductType_Click);
            // 
            // btn_DoKeywordCategory
            // 
            this.btn_DoKeywordCategory.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoKeywordCategory.FlatAppearance.BorderSize = 0;
            this.btn_DoKeywordCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoKeywordCategory.Location = new System.Drawing.Point(12, 456);
            this.btn_DoKeywordCategory.Name = "btn_DoKeywordCategory";
            this.btn_DoKeywordCategory.Size = new System.Drawing.Size(195, 81);
            this.btn_DoKeywordCategory.TabIndex = 4;
            this.btn_DoKeywordCategory.Text = "Управление категориями ключей";
            this.btn_DoKeywordCategory.UseVisualStyleBackColor = false;
            this.btn_DoKeywordCategory.Click += new System.EventHandler(this.btn_DoKeywordCategory_Click);
            // 
            // btn_DoProducts
            // 
            this.btn_DoProducts.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoProducts.FlatAppearance.BorderSize = 0;
            this.btn_DoProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoProducts.Location = new System.Drawing.Point(611, 32);
            this.btn_DoProducts.Name = "btn_DoProducts";
            this.btn_DoProducts.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProducts.TabIndex = 5;
            this.btn_DoProducts.Text = "Управление товарами";
            this.btn_DoProducts.UseVisualStyleBackColor = false;
            this.btn_DoProducts.Click += new System.EventHandler(this.btn_DoProducts_Click);
            // 
            // btn_ShowAllKeywords
            // 
            this.btn_ShowAllKeywords.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_ShowAllKeywords.FlatAppearance.BorderSize = 0;
            this.btn_ShowAllKeywords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowAllKeywords.Location = new System.Drawing.Point(12, 244);
            this.btn_ShowAllKeywords.Name = "btn_ShowAllKeywords";
            this.btn_ShowAllKeywords.Size = new System.Drawing.Size(195, 81);
            this.btn_ShowAllKeywords.TabIndex = 6;
            this.btn_ShowAllKeywords.Text = "Просмотреть существующие ключи";
            this.btn_ShowAllKeywords.UseVisualStyleBackColor = false;
            this.btn_ShowAllKeywords.Click += new System.EventHandler(this.btn_ShowAllKeywords_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(611, 456);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(195, 81);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_ShowIndexing
            // 
            this.btn_ShowIndexing.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_ShowIndexing.FlatAppearance.BorderSize = 0;
            this.btn_ShowIndexing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowIndexing.Location = new System.Drawing.Point(313, 244);
            this.btn_ShowIndexing.Name = "btn_ShowIndexing";
            this.btn_ShowIndexing.Size = new System.Drawing.Size(195, 81);
            this.btn_ShowIndexing.TabIndex = 9;
            this.btn_ShowIndexing.Text = "Индексация";
            this.btn_ShowIndexing.UseVisualStyleBackColor = false;
            this.btn_ShowIndexing.Click += new System.EventHandler(this.btn_ShowIndexing_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(313, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 81);
            this.button1.TabIndex = 11;
            this.button1.Text = "Создать семантику для нового товара";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.семантическиеЯдраToolStripMenuItem,
            this.семантикаToolStripMenuItem,
            this.товарыToolStripMenuItem,
            this.сотрудникToolStripMenuItem,
            this.serviceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.serviceToolStripMenuItem.Text = "Сервис";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "Справка";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btn_DoMarketplaces
            // 
            this.btn_DoMarketplaces.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoMarketplaces.FlatAppearance.BorderSize = 0;
            this.btn_DoMarketplaces.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoMarketplaces.Location = new System.Drawing.Point(611, 244);
            this.btn_DoMarketplaces.Name = "btn_DoMarketplaces";
            this.btn_DoMarketplaces.Size = new System.Drawing.Size(195, 81);
            this.btn_DoMarketplaces.TabIndex = 13;
            this.btn_DoMarketplaces.Text = "Управление маркетплейсами";
            this.btn_DoMarketplaces.UseVisualStyleBackColor = false;
            this.btn_DoMarketplaces.Click += new System.EventHandler(this.btn_DoMarketplaces_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.YellowGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 81);
            this.button2.TabIndex = 14;
            this.button2.Text = "Просмотреть историю ключей";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.семантическиеЯдраToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.семантическиеЯдраToolStripMenuItem.Text = "Семантическое ядро";
            // 
            // семантикаToolStripMenuItem
            // 
            this.семантикаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateSemanticsToolStripMenuItem,
            this.EditSemanticsToolStripMenuItem,
            this.ShowIndexingToolStripMenuItem});
            this.семантикаToolStripMenuItem.Name = "семантикаToolStripMenuItem";
            this.семантикаToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.семантикаToolStripMenuItem.Text = "Семантика";
            // 
            // товарыToolStripMenuItem
            // 
            this.товарыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoProductsToolStripMenuItem,
            this.DoProductTypesToolStripMenuItem,
            this.DoMarketpalcesToolStripMenuItem});
            this.товарыToolStripMenuItem.Name = "товарыToolStripMenuItem";
            this.товарыToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.товарыToolStripMenuItem.Text = "Товары";
            // 
            // DoProductsToolStripMenuItem
            // 
            this.DoProductsToolStripMenuItem.Name = "DoProductsToolStripMenuItem";
            this.DoProductsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.DoProductsToolStripMenuItem.Text = "Управление товарами";
            this.DoProductsToolStripMenuItem.Click += new System.EventHandler(this.btn_DoProducts_Click);
            // 
            // DoProductTypesToolStripMenuItem
            // 
            this.DoProductTypesToolStripMenuItem.Name = "DoProductTypesToolStripMenuItem";
            this.DoProductTypesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.DoProductTypesToolStripMenuItem.Text = "Управление видами товаров";
            this.DoProductTypesToolStripMenuItem.Click += new System.EventHandler(this.btn_DoProductType_Click);
            // 
            // DoMarketpalcesToolStripMenuItem
            // 
            this.DoMarketpalcesToolStripMenuItem.Name = "DoMarketpalcesToolStripMenuItem";
            this.DoMarketpalcesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.DoMarketpalcesToolStripMenuItem.Text = "Управление маркетплейсами";
            this.DoMarketpalcesToolStripMenuItem.Click += new System.EventHandler(this.btn_DoMarketplaces_Click);
            // 
            // CreateSemanticsToolStripMenuItem
            // 
            this.CreateSemanticsToolStripMenuItem.Name = "CreateSemanticsToolStripMenuItem";
            this.CreateSemanticsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.CreateSemanticsToolStripMenuItem.Text = "Создать семантику для нового товара";
            this.CreateSemanticsToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditSemanticsToolStripMenuItem
            // 
            this.EditSemanticsToolStripMenuItem.Name = "EditSemanticsToolStripMenuItem";
            this.EditSemanticsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.EditSemanticsToolStripMenuItem.Text = "Редактирование семантики";
            this.EditSemanticsToolStripMenuItem.Click += new System.EventHandler(this.btn_DoSemantics_Click);
            // 
            // ShowIndexingToolStripMenuItem
            // 
            this.ShowIndexingToolStripMenuItem.Name = "ShowIndexingToolStripMenuItem";
            this.ShowIndexingToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ShowIndexingToolStripMenuItem.Text = "Индексация";
            this.ShowIndexingToolStripMenuItem.Click += new System.EventHandler(this.btn_ShowIndexing_Click);
            // 
            // DoSemCoreToolStripMenuItem
            // 
            this.DoSemCoreToolStripMenuItem.Name = "DoSemCoreToolStripMenuItem";
            this.DoSemCoreToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.DoSemCoreToolStripMenuItem.Text = "Собрать сем. ядро";
            this.DoSemCoreToolStripMenuItem.Click += new System.EventHandler(this.btn_DoSemCore_Click);
            // 
            // DoRewriteSemCoreToolStripMenuItem
            // 
            this.DoRewriteSemCoreToolStripMenuItem.Name = "DoRewriteSemCoreToolStripMenuItem";
            this.DoRewriteSemCoreToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.DoRewriteSemCoreToolStripMenuItem.Text = "Пересобрать сем. ядро";
            this.DoRewriteSemCoreToolStripMenuItem.Click += new System.EventHandler(this.btn_DoRewriteSemCore_Click);
            // 
            // ShowAllKeywordsToolStripMenuItem
            // 
            this.ShowAllKeywordsToolStripMenuItem.Name = "ShowAllKeywordsToolStripMenuItem";
            this.ShowAllKeywordsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.ShowAllKeywordsToolStripMenuItem.Text = "Просмотреть существующие ключи";
            this.ShowAllKeywordsToolStripMenuItem.Click += new System.EventHandler(this.btn_ShowAllKeywords_Click);
            // 
            // ShowSemCoreArchiveToolStripMenuItem
            // 
            this.ShowSemCoreArchiveToolStripMenuItem.Name = "ShowSemCoreArchiveToolStripMenuItem";
            this.ShowSemCoreArchiveToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.ShowSemCoreArchiveToolStripMenuItem.Text = "Просмотреть историю ключей";
            this.ShowSemCoreArchiveToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // DoKeywordCategoryToolStripMenuItem
            // 
            this.DoKeywordCategoryToolStripMenuItem.Name = "DoKeywordCategoryToolStripMenuItem";
            this.DoKeywordCategoryToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.DoKeywordCategoryToolStripMenuItem.Text = "Управление категориями ключей";
            this.DoKeywordCategoryToolStripMenuItem.Click += new System.EventHandler(this.btn_DoKeywordCategory_Click);
            // 
            // сотрудникToolStripMenuItem
            // 
            this.сотрудникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonalInfoToolStripMenuItem,
            this.LogOutToolStripMenuItem});
            this.сотрудникToolStripMenuItem.Name = "сотрудникToolStripMenuItem";
            this.сотрудникToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сотрудникToolStripMenuItem.Text = "Сотрудник";
            // 
            // ShowPersonalInfoToolStripMenuItem
            // 
            this.ShowPersonalInfoToolStripMenuItem.Name = "ShowPersonalInfoToolStripMenuItem";
            this.ShowPersonalInfoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ShowPersonalInfoToolStripMenuItem.Text = "Карточка сотрудника";
            // 
            // LogOutToolStripMenuItem
            // 
            this.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem";
            this.LogOutToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.LogOutToolStripMenuItem.Text = "Завершить сеанс";
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 546);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_DoMarketplaces);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ShowIndexing);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_ShowAllKeywords);
            this.Controls.Add(this.btn_DoProducts);
            this.Controls.Add(this.btn_DoKeywordCategory);
            this.Controls.Add(this.btn_DoProductType);
            this.Controls.Add(this.btn_DoRewriteSemCore);
            this.Controls.Add(this.btn_DoSemantics);
            this.Controls.Add(this.btn_DoSemCore);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная - Bona Fides";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DoSemCore;
        private System.Windows.Forms.Button btn_DoSemantics;
        private System.Windows.Forms.Button btn_DoRewriteSemCore;
        private System.Windows.Forms.Button btn_DoProductType;
        private System.Windows.Forms.Button btn_DoKeywordCategory;
        private System.Windows.Forms.Button btn_DoProducts;
        private System.Windows.Forms.Button btn_ShowAllKeywords;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_ShowIndexing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btn_DoMarketplaces;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem семантическиеЯдраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoSemCoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoRewriteSemCoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowAllKeywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowSemCoreArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoKeywordCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem семантикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateSemanticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditSemanticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowIndexingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem товарыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoProductTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoMarketpalcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonalInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogOutToolStripMenuItem;
    }
}