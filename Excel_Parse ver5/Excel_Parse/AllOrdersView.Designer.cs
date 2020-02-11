namespace Excel_Parse
{
    partial class AllOrdersView
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_loadFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_saveToDB = new System.Windows.Forms.Button();
            this.dgv_mp = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MP_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rb_PDW = new System.Windows.Forms.RadioButton();
            this.rb_LTB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_loadFile
            // 
            this.btn_loadFile.Location = new System.Drawing.Point(351, 22);
            this.btn_loadFile.Name = "btn_loadFile";
            this.btn_loadFile.Size = new System.Drawing.Size(190, 66);
            this.btn_loadFile.TabIndex = 0;
            this.btn_loadFile.Text = "Выбрать отчет";
            this.btn_loadFile.UseVisualStyleBackColor = true;
            this.btn_loadFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(299, 172);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(292, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btn_saveToDB
            // 
            this.btn_saveToDB.Location = new System.Drawing.Point(351, 259);
            this.btn_saveToDB.Name = "btn_saveToDB";
            this.btn_saveToDB.Size = new System.Drawing.Size(190, 66);
            this.btn_saveToDB.TabIndex = 2;
            this.btn_saveToDB.Text = "Сохранить в БД";
            this.btn_saveToDB.UseVisualStyleBackColor = true;
            this.btn_saveToDB.Click += new System.EventHandler(this.btn_saveToDB_Click);
            // 
            // dgv_mp
            // 
            this.dgv_mp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.MP_Id});
            this.dgv_mp.Location = new System.Drawing.Point(12, 59);
            this.dgv_mp.Name = "dgv_mp";
            this.dgv_mp.RowTemplate.Height = 24;
            this.dgv_mp.Size = new System.Drawing.Size(244, 288);
            this.dgv_mp.TabIndex = 4;
            // 
            // name
            // 
            this.name.HeaderText = "namecln";
            this.name.Name = "name";
            // 
            // MP_Id
            // 
            this.MP_Id.HeaderText = "mpidcln";
            this.MP_Id.Name = "MP_Id";
            // 
            // rb_PDW
            // 
            this.rb_PDW.AutoSize = true;
            this.rb_PDW.Checked = true;
            this.rb_PDW.Location = new System.Drawing.Point(21, 16);
            this.rb_PDW.Name = "rb_PDW";
            this.rb_PDW.Size = new System.Drawing.Size(50, 17);
            this.rb_PDW.TabIndex = 5;
            this.rb_PDW.TabStop = true;
            this.rb_PDW.Text = "PDW";
            this.rb_PDW.UseVisualStyleBackColor = true;
            this.rb_PDW.CheckedChanged += new System.EventHandler(this.rb_LTB_CheckedChanged);
            // 
            // rb_LTB
            // 
            this.rb_LTB.AutoSize = true;
            this.rb_LTB.Location = new System.Drawing.Point(141, 16);
            this.rb_LTB.Name = "rb_LTB";
            this.rb_LTB.Size = new System.Drawing.Size(42, 17);
            this.rb_LTB.TabIndex = 6;
            this.rb_LTB.Text = "LTB";
            this.rb_LTB.UseVisualStyleBackColor = true;
            this.rb_LTB.CheckedChanged += new System.EventHandler(this.rb_LTB_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_PDW);
            this.panel1.Controls.Add(this.rb_LTB);
            this.panel1.Location = new System.Drawing.Point(33, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 46);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(299, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 61);
            this.label1.TabIndex = 8;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_mp);
            this.Controls.Add(this.btn_saveToDB);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_loadFile);
            this.Name = "AllOrdersView";
            this.Text = "AllOrdersView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllOrdersView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_loadFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_saveToDB;
        private System.Windows.Forms.DataGridView dgv_mp;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MP_Id;
        private System.Windows.Forms.RadioButton rb_PDW;
        private System.Windows.Forms.RadioButton rb_LTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}