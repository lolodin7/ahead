namespace Analytics
{
    partial class PnL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnL));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_DateEnd = new System.Windows.Forms.TextBox();
            this.tb_DateStart = new System.Windows.Forms.TextBox();
            this.monthCalendarEnd = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarStart = new System.Windows.Forms.MonthCalendar();
            this.btn_ChooseDate = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_DateEnd);
            this.panel1.Controls.Add(this.tb_DateStart);
            this.panel1.Controls.Add(this.monthCalendarEnd);
            this.panel1.Controls.Add(this.monthCalendarStart);
            this.panel1.Location = new System.Drawing.Point(830, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 199);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // tb_DateEnd
            // 
            this.tb_DateEnd.Location = new System.Drawing.Point(194, 4);
            this.tb_DateEnd.Name = "tb_DateEnd";
            this.tb_DateEnd.Size = new System.Drawing.Size(165, 20);
            this.tb_DateEnd.TabIndex = 4;
            this.tb_DateEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_DateEnd_KeyPress);
            // 
            // tb_DateStart
            // 
            this.tb_DateStart.Location = new System.Drawing.Point(4, 4);
            this.tb_DateStart.Name = "tb_DateStart";
            this.tb_DateStart.Size = new System.Drawing.Size(165, 20);
            this.tb_DateStart.TabIndex = 3;
            this.tb_DateStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_DateStart_KeyPress);
            // 
            // monthCalendarEnd
            // 
            this.monthCalendarEnd.Location = new System.Drawing.Point(195, 31);
            this.monthCalendarEnd.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.monthCalendarEnd.MaxSelectionCount = 1;
            this.monthCalendarEnd.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.monthCalendarEnd.Name = "monthCalendarEnd";
            this.monthCalendarEnd.ShowToday = false;
            this.monthCalendarEnd.TabIndex = 1;
            this.monthCalendarEnd.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarEnd_DateChanged);
            // 
            // monthCalendarStart
            // 
            this.monthCalendarStart.Location = new System.Drawing.Point(4, 31);
            this.monthCalendarStart.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.monthCalendarStart.MaxSelectionCount = 1;
            this.monthCalendarStart.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.monthCalendarStart.Name = "monthCalendarStart";
            this.monthCalendarStart.ShowToday = false;
            this.monthCalendarStart.TabIndex = 0;
            this.monthCalendarStart.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStart_DateChanged);
            // 
            // btn_ChooseDate
            // 
            this.btn_ChooseDate.Location = new System.Drawing.Point(932, 2);
            this.btn_ChooseDate.Name = "btn_ChooseDate";
            this.btn_ChooseDate.Size = new System.Drawing.Size(242, 22);
            this.btn_ChooseDate.TabIndex = 10;
            this.btn_ChooseDate.Text = "Выбор даты";
            this.btn_ChooseDate.UseVisualStyleBackColor = true;
            this.btn_ChooseDate.Click += new System.EventHandler(this.btn_ChooseDate_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(108, 76);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(141, 22);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1185, 432);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "7 дней";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 24);
            this.button2.TabIndex = 15;
            this.button2.Text = "30 дней";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(678, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 24);
            this.button3.TabIndex = 16;
            this.button3.Text = "6 месяцев";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(784, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 24);
            this.button4.TabIndex = 17;
            this.button4.Text = "Год";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // PnL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 603);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ChooseDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PnL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PnL_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_DateEnd;
        private System.Windows.Forms.TextBox tb_DateStart;
        private System.Windows.Forms.MonthCalendar monthCalendarEnd;
        private System.Windows.Forms.MonthCalendar monthCalendarStart;
        private System.Windows.Forms.Button btn_ChooseDate;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}