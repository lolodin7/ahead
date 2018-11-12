namespace Excel_Parse
{
    partial class KeywordsAreExisted
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeywordsAreExisted));
            this.dgv_Keywords = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lb_Information = new System.Windows.Forms.Label();
            this.btn_SetAndInsertKeys = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lb_KeysCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Keywords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Keywords
            // 
            this.dgv_Keywords.AllowUserToAddRows = false;
            this.dgv_Keywords.AllowUserToDeleteRows = false;
            this.dgv_Keywords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Keywords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_Keywords.Location = new System.Drawing.Point(12, 12);
            this.dgv_Keywords.Name = "dgv_Keywords";
            this.dgv_Keywords.ReadOnly = true;
            this.dgv_Keywords.Size = new System.Drawing.Size(403, 565);
            this.dgv_Keywords.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Keyword";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(445, 475);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(132, 43);
            this.btn_Export.TabIndex = 1;
            this.btn_Export.Text = "Экспорт";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(445, 184);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(132, 43);
            this.btn_Edit.TabIndex = 2;
            this.btn_Edit.Text = "Редактировать";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(445, 534);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(132, 43);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Закрыть";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lb_Information
            // 
            this.lb_Information.Location = new System.Drawing.Point(421, 12);
            this.lb_Information.Name = "lb_Information";
            this.lb_Information.Size = new System.Drawing.Size(184, 169);
            this.lb_Information.TabIndex = 4;
            this.lb_Information.Text = resources.GetString("lb_Information.Text");
            // 
            // btn_SetAndInsertKeys
            // 
            this.btn_SetAndInsertKeys.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_SetAndInsertKeys.Location = new System.Drawing.Point(445, 266);
            this.btn_SetAndInsertKeys.Name = "btn_SetAndInsertKeys";
            this.btn_SetAndInsertKeys.Size = new System.Drawing.Size(132, 43);
            this.btn_SetAndInsertKeys.TabIndex = 5;
            this.btn_SetAndInsertKeys.Text = "Загрузить и обновить ключи";
            this.btn_SetAndInsertKeys.UseVisualStyleBackColor = true;
            this.btn_SetAndInsertKeys.Click += new System.EventHandler(this.btn_SetAndInsertKeys_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(424, 338);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(181, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // lb_KeysCount
            // 
            this.lb_KeysCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_KeysCount.Location = new System.Drawing.Point(442, 391);
            this.lb_KeysCount.Name = "lb_KeysCount";
            this.lb_KeysCount.Size = new System.Drawing.Size(135, 30);
            this.lb_KeysCount.TabIndex = 7;
            this.lb_KeysCount.Text = "label1";
            this.lb_KeysCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeywordsAreExisted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 589);
            this.Controls.Add(this.lb_KeysCount);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_SetAndInsertKeys);
            this.Controls.Add(this.lb_Information);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.dgv_Keywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeywordsAreExisted";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эти ключи уже существуют";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KeywordsAreExisted_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Keywords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Keywords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lb_Information;
        private System.Windows.Forms.Button btn_SetAndInsertKeys;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_KeysCount;
    }
}