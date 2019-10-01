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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormView));
            this.btn_Exit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.семантическиеЯдраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoSemCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoRewriteSemCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoKeywordCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAllKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSemCoreArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.семантикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateSemanticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSemanticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowIndexingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.товарыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoProductTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoMarketpalcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рекламаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonalInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerNewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.showAdvDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(776, 443);
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
            this.семантикаToolStripMenuItem,
            this.товарыToolStripMenuItem,
            this.loggerToolStripMenuItem,
            this.рекламаToolStripMenuItem,
            this.сотрудникToolStripMenuItem,
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
            // семантикаToolStripMenuItem
            // 
            this.семантикаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateSemanticsToolStripMenuItem,
            this.EditSemanticsToolStripMenuItem,
            this.ShowIndexingToolStripMenuItem});
            this.семантикаToolStripMenuItem.Enabled = false;
            this.семантикаToolStripMenuItem.Name = "семантикаToolStripMenuItem";
            this.семантикаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.семантикаToolStripMenuItem.Text = "Семантика";
            // 
            // CreateSemanticsToolStripMenuItem
            // 
            this.CreateSemanticsToolStripMenuItem.Name = "CreateSemanticsToolStripMenuItem";
            this.CreateSemanticsToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.CreateSemanticsToolStripMenuItem.Text = "Создать семантику для нового товара";
            this.CreateSemanticsToolStripMenuItem.Click += new System.EventHandler(this.ChooseProduct_Click);
            // 
            // EditSemanticsToolStripMenuItem
            // 
            this.EditSemanticsToolStripMenuItem.Name = "EditSemanticsToolStripMenuItem";
            this.EditSemanticsToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.EditSemanticsToolStripMenuItem.Text = "Редактирование семантики";
            this.EditSemanticsToolStripMenuItem.Click += new System.EventHandler(this.btn_DoSemantics_Click);
            // 
            // ShowIndexingToolStripMenuItem
            // 
            this.ShowIndexingToolStripMenuItem.Enabled = false;
            this.ShowIndexingToolStripMenuItem.Name = "ShowIndexingToolStripMenuItem";
            this.ShowIndexingToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.ShowIndexingToolStripMenuItem.Text = "Индексация";
            this.ShowIndexingToolStripMenuItem.Click += new System.EventHandler(this.btn_ShowIndexing_Click);
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
            // loggerToolStripMenuItem
            // 
            this.loggerToolStripMenuItem.Name = "loggerToolStripMenuItem";
            this.loggerToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.loggerToolStripMenuItem.Text = "Logger";
            this.loggerToolStripMenuItem.Click += new System.EventHandler(this.LoggerToolStripMenuItem_Click);
            // 
            // рекламаToolStripMenuItem
            // 
            this.рекламаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReportToolStripMenuItem,
            this.updateReportToolStripMenuItem,
            this.showAdvDataToolStripMenuItem});
            this.рекламаToolStripMenuItem.Name = "рекламаToolStripMenuItem";
            this.рекламаToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.рекламаToolStripMenuItem.Text = "Реклама";
            // 
            // addReportToolStripMenuItem
            // 
            this.addReportToolStripMenuItem.Name = "addReportToolStripMenuItem";
            this.addReportToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addReportToolStripMenuItem.Text = "Добавить отчет";
            this.addReportToolStripMenuItem.Click += new System.EventHandler(this.AddReportToolStripMenuItem_Click);
            // 
            // updateReportToolStripMenuItem
            // 
            this.updateReportToolStripMenuItem.Name = "updateReportToolStripMenuItem";
            this.updateReportToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.updateReportToolStripMenuItem.Text = "Обновить отчет";
            this.updateReportToolStripMenuItem.Click += new System.EventHandler(this.UpdateReportToolStripMenuItem_Click);
            // 
            // сотрудникToolStripMenuItem
            // 
            this.сотрудникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonalInfoToolStripMenuItem,
            this.registerNewEmployeeToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.LogOutToolStripMenuItem});
            this.сотрудникToolStripMenuItem.Name = "сотрудникToolStripMenuItem";
            this.сотрудникToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.сотрудникToolStripMenuItem.Text = "Сотрудник";
            // 
            // ShowPersonalInfoToolStripMenuItem
            // 
            this.ShowPersonalInfoToolStripMenuItem.Name = "ShowPersonalInfoToolStripMenuItem";
            this.ShowPersonalInfoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ShowPersonalInfoToolStripMenuItem.Text = "Личный кабинет";
            this.ShowPersonalInfoToolStripMenuItem.Click += new System.EventHandler(this.ShowPersonalInfoToolStripMenuItem_Click);
            // 
            // registerNewEmployeeToolStripMenuItem
            // 
            this.registerNewEmployeeToolStripMenuItem.Name = "registerNewEmployeeToolStripMenuItem";
            this.registerNewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.registerNewEmployeeToolStripMenuItem.Text = "Регистрация сотрудника";
            this.registerNewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.registerNewEmployeeToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.employeesToolStripMenuItem.Text = "Сотрудники";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // LogOutToolStripMenuItem
            // 
            this.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem";
            this.LogOutToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.LogOutToolStripMenuItem.Text = "Завершить сеанс";
            this.LogOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(771, 2);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(210, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Привет, Бандит";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // showAdvDataToolStripMenuItem
            // 
            this.showAdvDataToolStripMenuItem.Name = "showAdvDataToolStripMenuItem";
            this.showAdvDataToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showAdvDataToolStripMenuItem.Text = "Посмотреть";
            this.showAdvDataToolStripMenuItem.Click += new System.EventHandler(this.showAdvDataToolStripMenuItem_Click);
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 536);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormView_FormClosing);
            this.Load += new System.EventHandler(this.MainFormView_Load);
            this.VisibleChanged += new System.EventHandler(this.MainFormView_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem registerNewEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggerToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem рекламаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAdvDataToolStripMenuItem;
    }
}