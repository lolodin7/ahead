namespace Excel_Parse
{
    partial class IndexingStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexingStatus));
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_NotOk = new System.Windows.Forms.Button();
            this.btn_Closed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.LightGray;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.Location = new System.Drawing.Point(57, 36);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(177, 61);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "Всё в порядке (Ok)";
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_NotOk
            // 
            this.btn_NotOk.BackColor = System.Drawing.Color.LightGray;
            this.btn_NotOk.FlatAppearance.BorderSize = 0;
            this.btn_NotOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NotOk.Location = new System.Drawing.Point(57, 119);
            this.btn_NotOk.Name = "btn_NotOk";
            this.btn_NotOk.Size = new System.Drawing.Size(177, 61);
            this.btn_NotOk.TabIndex = 1;
            this.btn_NotOk.Text = "Есть проблемы (Not Ok)";
            this.btn_NotOk.UseVisualStyleBackColor = false;
            this.btn_NotOk.Click += new System.EventHandler(this.btn_NotOk_Click);
            // 
            // btn_Closed
            // 
            this.btn_Closed.BackColor = System.Drawing.Color.LightGray;
            this.btn_Closed.FlatAppearance.BorderSize = 0;
            this.btn_Closed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Closed.Location = new System.Drawing.Point(57, 201);
            this.btn_Closed.Name = "btn_Closed";
            this.btn_Closed.Size = new System.Drawing.Size(177, 61);
            this.btn_Closed.TabIndex = 2;
            this.btn_Closed.Text = "Листинг закрыт (Closed)";
            this.btn_Closed.UseVisualStyleBackColor = false;
            this.btn_Closed.Click += new System.EventHandler(this.btn_Closed_Click);
            // 
            // IndexingStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 316);
            this.Controls.Add(this.btn_Closed);
            this.Controls.Add(this.btn_NotOk);
            this.Controls.Add(this.btn_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndexingStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор статуса";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndexingStatus_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.IndexingStatus_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_NotOk;
        private System.Windows.Forms.Button btn_Closed;
    }
}