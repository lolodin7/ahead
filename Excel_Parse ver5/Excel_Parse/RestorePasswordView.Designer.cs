namespace Excel_Parse
{
    partial class RestorePasswordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestorePasswordView));
            this.btn_Next = new System.Windows.Forms.Button();
            this.tb_Input1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Input2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(84, 188);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(196, 50);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = "Далее";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // tb_Input1
            // 
            this.tb_Input1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Input1.Location = new System.Drawing.Point(65, 90);
            this.tb_Input1.Name = "tb_Input1";
            this.tb_Input1.Size = new System.Drawing.Size(227, 26);
            this.tb_Input1.TabIndex = 5;
            this.tb_Input1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Input_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 62);
            this.label1.TabIndex = 4;
            this.label1.Text = "Для восстановления пароля введите свой логин в поле внизу.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Input2
            // 
            this.tb_Input2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Input2.Location = new System.Drawing.Point(65, 139);
            this.tb_Input2.Name = "tb_Input2";
            this.tb_Input2.Size = new System.Drawing.Size(227, 26);
            this.tb_Input2.TabIndex = 6;
            this.tb_Input2.Visible = false;
            this.tb_Input2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Input_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 62);
            this.label2.TabIndex = 7;
            this.label2.Text = "Для восстановления пароля введите свой логин в поле внизу.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // RestorePasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Input2);
            this.Controls.Add(this.tb_Input1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RestorePasswordView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Восстановление пароля";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RestorePasswordView_FormClosing);
            this.Shown += new System.EventHandler(this.RestorePasswordView_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.TextBox tb_Input1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Input2;
        private System.Windows.Forms.Label label2;
    }
}