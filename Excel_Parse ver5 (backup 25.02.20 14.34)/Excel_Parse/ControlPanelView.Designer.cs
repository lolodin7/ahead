﻿namespace Excel_Parse
{
    partial class ControlPanelView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanelView));
            this.lb_Name = new System.Windows.Forms.Label();
            this.lb_Login = new System.Windows.Forms.Label();
            this.lb_Password = new System.Windows.Forms.Label();
            this.lb_Question = new System.Windows.Forms.Label();
            this.lb_Answer = new System.Windows.Forms.Label();
            this.lb_AnswerTxt = new System.Windows.Forms.Label();
            this.lb_QuestionTxt = new System.Windows.Forms.Label();
            this.lb_Passwordtxt = new System.Windows.Forms.Label();
            this.lb_LoginTxt = new System.Windows.Forms.Label();
            this.lb_NameTxt = new System.Windows.Forms.Label();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.btn_ChangeName = new System.Windows.Forms.Button();
            this.tb_ChangeName = new System.Windows.Forms.TextBox();
            this.btn_ChangeQuestion = new System.Windows.Forms.Button();
            this.btn_ChangeAnswer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Role = new System.Windows.Forms.Label();
            this.btn_CancelChangeName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Name
            // 
            this.lb_Name.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Name.Location = new System.Drawing.Point(100, 96);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(174, 23);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "Имя";
            this.lb_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Login
            // 
            this.lb_Login.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Login.Location = new System.Drawing.Point(99, 9);
            this.lb_Login.Name = "lb_Login";
            this.lb_Login.Size = new System.Drawing.Size(50, 23);
            this.lb_Login.TabIndex = 1;
            this.lb_Login.Text = "Логин";
            this.lb_Login.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Password
            // 
            this.lb_Password.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Password.Location = new System.Drawing.Point(99, 193);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(84, 23);
            this.lb_Password.TabIndex = 2;
            this.lb_Password.Text = "***************";
            this.lb_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Question
            // 
            this.lb_Question.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Question.Location = new System.Drawing.Point(99, 284);
            this.lb_Question.Name = "lb_Question";
            this.lb_Question.Size = new System.Drawing.Size(213, 23);
            this.lb_Question.TabIndex = 3;
            this.lb_Question.Text = "Вопрос";
            this.lb_Question.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Answer
            // 
            this.lb_Answer.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Answer.Location = new System.Drawing.Point(99, 375);
            this.lb_Answer.Name = "lb_Answer";
            this.lb_Answer.Size = new System.Drawing.Size(84, 23);
            this.lb_Answer.TabIndex = 4;
            this.lb_Answer.Text = "***************";
            this.lb_Answer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_AnswerTxt
            // 
            this.lb_AnswerTxt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_AnswerTxt.Location = new System.Drawing.Point(12, 375);
            this.lb_AnswerTxt.Name = "lb_AnswerTxt";
            this.lb_AnswerTxt.Size = new System.Drawing.Size(62, 23);
            this.lb_AnswerTxt.TabIndex = 9;
            this.lb_AnswerTxt.Text = "Ответ:";
            this.lb_AnswerTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_QuestionTxt
            // 
            this.lb_QuestionTxt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_QuestionTxt.Location = new System.Drawing.Point(12, 284);
            this.lb_QuestionTxt.Name = "lb_QuestionTxt";
            this.lb_QuestionTxt.Size = new System.Drawing.Size(62, 23);
            this.lb_QuestionTxt.TabIndex = 8;
            this.lb_QuestionTxt.Text = "Вопрос:";
            this.lb_QuestionTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Passwordtxt
            // 
            this.lb_Passwordtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Passwordtxt.Location = new System.Drawing.Point(12, 193);
            this.lb_Passwordtxt.Name = "lb_Passwordtxt";
            this.lb_Passwordtxt.Size = new System.Drawing.Size(62, 23);
            this.lb_Passwordtxt.TabIndex = 7;
            this.lb_Passwordtxt.Text = "Пароль:";
            this.lb_Passwordtxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_LoginTxt
            // 
            this.lb_LoginTxt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_LoginTxt.Location = new System.Drawing.Point(12, 9);
            this.lb_LoginTxt.Name = "lb_LoginTxt";
            this.lb_LoginTxt.Size = new System.Drawing.Size(62, 23);
            this.lb_LoginTxt.TabIndex = 6;
            this.lb_LoginTxt.Text = "Логин:";
            this.lb_LoginTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_NameTxt
            // 
            this.lb_NameTxt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_NameTxt.Location = new System.Drawing.Point(12, 98);
            this.lb_NameTxt.Name = "lb_NameTxt";
            this.lb_NameTxt.Size = new System.Drawing.Size(62, 23);
            this.lb_NameTxt.TabIndex = 5;
            this.lb_NameTxt.Text = "Имя:";
            this.lb_NameTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ChangePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ChangePassword.Location = new System.Drawing.Point(16, 219);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(123, 27);
            this.btn_ChangePassword.TabIndex = 10;
            this.btn_ChangePassword.Text = "Изменить";
            this.btn_ChangePassword.UseVisualStyleBackColor = false;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // btn_ChangeName
            // 
            this.btn_ChangeName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ChangeName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ChangeName.Location = new System.Drawing.Point(16, 129);
            this.btn_ChangeName.Name = "btn_ChangeName";
            this.btn_ChangeName.Size = new System.Drawing.Size(123, 27);
            this.btn_ChangeName.TabIndex = 11;
            this.btn_ChangeName.Text = "Изменить";
            this.btn_ChangeName.UseVisualStyleBackColor = false;
            this.btn_ChangeName.Click += new System.EventHandler(this.btn_ChangeName_Click);
            // 
            // tb_ChangeName
            // 
            this.tb_ChangeName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_ChangeName.Location = new System.Drawing.Point(103, 98);
            this.tb_ChangeName.Name = "tb_ChangeName";
            this.tb_ChangeName.Size = new System.Drawing.Size(179, 25);
            this.tb_ChangeName.TabIndex = 12;
            this.tb_ChangeName.Visible = false;
            // 
            // btn_ChangeQuestion
            // 
            this.btn_ChangeQuestion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ChangeQuestion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ChangeQuestion.Location = new System.Drawing.Point(16, 310);
            this.btn_ChangeQuestion.Name = "btn_ChangeQuestion";
            this.btn_ChangeQuestion.Size = new System.Drawing.Size(123, 27);
            this.btn_ChangeQuestion.TabIndex = 13;
            this.btn_ChangeQuestion.Text = "Изменить";
            this.btn_ChangeQuestion.UseVisualStyleBackColor = false;
            this.btn_ChangeQuestion.Click += new System.EventHandler(this.btn_ChangeQuestion_Click);
            // 
            // btn_ChangeAnswer
            // 
            this.btn_ChangeAnswer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ChangeAnswer.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ChangeAnswer.Location = new System.Drawing.Point(16, 401);
            this.btn_ChangeAnswer.Name = "btn_ChangeAnswer";
            this.btn_ChangeAnswer.Size = new System.Drawing.Size(123, 27);
            this.btn_ChangeAnswer.TabIndex = 14;
            this.btn_ChangeAnswer.Text = "Изменить";
            this.btn_ChangeAnswer.UseVisualStyleBackColor = false;
            this.btn_ChangeAnswer.Click += new System.EventHandler(this.btn_ChangeAnswer_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Статус:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Role
            // 
            this.lb_Role.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Role.Location = new System.Drawing.Point(99, 52);
            this.lb_Role.Name = "lb_Role";
            this.lb_Role.Size = new System.Drawing.Size(183, 23);
            this.lb_Role.TabIndex = 16;
            this.lb_Role.Text = "Статус:";
            this.lb_Role.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_CancelChangeName
            // 
            this.btn_CancelChangeName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_CancelChangeName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CancelChangeName.Location = new System.Drawing.Point(159, 129);
            this.btn_CancelChangeName.Name = "btn_CancelChangeName";
            this.btn_CancelChangeName.Size = new System.Drawing.Size(123, 27);
            this.btn_CancelChangeName.TabIndex = 17;
            this.btn_CancelChangeName.Text = "Отмена";
            this.btn_CancelChangeName.UseVisualStyleBackColor = false;
            this.btn_CancelChangeName.Visible = false;
            this.btn_CancelChangeName.Click += new System.EventHandler(this.btn_CancelChangeName_Click);
            // 
            // ControlPanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 449);
            this.Controls.Add(this.btn_CancelChangeName);
            this.Controls.Add(this.lb_Role);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ChangeAnswer);
            this.Controls.Add(this.btn_ChangeQuestion);
            this.Controls.Add(this.tb_ChangeName);
            this.Controls.Add(this.btn_ChangeName);
            this.Controls.Add(this.btn_ChangePassword);
            this.Controls.Add(this.lb_AnswerTxt);
            this.Controls.Add(this.lb_QuestionTxt);
            this.Controls.Add(this.lb_Passwordtxt);
            this.Controls.Add(this.lb_LoginTxt);
            this.Controls.Add(this.lb_NameTxt);
            this.Controls.Add(this.lb_Answer);
            this.Controls.Add(this.lb_Question);
            this.Controls.Add(this.lb_Password);
            this.Controls.Add(this.lb_Login);
            this.Controls.Add(this.lb_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlPanelView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личный кабинет - Bona Fides";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanelView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Label lb_Login;
        private System.Windows.Forms.Label lb_Password;
        private System.Windows.Forms.Label lb_Question;
        private System.Windows.Forms.Label lb_Answer;
        private System.Windows.Forms.Label lb_AnswerTxt;
        private System.Windows.Forms.Label lb_QuestionTxt;
        private System.Windows.Forms.Label lb_Passwordtxt;
        private System.Windows.Forms.Label lb_LoginTxt;
        private System.Windows.Forms.Label lb_NameTxt;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.Button btn_ChangeName;
        private System.Windows.Forms.TextBox tb_ChangeName;
        private System.Windows.Forms.Button btn_ChangeQuestion;
        private System.Windows.Forms.Button btn_ChangeAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Role;
        private System.Windows.Forms.Button btn_CancelChangeName;
    }
}