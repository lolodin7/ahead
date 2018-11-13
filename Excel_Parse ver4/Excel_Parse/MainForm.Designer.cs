namespace Excel_Parse
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_DoSemCore = new System.Windows.Forms.Button();
            this.btn_DoSemantics = new System.Windows.Forms.Button();
            this.btn_DoRewriteSemCore = new System.Windows.Forms.Button();
            this.btn_DoProductType = new System.Windows.Forms.Button();
            this.btn_DoKeywordCategory = new System.Windows.Forms.Button();
            this.btn_DoProducts = new System.Windows.Forms.Button();
            this.btn_ShowAllKeywords = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_DoSemCore
            // 
            this.btn_DoSemCore.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoSemCore.Location = new System.Drawing.Point(12, 12);
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
            this.btn_DoSemantics.Location = new System.Drawing.Point(313, 12);
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
            this.btn_DoRewriteSemCore.Location = new System.Drawing.Point(12, 117);
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
            this.btn_DoProductType.Location = new System.Drawing.Point(554, 12);
            this.btn_DoProductType.Name = "btn_DoProductType";
            this.btn_DoProductType.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProductType.TabIndex = 3;
            this.btn_DoProductType.Text = "Добавление новой категории товаров";
            this.btn_DoProductType.UseVisualStyleBackColor = false;
            this.btn_DoProductType.Click += new System.EventHandler(this.btn_DoProductType_Click);
            // 
            // btn_DoKeywordCategory
            // 
            this.btn_DoKeywordCategory.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoKeywordCategory.Location = new System.Drawing.Point(554, 117);
            this.btn_DoKeywordCategory.Name = "btn_DoKeywordCategory";
            this.btn_DoKeywordCategory.Size = new System.Drawing.Size(195, 81);
            this.btn_DoKeywordCategory.TabIndex = 4;
            this.btn_DoKeywordCategory.Text = "Управление KeywordCategory";
            this.btn_DoKeywordCategory.UseVisualStyleBackColor = false;
            this.btn_DoKeywordCategory.Click += new System.EventHandler(this.btn_DoKeywordCategory_Click);
            // 
            // btn_DoProducts
            // 
            this.btn_DoProducts.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoProducts.Location = new System.Drawing.Point(313, 117);
            this.btn_DoProducts.Name = "btn_DoProducts";
            this.btn_DoProducts.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProducts.TabIndex = 5;
            this.btn_DoProducts.Text = "Управление продуктами";
            this.btn_DoProducts.UseVisualStyleBackColor = false;
            this.btn_DoProducts.Click += new System.EventHandler(this.btn_DoProducts_Click);
            // 
            // btn_ShowAllKeywords
            // 
            this.btn_ShowAllKeywords.BackColor = System.Drawing.Color.Orange;
            this.btn_ShowAllKeywords.Location = new System.Drawing.Point(12, 235);
            this.btn_ShowAllKeywords.Name = "btn_ShowAllKeywords";
            this.btn_ShowAllKeywords.Size = new System.Drawing.Size(195, 81);
            this.btn_ShowAllKeywords.TabIndex = 6;
            this.btn_ShowAllKeywords.Text = "Просмотреть существующие ключи";
            this.btn_ShowAllKeywords.UseVisualStyleBackColor = false;
            this.btn_ShowAllKeywords.Click += new System.EventHandler(this.btn_ShowAllKeywords_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(724, 449);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(195, 81);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 533);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_ShowAllKeywords);
            this.Controls.Add(this.btn_DoProducts);
            this.Controls.Add(this.btn_DoKeywordCategory);
            this.Controls.Add(this.btn_DoProductType);
            this.Controls.Add(this.btn_DoRewriteSemCore);
            this.Controls.Add(this.btn_DoSemantics);
            this.Controls.Add(this.btn_DoSemCore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное окно";
            this.ResumeLayout(false);

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
    }
}