namespace Excel_Parse
{
    partial class SemCoreArchiveView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SemCoreArchiveView));
            this.label5 = new System.Windows.Forms.Label();
            this.btn_StartAddingKey = new System.Windows.Forms.Button();
            this.groupBox_Editing = new System.Windows.Forms.GroupBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ProductType2 = new System.Windows.Forms.ComboBox();
            this.rtb_KeyValue = new System.Windows.Forms.RichTextBox();
            this.cb_KeywordCategory2 = new System.Windows.Forms.ComboBox();
            this.rtb_KeyName = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtb_FindKeyword = new System.Windows.Forms.RichTextBox();
            this.btn_Export = new System.Windows.Forms.Button();
            this.lb_ProductType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ProductType = new System.Windows.Forms.ComboBox();
            this.lb_KeywordCategory = new System.Windows.Forms.Label();
            this.btn_GetKeywords = new System.Windows.Forms.Button();
            this.cb_KeywordCategory = new System.Windows.Forms.ComboBox();
            this.dgv_Keywords = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_Editing.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Keywords)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(168, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(679, 107);
            this.label5.TabIndex = 37;
            this.label5.Text = "Упс, похоже, не найдено ни одного ключа :(";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // btn_StartAddingKey
            // 
            this.btn_StartAddingKey.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_StartAddingKey.FlatAppearance.BorderSize = 0;
            this.btn_StartAddingKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartAddingKey.Location = new System.Drawing.Point(930, 700);
            this.btn_StartAddingKey.Name = "btn_StartAddingKey";
            this.btn_StartAddingKey.Size = new System.Drawing.Size(90, 91);
            this.btn_StartAddingKey.TabIndex = 36;
            this.btn_StartAddingKey.Text = "Добавить новый ключ";
            this.btn_StartAddingKey.UseVisualStyleBackColor = false;
            // 
            // groupBox_Editing
            // 
            this.groupBox_Editing.Controls.Add(this.btn_Cancel);
            this.groupBox_Editing.Controls.Add(this.btn_Save);
            this.groupBox_Editing.Controls.Add(this.label3);
            this.groupBox_Editing.Controls.Add(this.cb_ProductType2);
            this.groupBox_Editing.Controls.Add(this.rtb_KeyValue);
            this.groupBox_Editing.Controls.Add(this.cb_KeywordCategory2);
            this.groupBox_Editing.Controls.Add(this.rtb_KeyName);
            this.groupBox_Editing.Controls.Add(this.label4);
            this.groupBox_Editing.Enabled = false;
            this.groupBox_Editing.Location = new System.Drawing.Point(11, 693);
            this.groupBox_Editing.Name = "groupBox_Editing";
            this.groupBox_Editing.Size = new System.Drawing.Size(902, 100);
            this.groupBox_Editing.TabIndex = 35;
            this.groupBox_Editing.TabStop = false;
            this.groupBox_Editing.Text = "Редактирование ключа";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(468, 61);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 33);
            this.btn_Cancel.TabIndex = 39;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(263, 61);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(150, 33);
            this.btn_Save.TabIndex = 38;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(392, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "Вид товара";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_ProductType2
            // 
            this.cb_ProductType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType2.FormattingEnabled = true;
            this.cb_ProductType2.Location = new System.Drawing.Point(346, 34);
            this.cb_ProductType2.Name = "cb_ProductType2";
            this.cb_ProductType2.Size = new System.Drawing.Size(196, 21);
            this.cb_ProductType2.TabIndex = 32;
            // 
            // rtb_KeyValue
            // 
            this.rtb_KeyValue.Location = new System.Drawing.Point(226, 35);
            this.rtb_KeyValue.Multiline = false;
            this.rtb_KeyValue.Name = "rtb_KeyValue";
            this.rtb_KeyValue.Size = new System.Drawing.Size(86, 20);
            this.rtb_KeyValue.TabIndex = 1;
            this.rtb_KeyValue.Text = "";
            // 
            // cb_KeywordCategory2
            // 
            this.cb_KeywordCategory2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory2.FormattingEnabled = true;
            this.cb_KeywordCategory2.Location = new System.Drawing.Point(587, 34);
            this.cb_KeywordCategory2.Name = "cb_KeywordCategory2";
            this.cb_KeywordCategory2.Size = new System.Drawing.Size(196, 21);
            this.cb_KeywordCategory2.TabIndex = 33;
            // 
            // rtb_KeyName
            // 
            this.rtb_KeyName.Location = new System.Drawing.Point(6, 35);
            this.rtb_KeyName.Multiline = false;
            this.rtb_KeyName.Name = "rtb_KeyName";
            this.rtb_KeyName.Size = new System.Drawing.Size(193, 20);
            this.rtb_KeyName.TabIndex = 0;
            this.rtb_KeyName.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(622, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 23);
            this.label4.TabIndex = 35;
            this.label4.Text = "Категория ключей";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rtb_FindKeyword);
            this.groupBox1.Controls.Add(this.btn_Export);
            this.groupBox1.Controls.Add(this.lb_ProductType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_ProductType);
            this.groupBox1.Controls.Add(this.lb_KeywordCategory);
            this.groupBox1.Controls.Add(this.btn_GetKeywords);
            this.groupBox1.Controls.Add(this.cb_KeywordCategory);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 86);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(740, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Найдено: 250";
            this.label2.Visible = false;
            // 
            // rtb_FindKeyword
            // 
            this.rtb_FindKeyword.Location = new System.Drawing.Point(681, 42);
            this.rtb_FindKeyword.Multiline = false;
            this.rtb_FindKeyword.Name = "rtb_FindKeyword";
            this.rtb_FindKeyword.Size = new System.Drawing.Size(196, 20);
            this.rtb_FindKeyword.TabIndex = 30;
            this.rtb_FindKeyword.Text = "";
            this.rtb_FindKeyword.TextChanged += new System.EventHandler(this.rtb_FindKeyword_TextChanged);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Export.FlatAppearance.BorderSize = 0;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Location = new System.Drawing.Point(899, 27);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(104, 47);
            this.btn_Export.TabIndex = 29;
            this.btn_Export.Text = "Экспорт";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // lb_ProductType
            // 
            this.lb_ProductType.Location = new System.Drawing.Point(64, 16);
            this.lb_ProductType.Name = "lb_ProductType";
            this.lb_ProductType.Size = new System.Drawing.Size(100, 23);
            this.lb_ProductType.TabIndex = 8;
            this.lb_ProductType.Text = "Вид товара";
            this.lb_ProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Поиск ключа";
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Location = new System.Drawing.Point(18, 42);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(196, 21);
            this.cb_ProductType.TabIndex = 3;
            // 
            // lb_KeywordCategory
            // 
            this.lb_KeywordCategory.Location = new System.Drawing.Point(294, 16);
            this.lb_KeywordCategory.Name = "lb_KeywordCategory";
            this.lb_KeywordCategory.Size = new System.Drawing.Size(124, 23);
            this.lb_KeywordCategory.TabIndex = 10;
            this.lb_KeywordCategory.Text = "Категория ключей";
            this.lb_KeywordCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GetKeywords
            // 
            this.btn_GetKeywords.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_GetKeywords.FlatAppearance.BorderSize = 0;
            this.btn_GetKeywords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetKeywords.Location = new System.Drawing.Point(495, 27);
            this.btn_GetKeywords.Name = "btn_GetKeywords";
            this.btn_GetKeywords.Size = new System.Drawing.Size(149, 47);
            this.btn_GetKeywords.TabIndex = 26;
            this.btn_GetKeywords.Text = "Показать ключи";
            this.btn_GetKeywords.UseVisualStyleBackColor = false;
            this.btn_GetKeywords.Click += new System.EventHandler(this.btn_GetKeywords_Click);
            // 
            // cb_KeywordCategory
            // 
            this.cb_KeywordCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_KeywordCategory.FormattingEnabled = true;
            this.cb_KeywordCategory.Location = new System.Drawing.Point(259, 42);
            this.cb_KeywordCategory.Name = "cb_KeywordCategory";
            this.cb_KeywordCategory.Size = new System.Drawing.Size(196, 21);
            this.cb_KeywordCategory.TabIndex = 4;
            // 
            // dgv_Keywords
            // 
            this.dgv_Keywords.AllowUserToAddRows = false;
            this.dgv_Keywords.AllowUserToDeleteRows = false;
            this.dgv_Keywords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Keywords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Keywords.Location = new System.Drawing.Point(10, 99);
            this.dgv_Keywords.Name = "dgv_Keywords";
            this.dgv_Keywords.ReadOnly = true;
            this.dgv_Keywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Keywords.Size = new System.Drawing.Size(1010, 588);
            this.dgv_Keywords.TabIndex = 33;
            this.dgv_Keywords.Visible = false;
            // 
            // SemCoreArchiveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 801);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_StartAddingKey);
            this.Controls.Add(this.groupBox_Editing);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Keywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SemCoreArchiveView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История ключей - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemCoreArchiveView_FormClosing);
            this.groupBox_Editing.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Keywords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_StartAddingKey;
        private System.Windows.Forms.GroupBox groupBox_Editing;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_ProductType2;
        private System.Windows.Forms.RichTextBox rtb_KeyValue;
        private System.Windows.Forms.ComboBox cb_KeywordCategory2;
        private System.Windows.Forms.RichTextBox rtb_KeyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtb_FindKeyword;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label lb_ProductType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.Label lb_KeywordCategory;
        private System.Windows.Forms.Button btn_GetKeywords;
        private System.Windows.Forms.ComboBox cb_KeywordCategory;
        private System.Windows.Forms.DataGridView dgv_Keywords;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}