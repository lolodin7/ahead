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
            this.SuspendLayout();
            // 
            // btn_DoSemCore
            // 
            this.btn_DoSemCore.Location = new System.Drawing.Point(12, 12);
            this.btn_DoSemCore.Name = "btn_DoSemCore";
            this.btn_DoSemCore.Size = new System.Drawing.Size(195, 81);
            this.btn_DoSemCore.TabIndex = 0;
            this.btn_DoSemCore.Text = "Собрать семантическое ядро";
            this.btn_DoSemCore.UseVisualStyleBackColor = true;
            this.btn_DoSemCore.Click += new System.EventHandler(this.btn_DoSemCore_Click);
            // 
            // btn_DoSemantics
            // 
            this.btn_DoSemantics.Location = new System.Drawing.Point(313, 12);
            this.btn_DoSemantics.Name = "btn_DoSemantics";
            this.btn_DoSemantics.Size = new System.Drawing.Size(195, 81);
            this.btn_DoSemantics.TabIndex = 1;
            this.btn_DoSemantics.Text = "Семантика";
            this.btn_DoSemantics.UseVisualStyleBackColor = true;
            this.btn_DoSemantics.Click += new System.EventHandler(this.btn_DoSemantics_Click);
            // 
            // btn_DoRewriteSemCore
            // 
            this.btn_DoRewriteSemCore.Location = new System.Drawing.Point(12, 117);
            this.btn_DoRewriteSemCore.Name = "btn_DoRewriteSemCore";
            this.btn_DoRewriteSemCore.Size = new System.Drawing.Size(195, 81);
            this.btn_DoRewriteSemCore.TabIndex = 2;
            this.btn_DoRewriteSemCore.Text = "Пересобрать семантическое ядро";
            this.btn_DoRewriteSemCore.UseVisualStyleBackColor = true;
            // 
            // btn_DoProductType
            // 
            this.btn_DoProductType.Location = new System.Drawing.Point(614, 105);
            this.btn_DoProductType.Name = "btn_DoProductType";
            this.btn_DoProductType.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProductType.TabIndex = 3;
            this.btn_DoProductType.Text = "Управление ProductType";
            this.btn_DoProductType.UseVisualStyleBackColor = true;
            // 
            // btn_DoKeywordCategory
            // 
            this.btn_DoKeywordCategory.Location = new System.Drawing.Point(614, 241);
            this.btn_DoKeywordCategory.Name = "btn_DoKeywordCategory";
            this.btn_DoKeywordCategory.Size = new System.Drawing.Size(195, 81);
            this.btn_DoKeywordCategory.TabIndex = 4;
            this.btn_DoKeywordCategory.Text = "Управление KeywordCategory";
            this.btn_DoKeywordCategory.UseVisualStyleBackColor = true;
            // 
            // btn_DoProducts
            // 
            this.btn_DoProducts.Location = new System.Drawing.Point(313, 117);
            this.btn_DoProducts.Name = "btn_DoProducts";
            this.btn_DoProducts.Size = new System.Drawing.Size(195, 81);
            this.btn_DoProducts.TabIndex = 5;
            this.btn_DoProducts.Text = "Управление продуктами";
            this.btn_DoProducts.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 533);
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
    }
}