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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllOrdersView));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_loadFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_saveToDB = new System.Windows.Forms.Button();
            this.dgv_mp = new System.Windows.Forms.DataGridView();
            this.rb_PDW = new System.Windows.Forms.RadioButton();
            this.rb_LTB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MP_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtb_State = new System.Windows.Forms.RichTextBox();
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
            this.btn_loadFile.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_loadFile.Location = new System.Drawing.Point(160, 7);
            this.btn_loadFile.Name = "btn_loadFile";
            this.btn_loadFile.Size = new System.Drawing.Size(146, 46);
            this.btn_loadFile.TabIndex = 0;
            this.btn_loadFile.Text = "Выбрать отчет";
            this.btn_loadFile.UseVisualStyleBackColor = true;
            this.btn_loadFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(321, 252);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(292, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btn_saveToDB
            // 
            this.btn_saveToDB.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_saveToDB.Location = new System.Drawing.Point(369, 281);
            this.btn_saveToDB.Name = "btn_saveToDB";
            this.btn_saveToDB.Size = new System.Drawing.Size(190, 66);
            this.btn_saveToDB.TabIndex = 2;
            this.btn_saveToDB.Text = "Сохранить в БД";
            this.btn_saveToDB.UseVisualStyleBackColor = true;
            this.btn_saveToDB.Click += new System.EventHandler(this.btn_saveToDB_Click);
            // 
            // dgv_mp
            // 
            this.dgv_mp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_mp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.MP_Id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_mp.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_mp.Location = new System.Drawing.Point(12, 59);
            this.dgv_mp.Name = "dgv_mp";
            this.dgv_mp.RowTemplate.Height = 24;
            this.dgv_mp.Size = new System.Drawing.Size(294, 288);
            this.dgv_mp.TabIndex = 4;
            // 
            // rb_PDW
            // 
            this.rb_PDW.AutoSize = true;
            this.rb_PDW.Checked = true;
            this.rb_PDW.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_PDW.Location = new System.Drawing.Point(5, 12);
            this.rb_PDW.Name = "rb_PDW";
            this.rb_PDW.Size = new System.Drawing.Size(59, 23);
            this.rb_PDW.TabIndex = 5;
            this.rb_PDW.TabStop = true;
            this.rb_PDW.Text = "PDW";
            this.rb_PDW.UseVisualStyleBackColor = true;
            this.rb_PDW.CheckedChanged += new System.EventHandler(this.rb_LTB_CheckedChanged);
            // 
            // rb_LTB
            // 
            this.rb_LTB.AutoSize = true;
            this.rb_LTB.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_LTB.Location = new System.Drawing.Point(77, 12);
            this.rb_LTB.Name = "rb_LTB";
            this.rb_LTB.Size = new System.Drawing.Size(49, 23);
            this.rb_LTB.TabIndex = 6;
            this.rb_LTB.Text = "LTB";
            this.rb_LTB.UseVisualStyleBackColor = true;
            this.rb_LTB.CheckedChanged += new System.EventHandler(this.rb_LTB_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rb_PDW);
            this.panel1.Controls.Add(this.rb_LTB);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 46);
            this.panel1.TabIndex = 7;
            // 
            // name
            // 
            this.name.HeaderText = "Маркетплейс";
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // MP_Id
            // 
            this.MP_Id.HeaderText = "Маркетплейс Id";
            this.MP_Id.Name = "MP_Id";
            // 
            // rtb_State
            // 
            this.rtb_State.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_State.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_State.Location = new System.Drawing.Point(321, 7);
            this.rtb_State.Name = "rtb_State";
            this.rtb_State.ReadOnly = true;
            this.rtb_State.Size = new System.Drawing.Size(292, 239);
            this.rtb_State.TabIndex = 8;
            this.rtb_State.Text = "";
            // 
            // AllOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 359);
            this.Controls.Add(this.rtb_State);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_mp);
            this.Controls.Add(this.btn_saveToDB);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_loadFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllOrdersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузить Orders report";
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
        private System.Windows.Forms.RadioButton rb_PDW;
        private System.Windows.Forms.RadioButton rb_LTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MP_Id;
        private System.Windows.Forms.RichTextBox rtb_State;
    }
}