namespace Excel_Parse
{
    partial class ShowUsersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowUsersView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passhash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userroleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secretquestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userid,
            this.login,
            this.passhash,
            this.name,
            this.token1,
            this.token2,
            this.userroleid,
            this.secretquestion,
            this.answer,
            this.mac});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(762, 480);
            this.dataGridView1.TabIndex = 0;
            // 
            // userid
            // 
            this.userid.HeaderText = "useridclm";
            this.userid.Name = "userid";
            this.userid.ReadOnly = true;
            this.userid.Visible = false;
            // 
            // login
            // 
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 300;
            // 
            // passhash
            // 
            this.passhash.HeaderText = "passhash";
            this.passhash.Name = "passhash";
            this.passhash.ReadOnly = true;
            this.passhash.Visible = false;
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 250;
            // 
            // token1
            // 
            this.token1.HeaderText = "token1clm";
            this.token1.Name = "token1";
            this.token1.ReadOnly = true;
            this.token1.Visible = false;
            // 
            // token2
            // 
            this.token2.HeaderText = "token2clm";
            this.token2.Name = "token2";
            this.token2.ReadOnly = true;
            this.token2.Visible = false;
            // 
            // userroleid
            // 
            this.userroleid.HeaderText = "Роль пользователя";
            this.userroleid.Name = "userroleid";
            this.userroleid.ReadOnly = true;
            this.userroleid.Width = 150;
            // 
            // secretquestion
            // 
            this.secretquestion.HeaderText = "secretquestionclm";
            this.secretquestion.Name = "secretquestion";
            this.secretquestion.ReadOnly = true;
            this.secretquestion.Visible = false;
            // 
            // answer
            // 
            this.answer.HeaderText = "answerclm";
            this.answer.Name = "answer";
            this.answer.ReadOnly = true;
            this.answer.Visible = false;
            // 
            // mac
            // 
            this.mac.HeaderText = "macclm";
            this.mac.Name = "mac";
            this.mac.ReadOnly = true;
            this.mac.Visible = false;
            // 
            // ShowUsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 505);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowUsersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сотрудники - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowUsersView_FormClosing);
            this.Shown += new System.EventHandler(this.ShowUsersView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn passhash;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn token1;
        private System.Windows.Forms.DataGridViewTextBoxColumn token2;
        private System.Windows.Forms.DataGridViewTextBoxColumn userroleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn secretquestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn mac;
    }
}