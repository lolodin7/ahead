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
            this.SuspendLayout();
            // 
            // btn_DoSemCore
            // 
            this.btn_DoSemCore.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoSemCore.FlatAppearance.BorderSize = 0;
            this.btn_DoSemCore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btn_DoSemantics.FlatAppearance.BorderSize = 0;
            this.btn_DoSemantics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoSemantics.Location = new System.Drawing.Point(313, 117);
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
            this.btn_DoProductType.FlatAppearance.BorderSize = 0;
            this.btn_DoProductType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoProductType.Location = new System.Drawing.Point(611, 235);
            this.btn_DoProductType.Name = "btn_DoProductType";
            this.btn_DoProductType.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProductType.TabIndex = 3;
            this.btn_DoProductType.Text = "Добавление вида товара";
            this.btn_DoProductType.UseVisualStyleBackColor = false;
            this.btn_DoProductType.Click += new System.EventHandler(this.btn_DoProductType_Click);
            // 
            // btn_DoKeywordCategory
            // 
            this.btn_DoKeywordCategory.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DoKeywordCategory.FlatAppearance.BorderSize = 0;
            this.btn_DoKeywordCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoKeywordCategory.Location = new System.Drawing.Point(12, 343);
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
            this.btn_DoProducts.Location = new System.Drawing.Point(611, 12);
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
            this.btn_Exit.Location = new System.Drawing.Point(611, 440);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(195, 81);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_ShowIndexing
            // 
            this.btn_ShowIndexing.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btn_ShowIndexing.FlatAppearance.BorderSize = 0;
            this.btn_ShowIndexing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowIndexing.Location = new System.Drawing.Point(611, 117);
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
            this.button1.Location = new System.Drawing.Point(309, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 81);
            this.button1.TabIndex = 11;
            this.button1.Text = "Создать семантику для нового продукта";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 533);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bona Fides";
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
        private System.Windows.Forms.Button btn_ShowIndexing;
        private System.Windows.Forms.Button button1;
    }
}